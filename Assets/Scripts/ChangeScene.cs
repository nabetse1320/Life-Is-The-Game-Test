using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class ChangeScene : MonoBehaviour
{
    [SerializeField] private AnimationClip clipTransition;
    private Animator transitionAnimator;
    [SerializeField] private GameObject panel;
    private float transitionTime;

    void Start()
    {
        panel.SetActive(true);
        transitionAnimator = panel.GetComponent<Animator>();
        transitionTime = clipTransition.length;
        Invoke("DisablePanel", transitionTime);

    }

    public void LoadNextScene(int Scene)
    {
        StartCoroutine(SceneLoad(Scene));
    }


    public IEnumerator SceneLoad(int Scene)
    {
        panel.SetActive(true);
        transitionAnimator.SetTrigger("StartTransition");
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(Scene);

    }


    private void DisablePanel()
    {
        panel.SetActive(false);
    }

}
