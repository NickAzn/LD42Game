using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetection : MonoBehaviour {

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Wall")
        {
            Vector3 position = new Vector3(Random.Range(-5.5f, 5.5f), Random.Range(-4.5f, 4.5f), 0);
            Destroy(gameObject);
            LevelManager.instance.SummonDemon(position);
        }
    }
}
