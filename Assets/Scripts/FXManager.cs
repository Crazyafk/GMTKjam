using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FXManager : MonoBehaviour
{
    public GameObject shuffle;
    public GameObject stick;

    public void Shuffle()
    {
        Instantiate(shuffle);
    }
    public void Stick()
    {
        Instantiate(stick);
    }
}
