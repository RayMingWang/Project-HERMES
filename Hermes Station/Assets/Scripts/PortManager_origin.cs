using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortManager_origin : MonoBehaviour {
	public Port[] portlist;
	public DialougeUnit left;
	public DialougeUnit right;
	public int stage=0;
	private int[] client_01= new int[] {-1,-1};
	private int[] client_02= new int[]{-1,-1};
	private ArrayList dialoguelist = new ArrayList();
	//private bool indialouge=false;
	private Animator left_anim;
	private Animator right_anim;
	private bool showDialogue = false;
	private int showPort =-2;

//	int index_01 = 0;
//	int index_02 = 0;
//	int index_order = 0;
	DialogueSet currentDialougueset;
	// Use this for initialization
	void Start () {
		DialogueSet newdialogue = new DialogueSet ();
		newdialogue.setParticipants (-1, 8);
		newdialogue.name_02 = "Johnny";
		newdialogue.addLine02 ("Oh, hi, Mark");
		newdialogue.addLine02 ("Call Danny in port 1 please");
		newdialogue.order = new int[]{ 2, 2 };
		newdialogue.stage = 0;
		newdialogue.ResetConversation ();
		dialoguelist.Add (newdialogue);


		//must have leave it be
		newdialogue = new DialogueSet ();
		//which port is goint to talk
		newdialogue.setParticipants (1, 8);
		//The name
		newdialogue.name_01 = "Danny";
		newdialogue.name_02 = "Johnny";
		//add line, order must be mantianed
		newdialogue.addLine02 ("Oh,hi doggy");
		newdialogue.addLine01 ("Am I a beautyful human being?");
		newdialogue.addLine02("I am lucky.");
		newdialogue.addLine02("Lisa hates you.");
		newdialogue.addLine01("You are a vampaire");
		//order of participants
		newdialogue.order = new int[]{2,1,2,2,1};
		//when do you want the dialouge be avilable
		newdialogue.stage = 2;
		//must have leave it be
		newdialogue.ResetConversation ();
		dialoguelist.Add (newdialogue);
	}

	public void recieveConnection(int client,int portid){
		if (portid <= -1)
			return;
		Debug.Log ("connect"+ portid);
		portlist [portid].colid.enabled = false;
		if (client == -1) {
			CheckLine (-1, portid);
			showDialogue = true;
			showPort = portid;
		}
		if (client == 1) {
			if (client_01 [0] == -1)
				client_01 [0] = portid;
			else
				client_01 [1] = portid;
			if (client_01 [0] >= 0 && client_01 [1] >= 0) {
				CheckLine (client_01 [0],client_01 [1]);

			}	
		}
		if (client == 2) {
			if (client_02 [0] == -1)
				client_02 [0] = portid;
			else
				client_02 [1] = portid;
			if (client_02 [0] >= 0 && client_02 [1] >= 0) {
				CheckLine (client_02 [0],client_02 [1]);

			}	
		}
	}

	public void recieveDisconnection(int client,int portid){
		if (portid == -1) {
			Debug.Log ("-1bug");
			return;
		}
		Debug.Log ("disconnect"+portid);
		portlist [portid].colid.enabled = true;
		if (client == -1) {
			CheckActiveLine (-1, portid);
			showDialogue = false;
			showPort = -2;
			right_anim = right.GetComponent<Animator> ();
			right_anim.SetBool ("isOpen", false);
			left_anim = left.GetComponent<Animator> ();
			left_anim.SetBool ("isOpen", false);
		}
			
		if (client == 1) {
			CheckActiveLine (client_01 [0],client_01 [1]);
			if (client_01 [0] == portid)
				client_01 [0] = -1;
			else
				client_01 [1] = -1;
		}

		if (client == 2) {
			CheckActiveLine (client_02 [0],client_02 [1]);
			if (client_02 [0] == portid)
				client_02 [0] = -1;
			else
				client_02 [1] = -1;
		}
	}

	public void CheckActiveLine(int a, int b){
		DialogueSet target;
		for (int i = 0; i < dialoguelist.Count; i++) {
			target = (DialogueSet)dialoguelist [i];
			target.ResetConversation (a, b);
		}
	}

	public void CheckLine(int a, int b){
		DialogueSet target;
		for (int i = 0; i < dialoguelist.Count; i++) {
			target = (DialogueSet)dialoguelist [i];
			target.checkAvailability (a, b,stage);/*
			if(target.checkAvailability (a, b,stage);){
				showDialogue = true;
				showPort = a;
			}
		*/
		}
//		DialogueSet target;
//		for (int i = 0; i < dialoguelist.Count; i++)
//		{
//			target = (DialogueSet)dialoguelist[i];
//			target.checkAvailability (a, b, stage);
//				left.updateName(target.name_01);
//				right.updateName(target.name_02);
//				indialouge = true;
//				index_01 = 0;
//				index_02 = 0;
//				index_order = 0;
//				currentDialougueset = target;
//				left.updateDialouge ("");
//				right.updateDialouge ("");
//				left_anim=left.GetComponent<Animator>();
//				if (target.name_01.Equals ("no")) {
//					Debug.Log ("This is the one");
//
//				} else {
//					left_anim.SetBool ("isOpen", true);
//				}
//				right_anim =right.GetComponent<Animator>();
//				right_anim.SetBool ("isOpen", true);
//				return;
//			}
//		} 
	}

	void Update() {
		if (Input.GetKeyDown ("space")) {

			DialogueSet target;
			for (int i = 0; i < dialoguelist.Count; i++) {
				target = (DialogueSet)dialoguelist [i];
				//
				//
				//
				//target.forwardConversation (stage);
				if (showDialogue) {
					if (target.state == 0)
						continue;
					if (target.isReachable (showPort)) {
						if (target.currentside == 1) {
							left_anim = left.GetComponent<Animator> ();
							left_anim.SetBool ("isOpen", true);
							left.updateName (target.currentName);
							left.updateDialouge (target.currentCoversation);


						} else if(target.currentside == 2){
							right_anim = right.GetComponent<Animator> ();
							right_anim.SetBool ("isOpen", true);
							right.updateName (target.currentName);
							right.updateDialouge (target.currentCoversation);
						}else if(target.state==2){
							right_anim = right.GetComponent<Animator> ();
							right_anim.SetBool ("isOpen", false);
							left_anim = left.GetComponent<Animator> ();
							left_anim.SetBool ("isOpen", false);
							target.state = 3;
						}

					}
				}
			}

			stage++;
		}

	}
}
