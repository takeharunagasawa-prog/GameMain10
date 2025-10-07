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
    /// <summary>
    /// 
    /// </summary>
    /// <param name="destination"></param>
    /// <param name="speed"></param>
    /// <returns>�����x���ړI�ɓ��B���Ă��邩�ǂ�����Ԃ��܂�</returns>
    public bool ToWard(float destination, float speed)
    {
        float currentAlpha = targetImage.color.a;
        if (Mathf.Abs(destination - currentAlpha) < Mathf.Abs(speed))
        {
            Set(destination);
            return true;
        }
        else
        {
            currentAlpha += speed;
            Set(currentAlpha);
            return false;
        }
    }
}
