using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialougeUnit : MonoBehaviour {
	public GameObject name;
	public GameObject dialouge;
	private Sprite[] TextBox;

	private Text name_text;
	private Text dialouge_text;
	// Use this for initialization
	void Start () {
		TextBox = Resources.LoadAll <Sprite> ("dialougebox");

		name_text = name.GetComponent<Text> ();
		dialouge_text = dialouge.GetComponent<Text> ();

	}
	public void updateName(string name_string){
		name_text.text = name_string;
		int imageindex = 0;
		switch (name_string) {
		case "Blair": 
			GetComponent<Image>().sprite = TextBox [0];
			break;
		case "Socket": 
			GetComponent<Image>().sprite = TextBox [1];
			break;
		case "Detective": 
			GetComponent<Image> ().sprite = TextBox [2];
			break;
		case "Molli": 
			GetComponent<Image>().sprite = TextBox [3];
			break;
		case "Prawn": 
			GetComponent<Image>().sprite = TextBox [4];
			break;
		case "Loop": 
			GetComponent<Image>().sprite = TextBox [5];
			break;
		case "Voxel": 
			GetComponent<Image>().sprite = TextBox [6];
			break;
		case "Nova": 
			GetComponent<Image>().sprite = TextBox [7];
			break;
		
		}
	}

	public void updateDialouge(string dialouge_string){
		dialouge_text.text = dialouge_string;
	}
	// Update is called once per frame
	void Update () {
		
	}
}
