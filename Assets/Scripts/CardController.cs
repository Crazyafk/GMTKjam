using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardController : MonoBehaviour
{
    private Card cardData;
    public Card CardData
    {
        get{return cardData;}
        set{
            cardData = value;
            cardFront.sprite = value.cardArt;
        }
    }
    SpriteRenderer cardFront;
    void Awake()
    {
        cardFront = transform.Find("front").GetComponent<SpriteRenderer>();
    }
}
