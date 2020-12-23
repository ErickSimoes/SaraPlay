using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class MusicController : MonoBehaviour {

    [SerializeField]
    private AudioClip[] audioClips;
    [SerializeField]
    private AudioSource audioSource;
    private int index = 0;

    void Awake() {
        if (GameObject.FindGameObjectsWithTag("Music").Length > 1) {
            Destroy(this.gameObject);
        } else {
            DontDestroyOnLoad(this.gameObject);
        }
    }

    void Start() {
        JsonHelper.Shuffle(audioClips);
        PlayNext();
    }

    void Update() {
        if (audioSource.time == audioSource.clip.length) {
            PlayNext();
        }
    }

    private void PlayNext() {
        if (index >= audioClips.Length) {
            index = 0;
        }

        audioSource.clip = audioClips[index++];
        audioSource.Play();
    }
}
