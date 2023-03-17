using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lootboxes : MonoBehaviour
{
    [SerializeField] GameObject cardPrefabLeft;
    [SerializeField] GameObject cardPrefabRight;
    [SerializeField] TextAsset chancesJSON;
    BoxChances chancesData;
    Transform cardsCointainer;
    List<GameObject> cardsCointainerChildren;
    CardManager cardManager;
    List<CardManager.Card> cards;

    void Awake()
    {
        Transform LootboxOpenPopUp = transform.Find("LootboxOpenPopUp");
        cardsCointainer = LootboxOpenPopUp.Find("CardsCointainer");
        chancesData = JsonUtility.FromJson<BoxChances>(chancesJSON.text);
        cardManager = FindObjectOfType<CardManager>();
        cards = cardManager.cards;
    }

    void showCards(int cardAmount, string lootboxType)
    {
        List<CardManager.Card> generatedCards = GenerateCards(lootboxType);

        int i = 0;

        foreach (CardManager.Card card in generatedCards)
        {
            if (i >= cardAmount)
                break;

            Transform cardTransform = cardsCointainer.GetChild(i);
            UICardData uiCard = cardTransform.GetComponent<UICardData>();
            uiCard.pickCard(card.name);
            cardTransform.gameObject.SetActive(true);

            i++;
        }

        for (; i < cardsCointainer.childCount; i++)
        {
            Transform cardTransform = cardsCointainer.GetChild(i);
            cardTransform.gameObject.SetActive(false);
        }
    }

    public void OpenCommonBox()
    {
        showCards(chancesData.CommonBox.amount, "CommonBox");
    }

    public void OpenEpicBox()
    {
        showCards(chancesData.EpicBox.amount, "EpicBox");
    }

    public void GetButtonClicked()
    {
        // TODO: Add cardsObtained
        Debug.Log($"GetButton");

    }

    CardManager.Card GetRandomCardByRarity(string rarity, List<CardManager.Card> usedCards)
    {
        List<CardManager.Card> filteredCards = cards.FindAll(card => card.rarity == rarity && !usedCards.Contains(card));
        if (filteredCards.Count == 0)
        {
            Debug.LogWarning($"No {rarity} cards available");
            return null;
        }
        int randomIndex = Random.Range(0, filteredCards.Count);
        return filteredCards[randomIndex];
    }

    public List<CardManager.Card> GenerateCards(string lootboxType)
    {
        List<CardManager.Card> usedCards = new List<CardManager.Card>();
        List<CardManager.Card> generatedCards = new List<CardManager.Card>();

        BoxChances.BoxData boxData = null;

        if (lootboxType == "CommonBox")
        {
            boxData = chancesData.CommonBox;
        }
        else if (lootboxType == "EpicBox")
        {
            boxData = chancesData.EpicBox;
        }
        else
        {
            Debug.LogError($"Invalid lootbox type: {lootboxType}");
            return generatedCards;
        }

        var chances = boxData.chances;
        int totalAmount = boxData.amount;

        int commonAmount = Mathf.RoundToInt(totalAmount * chances.common / 100f);
        int epicAmount = totalAmount - commonAmount;

        string rarity = (chances.common >= chances.epic) ? "common" : "epic";
        CardManager.Card mandatoryCard = GetRandomCardByRarity(rarity, usedCards);
        if (mandatoryCard != null)
        {
            generatedCards.Add(mandatoryCard);
            usedCards.Add(mandatoryCard);
        }

        for (int i = 1; i < totalAmount; i++)
        {
            rarity = (i < commonAmount) ? "common" : "epic";
            CardManager.Card randomCard = GetRandomCardByRarity(rarity, usedCards);
            if (randomCard != null)
            {
                generatedCards.Add(randomCard);
                usedCards.Add(randomCard);
            }
        }
        return generatedCards;
    }



    [System.Serializable]
    public class BoxChances
    {
        public BoxData CommonBox;
        public BoxData EpicBox;

        [System.Serializable]
        public class BoxData
        {
            public BoxChancesData chances;
            public int amount;
        }

        [System.Serializable]
        public class BoxChancesData
        {
            public int common;
            public int epic;
        }
    }

}


