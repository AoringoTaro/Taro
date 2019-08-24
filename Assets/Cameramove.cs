using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cameramove : MonoBehaviour {

	//GameObject clickedGameObject;
	Vector3 now = new Vector3(0f,0f,0f);
	Vector3 before = new Vector3(0f,0f,0f);
	public int oksign = 0;
	public float speed1 = 3f;
	public float speed2 = -3f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		//clickedGameObject = null;

		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit = new RaycastHit();

		if (Physics.Raycast(ray, out hit)) {
			//clickedGameObject = hit.collider.gameObject;
		}

		now = hit.point;

		if (Input.GetMouseButtonDown (1)) {
			oksign = 1;
			before = hit.point;
		}
		if (oksign == 1) {
			if (now.x - before.x >= 5) {
				if (this.transform.position.x <= 20f) {
					Debug.Log ("1");
					this.transform.position += new Vector3 (speed1*Time.deltaTime,0f,0f);
				}
			}if (now.x - before.x <= -5) {
				if (this.transform.position.x >= 5f) {
					Debug.Log ("2");
					this.transform.position += new Vector3 (speed2* Time.deltaTime, 0f, 0f);
				}
			}if (now.z - before.z >= 5) {
				if (this.transform.position.z <= 20f) {
					Debug.Log ("3");
					this.transform.position += new Vector3 (0f, 0f, speed1* Time.deltaTime);
				}
			}if (now.z - before.z <= -5) {
				if (this.transform.position.z >= 5f) {
					Debug.Log ("4");
					this.transform.position += new Vector3 (0f, 0f, speed2* Time.deltaTime);
				}
			}
		}
		if (Input.GetMouseButtonUp (1)) {
			oksign = 0;
		}

			
	}
}
