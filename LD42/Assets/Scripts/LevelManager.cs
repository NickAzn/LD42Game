using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour {

    public GameObject enemyDemon;
    public GameObject player;
    public GameObject testDemon;
    public GameObject endText;
    public Shake camShaker;

    public float shakeTime;
    public float shakeMag;

    private float nextWaveTime = 0.0f;
    public float period = 5f;

    public float maxGridSizeX;
    public float maxGridSizeY;

    // Use this for initialization
    public static LevelManager instance;
    void Start() {
        instance = this;

        endText.GetComponent<Text>().enabled = false;
    }

    // Update is called once per frame
    void Update() {
        nextWaveTime -= Time.deltaTime;
        if (nextWaveTime <= 0)
        {
            nextWaveTime += period;

            for (int i = 0; i < 3; i++)
            {
                CheckRandomPos();
            }
        }
    }

    public void SummonDemon(Vector3 position){

        GameObject demon = Instantiate(enemyDemon);
        demon.transform.position = position;
        demon.GetComponent<EnemyController>().target = player.GetComponent<Transform>();
    }

    public void CheckRandomPos() {
        Vector3 position = new Vector3(Random.Range(-maxGridSizeX + .4f, maxGridSizeX - .4f), Random.Range(-maxGridSizeY + .4f, maxGridSizeY - .4f), 0);
        position = SnapToGrid(position);
        GameObject fakeDemon = Instantiate(testDemon);
        fakeDemon.transform.position = position;
    }

    //Snaps given position to a grid position
    public static Vector3 SnapToGrid(Vector3 position) {
        float gridPosX = Mathf.Round(position.x * 2) / 2;
        float gridPosY = Mathf.Round(position.y * 2) / 2;
        if (Mathf.Abs(gridPosX - (int)gridPosX) < .05f) {
            float originalDecimal = position.x - (int)position.x;
            if (Mathf.Abs(originalDecimal) < .5f) {
                if (originalDecimal >= 0) {
                    gridPosX += .5f;
                } else {
                    gridPosX -= .5f;
                }
            } else {
                if (originalDecimal <= 0) {
                    gridPosX += .5f;
                } else {
                    gridPosX -= .5f;
                }
            }
        }

        if (Mathf.Abs(gridPosY - (int)gridPosY) < .05f) {
            float originalDecimal = position.y - (int)position.y;
            if (Mathf.Abs(originalDecimal) < .5f) {
                if (originalDecimal >= 0) {
                    gridPosY += .5f;
                } else {
                    gridPosY -= .5f;
                }
            } else {
                if (originalDecimal <= 0) {
                    gridPosY += .5f;
                } else {
                    gridPosY -= .5f;
                }
            }
        }

        return new Vector3(gridPosX, gridPosY, 0);
    }

    public void ScreenShake() {
        camShaker.StartCoroutine(camShaker.StartShake(shakeTime, shakeMag));
    }


}
