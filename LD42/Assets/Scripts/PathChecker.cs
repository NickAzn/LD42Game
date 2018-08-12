using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathChecker : MonoBehaviour {

    public bool pathAvailable = true;

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.tag.Equals("Wall")) {
            pathAvailable = false;
        }
    }
}
