using UnityEngine;

public class EndingScene : MonoBehaviour
{
    [SerializeField] MessageManagement message;
    private EndingSceneState state;

    void Start()
    {
        state = EndingSceneState.WaitIn;
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
    public void StatusEnd(EndingSceneState currentState)
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
