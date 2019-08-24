using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class factorymove : MonoBehaviour {
	public GameObject[] Canvas;
	public GameObject Cameras;
	public GameObject turnchanger;
	// Use this for initialization
	void Start () {
		Canvas = GameObject.FindGameObjectsWithTag("SpawnButton");
		for (int i = 0; i < Canvas.Length; i++) {
			Canvas [i].SetActive (false);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void Clicked(){
		Cameras.GetComponent<circlebutton> ().factory = this.gameObject;
		for (int i = 0; i < Canvas.Length; i++) {
			Canvas [i].SetActive (true);
		}
	}
	public void makeheavytank(){

	}
	public void makelighttank(){

	}
	public void makecarryer(){

	}
	public void Finished(){
		for (int i = 0; i < Canvas.Length; i++) {
			Canvas [i].SetActive (false);
		}
	}
}
