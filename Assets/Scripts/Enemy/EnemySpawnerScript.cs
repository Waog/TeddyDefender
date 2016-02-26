using UnityEngine;
using System.Collections;

public class EnemySpawnerScript : MonoBehaviour {

	public Transform player;
	public Transform bed;
	public GameObject enemyTemplate;
	public GameObject enemyIndicatorTemplate;

	public float spawnTimeStart;
	public float spawnTimeEnd;
	public float spawnTimeInterpolationStart;
	public float spawnTimeInterpolationEnd;

	public Transform[] spawnPoints;

	void Start () {
		// InvokeRepeating ("Spawn", 0, spawnTime);
		float spawnTime = getSpawnTime ();
		Invoke ("Spawn", spawnTime	);
	}

	void Spawn () {
		int spawnPointIndex = Random.Range (0, spawnPoints.Length);

		GameObject newEnemy = (GameObject) Instantiate (enemyTemplate, spawnPoints [spawnPointIndex].position, spawnPoints [spawnPointIndex].rotation);
		newEnemy.GetComponent<EnemyVariablesScript> ().player = player;
		newEnemy.GetComponent<EnemyVariablesScript> ().bed = bed;

		GameObject newEnemyIndicator = (GameObject) Instantiate (enemyIndicatorTemplate);
		newEnemyIndicator.GetComponent<EnemyIndicatorScript> ().enemy = newEnemy.transform;
		newEnemyIndicator.GetComponent<EnemyIndicatorScript> ().player = player;

		Invoke ("Spawn", getSpawnTime ());
	}

	private float getSpawnTime() {
		if (Time.timeSinceLevelLoad < spawnTimeInterpolationStart) {
			return spawnTimeStart;
		} else if (Time.timeSinceLevelLoad > spawnTimeInterpolationEnd) {
			return spawnTimeEnd;
		} else {
			float m = (spawnTimeStart - spawnTimeEnd) / (spawnTimeInterpolationStart - spawnTimeInterpolationEnd);
			float n = spawnTimeStart - m * spawnTimeInterpolationStart;
			return m * Time.timeSinceLevelLoad + n;
		}
	}
}
