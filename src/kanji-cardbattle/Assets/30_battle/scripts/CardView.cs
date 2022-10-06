using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
 
public class CardView : MonoBehaviour
{
    [SerializeField] Text nameText, powerText, costText;
    [SerializeField] Image iconImage;
 
    public void Show(CardModel cardModel) // cardModelのデータ取得と反映
    {
        nameText.text = cardModel.name;
        powerText.text = cardModel.power.ToString();
        costText.text = cardModel.cost.ToString();
        iconImage.sprite = cardModel.icon;
    }
}