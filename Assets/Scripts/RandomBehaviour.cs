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
        Shuffle();
    }

    public void StartSortName() {
        StartCoroutine(ChooseName());
    }

    private IEnumerator ChooseName() {
        int max = 10;

        if (names.Length < 10) {
            max = name.Length - 1;
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

    private void Shuffle() {
        int rdm;
        for (int i = 0; i < names.Length; i++) {
            rdm = Random.Range(0, names.Length - 1);
            string temp = names[rdm];
            names[rdm] = names[i];
            names[i] = temp;
        }
    }
}
