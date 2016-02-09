using UnityEngine;
using System.Collections;

public class EnemyManager : MonoBehaviour {

	public Transform target;
	public GameObject enemyTemplate;
	public GameObject enemyIndicatorTemplate;
	public float spawnTime = 3f;
	public Transform[] spawnPoints;

	void Start () {
		InvokeRepeating ("Spawn", 0, spawnTime);
	}

	void Spawn () {
		int spawnPointIndex = Random.Range (0, spawnPoints.Length);

		GameObject newEnemy = (GameObject) Instantiate (enemyTemplate, spawnPoints [spawnPointIndex].position, spawnPoints [spawnPointIndex].rotation);
		newEnemy.GetComponent<EnemyScript> ().player = target;
		GameObject newEnemyIndicator = (GameObject) Instantiate (enemyIndicatorTemplate);
		newEnemyIndicator.GetComponent<EnemyIndicatorScript> ().enemy = newEnemy.transform;
		newEnemyIndicator.GetComponent<EnemyIndicatorScript> ().player = target;
	}
}
