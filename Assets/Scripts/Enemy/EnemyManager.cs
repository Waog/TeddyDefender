using UnityEngine;
using System.Collections;

public class EnemyManager : MonoBehaviour {

	//public PlayerHealth playerHealth;
	public Transform target;
	public GameObject enemyTemplate;
	public float spawnTime = 3f;
	public Transform[] spawnPoints;

	void Start () {
		InvokeRepeating ("Spawn", 0, spawnTime);
	}

	void Spawn () {
	//	if (playerHealth.currentHealth <= 0f) {
	//		return;
	//	}

		int spawnPointIndex = Random.Range (0, spawnPoints.Length);

		GameObject newEnemy = (GameObject) Instantiate (enemyTemplate, spawnPoints [spawnPointIndex].position, spawnPoints [spawnPointIndex].rotation);
		newEnemy.GetComponent<EnemyScript> ().player = target;
	}
}
