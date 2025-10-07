using UnityEngine;

public class EndingScene : MonoBehaviour
{
    [SerializeField] ContentManagement contentManagement;

    void Start()
    {
        contentManagement.RunFirstContent();
    }
    void Update()
    {
        if (!contentManagement.IsAllContentEnd())
        {
            contentManagement.ContentUpdate();
        }

        InputKeys();
    }
    void InputKeys()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (!contentManagement.IsAllContentEnd())
            {
                contentManagement.SkipContent();
            }
        }
    }
}
