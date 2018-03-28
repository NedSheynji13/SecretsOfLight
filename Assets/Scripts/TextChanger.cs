using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextChanger : MonoBehaviour
{
    #region Variables
    private TextMeshProUGUI Text;
    public TMP_ColorGradient Default, hovered;
    #endregion

    private void Start()
    {
        Text = GetComponent<TextMeshProUGUI>();
    }

    public void Hovered()
    {
        Text.colorGradientPreset = hovered;
    }

    public void Exited()
    {
        Text.colorGradientPreset = Default;
    }
}
