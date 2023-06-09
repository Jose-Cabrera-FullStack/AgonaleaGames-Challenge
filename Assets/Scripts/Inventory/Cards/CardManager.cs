using System.Collections.Generic;
using UnityEngine;

public class CardManager : MonoBehaviour
{
    // Referencia al archivo JSON de configuración de cartas
    public TextAsset cardConfigFile;

    public class Card
    {
        public string name;
        public int level;
        public string rarity;
        public Sprite sprite;
        public Sprite background;


        public Card(string name, int level, string rarity, Sprite sprite, Sprite background)
        {
            this.name = name;
            this.level = level;
            this.rarity = rarity;
            this.sprite = sprite;
            this.background = background;
        }
    }
    // Lista de cartas
    public List<Card> cards = new List<Card>();

    // Clase que modela una colección de cartas (se usa para parsear el archivo JSON)
    [System.Serializable]
    public class CardCollection
    {
        public List<Card> cards;
    }

    [System.Serializable]
    public class CardCollectionJSON
    {
        public List<CardJSON> cards;
    }

    [System.Serializable]
    public class CardJSON
    {
        public string name;
        public int level;
        public string rarity;
        public string sprite;
        public string background;
    }

    private void Awake()
    {
        // TODO: Convertir en singlenton para evitar que se dupliquen las instancias.
        ParseCardConfigFile();
    }

    private void ParseCardConfigFile()
    {
        CardCollectionJSON cardCollection = JsonUtility.FromJson<CardCollectionJSON>(cardConfigFile.text);

        foreach (CardJSON cardData in cardCollection.cards)
        {
            string name = cardData.name;
            int level = cardData.level;
            string rarity = cardData.rarity;
            Sprite sprite = Resources.Load<Sprite>("Cards Assets/" + cardData.sprite);
            Sprite background = Resources.Load<Sprite>("Inventory/" + cardData.background);
            Card card = new Card(name, level, rarity, sprite, background);
            cards.Add(card);
        }

    }

    public Card GetCard(string cardName)
    {
        Card card = cards.Find(c => c.name == cardName);
        if (card == null)
        {
            Debug.LogError("Card not found: " + cardName);
        }
        return card;
    }
}
