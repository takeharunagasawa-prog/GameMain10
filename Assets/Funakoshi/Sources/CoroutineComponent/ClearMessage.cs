using UnityEngine;
using TMPro;

public class ClearMessage : CoroutineContent
{
    [SerializeField] TextMeshProUGUI textComponent;

    public override void ForcedEnd()
    {
        textComponent.text = string.Empty;
    }
    public override void ProcessStarted()
    {
        textComponent.text = string.Empty;
    }
}
