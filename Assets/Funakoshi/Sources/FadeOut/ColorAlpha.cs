using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ColorAlpha
{
    private readonly Image targetImage;

    public ColorAlpha(Image image)
    {
        targetImage = image;
    }

    public void Set(float value)
    {
        Color setColor = targetImage.color;
        setColor.a = value;
        targetImage.color = setColor;
    }
    public void Increase(float value)
    {
        float setAlpha = targetImage.color.a + value;
        setAlpha = Mathf.Clamp01(setAlpha);
        Set(setAlpha);
    }
}
