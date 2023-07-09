using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FXManager : MonoBehaviour
{
    public GameObject shuffle;
    public GameObject stick, bust, twist;
    public GameObject sussfx;
    public GameObject speech;

    public string spawnRootPath;

    Transform spawnOne, spawnTwo, spawnThree;

    void Awake()
    {
        Transform root = GameObject.Find(spawnRootPath).transform;
        spawnOne = root.Find("AIOne");
        spawnTwo = root.Find("AITwo");
        spawnThree = root.Find("AIThree");
    }

    public void Shuffle()
    {
        Instantiate(shuffle);
    }
    public void Stick(int id)
    {
        Instantiate(stick, idSpawn(id), Quaternion.identity);
    }
    public void Bust(int id)
    {
        Instantiate(bust, idSpawn(id), Quaternion.identity);
    }
    public void Twist(int id)
    {
        Instantiate(twist, idSpawn(id), Quaternion.identity);
    }
    public void SusSFX()
    {
        Instantiate(sussfx);
    }
    public void Speech()
    {
        Instantiate(speech);
    }
    Vector3 idSpawn(int id)
    {
        Vector3 spawnPos = Vector3.zero;

        if(id == 1){spawnPos = spawnOne.position;}
        if(id == 2){spawnPos = spawnTwo.position;}
        if(id == 3){spawnPos = spawnThree.position;}

        return spawnPos;
    }
}
