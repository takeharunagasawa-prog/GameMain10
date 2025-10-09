using UnityEngine;
using UnityEngine.SceneManagement;

public class GameInitializer : SingletonMonoBehaviour<GameInitializer>
{
    private SEConfigTable seConfigTable;
    private GameSettings gameSettings;

    private bool isInitialized = false;
    internal bool Initialized => isInitialized;
    internal GameSettings GetGameSettings() { return gameSettings; }

    internal void SetUpGameInitialize()
    {
        if (isInitialized)return;   

        // 既存のリソースロード
        seConfigTable = Resources.Load<SEConfigTable>("ScriptableObject/SEConfig");
        gameSettings = Resources.Load<GameSettings>("ScriptableObject/gameSettings");

     
        

       

        // AudioManagerを強制的に先に生成
        var audio = AudioManager.Instance;
        // 設定テーブルを渡す
        audio.SetupSEConfigTable(seConfigTable);
        
        
       


        isInitialized = true;
    }
}