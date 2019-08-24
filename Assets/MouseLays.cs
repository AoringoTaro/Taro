using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLays : MonoBehaviour {

	public GameObject clickedGameObject ;
	public RaycastHit hit;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		clickedGameObject = null;

		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		hit = new RaycastHit();

		if (Physics.Raycast(ray, out hit)) {
			clickedGameObject = hit.collider.gameObject;
		}

	}
}
