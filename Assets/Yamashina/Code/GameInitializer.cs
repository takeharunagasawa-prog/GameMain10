using UnityEngine;
using UnityEngine.SceneManagement;

public class GameInitializer : SingletonMonoBehaviour<GameInitializer>
{
    private BGMConfigTable bgmConfigTable;

    private SEConfigTable seConfigTable;
    private GameSettings gameSettings;

    private bool isInitialized = false;
    internal bool Initialized => isInitialized;
    internal GameSettings GetGameSettings() { return gameSettings; }

    internal void SetUpGameInitialize()
    {
        if (isInitialized)return;

        // �����̃��\�[�X���[�h
        bgmConfigTable = Resources.Load<BGMConfigTable>("ScriptableObject/BGMConfig");

        seConfigTable = Resources.Load<SEConfigTable>("ScriptableObject/SEConfig");
        gameSettings = Resources.Load<GameSettings>("ScriptableObject/gameSettings");

     
        

       

        // AudioManager�������I�ɐ�ɐ���
        var audio = AudioManager.Instance;
        // �ݒ�e�[�u����n��
        audio.SetupBGMConfigTable(bgmConfigTable);

        audio.SetupSEConfigTable(seConfigTable);
        
        
       


        isInitialized = true;
    }
}