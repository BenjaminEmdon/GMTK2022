using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
   
   
    private const string mainMenuSceneName = "MainMenu";
    [SerializeField] private PlayerData playerData;
    public EPlayerAttacks.Attacks[] startingAttacks;
   

    void Start()
   {
        if(SceneManager.GetActiveScene() == SceneManager.GetSceneByName(mainMenuSceneName))
        {
              playerData.nextLevel = 1;
              playerData.attackList = startingAttacks;
        }
        
   }

    public void PlayGame()
    {
        SceneManager.LoadScene(playerData.nextLevel);
    }
    
   
    public void QuitToMainMenu()
    {
        PauseManager.Unpause();
        SceneManager.LoadScene(mainMenuSceneName);
    }

    public void QuitToDesktop()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
