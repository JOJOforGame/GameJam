using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QuestManager : MonoBehaviour
{
    public static QuestManager instance;
    public Quest[] quests;
    public GameObject transition;
    public int transitionTime = 10;

    void Awake()
    {
        instance = this;
        foreach (Quest quest in quests)
        {
            quest.completed = false;
        }
        transition.SetActive(false);
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

        StartCoroutine(AdvanceToNextScene(nextSceneIndex));
    }

    IEnumerator AdvanceToNextScene(int idx)
    {
        transition.SetActive(true);
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(idx);
    }
}