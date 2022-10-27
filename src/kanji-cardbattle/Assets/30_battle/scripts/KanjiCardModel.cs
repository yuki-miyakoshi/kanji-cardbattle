using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
 
public class KanjiCardModel
{
    public int KanjiID_ = 0;
    public string KanjiUnique_,KanjiKanji_;

    public KanjiCardModel(int kanjiID,string kanjiUnique,string kanjiKanji)
    {
        KanjiID_ = kanjiID;

        KanjiUnique_ = kanjiUnique;

        KanjiKanji_ = kanjiKanji;
    }

}