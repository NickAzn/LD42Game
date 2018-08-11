using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

    public Transform target;
    public float movementSpeed;

    public GameObject deathObject;

    float selfDestructTimer;

	// Update is called once per frame
	void Update () {
        
        //Face the target
        float z = Mathf.Atan2((target.position.y - transform.position.y), (target.position.x - transform.position.x)) * Mathf.Rad2Deg - 90;
        transform.eulerAngles = new Vector3(0, 0, z);

        //Move forwards
        transform.position += transform.up * movementSpeed * Time.deltaTime;

        selfDestructTimer += Time.deltaTime;
        if (selfDestructTimer > Random.Range(5f, 6f)) {
            Die();
        }
    }

    public void Die() {
        GameObject deathObj = Instantiate(deathObject);
        Vector3 gridPos = new Vector3((int)transform.position.x, (int)transform.position.y, 0);
        deathObj.transform.position = gridPos;
        Destroy(gameObject);
    }
}
