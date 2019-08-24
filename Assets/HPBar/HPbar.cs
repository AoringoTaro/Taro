using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPbar : MonoBehaviour {

	public float health = 100f;
	public Slider healthslider;

	// Use this for initialization
	public void Healthbar () {
		this.GetComponent<Slider>().value = health;
		
	}
}
