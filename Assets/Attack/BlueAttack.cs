using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueAttack : MonoBehaviour {
	public GameObject clickedGameObject;
	GameObject pin;
	GameObject pinA;
	GameObject attackrule1;
	GameObject attackrule2;
	GameObject attackrule3;
	GameObject TurnChanger;
	GameObject cameras;
	public int attackchange = 0;
	//ameObject obj;
	Vector3 now = new Vector3(0f,0f,0f);
	int signal = 0;
	int turn = 0;
	public int turnrule = 0;
	public Blueheavytankstat attackcaluH; 
	public Bluelighttankstat attackcaluL; 
	public Bluecarryerstat attackcaluC; 
	// Use this for initialization
	void Start () {
		pin = GameObject.Find ("Arrow");
		pinA = GameObject.Find ("Capsule");
		attackrule3 = GameObject.Find ("carryerattackruleB");
		attackrule2 = GameObject.Find ("lightattackruleB");
		attackrule1 = GameObject.Find ("carryerattackruleB");
		TurnChanger = GameObject.Find ("TurnChanger");
		cameras = GameObject.FindWithTag ("MainCamera");

	}

	// Update is called once per frame
	void Update () {
		turnrule = TurnChanger.GetComponent<turnrule> ().turn;
		if (signal == 1) {
			RaycastHit hit = cameras.GetComponent<MouseLays> ().hit;
			clickedGameObject = cameras.GetComponent<MouseLays> ().clickedGameObject;
			now = hit.point;
			pin.SetActive (true);
			pin.transform.position = new Vector3 (now.x,2f,now.z);
			if (Input.GetMouseButtonDown (0)) {
				Debug.Log (clickedGameObject.tag);
				//obj = this.gameObject;
				if (this.gameObject.tag == "Blueteam/heavytank") {

					turn = /*rule.sign;*/attackrule1.GetComponent<Blueattackrulescript> ().sign;
					Debug.Log ("識別開始"+turn);
					if(turn == 2){
						if ((clickedGameObject.gameObject.tag == "Redteam/heavytank") || (clickedGameObject.gameObject.tag == "Redteam/lighttank")||(clickedGameObject.gameObject.tag == "Redteam/carryer")){
							pin.SetActive (false);
							Debug.Log ("攻撃側のオブジェクトは"+this.gameObject);
							Debug.Log ("反撃側のオブジェクトは"+clickedGameObject);
							attackcaluH = GetComponent<Blueheavytankstat> ();
							attackcaluH.caluculateattack ();
							attackrule1.GetComponent<Blueattackrulescript> ().sign = 0;
							signal = 0;
							attackchange = 0;
							attackrule1.SetActive (false);
						}

					}
				}
				if (this.gameObject.tag == "Blueteam/lighttank") {
					turn = /*rule.sign;*/attackrule2.GetComponent<Blueattackrulescript> ().sign;

					Debug.Log ("識別開始"+turn);
					if(turn == 2){
						if ((clickedGameObject.gameObject.tag == "Redteam/heavytank") || (clickedGameObject.gameObject.tag == "Redteam/lighttank")||(clickedGameObject.gameObject.tag == "Redteam/carryer")){
							pin.SetActive (false);
							Debug.Log ("攻撃側のオブジェクトは"+this.gameObject);
							Debug.Log ("反撃側のオブジェクトは"+clickedGameObject);
							attackcaluL = gameObject.GetComponent<Bluelighttankstat> ();
							attackcaluL.caluculateattack ();
							attackrule2.GetComponent<Blueattackrulescript> ().sign = 0;
							signal = 0;
							attackchange = 0;
							attackrule2.SetActive (false);
						}

					}
				}
				if (this.gameObject.tag == "Blueteam/carryer") {
					turn = /*rule.sign;*/attackrule3.GetComponent<Blueattackrulescript> ().sign;

					Debug.Log ("識別開始"+turn);
					if(turn == 2){
						if ((clickedGameObject.gameObject.tag == "Redteam/heavytank") || (clickedGameObject.gameObject.tag == "Redteam/lighttank")||(clickedGameObject.gameObject.tag == "Redteam/carryer")){
							pin.SetActive (false);
							Debug.Log ("攻撃側のオブジェクトは"+this.gameObject);
							Debug.Log ("反撃側のオブジェクトは"+clickedGameObject);
							attackcaluC = GetComponent<Bluecarryerstat> ();
							attackcaluC.caluculateattack ();
							attackrule3.GetComponent<Blueattackrulescript> ().sign = 0;
							signal = 0;
							attackchange = 0;
							attackrule3.SetActive (false);
						}

					}
				}


			}
		}
	}
	public void click(){
		if (turnrule == 1) {
			if (this.gameObject.tag == "Blueteam/heavytank") {
				if(attackchange == 0){
					attackrule1.SetActive (true);
					attackrule1.transform.position = this.gameObject.transform.position;
					signal = 1;
				}

			}
			if (this.gameObject.tag == "Blueteam/lighttank") {
				if(attackchange == 0){
					attackrule2.SetActive (true);
					attackrule2.transform.position = this.gameObject.transform.position;
					signal = 1;
				}

			}
			if (this.gameObject.tag == "Blueteam/carryer") {
				if(attackchange == 0){
					attackrule3.SetActive (true);
					attackrule3.transform.position = this.gameObject.transform.position;
					signal = 1;
				}

			}

			pin.transform.position = this.transform.position; 
		}

	}
	public void positionchange(){

	}
}
