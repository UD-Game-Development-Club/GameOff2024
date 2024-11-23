using UnityEngine;
using System.Collections;

public class TimeBook : MonoBehaviour
{
    [SerializeField] private GameInput gameInput;
    [SerializeField] private TimeTravel timeTravel;
    [SerializeField] private bool past = false;
    public bool BookSwitching = false;
    [SerializeField] private Animator animator;
    [SerializeField] private AudioSource toPast;
    [SerializeField] private AudioSource toFuture;
    [SerializeField] private Rigidbody rb;

    void Start()
    {
        animator = GetComponentInChildren<Animator>();
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        // TODO: only allow click if anim is not playing
        if (gameInput.GetInteractClick() && !BookSwitching)
        {
            StartCoroutine(BookSwitch());
        }
    }

    public IEnumerator BookSwitch()
    {
        AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);
        float animationLength = stateInfo.length;

        BookSwitching = true;

        // when pressed in play correct anim
        if (past == false)
        {
            // rb.isKinematic = true; // Pause Movement
            animator.SetBool("TimeTravel", true); // play open anim
            toPast.Play(); // play to past sound
            yield return new WaitForSeconds(animationLength);
            past = true; // check it is past
            timeTravel.SwitchTimePeriod(); // switch time
            // rb.isKinematic = false; // Resume Movement
        }
        else
        {
            // rb.isKinematic = true; // Pause Movement
            animator.SetBool("TimeTravel", false); // play close anim
            toFuture.Play(); // play to future sound
            yield return new WaitForSeconds(0.1f); // make transition wait for correct time in animation
            past = false; // check it is not past
            timeTravel.SwitchTimePeriod(); // switch time
            yield return new WaitForSeconds(animationLength-0.1f); // wait for resume movement
            // rb.isKinematic = false; // Resume Movement
        }
        BookSwitching = false;
    }
}
