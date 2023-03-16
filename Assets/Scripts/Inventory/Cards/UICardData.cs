using UnityEngine.UI;
using UnityEngine;

public class UICardData : MonoBehaviour
{
    private string _cardName;

    public string cardName
    {
        get { return _cardName; }
        set
        {
            _cardName = value;
            reRender();
        }
    }
    CardManager cardManager;
    CardManager.Card card;
    Transform sprite;
    Image background;

    void Awake()
    {
        cardManager = FindObjectOfType<CardManager>();
        sprite = transform.Find("Image");
        background = GetComponent<Image>();
    }


    void Update()
    {
        reRender();
    }

    public void reRender()
    {
        card = cardManager.GetCard(cardName);
        if (card != null)
        {
            chooseSprite();
            starsRenders();
            chooseBackground();
        }
    }

    void chooseSprite()
    {
        Image spriteCard = sprite.GetComponent<Image>();
        spriteCard.sprite = card.sprite;
    }

    void starsRenders()
    {
        string childName = "Panel";

        Transform starsContainer = transform.Find(childName);

        if (starsContainer != null)
        {
            for (int star = 0; star < starsContainer.childCount; star++)
            {
                Transform childTransform = starsContainer.GetChild(star);

                if (star < card.level)
                    childTransform.gameObject.SetActive(true);
                else
                    childTransform.gameObject.SetActive(false);

            }
        }
    }
    void chooseBackground()
    {
        background.sprite = card.background;
    }
}
