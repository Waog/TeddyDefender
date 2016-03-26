using UnityEngine;

[System.Serializable]
public class Wave : MonoBehaviour {

	public int pauseBetweenSubwaves = 2;

	private Subwave[] subwaves;
	private bool running = false;
	private bool finished = false;

	private int curSubwaveIndex = 0;

	void Start() {
		subwaves = GetComponentsInChildren<Subwave> ();
	}

	public void go() {
		running = true;
		releaseCurSubwave ();
	}

	public bool isFinished () {
		return finished;
	}

	public bool isRunning() {
		return running;
	}

	void Update () {

		if (running && !finished) {
			if (GameObject.FindGameObjectsWithTag("Enemy").Length == 0 && subwaves [curSubwaveIndex].wasReleased()) {
				curSubwaveIndex++;
				if (curSubwaveIndex < subwaves.Length) {
					Invoke ("releaseCurSubwave", pauseBetweenSubwaves);
				} else {
					finished = true;
				}
			}
		}
	}

	void releaseCurSubwave() {
		subwaves [curSubwaveIndex].go ();
	}
}
