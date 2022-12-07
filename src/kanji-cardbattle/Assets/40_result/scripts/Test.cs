using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
public class Test : MonoBehaviour
{
    public int KanjiID = 1;
    public GameObject title;
    public GameObject column1;
    public GameObject column2;
    float h2 = 0;

    void Awake()
    {
        MakeTable data = new MakeTable(KanjiID);
        ShowTable(data);
    }
    void Update()
    {
        // 最初のみ実行
        SizeChange(column1,column2);

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
    void ShowTable(MakeTable makeTable)
    {
        // 漢字
        title.GetComponent<Text>().text = makeTable.Kanji;
        // テキスト変更
        Component[] textComp = column2.GetComponentsInChildren<Text>();
        string[] textdata = 
            {
                makeTable.Busyu,
                Unify(makeTable.Onnyomi),
                Unify(makeTable.Kunnyomi),
                Unify(makeTable.Imi),
                makeTable.Kakusu,
                makeTable.Gakunenn,
                makeTable.Kannkenn,
                makeTable.Syubetu
            };
        for(int i = 0; i < textComp.Length; i++)
        {
            // テキスト変更
            Text content = textComp[i].GetComponent<Text>();
            content.text = textdata[i];
            // "-"の場合中央ぞろえ
            if(textdata[i] == "-")
            {
                content.alignment = TextAnchor.MiddleCenter;
            }
        }
    }
    void SizeChange(GameObject column1, GameObject column2) //column1
    {
        Component[] colomn1Comp = column1.GetComponentsInChildren<RectTransform>();
        Vector2 sd1 = colomn1Comp[1].GetComponent<RectTransform>().sizeDelta;
        Component[] colomn2Comp = column2.GetComponentsInChildren<RectTransform>();
        // float sum = 0;
        for(int i = 0; i < colomn2Comp.Length; i++)
        {
            Vector2 sd2 = colomn2Comp[i].GetComponent<RectTransform>().sizeDelta;
            sd1.y = sd2.y;
            // sum += sd.y;
            colomn1Comp[i].GetComponent<RectTransform>().sizeDelta = sd1;
        }
    }
}
