using System.Collections.Generic;
using UnityEngine;

public class ContentManagement : MonoBehaviour
{
    [SerializeField] List<CoroutineContentSkipUnit> skipUnits;

    private int skipUnitIndex = 0;
    private int coroutineContentIndex = 0;
    private CoroutineContent CurrentContent => skipUnits[skipUnitIndex].CoroutineContents[coroutineContentIndex];

    private bool isContentEnd = false;

    public bool IsAllContentEnd()
    {
        return isContentEnd;
    }
    public void RunFirstContent()
    {
        CurrentContent.ProcessStarted();
    }

    public void ContentUpdate()
    {
        Debug.Log(CurrentContent.GetType());
        if (CurrentContent.IsContentEnd())
        {
            NextContent();
        }
    }
    public void SkipContent()
    {
        if (skipUnits.Count <= skipUnitIndex + 1)
        {
            Debug.Log("これ以上スキップできません");
            return;
        }

        foreach (var content in skipUnits[skipUnitIndex].CoroutineContents)
        {
            content.ForcedEnd();
        }
        skipUnitIndex++;
        coroutineContentIndex = 0;

        CurrentContent.ProcessStarted();
    }

    private void NextContent()
    {
        AdvanceIndex();
        CurrentContent.ProcessStarted();
    }
    private void AdvanceIndex()
    {
        if (skipUnits[skipUnitIndex].CoroutineContents.Count <= coroutineContentIndex + 1)
        {
            skipUnitIndex++;
            coroutineContentIndex = 0;
            return;
        }
        if (skipUnits.Count <= skipUnitIndex)
        {
            isContentEnd = true;
            return;
        }

        coroutineContentIndex++;
    }
}
