using UnityEngine;
using System.Collections;

public class SquishyMonsterScript : EnemyScript
{
	public GameObject explosion;

	EnemyVariablesScript vars;
	bool isDying = false;

	void Start() {
		initiateIndicator ();
		vars = GetComponent<EnemyVariablesScript> ();
	}

	void FixedUpdate()
	{
		if (isDying) {
			return;
		}
		float z = Mathf.Atan2((vars.bed.transform.position.y - transform.position.y), (vars.bed.transform.position.x - transform.position.x)) * Mathf.Rad2Deg - 90;
		transform.eulerAngles = new Vector3(0, 0, z);
		GetComponent<Rigidbody2D>().AddForce(transform.up * vars.speed * GetComponent<Rigidbody2D>().mass);
	}

	public override void takeHit() {
//		Instantiate (explosion, transform.position, Quaternion.identity);
		GetComponent<CircleCollider2D> ().enabled = false;
		GetComponentInChildren<ParticleSystem> ().Stop ();
		transform.FindChild ("Red Eyes").gameObject.SetActive (false);
		Invoke ("destroy", GetComponentInChildren<ParticleSystem> ().startLifetime);
		isDying = true;
	}

	private void destroy() {
		Destroy(gameObject);
	}
}
