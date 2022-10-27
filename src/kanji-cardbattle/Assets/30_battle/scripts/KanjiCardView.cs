using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
 
public class KanjiCardView : MonoBehaviour
{
    [SerializeField] public Text kanjiText_;
    public int KanjiID_;
    public string KanjiUnique_,KanjiKanji_;
    

    public void Show(KanjiCardModel cardModel) // cardModelのデータ取得と反映
    {

        KanjiID_ = cardModel.KanjiID_;

        KanjiUnique_ = cardModel.KanjiUnique_;

        kanjiText_.text = cardModel.Kanji_;
    }
}