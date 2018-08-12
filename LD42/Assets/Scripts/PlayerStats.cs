using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerStats : MonoBehaviour {

    public GameObject endText;

    public int player_health;

	// Use this for initialization
	void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {

	}

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Enemy")
        {
            Debug.Log("Touched Enemy");
            player_health = player_health - 1;

            if (player_health <= 0)
            {
                endText.GetComponent<Text>().enabled = true;
                Debug.Log("Game Ended");
                //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
    }
}
