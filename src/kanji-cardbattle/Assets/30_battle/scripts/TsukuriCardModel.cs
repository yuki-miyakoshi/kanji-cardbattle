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

        Randam = UnityEngine.Random.Range(1, ReadKanjiCSV.instance.getListCount());
        if(UnityEngine.Random.Range(0,3) > 1){ // 1/3の確率で
Debug.Log("確定演出");
            int Length = GameObject.Find("Bushu").GetComponent<BushuCardView>().MyTsukuriUnique.Length-2;
            TsukuriUnique = GameObject.Find("Bushu").GetComponent<BushuCardView>().MyTsukuriUnique[UnityEngine.Random.Range(0,Length)];
        }else{
            TsukuriUnique = ReadKanjiCSV.instance.getKanjiCSV((Randam),4);
        }
        

        //作りが被っていたら変更します。
        while( GameObject.Find(TsukuriUnique) != null ){
            Randam = UnityEngine.Random.Range(1, ReadKanjiCSV.instance.getListCount());
            TsukuriUnique = ReadKanjiCSV.instance.getKanjiCSV(Randam,4);
        }

        TsukuriText = ReadKanjiCSV.instance.getKanjiCSV(Randam,5);
        CardID = cardID;
        Power = UnityEngine.Random.Range(1, 5);
    }

}