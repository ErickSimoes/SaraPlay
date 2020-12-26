using UnityEngine;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour {

    private void Start() {
        if (SceneManager.GetActiveScene().name == "GameScene") {
            Screen.sleepTimeout = SleepTimeout.NeverSleep;
        } else {
            Screen.sleepTimeout = SleepTimeout.SystemSetting;
        }
    }

    public void LoadScene(string sceneName) {
        SceneManager.LoadSceneAsync(sceneName);
    }
}
