using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bulb : MonoBehaviour {

	private Animator anim;
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();

	}

	public void turnOff(){
		anim.SetBool ("isOn",false);

	}

	public void turnOn(){
		anim.SetBool ("isOn",true);

	}

	// Update is called once per frame
	void Update () {
		
	}
}
