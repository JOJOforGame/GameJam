using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimPlayBack : MonoBehaviour
{
    public GameObject anim;
    public int animTime = 5;

    void Start()
    {
        playAnim();
    }

    IEnumerator playAnim()
    {
        yield return new WaitForSeconds(animTime);
        Debug.Log("Close animation");
        Destroy(anim);
    }
}