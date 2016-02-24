using UnityEngine;
using System.Collections;

public class ApplyAsText : MonoBehaviour {

	public void apply(float f) {
		UnityEngine.UI.Text t = GetComponent<UnityEngine.UI.Text>();
		t.text = "" + f;
	}
}
