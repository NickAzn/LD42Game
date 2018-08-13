using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffCollisionDetection : MonoBehaviour {

    

    public float spawnTime;
    bool failedSpawn = false;
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Wall")
        {
            if (!failedSpawn)
            {
                failedSpawn = true;
                LevelManager.instance.CheckRandomPosBuff();
                Destroy(gameObject);
            }
        }
    }

    private void Start()
    {

    }

    private void Update()
    {
        spawnTime -= Time.deltaTime;
        if (spawnTime < 0)
        {
            LevelManager.instance.SummonBuff(transform.position);
            Destroy(gameObject);
        }

        
    }
}
