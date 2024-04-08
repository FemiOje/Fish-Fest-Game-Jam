using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreen : MonoBehaviour {

	public float count;
	private int titleState;

	public GameObject instructionsWindow;

	// Use this for initialization
	void Start () {
		titleState = 1;		
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = new Vector3 (transform.position.x + count, transform.position.y, -10);	

		if(Input.GetKeyDown(KeyCode.Return))
		{
			SceneManager.LoadScene ("scene-1");
		}

	}
}
