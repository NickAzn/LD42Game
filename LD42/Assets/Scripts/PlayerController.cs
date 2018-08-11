using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float movementSpeed;

    public float maxGridSizeX;
    public float maxGridSizeY;

	// Update is called once per frame
	void Update () {
        float xMove = Input.GetAxis("Horizontal");
        float yMove = Input.GetAxis("Vertical");

        //Move
        transform.position += Vector3.right * xMove * movementSpeed * Time.deltaTime;
        transform.position += Vector3.up * yMove * movementSpeed * Time.deltaTime;

        Vector3 clampedPosition = new Vector3(
            Mathf.Clamp(transform.position.x, -maxGridSizeX + .45f, maxGridSizeX - .45f),
            Mathf.Clamp(transform.position.y, -maxGridSizeY + .45f, maxGridSizeY - .45f),
            0);
        transform.position = clampedPosition;
	}
}
