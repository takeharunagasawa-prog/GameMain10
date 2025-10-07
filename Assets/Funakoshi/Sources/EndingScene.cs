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
        contentManagement.ContentUpdate();

        InputKeys();
    }
    void InputKeys()
    {
        if (Input.GetMouseButtonDown(0))
        {
            contentManagement.SkipContent();
        }
    }
}
