using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class heavytank_move : MonoBehaviour {
	GameObject clickedGameObject;
	public int sign = 0;
	public int movesign = 1;
	public int turn = 0;
	Vector3 before = new Vector3 (0f,0f,0f);
	Vector3 now2 = new Vector3 (0f,0f,0f);
	Vector3 now = new Vector3 (0f,0f,0f);
	float resultX = 0;
	float resultZ = 0;
	float resultbeforeZ = 0;
	float resultnowZ = 0;
	float mainbeforeX = 0;
	float mainnowX = 0;
	float mainbeforeZ = 0;
	float mainnowZ = 0;
	//Vector3 playerpos = new Vector3 (0f,0f,0f);
	GameObject moverule;
	GameObject TurnChanger;
	GameObject cameras;
	//Vector3 mainbefore = new Vector3(0f,0f,0f);
	//Vector3 mainnow = new Vector3(0f,0f,0f);

	// Use this for initialization
	void Start () {
		moverule = GameObject.Find ("moverule_heavytank");
		TurnChanger = GameObject.Find ("TurnChanger");
		cameras = GameObject.FindWithTag ("MainCamera");

	}
	
	// Update is called once per frame
	void Update () {
		turn = TurnChanger.GetComponent<turnrule> ().turn;
		if (turn == 0) {
			RaycastHit hit = cameras.GetComponent<MouseLays> ().hit;
			clickedGameObject = cameras.GetComponent<MouseLays> ().clickedGameObject;
			now = hit.point;
			if (clickedGameObject == this.gameObject) {
				if (Input.GetMouseButtonDown(0)) {
					if (clickedGameObject.tag == "Redteam/heavytank") {
						if(movesign == 1){
							if (clickedGameObject == this.gameObject) {
								before = hit.point;
								moverule.SetActive (true);
								moverule.transform.position = new Vector3 (before.x,before.y,before.z);
								sign = 1;
								Debug.Log ("1");
							}
						}
					}

				}

				if (Input.GetMouseButtonUp (0)) {
					if (clickedGameObject.tag == "Redteam/heavytank") {
						movesign = 0;
						moverule.SetActive (false);
						sign = 0;
					}
				}
			}

			if(this.transform.rotation != new Quaternion(0f,0f,0f,0f)){
				this.transform.rotation = new Quaternion(0f,0f,0f,0f);
			}
		}
		if (turn == 1) {
			RaycastHit hit = cameras.GetComponent<MouseLays> ().hit;
			clickedGameObject = cameras.GetComponent<MouseLays> ().clickedGameObject;
			now = hit.point;
			if (clickedGameObject == this.gameObject) {
				if (Input.GetMouseButtonDown(0)) {
					if (clickedGameObject.tag == "Blueteam/heavytank") {
						if(movesign == 0){
							if (clickedGameObject == this.gameObject) {
								before = hit.point;
								moverule.SetActive (true);
								moverule.transform.position = new Vector3 (before.x,before.y,before.z);
								sign = 1;
								Debug.Log ("1");
							}
						}
					}

				}

				if (Input.GetMouseButtonUp (0)) {
					if (clickedGameObject.tag == "Blueteam/heavytank") {
						movesign = 1;
						moverule.SetActive (false);
						sign = 0;
					}

				}
			}

			if(this.transform.rotation != new Quaternion(0f,0f,0f,0f)){
				this.transform.rotation = new Quaternion(0f,0f,0f,0f);
			}
		}
	}
	void OnTriggerStay(Collider other){
		if (sign == 1) {
			if (Input.GetMouseButtonDown (1)) {
				moverule.SetActive (false);
				sign = 0;
				this.transform.position = new Vector3 (before.x, before.y, before.z);
			}
			resultX = now.x - before.x;
			resultZ = now.z - before.z;
			resultX = Mathf.Abs (resultX);
			resultZ = Mathf.Abs (resultZ);
			Debug.Log ("Yes");
			if (resultX <= 3.5f) {
				if (resultZ <= 3.5f) {
					Debug.Log ("OK");
					now2 = now;

					this.transform.position = new Vector3 (now.x, 0.1f, now.z);
				}
				else {
					this.transform.position = new Vector3 (now2.x, 0.1f, now2.z);
				}
			}
			else {
				this.transform.position = new Vector3 (now2.x, 0.1f, now2.z);
			}
		} 
	}


}
