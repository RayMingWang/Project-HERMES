using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Port : MonoBehaviour {
	public Bulb bulb;
	private bool bulb_switch= false;
	public int portid=0;
	public int state=0;
	public CircleCollider2D colid;

	public void bulbOn(){
		bulb.turnOn ();
	}

	public void bulbOff(){
		bulb.turnOff ();
	}


    void Start () {
		colid = GetComponent<CircleCollider2D> ();

	}
	
	void Update() {
		
	}
}
