using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float movementSpeed;

	// Update is called once per frame
	void Update () {
        float xMove = Input.GetAxis("Horizontal");
        float yMove = Input.GetAxis("Vertical");

        //Move
        transform.position += Vector3.right * xMove * movementSpeed * Time.deltaTime;
        transform.position += Vector3.up * yMove * movementSpeed * Time.deltaTime;
	}
}
