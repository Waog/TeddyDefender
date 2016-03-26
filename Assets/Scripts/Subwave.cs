using UnityEngine;

[System.Serializable]
public class Subwave : MonoBehaviour {

	private EnemyCountTuple[] enemyCountTuples;
	private bool released = false;

	void Start() {
		enemyCountTuples = GetComponentsInChildren<EnemyCountTuple> ();
	}

	public void go()
	{
		foreach (EnemyCountTuple enemyCountTuple in enemyCountTuples) {
			enemyCountTuple.Spawn ();
		}
		released = true;
	}

	public bool wasReleased() {
		return released;
	}
}
