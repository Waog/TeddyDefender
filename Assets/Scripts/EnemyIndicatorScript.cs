using UnityEngine;
using System.Collections;

public class EnemyIndicatorScript : MonoBehaviour
{

	public Transform player;
	public Transform enemy;

	void Update ()
	{
		if (enemy == null) {
			Destroy (gameObject);
			return;
		}

		updatePositionAndVisibility ();

		updateAngle ();
	}

	void updatePositionAndVisibility ()
	{
		RaycastHit2D[] hitInfos = Physics2D.LinecastAll (enemy.position, player.position);
		foreach (RaycastHit2D hitInfo in hitInfos) {
			if (hitInfo.collider.tag.Equals ("OffscreenIndicatorBounds")) {
				transform.position = new Vector3 (hitInfo.point.x, hitInfo.point.y, 0);
				if (hitInfo.distance == 0) {
					GetComponent<Renderer> ().enabled = false;
				}
				else {
					GetComponent<Renderer> ().enabled = true;
				}
			}
		}
	}

	void updateAngle ()
	{
		Vector3 player2enemy = enemy.position - player.position;
		transform.eulerAngles = new Vector3 (0, 0, Mathf.Rad2Deg * Mathf.Atan2 (player2enemy.y, player2enemy.x));
	}
}
