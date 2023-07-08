using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DealerCard : MonoBehaviour, IPointerClickHandler
{
    public int id;
    GameManager gameManager;

    void Awake()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        gameManager.ClickCard(id);
    }
}
