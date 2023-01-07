using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KanjiScriptableObject : ScriptableObject
{
    public int kanjiID;
    public string kanji;
    public string part;
    public string partLeft;
    public int partLeftId;
    public string partRight;
    public int partRightId;
    public string[] readO;
    public string[] readK;
    public string[] mean;
    public int stroke;
    public int strokePart;
    public int strokeOther;
    public string schoolGrade;
    public int kankenGrade;
    public string category;

}
