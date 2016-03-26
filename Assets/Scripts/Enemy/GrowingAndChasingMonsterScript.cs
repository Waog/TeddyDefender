using UnityEngine;
using System.Collections;

public class GrowingAndChasingMonsterScript : EnemyScript
{

	public GameObject explosion;
	private float life = 1f;
	public float MAX_LIFE;
	public float LIFE_PER_SECOND;
	public float RECOIL_DISTANCE = 0.5f;

	private EnemyVariablesScript vars;
	private Transform target;
	private static Vector3 DEFAULT_SCALE = new Vector3 (0.5f, 0.5f, 0.5f);
	private const float MAX_SCALE_FACTOR = 3;

	private float getScaleFactor() {
		return Mathf.Max(0.5f, (life / MAX_LIFE) * MAX_SCALE_FACTOR);
	}


	void Start() {
		init ();
		vars = GetComponent<EnemyVariablesScript> ();
		target = vars.bed;
	}

	void Update() {

		life += Time.deltaTime * LIFE_PER_SECOND;
		life = Mathf.Clamp (life, 0f, MAX_LIFE);

		transform.localScale = getScaleFactor() * DEFAULT_SCALE;
	}

    void FixedUpdate()
    {
        float z = Mathf.Atan2((target.transform.position.y - transform.position.y), (target.transform.position.x - transform.position.x)) * Mathf.Rad2Deg - 90;

        transform.eulerAngles = new Vector3(0, 0, z);

		GetComponent<Rigidbody2D>().AddForce(transform.up * vars.speed * GetComponent<Rigidbody2D>().mass * getScaleFactor());
    }

	public override void takeHit() {
		life--;
		target = vars.player;

		if (life <= 0) {
			Destroy (gameObject);
			Instantiate (explosion, transform.position, Quaternion.identity);
		} else {
			transform.position += (transform.position - target.position).normalized * RECOIL_DISTANCE;
		}
	}
}
