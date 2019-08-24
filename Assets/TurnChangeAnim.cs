using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnChangeAnim : MonoBehaviour {
	public int turn = 0;
	public float speed = 1f;
	Animation anim;
	Color color;
	GameObject[] children;
	// Use this for initialization
	void Start (){
		children = GameObject.FindGameObjectsWithTag ("textchildren");
		anim = GetComponent<Animation>();
		color = GetComponent<Renderer> ().material.color;
	}
	void Update (){
		if (turn == 0) {
			if (color.r > 0) {
				color.r = color.r - speed * Time.deltaTime;
				for (int i = 0; i < children.Length; i++) {
					children[i].GetComponent<Renderer> ().material.color = color;
				}
				Debug.Log ("色変え");
			}
			if (color.b < 255) {
				color.b = color.b + speed * Time.deltaTime;
				for (int i = 0; i < children.Length; i++) {
					children[i].GetComponent<Renderer> ().material.color = color;
				}
				Debug.Log ("色変え");
			}
		}
		if (turn == 1) {
			if (color.b > 0) {
				color.b = color.b - speed * Time.deltaTime;
				for (int i = 0; i < children.Length; i++) {
					children[i].GetComponent<Renderer> ().material.color = color;
				}
				Debug.Log ("色変え");
			}
			if (color.r < 255) {
				color.r = color.r + speed * Time.deltaTime;
				for (int i = 0; i < children.Length; i++) {
					children[i].GetComponent<Renderer> ().material.color = color;
				}
				Debug.Log ("色変え");
			}
		}
	}
	public void playanim(){
		this.gameObject.SetActive (true);
		anim.Play ("turnanim");
		Invoke("DelayMethod", 3.5f);
	}
	void DelayMethod (){
		this.gameObject.SetActive (false);
	}


}
