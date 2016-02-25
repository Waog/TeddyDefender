using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class RestartScene : MonoBehaviour {

	public void restartScene () {
		SceneManager.LoadScene("mainScene");
	}
}
