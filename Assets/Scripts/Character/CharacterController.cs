using Unity.VisualScripting;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] float reachThreshold = 0.0f;
    [SerializeField] Transform chatacter;
    [SerializeField] private Camera mainCamera;
    [SerializeField] private AnimatorController animatorController;

    private Vector3 newPositionTarget;
   private bool canMove = false;

    void Start()
    {
        newPositionTarget = chatacter.position;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(1)) 
        {
            newPositionTarget = mainCamera.ScreenToWorldPoint(Input.mousePosition);
            newPositionTarget.z = chatacter.position.z;
            AtMouseDown(newPositionTarget);
            canMove = true;
        }
        Move();
    }

    private void Move()
    {
        if(!canMove) return;

        chatacter.position = Vector3.MoveTowards(chatacter.position, newPositionTarget, speed * Time.deltaTime);

        if (Vector3.Distance(chatacter.position, newPositionTarget) <= reachThreshold)
        {
            OnReachedTarget();
        }

    }

    private void OnReachedTarget()
    {
        canMove = false;
        animatorController.PlayIdleAnimation();
        transform.rotation = Quaternion.identity; // reset rotation to default
    }


    private void AtMouseDown(Vector3 _clickPosition)
    {
        animatorController.PlayWalkAnimation();

        Vector3 direction = _clickPosition - transform.position;

        direction.y = 0f; // keep upright

        if (direction != Vector3.zero)
        {
            Quaternion rotation = Quaternion.LookRotation(-direction);
            transform.rotation = rotation;
        }
    }

}
