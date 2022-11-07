using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighLightUI : MonoBehaviour
{
    public Color HighLightButton(Image _color)
    {
        Color image = _color.color;
        image.a = 255;

        return image;
    }

    public Color UnHighLightButton(Image _color)
    {
        Color image = _color.color;
        image.a = 0;

        return image;
    }
}
