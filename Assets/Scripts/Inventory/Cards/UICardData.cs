using UnityEngine.UI;
using UnityEngine;

public class UICardData : MonoBehaviour
{
    [SerializeField]
    string cardName;
    CardManager cardManager;
    CardManager.Card card;
    Transform sprite;

    void Awake()
    {
        cardManager = FindObjectOfType<CardManager>();
        card = cardManager.GetCard(cardName);
        sprite = transform.Find("Image");
    }


    void Start()
    {
        chooseSprite();
        starsRenders();
        chooseBackground();
    }

    void chooseSprite()
    {
        Image image = sprite.GetComponent<Image>();
        image.sprite = card.sprite;
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

    }
}
