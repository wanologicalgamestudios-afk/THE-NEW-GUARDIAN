using UnityEngine;

public class CharacterController : MonoBehaviour
{
    [SerializeField] private float walkSpeed;
    [SerializeField] private float rotationSpeed;
    [SerializeField] float reachThreshold;
    [SerializeField] private float defaultAngle;
    [SerializeField] Transform chatacter;
    [SerializeField] private Camera mainCamera;
    [SerializeField] private AnimatorController animatorController;
  

    private Vector3 newPositionTarget;
    private bool canMove = false;
   

    void Start()
    {
        newPositionTarget = chatacter.position;
        SetDefaultAngle();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(1)) 
        {
            newPositionTarget = mainCamera.ScreenToWorldPoint(Input.mousePosition);
            newPositionTarget.z = chatacter.position.z;
            SetDirectionAngle();
            if (!canMove) 
            {
                canMove = true;
                animatorController.PlayWalkAnimation();
            }
     
        }
        Move();
    }

    private void SetDefaultAngle() 
    {
        Quaternion targetRotation = Quaternion.Euler(0f, defaultAngle, 0f);
        //chatacter.rotation = Quaternion.RotateTowards(
        //    chatacter.rotation,
        //    targetRotation,
        //    rotationSpeed * Time.deltaTime
        //    );
        chatacter.rotation = targetRotation;
    }
    private void SetDirectionAngle() 
    {
        Vector3 dir = newPositionTarget - chatacter.position;
        // Calculate angle
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;

        Quaternion rotation = Quaternion.Euler(0f, -1 * angle, 0f);
        chatacter.rotation = rotation;
    }

    private void Move()
    {
        if(!canMove) return;

        chatacter.position = Vector3.MoveTowards(chatacter.position, newPositionTarget, walkSpeed * Time.deltaTime);
        if (Vector3.Distance(chatacter.position, newPositionTarget) <= reachThreshold)
        {
            canMove = false;
            OnReachedTarget();
        }

    }

    private void OnReachedTarget()
    {
        animatorController.PlayIdleAnimation();
        // reset rotation to default
        SetDefaultAngle();
       // transform.rotation = Quaternion.identity; 
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
