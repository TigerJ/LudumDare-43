using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathSpawner : MonoBehaviour {
    public List<GameObject> tombStones;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void SpawnDeath(int type, int qty)
    {
        for(int i = 0; i <= qty; i++)
        {
            Instantiate(tombStones[type], transform.position, transform.rotation);
        }
    }
}
