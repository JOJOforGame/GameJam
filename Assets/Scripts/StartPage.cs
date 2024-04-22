using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TextCore.Text;

public class StartPage : MonoBehaviour
{
    public LoadDataManager loadDataManager;
    // Function to handle Continue button click
    public void ContinueGame()
    {
        // Check if there is saved data
        if (LoadDataManager.Instance.HasSaveData())
        {
            //TODO:load data
            GameData savedGameData = loadDataManager.LoadGameData();
            loadDataManager.SetGameData(savedGameData);
            // Load the scene for continuing the game
            SceneManager.LoadScene("Scene1");
        }
        else
        {
            Debug.Log("No saved game data found!");
        }
    }

    // Function to handle New Game button click
    public void StartNewGame()
    {
        // TODO:create new gamedata

        LoadDataManager loadDataManager = LoadDataManager.Instance;
        if (loadDataManager == null)
        {
            Debug.LogWarning("LoadDataManager instance is null.");
            return;
        }
        loadDataManager.Initialize();
       
        // Load the scene for starting a new game
        SceneManager.LoadScene("Scene1");
    }

    // Function to handle Settings button click
    public void OpenSettings()
    {
        // Open the settings panel or menu
        // You can implement your settings functionality here
        Debug.Log("Opening Settings");
    }

    // Function to handle Quit button click
    public void QuitGame()
    {
        // Save game data if necessary
        LoadDataManager.Instance.SaveGameData();
        // Quit the application
        Application.Quit();
    }
}
