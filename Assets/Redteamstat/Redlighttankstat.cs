using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Redlighttankstat : MonoBehaviour {
	public float RHitPoint = 100f;
	public float RAttackPoint = 50f;
	public float RDefencePoint = 20f;
	public float enemyHitpoint = 0f;
	public float enemyAttackpoint = 0f;
	public float enemyDefencepoint = 0f;

	public float friendlyfinalattackpoint = 0f;
	public float enemyfinalattackpoint = 0f;

	GameObject enemy;
	HPbar friendlyhitpointbar;
	HPbar enemyhitpoint;

	RedAttack enemyinformation;
	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}
	public void caluculateattack(){
		Debug.Log ("計算開始");
		enemyinformation = GetComponent<RedAttack> ();
		enemy = enemyinformation.clickedGameObject;
		if (enemy.gameObject.tag == "Blueteam/heavytank") {
			enemyHitpoint = enemy.GetComponent<Blueheavytankstat> ().BHitPoint;
			enemyAttackpoint = enemy.GetComponent<Blueheavytankstat> ().BAttackPoint;
			enemyDefencepoint = enemy.GetComponent<Blueheavytankstat> ().BDefencePoint;
		}
		if (enemy.gameObject.tag == "Blueteam/lighttank") {
			enemyHitpoint = enemy.GetComponent<Bluelighttankstat> ().BHitPoint;
			enemyAttackpoint = enemy.GetComponent<Bluelighttankstat> ().BAttackPoint;
			enemyDefencepoint = enemy.GetComponent<Bluelighttankstat> ().BDefencePoint;
		}
		if (enemy.gameObject.tag == "Blueteam/carryer") {
			enemyHitpoint = enemy.GetComponent<Bluecarryerstat> ().BHitPoint;
			enemyAttackpoint = enemy.GetComponent<Bluecarryerstat> ().BAttackPoint;
			enemyDefencepoint = enemy.GetComponent<Bluecarryerstat> ().BDefencePoint;
		}

		friendlyfinalattackpoint = enemyDefencepoint - RAttackPoint * RHitPoint / 100;
		enemyfinalattackpoint = RDefencePoint - enemyAttackpoint * enemyHitpoint / 100 * 0.9f;

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
		RHitPoint = RHitPoint + enemyfinalattackpoint;
		enemyHitpoint = enemyHitpoint + friendlyfinalattackpoint;
		if (enemy.gameObject.tag == "Blueteam/heavytank") {
			enemy.GetComponent<Blueheavytankstat> ().BHitPoint = enemyHitpoint;
		}
		if (enemy.gameObject.tag == "Blueteam/lighttank") {
			enemy.GetComponent<Bluelighttankstat> ().BHitPoint = enemyHitpoint;
		}
		if (enemy.gameObject.tag == "Blueteam/carryer") {
			enemy.GetComponent<Bluecarryerstat> ().BHitPoint = enemyHitpoint;
		}

		this.gameObject.GetComponentInChildren<HPbar> ().health = RHitPoint;
		this.gameObject.GetComponentInChildren<HPbar>().Healthbar();
		enemy.gameObject.GetComponentInChildren<HPbar>().health = enemyHitpoint;
		enemy.gameObject.GetComponentInChildren<HPbar>().Healthbar();
		Debug.Log (enemyfinalattackpoint);
		Debug.Log (friendlyfinalattackpoint);
		if (RHitPoint <= 0) {
			Destroy (this.gameObject);
		}
		if (enemyHitpoint <= 0) {
			Destroy (enemy);
		}

	}
}
