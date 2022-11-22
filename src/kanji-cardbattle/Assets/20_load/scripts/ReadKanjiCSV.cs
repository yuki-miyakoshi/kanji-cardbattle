using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
 
public class ReadKanjiCSV : MonoBehaviour
{

    public static ReadKanjiCSV instance;
    private TextAsset csvFile; // CSVファイル
    private List<string[]> csvDatas = new List<string[]>(); // CSVの中身を入れるリスト
    private List<string[]> BushuToTsukuri_Unique = new List<string[]>();
    private List<string[]> BushuToKanji_Unique = new List<string[]>();
    private string temp ;
    string temp3;
    // private string temp2;
   
    public void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    public void Initialized() // cardModelのデータ取得と反映
    {
        csvFile = Resources.Load("kanjiCSV") as TextAsset; // Resouces下のCSV読み込み
        StringReader reader = new StringReader(csvFile.text);

        while (reader.Peek() != -1) // reader.Peekが-1になるまで
        {
            string line = reader.ReadLine(); // 一行ずつ読み込み
            csvDatas.Add(line.Split(',')); // , 区切りでリストに追加
        }


        int maxBushuUnique = 0;
        for (int i = 0 ; i < getListCount() ; i++){
            if ( maxBushuUnique < int.Parse(getKanjiCSV(i,2)) ){
                maxBushuUnique =  int.Parse(getKanjiCSV(i,2));
            } 
        }

        //getBushuToTsukuri_Unique---
        for(int i = 0 ; i < maxBushuUnique ; i++){
            temp = null;
            for(int j = 0 ; j < getListCount() ; j++){
                if( int.Parse(getKanjiCSV(j,2)) == i+1){
                    temp = temp + getKanjiCSV(j,4)+",";
                }
            }
            BushuToTsukuri_Unique.Add(temp.Split(','));
        }//getBushuToTsukuri_Unique---

        //getBushuToKanji_Unique---
        for(int i = 0 ; i < maxBushuUnique ; i++){
            temp = null;
            for(int j = 0 ; j < getListCount() ; j++){
                if( int.Parse(getKanjiCSV(j,2)) == i+1){
                    temp = temp + getKanjiCSV(j,0)+",";
                }
            }
            BushuToKanji_Unique.Add(temp.Split(','));
        }//getBushuToKanji_Unique---
    }

    public string getKanjiCSV(int row,int col){
        return csvDatas[row][col];
    }

    public string[] getBushuToTsukuri_Unique(string BushuUnique){
        return BushuToTsukuri_Unique[int.Parse(BushuUnique)-1];
    }

    public string[] getBushuToKanji_Unique(string BushuUnique){
        return BushuToKanji_Unique[int.Parse(BushuUnique)-1];
    }

    public int getListCount(){
        return csvDatas.Count();
    }

    public string getBushuAndTsukuriToKanji_Unique(string Bushu,string Tsukuri){
        
        for(int i=0;i<getListCount();i++){
            if(csvDatas[i][2] == Bushu){
                if(csvDatas[i][4] == Tsukuri)
                temp3 = csvDatas[i][0];
            }
        }
        return temp3;
    }
}