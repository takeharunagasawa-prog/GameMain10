using UnityEngine;

public class EndingScene : MonoBehaviour
{
    [SerializeField] MessageManagement message;
    private EndingSceneState state;

    void Start()
    {
        state = EndingSceneState.WaitIn;
    }
    void Update()
    {
        switch (state)
        {
            case EndingSceneState.WaitIn:
                break;
            case EndingSceneState.Serif:
                break;
            case EndingSceneState.FadeOut:
                break;
            case EndingSceneState.Result:
                break;
        }
    }

    public void NextProccess()
    {
        switch(state)
        {
            case EndingSceneState.Serif:
                message.NextMessageProcess();
                break;
            default:
                break;
        }
    }
    private void StatusEnd(EndingSceneState currentState)
    {
        if (currentState != state)
            return;

        switch (state)
        {
            case EndingSceneState.WaitIn:
                state = EndingSceneState.Serif;
                break;
            case EndingSceneState.Serif:
                state = EndingSceneState.FadeOut;
                break;
            case EndingSceneState.FadeOut:
                state = EndingSceneState.Result;
                break;
        }
    }
}
