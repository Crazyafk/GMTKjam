using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIUIInterface : MonoBehaviour
{
    List<Card> showndeck;
    public string spawnRootPath;
    public GameObject cardPrefab;
    Transform spawnOne, spawnTwo, spawnThree;
    GameObject cardOne, cardTwo, cardThree;
    AI ai;

    void Start()
    {
        Transform root = GameObject.Find(spawnRootPath).transform;
        spawnOne = root.Find("CardSlotOne");
        spawnTwo = root.Find("CardSlotTwo");
        spawnThree = root.Find("CardSlotThree");

        showndeck = new List<Card>(new Card[3]);

        ai = GetComponent<AI>();
    }

    public void UpdateUI()
    {
        if(showndeck != ai.deck)
        {
            UpdateDeck();
        }
    }

    void UpdateDeck()
    {
        if(showndeck[0] != ai.deck[0])
        {
            if(cardOne != null)
            {
                Destroy(cardOne);
            }
            if(ai.deck[0] != null)
            {
                cardOne = Instantiate(cardPrefab, spawnOne);
            }
        }
        if(showndeck[1] != ai.deck[1])
        {
            if(cardTwo != null)
            {
                Destroy(cardTwo);
            }
            if(ai.deck[1] != null)
            {
                cardTwo = Instantiate(cardPrefab, spawnTwo);
            }
        }
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
                }
            }
        }
    }
}
