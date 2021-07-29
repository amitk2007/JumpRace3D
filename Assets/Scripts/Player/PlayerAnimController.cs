using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimController : MonoBehaviour
{
    [SerializeField] Animator animator;

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("JumpTrigger"))
        {
            animator.SetBool("IsFlying", false);
        }
        if (other.transform.CompareTag("Perfect"))
        {
            if (PreCanvasScript.lastStage != 0)
            {
                StartCoroutine(SlowDown());
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.transform.CompareTag("JumpTrigger"))
        {
            animator.SetBool("IsFlying", true);
        }
    }
    IEnumerator SlowDown()
    {
        Time.timeScale = 0.5f;
        yield return new WaitForSeconds(1);
        Time.timeScale = 1f;
    }

    void PlayWinAnimation()
    {
        animator.SetBool("Won", true);
    }
}
