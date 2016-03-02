using UnityEngine;
using System.Collections;

public class AwakeKidScript : MonoBehaviour {

	public Animator gameOverAnimator;

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag.Equals ("Enemy")) {
			//other.gameObject.GetComponent<EnemyScript> ().takeHit ();
			//AwakeGameOverWidget.SetActive(true);
			gameOverAnimator.SetTrigger("GameOver");
		}
	}
}
