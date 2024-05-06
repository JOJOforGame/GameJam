using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QuestManager : MonoBehaviour
{
    public static QuestManager instance;
    public Quest[] requiredQuests;
    public Quest[] additionalQuest;
    public GameObject transition;
    public int preTransitionTime = 0;
    public int transitionTime = 10;

    void Awake()
    {
        instance = this;
        foreach (Quest quest in requiredQuests)
        {
            quest.resetQuest();
        }
        foreach (Quest quest in additionalQuest)
        {
            quest.resetQuest();
        }
        transition.SetActive(false);
    }

    public bool checkQuestCompletion()
    {
        foreach (Quest q in requiredQuests)
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
        yield return new WaitForSeconds(preTransitionTime);
        transition.SetActive(true);
        yield return new WaitForSeconds(transitionTime);
        foreach(Quest q in this.additionalQuest)
        {
            Debug.Log("Trying to complete additional quest");
            q.tryCompleteQuest();
        }
        SceneManager.LoadScene(idx);
    }
}