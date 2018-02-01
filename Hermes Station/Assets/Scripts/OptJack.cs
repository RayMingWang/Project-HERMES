using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptJack : Jack {
	public Animator left;
	public Animator right;
	private ClinetJack targetClient;
	private ClinetJack lockedtargetClient;
	private bool inContectClient = false;

	void OnTriggerEnter2D(Collider2D other){

		targetPort = other.GetComponent<Port> ();
		if (targetPort != null)
			inContect = true;
		else {
			targetClient = other.GetComponent<ClinetJack>();
			if (targetClient != null) {
				if (targetClient.connectPort != -1) {
					inContectClient = true;
				}
			}
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
				if (inContectClient) {
					state = 2;
					rb.bodyType = RigidbodyType2D.Kinematic;
					tip_renderer.enabled = false;
					rb.transform.position = new Vector3 (+0.53f, +0.58f,0f) + targetClient.transform.position;
					rb.transform.rotation = new Quaternion ();
					lockedPosition = targetClient.transform.position+new Vector3 (-0.6f, -0.6f,0f);
					connectPort = targetClient. connectPort;
					ConnectedtoPort ();
				} else {
					tip_renderer.enabled = true;
					state = 0;
					clid.isTrigger = false;
					rb.bodyType = RigidbodyType2D.Dynamic;
				}

			}

			break;
		case 2:
			break;
		default:
			break;

		}
	}


	public override void ConnectedtoPort(){
		manager.recieveConnection (-1, connectPort);
	}

	public override void DisConnectedtoPort(){
		inContectClient = false;
		manager.recieveDisconnection (-1, connectPort);
	}
}
