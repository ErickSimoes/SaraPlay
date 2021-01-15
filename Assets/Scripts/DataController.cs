using System.IO;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class DataController : MonoBehaviour {

    private const string fileName = "names_list.json";

    private List<string> nameList;
    [SerializeField] private GameObject panel;
    [SerializeField] private GameObject nameButtonPrefab;
    [SerializeField] private DeleteOrEditController deleteOrEditPanel;
    [SerializeField] private GameObject AddPanel;

    public static bool isEdition = false;
    public static string originalName;

    void Start() {
        ReloadNamesPanel();
    }

    public void SaveName(Text name) {
        if (isEdition) {
            RemoveName(originalName);
        }
        nameList.Add(name.text);
        SaveNameList();
        AddPanel.SetActive(false);
    }

    public void RemoveName(string name) {
        nameList.Remove(name);
        SaveNameList();
    }

    private void SaveNameList() {
        string namesListJson = JsonHelper.ToJson(nameList.ToArray(), true);
        File.WriteAllText(Path.Combine(Application.persistentDataPath, fileName), namesListJson);
        ReloadNamesPanel();
    }
    
    public static string[] ReadNameList2Array() {
        string allText = File.ReadAllText(Path.Combine(Application.persistentDataPath, fileName));
        return JsonHelper.FromJson<string>(allText);
    }

    private void ReloadNamesPanel() {
        nameList = new List<string>();
        nameList.AddRange(ReadNameList2Array());

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
