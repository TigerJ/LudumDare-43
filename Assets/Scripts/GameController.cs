using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {
    public int cooks;
    public int hunters;
    public int gatherers;
    public int wranglers;
    public int women;
    public int children;
    public int horses;

    public Text cooksText;
    public Text huntersText;
    public Text gatherersText;
    public Text wranglersText;
    public Text womenText;
    public Text childrenText;
    public Text horsesText;
    // Use this for initialization
    void Start () {
        updateStat(100, "cooks");
        updateStat(100, "hunters");
        updateStat(100, "gatherers");
        updateStat(100, "wranglers");
        updateStat(100, "women");
        updateStat(100, "children");
        updateStat(100, "horses");
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    public void updateStat(int amount, string stat)
    {
        switch (stat)
        {
            case "cooks":
                cooks = cooks + amount;
                cooksText.text = pad3(cooks);
                break;
            case "hunters":
                hunters = hunters + amount;
                huntersText.text = pad3(hunters);
                break;
            case "gatherers":
                gatherers = gatherers + amount;
                gatherersText.text = pad3(gatherers);
                break;
            case "wranglers":
                wranglers = wranglers + amount;
                wranglersText.text = pad3(wranglers);
                break;
            case "women":
                women = women + amount;
                womenText.text = pad3(women);
                break;
            case "children":
                children = children + amount;
                childrenText.text = pad3(children);
                break;
            case "horses":
                horses = horses + amount;
                horsesText.text = pad3(horses);
                break;
        }
    }
    string pad3(int value)
    {
        return value.ToString("d3");
    }
}
