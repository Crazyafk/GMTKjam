using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardManager : MonoBehaviour
{
    public List<Card> allCards;

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
}
