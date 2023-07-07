using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    CardManager cardManager;
    Queue<Card> toBeDealt;

    AI aiOne, aiTwo, aiThree;
    int whichAiIsPlayer; //0-2 //Which AI is do we want to win?
    int whichAiDueTurn; //0-2 //Which AI is due to take their turn next?
    
    void Start()
    {
        cardManager = GetComponent<CardManager>();

        toBeDealt = new Queue<Card>();
        for(int i = 0; i < 3; i++)
        {
            toBeDealt.Enqueue(cardManager.ChooseCard());
        }
    }

    public void NextTurn()
    {
        if(whichAiDueTurn == 0){aiOne.TakeTurn();}
        if(whichAiDueTurn == 1){aiOne.TakeTurn();}
        if(whichAiDueTurn == 2){aiOne.TakeTurn();}

        whichAiDueTurn = (whichAiDueTurn + 1) % 3;
    }

    public Card TakeCard()
    {
        toBeDealt.Enqueue(cardManager.ChooseCard());
        return(toBeDealt.Dequeue());
    }
}
