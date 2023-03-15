using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UICardData : MonoBehaviour
{
    [SerializeField]
    string cardName;
    CardManager cardManager;


    void Awake()
    {
        cardManager = FindObjectOfType<CardManager>();
        CardManager.Card card = cardManager.GetCard(cardName);

        // Find child GameObject by name
        string childName = "Panel";
        Transform childTransform = transform.Find(childName);
        if (childTransform != null)
        {
            GameObject childGameObject = childTransform.gameObject;
            // Do something with the child GameObject...
        }
    }

}
