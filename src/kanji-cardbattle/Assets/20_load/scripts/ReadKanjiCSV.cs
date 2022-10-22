using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
 
public class ReadKanjiCSV : MonoBehaviour
{

    public static ReadKanjiCSV instance;
   
    public void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    private TextAsset csvFile; // CSVファイル
    private List<string[]> csvDatas = new List<string[]>(); // CSVの中身を入れるリスト
    private List<string[]> BushuToTsukuri_Unique = new List<string[]>();
    private string temp ;
    // private List<string> TsukuriUnique = new List<string>();

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

        for(int i = 0 ; i < maxBushuUnique ; i++){

            temp = null;
            for(int j = 0 ; j < getListCount() ; j++){
                if( int.Parse(getKanjiCSV(j,2)) == i+1){
                    temp = temp + getKanjiCSV(j,4)+",";
                }
            }
            BushuToTsukuri_Unique.Add(temp.Split(','));

        }


    }

    public string getKanjiCSV(int row,int col){
        return csvDatas[row][col];
    }

    public string[] getBushuToTsukuri_Unique(string BushuUnique){

        return BushuToTsukuri_Unique[int.Parse(BushuUnique)-1];
       
    }

    public int getListCount(){
        return csvDatas.Count();
    }
}