using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEvent : ScriptableObject {
    public int mincooks;
    public int maxcooks;
    public int minhunters;
    public int maxhunters;
    public int mingatherers;
    public int maxgatherers;
    public int minwranglers;
    public int maxwranglers;
    public int minwomen;
    public int maxwomen;
    public int minchildren;
    public int maxchildren;
    public int minhorses;
    public int maxhorses;

    public string description;
    public string minigameScene;//might not make it into the game
    public string option1;
    public string option2;
    public string option3;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
