using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	// Update is called once per frame
	void Update () {
        float xMove = Input.GetAxis("Horizontal");
        float yMove = Input.GetAxis("Vertical");

        transform.position += Vector3.right * xMove;
        transform.position += Vector3.up * yMove;
	}
}
