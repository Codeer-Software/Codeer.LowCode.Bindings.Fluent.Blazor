# Standard Differences - 標準ライブラリとの差異・制約事項

## アクセス制限による差異

標準ライブラリの internal メソッドは外部アセンブリから呼べないため、代替実装が必要。

### 1. Localize メソッド

```csharp
// 標準 (internal extension method)
Field.Localize(text)

// Fluent (公開 API 経由)
Field.Services.AppInfoService.Localize(text)
```

**影響**: 全コンポーネントで使用。機能的に同等。

### 2. GetRowCount メソッド

```csharp
// 標準 (internal) - IsAutoFitRows + 行数カウントを考慮
Field.GetRowCount()

// Fluent (代替実装)
Field.Design.Rows ?? 3
```

**影響**: FluentTextFieldComponent の TextArea 行数。IsAutoFitRows は未対応。

### 3. LabelField.IsRequired メソッド

```csharp
// 標準 (internal) - 関連フィールドの Required を確認
Field.IsRequired()

// Fluent (自前実装)
private bool IsRelativeFieldRequired() {
    if (Field.ModuleLayoutType == ModuleLayoutType.Search) return false;
    var relativeField = Field.Module.GetField(Field.Design.RelativeField);
    return relativeField switch {
        RadioButtonField rb => rb.GetRadioGroupField()?.Design.IsRequired() ?? false,
        null => false,
        _ => relativeField.Design.IsRequired(),
    };
}
```

**影響**: FluentLabelFieldComponent の必須マーク表示。

## 意図的な差異 (Fluent UI 固有)

### 1. バリデーションフィードバック

標準は `<ValidationFeedback>` コンポーネントを使用。Fluent 版では未実装。
FluentUI のバリデーション表示メカニズムが異なるため。

### 2. GetStyleString / GetValidationClassName

標準は Bootstrap の CSS クラスを適用。Fluent 版では FluentUI のスタイリングシステムを使用するため不要。

### 3. @ref="Element"

標準はフォーカス管理用に Element 参照を設定。Fluent 版では未設定。
FluentUI コンポーネントのフォーカス管理は異なる仕組み。

### 4. ボタンスタイリング

```
標準: ButtonVariant enum + Bootstrap CSS
Fluent: Appearance enum (Accent, Outline, etc.)
```

### 5. AnchorTag スタイリング

```
標準: AnchorStyle enum (Default, Button)
Fluent: Appearance enum → [IgnoreBaseProperties(nameof(Style))]
```

## 既知の制約・注意事項

### FluentSlider の型制約

`FluentSlider<TValue>` は `INumber<TValue>` を要求するため、`decimal?` は使用不可。
→ `decimal` (non-nullable) に変換してバインド。

```razor
<FluentSlider @bind-Value:get="@SliderValue" @bind-Value:set="@OnSliderChanged"
              Min="@(Min ?? 0)" Max="@(Max ?? 100)" Step="@(Step ?? 1)" />

@code {
    private decimal SliderValue => Field.Value ?? 0;
    private async Task OnSliderChanged(decimal value) => await Field.SetValueAsync(value);
}
```

### FluentUI Icons namespace (v4.11+)

FluentUI v4.11 以降で Icons の名前空間が変更。_Imports.razor に必要:
```razor
@using Icons = Microsoft.FluentUI.AspNetCore.Components.Icons
```

### IsYearMonthOnly (DateField)

FluentDatePicker は `type="month"` をサポートしないため、年月モードでは標準の
`<input type="month">` にフォールバック。

### SelectField の OnFocus

標準の検索 SelectComponent は `@onfocus` で `Field.OnFocusAsync()` を呼び出し、
遅延ロード候補を取得する。Fluent 版でも同様に実装済み。

### RadioButtonField の OnChange

標準は Timer ベースの debounce を使用。Fluent 版は直接 async void で実装。
挙動の違いが出る可能性あり。

## 各コンポーネントの差分詳細

### FluentTextFieldComponent
- [x] _tempValue パターン
- [x] Placeholder ローカライズ
- [ ] URL 自動検出 (ViewOnly モード) - 未実装
- [ ] IsAutoFitRows - 未実装 (internal メソッド)

### FluentNumberFieldComponent
- [x] Slider モード
- [x] Step プロパティ
- [x] Placeholder ローカライズ

### FluentBooleanFieldComponent
- [x] Label ローカライズ
- [x] TrueText/FalseText ローカライズ
- [x] List layout 時の Label 空文字化

### FluentDateFieldComponent
- [x] IsYearMonthOnly モード
- [x] FluentDatePicker 使用

### FluentSelectFieldComponent
- [x] 選択肢のローカライズ
- [ ] @key="Field.CandidateId" (候補変更時の強制再描画) - 未実装

### FluentRadioButtonFieldComponent
- [x] Label ローカライズ

### FluentLabelFieldComponent
- [x] @onclick ハンドラ
- [x] 関連フィールドの IsRequired チェック
- [x] Localize 対応
- [ ] for 属性 (アクセシビリティ) - 未実装

### FluentLinkFieldComponent
- [x] OnSearchButtonClicked 対応
- [x] Nullable 対応

### FluentAnchorTagFieldComponent
- [x] Localize 対応
- [ ] @onclick:preventDefault - 未実装 (クリック時に # へ遷移する可能性)

### FluentButtonFieldComponent / FluentSubmitButtonFieldComponent
- [x] Localize 対応
- [ ] Icon 表示 - 未実装 (Fluent のアイコンシステムが異なる)
- [ ] ImageResourceSet - IgnoreBaseProperties で非表示

## 検索コンポーネントの差分

### 全検索コンポーネント共通
- [x] IsSimpleSearchParameter チェック (FluentText, FluentDate, FluentNumber, FluentTime, FluentRadioGroup, FluentSelect)

### FluentBooleanComponent (Search)
- [x] TrueText/FalseText + Localize 対応

### FluentSelectComponent (Search)
- [x] OnFocus ハンドラ

### FluentTimeComponent (Search)
- [ ] SaveAsUtc 対応 - 未実装 (標準の TimeUtility は使えるが未適用)
