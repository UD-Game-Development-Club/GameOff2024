using UnityEngine;
using System.Collections;

public class TimeBook : MonoBehaviour
{
    [SerializeField] private GameInput gameInput;
    [SerializeField] private TimeTravel timeTravel;
    private bool past = false;
    private Animator animator;
    //private GameObject book;

    void Start()
    {
        animator = GetComponentInChildren<Animator>();
        //book = transform.Find("Book").gameObject;
    }

    private void Update()
    {
        // TODO: only allow click if anim is not playing
        if (gameInput.GetInteractClick())
        {
            StartCoroutine(BookAnimation());
        }
    }

    private IEnumerator BookAnimation()
    {
        AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);
        float animationLength = stateInfo.length;

        // when pressed in play correct anim
        if (past == false)
        {
            // play open anim
            animator.SetBool("TimeTravel", true);
            // play sound
            yield return new WaitForSeconds(animationLength);
            past = true;
            timeTravel.SwitchTimePeriod();
        }
        else
        {
            // play close anim
            animator.SetBool("TimeTravel", false);
            yield return new WaitForSeconds(0.1f);
            past = false;
            timeTravel.SwitchTimePeriod();
            // play sound
        }
    }
}
