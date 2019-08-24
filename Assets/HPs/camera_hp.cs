using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera_hp : MonoBehaviour {
	void LateUpdate() {
		transform.rotation = Camera.main.transform.rotation;
	}
}
