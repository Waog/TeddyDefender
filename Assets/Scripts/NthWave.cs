using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class NthWave : Wave {

	public int n;
	public GameObject ghostPrefab;
	public GameObject wormPrefab;

	void Start() {
		subwaves = new List<Subwave>();

		Subwave subw1 = new Subwave ();
		subw1.add(new EnemyCountTuple(ghostPrefab, 2 * n));
		subwaves.Add (subw1);

		Subwave subw2 = new Subwave ();
		subw2.add(new EnemyCountTuple(ghostPrefab, n));
		subw2.add(new EnemyCountTuple(wormPrefab, n / 2));
		subwaves.Add (subw2);

		Subwave subw3 = new Subwave ();
		subw3.add(new EnemyCountTuple(ghostPrefab, n / 2));
		subw3.add(new EnemyCountTuple(wormPrefab, n));
		subwaves.Add (subw3);
	}
}
