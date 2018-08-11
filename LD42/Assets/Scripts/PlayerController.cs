using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float movementSpeed;

    public float maxGridSizeX;
    public float maxGridSizeY;

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
            Mathf.Clamp(transform.position.x, -maxGridSizeX + .45f, maxGridSizeX - .45f),
            Mathf.Clamp(transform.position.y, -maxGridSizeY + .45f, maxGridSizeY - .45f),
            0);
        transform.position = clampedPosition;
	}
}
