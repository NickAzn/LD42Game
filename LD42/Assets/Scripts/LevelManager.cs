using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

    public GameObject enemyDemon;
    public GameObject player;
    public GameObject testDemon;
    public GameObject endScreen;
    public Shake camShaker;

    private float nextWaveTime = 0.0f;
    public float period = 5f;

    public float maxGridSizeX;
    public float maxGridSizeY;

    public Text scoreText;
    public Text highscoreText;
    int score = 0;

    Vector3 cameraPos;

    // Use this for initialization
    public static LevelManager instance;
    void Start() {
        instance = this;

        cameraPos = camShaker.transform.position;
        endScreen.SetActive(false);

        Debug.Log((int)-0.5f);
    }

    // Update is called once per frame
    void Update() {
        scoreText.text = score.ToString();

        nextWaveTime -= Time.deltaTime;
        if (nextWaveTime <= 0)
        {
            nextWaveTime += period;

            for (int i = 0; i < 3; i++)
            {
                CheckRandomPos();
            }
        }
        if (!camShaker.shaking && transform.position != cameraPos) {
            camShaker.transform.position = cameraPos;
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

    //Shake the screen
    public void ScreenShake(float duration, float magnitude) {
        camShaker.StartCoroutine(camShaker.StartShake(duration, magnitude));
    }

    //Increase score by value
    public void IncreaseScore(int value) {
        score += value;
    }

    //Restarts the game
    public void RestartGame() {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    //Shows end screen and pauses the game
    public void EndGame() {
        endScreen.SetActive(true);
        Time.timeScale = 0f;
        ScreenShake(.2f, .15f);

        int highscore = PlayerPrefs.GetInt("Highscore", 0);
        highscoreText.text = "High Score: " + highscore.ToString();
        if (score > highscore) {
            highscore = score;
            PlayerPrefs.SetInt("Highscore", highscore);
            highscoreText.text = "New High Score! " + highscore.ToString();
        }

    }

}
