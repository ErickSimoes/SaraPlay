using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Toggle))]
public class MusicToggleController : MonoBehaviour {

    private Toggle toggle;
    private MusicController musicController;

    void Start() {
        toggle = GetComponent<Toggle>();

        if (PlayerPrefs.HasKey(MusicController.TOGGLE_STATE)) {
            int state = PlayerPrefs.GetInt(MusicController.TOGGLE_STATE);
            toggle.isOn = state == 1;
        }

        musicController = GameObject.FindGameObjectWithTag("Music").GetComponent<MusicController>();

        toggle.onValueChanged.AddListener(delegate {
            musicController.OnOff(toggle.isOn);
        });
    }

}
