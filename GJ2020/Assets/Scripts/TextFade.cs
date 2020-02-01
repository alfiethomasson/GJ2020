using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TextFade : MonoBehaviour
{
    bool processing = false;
    public TextMeshProUGUI text;

    // Update is called once per frame
    void Update()
    {
        if (text.text != "") {
            if (processing)
            { return; }
            else {
                processing = true;
                StartCoroutine(Text());
            }
        }
    }

    IEnumerator Text() {
        yield return new WaitForSeconds(5);
        text.text = "";
    }
}
