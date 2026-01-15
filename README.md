# MornLocalize

## 概要

Googleスプレッドシートを使った多言語テキスト・画像管理ライブラリ。

## 依存関係

| 種別 | 名前 |
|------|------|
| 外部パッケージ | UniTask, UniRx, TextMesh Pro |
| Mornライブラリ | MornSpreadSheet, MornGlobal |

## 使い方

### スプレッドシートの準備

以下の形式でスプレッドシートを作成します。

|            | jp   | en  | ... |
|------------|------|-----|-----|
| system.yes | はい | Yes | ... |
| system.no  | いいえ | No  | ... |

### セットアップ

1. Projectウィンドウで右クリック → `MornLocalize/MornLocalizeMasterData` を作成
2. `SheetId` と `SheetName` を設定
3. `DefaultLanguage` にデフォルトの言語を設定
4. `Load` ボタンを押す

### コードでの使用

```csharp
// 直接取得
var text = settings.Get("jp", "system.yes");

// MornLocalizeStringを使用（推奨）
[SerializeField] private MornLocalizeString _text;
string value = _text.Get();       // 現在の言語で取得
string value = _text.Get("en");   // 指定言語で取得
```

### 言語切り替え

```csharp
MornLocalizeCore.ChangeLanguage("en");
```

### UIコンポーネント

- **MornLocalizeText**: TextMesh Pro テキストと連携
- **MornLocalizeImage/Sprite**: 画像の言語切り替え
