using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DealerCard : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    public int id;
    GameManager gameManager;
    CardController cardController;

    void Awake()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        cardController = GetComponent<CardController>();
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        gameManager.ClickCard(id, cardController);
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        cardController.ChangeColour(cardController.mouseOverColor);
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        if(cardController.IsMouseOverColour())
        {
            cardController.ChangeColour(Color.white);
        }
    }
}
