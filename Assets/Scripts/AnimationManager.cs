using UnityEngine;

public class AnimationManager : MonoBehaviour
{
    public Animator animator;

    public void PlayFeedAnimation()
    {
        animator.SetTrigger("Feed");
    }

    public void PlayPlayAnimation()
    {
        animator.SetTrigger("Play");
    }

    public void PlayBathAnimation()
    {
        animator.SetTrigger("Bath");
    }

    public void PlaySleepAnimation()
    {
        animator.SetTrigger("Sleep");
    }
}