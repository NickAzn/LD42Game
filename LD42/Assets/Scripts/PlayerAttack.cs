using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerAttack : MonoBehaviour {

    public GameObject attackHitBox;
    public float attackCooldown;
    float currentCooldown = 0;
    public ParticleSystem attackReadyParticle;
    bool playedReady = false;

    public AudioClip swingSound;
    public AudioClip potionSound;

    public int WaterCount { get; private set; }
    public GameObject wallDestroyer;
    public int maxWater;
    public Image waterUI;
    public Sprite[] waterStates;
	
	// Update is called once per frame
	void Update () {

        var mousePosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 1));
        float z = Mathf.Atan2((mousePosition.y - transform.position.y), (mousePosition.x - transform.position.x)) * Mathf.Rad2Deg - 90;
        transform.eulerAngles = new Vector3(0, 0, z);

        if (currentCooldown > 0) {
            currentCooldown -= Time.deltaTime;
            if (currentCooldown < attackReadyParticle.main.startLifetime.constantMax && !playedReady) {
                attackReadyParticle.Emit(1);
                playedReady = true;
            }
        }

        if (Input.GetButtonDown("Fire1") && currentCooldown <= 0){
            SoundManager.instance.PlaySoundEffect(swingSound);
            currentCooldown = attackCooldown;
            playedReady = false;
            GameObject attackMove = Instantiate(attackHitBox, transform.position, transform.rotation);
            attackMove.transform.position = transform.position + transform.up * .5f;
            attackMove.GetComponent<PlayerAttackHitbox>().player = transform;
        }

        if (Input.GetButtonDown("Fire2") && WaterCount > 0) {
            SoundManager.instance.PlaySoundEffect(potionSound);
            GainWater(-1);
            GameObject wd = Instantiate(wallDestroyer);
            wd.transform.position = transform.position;
        }
    }

    public void GainWater(int amt) {
        WaterCount += amt;
        if (WaterCount > maxWater)
            WaterCount = maxWater;

        waterUI.sprite = waterStates[WaterCount];
    }
}
