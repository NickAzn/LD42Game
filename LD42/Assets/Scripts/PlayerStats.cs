using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour {

    public GameObject Heart1;
    public GameObject Heart2;
    public GameObject Heart3;
    public GameObject Heart4;
    public GameObject Heart5;

    public Sprite EmptyHeart;
    public Sprite Fullheart;

    public AudioClip HealSound;
    public AudioClip PotionCollectSound;
    public AudioClip hitSound;

    public Sprite DamageState0;
    public Sprite DamageState1;
    public Sprite DamageState2;
    public Sprite DamageState3;
    public Sprite DamageState4;

    public int player_health;

    public float hitInvulTime;
    float invulTimer = 0f;

    void OnCollisionStay2D(Collision2D col) {
        if (col.gameObject.tag == "Enemy" && invulTimer <= 0f) {
            TakeDamage(1);
        }
    }

    public void TakeDamage(int amount) {
        player_health -= amount;
        LevelManager.instance.ScreenShake(.1f, .15f);
        SoundManager.instance.PlaySoundEffect(hitSound);
        invulTimer = hitInvulTime;

        if (player_health == 4) {
            Heart1.GetComponent<Image>().sprite = EmptyHeart;
            this.GetComponent<SpriteRenderer>().sprite = DamageState1;
        } else if (player_health == 3) {
            Heart2.GetComponent<Image>().sprite = EmptyHeart;
            this.GetComponent<SpriteRenderer>().sprite = DamageState2;
        } else if (player_health == 2) {
            Heart3.GetComponent<Image>().sprite = EmptyHeart;
            this.GetComponent<SpriteRenderer>().sprite = DamageState3;
        } else if (player_health == 1) {
            Heart4.GetComponent<Image>().sprite = EmptyHeart;
            this.GetComponent<SpriteRenderer>().sprite = DamageState4;
        }

        if (player_health <= 0) {
            Heart5.GetComponent<Image>().sprite = EmptyHeart;
            LevelManager.instance.EndGame();
        }
    }

    private void OnTriggerStay2D(Collider2D col) {
        if (col.gameObject.tag == "HealthBuff") {
            if (player_health == 5) {
                return;
            } else if (player_health == 4) {
                player_health++;
                Heart1.GetComponent<Image>().sprite = Fullheart;
                this.GetComponent<SpriteRenderer>().sprite = DamageState0;
                Destroy(col.gameObject);
            } else if (player_health == 3) {
                player_health++;
                Heart2.GetComponent<Image>().sprite = Fullheart;
                this.GetComponent<SpriteRenderer>().sprite = DamageState1;
                Destroy(col.gameObject);
            } else if (player_health == 2) {
                player_health++;
                Heart3.GetComponent<Image>().sprite = Fullheart;
                this.GetComponent<SpriteRenderer>().sprite = DamageState2;
                Destroy(col.gameObject);
            } else if (player_health == 1) {
                player_health++;
                Heart4.GetComponent<Image>().sprite = Fullheart;
                this.GetComponent<SpriteRenderer>().sprite = DamageState3;
                Destroy(col.gameObject);
            }
            SoundManager.instance.PlaySoundEffect(HealSound);
        } else if (col.gameObject.tag == "Water") {
            PlayerAttack atkStats = GetComponent<PlayerAttack>();
            if (atkStats.WaterCount < atkStats.maxWater) {
                atkStats.GainWater(1);
                SoundManager.instance.PlaySoundEffect(PotionCollectSound);
                Destroy(col.gameObject);
            }
        }
    }

    private void Update() {
        if (invulTimer > 0f)
            invulTimer -= Time.deltaTime;
    }
}
