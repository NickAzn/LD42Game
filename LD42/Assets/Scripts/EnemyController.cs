using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

    public Transform target;
    public float movementSpeed;

    public GameObject deathObject;
    public GameObject deathParticles;

    public AudioClip teleportSound;
    public AudioClip deathSound;

    private Rigidbody2D rb;

    public float deathShakeTime;
    public float deathShakeMag;

    private Vector3 targetOffset;
    private Vector3 movementTarget;

    public int scoreValue;
    public bool ChannelingExit { get; private set; }
    public float exitChannelTime;
    float currentChannelTime;
    public ParticleSystem exitChannelParticles;
    public GameObject exitBurstParticles;

    //float selfDestructTimer;

    private void Start() {
        ChannelingExit = false;
        rb = GetComponent<Rigidbody2D>();
        targetOffset = new Vector3(Random.Range(-.5f, .5f), Random.Range(-.5f, .5f), 0);
    }

    // Update is called once per frame
    void Update () {
        movementTarget = target.position + targetOffset;

        //Rotate towards target
        if (!ChannelingExit) {
            float z = Mathf.Atan2((movementTarget.y - transform.position.y), (movementTarget.x - transform.position.x)) * Mathf.Rad2Deg - 90;
            transform.eulerAngles = new Vector3(0, 0, z);
            rb.velocity = transform.up * movementSpeed;
        } else {
            rb.velocity = Vector3.zero;
            rb.MoveRotation(rb.rotation + 180 * Time.deltaTime);
            currentChannelTime += Time.deltaTime;
            if (currentChannelTime >= exitChannelTime) {
                ExitMap();
            }
        }

        Vector3 clampedPosition = new Vector3(
            Mathf.Clamp(transform.position.x, -LevelManager.instance.maxGridSizeX + .45f, LevelManager.instance.maxGridSizeX - .45f),
            Mathf.Clamp(transform.position.y, -LevelManager.instance.maxGridSizeY + .45f, LevelManager.instance.maxGridSizeY - .45f),
            0);
        transform.position = clampedPosition;

        /*
        selfDestructTimer += Time.deltaTime;
        if (selfDestructTimer > Random.Range(5f, 6f)) {
            Die();
        }
        */
    }

    //Enemy death
    public void Die() {
        LevelManager.instance.ScreenShake(deathShakeTime, deathShakeMag);
        SoundManager.instance.PlaySoundEffect(deathSound);
        LevelManager.instance.IncreaseScore(scoreValue);
        LevelManager.instance.EnemyDied(gameObject);
        GameObject deathPrt = Instantiate(deathParticles);
        deathPrt.transform.position = transform.position;
        GameObject deathObj = Instantiate(deathObject);
        deathObj.transform.position = LevelManager.SnapToGrid(transform.position);
        Destroy(gameObject);
    }

    public void ChannelExit() {
        ChannelingExit = true;
        exitChannelParticles.Play();
        InvokeRepeating("PlaySound", 0, teleportSound.length);
    }

    public void CancelChannel() {
        ChannelingExit = false;
        currentChannelTime = 0;
        exitChannelParticles.Stop();
        CancelInvoke();

    }

    public void ExitMap() {
        LevelManager.instance.EnemyExitHit();
        GameObject exitPrt = Instantiate(exitBurstParticles);
        exitPrt.transform.position = transform.position;
        Destroy(gameObject);
    }

    private void PlaySound()
    {
        SoundManager.instance.PlaySoundEffect(teleportSound);
    }
}
