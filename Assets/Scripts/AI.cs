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
    public FXManager fxmanager;
    AIUIInterface aIUIInterface;
    public List<Card> deck;
    public int value;
    bool isHinted;
    bool hintIsStick;

    void Start()
    {
        cardManager = GameObject.Find("GameManager").GetComponent<CardManager>();
        gameManager = cardManager.GetComponent<GameManager>();
        fxmanager = cardManager.GetComponent<FXManager>();
        aIUIInterface = GetComponent<AIUIInterface>();

        deck = new List<Card>();
    }

    void UpdateThings()
    {
        value = cardManager.ValueDeck(deck);

        if(value > 21)
        {
            status = Status.Bust;
            print("Bust!");
            fxmanager.Bust(id);
        }

        aIUIInterface.UpdateUI();
    }

    public bool TakeTurn()
    {
        print("AI #"+id.ToString()+"'s Turn!");
        if(status != Status.Playing){return false;}

        if(isHinted)
        {
            isHinted = false;
            if(hintIsStick)
            {
                Stick();
            }else{
                Twist();
            }
        }
        else{
            if(doStick.RollProb(value))
            {
                Stick();
            }
            else
            {
                Twist();
            }
        }
        return true;
    }
    void Stick()
    {
        status = Status.Stuck;
        UpdateThings();
        print("Stick!");
        fxmanager.Stick(id);
        aIUIInterface.Think();
    }
    void Twist()
    {
        Card newCard = gameManager.TakeCard();
        deck.Add(newCard);
        print("Twist! Drawn: "+newCard.name);
        UpdateThings();
        print("Value: "+value);
        fxmanager.Twist(id);
        aIUIInterface.Hand();
    }
    public void Win()
    {
        points += 1;
        print("AI #"+id.ToString()+" Wins this round!");
        UpdateThings();
        aIUIInterface.Win();
    }
    public void Lose()
    {
        aIUIInterface.Anger();
    }
    public void NewRound()
    {
        status = Status.Playing;
        deck = cardManager.GetStartingDeck();
        UpdateThings();
    }
    public void Hint(bool isStick)
    {
        isHinted = true;
        hintIsStick = isStick;
    }
}
