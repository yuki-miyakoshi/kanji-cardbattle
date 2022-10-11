using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
 
public class KanjiCardView : MonoBehaviour
{
    [SerializeField] public Text kanjiText;
    public int KanjiID = 0,KanjiPower;
    public string KanjiUnique,KanjiKanji;

    public void Show(KanjiCardModel cardModel) // cardModelのデータ取得と反映
    {

        KanjiID = cardModel.KanjiID;

        KanjiPower = cardModel.KanjiPower;

        KanjiUnique = cardModel.KanjiUnique;

        kanjiText.text = cardModel.KanjiKanji;
    }
}