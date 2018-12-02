using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class End : MonoBehaviour {

    bool end;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (end)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene("main");
            }
        }
	}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        end = true;
        GameController gameController = GameObject.Find("GameController").GetComponent<GameController>();
        GameObject.Find("Score").GetComponent<Text>().text = (gameController.cooks + gameController.hunters + gameController.gatherers + gameController.wranglers + gameController.women + gameController.children + gameController.horses).ToString("d5");
        GameObject.Find("EndStuff").GetComponent<CanvasGroup>().alpha = 1;
    }
}
