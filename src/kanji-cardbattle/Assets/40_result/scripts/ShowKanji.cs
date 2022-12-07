using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowKanji : MonoBehaviour
{
    public int KanjiID = 1;
    void Awake()
    {
        MakeTable data = new MakeTable(KanjiID);
        DisplayKanji(data);
    }
    void DisplayKanji(MakeTable table)
    {
        Text kanji = this.GetComponent<Text>();
        kanji.text = table.Kanji;
    }  
}
