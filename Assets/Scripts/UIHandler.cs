﻿using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIHandler : MonoBehaviour
{
    public TMP_InputField textInput;
    public TMP_InputField colorInput;

    public Button textToColor;
    public Button colorToText;

    public TMP_InputField textOutput;

    public Transform colorsHolder;
    public GameObject colorGameObject;

    private void Start()
    {
        textToColor.onClick.AddListener(TextToColor);
        colorToText.onClick.AddListener(ColorToText);
    }

    private void TextToColor()
    {
        var colors = Converter.TextToColor(textInput.text);
        
        foreach (Transform child in colorsHolder) Destroy(child.gameObject);

        foreach (var color in colors)
        {
            var newColor = Instantiate(colorGameObject, transform.position, Quaternion.identity);
            newColor.transform.SetParent(colorsHolder, false);
            newColor.GetComponent<Image>().color = color;
        }
    }

    private void ColorToText()
    {
        textOutput.text = Converter.ColorToText(colorInput.text);
    }
}
