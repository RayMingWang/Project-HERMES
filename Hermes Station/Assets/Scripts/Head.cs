using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Head : MonoBehaviour {

    // Use this for initialization
    public int knot_count = 7;
    public float thrust=1;
    public float clamp = 3.5f;
	//wiretype 0: Opertor line
	//wiretype 1: Normal line
	public int wiretype= 0 ;
    private Rigidbody2D rb;
	//state 0: Hook to dock;
	//state 1: moving
	//state 2: Not hoding
	//state 3: Freeze to a port
	//state 
	public int state=0;
	public Vector3 dockingPosition;
	public Vector3 connectPortPosition;

	public void FreezeHead(){
		state = 3;
		//SpriteRenderer renderer = GetComponent<SpriteRenderer> ();
		//renderer.enabled = false;
	}



    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    
    void OnMouseDrag()
    {
        //Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //transform.position = (pos);
    }
    
	void OnMouseDown(){
		switch (state) {
		case 0:
			state = 1;	
			break;
		case 1:
			break;
		case 2:
			state = 1;	
			break;
		case 3:
			state = 1;
			break;
		default:
			break;
		}
	}

	void OnMouseUp(){
		
		switch (state) {
		case 0:
			
			break;
		case 1:
			GameObject dock = GameObject.Find ("OperaterJackDock");
			Vector3 distance = transform.position - dock.transform.position;
			if (distance.magnitude < 1)
				state = 0;
			else
				state = 2;
			break;
		case 2:
			break;
		default:
			break;
		}
	}


    // Update is called once per frame
    void Update () {
		switch (state) {
		case 0:
			transform.position = dockingPosition;
			transform.rotation = Quaternion.Euler (0, 0, 0);
			break;
		case 3:
			transform.position = connectPortPosition ;
			transform.rotation = Quaternion.Euler(0, 0, 0);
			break;
		case 1:
			Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			Vector3 direction = (new Vector3(pos.x, pos.y, 0) - transform.parent.position);
			//Debug.Log(direction.magnitude);
			if (direction.magnitude < clamp)
				transform.position = (pos);
			else
			{


				transform.position = transform.parent.position + Vector3.ClampMagnitude(direction, clamp);
				//Debug.Log(transform.localPosition.magnitude);
			}
			transform.rotation = Quaternion.Euler(0, 0, 0);
			break;
		case 2:
			break;
		default:
			break;
		}

        
    }

    void FixedUpdate()
    {
		if(state!=2)
        	rb.AddForce(new Vector2(0,1) * thrust);
        
    }
}
