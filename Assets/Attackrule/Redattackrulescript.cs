using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Redattackrulescript : MonoBehaviour {
	public int sign = 0;
	List<GameObject>Cols = new List<GameObject>();
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnTriggerEnter(Collider other){
		Debug.Log ("攻撃対象発見");

		if (other.gameObject.CompareTag ("Blueteam/heavytank") && !Cols.Contains (other.gameObject)) {
			Debug.Log ("青軍");
			Cols.Add (other.gameObject);
			sign = 2;
		}
		if (other.gameObject.CompareTag ("Blueteam/carryer") && !Cols.Contains (other.gameObject)) {
			Debug.Log ("青軍");
			Cols.Add (other.gameObject);
			sign = 2;
		}
		if (other.gameObject.CompareTag ("Blueteam/lighttank") && !Cols.Contains (other.gameObject)) {
			Debug.Log ("青軍");
			Cols.Add (other.gameObject);
			sign = 2;
		}
		else{
			Cols.Remove (other.gameObject);
		}
	}

}
