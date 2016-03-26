using UnityEngine;

[System.Serializable]
public class Subwave : MonoBehaviour {
	public EnemyCountTuple[] enemyCountTuples;

	private bool released = false;

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
