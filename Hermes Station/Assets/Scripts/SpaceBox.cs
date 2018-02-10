using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceBox : MonoBehaviour {
    public float background_speed = 0.1f;
    public float star_speed = 0.2f;
    public Transform star_transform;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.eulerAngles += new Vector3(0,0,background_speed*Time.deltaTime);
        star_transform.eulerAngles += new Vector3(0, 0, star_speed * Time.deltaTime);
	}
}
