using UnityEngine;
using UnityEngine.EventSystems;

public class CharacterController : MonoBehaviour
{
    [SerializeField] private float walkSpeed;
    [SerializeField] private float rotationSpeed;
    [SerializeField] float reachThreshold;
    [SerializeField] private float defaultAngle;
    [SerializeField] Transform chatacter;
    [SerializeField] private Camera mainCamera;
    [SerializeField] private AnimatorController animatorController;
    [SerializeField] private Collider characterCollider;


    private Vector3 newPositionTarget;
    private bool canMove = false;
    Vector3 moveDirection;


    Bounds ColliderBounds;
    Vector3 ScreenmMin;
    Vector3 ScreenMax;
    bool outsideLeft;
    bool outsideRight;
    bool outsideBottom;
    bool outsideTop;

    void Start()
    {
        newPositionTarget = chatacter.position;
        SetDefaultAngle();

        Bounds bounds = characterCollider.bounds;
        Debug.Log("ColliderBounds " + bounds);
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) 
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

        CheckForOutsideScreen();

        if (Vector3.Distance(chatacter.position, newPositionTarget) <= reachThreshold)
        {
            canMove = false;
            IdleOnReachedTarget();
        }

    }

    private void CheckForOutsideScreen()
    {
        ColliderBounds = characterCollider.bounds;

        ScreenmMin = Camera.main.WorldToViewportPoint(ColliderBounds.min);
        ScreenMax = Camera.main.WorldToViewportPoint(ColliderBounds.max);

        moveDirection = newPositionTarget - chatacter.position;
        moveDirection.Normalize(); 

        outsideLeft = ScreenmMin.x < 0f && moveDirection.x < 0f;
        outsideRight = ScreenMax.x > 1f && moveDirection.x > 0f;
        outsideBottom = ScreenmMin.y < 0f && moveDirection.y < 0f;
        outsideTop = ScreenMax.y > 1f && moveDirection.y > 0f;

        //if (outsideLeft || outsideRight || outsideBottom || outsideTop)
        //{
        //    canMove = false;
        //    IdleOnReachedTarget();
        //}

        if (outsideLeft || outsideRight) 
        {
            newPositionTarget = new Vector3(chatacter.position.x, newPositionTarget.y, newPositionTarget.z);
        }
        if (outsideBottom || outsideTop) 
        {
            newPositionTarget = new Vector3(newPositionTarget.x, chatacter.position.y, newPositionTarget.z);
        }
    }
    private void IdleOnReachedTarget()
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

    public void SetCharacterForNewGame() 
    {
        canMove = false;
    }

}
