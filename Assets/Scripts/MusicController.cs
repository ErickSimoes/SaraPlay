using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class MusicController : MonoBehaviour {

    public static string TOGGLE_STATE = "toggle_state";

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

        if (PlayerPrefs.HasKey(TOGGLE_STATE)) {
            if (PlayerPrefs.GetInt(TOGGLE_STATE) == 1) {
                audioSource.Play();
            }
        }
    }

    public void OnOff(bool onOff) {
        if (onOff) {
            audioSource.Play();
        } else {
            audioSource.Pause();
        }

        PlayerPrefs.SetInt(TOGGLE_STATE, onOff ? 1 : 0);
    }
}
