using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jack : MonoBehaviour {
	public int state =0;
	// 0: Regualer phyisics
	// 1: Drag
	// 2: Nail
	public Rigidbody2D rb;
	public PolygonCollider2D clid;
	public Port targetPort;
	public Vector3 lockedPosition;
	public bool inContect= false;

	public SpriteRenderer tip_renderer;
	public PortManager manager;
	public int connectPort = -1;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
		clid = GetComponent<PolygonCollider2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		switch (state) {
		case 0:
			break;
		case 1:
			rb.transform.rotation = new Quaternion ();
			break;
		case 2:
			//rb.transform.position = new Vector3 (-0.03f, -0.08f,0f) + targetPort.transform.position;
			rb.transform.position = new Vector3 (-0.03f, -0.08f,0f) + lockedPosition;
			rb.transform.rotation = new Quaternion ();
			rb.bodyType = RigidbodyType2D.Static;
			break;
		default:
			break;

		}
	}

	void OnMouseDown(){
		
		switch (state) {
		case 0:
			state = 1;
			tip_renderer.enabled = true;
			clid.isTrigger = true;

			rb.bodyType = RigidbodyType2D.Kinematic;
			break;
		case 1:
			break;
		case 2:
			DisConnectedtoPort ();
			tip_renderer.enabled = true;
			state = 1;
			clid.isTrigger = true;
			rb.transform.rotation = new Quaternion ();
			connectPort = -1;
			inContect=false;



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
			if (inContect) {
				state = 2;
				rb.bodyType = RigidbodyType2D.Kinematic;
				tip_renderer.enabled = false;
				rb.transform.position = new Vector3 (-0.03f, -0.08f,0f) + targetPort.transform.position;
				rb.transform.rotation = new Quaternion ();
				lockedPosition = targetPort.transform.position;
				connectPort = targetPort.portid;
				ConnectedtoPort ();
			}
				
			else {
				tip_renderer.enabled = true;
				state = 0;
				clid.isTrigger = false;
				rb.bodyType = RigidbodyType2D.Dynamic;
			}

			break;
		case 2:
			break;
		default:
			break;

		}
	}

	void OnTriggerEnter2D(Collider2D other){
		
		targetPort = other.GetComponent<Port> ();
		if (targetPort != null)
			inContect = true;
		else {
			inContect = false;
		}
			
	}

	void OnTriggerExit2D(Collider2D other){
		inContect = false;	
	}



	void FixedUpdate(){
		switch (state) {
		case 0:
			
			break;
		case 1:
			Vector2 pos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
			rb.MovePosition (pos);
			rb.transform.rotation = new Quaternion ();

			break;
		case 2:
			
			break;
		default:
			break;
			
		}
	}
	public virtual void ConnectedtoPort(){
		Debug.Log (123);
	}

	public virtual void DisConnectedtoPort(){
		Debug.Log (456);
	}
}
