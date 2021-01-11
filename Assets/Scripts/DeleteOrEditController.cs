using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeleteOrEditController : MonoBehaviour {
    [SerializeField]
    private Text text;
    
    public void setName(string name) {
        this.gameObject.SetActive(true);
        text.text = name;
    }
}
