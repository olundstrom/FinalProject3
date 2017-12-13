using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class HUD: MonoBehaviour  {


	public Sprite[] HearthSprites;

	public Image HeartUI;
	private playercontroller3 player;

	void Start(){

		player = GameObject.FindGameObjectWithTag ("Player").GetComponent<playercontroller3> ();


	}

	void Update(){
		HeartUI.sprite = HearthSprites[player.Health];
	}

}


