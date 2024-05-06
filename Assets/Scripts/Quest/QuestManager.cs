using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QuestManager : MonoBehaviour
{
    public GameObject textCanvas;
    public static QuestManager instance;
    public Quest[] quests;

    void Awake()
    {
        instance = this;
        foreach (Quest quest in quests)
        {
            quest.completed = false;
        }
    }

    private bool checkQuestCompletion()
    {
        foreach (Quest q in quests)
        {
            if (!q.completed)
            {
                return false;
            }
        }
        return true;
    }

    public void TryGoToNextScene()
    {
        if (!checkQuestCompletion())
        {
            return;
        }
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;

        // If we're on the last scene, wrap around to the first scene
        if (nextSceneIndex >= SceneManager.sceneCountInBuildSettings)
        {
            nextSceneIndex = 0;
        }
        if (textCanvas != null)
        {
            textCanvas.SetActive(true);
        }

        StartCoroutine(JumpToNextScene(nextSceneIndex));
    }

    IEnumerator JumpToNextScene(int nextSceneIndex)
    {
        // set canvas to true

        yield return new WaitForSeconds(5);
        SceneManager.LoadScene(nextSceneIndex);
    }
}