using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

public class Csv2ScriptableObject : MonoBehaviour
{
    TextAsset csvFile;
    void Start()
    {
        ReadCsv();
    }
    void ReadCsv()
    {
        // Assets\Resources\csv\NewKanjiData3.csv
        string path = "csv/NewKanjiData3";
        csvFile = Resources.Load(path) as TextAsset;
        StringReader reader = new StringReader(csvFile.text);
        for(int i = 0; i < 3190; i++)
        {
            var SObj = ScriptableObject.CreateInstance<KanjiScriptableObject>();
            string[] row = reader.ReadLine().Split(",");
            string sobj_path = "Assets/Resources/ScriptableObject/" + row[0] + ".asset";
            KanjiScriptableObject obj = new KanjiScriptableObject();
            obj.kanjiID = int.Parse(row[0]);
            obj.kanji = row[1];
            obj.part = row[2];
            obj.partLeft = row[3];
            obj.partLeftId = int.Parse(row[4]);
            obj.partRight = row[5];
            obj.partRightId = int.Parse(row[6]);
            obj.readO = row[7].Split(".");
            obj.readK = row[8].Split(".");
            obj.mean = row[9].Split(".");
            obj.stroke = int.Parse(row[10]);
            obj.strokePart = int.Parse(row[11]);
            obj.strokeOther = int.Parse(row[12]);
            obj.schoolGrade = row[13];
            obj.kankenGrade = int.Parse(row[14]);
            obj.category = row[15];
            AssetDatabase.CreateAsset(obj, sobj_path);
        }
    }
}
