using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

public class AnimationController : MonoBehaviour
{

    private Animator animator;


    void Start()
    {
        animator = GetComponent<Animator>();
        animator.SetInteger("animationId", PlayerPrefs.GetInt("Animation", 0));
    }
    public void ChangeAnimation(int idAnimation)
    {
        animator.SetInteger("animationId",idAnimation);
        PlayerPrefs.SetInt("Animation",idAnimation);
    }

}
