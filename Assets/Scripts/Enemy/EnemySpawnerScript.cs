using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemySpawnerScript : MonoBehaviour {

	public UnityEngine.UI.Text wavesText;

	private Wave[] waves;
	private int curWaveIndex = 0;
	private float timeWithoutWave = 0;
	private const float TIME_BETWEEN_WAVES = 5f;


	void Start() {
		waves = GetComponentsInChildren<Wave> ();
	}

	void Update () {
		if (curWaveIndex < waves.Length) {
			if (waves [curWaveIndex].isFinished ()) {
				curWaveIndex++;
				timeWithoutWave = 0;
				if (curWaveIndex >= waves.Length) {
					return;
				}
			}
	
			if (!waves [curWaveIndex].isRunning ()) {
				timeWithoutWave += Time.deltaTime;
			}

			if (!waves [curWaveIndex].isRunning () && timeWithoutWave >= TIME_BETWEEN_WAVES) {
				waves [curWaveIndex].go ();
				wavesText.text = "Wave: " + (curWaveIndex + 1);
			}
		}
	}
}
