using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI : MonoBehaviour
{
    public int id;

    public enum Status{Playing, Stuck, Bust}
    public Status status;

    public ValueDict doStick;

    public int points; //how many rounds this AI has won

    CardManager cardManager;
    GameManager gameManager;
    List<Card> deck;
    public int value;

    void Start()
    {
        cardManager = GameObject.Find("GameManager").GetComponent<CardManager>();
        gameManager = cardManager.GetComponent<GameManager>();
    }

    void UpdateThings()
    {
        value = cardManager.ValueDeck(deck);

        if(value > 21)
        {
            status = Status.Bust;
            print("Bust!");
        }
    }

    public bool TakeTurn()
    {
        print("AI #"+id.ToString()+"'s Turn!");
        if(status != Status.Playing){return false;}

        if(doStick.RollProb(value))
        {
            status = Status.Stuck;
            UpdateThings();
            print("Stick!");
        }
        else
        {
            Card newCard = gameManager.TakeCard();
            deck.Add(newCard);
            print("Twist! Drawn: "+newCard.name);
            UpdateThings();
            print("Value: "+value);
        }
        if(status != Status.Playing){return false;}
        return true;
    }
    public void Win()
    {
        points += 1;
        print("AI #"+id.ToString()+" Wins this round!");
        UpdateThings();
    }
    public void NewRound()
    {
        status = Status.Playing;
        deck = cardManager.GetStartingDeck();
        UpdateThings();
    }
}
