using UnityEngine;
using System.Collections;

public class SceneTimer : MonoBehaviour
{

	bool timerFreezed = false;
	
	// Update is called once per frame
	void Update ()
	{
		if (!timerFreezed) {
			UnityEngine.UI.Text t = GetComponent<UnityEngine.UI.Text> ();
			t.text = "" + Mathf.FloorToInt (Time.timeSinceLevelLoad);
		}
	}

	public void freezeTimer ()
	{
		timerFreezed = true;
	}
}
