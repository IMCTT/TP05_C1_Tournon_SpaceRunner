using System;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MainMenu : MonoBehaviour
{
    [Header("Paneles")]
    public GameObject mainMenuPanel;
 
    
    [Header("Botones")]
    public UnityEngine.UI.Button playButton;
   
    public UnityEngine.UI.Button exitButton;

    private void Start()
    {
        playButton.onClick.AddListener(OnPlayButton);

        exitButton.onClick.AddListener(OnExitButton);
    }

    public void OnPlayButton()
    {
        
        mainMenuPanel.SetActive(false);
        SceneManager.LoadScene("Game");
        Time.timeScale = 1f;
    }



 

    public void OnExitButton()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

    private void OnDestroy()
    {
        playButton.onClick.RemoveAllListeners();

        exitButton.onClick.RemoveAllListeners();   
    }
}

