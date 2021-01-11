using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DataController : MonoBehaviour {

    private const string fileName = "names_list.json";
    [SerializeField] private GameObject panel;
    [SerializeField] private GameObject nameButtonPrefab;
    [SerializeField] private DeleteOrEditController deleteOrEditPanel;

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
        string[] name_list = Read2TextBox();
        GameObject tempNameButton;
        foreach (string name in name_list) {
            tempNameButton = Instantiate(nameButtonPrefab, panel.transform);
            tempNameButton.GetComponentInChildren<Text>().text = name;
            tempNameButton.GetComponent<Button>().onClick
                          .AddListener(delegate { deleteOrEditPanel.setName(name); });
        }
    }
}
