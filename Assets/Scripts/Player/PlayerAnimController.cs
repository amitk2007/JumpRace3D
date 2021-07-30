using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

//controll the player animations - we can change the animation in the animator and all will work without chaning the code
public class PlayerAnimController : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] TextMeshProUGUI perfectText;

    private void Start()
    {
        perfectText.gameObject.SetActive(false);
    }
    public void SetFisrtAnim()
    {
        animator.SetBool("IsFlying", false);
        animator.SetBool("Won", false);
    }
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
    //change the timescale for 1 sec to a lower timescal = slowmotion
    IEnumerator SlowDown()
    {
        perfectText.gameObject.SetActive(true);
        Time.timeScale = 0.5f;
        yield return new WaitForSeconds(1);
        Time.timeScale = 1f;
        perfectText.gameObject.SetActive(false);
    }

    public void PlayWinAnimation()
    {
        animator.SetBool("Won", true);
    }
}
