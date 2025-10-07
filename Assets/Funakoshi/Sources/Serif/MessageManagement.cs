/*using UnityEngine;

public class MessageSetter : MonoBehaviour
{
    [SerializeField] private Lines lines;
    [SerializeField] SerifContent textComponent;

    private int serifIndex = 0;

    public void NextMessageProcess()
    {
        if (textComponent.IsTextRunning())
        {
            textComponent.TextAnimationForcedEnd();
        }
        else
        {
            string nextMessage = lines.Messages[serifIndex];
            textComponent.NextMessage(nextMessage);

            serifIndex++;
        }
    }
    public bool IsMessageEnd()
    {
        if (lines.Messages.Count <= serifIndex)
        {
            if (textComponent.IsTextRunning() == false)
            {
                return true;
            }
        }
        return false;
    }
}
*/