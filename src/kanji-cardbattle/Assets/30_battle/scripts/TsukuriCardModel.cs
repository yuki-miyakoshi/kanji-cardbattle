using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
 
public class TsukuriCardModel
{
    public int CardID;
    public int Tsukuri_unique;
    public int Power;
    public int randam;
    public string TsukuriText;

    public TsukuriCardModel(int cardID)
    {
        randam = UnityEngine.Random.Range(1, 300);
        Tsukuri_unique = int.Parse(ReadKanjiCSV.instance.getKanjiCSV((randam),4));
        while( GameObject.Find(Tsukuri_unique.ToString()) != null ){
            randam = UnityEngine.Random.Range(1, 300);
            Tsukuri_unique = int.Parse(ReadKanjiCSV.instance.getKanjiCSV(randam,4));
        }
        TsukuriText = ReadKanjiCSV.instance.getKanjiCSV(randam,5);
        CardID = cardID;
        Power = UnityEngine.Random.Range(1, 5);
    }

}