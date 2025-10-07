using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Panel : MonoBehaviour
{
    [SerializeField] private Image thisImage;

    private ColorAlpha colorAlpha;

    void Start()
    {
        colorAlpha = new ColorAlpha(thisImage);
    }

    private IEnumerator Fade(float fadeSpeed, int executeFrames)
    {
        for (int i = 0; i < executeFrames; i++)
        {
            yield return new WaitForEndOfFrame();

            colorAlpha.Increase(fadeSpeed);
        }
    }
}
