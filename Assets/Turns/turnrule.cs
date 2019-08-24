using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class turnrule : MonoBehaviour {
	public int turn = 0;
	int colorsign = 1;
	bool count = false;
	public GameObject turnColor;
	public GameObject noturn;
	public Color Color1;
	public Color Base;
	GameObject text;
	public GameObject[] Redheavytanks;
	public GameObject[] Redlighttanks;
	public GameObject[] Redcarryers;
	public GameObject[] Blueheavytanks;
	public GameObject[] Bluelighttanks;
	public GameObject[] Bluecarryers;
	float speed = 1f;

	// Use this for initialization
	void Start () {
		text = GameObject.FindWithTag ("Turntext");
		text.SetActive (false);
		Redheavytanks = GameObject.FindGameObjectsWithTag("Redteam/heavytank");
		Redlighttanks = GameObject.FindGameObjectsWithTag("Redteam/lighttank");
		Redcarryers = GameObject.FindGameObjectsWithTag("Redteam/carryer");
	    Blueheavytanks = GameObject.FindGameObjectsWithTag("Blueteam/heavytank");
		Bluelighttanks = GameObject.FindGameObjectsWithTag("Blueteam/lighttank");
		Bluecarryers = GameObject.FindGameObjectsWithTag("Blueteam/carryer");
		turnColor = GameObject.FindWithTag("Turn1");
		noturn = GameObject.FindWithTag ("Turn2");
	}
	
	// Update is called once per frame
	void Update () {
		if (colorsign == 1) {
			Debug.Log ("配色変更");
			if (Color1.r >= 255) {

			} else {
				Color1.r = Color1.r + Time.deltaTime * speed;
				turnColor.GetComponent<Text> ().color = Color1;
				noturn.GetComponent<Text> ().color = Color1;

			}
		}
		if (colorsign == 0) {
			Debug.Log ("配色変更");
			if (Color1.b >= 255) {

			} else {
				Color1.b = Color1.b + Time.deltaTime * speed;
				turnColor.GetComponent<Text> ().color = Color1;
				noturn.GetComponent<Text> ().color = Color1;

			}
		}
	}
	public void click(){
		if (count == false) {
			turn = 1;
			for (int i = 0; i < Blueheavytanks.Length; i++) {
				Blueheavytanks [i].GetComponent<heavytank_move> ().movesign = 0;
				Blueheavytanks [i].GetComponent<BlueAttack> ().attackchange = 0;
				Debug.Log(Redheavytanks [i] + "補給完了");
			}
			for (int i = 0; i < Bluelighttanks.Length; i++) {
				Bluelighttanks [i].GetComponent<lighttank_move> ().movesign = 0;
				Bluelighttanks [i].GetComponent<BlueAttack> ().attackchange = 0;
				Debug.Log(Redlighttanks [i] + "補給完了");
			}
			for (int i = 0; i < Bluecarryers.Length; i++) {
				Bluecarryers [i].GetComponent<carryer_move> ().movesign = 0;
				Bluecarryers[i].GetComponent<BlueAttack> ().attackchange = 0;
				Debug.Log(Redcarryers [i] + "補給完了");
			}

			colorsign = 0;
			Color1 = Base;
			turnColor.GetComponent<Text> ().text = "青";
			text.GetComponent<TurnChangeAnim> ().turn = 0;
			text.GetComponent<TurnChangeAnim> ().playanim ();
		}
		if (count == true) { 
			turn = 0;
			for (int i = 0; i < Redheavytanks.Length; i++) {
				Redheavytanks [i].GetComponent<heavytank_move> ().movesign = 1;
				Redheavytanks[i].GetComponent<RedAttack> ().attackchange = 1;
				Debug.Log(Redheavytanks [i] + "補給完了");
			}
			for (int i = 0; i < Redlighttanks.Length; i++) {
				Redlighttanks [i].GetComponent<lighttank_move> ().movesign = 1;
				Redlighttanks[i].GetComponent<RedAttack> ().attackchange = 1;
				Debug.Log(Redlighttanks [i] + "補給完了");
			}
			for (int i = 0; i < Redcarryers.Length; i++) {
				Redcarryers [i].GetComponent<carryer_move> ().movesign = 1;
				Redcarryers[i].GetComponent<RedAttack> ().attackchange = 1;
				Debug.Log(Redcarryers [i] + "補給完了");
			}
			colorsign = 1;
			Color1 = Base;
			turnColor.GetComponent<Text> ().text = "赤";
			text.GetComponent<TurnChangeAnim> ().turn = 1;
			text.GetComponent<TurnChangeAnim> ().playanim ();

		}
		if (turn == 1) {
			count = true;
		}
		if (turn == 0) {
			count = false;
		}
	}
}
