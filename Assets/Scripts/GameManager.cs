using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    CardManager cardManager;
    Queue<Card> toBeDealt;

    public int howManyRounds;
    int roundNo = 1;
    public AI aiOne, aiTwo, aiThree;
    int whichAiIsPlayer; //0-2 //Which AI is do we want to win?
    int whichAiDueTurn; //0-2 //Which AI is due to take their turn next?
    
    void Start()
    {
        cardManager = GetComponent<CardManager>();

        toBeDealt = new Queue<Card>();
        
        NewRound();
    }

    public void NextTurn()
    {
        if(whichAiDueTurn == 0)
        {
            aiOne.TakeTurn();
        }
        if(whichAiDueTurn == 1)
        {
            aiTwo.TakeTurn();
        }
        if(whichAiDueTurn == 2)
        {
            aiThree.TakeTurn();
        }

        whichAiDueTurn = (whichAiDueTurn + 1) % 3;

        if(aiOne.status != AI.Status.Playing && aiTwo.status != AI.Status.Playing && aiThree.status != AI.Status.Playing)
        {
            EndRound();
        }
        if(roundNo < howManyRounds)
        {
            NewRound();
        }
    }

    void EndRound()
    {
        int highestValue = 0;
        int winningAIid = 0;

        if(aiOne.status == AI.Status.Stuck)
        {
            highestValue = aiOne.value;
            winningAIid = 1;
        }
        if(aiTwo.status == AI.Status.Stuck && aiTwo.value > highestValue)
        {
            highestValue = aiTwo.value;
            winningAIid = 2;
        }
        if(aiThree.status == AI.Status.Stuck && aiThree.value > highestValue)
        {
            highestValue = aiThree.value;
            winningAIid = 3;
        }

        if(winningAIid == 1){aiOne.Win();}
        if(winningAIid == 2){aiTwo.Win();}
        if(winningAIid == 3){aiThree.Win();}

        print("Current Scores:");
        print(aiOne.points);
        print(aiTwo.points);
        print(aiThree.points);
    }

    public Card TakeCard()
    {
        toBeDealt.Enqueue(cardManager.ChooseCard());
        return(toBeDealt.Dequeue());
    }

    void NewRound()
    {
        roundNo++;

        toBeDealt.Clear();

        for(int i = 0; i < 3; i++)
        {
            toBeDealt.Enqueue(cardManager.ChooseCard());
        }

        aiOne.NewRound();
        aiTwo.NewRound();
        aiThree.NewRound();
    }
}
