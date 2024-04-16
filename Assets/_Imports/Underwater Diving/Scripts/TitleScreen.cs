using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreen : MonoBehaviour {

	public float count;

	public GameObject instructionsWindow;
	
	void Update () {
		transform.position = new Vector3 (transform.position.x + count, transform.position.y, -10);	

		if(Input.GetKeyDown(KeyCode.Return))
		{
			SceneManager.LoadScene ("scene-1");
		}

	}
}
