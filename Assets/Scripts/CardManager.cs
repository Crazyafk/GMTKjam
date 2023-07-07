using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardManager : MonoBehaviour
{
    public List<Card> allCards;
    public ValueDict reroll;

    public Card ChooseCard()
    {
        int val = Random.Range(0,allCards.Count);

        return(allCards[val]);
    }
    public int ValueDeck(List<Card> deck)
    {
        int value = 0;
        foreach(Card card in deck)
        {
            value += card.value;
        }
        return(value);
    }
    public List<Card> GetStartingDeck()
    {
        List<Card> deck = new List<Card>();
        deck.Add(ChooseCard());
        deck.Add(ChooseCard());

        int value = ValueDeck(deck);
        if(reroll.RollProb(value))
        {
            return(GetStartingDeck());
        }
        return(deck);
    }
}
