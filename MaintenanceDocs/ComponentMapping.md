# Component Mapping - 全コンポーネント対応表

## フィールドコンポーネント一覧

| # | 標準 Field | Fluent Design | Fluent Component | Fluent Search | 備考 |
|---|---|---|---|---|---|
| 1 | TextField | FluentTextFieldDesign | FluentTextFieldComponent | FluentTextComponent | _tempValue パターン使用 |
| 2 | NumberField | FluentNumberFieldDesign | FluentNumberFieldComponent | FluentNumberComponent | Slider + Step 対応 |
| 3 | BooleanField | FluentBooleanFieldDesign | FluentBooleanFieldComponent | FluentBooleanComponent | CheckBox/Switch/Toggle |
| 4 | DateField | FluentDateFieldDesign | FluentDateFieldComponent | FluentDateComponent | IsYearMonthOnly 対応 |
| 5 | TimeField | FluentTimeFieldDesign | FluentTimeFieldComponent | FluentTimeComponent | |
| 6 | PasswordField | FluentPasswordFieldDesign | FluentPasswordFieldComponent | - | 確認入力付き |
| 7 | SelectField | FluentSelectFieldDesign | FluentSelectFieldComponent | FluentSelectComponent | OnFocus 対応 |
| 8 | RadioGroupField | FluentRadioGroupFieldDesign | FluentRadioGroupFieldComponent | FluentRadioGroupComponent | PopulateRadioButtons 対応 |
| 9 | RadioButtonField | FluentRadioButtonFieldDesign | FluentRadioButtonFieldComponent | - | |
| 10 | ButtonField | FluentButtonFieldDesign | FluentButtonFieldComponent | - | Appearance 指定可 |
| 11 | SubmitButtonField | FluentSubmitButtonFieldDesign | FluentSubmitButtonFieldComponent | - | |
| 12 | LabelField | FluentLabelFieldDesign | FluentLabelFieldComponent | - | Typography 対応 |
| 13 | LinkField | FluentLinkFieldDesign | FluentLinkFieldComponent | FluentLinkComponent | OnSearchButtonClicked 対応 |
| 14 | AnchorTagField | FluentAnchorTagFieldDesign | FluentAnchorTagFieldComponent | - | Appearance 指定可 |
| 15 | IdField | FluentIdFieldDesign | FluentIdFieldComponent | - | 検索は標準 IdComponent |

## 標準にあるが Fluent に未実装の検索コンポーネント

| 標準 Search Component | 状態 | 対応方針 |
|---|---|---|
| DateTimeComponent | 未実装 | DateTimeField 自体が FluentDateTimeFieldDesign なしのため未対応 |
| FileComponent | 未実装 | FileField は FluentFileFieldDesign なしのため未対応 |
| IdComponent | 未実装 | FluentIdFieldDesign は GetSearchWebComponentTypeFullName 未オーバーライド→標準を使用 |
| ListComponent | 未実装 | ListField は FluentListFieldDesign なしのため未対応 |

## Design クラスの [IgnoreBaseProperties] 設定

| Design クラス | 非表示にしているプロパティ |
|---|---|
| FluentButtonFieldDesign | Variant, Icon, ImageResourceSet, ShowTextInToolTip |
| FluentSubmitButtonFieldDesign | Variant, Icon, ImageResourceSet |
| FluentAnchorTagFieldDesign | Style |

## Design クラスの Fluent 固有プロパティ

| Design クラス | プロパティ | 型 | 説明 |
|---|---|---|---|
| FluentButtonFieldDesign | Appearance | Appearance | ボタンの外観 (Hypertext, Filled は除外) |
| FluentSubmitButtonFieldDesign | Appearance | Appearance | ボタンの外観 |
| FluentAnchorTagFieldDesign | Appearance | Appearance | リンクの外観 (デフォルト: Hypertext) |
| FluentDateFieldDesign | StandardInput | bool | 標準 HTML input を使うか |

## GetSearchWebComponentTypeFullName のオーバーライド状況

| Design | オーバーライド | 返す型 |
|---|---|---|
| FluentTextFieldDesign | あり | FluentTextComponent |
| FluentNumberFieldDesign | あり | FluentNumberComponent |
| FluentBooleanFieldDesign | あり | FluentBooleanComponent |
| FluentDateFieldDesign | あり | FluentDateComponent |
| FluentTimeFieldDesign | あり | FluentTimeComponent |
| FluentSelectFieldDesign | あり | FluentSelectComponent |
| FluentRadioGroupFieldDesign | あり | FluentRadioGroupComponent |
| FluentLinkFieldDesign | あり | FluentLinkComponent |
| FluentIdFieldDesign | **なし** | 標準の IdComponent を使用 |
| FluentPasswordFieldDesign | なし (base = empty) | 検索なし (正常) |
| FluentRadioButtonFieldDesign | なし (base = empty) | 検索なし (正常) |
| FluentButtonFieldDesign | **なし** | 標準の ButtonFieldComponent を使用 |
| FluentSubmitButtonFieldDesign | なし (base = empty) | 検索なし (正常) |
| FluentLabelFieldDesign | **なし** | 標準の LabelFieldComponent を使用 |
| FluentAnchorTagFieldDesign | なし (base = empty) | 検索なし (正常) |
