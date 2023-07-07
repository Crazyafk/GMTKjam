using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
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
