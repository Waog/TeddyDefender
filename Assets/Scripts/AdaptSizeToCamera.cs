using UnityEngine;
using System.Collections;

public class AdaptSizeToCamera : MonoBehaviour
{

	private float PADDING = 0.05f;

	void Update ()
	{

		transform.localPosition = new Vector3 (Camera.main.transform.localPosition.x, Camera.main.transform.localPosition.y, 0);
		transform.localScale = new Vector3 (2f * (1f - PADDING) * Camera.main.orthographicSize * Screen.width / Screen.height, 2f * (1f - PADDING) * Camera.main.orthographicSize, transform.localScale.z);
	}
}
