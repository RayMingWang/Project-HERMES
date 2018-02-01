using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueSet : MonoBehaviour {
	public int participants_01;
	public int participants_02;
	public string name_01="This guy don't exisit";
	public string name_02="This guy don't exisit";
	public string[] MultiString_01=new string[100];
	public string[] MultiString_02=new string[100];

	public int currentside=0;
	public string currentName="";
	public string currentCoversation="";

	public int[] order;
	public int stage;
	public int state;
	//00 not active
	//01 on going
	//02 End
	private int index_01=0;
	private int index_02=0;
	private int index_order = 0;



	//state 00: Not avilable yet;
	//state 01: Avilable;
	// Use this for initialization
	public void setParticipants(int first, int second){
		participants_01 = first;
		participants_02 = second;
	}

	public void addLine01(string newline){
		MultiString_01 [index_01] = newline;
		index_01++;
	}
	public void addLine02(string newline){
		MultiString_02 [index_02] = newline;
		index_02++;
	}

	public bool checkAvailability(int a,int b,int currentstage){
		if (state == 2||state ==1 )
			return false;
		
		if (a == -1) {
			name_01="no";

		}
		if (stage <=currentstage) {
			if (a == participants_01 && b == participants_02) {
				state = 1;
				return true;
			}
			if (b == participants_01 && a == participants_02) {
				state = 1;
				return true;
			}
		}
		return false;
	}

	public bool forwardConversation(int currentsatge){
		if (state == 1) {
			if (index_order == order.Length) {
				currentside = -1;
				state = 2;
				return false;
			}

			if (order [index_order] == 1) {
				currentside = 1;
				currentName = name_01;
				currentCoversation = MultiString_01 [index_01];
				index_order++;
				index_01++;
				return false;
			}else if (order [index_order] == 2) {
				currentside = 2;
				currentName = name_02;
				currentCoversation = MultiString_02 [index_02];
				index_order++;
				index_02++;
				return false;
			}
		}
		if (state == 0&&stage<=currentsatge) {
			return true;
		}
		return false;
	}

	public void ResetConversation(int a,int b){
		if (state != 1)
			return;
		if (a == participants_01 && b == participants_02) {
			state = 0;
			index_order=0;
			index_01=0;
			index_02=0;

		}
		if (b == participants_01 && a == participants_02) {
			state = 0;
			index_order=0;
			index_01=0;
			index_02=0;
		} 
	}

	public void ResetConversation(){

			state = 0;
			index_order=0;
			index_01=0;
			index_02=0;

		

	}

	public bool isReachable(int port){
		if (port == participants_01 || port == participants_02)
			return true;
		else
			return false;
		
	}





}
