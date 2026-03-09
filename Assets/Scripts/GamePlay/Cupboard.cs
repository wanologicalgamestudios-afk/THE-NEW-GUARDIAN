using UnityEngine;

public class Cupboard : MonoBehaviour
{
    [SerializeField] private Animator secondDoorAnimator;

    public void OpenDoor(int _number) 
    {
        if (_number == 2) 
        {
            Debug.Log("Opening second door "+ _number);
            secondDoorAnimator.SetTrigger("open");
        }
    }
}
