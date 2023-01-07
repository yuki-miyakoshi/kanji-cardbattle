using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
 
public class BushuCardModel
{
    public int CardID;
    public int Randam;
    public string[] MyTsukuriUnique;
    public string[] MyKanjiUnique;
    public string BushuText;
    public string BushuUnique;

    public BushuCardModel(int cardID)
    {
        Randam = UnityEngine.Random.Range(1, ReadKanjiCSV.instance.getMAXBushuToTsukuri_Unique());
        while(ReadKanjiCSV.instance.getKanjiCSV((Randam),4) == null){
            Randam = UnityEngine.Random.Range(1, ReadKanjiCSV.instance.getMAXBushuToTsukuri_Unique());
        }
        BushuUnique = ReadKanjiCSV.instance.getKanjiCSV((Randam),4);

        MyTsukuriUnique = ReadKanjiCSV.instance.getBushuToTsukuri_Unique(BushuUnique);
        MyKanjiUnique = ReadKanjiCSV.instance.getBushuToKanji_Unique(BushuUnique);

        BushuText = ReadKanjiCSV.instance.getKanjiCSV(Randam,3);

        CardID = cardID;
    }

}