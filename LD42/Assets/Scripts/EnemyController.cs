using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

    public Transform target;
    public float movementSpeed;

    public GameObject deathObject;

    private Rigidbody2D rb;

    //float selfDestructTimer;

    private void Start() {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update () {
        
        //Face the target
        float z = Mathf.Atan2((target.position.y - transform.position.y), (target.position.x - transform.position.x)) * Mathf.Rad2Deg - 90;
        transform.eulerAngles = new Vector3(0, 0, z);

        rb.velocity = transform.up * movementSpeed;

        /*
        selfDestructTimer += Time.deltaTime;
        if (selfDestructTimer > Random.Range(5f, 6f)) {
            Die();
        }
        */
    }

    public void Die() {
        GameObject deathObj = Instantiate(deathObject);
        
        //Set death object onto the grid
        float gridPosX = Mathf.Round(transform.position.x * 2) / 2;
        float gridPosY = Mathf.Round(transform.position.y * 2) / 2;
        if (Mathf.Abs(gridPosX - (int)gridPosX) < .05f) {
            float originalDecimal = transform.position.x - (int)transform.position.x;
            if (Mathf.Abs(originalDecimal) < .5f) {
                if (originalDecimal >= 0) {
                    gridPosX += .5f;
                } else {
                    gridPosX -= .5f;
                }
            } else {
                if (originalDecimal <= 0) {
                    gridPosX += .5f;
                } else {
                    gridPosX -= .5f;
                }
            }
        }

        if (Mathf.Abs(gridPosY - (int)gridPosY) < .05f) {
            float originalDecimal = transform.position.y - (int)transform.position.y;
            if (Mathf.Abs(originalDecimal) < .5f) {
                if (originalDecimal >= 0) {
                    gridPosY += .5f;
                } else {
                    gridPosY -= .5f;
                }
            } else {
                if (originalDecimal <= 0) {
                    gridPosY += .5f;
                } else {
                    gridPosY -= .5f;
                }
            }
        }
        Vector3 gridPos = new Vector3(gridPosX, gridPosY, 0);
        deathObj.transform.position = gridPos;
        Destroy(gameObject);
    }
}
