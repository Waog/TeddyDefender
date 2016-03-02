using UnityEngine;
using System.Collections;

public class SwordScript : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
		if (other.gameObject.tag.Equals ("Enemy")) {
			other.gameObject.GetComponent<EnemyScript> ().takeHit ();
		}
    }
}
