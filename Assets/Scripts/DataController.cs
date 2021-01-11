using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class DataController : MonoBehaviour {

    private const string fileName = "names_list.json";

    [SerializeField] private new List<string> nameList;
    [SerializeField] private GameObject panel;
    [SerializeField] private GameObject nameButtonPrefab;
    [SerializeField] private DeleteOrEditController deleteOrEditPanel;

    private void SaveNameList() {
        string namesListJson = JsonHelper.ToJson(nameList.ToArray(), true);
        File.WriteAllText(Path.Combine(Application.persistentDataPath, fileName), namesListJson);
    }
    
    public void SaveName(Text name) {
        nameList.Add(name.text);
        SaveNameList();
    }

    public static string[] Read2TextBox() {
        string allText = File.ReadAllText(Path.Combine(Application.persistentDataPath, fileName));
        return JsonHelper.FromJson<string>(allText);
    }

    private void OnEnable() {
        SceneManager.sceneLoaded += OnSceneLoad;
    }

    private void OnSceneLoad(Scene scene, LoadSceneMode mode) {
        if(scene.name == "InsertScene") {
            nameList.AddRange(Read2TextBox());
            GameObject tempNameButton;
            foreach (string name in nameList) {
                tempNameButton = Instantiate(nameButtonPrefab, panel.transform);
                tempNameButton.GetComponentInChildren<Text>().text = name;
                tempNameButton.GetComponent<Button>().onClick
                            .AddListener(delegate { deleteOrEditPanel.setName(name); });
            }
        }
    }
}
