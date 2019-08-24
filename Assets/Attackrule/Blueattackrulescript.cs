using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blueattackrulescript : MonoBehaviour {
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

		if (other.gameObject.CompareTag ("Redteam/heavytank") && !Cols.Contains (other.gameObject)) {
			Debug.Log ("赤軍");
			Cols.Add (other.gameObject);
			sign = 2;
		}
		if (other.gameObject.CompareTag ("Redteam/carryer") && !Cols.Contains (other.gameObject)) {
			Debug.Log ("赤軍");
			Cols.Add (other.gameObject);
			sign = 2;
		}
		if (other.gameObject.CompareTag ("Redteam/lighttank") && !Cols.Contains (other.gameObject)) {
			Debug.Log ("赤軍");
			Cols.Add (other.gameObject);
			sign = 2;
		}
		else{
			Cols.Remove (other.gameObject);
		}
	}
}
