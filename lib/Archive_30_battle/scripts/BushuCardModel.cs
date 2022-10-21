using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
 
public class BushuCardModel
{
    public int CardID;
    public int Randam;
    public List<string> MyTsukuriUnique;
    public string BushuText;
    public string BushuUnique;

    public BushuCardModel(int cardID)
    {
        Randam = UnityEngine.Random.Range(1, 3000);
        BushuUnique = ReadKanjiCSV.instance.getKanjiCSV((Randam),2);

        MyTsukuriUnique = ReadKanjiCSV.instance.getMyTsukuriUnique(BushuUnique);

        BushuText = ReadKanjiCSV.instance.getKanjiCSV(Randam,3);

        CardID = cardID;
    }

}