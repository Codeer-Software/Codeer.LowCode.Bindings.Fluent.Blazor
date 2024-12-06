# Bindings.MudBlazor

[Codeer.LowCode.Blazor](https://github.com/Codeer-Software/Codeer.LowCode.Blazor.Manual/blob/main/JP/README.md)に[Fluent UI Blazor](https://www.fluentui-blazor.net/) UIコンポーネントを追加するためのライブラリです。

## インストール

### パッケージのインストール

LowCodeApp.Client.Shared プロジェクトにNuGetから次のパッケージをインストールしてください。

- Codeer.LowCode.Bindings.Fluent.Blazor

### コードの修正

ライブラリの使用に必要なコードを以下のプロジェクトにそれぞれ追加する必要があります。

- LowCodeApp.Client
- LowCodeApp.Shared
- LowCodeApp.Designer

#### LowCodeApp.Client

`Program.cs` に以下のコードを追加してください。

```csharp
builder.Services.AddFluentUIComponents();
```

#### LowCodeApp.Server

`Program.cs` に以下のコードを追加してください。

```csharp
typeof(FluentTextFieldDesign).ToString();
```

#### LowCodeApp.Designer

`App.xaml.cs` に以下のコードを追加してください。

```csharp
typeof(FluentTextFieldDesign).ToString();
Services.AddFluentUIComponents();
BlazorRuntime.InstallAssemblyInitializer(typeof(FluentTextFieldDesign).Assembly);
```

## 使用方法

DesignerからFluent UIを使用したコンポーネントが配置できるようになっています。
通常のButtonやBooleanの代わりにFluentButtonやFluentBooleanを使用してください。

// 画像

## サポートしているタイプ

Codeer.LowCode.Blazorの標準コントロールに対応するFluent UI Blazorコントロールは以下の通りです。

| Codeer.LowCode.Blazor | FluentBlazor |
| --- | --- |
| Boolean | FluentBoolean |
| Button | FluentButton |
| Date | FluentDate |
| Id | FluentId |
| Link | FluentLink |
| Number | FluentNumber |
| Password | FluentPassword |
| RadioButton | FluentRadioButton |
| RadioGroup | FluentRadioGroup |
| Select | FluentSelect |
| Text | FluentText |
| Time | FluentTime |
