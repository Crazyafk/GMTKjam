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

    FXManager fxmanager;

    int suspicion;
    bool isShaking;
    float shakeTimer;

    public float shakeLength, minShakeScale, maxShakeScale;

    Vector3 originalScale;

    Image image;

    void Awake()
    {
        image = GetComponent<Image>();

        fxmanager = GameObject.Find("GameManager").GetComponent<FXManager>();

        SetSuspicion(0);

        originalScale = transform.localScale;
    }
    void Update()
    {
        if(isShaking)
        {
            shakeTimer += Time.deltaTime;
            if(shakeTimer >= shakeLength)
            {
                isShaking = false;
            }

            float scaleMod = Random.Range(minShakeScale, maxShakeScale);
            transform.localScale = originalScale * scaleMod;
        }
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
        fxmanager.SusTooHigh();
        Shake();
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
        if(TryAddSuspicion(swapCardCost))
        {
            fxmanager.SusSFX();
            return true;
        }
        return false;
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
    void Shake()
    {
        isShaking = true;
        shakeTimer = 0f;
    }
}
