using System.Collections;
using TMPro;
using UnityEngine;

public class RandomBehaviour : MonoBehaviour {

    private string[] names;
    [SerializeField]
    private TextMeshProUGUI text;
    private int index = 0;

    void Start() {
        names = DataController.Read2TextBox();
        JsonHelper.Shuffle(names);
    }

    public void StartSortName() {
        StartCoroutine(ChooseName());
    }

    private IEnumerator ChooseName() {

        int max = 10;
        if (names.Length < 10) {
            max = names.Length - 1;
        }

        for (int i = 0; i < max; i++) {
            text.text = names[i];
            yield return new WaitForSeconds(.15f);
        }

        text.text = names[index++];

        if (index >= names.Length) {
            index = 0;
        }
    }

}
