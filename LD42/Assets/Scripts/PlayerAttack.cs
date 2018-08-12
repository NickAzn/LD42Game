using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour {

    public GameObject attackHitBox;
    public float attackCooldown;
    float currentCooldown = 0;
	
	// Update is called once per frame
	void Update () {

        var mousePosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 1));
        float z = Mathf.Atan2((mousePosition.y - transform.position.y), (mousePosition.x - transform.position.x)) * Mathf.Rad2Deg - 90;
        transform.eulerAngles = new Vector3(0, 0, z);

        if (currentCooldown > 0)
            currentCooldown -= Time.deltaTime;

        if (Input.GetButtonDown("Fire1") && currentCooldown <= 0){
            currentCooldown = attackCooldown;
            GameObject attackMove = Instantiate(attackHitBox, transform.position, transform.rotation);
            attackMove.transform.position = transform.position + transform.up * .5f;
            attackMove.GetComponent<PlayerAttackHitbox>().player = transform;
        }
    }
}
