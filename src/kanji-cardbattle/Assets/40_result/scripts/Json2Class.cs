using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Json2Class : MonoBehaviour
{
    void start()
    {
        MakeScriptableObject kanjiData = new MakeScriptableObject();
        kanjiData.KanjiID;
        kanjiData.Kanji;
        kanjiData.Busyu;
        kanjiData.Onnyomi;
        kanjiData.Kunnyomi;
        kanjiData.Kakusu;
        kanjiData.Imi;
        kanjiData.Gakunenn;
        kanjiData.Kannkenn;
        kanjiData.Syubetu;
    }
}



//string json = "{\"s\":\"xyz\",\"i\":2,\"f\":3.5,\"b\":false}";
Data data = JsonUtility.FromJson<Data>(json);
Debug.Log(data);