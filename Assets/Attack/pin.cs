using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pin : MonoBehaviour {

	GameObject heavyattackrule;
	GameObject lightattackrule;
	GameObject carryerattackrule;

	// Use this for initialization
	void Start () {
		heavyattackrule = GameObject.Find ("heavyattackrule");
		lightattackrule = GameObject.Find ("lightattackrule");
		carryerattackrule = GameObject.Find ("carryerattackrule");
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnTriggerStay(Collider other){
		if (other == heavyattackrule) {
		}
		if (other == lightattackrule) {
		}
		if (other == carryerattackrule) {
		}
	}
}
