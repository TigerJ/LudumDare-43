using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventOption : ScriptableObject {

    public int cooks;
    public int hunters;
    public int gatherers;
    public int wranglers;
    public int women;
    public int children;
    public int horses;

    public string OptionText;
    public List<EventResolution> resolutions;

}
