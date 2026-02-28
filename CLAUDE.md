# Codeer.LowCode.Bindings.Fluent.Blazor - Claude Code Guide

## Overview

Codeer.LowCode.Blazor の拡張 Field ライブラリ。標準の Bootstrap ベースコンポーネントを
Microsoft Fluent UI Blazor コンポーネントに置き換える。

- **Version**: 0.7.0
- **Target**: .NET 8.0
- **Base Library**: Codeer.LowCode.Blazor (現在 v1.2.49)
- **UI Library**: Microsoft.FluentUI.AspNetCore.Components (現在 v4.14.0)
- **Standard Library Source** (参照用): `C:\tfs\codeer\Codeer.LowCode.Blazor`

## Architecture

### 3ファイル構成パターン (各フィールド型)

```
Designs/FluentXxxFieldDesign.cs     → 標準の XxxFieldDesign を継承
Components/FluentXxxFieldComponent.razor → FluentFieldComponentBase<TField, TDesign> を継承
Search/FluentXxxComponent.razor     → 検索用コンポーネント (該当する型のみ)
```

### Design クラスの実装パターン

```csharp
[IgnoreBaseProperties(nameof(Variant), nameof(Icon))]  // Fluent で不要なプロパティを隠す
public class FluentXxxFieldDesign : XxxFieldDesign
{
    public FluentXxxFieldDesign() => TypeFullName = typeof(FluentXxxFieldDesign).FullName!;
    public override string GetWebComponentTypeFullName() => typeof(FluentXxxFieldComponent).FullName!;
    public override string GetSearchWebComponentTypeFullName() => typeof(FluentXxxComponent).FullName!;

    [Designer] // Fluent 固有プロパティ
    public Appearance Appearance { get; set; }
}
```

### Component の実装パターン

```razor
@inherits FluentFieldComponentBase<XxxField, FluentXxxFieldDesign>

@if (IsViewMode) {
  <FluentLabel>@ViewOnlyValue</FluentLabel>
} else {
  <FluentTextField @bind-Value:get="@Value" @bind-Value:set="@OnValueChanged" ... />
}

@code {
  private bool IsDisabled => Field.IsEnabled == false;
  private bool IsViewMode => Field.IsViewOnly;
  // Field.Services.AppInfoService.Localize() でローカライズ
  // Field.Services.AppInfoService.IsDesignMode でデザインモード判定
}
```

## Key Rules

### Localize は public API を使う
```csharp
// NG: Field.Localize() は internal - 外部アセンブリからアクセス不可
// OK:
Field.Services.AppInfoService.Localize(text)
```

### internal メソッドへのアクセス不可
以下は Codeer.LowCode.Blazor の internal メソッドなので直接呼べない:
- `Field.Localize()` → `Field.Services.AppInfoService.Localize()` を使う
- `Field.GetRowCount()` → `Field.Design.Rows ?? 3` を使う
- `LabelField.IsRequired()` → 関連フィールドを自前で確認するロジックを実装

### FluentUI Icons namespace
FluentUI v4.11 以降、Icons は別名前空間。_Imports.razor に以下が必要:
```razor
@using Icons = Microsoft.FluentUI.AspNetCore.Components.Icons
```

### FluentSlider の制約
`FluentSlider<TValue>` は nullable 型を受け付けない (`INumber<T>` 制約)。
`decimal?` → `decimal` に変換してバインドする必要がある。

## Build

```bash
# ソリューション全体ビルド
dotnet build Codeer.LowCode.Bindings.Fluent.Blazor.sln

# メインライブラリのみ
dotnet build Codeer.LowCode.Bindings.Fluent.Blazor/Codeer.LowCode.Bindings.Fluent.Blazor.csproj
```

NuGet パッケージはビルド時に自動生成 (`GeneratePackageOnBuild: True`)。

## Maintenance Workflow

### 標準ライブラリ更新時の作業手順

1. **NuGet 更新**: `Codeer.LowCode.Blazor` のバージョンを上げる
2. **標準コンポーネントとの差分確認**: 各フィールドの標準実装を読み、変更点を特定
   - 標準コンポーネント: `C:\tfs\codeer\Codeer.LowCode.Blazor\Source\Codeer.LowCode.Blazor\Components\Fields\`
   - 標準検索コンポーネント: `C:\tfs\codeer\Codeer.LowCode.Blazor\Source\Codeer.LowCode.Blazor\Components\Search\`
3. **Design クラスの確認**: 新しいプロパティが追加された場合、`[IgnoreBaseProperties]` の更新要否を確認
4. **ビルド検証**: 全プロジェクトでビルドエラーがないことを確認
5. **Example プロジェクト**: 標準の Example (`C:\tfs\codeer\...\Source\App\`) と差分確認

### 詳細ドキュメント

`MaintenanceDocs/` フォルダに詳細情報あり:
- `ComponentMapping.md` - 全コンポーネントの対応表と実装状況
- `StandardDifferences.md` - 標準との既知の差異・制約事項
- `ProjectStructure.md` - ファイル構成の詳細

## File Layout

```
Codeer.LowCode.Bindings.Fluent.Blazor/
├── _Imports.razor              # グローバル using
├── Components/                 # 15 フィールドコンポーネント
├── Designs/                    # 15 デザインクラス
├── Search/                     # 8 検索コンポーネント
├── Infrastructure/             # FluentFieldComponentBase.cs (基底クラス)
├── Internal/                   # DateTimeHelper.cs, InternalFluentToggleButton
├── Extensions/                 # FieldDesignExtension.cs, StringExtension.cs
├── Installer/                  # FluentInstaller.razor
└── Properties/                 # Resource.resx, Resource.ja-JP.resx
```

## Code Style

- C# インデント: 4スペース
- Razor/JSON: 2スペース
- 改行: CRLF
- Nullable: enable
- ImplicitUsings: enable
- コンポーネント内のコードは `@code {}` に記述 (コードビハインド不使用)
