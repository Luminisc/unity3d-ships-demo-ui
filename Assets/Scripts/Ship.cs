using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour {
    public Stats stats;
    public Sprite icon;
	// Use this for initialization
	void Start () {
        stats = gameObject.GetComponent<Stats>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
