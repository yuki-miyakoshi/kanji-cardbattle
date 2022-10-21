using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
 
public class KanjiCardModel
{
    public int KanjiID = 0,KanjiPower;
    public string KanjiUnique,KanjiKanji;

    public KanjiCardModel(int kanjiID,int kanjiPower,string kanjiUnique,string kanjiKanji)
    {
        KanjiID = kanjiID;

        KanjiPower = kanjiPower;

        KanjiUnique = kanjiUnique;

        KanjiKanji = kanjiKanji;
    }

}