using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDestroy : MonoBehaviour
{
    public float TimeToDestroy;
    void Start()
    {
        Invoke("DestroySelf",TimeToDestroy);
    }
    void DestroySelf()
    {
        Destroy(this.gameObject);
    }
}
