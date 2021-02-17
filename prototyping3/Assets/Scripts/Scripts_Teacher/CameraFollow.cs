using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
	public Transform playerObj;
	public bool isPlayer1;
	public Vector3 offsetCamera;

	void Start(){

		if (isPlayer1 == true){
			if (GameObject.FindGameObjectWithTag ("Player1").transform.GetChild(0) != null) {
				playerObj = GameObject.FindGameObjectWithTag ("Player1").transform.GetChild(0);
			}
		} else {
			if (GameObject.FindGameObjectWithTag ("Player2").transform.GetChild(0) != null) {
				playerObj = GameObject.FindGameObjectWithTag ("Player2").transform.GetChild(0);
			}
		}
	}

	void FixedUpdate () {
		Vector3 pos = Vector3.Lerp ((Vector3)transform.position, (Vector3)playerObj.position + offsetCamera, Time.fixedDeltaTime * 5);
		//transform.position = new Vector3 (pos.x, pos.y, transform.position.y);
		transform.position = new Vector3 (pos.x, pos.y, pos.z);
		transform.LookAt(playerObj);
	}

}

