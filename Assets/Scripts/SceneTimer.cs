using UnityEngine;
using System.Collections;

public class SceneTimer : MonoBehaviour
{
	
	// Update is called once per frame
	void Update ()
	{
		UnityEngine.UI.Text t = GetComponent<UnityEngine.UI.Text> ();
		t.text = "" + Mathf.FloorToInt(Time.timeSinceLevelLoad);
	}
}
