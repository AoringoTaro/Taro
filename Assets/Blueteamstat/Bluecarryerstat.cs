using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bluecarryerstat : MonoBehaviour {
	public float BHitPoint = 100f;
	public float BAttackPoint = 75f;
	public float BDefencePoint = 30f;
	public float enemyHitpoint = 0f;
	public float enemyAttackpoint = 0f;
	public float enemyDefencepoint = 0f;

	public float friendlyfinalattackpoint = 0f;
	public float enemyfinalattackpoint = 0f;

	GameObject enemy;
	BlueAttack enemyinformation;
	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}
	public void caluculateattack(){
		Debug.Log ("計算開始");
		enemyinformation = GetComponent<BlueAttack> ();
		enemy = enemyinformation.clickedGameObject;
		if (enemy.gameObject.tag == "Redteam/heavytank") {
			enemyHitpoint = enemy.GetComponent<Redheavytankstat> ().RHitPoint;
			enemyAttackpoint = enemy.GetComponent<Redheavytankstat> ().RAttackPoint;
			enemyDefencepoint = enemy.GetComponent<Redheavytankstat> ().RDefencePoint;
		}
		if (enemy.gameObject.tag == "Redteam/lighttank") {
			enemyHitpoint = enemy.GetComponent<Redlighttankstat> ().RHitPoint;
			enemyAttackpoint = enemy.GetComponent<Redlighttankstat> ().RAttackPoint;
			enemyDefencepoint = enemy.GetComponent<Redlighttankstat> ().RDefencePoint;
		}
		if (enemy.gameObject.tag == "Redteam/carryer") {
			enemyHitpoint = enemy.GetComponent<Redcarryerstat> ().RHitPoint;
			enemyAttackpoint = enemy.GetComponent<Redcarryerstat> ().RAttackPoint;
			enemyDefencepoint = enemy.GetComponent<Redcarryerstat> ().RDefencePoint;
		}
		friendlyfinalattackpoint = enemyDefencepoint - BAttackPoint * BHitPoint / 100;
		enemyfinalattackpoint = BDefencePoint - enemyAttackpoint * enemyHitpoint / 100*0.9f;

		Debug.Log (enemyfinalattackpoint);
		Debug.Log (friendlyfinalattackpoint);

		if (friendlyfinalattackpoint >= 0) {
			Debug.Log ("回復させている");
			friendlyfinalattackpoint = 0;
		}
		if (enemyfinalattackpoint >= 0) {
			Debug.Log("回復させている");
			enemyfinalattackpoint = 0;
		}
		BHitPoint = BHitPoint + enemyfinalattackpoint;
		enemyHitpoint = enemyHitpoint + friendlyfinalattackpoint;
		if (enemy.gameObject.tag == "Redteam/heavytank") {
			enemy.GetComponent<Redheavytankstat> ().RHitPoint = enemyHitpoint;
		}
		if (enemy.gameObject.tag == "Redteam/lighttank") {
			enemy.GetComponent<Redlighttankstat> ().RHitPoint = enemyHitpoint;
		}
		if (enemy.gameObject.tag == "Redteam/carryer") {
			enemy.GetComponent<Redcarryerstat> ().RHitPoint = enemyHitpoint;
		}
		this.gameObject.GetComponentInChildren<HPbar> ().health = BHitPoint;
		this.gameObject.GetComponentInChildren<HPbar>().Healthbar();
		enemy.gameObject.GetComponentInChildren<HPbar>().health = enemyHitpoint;
		enemy.gameObject.GetComponentInChildren<HPbar>().Healthbar();
		Debug.Log (enemyfinalattackpoint);
		Debug.Log (friendlyfinalattackpoint);
		if (BHitPoint <= 0) {
			Destroy (this.gameObject);
		}
		if (enemyHitpoint <= 0) {
			Destroy (enemy);
		}

	}
}
