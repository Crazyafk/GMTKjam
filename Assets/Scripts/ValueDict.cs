using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "ValueDict", menuName = "ScriptableObjects/ValueDict", order = 1)]
public class ValueDict : ScriptableObject
{
    [Header("0 is will always return false, 1 is will always return true")]
    [Range(0f,1f)]
    public float v2;
    [Range(0f,1f)]
    public float v3;
    [Range(0f,1f)]
    public float v4;
    [Range(0f,1f)]
    public float v5;
    [Range(0f,1f)]
    public float v6;
    [Range(0f,1f)]
    public float v7;
    [Range(0f,1f)]
    public float v8;
    [Range(0f,1f)]
    public float v9;
    [Range(0f,1f)]
    public float v10;
    [Range(0f,1f)]
    public float v11;
    [Range(0f,1f)]
    public float v12;
    [Range(0f,1f)]
    public float v13;
    [Range(0f,1f)]
    public float v14;
    [Range(0f,1f)]
    public float v15;
    [Range(0f,1f)]
    public float v16;
    [Range(0f,1f)]
    public float v17;
    [Range(0f,1f)]
    public float v18;
    [Range(0f,1f)]
    public float v19;
    [Range(0f,1f)]
    public float v20;
    [Range(0f,1f)]
    public float v21;

    List<float> list;
    bool isInited = false;

    void CheckInit()
    {
        if(!isInited)
        {
            isInited = true;
            list = new List<float>();
            list.Add(v2);
            list.Add(v3);
            list.Add(v4);
            list.Add(v5);
            list.Add(v6);
            list.Add(v7);
            list.Add(v8);
            list.Add(v9);
            list.Add(v10);
            list.Add(v11);
            list.Add(v12);
            list.Add(v13);
            list.Add(v14);
            list.Add(v15);
            list.Add(v16);
            list.Add(v17);
            list.Add(v18);
            list.Add(v19);
            list.Add(v20);
            list.Add(v21);
        }
    }
    public float GetProb(int value)
    {
        CheckInit();
        return(list[value - 2]); //list starts at 2, which is index 0.
    }
    public bool RollProb(int value)
    {
        float probability = GetProb(value);
        float rand = Random.Range(0f,1f);

        if(rand < probability)
        {
            return(true);
        }
        return(false);
    }
}