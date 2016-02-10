using UnityEngine;
using System.Collections;

public class SquishyMonsterScript : EnemyScript
{
	public GameObject explosion;

	private EnemyVariablesScript vars;

	void Start() {
		vars = GetComponent<EnemyVariablesScript> ();
	}

	void FixedUpdate()
	{
		float z = Mathf.Atan2((vars.bed.transform.position.y - transform.position.y), (vars.bed.transform.position.x - transform.position.x)) * Mathf.Rad2Deg - 90;
		transform.eulerAngles = new Vector3(0, 0, z);
		GetComponent<Rigidbody2D>().AddForce(transform.up * vars.speed * GetComponent<Rigidbody2D>().mass);
	}

	public override void takeHit() {
			Destroy (gameObject);
			Instantiate (explosion, transform.position, Quaternion.identity);
	}
}
