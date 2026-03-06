using System;
using UnityEngine;

public class AnimatorController : MonoBehaviour
{
    [SerializeField]
    private Animator animator;


    Action callbackOnYawnAnimationend;
    public void PlayIdleAnimation()
    {
        if (animator != null)
        {
            animator.SetTrigger("idle");
        }
        else
        {
            Debug.LogWarning("Animator component is not assigned.");
        }
    }
    public void PlayWalkAnimation()
    {
        if (animator != null)
        {
            animator.SetTrigger("walk");
        }
        else
        {
            Debug.LogWarning("Animator component is not assigned.");
        }
    }

    public void PlayYawnAnimation(Action _callbackOnAnimationEnd)
    {
        if (animator != null)
        {
            callbackOnYawnAnimationend = _callbackOnAnimationEnd;
            animator.SetTrigger("yawn");
        }
        else
        {
            Debug.LogWarning("Animator component is not assigned.");
        }
    }

    public void PlaySittingAnimation()
    {
        if (animator != null)
        {
            animator.SetTrigger("sit");
        }
        else
        {
            Debug.LogWarning("Animator component is not assigned.");
        }
    }

    public void OnYawnAnimationEnd() 
    {
        callbackOnYawnAnimationend?.Invoke();
    }
}
