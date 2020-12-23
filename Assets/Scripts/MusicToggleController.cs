using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Toggle))]
public class MusicToggleController : MonoBehaviour {

    private Toggle toggle;
    private MusicController musicController;

    void Start() {
        toggle = GetComponent<Toggle>();
        musicController = GameObject.FindGameObjectWithTag("Music").GetComponent<MusicController>();

        toggle.onValueChanged.AddListener(delegate {
            musicController.OnOff(toggle.isOn);
        });
    }

}
