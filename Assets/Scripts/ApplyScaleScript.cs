using UnityEngine;
using System.Collections;

public class ApplyScaleScript : MonoBehaviour {

	public void setScale(float newScale) {
		transform.localScale = new Vector3 (newScale, newScale, 1);
	}

	public void setInverseScale(float newScaleDenominator) {
		transform.localScale = new Vector3 (1 / newScaleDenominator, 1 / newScaleDenominator, 1);
	}
}
