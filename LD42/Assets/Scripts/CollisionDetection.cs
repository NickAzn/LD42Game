using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetection : MonoBehaviour {

    public float showTime;
    public SpriteRenderer spriteRenderer;

    public float spawnTime;
    bool failedSpawn = false;
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Wall")
        {
            if (!failedSpawn) {
                failedSpawn = true;
                LevelManager.instance.CheckRandomPos();
                Destroy(gameObject);
            }
        }
    }

    private void Start() {
        spriteRenderer.enabled = false;
    }

    private void Update() {
        spawnTime -= Time.deltaTime;
        if (spawnTime < 0) {
            LevelManager.instance.SummonDemon(transform.position);
            Destroy(gameObject);
        }

        showTime -= Time.deltaTime;
        if (showTime < 0) {
            spriteRenderer.enabled = true;
        }
    }
}