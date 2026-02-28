# Update Procedure - Codeer.LowCode.Blazor 更新手順

## 概要

Codeer.LowCode.Blazor の新バージョンがリリースされた際に、
Fluent Blazor Bindings を追従させるための手順。

## Step 1: NuGet パッケージ更新

### 1.1 バージョン確認

```bash
cd C:\GitHub\Codeer.LowCode.Bindings.Fluent.Blazor
dotnet list package --outdated
```

### 1.2 更新対象ファイル

1. `Codeer.LowCode.Bindings.Fluent.Blazor/Codeer.LowCode.Bindings.Fluent.Blazor.csproj`
   - `Codeer.LowCode.Blazor` → 最新版
   - `Microsoft.FluentUI.AspNetCore.Components` → .NET 8 範囲の最新
   - `Microsoft.FluentUI.AspNetCore.Components.Icons` → 同上

2. `Example/LowCodeApp.Client/LowCodeApp.Client.csproj`
   - `Codeer.LowCode.Blazor` → 最新版

3. `Example/LowCodeApp.Client.Shared/LowCodeApp.Client.Shared.csproj`
   - `Codeer.LowCode.Blazor` → 最新版
   - **注意**: `Microsoft.Extensions.Http` は最新8.0.xが存在しない場合あり

4. `Example/LowCodeApp.Server.Shared/LowCodeApp.Server.Shared.csproj`
   - `Codeer.LowCode.Blazor` → 最新版

5. `Example/LowCodeApp.Designer/LowCodeApp.Designer.csproj`
   - `Codeer.LowCode.Blazor.Designer` → 最新版

6. `Example/LowCodeApp.Server/LowCodeApp.Server.csproj`

## Step 2: ビルドしてエラー確認

```bash
dotnet build Codeer.LowCode.Bindings.Fluent.Blazor.sln
```

**よくあるエラーパターン:**

| エラー | 原因 | 対処 |
|---|---|---|
| CS1061 (メンバーが見つからない) | API 変更 | 標準実装を確認して修正 |
| CS0535 (インターフェース未実装) | インターフェース変更 | 標準の Example から実装をコピー |
| CS0246 (型が見つからない) | 名前空間変更 | using を追加 |
| CS0612 (Obsolete) | 非推奨 API | 警告なら無視可、エラーなら代替 API へ |

## Step 3: 標準コンポーネントとの差分確認

### 3.1 比較対象ディレクトリ

| Fluent | 標準 |
|---|---|
| `Components/` | `C:\tfs\codeer\Codeer.LowCode.Blazor\Source\Codeer.LowCode.Blazor\Components\Fields\` |
| `Search/` | `C:\tfs\codeer\Codeer.LowCode.Blazor\Source\Codeer.LowCode.Blazor\Components\Search\` |
| `Designs/` | `C:\tfs\codeer\Codeer.LowCode.Blazor\Source\Codeer.LowCode.Blazor\Repository\Design\` |

### 3.2 確認ポイント

各コンポーネントについて以下をチェック:

1. **新しいプロパティ/機能の追加**
   - 標準の Design クラスに新プロパティが追加されていないか
   - 追加されていれば Fluent コンポーネントでも対応するか、[IgnoreBaseProperties] で非表示にするか判断

2. **ローカライズ対応**
   - 新しいテキスト表示箇所で `Field.Services.AppInfoService.Localize()` が使われているか

3. **IsSimpleSearchParameter**
   - 検索コンポーネントで範囲入力の条件分岐が正しいか

4. **イベントハンドラ**
   - 新しい OnXxx イベントが追加されていないか

5. **internal メソッド呼び出し**
   - 標準で `Field.Localize()` 等の internal メソッドが使われている場合、
     Fluent 版では公開 API に置き換える

### 3.3 Example プロジェクトの確認

標準の Example (`C:\tfs\codeer\Codeer.LowCode.Blazor\Source\App\`) と比較:

- `WebApp.Client.Shared/Services/UIService.cs` ← コンストラクタ変更に注意
- `WebApp.Client.Shared/Services/ServiceInitializer.cs` ← DI 登録の変更
- `WebApp.Client.Shared/ScriptObjects/Excel.cs` ← インターフェース変更

## Step 4: Design クラスの確認

標準の各 FieldDesign クラスに新プロパティが追加された場合:

```csharp
// 標準に新プロパティが追加された場合の対応例

// A) Fluent でも使う場合 → 何もしない (自動継承)
// B) Fluent で非表示にする場合:
[IgnoreBaseProperties(nameof(NewProperty))]
public class FluentXxxFieldDesign : XxxFieldDesign { ... }
```

## Step 5: 最終ビルド確認

```bash
# 全プロジェクトビルド
dotnet build Codeer.LowCode.Bindings.Fluent.Blazor.sln

# エラー0、警告は Obsolete のみであることを確認
```

## チェックリスト

- [ ] NuGet パッケージを最新化
- [ ] メインライブラリのビルド成功
- [ ] 全フィールドコンポーネントを標準と比較
- [ ] 全検索コンポーネントを標準と比較
- [ ] Design クラスの新プロパティ確認
- [ ] Example プロジェクトのビルド成功
- [ ] ソリューション全体のビルド成功 (0 エラー)

## 過去の更新履歴

### 2026-02: v1.1.36 → v1.2.49

主な変更点:
- 全コンポーネントに Localize 対応追加
- TextFieldComponent に _tempValue パターン追加
- NumberFieldComponent に Slider + Step 対応
- DateFieldComponent に IsYearMonthOnly 対応
- LabelFieldComponent に @onclick, IsRequired (関連フィールド) 追加
- LinkFieldComponent に OnSearchButtonClicked, nullable 対応
- RadioGroupFieldComponent に PopulateRadioButtons 対応
- 全検索コンポーネントに IsSimpleSearchParameter チェック追加
- SelectComponent 検索に OnFocus 追加
- BooleanComponent 検索に TrueText/FalseText + Localize 追加
- ButtonFieldDesign に ImageResourceSet, ShowTextInToolTip → IgnoreBaseProperties
- UIService コンストラクタから ModuleDialogService/MessageBoxService 削除
- Excel.DataGetter に CreateChildExcelSymbolConverter, Adjust 追加
- FluentUI v4.14.0 で Icons 名前空間変更に対応
