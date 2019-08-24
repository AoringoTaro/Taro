using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class circlebutton : MonoBehaviour {

	public List<MenuButton> buttons = new List<MenuButton> ();
	public GameObject factory;
	private Vector2 Mouseposition;
	private Vector2 fromVector2X = new Vector2(0.5f,1.0f);
	private Vector2 centercircle = new Vector2(0.5f,0.5f);
	private Vector2 toVector2X;

	public int menuItems;
	public int CurMenuItem;
	public int OldMenuItem;

	// Use this for initialization
	void Start () {
		menuItems = buttons.Count;
		foreach (MenuButton button in buttons) {
			button.aceneimage.color = button.NormalColor;
		}
		CurMenuItem = 0;
		OldMenuItem = 0;
	}
	
	// Update is called once per frame
	void Update () {
		GetCurrentMenuItem ();
		//if (Input.GetButtonDown ("0"))
			ButtonAction ();
	}
	public void GetCurrentMenuItem(){
		Mouseposition = new Vector2 (Input.mousePosition.x, Input.mousePosition.y);

		toVector2X = new Vector2 (Mouseposition.x / Screen.width, Mouseposition.y / Screen.height);

		float angle = (Mathf.Atan2(fromVector2X.y-centercircle.y,fromVector2X.x-centercircle.x) - Mathf.Atan2(toVector2X.y-centercircle.y,toVector2X.x-centercircle.x)) * Mathf.Rad2Deg;

		if (angle < 0)
			angle += 360;

		CurMenuItem = (int)(angle / (360 / menuItems));
		if (CurMenuItem != OldMenuItem) {
			buttons [OldMenuItem].aceneimage.color = buttons [OldMenuItem].NormalColor;
			OldMenuItem = CurMenuItem;
			buttons [CurMenuItem].aceneimage.color = buttons [CurMenuItem].HighlightedColor;
		}
	}
	public void ButtonAction(){
		buttons [CurMenuItem].aceneimage.color = buttons [CurMenuItem].PressedColor;

		switch (CurMenuItem) {
		case 0:
			factory.GetComponent<factorymove> ().Finished ();
			break;
		case 1:
			factory.GetComponent<factorymove> ().Finished ();
			break;
		case 2:
			factory.GetComponent<factorymove> ().Finished ();
			break;
		case 3:
			factory.GetComponent<factorymove> ().Finished ();
			break;
		}
	}

}
[System.Serializable]
public class MenuButton
{
	public string name;
	public Image aceneimage;
	public Color NormalColor = Color.white;
	public Color HighlightedColor = Color.gray;
	public Color PressedColor = Color.gray;
}

