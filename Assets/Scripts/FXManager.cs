using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FXManager : MonoBehaviour
{
    public GameObject shuffle;
    public void Shuffle()
    {
        Instantiate(shuffle);
    }
}
