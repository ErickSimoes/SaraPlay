using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DataController : MonoBehaviour {

    private const string fileName = "names_list.json";
    [SerializeField] private TMP_InputField textBox;

    public void SaveTextBox(TextMeshProUGUI textBox) {
        string namesListJson = JsonHelper.ToJson(textBox.text.Split('\n'), true);
        File.WriteAllText(Path.Combine(Application.persistentDataPath, fileName), namesListJson);
    }

    public static string[] Read2TextBox() {
        string allText = File.ReadAllText(Path.Combine(Application.persistentDataPath, fileName));
        return JsonHelper.FromJson<string>(allText);
    }

    private void OnEnable() {
        SceneManager.sceneLoaded += OnSceneLoad;
    }

    private void OnSceneLoad(Scene scene, LoadSceneMode mode) {
        if (textBox) {
            string[] name_list = Read2TextBox();
            textBox.text = string.Join("\n", name_list);
        }
    }
}
