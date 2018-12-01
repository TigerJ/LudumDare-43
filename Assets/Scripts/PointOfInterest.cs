using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointOfInterest : MonoBehaviour {
    Player player;
    GameController gameController;
    private void Start()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
        gameController = GameObject.Find("GameController").GetComponent<GameController>();
    }
    private void OnMouseDown()
    {
        if(transform.position.x < player.transform.position.x -1f && gameController.eventing == false)
        {
            gameController.hideEvent();
            player.setTarget(gameObject);

        }
    }
}
