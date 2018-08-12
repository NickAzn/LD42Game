using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float movementSpeed;

    private Rigidbody2D rb;

    private void Start() {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update () {
        float xMove = Input.GetAxis("Horizontal");
        float yMove = Input.GetAxis("Vertical");

        //Move using rigidbody
        rb.velocity = new Vector2(xMove * movementSpeed, yMove * movementSpeed);

        Vector3 clampedPosition = new Vector3(
            Mathf.Clamp(transform.position.x, -LevelManager.instance.maxGridSizeX + .45f, LevelManager.instance.maxGridSizeX - .45f),
            Mathf.Clamp(transform.position.y, -LevelManager.instance.maxGridSizeY + .45f, LevelManager.instance.maxGridSizeY - .45f),
            0);
        transform.position = clampedPosition;
    }
}
