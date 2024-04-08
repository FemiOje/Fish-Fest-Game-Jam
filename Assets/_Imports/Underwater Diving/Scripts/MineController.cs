using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineController : MonoBehaviour {

	public GameObject explosion;

	private void OnTriggerEnter2D(Collider2D other) {
		if(other.gameObject.tag == "Player"){	
			GameManager.Instance.UpdateLives(-1);
			Instantiate (explosion, gameObject.transform.position, gameObject.transform.rotation);
		}	
	}
}
