using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
 
public class ReadKanjiCSV : MonoBehaviour
{

    public static ReadKanjiCSV instance;
    public int ListCount;
   
    public void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    TextAsset csvFile; // CSVファイル
    List<string[]> csvDatas = new List<string[]>(); // CSVの中身を入れるリスト;

    public void Initialized() // cardModelのデータ取得と反映
    {
        csvFile = Resources.Load("kanjiCSV") as TextAsset; // Resouces下のCSV読み込み
        StringReader reader = new StringReader(csvFile.text);

        while (reader.Peek() != -1) // reader.Peaekが-1になるまで
        {
            string line = reader.ReadLine(); // 一行ずつ読み込み
            csvDatas.Add(line.Split(',')); // , 区切りでリストに追加
        }

        ListCount = csvDatas.Count();
    }

    public string getKanjiCSV(int row,int col){
        return csvDatas[row][col];
    }

    public List<string> getMyTsukuriUnique(string BushuUnique){

        List<string> TsukuriUniqueData = new List<string>();

        for(int i = 0 ; i < ListCount ; i++){
            if(csvDatas[i][2] == BushuUnique){
                TsukuriUniqueData.Add(csvDatas[i][4]);
            }
        }
        Debug.Log(ListCount);
        return TsukuriUniqueData;
       
    }

    public int getListCount(){
        return ListCount;
    }
}