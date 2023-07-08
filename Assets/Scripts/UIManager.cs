using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    GameObject nextUpOne, nextUpTwo, nextUpThree;
    GameManager gameManager;

    void Start()
    {
        gameManager = GetComponent<GameManager>();

        nextUpOne = gameManager.aiOne.transform.Find("nextUp").gameObject;
        nextUpTwo = gameManager.aiTwo.transform.Find("nextUp").gameObject;
        nextUpThree = gameManager.aiThree.transform.Find("nextUp").gameObject;
    }
    public void UpdateThings()
    {
        //NextUp
        if(gameManager.whichAiDueTurn == 0)
        {
            nextUpOne.SetActive(true);
            nextUpTwo.SetActive(false);
            nextUpThree.SetActive(false);
        }
        if(gameManager.whichAiDueTurn == 1)
        {
            nextUpOne.SetActive(false);
            nextUpTwo.SetActive(true);
            nextUpThree.SetActive(false);
        }
        if(gameManager.whichAiDueTurn == 2)
        {
            nextUpOne.SetActive(false);
            nextUpTwo.SetActive(false);
            nextUpThree.SetActive(true);
        }
    }
}
