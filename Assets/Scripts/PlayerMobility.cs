using UnityEngine;
using System.Collections;

public class PlayerMobility : MonoBehaviour
{
	public float speed;
	public GameObject targetIndicator;

	const float CLICK_INTERVAL = 0.3f;
	int movingAnimatorParamHash;
	GameObject movingGoalIndicator;


	void Awake ()
	{
		movingAnimatorParamHash = Animator.StringToHash ("Moving");
	}

	bool isEnemyInHitZone ()
	{
		Transform hitZone = transform.Find ("hitZone");
		return hitZone.GetComponent<CollidingEnemyCounter> ().isColliding ();
	}

	void Update ()
	{
		if (Input.GetMouseButtonUp (0)) {
			if (movingGoalIndicator) {
				Destroy (movingGoalIndicator);
			}

			Vector3 clickPositionOnFloor = Camera.main.ScreenToWorldPoint (Input.mousePosition);
			clickPositionOnFloor.z = 0;
			movingGoalIndicator = (GameObject)Instantiate (targetIndicator, clickPositionOnFloor, Quaternion.identity);
		}

		if (movingGoalIndicator != null) {
			lookToTargetIndicator ();
			GetComponent<Rigidbody2D> ().AddForce (gameObject.transform.up * speed);
		}
			
		GetComponent<Animator> ().SetBool (movingAnimatorParamHash,
			GetComponent<Rigidbody2D> ().velocity.magnitude > 0.1);
		GetComponent<Rigidbody2D> ().angularVelocity = 0;
	}

	void lookToTargetIndicator ()
	{
		Quaternion rot = Quaternion.LookRotation (Vector3.forward, movingGoalIndicator.transform.position - transform.position);
		transform.rotation = rot;
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.CompareTag("TargetIndicator")) {
			if (movingGoalIndicator) {
				Destroy (movingGoalIndicator);
				movingGoalIndicator = null;
			}
		}
	}
}
