using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIUIInterface : MonoBehaviour
{
    public List<Card> showndeck;
    public string spawnRootPath;
    public GameObject cardPrefab;
    Transform spawnOne, spawnTwo, spawnThree, spawnFour, spawnFive, spawnSix, spawnSeven;
    GameObject cardOne, cardTwo, cardThree, cardFour, cardFive, cardSix, cardSeven;
    CardController cardConOne, cardConTwo, cardConThree, cardConFour, cardConFive, cardConSix, cardConSeven;
    AI ai;
    Animator animator;

    void Start()
    {
        Transform root = GameObject.Find(spawnRootPath).transform;
        spawnOne = root.Find("CardSlotOne");
        spawnTwo = root.Find("CardSlotTwo");
        spawnThree = root.Find("CardSlotThree");
        spawnFour = root.Find("CardSlotFour");
        spawnFive = root.Find("CardSlotFive");
        spawnSix = root.Find("CardSlotSix");
        spawnSeven = root.Find("CardSlotSeven");

        showndeck = new List<Card>(new Card[7]);

        ai = GetComponent<AI>();

        animator = transform.Find("playerSprite").GetComponent<Animator>();
    }

    public void UpdateUI()
    {
        UpdateDeck();
    }

    public void Hand()
    {
        animator.SetTrigger("Hand");
    }
    public void Anger()
    {
        animator.SetTrigger("Anger");
    }
    public void Sus()
    {
        animator.SetTrigger("Sus");
    }
    public void Think()
    {
        animator.SetTrigger("Think");
    }
    public void Win()
    {
        animator.SetTrigger("Win");
    }

    void UpdateDeck()
    {
        //Slot 1
        if(showndeck[0] != ai.deck[0])
        {
            if(cardOne != null)
            {
                Destroy(cardOne);
            }
            if(ai.deck[0] != null)
            {
                cardOne = Instantiate(cardPrefab, spawnOne);
                cardConOne = cardOne.GetComponent<CardController>();
                cardConOne.CardData = ai.deck[0];
            }
            showndeck[0] = ai.deck[0];
        }
        //Slot 2
        if(showndeck[1] != ai.deck[1])
        {
            if(cardTwo != null)
            {
                Destroy(cardTwo);
            }
            if(ai.deck[1] != null)
            {
                cardTwo = Instantiate(cardPrefab, spawnTwo);
                cardConTwo = cardTwo.GetComponent<CardController>();
                cardConTwo.CardData = ai.deck[1];
            }
            showndeck[1] = ai.deck[1];
        }
        //Slot 3
        if(ai.deck.Count > 2)
        {
            if(showndeck[2] != ai.deck[2])
            {
                if(cardThree != null)
                {
                    Destroy(cardThree);
                }
                if(ai.deck[2] != null)
                {
                    cardThree = Instantiate(cardPrefab, spawnThree);
                    cardConThree = cardThree.GetComponent<CardController>();
                    cardConThree.CardData = ai.deck[2];
                    cardConThree.doFlipSound = true;
                }
            }
            showndeck[2] = ai.deck[2];
        }
        else
        {
            if(cardThree != null)
            {
                Destroy(cardThree);
            }
        }
        //Slot 4
        if(ai.deck.Count > 3)
        {
            if(showndeck[3] != ai.deck[3])
            {
                if(cardFour != null)
                {
                    Destroy(cardFour);
                }
                if(ai.deck[3] != null)
                {
                    cardFour = Instantiate(cardPrefab, spawnFour);
                    cardConFour = cardFour.GetComponent<CardController>();
                    cardConFour.CardData = ai.deck[3];
                    cardConFour.doFlipSound = true;
                }
            }
            showndeck[3] = ai.deck[3];
        }
        else
        {
            if(cardFour != null)
            {
                Destroy(cardFour);
            }
        }
        //Slot 5
        if(ai.deck.Count > 4)
        {
            if(showndeck[4] != ai.deck[4])
            {
                if(cardFive != null)
                {
                    Destroy(cardFive);
                }
                if(ai.deck[4] != null)
                {
                    cardFive = Instantiate(cardPrefab, spawnFive);
                    cardConFive = cardFive.GetComponent<CardController>();
                    cardConFive.CardData = ai.deck[4];
                    cardConFive.doFlipSound = true;
                }
            }
            showndeck[4] = ai.deck[4];
        }
        else
        {
            if(cardFive != null)
            {
                Destroy(cardFive);
            }
        }
        //Slot 6
        if(ai.deck.Count > 5)
        {
            if(showndeck[5] != ai.deck[5])
            {
                if(cardSix != null)
                {
                    Destroy(cardSix);
                }
                if(ai.deck[5] != null)
                {
                    cardSix = Instantiate(cardPrefab, spawnSix);
                    cardConSix = cardSix.GetComponent<CardController>();
                    cardConSix.CardData = ai.deck[5];
                    cardConSix.doFlipSound = true;
                }
            }
            showndeck[5] = ai.deck[5];
        }
        else
        {
            if(cardSix != null)
            {
                Destroy(cardSix);
            }
        }
        //Slot 7
        if(ai.deck.Count > 6)
        {
            if(showndeck[6] != ai.deck[6])
            {
                if(cardSeven != null)
                {
                    Destroy(cardSeven);
                }
                if(ai.deck[6] != null)
                {
                    cardSeven = Instantiate(cardPrefab, spawnSeven);
                    cardConSeven = cardSeven.GetComponent<CardController>();
                    cardConSeven.CardData = ai.deck[6];
                    cardConSeven.doFlipSound = true;
                }
            }
            showndeck[6] = ai.deck[6];
        }
        else
        {
            if(cardSeven != null)
            {
                Destroy(cardSeven);
            }
        }
    }
}
