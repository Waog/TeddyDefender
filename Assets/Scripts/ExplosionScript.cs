using UnityEngine;
using System.Collections;

public class ExplosionScript : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        Invoke("Die", 1);
    }

    void Die()
    {
        Destroy(gameObject);
    }
}
