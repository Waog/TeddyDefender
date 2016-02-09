using UnityEngine;
using System.Collections;

public class PlayerMobility : MonoBehaviour
{


    public float speed;
	private bool moveAllowed = true;

    private const float CLICK_INTERVAL = 0.3f;
    private int movingAnimatorParamHash;

    void Awake()
    {
        movingAnimatorParamHash = Animator.StringToHash("Moving");
    }

    void Update() {

    }

	bool isEnemyInHitZone() {
		Transform hitZone = transform.Find("hitZone");
		BoxCollider2D playerHitZoneCollider = hitZone.GetComponent<BoxCollider2D> ();

		return hitZone.GetComponent<collidingEnemyCounter> ().isColliding ();

//		GameObject[] enemies = GameObject.FindGameObjectsWithTag ("Enemy");
//		foreach (GameObject enemy in enemies) {
//			BoxCollider2D enemyCollider = enemy.GetComponent<BoxCollider2D> ();
//			if (Physics2D.IsTouching (playerHitZoneCollider, enemyCollider)) {
//				return true;
//			}
//		}
//		return false;
	}

    void FixedUpdate()
    {
		if (Input.GetMouseButtonDown (0)) {
			//|| (Input.touchCount > 0 && Input.GetTouch(0).phase.Equals(TouchPhase.Began))) {
			lookToMouse ();
			if (isEnemyInHitZone ()) {
				GetComponent<Animator> ().SetTrigger ("Attack");
				moveAllowed = false;
			} else {
				moveAllowed = true;
			}
		}

        if (Input.GetMouseButton(0) && moveAllowed) {
			lookToMouse ();

            GetComponent<Rigidbody2D>().AddForce(gameObject.transform.up * speed);
            GetComponent<Animator>().SetBool(movingAnimatorParamHash,
                        GetComponent<Rigidbody2D>().velocity.magnitude > 0.1);
        } else {
            GetComponent<Animator>().SetBool(movingAnimatorParamHash, false);
        }
		GetComponent<Rigidbody2D>().angularVelocity = 0;
    }

	void lookToMouse ()
	{
		var mousePosition = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		Quaternion rot = Quaternion.LookRotation (transform.position - mousePosition, Vector3.forward);
//		transform.rotation = rot;
//		transform.eulerAngles = new Vector3 (0, 0, transform.eulerAngles.z);

		Vector3 teddyToMouse = mousePosition - transform.position;
		GetComponent<Rigidbody2D> ().MoveRotation(- Mathf.Rad2Deg * Mathf.Atan2(teddyToMouse.x, teddyToMouse.y));
	}
}
