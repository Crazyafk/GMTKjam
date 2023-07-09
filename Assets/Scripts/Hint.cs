using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hint : MonoBehaviour
{
    string[] stickPuns = {
        "Is it just me or is it a bit STICKY in here?",
        "I was a bit STUCK on the crossword today",
        "My favourite webcomic is homeSTUCK",
        "STUCK on a feeling! ... wait it's hooked?",
        "I really like frogs, they're STICKY little guys",
        "what's brown and sticky? A STICK",
        "Best music rhythm? Probably STICKato",
        "I can't draw, I can only do STICKmen",
        "I had a pet frog once. Called it STICKy",
        "best chocolate? Probably matchSTICKs",
        "I like cottages, they're so rusSTICK",
        "STICK it to the man!",
        "I've always wanted to learn how to use chopSTICKs",
        "that person has some real nice lipSTICK on",
        "can't believe I got STUCK with this match",
        "I should've STUCK to improv, man",
        "what's the hardest bug to escape? A STICK insect!",
        "what youtube link do trees hate? A STICK-roll",
        "I got STICK-bugged yesterday.",
        "how do you kill a tiny vampire? A STICK to the heart",
        "favourite singer? Probably STICKleBack"
    };

    string[] twistPuns = {
        "favourite board game? Probably TWISTer",
        "favourite ice cream? Probably a TWISTer",
        "favourite song? TWIST and shout",
        "favourite play? Oliver TWIST of course!",
        "TWISTers are a real menace in California",
        "Elon Musk ruined TWISTer - uh I mean twitter",
        "I TWISTed my ankle the other week",
        "The Joker is my favourite villain. He's so TWISTed",
        "I could never cheat! Don't TWIST my arm on that",
        "love a good tongueTWISTer",
        "fed up of all disney films having TWIST villains"
    };

    public float displayTime;
    public Text punText;
    public Image punImage;

    public SuspicionMeter suspicionMeter;
    public GameManager gameManager;
    public FXManager fxmanager;

    public void GiveHint(bool isStick)
    {
        if(!suspicionMeter.TryHint()){return;}

        if(isStick)
        {
            int val = Random.Range(0,stickPuns.Length);
            DisplayPun(stickPuns[val]);
        }
        else{
            int val = Random.Range(0,twistPuns.Length);
            DisplayPun(twistPuns[val]);
        }

        gameManager.Hint(isStick);
    }
    void DisplayPun(string pun)
    {
        punImage.enabled = true;
        punText.enabled = true;
        punText.text = pun;
        Invoke("RemoveDisplay",displayTime);

        fxmanager.Speech();
    }
    void RemoveDisplay()
    {
        punImage.enabled = false;
        punText.enabled = false;
    }
}
