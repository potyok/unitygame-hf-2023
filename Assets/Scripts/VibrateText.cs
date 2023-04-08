using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class VibrateText : MonoBehaviour
{
    public TextMeshProUGUI vibratedText;
    private float stage = 0f;
    private int maxStage = 360;

    void Update()
    {
        vibratedText.color = new Color(1f, 1f, 1f, Mathf.Abs(Mathf.Cos(stage / maxStage * 2f * Mathf.PI)));
        stage += Time.deltaTime * 100f;
        if (stage > maxStage) stage = 0f;
    }
}
