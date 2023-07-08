using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    GameObject nextUpOne, nextUpTwo, nextUpThree;
    Transform spawnOne, spawnTwo, spawnThree;
    GameManager gameManager;
    CardController cardOne, cardTwo, cardThree;
    GameObject cardGOne, cardGTwo, cardGThree;
    public string spawnRootPath;
    public float slideRightTime;
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
        cardThree.CardData = viewCards[0];

        cardGTwo = Instantiate(cardPrefab, spawnTwo);
        cardTwo = cardGTwo.GetComponent<CardController>();
        cardTwo.CardData = viewCards[1];

        cardGOne = Instantiate(cardPrefab, spawnOne);
        cardOne = cardGOne.GetComponent<CardController>();
        cardOne.CardData = viewCards[2];
    }
    public void SlideDealerCards(Card _card)
    {
        print("slide");

        Destroy(cardGThree);

        cardTwo.SlideRight(spawnTwo.position, spawnThree.position, slideRightTime);
        cardGThree = cardGTwo;
        cardThree = cardTwo;

        cardOne.SlideRight(spawnOne.position, spawnTwo.position, slideRightTime);
        cardGTwo = cardGOne;
        cardTwo = cardOne;

        cardGOne = Instantiate(cardPrefab, spawnOne);
        cardOne = cardGOne.GetComponent<CardController>();
        cardOne.CardData = _card;
    }
    public void EndRound()
    {
        Destroy(cardGOne);
        Destroy(cardGTwo);
        Destroy(cardGThree);
    }
}
