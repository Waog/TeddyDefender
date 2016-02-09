using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class collidingEnemyCounter : MonoBehaviour {

	private List<Collider2D> inside = new List<Collider2D>();

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag.Equals ("Enemy")) {
			inside.Add (other);
		}
	}

	void OnTriggerExit2D(Collider2D other)
	{
		if (other.gameObject.tag.Equals ("Enemy")) {
			inside.Remove (other);
		}
	}

	public bool isColliding() {
		inside.RemoveAll (item => item == null);

		return inside.Count > 0;
	}
}
