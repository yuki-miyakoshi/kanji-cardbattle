using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "ScriptableObjects", menuName = "Create Table")]
public class MakeScriptableObject : ScriptableObject
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
}