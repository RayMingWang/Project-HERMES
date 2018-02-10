using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WhataStory : MonoBehaviour {

	public void tellastory()
    {
        GetComponent<Text>().text = "haha, what a story, mark";
        Debug.Log("haha, what a story, mark");
    }
}
