using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeTable : MonoBehaviour
{
    public int KanjiID;
    public string Kanji;
    public string Busyu;
    public string[] Onnyomi;
    public string[] Kunnyomi;
    public string Kakusu;
    public string[] Imi;
    public string Gakunenn;
    public string Kannkenn;
    public string Syubetu;

    public MakeTable(int KanjiID)
    {
        MakeScriptableObject tableData = Resources.Load<MakeScriptableObject>("ScriptableObject/Data"+ KanjiID);

        KanjiID = tableData.KanjiID;
        Kanji = tableData.Kanji;
        Busyu = tableData.Busyu;
        Onnyomi = tableData.Onnyomi;
        Kunnyomi = tableData.Kunnyomi;
        Kakusu = tableData.Kakusu;
        Imi = tableData.Imi;
        Gakunenn = tableData.Gakunenn;
        Kannkenn = tableData.Kannkenn;
        Syubetu = tableData.Syubetu;
    }
}
