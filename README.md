# 海賊すごろく / Pirate Sugoroku

脱初心者向けのオブジェクト指向とSOLID原則に基づいた設計を練習するためのプロジェクトです。

- [企画書](./Documents/proposal/index.md)
- [仕様書](./Documents/tech_spec/index.md)

## 動作環境
- Unity2021.3.0f1
- 対象環境：PCとWebGLビルド
- 画面解像度：960x540ピクセル
- Assets/PirateSugoroku/Scenes/Mapシーンを読み込む

## プロジェクトの準備
プロジェクトはいくつかのアセットを利用していて、クローンした後にいくらかの設定が必要です。以下、その手順です。

1. プロジェクトのリポジトリーをCloneするか、DownloadZipなどで入手して、任意のフォルダーに展開します
1. 対応バージョンのUnityで開きます
1. Assets/PirateSugoroku/Scenes/Mapシーンを開きます
1. TMP Importerダイアログが表示されたら、Import TMP Essensialsボタンをクリックして読み込んで、続けてImport TMP Examples & Extrasボタンをクリックして読み込みます
1. 以下のアセットを、AssetStoreからダウンロードして、インポートします
  - [Ebru Dogan. LowPoly Water](https://assetstore.unity.com/packages/tools/particles-effects/lowpoly-water-107563)

以上で設定完了です。開始して動作確認をしてください。最初はゲームは実装されていないので、サイコロが転がるだけです。

## 水面の不具合解消
水面のシェーダーの修正は以下を参照。

https://am1tanaka.hatenablog.com/entry/water-unlit-dof

修正後、マテリアルの色を 41F1ED にする。

## 組み込みアセット
以下のアセットを組み込んでいます。データの再利用については、それぞれのアセットのライセンスに従ってください。

- Assets/Kenney Assetsフォルダー以下
  - Kenney (www.kenney.nl)
- Assets/Quaternius
  - @Quaternius https://www.patreon.com/quaternius
