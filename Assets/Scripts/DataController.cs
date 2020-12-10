using System.IO;
using TMPro;
using UnityEngine;

public class DataController : MonoBehaviour {

    private const string fileName = "names_list.json";

    public void SaveTextBox(TextMeshProUGUI textBox) {
        string namesListJson = JsonHelper.ToJson(textBox.text.Split('\n'), true);
        File.WriteAllText(Path.Combine(Application.persistentDataPath, fileName), namesListJson);
    }
}
