using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class DataController : MonoBehaviour {

    private const string fileName = "names_list.json";

    private List<string> nameList;
    [SerializeField] private GameObject panel;
    [SerializeField] private GameObject nameButtonPrefab;
    [SerializeField] private DeleteOrEditController deleteOrEditPanel;
    [SerializeField] private GameObject AddPanel;

    void Start() {
        ReloadNamesPanel();
    }
    
    private void SaveNameList() {
        string namesListJson = JsonHelper.ToJson(nameList.ToArray(), true);
        File.WriteAllText(Path.Combine(Application.persistentDataPath, fileName), namesListJson);
    }
    
    public void SaveName(Text name) {
        nameList.Add(name.text);
        SaveNameList();
        ReloadNamesPanel();
        AddPanel.SetActive(false);
    }

    public void RemoveName(string name) {
        nameList.Remove(name);
        SaveNameList();
        ReloadNamesPanel();
    }

    public static string[] Read2TextBox() {
        string allText = File.ReadAllText(Path.Combine(Application.persistentDataPath, fileName));
        return JsonHelper.FromJson<string>(allText);
    }

    private void ReloadNamesPanel() {
        nameList = new List<string>();
        nameList.AddRange(Read2TextBox());

        foreach (Transform item in panel.transform) {
            Destroy(item.gameObject);
        }

        GameObject tempNameButton;
        foreach (string name in nameList) {
            tempNameButton = Instantiate(nameButtonPrefab, panel.transform);
            tempNameButton.GetComponentInChildren<Text>().text = name;
            tempNameButton.GetComponent<Button>().onClick
                        .AddListener(delegate { deleteOrEditPanel.setName(name); });
        }
    }
}
