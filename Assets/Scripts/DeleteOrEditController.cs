using UnityEngine;
using UnityEngine.UI;

public class DeleteOrEditController : MonoBehaviour {
    [SerializeField] private Text text;
    [SerializeField] private DataController dataController;
    
    public void setName(string name) {
        this.gameObject.SetActive(true);
        text.text = name;
    }

    public void DeleteName() {
        dataController.RemoveName(text.text);
    }
}
