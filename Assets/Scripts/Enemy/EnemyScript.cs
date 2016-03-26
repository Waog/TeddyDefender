using UnityEngine;
using System.Collections;

public abstract class EnemyScript : MonoBehaviour
{
	public abstract void takeHit ();

	protected void initiateIndicator() {
		GameObject newEnemyIndicator = (GameObject)Instantiate(GetComponent<EnemyVariablesScript> ().enemyIndicatorPrefab);
		newEnemyIndicator.GetComponent<EnemyIndicatorScript> ().enemy = transform;
		newEnemyIndicator.GetComponent<EnemyIndicatorScript> ().player = GameObject.FindGameObjectWithTag ("Player").transform;
		newEnemyIndicator.GetComponent<SpriteRenderer> ().sprite = GetComponent<EnemyVariablesScript> ().indicatorIcon;
	}
}
