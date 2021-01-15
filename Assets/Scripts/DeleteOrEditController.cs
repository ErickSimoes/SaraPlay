using UnityEngine;
using UnityEngine.UI;

public class DeleteOrEditController : MonoBehaviour {
    [SerializeField] private Text text;
    [SerializeField] private DataController dataController;
    [SerializeField] private InputField text2Save;
    
    public void setName(string name) {
        this.gameObject.SetActive(true);
        text.text = name;
    }

    public void DeleteName() {
        dataController.RemoveName(text.text);
    }

    public void EditName() {
        text2Save.text = text.text;
        DataController.isEdition = true;
        DataController.originalName = text.text;
    }
}
