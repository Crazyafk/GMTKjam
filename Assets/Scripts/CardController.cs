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
    int sliding; //0 - none, 1 - slide right, 2 - slide out
    Vector3 slideOrigin, slideDestination;
    float slidetime, slidetimer;
    public Color selectColor, mouseOverColor;
    public bool testSlideTrigger;

    void Awake()
    {
        cardFront = transform.Find("front").GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        audio = GetComponent<AudioSource>();

        Invoke("FlipToFront", timeToFlip);
    }
    void Update()
    {
        if(sliding != 0)
        {
            transform.position = Utility.SmoothLerp(slideOrigin, slideDestination, slidetimer / slidetime);

            if(sliding == 2)
            {
                Color colour = cardFront.color;
                colour.a = Mathf.Lerp(1f, 0f, slidetimer / slidetime);
                cardFront.color = colour;

                print(cardFront.color.a);
            }

            slidetimer += Time.deltaTime;
            if(slidetimer >= slidetime)
            {
                if(sliding == 2)
                {
                    Destroy(this.gameObject);
                }

                transform.position = slideDestination;
                sliding = 0;
            }
        }

        if(testSlideTrigger)
        {
            SlideRight(transform.position, transform.position + Vector3.right, 1f);
            testSlideTrigger = false;
        }
    }
    void FlipToFront()
    {
        animator.SetBool("showFront", true);
        if(doFlipSound)
        {
            audio.Play();
        }
    }
    public void SlideRight(Vector3 _origin, Vector3 _dest, float _time)
    {
        sliding = 1;
        slideOrigin = _origin;
        slideDestination = _dest;
        slidetime = _time;
        slidetimer = 0f;
    }
    public void SlideOut(Vector3 _origin, Vector3 _dest, float _time)
    {
        sliding = 2;
        slideOrigin = _origin;
        slideDestination = _dest;
        slidetime = _time;
        slidetimer = 0f;
    }
    public void ChangeColour(Color colour)
    {
        if(sliding != 2)
        {
            cardFront.color = colour;
        }
    }
    public bool IsMouseOverColour()
    {
        return(cardFront.color == mouseOverColor);
    }
}
