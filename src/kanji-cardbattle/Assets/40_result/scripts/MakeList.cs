using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MakeList : MonoBehaviour
{
    public int kanjiID;
    public GameObject title;
    public GameObject column1;
    public GameObject column2;

    void Awake()
    {
        ShowTable(kanjiID);
    }
    void ShowTable(int kanjiID)
    {
        // 読み込み
        string path = "ScriptableObject/"+ kanjiID.ToString();
        KanjiScriptableObject obj = Resources.Load<KanjiScriptableObject>(path);
        Component[] textComp = column2.GetComponentsInChildren<Text>();
        ShowTitle(obj.kanji);
        string[] data = 
        {
            obj.part,
            Unify(obj.readO),
            Unify(obj.readK),
            Unify(obj.mean),
            obj.stroke.ToString(),
            obj.strokePart.ToString(),
            obj.strokeOther.ToString(),
            obj.schoolGrade,
            obj.kankenGrade.ToString(),
            obj.category
        };
        for(int i = 0; i < textComp.Length; i++)
        {
            // テキスト変更
            Text content = textComp[i].GetComponent<Text>();
            content.text = data[i];
            // "-"の場合中央ぞろえ
            if(data[i] == "-")
            {
                content.alignment = TextAnchor.MiddleCenter;
            }
        }
    }
    void ShowTitle(string kanji)
    {
        Text display =title.GetComponent<Text>();
        display.text = kanji;
    }
    string Unify(string[] words)
    {
        string phrase = "";
        int count = 1;
        foreach(string word in words)
        {
            if(words.Length <= 1)
            {
                phrase = word;
            }
            else if(count == words.Length)
            {
                phrase += count + "." + word;
                count += 1;
            }
            else
            {
                phrase += count + "." + word + "\n";
                count += 1;
            }
        }
        return phrase;
    }
}
