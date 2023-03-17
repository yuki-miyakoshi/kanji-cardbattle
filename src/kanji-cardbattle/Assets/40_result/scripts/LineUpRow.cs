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
            RectTransform column1RTf = colomn1Comp[i].GetComponent<RectTransform>();
            RectTransform column2RTf = colomn2Comp[i].GetComponent<RectTransform>();

            // column2のy座標を設定
            float y = column2RTf.sizeDelta.y + 50;
            column2RTf.anchoredPosition = new Vector2(column2RTf.anchoredPosition.x, y);
            // 高さをそろえる
            column1RTf.sizeDelta = new Vector2(column1RTf.sizeDelta.x, column2RTf.sizeDelta.y);
            // y座標をそろえる
            column1RTf.anchoredPosition = new Vector2(column1RTf.anchoredPosition.x, column2RTf.anchoredPosition.y);
        }
    }
}
