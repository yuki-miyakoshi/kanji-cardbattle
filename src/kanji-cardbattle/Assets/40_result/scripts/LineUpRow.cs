using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LineUpRow : MonoBehaviour
{
    public GameObject column1;
    public GameObject column2;

    // Update is called once per frame
    void Update()
    {
        Component[] comp = column2.GetComponentsInChildren<RectTransform>();
        float Height = comp[0].GetComponent<RectTransform>().sizeDelta.y;
        if (Height != 0) 
        SizeChange();    
        Debug.Log("a");
    }

    void SizeChange() //column1
    {
        Component[] colomn1Comp = column1.GetComponentsInChildren<RectTransform>();
        Component[] colomn2Comp = column2.GetComponentsInChildren<RectTransform>();
        // float sum = 0;
        for(int i = 0; i < colomn2Comp.Length; i++)
        {
            Vector2 sd1 = colomn1Comp[i].GetComponent<RectTransform>().sizeDelta;
            Vector2 sd2 = colomn2Comp[i].GetComponent<RectTransform>().sizeDelta;
            sd1.y = sd2.y;
            // sum += sd.y;
            colomn1Comp[i].GetComponent<RectTransform>().sizeDelta = sd1;
        }
    }
}
