using UnityEngine;

[System.Serializable]
public class EnemyCountTuple : MonoBehaviour {
	public GameObject enemy;
	public int count;

	public void Spawn()
	{
		for (int enemyIndex = 0; enemyIndex < count; enemyIndex++) {
			SpawnSingle();
		}
	}

	private void SpawnSingle() {

		GameObject[] spawnPoints = GameObject.FindGameObjectsWithTag ("SpawnPoint");

		int spawnPointIndex = Random.Range (0, spawnPoints.Length);

		GameObject newEnemy = (GameObject) Instantiate (enemy, spawnPoints [spawnPointIndex].transform.position, spawnPoints [spawnPointIndex].transform.rotation);
		newEnemy.GetComponent<EnemyVariablesScript> ().player = GameObject.FindGameObjectWithTag ("Player").transform;
		newEnemy.GetComponent<EnemyVariablesScript> ().bed = GameObject.FindGameObjectWithTag ("Bed").transform;
	}
}
