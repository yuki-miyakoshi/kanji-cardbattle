using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
 
public class KanjiCardModel
{
    public int KanjiID_ = 0;
    public string KanjiUnique_;
    public string Kanji_;

    public KanjiCardModel(string KanjiUnique)
    {

        KanjiUnique_ = KanjiUnique;

        Kanji_ = ReadKanjiCSV.instance.getKanjiCSV(int.Parse(KanjiUnique),1);

        KanjiID_++;
    }

}