using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class FadeOutPanel : CoroutineContent
{
    [SerializeField] private Image thisImage;
    [SerializeField] private float fadeSpeed;
    [SerializeField] private float terminalAlpha;

    private ColorAlpha colorAlpha;

    void Awake()
    {
        colorAlpha = new ColorAlpha(thisImage);
    }

    public override void ProcessStarted()
    {
        StartCoroutine(Fade());
    }
    public override void ForcedEnd()
    {
        StopAllCoroutines();
        colorAlpha.Set(terminalAlpha);

        contentEnd = true;
    }

    private IEnumerator Fade()
    {
        while (!colorAlpha.ToWard(terminalAlpha, fadeSpeed))
        {
            yield return new WaitForEndOfFrame();
        }

        contentEnd = true;
    }
}
