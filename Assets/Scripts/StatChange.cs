using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatChange : MonoBehaviour {
    public float displayTimer;
    public Color positive;
    public Color negative;
    public Color defaultColor;
    Vector3 startPos;
    
	// Use this for initialization
	void Start () {
        startPos = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		if(displayTimer > 0)
        {
            transform.position = new Vector3(transform.position.x - .5f, transform.position.y, transform.position.z);
            displayTimer = displayTimer - Time.deltaTime;
        }
        else
        {
            if (gameObject.GetComponent<Text>().color != defaultColor) gameObject.GetComponent<Text>().color = defaultColor;
            if (gameObject.transform.position != startPos) gameObject.transform.position = startPos;
        }
	}
    public void startStatChange(int amount, string statname)
    {
        if (amount > 0)
        {
            gameObject.GetComponent<Text>().text = amount.ToString() + " " + statname;
            gameObject.GetComponent<Text>().color = positive;
            
        }
        if (amount < 0)
        {
            gameObject.GetComponent<Text>().text = amount.ToString() + " " + statname;
            gameObject.GetComponent<Text>().color = negative;
            
        }
        displayTimer = 2f;
    }
}
