# Project Structure - ファイル構成詳細

## ソリューション構成

```
Codeer.LowCode.Bindings.Fluent.Blazor.sln
├── Codeer.LowCode.Bindings.Fluent.Blazor/  (メインライブラリ - NuGet パッケージ)
├── Example/LowCodeApp.Client/              (Blazor WebAssembly クライアント)
├── Example/LowCodeApp.Client.Shared/       (クライアント共有ライブラリ)
├── Example/LowCodeApp.Server.Shared/       (サーバー共有ライブラリ)
├── Example/LowCodeApp.Server/              (ASP.NET Core サーバー)
└── Example/LowCodeApp.Designer/            (WPF デザイナーアプリ)
```

## メインライブラリ構成

```
Codeer.LowCode.Bindings.Fluent.Blazor/
│
├── Codeer.LowCode.Bindings.Fluent.Blazor.csproj
│   NuGet パッケージ設定:
│   - PackageId: Codeer.LowCode.Bindings.Fluent.Blazor
│   - Version: 0.7.0
│   - GeneratePackageOnBuild: True
│   - TargetFramework: net8.0
│   依存パッケージ:
│   - Codeer.LowCode.Blazor 1.2.49
│   - Microsoft.AspNetCore.Components.Web 8.0.24
│   - Microsoft.FluentUI.AspNetCore.Components 4.14.0
│   - Microsoft.FluentUI.AspNetCore.Components.Icons 4.14.0
│
├── _Imports.razor
│   グローバル using 定義:
│   - Microsoft.AspNetCore.Components.Web
│   - Microsoft.FluentUI.AspNetCore.Components
│   - Microsoft.FluentUI.AspNetCore.Components.Extensions
│   - Icons = Microsoft.FluentUI.AspNetCore.Components.Icons  ※v4.11+ 必須
│   - Codeer.LowCode.Bindings.Fluent.Blazor.Infrastructure
│   - Codeer.LowCode.Bindings.Fluent.Blazor.Designs
│   - Codeer.LowCode.Bindings.Fluent.Blazor.Internal
│
├── Infrastructure/
│   └── FluentFieldComponentBase.cs
│       ジェネリック基底クラス:
│       FluentFieldComponentBase<TField, TBase> : FieldComponentBase<TField>
│       - FluentDesign プロパティ: Field.Design を TBase にキャスト
│       - TField: FieldBase 派生 (e.g., TextField, NumberField)
│       - TBase: FieldDesignBase 派生 (e.g., FluentTextFieldDesign)
│
├── Components/  (15 フィールドコンポーネント)
│   各ファイルは .razor + .razor.css のペア
│   - FluentTextFieldComponent.razor      - テキスト入力 (単行/複数行)
│   - FluentNumberFieldComponent.razor    - 数値入力 + スライダー
│   - FluentBooleanFieldComponent.razor   - チェックボックス/スイッチ/トグル
│   - FluentDateFieldComponent.razor      - 日付ピッカー + 年月モード
│   - FluentTimeFieldComponent.razor      - 時刻ピッカー
│   - FluentPasswordFieldComponent.razor  - パスワード入力 (確認入力付き)
│   - FluentSelectFieldComponent.razor    - ドロップダウン選択
│   - FluentRadioGroupFieldComponent.razor - ラジオボタングループ
│   - FluentRadioButtonFieldComponent.razor - 個別ラジオボタン
│   - FluentButtonFieldComponent.razor    - アクションボタン
│   - FluentSubmitButtonFieldComponent.razor - 送信ボタン
│   - FluentLabelFieldComponent.razor     - ラベル表示
│   - FluentLinkFieldComponent.razor      - リンクフィールド (モーダル検索)
│   - FluentAnchorTagFieldComponent.razor - アンカーリンク
│   - FluentIdFieldComponent.razor        - ID 入力
│
├── Designs/  (15 デザインクラス)
│   各クラスは標準の XxxFieldDesign を継承
│   - FluentTextFieldDesign.cs
│   - FluentNumberFieldDesign.cs
│   - FluentBooleanFieldDesign.cs
│   - FluentDateFieldDesign.cs       ※StandardInput プロパティ追加
│   - FluentTimeFieldDesign.cs
│   - FluentPasswordFieldDesign.cs
│   - FluentSelectFieldDesign.cs
│   - FluentRadioGroupFieldDesign.cs
│   - FluentRadioButtonFieldDesign.cs
│   - FluentButtonFieldDesign.cs     ※Appearance, IgnoreBaseProperties
│   - FluentSubmitButtonFieldDesign.cs ※Appearance, IgnoreBaseProperties
│   - FluentLabelFieldDesign.cs
│   - FluentLinkFieldDesign.cs
│   - FluentAnchorTagFieldDesign.cs  ※Appearance, IgnoreBaseProperties(Style)
│   - FluentIdFieldDesign.cs
│
├── Search/  (8 検索コンポーネント)
│   - FluentTextComponent.razor       - テキスト検索 (Like/Equal)
│   - FluentNumberComponent.razor     - 数値範囲検索
│   - FluentBooleanComponent.razor    - Boolean 選択検索
│   - FluentDateComponent.razor       - 日付範囲検索
│   - FluentTimeComponent.razor       - 時刻範囲検索
│   - FluentSelectComponent.razor     - ドロップダウン検索 (単一/複数)
│   - FluentRadioGroupComponent.razor - ラジオグループ検索
│   - FluentLinkComponent.razor       - リンク検索 (モーダル)
│   各ファイルには .razor.css も存在
│
├── Internal/
│   ├── DateTimeHelper.cs
│   │   拡張メソッド群:
│   │   - ToDateTimeNullable() : DateOnly? → DateTime?
│   │   - ToDateOnlyNullable() : DateTime? → DateOnly?
│   │   - ToDateTime() : TimeOnly → DateTime
│   │   - ToTimeOnlyNullable() : DateTime? → TimeOnly?
│   └── Components/
│       ├── InternalFluentToggleButton.razor
│       │   Not ボタン (検索) や ToggleButton (Boolean) で使用
│       │   FluentButton の Appearance を切り替えて On/Off を表現
│       └── InternalFluentToggleButton.razor.css
│
├── Extensions/
│   ├── FieldDesignExtension.cs
│   │   internal static class FieldDesignExtensions:
│   │   - GetDisplayText(FieldDesignBase) : IDisplayName → DisplayName or Name
│   │   - IsRequired(FieldDesignBase) : IRequired → IsRequired property
│   └── StringExtension.cs
│       - DomSafeString() : FluentUI の ID 制約対応 (先頭に "a" 追加, "-" 除去)
│
├── Installer/
│   └── FluentInstaller.razor
│       FluentUI プロバイダーコンポーネントの一括登録:
│       - FluentToastProvider
│       - FluentDialogProvider
│       - FluentTooltipProvider
│       - FluentMessageBarProvider
│       - FluentMenuProvider
│
└── Properties/
    ├── Resource.resx              - 英語リソース
    ├── Resource.ja-JP.resx        - 日本語リソース
    └── Resource.Designer.cs       - 自動生成アクセサ
    主なリソースキー:
    - SearchField_MatchCondition_Like ("Contains" / "部分一致")
    - SearchField_MatchCondition_Equals ("Equals" / "完全一致")
    - SearchField_FileField_FileName
    - SearchField_FileField_FileSize
```

## Example プロジェクト構成

```
Example/
├── DesignData/App/               デザインデータ (JSON)
│   ├── designer.settings.json
│   ├── Modules/                  モジュール定義
│   └── PageFrames/               ページフレーム定義
│
├── LowCodeApp.Client/            Blazor WebAssembly
│   ├── Program.cs                エントリポイント (AddFluentUIComponents)
│   ├── Pages/LowCodePage.razor   メインページ
│   └── Shared/                   レイアウト
│
├── LowCodeApp.Client.Shared/     クライアント共有
│   ├── Services/                 DI サービス実装
│   │   ├── AppInfoService.cs     デザインデータ管理
│   │   ├── ModuleDataService.cs  HTTP 経由データアクセス
│   │   ├── UIService.cs          ダウンロード・通知
│   │   ├── ServiceInitializer.cs DI 登録
│   │   └── HttpService.cs        HTTP 通信ラッパー
│   ├── ScriptObjects/            スクリプトオブジェクト
│   │   └── Excel.cs              Excel 操作 (IExcelSymbolConverter)
│   └── Samples/                  カスタムコンポーネント例
│
├── LowCodeApp.Server.Shared/     サーバー共有
│   └── DbAccessor.cs             マルチ DB アクセス
│
├── LowCodeApp.Server/            ASP.NET Core サーバー
│   ├── Program.cs                サーバー起動 (typeof(FluentTextFieldDesign).ToString())
│   ├── Controllers/              API コントローラー群
│   └── Services/                 サーバーサービス
│
└── LowCodeApp.Designer/          WPF デザイナー
    ├── App.xaml.cs               デザイナー起動 (BlazorRuntime.InstallAssemblyInitializer)
    └── Lib/                      デザイナー拡張機能
```

## NuGet パッケージバージョン一覧 (2025-02 時点)

### メインライブラリ
| パッケージ | バージョン |
|---|---|
| Codeer.LowCode.Blazor | 1.2.49 |
| Microsoft.AspNetCore.Components.Web | 8.0.24 |
| Microsoft.FluentUI.AspNetCore.Components | 4.14.0 |
| Microsoft.FluentUI.AspNetCore.Components.Icons | 4.14.0 |

### Example - Client
| パッケージ | バージョン |
|---|---|
| Codeer.LowCode.Blazor | 1.2.49 |
| Microsoft.AspNetCore.Components.WebAssembly | 8.0.24 |

### Example - Client.Shared
| パッケージ | バージョン |
|---|---|
| Codeer.LowCode.Blazor | 1.2.49 |
| Excel.Report.PDF | 0.32.0 |
| Microsoft.Extensions.Http | 8.0.1 |

### Example - Server.Shared
| パッケージ | バージョン |
|---|---|
| Codeer.LowCode.Blazor | 1.2.49 |
| Microsoft.EntityFrameworkCore* | 8.0.24 |
| Npgsql.EntityFrameworkCore.PostgreSQL | 8.0.5 |
| Dapper | 2.1.66 |

### Example - Designer
| パッケージ | バージョン |
|---|---|
| Codeer.LowCode.Blazor.Designer | 1.2.49 |
| Azure.AI.OpenAI | 2.1.0 |

### Example - Server
| パッケージ | バージョン |
|---|---|
| Azure.AI.OpenAI | 2.1.0 |
| PdfPig | 0.1.13 |

## アセンブリ登録方法

Fluent コンポーネントの自動検出には、アセンブリがロードされている必要がある。

```csharp
// Client / Server の Program.cs
typeof(FluentTextFieldDesign).ToString();  // アセンブリ強制ロード
builder.Services.AddFluentUIComponents();  // FluentUI サービス登録

// Designer の App.xaml.cs
typeof(FluentTextFieldDesign).ToString();
BlazorRuntime.InstallAssemblyInitializer(typeof(FluentTextFieldDesign).Assembly);
```
