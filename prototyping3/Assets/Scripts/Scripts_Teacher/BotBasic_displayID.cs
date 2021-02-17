using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotBasic_displayID : MonoBehaviour{
	private bool isPlayer1;
	private Transform cam;
	public Transform playerLabel;
	public GameObject imageP1;
	public GameObject imageP2;
	
    void Start()
    {
		isPlayer1 = gameObject.transform.root.GetComponent<playerParent>().isPlayer1;
		
        if (isPlayer1 == true){
			cam = GameObject.FindWithTag("camP1").transform;
			imageP1.SetActive(true);
			imageP2.SetActive(false);
			playerLabel = imageP1.transform;
		}   else{
			cam = GameObject.FindWithTag("camP2").transform;
			imageP1.SetActive(false);
			imageP2.SetActive(true);
			playerLabel = imageP2.transform;
		}
    }
	
	void Update(){
		playerLabel.LookAt(cam);	
	}	
}
