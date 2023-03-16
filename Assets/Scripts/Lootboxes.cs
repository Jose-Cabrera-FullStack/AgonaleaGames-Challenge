using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lootboxes : MonoBehaviour
{
    [SerializeField] GameObject cardPrefabLeft;
    [SerializeField] GameObject cardPrefabRight;
    [SerializeField] TextAsset chancesJSON;
    UICardData uiCardDataLeft;
    UICardData uiCardDataRight;

    void Start()
    {
        uiCardDataLeft = cardPrefabLeft.GetComponent<UICardData>();
        // uiCardDataRight = cardPrefabRight.GetComponent<UICardData>();
    }

    public void OpenCommonBox()
    {
        // Debug.Log($"antes Common:{uiCardDataLeft.cardName}");
        // uiCardDataLeft.cardName = "Card 5";
        // uiCardDataLeft.reRender();

        // Debug.Log($"despues Common:{uiCardDataLeft.cardName}");


    }

    public void OpenEpicBox()
    {
        //TODO implement it.
        Debug.Log($"Epic");
    }

    public void GetButtonClicked()
    {
        Debug.Log($"GetButton");

    }
}
