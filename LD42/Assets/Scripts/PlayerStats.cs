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

    public int player_health;

    public float hitInvulTime;
    float invulTimer = 0f;

    void OnCollisionStay2D(Collision2D col)
    {
        if (col.gameObject.tag == "Enemy" && invulTimer <= 0f)
        {
            player_health = player_health - 1;
            LevelManager.instance.ScreenShake(.1f, .15f);
            invulTimer = hitInvulTime;

            if(player_health == 4)
            {
                Heart1.GetComponent<Image>().sprite = EmptyHeart;
            } else if(player_health == 3)
            {
                Heart2.GetComponent<Image>().sprite = EmptyHeart;
            } else if(player_health == 2)
            {
                Heart3.GetComponent<Image>().sprite = EmptyHeart;
            } else if(player_health == 1)
            {
                Heart4.GetComponent<Image>().sprite = EmptyHeart;
            }

            if (player_health <= 0)
            {
                Heart5.GetComponent<Image>().sprite = EmptyHeart;
                LevelManager.instance.EndGame();
            }
        }
    }

    private void Update() {
        if (invulTimer > 0f)
            invulTimer -= Time.deltaTime;
    }
}
