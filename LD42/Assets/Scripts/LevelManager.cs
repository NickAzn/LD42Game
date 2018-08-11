using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {

    public GameObject enemyDemon;
    public GameObject player;
    public GameObject testDemon;

    private float nextWaveTime = 0.0f;
    public float period = 5f;

    // Use this for initialization
    public static LevelManager instance;
    void Start() {
        instance = this;
    }

    // Update is called once per frame
    void Update() {
        if (Time.time > nextWaveTime)
        {
            nextWaveTime += period;

            for (int i = 0; i < 3; i++)
            {
                Vector3 position = new Vector3(Random.Range(-5.5f, 5.5f), Random.Range(-4.5f, 4.5f), 0);

                /* GameObject fakeDemon = Instantiate(testDemon);
                fakeDemon.transform.position = position; */


                SummonDemon(position);
            }
        }
    }

    public void SummonDemon(Vector3 position){

        GameObject demon = Instantiate(enemyDemon);
        demon.transform.position = position;
        demon.GetComponent<EnemyController>().target = player.GetComponent<Transform>();
    }


}
