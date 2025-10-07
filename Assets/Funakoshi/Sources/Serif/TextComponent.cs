using System.Collections;
using UnityEngine;
using TMPro;

public class TextComponent : MonoBehaviour, IMessageProccessable
{
    [SerializeField] TextMeshProUGUI textComponent;

    private TextUseCase text;
    private bool isCoroutineRunning;
    private string hereMessage;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        text = new TextUseCase(textComponent);
        isCoroutineRunning = false;
        hereMessage = string.Empty;
    }

    public bool IsTextRunning()
    {
        return isCoroutineRunning;
    }
    public void NextMessage(string message)
    {
        text.ClearText();
        StartCoroutine(IncreaseExecute(message));
    }
    public void TextAnimationForcedEnd()
    {
        text.SetText(hereMessage);
    }

    private IEnumerator IncreaseExecute(string message)
    {
        isCoroutineRunning = true;
        hereMessage = message;

        int messageLength = message.Length;
        int viewCharsCount = 0;
        while (true)
        {
            text.AddNewCharToText(message[viewCharsCount]);

            yield return new WaitForEndOfFrame();

            viewCharsCount++;
            if (messageLength <= viewCharsCount)
            {
                break;
            }
        }

        isCoroutineRunning = false;
    }
}
