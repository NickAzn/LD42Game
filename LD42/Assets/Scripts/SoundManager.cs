using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {

    public static SoundManager instance;

    public AudioSource music;
    public AudioSource sfx;

    private void Start() {
        if (instance == null) {
            instance = this;
            DontDestroyOnLoad(gameObject);
        } else {
            Destroy(gameObject);
        }

        if (PlayerPrefs.GetInt("MusicMuted", 0) == 1)
            music.volume = 0;

        if (PlayerPrefs.GetInt("SfxMuted", 0) == 1)
            sfx.volume = 0;
    }

    public void PlaySoundEffect(AudioClip clip) {
        sfx.PlayOneShot(clip);
    }

    public void MuteMusic() {
        if (PlayerPrefs.GetInt("MusicMuted", 0) == 0) {
            music.volume = 0;
            PlayerPrefs.SetInt("MusicMuted", 1);
        } else {
            music.volume = 1;
            PlayerPrefs.SetInt("MusicMuted", 0);
        }
    }

    public void MuteSfx() {
        if (PlayerPrefs.GetInt("SfxMuted", 0) == 0) {
            sfx.volume = 0;
            PlayerPrefs.SetInt("SfxMuted", 1);
        } else {
            sfx.volume = 1;
            PlayerPrefs.SetInt("SfxMuted", 0);
        }
    }
}