using UnityEngine;
using System.Collections;

public abstract class EnemyScript : MonoBehaviour
{
	public abstract void takeHit ();



	protected void init() {

		GetComponent<EnemyVariablesScript> ().player = GameObject.FindGameObjectWithTag ("Player").transform;
		GetComponent<EnemyVariablesScript> ().bed = GameObject.FindGameObjectWithTag ("Bed").transform;

		GameObject newEnemyIndicator = (GameObject)Instantiate(GetComponent<EnemyVariablesScript> ().enemyIndicatorPrefab);
		newEnemyIndicator.GetComponent<EnemyIndicatorScript> ().enemy = transform;
		newEnemyIndicator.GetComponent<EnemyIndicatorScript> ().player = GameObject.FindGameObjectWithTag ("Player").transform;
		newEnemyIndicator.GetComponent<SpriteRenderer> ().sprite = GetComponent<EnemyVariablesScript> ().indicatorIcon;
	}
}
