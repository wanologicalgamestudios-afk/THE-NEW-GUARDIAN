using UnityEngine;

public class AnimatorController : MonoBehaviour
{
    [SerializeField]
    private Animator animator;

  
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


}
