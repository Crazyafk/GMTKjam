using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI : MonoBehaviour
{
    enum Status{Playing, Stuck, Bust}
    Status status;

    public ValueDict doStick;

    int points; //how many rounds this AI has won

    CardManager cardManager;
    GameManager gameManager;
    List<Card> deck;
    int value;

    void Start()
    {
        cardManager = GameObject.Find("GameManager").GetComponent<CardManager>();
        gameManager = cardManager.GetComponent<GameManager>();
        deck = cardManager.GetStartingDeck();

        UpdateThings();
    }

    void UpdateThings()
    {
        value = cardManager.ValueDeck(deck);

        if(value > 21)
        {
            status = Status.Bust;
        }
    }

    public bool TakeTurn()
    {
        if(status != Status.Playing){return false;}

        if(doStick.RollProb(value))
        {
            status = Status.Stuck;
            UpdateThings();
        }
        else
        {
            deck.Add(gameManager.TakeCard());
            UpdateThings();
        }
        if(status != Status.Playing){return false;}
        return true;
    }
}
