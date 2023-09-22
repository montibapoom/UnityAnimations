using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageChanger : MonoBehaviour
{
    public KeyCode keyCode;
    public Image image;
    public Color changeColor;

    private Color defaultColor;

    private void Start()
    {
        defaultColor = image.color;
    }

    private void Update()
    {
        var targetColor = Input.GetKey(keyCode) ? changeColor : defaultColor;

        if (image.color != targetColor)
            image.color = targetColor;
    }
}
