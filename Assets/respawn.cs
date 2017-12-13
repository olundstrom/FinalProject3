using UnityEngine;
using System.Collections;

public class respawn : MonoBehaviour {
	public float threshold;
	private playercontroller3 player;

	void Start (){
	
		player = GameObject.FindGameObjectWithTag ("Player").GetComponent<playercontroller3> ();

	}

	void FixedUpdate () {
		if (transform.position.y < threshold) {
			transform.position = new Vector3 (0, 0, -4);
			player.Health--;
		}
	}
}
