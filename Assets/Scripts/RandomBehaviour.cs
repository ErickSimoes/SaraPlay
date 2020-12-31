using System.Collections;
using TMPro;
using UnityEngine;

public class RandomBehaviour : MonoBehaviour {

    private string[] names;
    [SerializeField]
    private TextMeshProUGUI text;
    private int index = 0;
    private AudioSource audioSource;
    [SerializeField]
    private AudioClip nextClip, choiceClip;

    void Start() {
        audioSource = GetComponent<AudioSource>();

        names = DataController.Read2TextBox();
        JsonHelper.Shuffle(names);
    }

    public void StartSortName() {
        StartCoroutine(ChooseName());
    }

    private IEnumerator ChooseName() {

        int max = 10;
        if (names.Length < 10) {
            max = names.Length - 1;
        }

        audioSource.clip = nextClip;

        for (int i = 0; i < max; i++) {
            text.text = names[i];
            
            if (PlayerPrefs.GetInt(MusicController.TOGGLE_STATE) == 1) {
                audioSource.Play();
            }
            yield return new WaitForSeconds(.15f);
        }

        audioSource.clip = choiceClip;
        if (PlayerPrefs.GetInt(MusicController.TOGGLE_STATE) == 1) {
            audioSource.Play();
        }

        text.text = names[index++];

        if (index >= names.Length) {
            index = 0;
        }
    }

}
