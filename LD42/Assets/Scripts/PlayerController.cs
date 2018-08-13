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
        if (!LevelManager.instance.GameStarted && (xMove != 0 || yMove != 0))
            LevelManager.instance.StartGame();

        //Move using rigidbody
        rb.velocity = new Vector2(xMove * movementSpeed, yMove * movementSpeed);

        Vector3 clampedPosition = new Vector3(
            Mathf.Clamp(transform.position.x, -LevelManager.instance.maxGridSizeX + .5f, LevelManager.instance.maxGridSizeX - .5f),
            Mathf.Clamp(transform.position.y, -LevelManager.instance.maxGridSizeY + .5f, LevelManager.instance.maxGridSizeY - .5f),
            0);
        transform.position = clampedPosition;
    }
}
