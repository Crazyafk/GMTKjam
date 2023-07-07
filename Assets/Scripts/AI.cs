using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI : MonoBehaviour
{
    enum Status{Playing, Stuck, Bust}
    Status status;

    int points; //how many rounds this AI has won

    CardManager cardManager;
    List<Card> deck;
    int value;

    void Start()
    {
        cardManager = GameObject.Find("GameManager").GetComponent<CardManager>();
        deck = cardManager.GetStartingDeck();

        UpdateAI();
    }

    void UpdateAI()
    {
        value = cardManager.ValueDeck(deck);
    }
}
