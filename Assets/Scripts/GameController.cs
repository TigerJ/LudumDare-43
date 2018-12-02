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

    public StatChange cooksChange;
    public StatChange huntersChange;
    public StatChange gatherersChange;
    public StatChange wranglersChange;
    public StatChange womenChange;
    public StatChange childrenChange;
    public StatChange horsesChange;

    public bool eventing;
    public bool evented;
    List<GameEvent> events;
    GameEvent randomEvent;
    EventResolution randomResolution;

    CanvasGroup eventPanel;
    Text eventDescription;
    Text eventOption1;
    Text eventOption2;
    Text eventOption3;
    Text eventResolution;
    Text continueText;

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
        continueText = GameObject.Find("Continue").GetComponent<Text>();

        events = new List<GameEvent>();


        //tale of fried frogs
        EventOption event1Option1 = createOption(0, 10, 0, 0, 5, 5, 0, "[press 1] You send in 10 hunters with guns, followed by 5 women and 5 children to show your family situation. Some of the children hold frogs.");
        event1Option1.resolutions = new List<EventResolution>();
        event1Option1.resolutions.Add(createResolution(0, 10, 0, 0, 0, 0, 5, "The frog fixin dudes are impressed by your hunters outfits and your peaceful nature. They agree to join your party"));
        event1Option1.resolutions.Add(createResolution(0, -10, 0, 0, 0, 0, 0, "Your hunters look menacing as they approach and accidently cath the good natured frog cookers off guard. Both your hunters are shot and killed. The woman and child flee back for safety."));
        event1Option1.resolutions.Add(createResolution(0, -10, 0, 0, -5, -5, 0, "The frog food is so delicious, the woman and child decide to remain with the frog cookin' dudes. and settle in a nearby cave. The hunters also join to learn the art of giggin'"));

        EventOption event1Option2 = createOption(12, 0, 0, 0, 0, 0, 0, "[press 2] 4 of your cooks are interested in the delicious smells that hang in the air.");
        event1Option2.resolutions = new List<EventResolution>();
        event1Option2.resolutions.Add(createResolution(-12, 0, 0, 0, 0, 0, 0, "Upon reaching the frog cooking camp, your cooks realize they have sumbled into a trap from a delerious escaped cannibal! All your cooks are eaten with sides of fried frogs."));
        event1Option2.resolutions.Add(createResolution(6, 0, 0, 0, 0, 0, 0, "Your cooks meet their cooks, their cooks like your cooks, all the cooks spend a lot of time talking about different types of salts. the other cooks(6) join your cooks to cook."));
        event1Option2.resolutions.Add(createResolution(-6, 0, 0, 0, 0, 0, 0, "The campsite is abonded.. After eating and sampling some of the fried frogs, 6 of your cooks die immediatly from choking on the delicious legs."));

        EventOption event1Option3 = createOption(0, 2, 0, 0, 0, 0, 2, "[press 3] 2 of your mounted hunters are sent to investigate");
        event1Option3.resolutions = new List<EventResolution>();
        event1Option3.resolutions.Add(createResolution(2, 0, 0, 0, 0, 0, 0, "Two cooks hanging out by a fire share their feast with your hunters and are impressed by your upkeep of animals and health. they join you."));
        event1Option3.resolutions.Add(createResolution(0, 0, 0, 0, 0, 0, -2, "The cooks share their frogs with your hunters, they then become interested in your horses... very interested in them. Your hunters barely escape being eaten along with them."));
        event1Option3.resolutions.Add(createResolution(0, -2, 0, 0, 0, 0, -2, "The campsite is full of people who are VERY hungry. Your hunters and horses do not return."));

        AddEvent("The sun was blazing hot down the wagons. As sweat beaded of the hats of the hunters and soaked the armpits of children, a large smokey campfire could be seen in the distance. The smell of deliciously fried frogs hung in the air and the stomachs of the women began to growl with the horses.", 0, 0, 0, 0, 0, 0, 0, event1Option1, event1Option2, event1Option3);

        //water well
        EventOption event2Option1 = createOption(0, 0, 0, 2, 0, 0, 5, "[press 1] Without any warning, 5 horses go charging towards the well! 2 of the wranglers chase after them");
        event2Option1.resolutions = new List<EventResolution>();

        event2Option1.resolutions.Add(createResolution(0, 0, 0, 0, 0, 0, -5, "The horses charge up and chug the water, suddenly they all fall over the water is tainted!! This probably explains where there is nobody around in the town. The frog ribbits out a laugh. 5 horses don't make it."));

        event2Option1.resolutions.Add(createResolution(0, 0, 0, 0, 0, 12, 0, "The horses charge up and chug the water. Suddenly they yell out a loud and vibrant whiny of joy! the noise and commotion heard yonder causes several hiding children hesitantly approach from hiding. They explain that bandits attacked the town and they were told to hide until someone they thought they could trust would come by. 12 children join the wagon train!"));

        event2Option1.resolutions.Add(createResolution(-2, -3, -2, 0, 0, 0, 0, "The horses charge up and chug the water, They drink the trough dry! Upon discovery, the well is also dry. You decide to let the women and children drink first. 3 Hunters, 2 Cooks, and 2 gatherers perish from dehydration."));

        EventOption event2Option2 = createOption(0, 0, 5, 0, 0, 0, 0, "[press 2] You send 5 gatherers ahead of the train to handle any disorderly rush that might happen as everyone is thirsty and angry.They are thangry.");
        event2Option2.resolutions = new List<EventResolution>();
        event2Option2.resolutions.Add(createResolution(0, 0, 0, -3, -2, 0, -2, "As the gatherers start to head toward the fountain all other groups become unruly and fights begin breakout! The hunters shoot off several rounds during the scuffle. 3 wranglers, 2 women, and 2 horses do not survive the water rush. The frog ribbits out a laugh."));
        event2Option2.resolutions.Add(createResolution(0, 0, 0, 0, 0, 0, 0, "The gatherers secure the water source and provide water to everyone.For once nothing bad happens!The frog winks at you from the bucket."));
        event2Option2.resolutions.Add(createResolution(0, -2, 0, -2, -1, -2, 0, "The gatherers mis-identify the water as safe. 2 wranglers, 2 hunters, 1 woman, and 2 children perish from the tainted water."));

        EventOption event2Option3 = createOption(0, 0, 0, 0, 0, 0, 0, "[press 3] Send the women(3) and children(6) first so that they can be quenched before the men and animals.");
        event2Option3.resolutions = new List<EventResolution>();
        event2Option3.resolutions.Add(createResolution(0, 0, 0, 0, -3, -6, 0, "This is one of those times when sending the gatherers might have been a better idea. Tragically the water was tainted and the women and children became deathly ill. The men dig holes for the 3 women and 6 children."));
        event2Option3.resolutions.Add(createResolution(0, 0, 0, 0, -3, -6, 0, "At first, it seems everything is going perfectly until some doors begin to open around the town building nearby. One of the children looks up from the well as the frog jumps out of the bucket and down the water shaft. Limping slowly forward with a stagger on the other side of the well is something that is no longer recognizable as human. This is a ghoul town! The smell of death and decay is unbearable. The wagon train packs up at the sight of this horror and abandons anyone who was not ready to go. 3 women and 6 children were left to live (eternally as undead)."));
        event2Option3.resolutions.Add(createResolution(3, 3, 0, 2, 0, 0, 0, "The women and children drink the water, elated the begin to sing and cheer! The noise is heard throughout the town. A few townspeople who were hiding from what they perceived as banditos come to greet the wagon train. 3 cooks, 2 wranglers, and 3 hunters join!"));

        AddEvent("The entire wagon train is parched! Water is running dangerously low. Several oxen have all but given up, and the wranglers can barely keep them going. Over the next pass you spot a small town, as you enter the main street you do not hear any noise, and it is eerily quiet as nobody seems to be around. In the center of the town as you pass through you come upon a stone water well and old wooden trough. A giant fat frog sits halfway in the bucket used to gather water with a lazy look on his face.", 0, 0, 0, 0, 0, 0, 0, event2Option1, event2Option2, event2Option3);

        //I heard a herd
        EventOption event3Option1 = createOption(0, 0, 0, 2, 0, 0, 5, "[press 1] muster 15 of your best wranglers to head out and investigate the noises in the distance and retrieve any animals they can capture.");
        event3Option1.resolutions = new List<EventResolution>();

        event3Option1.resolutions.Add(createResolution(0, 0, 0, -15, 0, 0, 0, "All is quiet except the very low and distinct crunch of dry dirt under the boots of the animal wrangles. The wind whistles and in the distance horse whinnying can be heard as a beckoning call to any horseman who had the experience and wisdom to understand it. As the lantern light danced shadows around bush and brush while the men approached the noise. They discovered that in addition to a heard of wild horses, there was also a pack of wild wolves. The wrangles boots were quiet. (15 wrangles lost)"));

        event3Option1.resolutions.Add(createResolution(0,0,0,0,0,0,10, "The wranglers with their years of experience and horsemanship understood right away that there was trouble ahead. They quickly whistled \"the signal\" and the hunters arrived on horseback to assist in protecting the pack of horses besieged by wolves. (10 horses gained)"));

        event3Option1.resolutions.Add(createResolution(0, -2, 0, -10, -5, -5, 0, "As the wranglers make their way through the thick and rustling brush, they are ambushed on their way to the horses by a gang of bandits. Running back to the caravan the bandits can siege a wagon of women and children in addition to the wranglers that were injured. The wagon train quickly packed up and left. 5 women, 5 children, 2 hunters, and 10 wranglers are lost."));

        EventOption event3Option2 = createOption(0, 0, 0, 0, 0, 0, 0, "[press 2] pack up camp and start moving out away from where you believe the noises are coming from");
        event3Option2.resolutions = new List<EventResolution>();

        event3Option2.resolutions.Add(createResolution(0,0,0,0,0,0,0, "\"We have enough horses!\" seems to be the consensus among all significant parties of the wagon train. The wranglers suggest horses are not typically noisy creatures at night unless they are under attack or something is awry. Keen to the behavior of animals, your experienced wranglers save the group from a possible encounter with wolves."));

        EventOption event3Option3 = createOption(0, 0, 0, 0, 0, 0, 0, "[press 3] send 5 hunters and 5 wranglers to check out the noise and possibly defend the camp.");
        event3Option3.resolutions = new List<EventResolution>();

        event3Option3.resolutions.Add(createResolution(0, 0, 0, 0, 0, 0, 20, "The hunters guide the wranglers around behind the hillside. Off in the distance using the moonlight, the hunters can detect that there are wolves in the process of preying on the heard of wild horses. The wranglers and hunters work together to formulate a plan. Drawing several odd markings in the dirt with some sticks, the hunters will create a diversion using gunshots and scare the wolves and horses apart. The wranglers will position themselves in an area about 1.5 miles away from where the horses will eventually tire from running. (20 horses gained)"));

        event3Option3.resolutions.Add(createResolution(0, 0, 0, 0, 0, 0, 10, "The wranglers and hunters begin to approach the wild horses from the hillside. To everyone surprise, the horses are not under any visible threat. A massively large mustang appears to be challenging the herd leader! The wranglers quickly begin taking notes of what they are watching while the hunters start to clean their guns and find rocks and brush to lean on. After a short while, the challenge resolves, and the wranglers attempt to gather what stray horses they can. (10 horses gained)"));

        event3Option3.resolutions.Add(createResolution(0,-5,0,-5,0,0,0, "The wranglers approach the herd of wild horses, as they get closer and closer to quietly catch them the hunters notice something isn't quite right. The ground underneath their feet is wet and deep, and sandy. What is it, that ain't exactly earth, and it ain't exactly land? \"QUICKSAND\" (5 wranglers and 5 hunters are lost)"));

        AddEvent("The wagon train is stirred on a cold night as off in the distance the sound of stampeding animals grows louder and echoes off the nearby cliffs and mountains mixed with noises of frogs mating off in the distance. The smell of fear is in the air.", 0, 0, 0, 15, 0, 0, 0, event3Option1, event3Option2, event3Option3);

        //The Cattle Man
        EventOption event4Option1 = createOption(0, 0, 0, 5, 0, 0, 0, "[Press 1] send 5 wranglers to help round up the cattle");
        event4Option1.resolutions = new List<EventResolution>();
        event4Option1.resolutions.Add(createResolution(0, 0, 0, -5, 0, 0, 0, "Five wranglers in denim stand  Offering their helping hand  A smile and a nod, A look and a smack  The cattle ran em over and they ain't coming back"));

        EventOption event4Option2 = createOption(0, 0, 0, 10, 0, 0, 0, "[Press 2] send 10 wranglers to help round up the cattle");
        event4Option2.resolutions = new List<EventResolution>();
        event4Option2.resolutions.Add(createResolution(0, 0, 0, 0, 0, 0, 0, "Ten wranglers in denim stand  Offering their helping hand  A smile and a nod, A look and a Yell  These wrangler boys round'em up swell"));

        EventOption event4Option3 = createOption(0, 5, 0, 0, 0, 0, 0, "[Press 3] send 5 hunters to take the cattle from cattle man");
        event4Option3.resolutions = new List<EventResolution>();
        event4Option3.resolutions.Add(createResolution(0, -5, 0, 0, 0, 0, 0, "Five hunters lock and load  All's fair on the open road  Taking aim, ready to fire  Cattle ran em over like a big truck tire"));

        AddEvent("Gather round the fire now and hear what I've to say  It was a cold crisp Ludum Dare and the sky's was grey  Ol' man TigerJ fiddled with his code  Tryin ta squash bugs and add an extra toad  The cattle man his newest  re a noble NPC  Led lots of steer around the land for all us to see  He needed a wrangler man or 3, or 5, or 10  Before the wicked railways come an' ruin all the lan'", 0, 5, 0, 10, 0, 0, 0, event4Option1, event4Option2, event4Option3);

        //The Giant Frogs of Tucker Hill
        EventOption event5Option1 = createOption(0, 20, 0, 0, 0, 0, 0, "[press 1] Send all the hunters to start shooting!");
        event5Option1.resolutions = new List<EventResolution>();
        event5Option1.resolutions.Add(createResolution(0, -10, 0, 0, 0, 0, 0, "About 20 hunters go in, about 10 come out."));
        event5Option1.resolutions.Add(createResolution(0, 0, 0, 0, -5, -5, 0, "Your hunters look at the giant beast and run back towards cover. From afar they manage to fire enough rounds to take the beast out! 5 women and 5 children were not fast enough to get out."));

        EventOption event5Option2 = createOption(0,0,0,5,0,0,0, "[press 2] Send the wranglers to catch and tame the giant frogs!");
        event5Option2.resolutions = new List<EventResolution>();
        event5Option2.resolutions.Add(createResolution(0, 0, 0, 0, -5, -10, 0, "The wranglers laugh at this idea, the hunters go in and put the frogs down. 5 women and 10 children get snacked on."));
        event5Option2.resolutions.Add(createResolution(0, 0, 0, -5, 0, 0, 0, "The wranglers rush in! They manage to capture one of the frogs and name it Eric Von BattleFrog. 5 wranglers lives are worth one frog in a bush."));

        EventOption event5Option3 = createOption(10, 0, 0, 0, 0, 0, 0, "[press 3] Send the cooks! we're eating frogs tonight!");
        event5Option3.resolutions = new List<EventResolution>();
        event5Option3.resolutions.Add(createResolution(0, 0, 0, 0, 0, 0, 0, "The cooks are able to trick and lure the giant frog into a giant pot, The wagon train has a giant feast."));
        event5Option3.resolutions.Add(createResolution(-10, 0, 0, 0, 0, 0, 0, "The cooks look at the giant frog and start to run away, the frog, however, looks at them and decides to have a meal. (10 cooks are lost)"));
        AddEvent("A loud crash reverberates across the trail, looking back you see a wagon has been upended! Screams emanate from men, women, and children who are scattering like ants from a freshly kicked hill. From up over the now top of a wagon (what was once the side) a GIANT frog head peers over. Faster than you can blink it's ropelike tongue fires faster than a musket and wraps a small child for a snack. Like a bungee jumper who has just reached the end of their line, the child snaps back into the frog's mouth in one big gulp!", 10, 20, 0, 5, 0, 0, 0, event5Option1, event5Option2, event5Option3);

        //Frohdaggo
        EventOption event6Option1 = createOption(0, 0, 0, 10, 0, 0, 0, "[press 1] send 10 of the best wranglers to go win some gold!");
        event6Option1.resolutions = new List<EventResolution>();
        event6Option1.resolutions.Add(createResolution(0, 0, 0, 10, 0, 0, 0, "The gunshot kicks off the race! The wranglers are living up to their claims and experience. Hopping, flipping, flying, farting, driving, bouncing, and leaping down the canyon they go!  After the apparently easy victory other wranglers ask where they can sign up (they don't get any of the winnings though)(10 wranglers join)"));
        event6Option1.resolutions.Add(createResolution(0,0,0,0,10,10,0,"You thought they were the best.. The race starts but your frogs don't even move! The wranglers might be great with oxen but they are terrible with giant frogs. After the total failure of a race, you read the fine print of the contract, You can have your wranglers back but 10 of your women and children are now the property of Frohdaggo Entertainment. (10 women and 10 children are no longer with the party)"));

        EventOption event6Option2 = createOption(0, 0, 0, 0, 0, 0, 0, "[press 2] politely decline and start a path around the frog fair");
        event6Option2.resolutions = new List<EventResolution>();
        event6Option2.resolutions.Add(createResolution(-5,0,0,0,0,-5,0, "You try to steer around the hustle and bustle, you cannot prevent everyone from stopping to take a look, some of your wagon train decides to run away and join the Frohdaggo Circus! (5 cooks and 5 children do not return)"));
        event6Option2.resolutions.Add(createResolution(0, 0, 0, 0, 0, 0, 0, "\"More frogs more problems\" you proclaim aloud as you successfully steer the lead around the hubbub. (no loses or gains)"));

        EventOption event6Option3 = createOption(0, 0, 0, 0, 0, 0, 0, "[press 3] pass off some of the gatherers as wranglers, they might win and who really needs them anyway?");
        event6Option3.resolutions = new List<EventResolution>();
        event6Option3.resolutions.Add(createResolution(0, 0, -10, 10, 0, 0, 0, "To everyone's jaw-dropping amazement, the gatherers are natural frog wranglers! who knew? Afterward, you decide these people are better as wranglers than picking nuts and berries. Sometimes you just need to give someone a chance! (lose 10 gatherers, gain 10 wranglers)"));

        AddEvent("As you round the bend on one of the many precarious cliffsides the trail opens up to a plateau. Across the opening is sprawled a tent city that appears to have popped up overnight. Your wagon train is greeted with praise as you arrive and experience greetings from people that you are unable to recognize. After some discussions with various plateau folk, you find out that they are racing giant ridable frogs down the canyon!  They implore you to offer up some wranglers and impress them in their frog rodeo, the prize money is enough for every family in the wagon train to have no worries when they settle in out west!", 5, 0, 0, 10, 0, 5, 0, event6Option1, event6Option2, event6Option3);

        //Fickle Food
        EventOption event7Option1 = createOption(0, 5, 5, 0, 0, 0, 0, "[press 1] send 5 gatherers and 5 hunters out yonder over the hill to see if there is any ranging beasts or vegetation to collect and bring back to camp.");
        event7Option1.resolutions = new List<EventResolution>();
        event7Option1.resolutions.Add(createResolution(0, -10, -5, 0, 0, 0, -5, "They leave the camp and head over the hill to collect food. There are no noises and no sign of them after an hour. 5 more hunters on horseback go to search for them. Nobody returns back to camp. (10 hunters, 5 gatherers, 5 horses are all lost)"));
        event7Option1.resolutions.Add(createResolution(10, 10, 10, 10, 10, 10, 10, "You dispatch 5 gatherers and 5 hunters, surprisingly they run into another group of campers who decide to join you! (gain 10 of everything!)"));

        EventOption event7Option2 = createOption(0, 5, 5, 0, 0, 0, 0, "[press 2] send 10 gatherers to the woods to forage for food and scout for the hunters.");
        event7Option2.resolutions = new List<EventResolution>();
        event7Option2.resolutions.Add(createResolution(0, 0, 0, 0, 0, 0, 0, "The woods are dark and mysterious. After hours of waiting you decide to dispatch a search party of mounted hunters to traverse the forest and search for your missing gathering group. As the hunters near the edge of the forest to make way inside they meet up with all 10 gatherers whos hands are full and who have obtained overwhelming amounts of food! You gain no extra party members and a lot of weight."));
        event7Option2.resolutions.Add(createResolution(0, 0, -5, 0, 0, 0, 0, "The gatherers get further and further into the thick dense foliage of the forest. eventually, they begin to lose track of each other! half of them never find their way back to camp, the ones that do not return empty-handed. (lose 5 gatherers)"));

        EventOption event7Option3 = createOption(0, 5, 5, 0, 0, 0, 0, "[press 3] send 5 gatherers and 5 cooks to pick out food for the best meal when the party reaches its final stop on the west coast.");
        event7Option3.resolutions = new List<EventResolution>();
        event7Option3.resolutions.Add(createResolution(0, 5, 0, 5, 5, 5, 0, "The gatherers know what is edible, the cooks know what is delicious. They are met with great success and find many rare ingredients and exotic spices to use in a delicious feast. While cooking up a test batch some wondering nomads cannot resist the smell and join your party! (gain 5 hunters, 5 wranglers, 5 women, and 5 children)"));

        AddEvent("The sun begins to set as you reach a good clearing to set up camp. After a while, some of your gatherers and hunters decide it might be a good idea to collect some rations and supplies from the nearby wilderness.", 0, 0, 0, 0, 0, 0, 0, event7Option1, event7Option2, event7Option3);

        //The Frisco Frog
        EventOption event8Option1 = createOption(0, 0, 0, 0, 0, 0, 0, "[press 1] Let him join");
        event8Option1.resolutions = new List<EventResolution>();
        event8Option1.resolutions.Add(createResolution(-5, -5, -5, -5, -5, -5, -5, "It seems that ever since he joins the wagon train there has been bad luck around every turn, but at least you are helping him out! (lose 5 of everything)"));

        EventOption event8Option2 = createOption(0, 0, 0, 0, 0, 0, 0, "[press 2] Pass");
        event8Option2.resolutions = new List<EventResolution>();
        event8Option2.resolutions.Add(createResolution(0, 1, 0, 0, 0, 0, 1, "After leaving him to chasing his frogs you come across a cowboy who looks like he might someday pilot the millennium falcon. He joins your group. The ladies swoon. (1 hunter and 1 horse join)"));

        EventOption event8Option3 = createOption(0, 0, 0, 0, 0, 0, 0, "[press 3] Help him catch the frog before you leave");
        event8Option3.resolutions = new List<EventResolution>();
        event8Option3.resolutions.Add(createResolution(0, 0, 0, 0, 0, 0, 0, "He thanks and blesses you"));

        AddEvent("Frog, Frog, Frog! Ribbet-ribbet-ribbet-frog! Come here Come here, wait! I don't want to hurt you! I just want to make you kosher!  You come across an odd man in an odd coat with a long beard who looks like he might also someday run a chocolate shop.After some conversations you find out is also headed out west!", 0, 0, 0, 0, 0, 0, 0, event8Option1, event8Option2, event8Option3);
    }

    // Update is called once per frame
    void Update () {
        if (eventing == true && evented==false)
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
        else if(eventing == true && evented == true)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                continueText.text = "";
                eventing = false;
                evented = false;
                hideEvent();
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

        evented = true;
        continueText.text = "click anwhere to continue";
    }
    public void updateStat(int amount, string stat)
    {
        switch (stat)
        {
            case "cooks":
                cooks = cooks + amount;
                cooksText.text = pad3(cooks);
                cooksChange.startStatChange(amount, "cooks");
                
                break;
            case "hunters":
                hunters = hunters + amount;
                huntersText.text = pad3(hunters);
                huntersChange.startStatChange(amount, "hunters");
                
                break;
            case "gatherers":
                gatherers = gatherers + amount;
                gatherersText.text = pad3(gatherers);
                gatherersChange.startStatChange(amount, "gatherers");
                
                break;
            case "wranglers":
                wranglers = wranglers + amount;
                wranglersText.text = pad3(wranglers);
                wranglersChange.startStatChange(amount, "wranglers");
                
                break;
            case "women":
                women = women + amount;
                womenText.text = pad3(women);
                womenChange.startStatChange(amount, "women");
                
                break;
            case "children":
                children = children + amount;
                childrenText.text = pad3(children);
                childrenChange.startStatChange(amount, "children");
                
                break;
            case "horses":
                horses = horses + amount;
                horsesText.text = pad3(horses);
                horsesChange.startStatChange(amount, "horses");

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
        possibleEvents = events.FindAll(gameEvent => gameEvent.mincooks <= cooks && gameEvent.minhunters <= hunters && gameEvent.mingatherers <= gatherers && gameEvent.minwranglers <= wranglers && gameEvent.minwomen <= women && gameEvent.minchildren <= children && gameEvent.minhorses <= horses && gameEvent != randomEvent);
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
