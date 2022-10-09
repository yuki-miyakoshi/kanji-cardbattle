using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
 
public class TsukuriCardModel
{
    public int CardID;
    public string Tsukuri_unique;
    public int Power;
    public int randam;
    public string TsukuriText;

    public TsukuriCardModel(int cardID)
    {
        randam = UnityEngine.Random.Range(1, 300);
        Tsukuri_unique = ReadKanjiCSV.instance.getKanjiCSV((randam),4);

        //作りが被っていたら変更します。
        while( GameObject.Find(Tsukuri_unique) != null ){
            randam = UnityEngine.Random.Range(1, 300);
            Tsukuri_unique = ReadKanjiCSV.instance.getKanjiCSV(randam,4);
        }

        TsukuriText = ReadKanjiCSV.instance.getKanjiCSV(randam,5);
        CardID = cardID;
        Power = UnityEngine.Random.Range(1, 5);
    }

}