using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    CardManager cardManager;
    FXManager fxmanager;
    UIManager uimanager;
    SuspicionMeter suspicionMeter;
    public Queue<Card> toBeDealt;

    public int howManyRounds;
    int roundNo = 0;
    public AI aiOne, aiTwo, aiThree;
    public int whichAiIsPlayer; //0-2 //Which AI is do we want to win?
    [HideInInspector]
    public int whichAiDueTurn; //0-2 //Which AI is due to take their turn next?
    int cardClickLast = 0; //which card was clicked last? for card swapping
    
    void Start()
    {
        cardManager = GetComponent<CardManager>();
        fxmanager = GetComponent<FXManager>();
        uimanager = GetComponent<UIManager>();

        suspicionMeter = GameObject.Find("/Canvas/SuspicionMeter").GetComponent<SuspicionMeter>();

        toBeDealt = new Queue<Card>();
        
        uimanager.UpdateThings();
        NewRound();
    }

    public void NextTurn()
    {
        bool doAnotherTurn = false;

        if(whichAiDueTurn == 0)
        {
            if(!aiOne.TakeTurn()){doAnotherTurn = true;}
        }
        if(whichAiDueTurn == 1)
        {
            if(!aiTwo.TakeTurn()){doAnotherTurn = true;}
        }
        if(whichAiDueTurn == 2)
        {
            if(!aiThree.TakeTurn()){doAnotherTurn = true;}
        }

        whichAiDueTurn = (whichAiDueTurn + 1) % 3;

        if(aiOne.status != AI.Status.Playing && aiTwo.status != AI.Status.Playing && aiThree.status != AI.Status.Playing)
        {
            EndRound();
        }

        uimanager.UpdateThings();

        if(doAnotherTurn){NextTurn();}
        else{suspicionMeter.NextTurn();}
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

        if(winningAIid == 1){aiOne.Win();aiTwo.Lose();aiThree.Lose();}
        if(winningAIid == 2){aiTwo.Win();aiOne.Lose();aiThree.Lose();}
        if(winningAIid == 3){aiThree.Win();aiOne.Lose();aiTwo.Lose();}

        print("Current Scores:");
        print(aiOne.points);
        print(aiTwo.points);
        print(aiThree.points);

        uimanager.EndRound();

        if(roundNo < howManyRounds)
        {
            NewRound();
        }else{
            EndGame();
        }
    }

    public Card TakeCard()
    {
        Card newCard = cardManager.ChooseCard();
        uimanager.SlideDealerCards(newCard);
        toBeDealt.Enqueue(newCard);
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
        uimanager.InitDealerCards();
        uimanager.UpdateThings();
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

    public void ClickCard(int id)
    {
        if(cardClickLast == 0)
        {
            cardClickLast = id;
        }
        else if(cardClickLast == id)
        {
            cardClickLast = 0;
        }
        else
        {
            SwapCards(id, cardClickLast);
            cardClickLast = 0;
        }
    }
    void SwapCards(int a, int b)
    {
        if(!suspicionMeter.TrySwap()){return;}

        Card[] tempArray = new Card[3];
        tempArray[2] = toBeDealt.Dequeue();
        tempArray[1] = toBeDealt.Dequeue();
        tempArray[0] = toBeDealt.Dequeue();

        Card tempCard = tempArray[a-1];
        tempArray[a-1] = tempArray[b-1];
        tempArray[b-1] = tempCard;

        toBeDealt.Enqueue(tempArray[2]);
        toBeDealt.Enqueue(tempArray[1]);
        toBeDealt.Enqueue(tempArray[0]);

        uimanager.SwapDealerCards(a,b);
    }
    public void Hint(bool isStick)
    {
        if(whichAiIsPlayer == 0){aiOne.Hint(isStick);}
        if(whichAiIsPlayer == 1){aiTwo.Hint(isStick);}
        if(whichAiIsPlayer == 2){aiThree.Hint(isStick);}
    }
}
