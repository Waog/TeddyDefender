using UnityEngine;
using System.Collections;

public class EnemyScript : MonoBehaviour
{

    public float speed;
    public Transform player;
	public GameObject explosion;
	private float life = 1f;
	private const float MAX_LIFE = 10f;
	private const float LIFE_PER_SECOND = 0.3f;
	private static Vector3 DEFAULT_SCALE = new Vector3 (0.5f, -0.5f, 0.5f);
	private const float MAX_SCALE_FACTOR = 3;

	private float getScaleFactor() {
		return Mathf.Max(0.5f, (life / MAX_LIFE) * MAX_SCALE_FACTOR);
	}

	void Update() {

		life += Time.deltaTime * LIFE_PER_SECOND;
		//life = Mathf.Clamp (life, 0.5f, MAX_LIFE);

		transform.localScale = getScaleFactor() * DEFAULT_SCALE;
	}

    void FixedUpdate()
    {
        float z = Mathf.Atan2((player.transform.position.y - transform.position.y), (player.transform.position.x - transform.position.x)) * Mathf.Rad2Deg - 90;

        transform.eulerAngles = new Vector3(0, 0, z);

		GetComponent<Rigidbody2D>().AddForce(transform.up * speed * GetComponent<Rigidbody2D>().mass * getScaleFactor());
    }

	public void takeHit() {
		life--;

		if (life <= 0) {
			Destroy (gameObject);
			Instantiate (explosion, transform.position, Quaternion.identity);
		} else {
			transform.position += (transform.position - player.position).normalized * 1;
		}
	}
}
