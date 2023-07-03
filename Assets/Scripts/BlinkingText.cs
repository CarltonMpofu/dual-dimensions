using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BlinkingText : MonoBehaviour 
{ 
    [SerializeField] float BlinkTime = 0.5f;
    TextMeshProUGUI textComponent;

    void Awake() {
        textComponent =  GetComponent<TextMeshProUGUI>();
        textComponent.text = "";
    }

    void Start() {
        
    }

    public void StartBlinkingText()
    {
        StartCoroutine(Blink());
    }

    IEnumerator Blink() {
        while (true) {
            textComponent.text = "Well done\nLevel complete";
            yield return new WaitForSeconds(BlinkTime);
            textComponent.text = "";
            yield return new WaitForSeconds(BlinkTime);
        }
    }
}
