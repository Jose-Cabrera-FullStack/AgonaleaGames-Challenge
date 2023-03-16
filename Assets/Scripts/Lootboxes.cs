using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lootboxes : MonoBehaviour
{
    [SerializeField] GameObject cardPrefabLeft;
    [SerializeField] GameObject cardPrefabRight;
    [SerializeField] TextAsset chancesJSON;
    Transform cardsCointainer;
    List<GameObject> cardsCointainerChildren;

    void Awake()
    {
        Transform LootboxOpenPopUp = transform.Find("LootboxOpenPopUp");

        cardsCointainer = LootboxOpenPopUp.Find("CardsCointainer");

        // chancesData = JsonUtility.FromJson<Dictionary<string, Dictionary<string, int>>>(chancesJSON.text);
    }

    void showCards()
    {
        for (int i = 0; i < cardsCointainer.childCount; i += 1)
        {
            Transform card = cardsCointainer.GetChild(i);
            if (i < 2)
            {
                UICardData uiCard = card.GetComponent<UICardData>();
                card.gameObject.SetActive(true);
                Debug.Log($"{card}");
            }
            else
                card.gameObject.SetActive(false);
        }

    }

    public void OpenCommonBox()
    {
        // int amount = chancesData["CommonBox"]["amount"];
        // List<CardManager.Card> cards = new List<CardManager.Card>();
        showCards();
        // uiCardDataLeft.pickCard("Carta 5");
        // uiCardDataRight.pickCard("Carta 2");
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
