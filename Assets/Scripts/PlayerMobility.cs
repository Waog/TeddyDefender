using UnityEngine;
using System.Collections;

public class PlayerMobility : MonoBehaviour
{


	public float speed;
	private bool moveAllowed = false;

	private const float CLICK_INTERVAL = 0.3f;
	private int movingAnimatorParamHash;
	private bool mouseDownLastFrame = false;

	void Awake ()
	{
		movingAnimatorParamHash = Animator.StringToHash ("Moving");
	}

	void Update ()
	{

	}

	bool isEnemyInHitZone ()
	{
		Transform hitZone = transform.Find ("hitZone");
		BoxCollider2D playerHitZoneCollider = hitZone.GetComponent<BoxCollider2D> ();

		return hitZone.GetComponent<CollidingEnemyCounter> ().isColliding ();
	}

	void FixedUpdate ()
	{
		if (Input.GetMouseButton (0)) {
			lookToMouse ();
			if (mouseDownLastFrame) {
				if (isEnemyInHitZone ()) {
					GetComponent<Animator> ().SetTrigger ("Attack");
					moveAllowed = false;
				} else {
					moveAllowed = true;
				}
			}

			if (moveAllowed) {
				GetComponent<Rigidbody2D> ().AddForce (gameObject.transform.up * speed);
			}
		}
		GetComponent<Animator> ().SetBool (movingAnimatorParamHash,
			GetComponent<Rigidbody2D> ().velocity.magnitude > 0.1);
		GetComponent<Rigidbody2D> ().angularVelocity = 0;

		if (Input.GetMouseButtonDown (0)) {
			//|| (Input.touchCount > 0 && Input.GetTouch(0).phase.Equals(TouchPhase.Began))) {
			lookToMouse ();
			mouseDownLastFrame = true;
		} else {
			mouseDownLastFrame = false;
		}
	}

	void lookToMouse ()
	{
		var mousePosition = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		Quaternion rot = Quaternion.LookRotation (transform.position - mousePosition, Vector3.forward);
		transform.rotation = rot;
		transform.eulerAngles = new Vector3 (0, 0, transform.eulerAngles.z);

//		Vector3 teddyToMouse = mousePosition - transform.position;
//		GetComponent<Rigidbody2D> ().MoveRotation(- Mathf.Rad2Deg * Mathf.Atan2(teddyToMouse.x, teddyToMouse.y));
	}
}
