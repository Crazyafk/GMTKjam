using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    GameObject nextUpOne, nextUpTwo, nextUpThree;
    Transform spawnOne, spawnTwo, spawnThree;
    GameManager gameManager;
    CardController cardOne, cardTwo, cardThree;
    DealerCard cardDOne, cardDTwo, cardDThree;
    GameObject cardGOne, cardGTwo, cardGThree;
    public string spawnRootPath;
    public float slideRightTime;
    public float swapSlideTime;
    public GameObject cardPrefab;

    void Start()
    {
        gameManager = GetComponent<GameManager>();

        nextUpOne = gameManager.aiOne.transform.Find("nextUp").gameObject;
        nextUpTwo = gameManager.aiTwo.transform.Find("nextUp").gameObject;
        nextUpThree = gameManager.aiThree.transform.Find("nextUp").gameObject;

        Transform root = GameObject.Find(spawnRootPath).transform;
        spawnOne = root.Find("CardSlotOne");
        spawnTwo = root.Find("CardSlotTwo");
        spawnThree = root.Find("CardSlotThree");
    }
    public void UpdateThings()
    {
        //NextUp
        if(gameManager.whichAiDueTurn == 0)
        {
            nextUpOne.SetActive(true);
            nextUpTwo.SetActive(false);
            nextUpThree.SetActive(false);
        }
        if(gameManager.whichAiDueTurn == 1)
        {
            nextUpOne.SetActive(false);
            nextUpTwo.SetActive(true);
            nextUpThree.SetActive(false);
        }
        if(gameManager.whichAiDueTurn == 2)
        {
            nextUpOne.SetActive(false);
            nextUpTwo.SetActive(false);
            nextUpThree.SetActive(true);
        }
    }
    public void InitDealerCards()
    {
        Card[] viewCards = gameManager.toBeDealt.ToArray();

        cardGThree = Instantiate(cardPrefab, spawnThree);
        cardThree = cardGThree.GetComponent<CardController>();
        cardDThree = cardGThree.AddComponent<DealerCard>();
        cardDThree.id = 3;
        cardThree.CardData = viewCards[0];

        cardGTwo = Instantiate(cardPrefab, spawnTwo);
        cardTwo = cardGTwo.GetComponent<CardController>();
        cardDTwo = cardGTwo.AddComponent<DealerCard>();
        cardDTwo.id = 2;
        cardTwo.CardData = viewCards[1];

        cardGOne = Instantiate(cardPrefab, spawnOne);
        cardOne = cardGOne.GetComponent<CardController>();
        cardDOne = cardGOne.AddComponent<DealerCard>();
        cardDOne.id = 1;
        cardOne.CardData = viewCards[2];
    }
    public void SlideDealerCards(Card _card)
    {
        print("slide");

        Destroy(cardGThree);

        cardTwo.SlideRight(spawnTwo.position, spawnThree.position, slideRightTime);
        cardGThree = cardGTwo;
        cardDThree = cardDTwo;
        cardDThree.id = 3;
        cardThree = cardTwo;

        cardOne.SlideRight(spawnOne.position, spawnTwo.position, slideRightTime);
        cardGTwo = cardGOne;
        cardDTwo = cardDOne;
        cardDTwo.id = 2;
        cardTwo = cardOne;

        cardGOne = Instantiate(cardPrefab, spawnOne);
        cardOne = cardGOne.GetComponent<CardController>();
        cardDOne = cardGOne.AddComponent<DealerCard>();
        cardDOne.id = 1;
        cardOne.CardData = _card;
    }
    public void EndRound()
    {
        Destroy(cardGOne);
        Destroy(cardGTwo);
        Destroy(cardGThree);
    }
    public void SwapDealerCards(int a, int b)
    {
        Vector3 aPos = Vector3.zero;
        Vector3 bPos = Vector3.zero;

        switch(a)
        {
            case 1:
                aPos = spawnOne.position;
                break;
            case 2:
                aPos = spawnTwo.position;
                break;
            case 3:
                aPos = spawnThree.position;
                break;
            default:
                print("shit a");
                print(a);
                break;
        }
        switch(b)
        {
            case 1:
                bPos = spawnOne.position;
                cardOne.SlideRight(bPos, aPos, swapSlideTime);
                break;
            case 2:
                bPos = spawnTwo.position;
                cardTwo.SlideRight(bPos, aPos, swapSlideTime);
                break;
            case 3:
                bPos = spawnThree.position;
                cardThree.SlideRight(bPos, aPos, swapSlideTime);
                break;
            default:
                print("shit b");
                print(b);
                break;
        }
        switch(a)
        {
            case 1:
                cardOne.SlideRight(aPos, bPos, swapSlideTime);
                break;
            case 2:
                cardTwo.SlideRight(aPos, bPos, swapSlideTime);
                break;
            case 3:
                cardThree.SlideRight(aPos, bPos, swapSlideTime);
                break;
            default:
                print("shit a");
                print(a);
                break;
        }
    }
}
