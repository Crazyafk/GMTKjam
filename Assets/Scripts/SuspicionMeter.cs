using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SuspicionMeter : MonoBehaviour
{
    public Sprite[] sprites = new Sprite[46];

    [SerializeField]
    int swapCardCost;
    [SerializeField]
    int hintCost;
    [SerializeField]
    int perTurnDecay;

    [SerializeField]
    AIUIInterface susAiOne, susAiTwo;

    int suspicion;

    Image image;

    void Awake()
    {
        image = GetComponent<Image>();

        SetSuspicion(0);
    }
    public void SetSuspicion(int _sus)
    {
        suspicion = _sus;
        image.sprite = sprites[_sus];
    }
    public bool TryAddSuspicion(int _sus)
    {
        if(suspicion + _sus <= 45)
        {
            SetSuspicion(suspicion + _sus);
            SusAI();
            return true;
        }
        return false;
    }
    public void NextTurn()
    {
        suspicion -= perTurnDecay;
        if(suspicion < 0)
        {
            suspicion = 0;
        }
        SetSuspicion(suspicion);
    }
    public bool TrySwap()
    {
        return(TryAddSuspicion(swapCardCost));
    }
    public bool TryHint()
    {
        return(TryAddSuspicion(hintCost));
    }
    void SusAI()
    {
        if(Random.Range(0f,2f) > 1)
        {
            susAiOne.Sus();
        }else{
            susAiTwo.Sus();
        }
    }
}
