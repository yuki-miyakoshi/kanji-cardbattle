using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
 
public class TsukuriCardView : MonoBehaviour
{
    [SerializeField] Text tsukuriText, powerText;

    TextAsset csvFile; // CSVファイル
    List<string[]> csvDatas = new List<string[]>(); // CSVの中身を入れるリスト;

    public void Show(TsukuriCardModel cardModel) // cardModelのデータ取得と反映
    {
        csvFile = Resources.Load("kanjiCSV") as TextAsset; // Resouces下のCSV読み込み
        StringReader reader = new StringReader(csvFile.text);

        while (reader.Peek() != -1) // reader.Peaekが-1になるまで
        {
            string line = reader.ReadLine(); // 一行ずつ読み込み
            csvDatas.Add(line.Split(',')); // , 区切りでリストに追加
        }

        tsukuriText.text = csvDatas[cardModel.tsukuri_unique][5];
        powerText.text = cardModel.power.ToString();

    }
}