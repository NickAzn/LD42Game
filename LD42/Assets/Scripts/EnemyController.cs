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

        Vector3 clampedPosition = new Vector3(
            Mathf.Clamp(transform.position.x, -LevelManager.instance.maxGridSizeX + .45f, LevelManager.instance.maxGridSizeX - .45f),
            Mathf.Clamp(transform.position.y, -LevelManager.instance.maxGridSizeY + .45f, LevelManager.instance.maxGridSizeY - .45f),
            0);
        transform.position = clampedPosition;

        /*
        selfDestructTimer += Time.deltaTime;
        if (selfDestructTimer > Random.Range(5f, 6f)) {
            Die();
        }
        */
    }

    public void Die() {
        LevelManager.instance.ScreenShake();
        GameObject deathObj = Instantiate(deathObject);
        deathObj.transform.position = LevelManager.SnapToGrid(transform.position);
        Destroy(gameObject);
    }
}
