using UnityEngine;

[CreateAssetMenu(fileName = "Card", menuName = "Card", order = 1)]
public class Card : ScriptableObject
{
    public Sprite cardArt;
    public int value;
    public string name;
}
