using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackHitbox : MonoBehaviour {

    public float selfDestuctTime;

    private void OnTriggerEnter2D(Collider2D collision) {
        //If the hitbox collides with an enemy, kill the enemy
        if (collision.tag.Equals("Enemy")) {
            collision.GetComponent<EnemyController>().Die();
        }
    }

    private void Update() {
        //Count down self destruct time, then destroy object at 0
        selfDestuctTime -= Time.deltaTime;
        if (selfDestuctTime <= 0f)
            Destroy(gameObject);
    }
}
