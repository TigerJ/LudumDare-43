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
    GameEvent randomEvent;
    EventResolution randomResolution;

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


        //tale of fried frogs

        EventOption event1Option1 = createOption(0, 2, 0, 0, 1, 1, 0, "[press 1] You send in 2 hunters with guns, followed by 1 woman and 1 child to show your family situation. The child is holding a frog.");
        event1Option1.resolutions = new List<EventResolution>();
        event1Option1.resolutions.Add(createResolution(0, 2, 0, 0, 0, 0, 1, "The frog fixin dudes are impressed by your hunters outfits and your peaceful nature. They agree to join your party"));
        event1Option1.resolutions.Add(createResolution(0, -2, 0, 0, 0, 0, 0, "Your hunters look menacing as they approach and accidently cath the good natured frog cookers off guard. Both your hunters are shot and killed. The woman and child flee back for safety."));
        event1Option1.resolutions.Add(createResolution(0, -2, 0, 0, -1, -1, 0, "The frog food is so delicious, the woman and child decide to remain with the frog cookin' dudes. and settle in a nearby cave. The hunters also join to learn the art of giggin'"));

        EventOption event1Option2 = createOption(4, 0, 0, 0, 0, 0, 0, "[press 2] 4 of your cooks are interested in the delicious smells that hang in the air.");
        event1Option2.resolutions = new List<EventResolution>();
        event1Option2.resolutions.Add(createResolution(-4, 0, 0, 0, 0, 0, 0, "Upon reaching the frog cooking camp, your cooks realize they have sumbled into a trap from a delerious escaped cannibal! All your cooks are eaten with sides of fried frogs."));
        event1Option2.resolutions.Add(createResolution(2, 0, 0, 0, 0, 0, 0, "Your cooks meet their cooks, their cooks like your cooks, all the cooks spend a lot of time talking about different types of salts. the other cooks join your cooks to cook."));
        event1Option2.resolutions.Add(createResolution(-2, 0, 0, 0, 0, 0, 0, "The campsite is abonded.. After eating and sampling some of the fried frogs, two of your cooks die immediatly from choking on the delicious legs."));

        EventOption event1Option3 = createOption(0, 2, 0, 0, 0, 0, 2, "[press 3] 2 of your mounted hunters are sent to investigate");
        event1Option3.resolutions = new List<EventResolution>();
        event1Option3.resolutions.Add(createResolution(2, 0, 0, 0, 0, 0, 0, "Two cooks hanging out by a fire share their feast with your hunters and are impressed by your upkeep of animals and health. they join you."));
        event1Option3.resolutions.Add(createResolution(0, 0, 0, 0, 0, 0, -2, "The cooks share their frogs with your hunters, they then become interested in your horses... very interested in them. Your hunters barely escape being eaten along with them."));
        event1Option3.resolutions.Add(createResolution(0, -2, 0, 0, 0, 0, -2, "The campsite is full of people who are VERY hungry. Your hunters and horses do not return."));

        AddEvent("The sun was blazing hot down the wagons. As sweat beaded of the hats of the hunters and soaked the armpits of children, a large smokey campfire could be seen in the distance. The smell of deliciously fried frogs hung in the air and the stomachs of the women began to growl with the horses.", 0, 0, 0, 0, 0, 0, 0, event1Option1, event1Option2, event1Option3);

        //
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
        switch (choice)
        {
            case 1:
                randomResolution = randomEvent.option1.resolutions[Random.Range(0, randomEvent.option1.resolutions.Count)];
                break;
            case 2:
                randomResolution = randomEvent.option2.resolutions[Random.Range(0, randomEvent.option2.resolutions.Count)];
                break;
            case 3:
                randomResolution = randomEvent.option3.resolutions[Random.Range(0, randomEvent.option3.resolutions.Count)];
                break;
        }
        updateStat(randomResolution.cooks, "cooks");
        updateStat(randomResolution.hunters, "hunters");
        updateStat(randomResolution.gatherers, "gatherers");
        updateStat(randomResolution.wranglers, "wranglers");
        updateStat(randomResolution.women, "women");
        updateStat(randomResolution.children, "children");
        updateStat(randomResolution.horses, "horses");

        eventDescription.text = randomResolution.resolutionText;
        eventOption1.text = "";
        eventOption2.text = "";
        eventOption3.text = "";

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

    void AddEvent(string description, int mincooks, int minhunters, int mingatherers, int minwranglers, int minwomen, int minchildren, int minhorses, EventOption option1, EventOption option2 , EventOption option3)
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
    EventOption createOption(int cooks, int hunters, int gatherers, int wranglers, int women, int children, int horses, string OptionText)
    {
        EventOption eventOption = ScriptableObject.CreateInstance<EventOption>();
        eventOption.cooks = cooks;
        eventOption.hunters = hunters;
        eventOption.gatherers = gatherers;
        eventOption.wranglers = wranglers;
        eventOption.women = women;
        eventOption.children = children;
        eventOption.horses = horses;
        eventOption.OptionText = OptionText;
        return eventOption;
    }
    EventResolution createResolution(int cooks, int hunters, int gatherers, int wranglers, int women, int children, int horses, string resolutionText)
    {
        EventResolution eventResolution = ScriptableObject.CreateInstance<EventResolution>();
        eventResolution.cooks = cooks;
        eventResolution.hunters = hunters;
        eventResolution.gatherers = gatherers;
        eventResolution.wranglers = wranglers;
        eventResolution.women = women;
        eventResolution.children = children;
        eventResolution.horses = horses;
        eventResolution.resolutionText = resolutionText;
        return eventResolution;
    }
    public void displayEvent()
    {
        eventing = true;
        List<GameEvent> possibleEvents = new List<GameEvent>();
        possibleEvents = events.FindAll(gameEvent => gameEvent.mincooks <= cooks && gameEvent.minhunters <= hunters && gameEvent.mingatherers <= gatherers && gameEvent.minwranglers <= wranglers && gameEvent.minwomen <= women && gameEvent.minchildren <= children && gameEvent.minhorses <= horses);
        randomEvent = possibleEvents[Random.Range(0, possibleEvents.Count)];

        eventPanel.alpha = 1;
        eventPanel.blocksRaycasts = true;
        eventPanel.interactable = true;

        eventDescription.text = randomEvent.description;
        eventOption1.text = randomEvent.option1.OptionText;
        eventOption2.text = randomEvent.option2.OptionText;
        eventOption3.text = randomEvent.option3.OptionText;
    }
    public void hideEvent()
    {
        eventPanel.alpha = 0;
        eventPanel.blocksRaycasts = false;
        eventPanel.interactable = false;
    }
}
