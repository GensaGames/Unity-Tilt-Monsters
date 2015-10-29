using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TransparentEffect : MainMotions {

    public float transparentStep = 0.05f;
    public float repeatTime = 0.025f;
    public float startDelay = 0.1f;

    private Text GUIText;
    private Color currentColor;

	void Start () {
        GUIText = gameObject.GetComponent<Text>();
        currentColor = GUIText.color;
        InvokeRepeating("updateTransparent", startDelay, repeatTime);
	}

    void updateTransparent() {
        currentColor.a -= transparentStep;
        GUIText.color = currentColor;
    
    }

}
