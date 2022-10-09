using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
 
public class TsukuriCardModel
{
    public int CardID;
    public string TsukuriUnique;
    public int Power;
    public int Randam;
    public string TsukuriText;

    public TsukuriCardModel(int cardID)
    {
        Randam = UnityEngine.Random.Range(1, 300);
        TsukuriUnique = ReadKanjiCSV.instance.getKanjiCSV((Randam),4);

        //作りが被っていたら変更します。
        while( GameObject.Find(TsukuriUnique) != null ){
            Randam = UnityEngine.Random.Range(1, 300);
            TsukuriUnique = ReadKanjiCSV.instance.getKanjiCSV(Randam,4);
        }

        TsukuriText = ReadKanjiCSV.instance.getKanjiCSV(Randam,5);
        CardID = cardID;
        Power = UnityEngine.Random.Range(1, 5);
    }

}