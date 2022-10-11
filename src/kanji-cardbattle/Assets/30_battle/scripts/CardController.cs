using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class CardController : MonoBehaviour
{
    public TsukuriCardView tsukuriView; // カードの見た目の処理
    public TsukuriCardModel tsukuriModel; // カードのデータを処理

    public BushuCardView bushuView; // カードの見た目の処理
    public BushuCardModel bushuModel; // カードのデータを処理

    public KanjiCardView kanjiView; // カードの見た目の処理
    public KanjiCardModel kanjiModel; // カードのデータを処理

    private void Awake()
    {
        tsukuriView = GetComponent<TsukuriCardView>();
        bushuView = GetComponent<BushuCardView>();
        kanjiView = GetComponent<KanjiCardView>();
    }
 
    public void TsukuriInit(int cardID) // カードを生成した時に呼ばれる関数
    {
        tsukuriModel = new TsukuriCardModel(cardID); // カードデータを生成
        tsukuriView.Show(tsukuriModel); // 表示
    }
    public void BushuInit(int cardID) // カードを生成した時に呼ばれる関数
    {
        bushuModel = new BushuCardModel(cardID); // カードデータを生成
        bushuView.Show(bushuModel); // 表示
    }

    public void KanjiInit(int KanjiID,int KanjiPower,string KanjiUnique,string KanjiKanji) // カードを生成した時に呼ばれる関数
    {
        kanjiModel = new KanjiCardModel(KanjiID,KanjiPower,KanjiUnique,KanjiKanji); // カードデータを生成
        kanjiView.Show(kanjiModel); // 表示
    }

}