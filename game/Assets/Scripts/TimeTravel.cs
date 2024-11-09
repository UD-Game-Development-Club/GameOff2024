using UnityEngine;

public class TimeTravel: MonoBehaviour
{
    private GameObject sharedParent;
    private GameObject pastParent;
    private GameObject presentParent;

    private void Awake()
    {
        sharedParent = GameObject.FindGameObjectWithTag("Shared");
        pastParent = GameObject.FindGameObjectWithTag("Past");
        presentParent = GameObject.FindGameObjectWithTag("Present");
        pastParent.SetActive(false);
    }

    public void SwitchTimePeriod()
    {
        presentParent.SetActive(!presentParent.activeSelf);
        pastParent.SetActive(!pastParent.activeSelf);
    }
}
