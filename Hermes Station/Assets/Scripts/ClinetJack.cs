using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClinetJack : Jack {
	public int client_num;
	public override void ConnectedtoPort(){
		manager.recieveConnection (client_num, connectPort);
	}

	public override void DisConnectedtoPort(){
		manager.recieveDisconnection (client_num, connectPort);
	}
}
