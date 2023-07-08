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
    public bool doFlipSound; //Make flip sound when flipping?
    SpriteRenderer cardFront;
    Animator animator;
    AudioSource audio;

    void Awake()
    {
        cardFront = transform.Find("front").GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        audio = GetComponent<AudioSource>();

        Invoke("FlipToFront", timeToFlip);
    }
    void FlipToFront()
    {
        animator.SetBool("showFront", true);
        if(doFlipSound)
        {
            audio.Play();
        }
    }
}
