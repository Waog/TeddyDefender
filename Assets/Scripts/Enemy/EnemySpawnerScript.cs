using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemySpawnerScript : MonoBehaviour {

	public Wave[] waves;
	private int curWaveIndex = 0;
	private float timeWithoutWave = 0;
	private const float TIME_BETWEEN_WAVES = 5f;

	public Transform player;
	public Transform bed;
	public GameObject enemyIndicatorTemplate;

	public Transform[] spawnPoints;

	public UnityEngine.UI.Text wavesText;

	void Update () {
		
		if (waves [curWaveIndex].isFinished ()) {
			curWaveIndex++;
			timeWithoutWave = 0;
		}
	
		if (! waves [curWaveIndex].isRunning()) {
			timeWithoutWave += Time.deltaTime;
		}

		if (! waves [curWaveIndex].isRunning() && timeWithoutWave >= TIME_BETWEEN_WAVES) {
			waves [curWaveIndex].go ();
			wavesText.text = "Wave: " + (curWaveIndex + 1);
		}

	}
}
