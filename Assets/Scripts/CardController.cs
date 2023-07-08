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
    public float timeToFlip; //How much time the card should wait from awake to flipping to front
    SpriteRenderer cardFront;
    Animator animator;
    void Awake()
    {
        cardFront = transform.Find("front").GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();

        Invoke("FlipToFront", timeToFlip);
    }
    void FlipToFront()
    {
        animator.SetBool("showFront", true);
    }
}
