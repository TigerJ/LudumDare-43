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

    public bool eventing;

    List<GameEvent> events;

    CanvasGroup eventPanel;
    Text eventDescription;
    Text eventOption1;
    Text eventOption2;
    Text eventOption3;
    Text eventResolution;

    // Use this for initialization
    void Start () {
        updateStat(100, "cooks");
        updateStat(100, "hunters");
        updateStat(100, "gatherers");
        updateStat(100, "wranglers");
        updateStat(100, "women");
        updateStat(100, "children");
        updateStat(100, "horses");

        eventPanel = GameObject.Find("EventPanel").GetComponent<CanvasGroup>();
        hideEvent();

        eventDescription = GameObject.Find("Description").GetComponent<Text>();
        eventOption1 = GameObject.Find("Option1").GetComponent<Text>();
        eventOption2 = GameObject.Find("Option2").GetComponent<Text>();
        eventOption3 = GameObject.Find("Option3").GetComponent<Text>();

        events = new List<GameEvent>();
        AddEvent("The sun was blazing hot down the wagons. As sweat beaded of the hats of the hunters and soaked the armpits of children, a large smokey campfire could be seen in the distance. The smell of deliciously fried frogs hung in the air and the stomachs of the women began to growl with the horses.", "option 1 text here", "option 2 text here", "option 3 test here", 0, 0, 0, 0, 0, 0, 0);
    }

    // Update is called once per frame
    void Update () {
        if (eventing == true)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                processChoice(1);
            }
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                processChoice(2);
            }
            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                processChoice(3);
            }
        }
	}
    void processChoice(int choice)
    {
        Debug.Log(choice);
        eventing = false;
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

    void AddEvent(string description, string option1, string option2, string option3, int mincooks, int minhunters, int mingatherers, int minwranglers, int minwomen, int minchildren, int minhorses)
    {
        GameEvent newEvent = ScriptableObject.CreateInstance<GameEvent>();
        newEvent.description = description;
        newEvent.option1 = option1;
        newEvent.option2 = option2;
        newEvent.option3 = option3;
        newEvent.mincooks = mincooks;
        newEvent.minhunters = minhunters;
        newEvent.mingatherers = mingatherers;
        newEvent.minwranglers = minwranglers;
        newEvent.minwomen = minwomen;
        newEvent.minchildren = minchildren;
        newEvent.minhorses = minhorses;
        events.Add(newEvent);
    }
    public void displayEvent()
    {
        eventing = true;
        List<GameEvent> possibleEvents = new List<GameEvent>();
        possibleEvents = events.FindAll(gameEvent => gameEvent.mincooks <= cooks && gameEvent.minhunters <= hunters && gameEvent.mingatherers <= gatherers && gameEvent.minwranglers <= wranglers && gameEvent.minwomen <= women && gameEvent.minchildren <= children && gameEvent.minhorses <= horses);
        GameEvent randomEvent = possibleEvents[Random.Range(0, possibleEvents.Count)];

        eventPanel.alpha = 1;
        eventPanel.blocksRaycasts = true;
        eventPanel.interactable = true;

        eventDescription.text = randomEvent.description;
        eventOption1.text = randomEvent.option1;
        eventOption2.text = randomEvent.option2;
        eventOption3.text = randomEvent.option3;
    }
    public void hideEvent()
    {
        eventPanel.alpha = 0;
        eventPanel.blocksRaycasts = false;
        eventPanel.interactable = false;
    }
}
