using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class AwakeKidScript : MonoBehaviour {

	public Animator gameOverAnimator;
	public SceneTimer sceneTimer;
	public Slider sleepmeter;
	public float damagePerSecondPerMonster = 0.1f;
	public float regenerationPerSecond = 0.01f;

	void OnTriggerStay2D(Collider2D other)
	{
		if (other.gameObject.tag.Equals ("Enemy")) {
			//other.gameObject.GetComponent<EnemyScript> ().takeHit ();
			//AwakeGameOverWidget.SetActive(true);


			sleepmeter.value -= damagePerSecondPerMonster * Time.deltaTime;

			if (sleepmeter.value <= 0) {
				gameOverAnimator.SetTrigger("GameOver");
				sceneTimer.freezeTimer ();
			}
		}
	}

	void Update() {
		sleepmeter.value += regenerationPerSecond * Time.deltaTime;
	}
}
