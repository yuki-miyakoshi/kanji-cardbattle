using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
 
public class BushuCardModel
{
    public int CardID;
    public int Randam;
    public int KanjiRank;
    public string[] MyTsukuriUnique;
    public string[] MyKanjiUnique;
    public string BushuText;
    public string BushuUnique;

    public BushuCardModel(int cardID)
    {
        Randam = UnityEngine.Random.Range(0,ReadKanjiCSV.instance.getListCount());
        KanjiRank = int.Parse(ReadKanjiCSV.instance.getKanjiCSV((Randam),11));

        while(KanjiRank == 110 || KanjiRank < 19){
            Randam = UnityEngine.Random.Range(0,ReadKanjiCSV.instance.getListCount());
            KanjiRank = int.Parse(ReadKanjiCSV.instance.getKanjiCSV((Randam),11));
            
        }
// Debug.Log(KanjiRank);
        BushuUnique = ReadKanjiCSV.instance.getKanjiCSV((Randam),4);

        MyTsukuriUnique = ReadKanjiCSV.instance.getBushuToTsukuri_Unique(BushuUnique);
        MyKanjiUnique = ReadKanjiCSV.instance.getBushuToKanji_Unique(BushuUnique);

        BushuText = ReadKanjiCSV.instance.getKanjiCSV(Randam,3);

        CardID = cardID;
    }

}