using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestruct : MonoBehaviour {

    public float selfDestructTime;
	
	// Update is called once per frame
	void Update () {
        selfDestructTime -= Time.deltaTime;
        if (selfDestructTime <= 0f)
            Destroy(gameObject);
	}
}
