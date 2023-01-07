using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
 
public class TsukuriCardModel
{
    public int CardID;
    public string TsukuriUnique;
    // public string oldUnique;
    public int Power;
    public int Randam;
    public int KanjiRank;
    public string TsukuriText;

    public TsukuriCardModel(int cardID)
    {
                
        Randam = UnityEngine.Random.Range(0, ReadKanjiCSV.instance.getListCount());

        KanjiRank = int.Parse(ReadKanjiCSV.instance.getKanjiCSV((Randam),11));

        while(KanjiRank == 110 || KanjiRank < 19){


            if(UnityEngine.Random.Range(0,3) > 1){ // 1/3の確率で
                int Length = GameObject.Find("Bushu").GetComponent<BushuCardView>().MyTsukuriUnique.Length-1;
// Debug.Log(Length);
                TsukuriUnique = GameObject.Find("Bushu").GetComponent<BushuCardView>().MyTsukuriUnique[UnityEngine.Random.Range(0,Length)];
            }else{
                TsukuriUnique = ReadKanjiCSV.instance.getKanjiCSV((Randam),6);
            }
            

            // //作りが被っていたら変更します。
            // while( GameObject.Find(TsukuriUnique) != null ){
            //     Randam = UnityEngine.Random.Range(1, ReadKanjiCSV.instance.getListCount());
            //     TsukuriUnique = ReadKanjiCSV.instance.getKanjiCSV(Randam,6);
            // }
        Randam = UnityEngine.Random.Range(0, ReadKanjiCSV.instance.getListCount());
        KanjiRank = int.Parse(ReadKanjiCSV.instance.getKanjiCSV((Randam),11));
        

        }
        // GameObject.name = TsukuriUnique;
        TsukuriUnique = ReadKanjiCSV.instance.getKanjiCSV(Randam,6);
        TsukuriText = ReadKanjiCSV.instance.getKanjiCSV(Randam,5);
        CardID = cardID;
        Power = UnityEngine.Random.Range(1, 5);
    }

}