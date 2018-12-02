using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEvent : ScriptableObject {
    public int mincooks;
    public int minhunters;
    public int mingatherers;    
    public int minwranglers;
    public int minwomen;
    public int minchildren;
    public int minhorses;

    public string title;
    public string description;
    public string minigameScene;//might not make it into the game
    public EventOption option1;
    public EventOption option2;
    public EventOption option3;

}
