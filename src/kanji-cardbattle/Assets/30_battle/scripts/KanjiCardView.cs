using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
 
public class KanjiCardView : MonoBehaviour
{
    [SerializeField] public Text kanjiText;
    public int KanjiID = 0;
    public string KanjiUnique,KanjiKanji;

    public void Show(KanjiCardModel cardModel) // cardModelのデータ取得と反映
    {

        KanjiID = cardModel.KanjiID_;

        KanjiUnique = cardModel.KanjiUnique_;

        kanjiText.text = cardModel.KanjiKanji_;
    }
}