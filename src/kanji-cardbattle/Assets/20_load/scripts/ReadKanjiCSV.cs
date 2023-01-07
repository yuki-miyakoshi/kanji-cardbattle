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
    public List<string[]> preCsvDatas = new List<string[]>(); // CSVの中身を入れるリスト
    public List<string[]> csvDatas = new List<string[]>(); // CSVの中身を入れるリスト
    private List<string[]> BushuToTsukuri_Unique = new List<string[]>();
    private List<string[]> BushuToKanji_Unique = new List<string[]>();
    private List<string[]> Bushu_Unique = new List<string[]>();
    private string temp ;
    private int tempint ;
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
        csvFile = Resources.Load("NewKanjiData2") as TextAsset; // Resouces下のCSV読み込み
        StringReader reader = new StringReader(csvFile.text);

        while (reader.Peek() != -1) // reader.Peekが-1になるまで
        {
            string line = reader.ReadLine(); // 一行ずつ読み込み
            preCsvDatas.Add(line.Split(',')); // , 区切りでリストに追加
            // Debug.Log(line);
        }
        //  Debug.Log(csvDatas.count());

        tempint = preCsvDatas.Count();
        for (int i = 0;i < tempint; i++ ){
            if((int.Parse(preCsvDatas[i][11])!=110) && (int.Parse(preCsvDatas[i][11]) > 19))
            csvDatas.Add(preCsvDatas[i]);
        }


        int maxBushuUnique = 0;
        for (int i = 0 ; i < getListCount() ; i++){
            if ( maxBushuUnique < int.Parse(getKanjiCSV(i,4)) ){
                   
                maxBushuUnique =  int.Parse(getKanjiCSV(i,4));
            } 
        }

        int maxTsukuriUnique = 0;
        for (int i = 0 ; i < getListCount() ; i++){
            if ( maxTsukuriUnique < int.Parse(getKanjiCSV(i,6)) ){
                   
                maxTsukuriUnique =  int.Parse(getKanjiCSV(i,6));
            } 
        }

        //getBushuToTsukuri_Unique---
        for(int i = 0 ; i < maxBushuUnique ; i++){
            temp = null;
            for(int j = 0 ; j < getListCount() ; j++){
                if( int.Parse(getKanjiCSV(j,4)) == i+1){
                    temp = temp + getKanjiCSV(j,6)+",";   
                }
            }

            if(temp != null){
                BushuToTsukuri_Unique.Add(temp.Split(','));
            
            }else{
                BushuToTsukuri_Unique.Add(null);
            
            }
            
        }//getBushuToTsukuri_Unique---

        //getBushuToKanji_Unique---
        for(int i = 0 ; i < maxBushuUnique ; i++){
            temp = null;
            for(int j = 0 ; j < getListCount() ; j++){
                if( int.Parse(getKanjiCSV(j,4)) == i+1){
                    temp = temp + getKanjiCSV(j,0)+",";
                }
            }
            if(temp != null){
            
                BushuToKanji_Unique.Add(temp.Split(','));
            
            }else{
                BushuToKanji_Unique.Add(null);
            
            }
        }//getBushuToKanji_Unique---
    }

    public string getKanjiCSV(int row,int col){
        return csvDatas[row][col];
    }

    public string[] getBushuToTsukuri_Unique(string BushuUnique){
        Debug.Log(BushuToTsukuri_Unique[int.Parse(BushuUnique)]);
        return BushuToTsukuri_Unique[int.Parse(BushuUnique)];
    }

    public string[] getBushuToKanji_Unique(string BushuUnique){
        // Debug.Log(BushuUnique);
        // Debug.Log(BushuToKanji_Unique);
        return BushuToKanji_Unique[int.Parse(BushuUnique)];
    }

    public int getListCount(){
        return csvDatas.Count();
    }

    public int getMAXBushuToTsukuri_Unique(){
        // Debug.Log(BushuToTsukuri_Unique.Count());
        return BushuToTsukuri_Unique.Count();
    }

    // public int getMAXBushuToTsukuri_Unique(){
    //     Debug.Log(BushuToTsukuri_Unique.Count());
    //     return BushuToTsukuri_Unique.Count();
    // }

    public string getBushuAndTsukuriToKanji_Unique(string Bushu,string Tsukuri){
        
        for(int i=0;i<getListCount();i++){
            if(csvDatas[i][4] == Bushu){
                if(csvDatas[i][6] == Tsukuri)
                temp3 = csvDatas[i][0];
            }
        }
        return temp3;
    }
}