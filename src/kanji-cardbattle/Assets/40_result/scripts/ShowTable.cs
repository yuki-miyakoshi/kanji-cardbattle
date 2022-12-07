using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class ShowTable : MonoBehaviour
{
    [SerializeField] int KanjiID;
    [SerializeField] string Kanji, Busyu, Kakusu, Gakunenn, Kannkenn, Syubetu;
    [SerializeField] string[] Onnyomi, Kunnyomi, Imi;
    
    public void Show(MakeTable maketable)
    {
        //Text1_1.text = maketable.Kanji;
        //Row2.Data.Text.text = maketable.Onnyomi;
        //Row3.Data.Text.text = maketable.Kunnyomi;
        //Row4.Data.Text.text = maketable.Kanji;
        //Text5_1.text = maketable.Kakusu;
        //Text6_1.text = maketable.Gakunenn;
        //Text7_1.text = maketable.Kannkenn;
        //Text8_1.text = maketable.Syubetu;
    }
}
