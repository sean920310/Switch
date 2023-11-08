using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMasking : MonoBehaviour
{
    private Animator m_animator;
    private int m_isPlayingCount = 0;

    // Fade in complete event
    public delegate void FadeInCompleteAction();
    public event FadeInCompleteAction OnFadeInComplete;

    //Fade out complete event
    public delegate void FadeOutCompleteAction();
    public event FadeOutCompleteAction OnFadeOutComplete;

    private void Start()
    {
        m_animator = GetComponent<Animator>();
    }

    // Fade in animation
    public void FadeIn()
    {
        StartCoroutine(PlayAnimationWithWait("FadeIn"));
    }

    // Fade out animation
    public void FadeOut()
    {
        StartCoroutine(PlayAnimationWithWait("FadeOut"));
    }

    // wait for animation to finish to play animation
    private IEnumerator PlayAnimationWithWait(string animationName)
    {
        m_isPlayingCount++;
        yield return new WaitWhile(() => m_isPlayingCount > 1);
        StartCoroutine(PlayAnimation(animationName));
    }


    private IEnumerator PlayAnimation(string animationName)
    {
        m_animator.ResetTrigger(animationName);
        m_animator.SetTrigger(animationName);

        if (animationName == "FadeIn")
        {
            yield return new WaitForSeconds(m_animator.GetCurrentAnimatorStateInfo(0).length);

            OnFadeInComplete?.Invoke();
        }
        else if (animationName == "FadeOut")
        {
            yield return new WaitForSeconds(m_animator.GetCurrentAnimatorStateInfo(0).length * 0.7f);
            OnFadeOutComplete?.Invoke();
        }

        m_isPlayingCount--;
    }
}
