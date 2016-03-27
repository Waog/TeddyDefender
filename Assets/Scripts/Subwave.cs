using UnityEngine;
using System.Collections.Generic;
using System.Linq;

[System.Serializable]
public class Subwave : MonoBehaviour {

	private List<EnemyCountTuple> enemyCountTuples;
	private bool released = false;

	void Start() {
		enemyCountTuples = GetComponentsInChildren<EnemyCountTuple> ().OfType<EnemyCountTuple> ().ToList ();
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

	public void add(EnemyCountTuple enemyCountTuple) {
		enemyCountTuples.Add (enemyCountTuple);
	}
}
