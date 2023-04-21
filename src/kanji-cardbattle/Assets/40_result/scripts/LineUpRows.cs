using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LineUpRows : MonoBehaviour
{
    public GameObject content;
    public GameObject title;
    public int kanjiID;

    void Start()
    {
        ChangeColor();
    }

    void Update()
    {
        ChangeSize();
    }


    void ChangeColor()
    {
        for(int i = 0; i < content.transform.childCount; i++)
        {
            var rows = content.transform.GetChild(i);

            // 色
            // 1:黄色, 2:ピンク
            Image image = rows.GetComponent<Image>();
            string[] colorcode = {"#F6FF79","#FF79f6"};

            // 偶数だった場合に色を変える
            Color bgcolor;
            if (ColorUtility.TryParseHtmlString(colorcode[i%2], out bgcolor))
            {
                image.color = bgcolor;
            }
        }
    }
    void ChangeText()
    {
        // 読み込み
        string path = "ScriptableObject/"+ kanjiID.ToString();
        KanjiScriptableObject obj = Resources.Load<KanjiScriptableObject>(path);

        // タイトル
        Text display = title.GetComponent<Text>();
        display.text = obj.kanji;

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
        Component[] table = content.GetComponentsInChildren<Transform>();
        for(int i = 0; i < content.transform.childCount; i++)
        {
            // テキスト変更
            Text tabledata = table[i].gameObject.GetComponentInChildren<Transform>().GetChild(1).GetComponent<Text>();
            tabledata.text = data[i];
            // "-"の場合中央ぞろえ
            if(data[i] == "-")
            {
                tabledata.alignment = TextAnchor.MiddleCenter;
            }
        }

    }
    
    // 後で見る
    void ChangeSize()
    {
        Component[] table = content.GetComponentsInChildren<Transform>();
        for(int i = 0; i < content.transform.childCount; i++)
        {
            // テキスト変更
            Text tabledata = table[i].gameObject.GetComponentInChildren<Transform>().GetChild(1).GetComponent<Text>();
            if (tabledata.text != tabledata.cachedTextGeneratorForLayout.GetParsedText())
            {
                // テキストオブジェクトの高さをテキストの行数に応じて自動で変更する
                tabledata.cachedTextGeneratorForLayout.Invalidate();
                tabledata.rectTransform.sizeDelta = new Vector2(tabledata.rectTransform.sizeDelta.x, tabledata.preferredHeight);
            }
        }
    }
    // 後で作る
    void Changelocate()
    {


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
