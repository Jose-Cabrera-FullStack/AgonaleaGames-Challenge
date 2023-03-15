using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UICardData : MonoBehaviour
{
    [SerializeField]
    string cardName;
    CardManager cardManager;


    void Start()
    {
        cardManager = FindObjectOfType<CardManager>();
        CardManager.Card card = cardManager.GetCard(cardName);

        string childName = "Panel";
        Transform panelChild = transform.Find(childName);

        if (panelChild != null)
        {
            for (int star = 0; star < panelChild.childCount; star++)
            {
                Transform childTransform = panelChild.GetChild(star);
                if (star < card.level) childTransform.gameObject.SetActive(true);
                else childTransform.gameObject.SetActive(false);

            }
        }
    }

}
