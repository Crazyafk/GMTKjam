using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    CardManager cardManager;
    FXManager fxmanager;
    UIManager uimanager;
    Queue<Card> toBeDealt;

    public int howManyRounds;
    int roundNo = 0;
    public AI aiOne, aiTwo, aiThree;
    public int whichAiIsPlayer; //0-2 //Which AI is do we want to win?
    [HideInInspector]
    public int whichAiDueTurn; //0-2 //Which AI is due to take their turn next?
    
    void Start()
    {
        cardManager = GetComponent<CardManager>();
        fxmanager = GetComponent<FXManager>();
        uimanager = GetComponent<UIManager>();

        toBeDealt = new Queue<Card>();
        
        uimanager.UpdateThings();
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

        uimanager.UpdateThings();
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

        if(roundNo < howManyRounds)
        {
            NewRound();
        }else{
            EndGame();
        }
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
        whichAiDueTurn = 0;
        aiOne.NewRound();
        aiTwo.NewRound();
        aiThree.NewRound();

        fxmanager.Shuffle();
    }

    void EndGame()
    {
        int highestPoints = aiOne.points;
        int winningAIid = 1;

        if(aiTwo.points > highestPoints)
        {
            highestPoints = aiTwo.points;
            winningAIid = 2;
        }
        if(aiThree.points > highestPoints)
        {
            highestPoints = aiThree.points;
            winningAIid = 3;
        }

        print("Game Over!");
        print("AI #"+winningAIid+" Wins!");

        if(winningAIid - 1 == whichAiIsPlayer)
        {
            print("Player Wins!");
        }else{
            print("Player Loses!");
        }
    }
}
