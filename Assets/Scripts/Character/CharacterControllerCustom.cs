using UnityEngine;
using UnityEngine.EventSystems;

public class CharacterControllerCustom : MonoBehaviour
{
    [SerializeField] private float walkSpeedMin;
    [SerializeField] private float walkSpeedMax;

    [SerializeField] private float rotationSpeed;
    [SerializeField] float reachThreshold;
    [SerializeField] private float defaultAngle;
    [SerializeField] Transform chatacter;
    [SerializeField] Transform chatacterMainBody;
    [SerializeField] private Camera mainCamera;
    [SerializeField] private AnimatorController animatorController;
    [SerializeField] private Collider characterCollider;
    [SerializeField] private float mainCharacterTopPadding;
    [SerializeField] private float characterMaxPositionOnY;
    [SerializeField] private float characterMinPositionOnY;
    [SerializeField] private float characterMaxSizeWhileMoving;
    [SerializeField] private float characterMinSizeWhileMoving;


    #region Move Variables
    private Vector3 newPositionTarget;
    private bool canMove = false;
    Vector3 newCalculatedPositionX;
    Vector3 newCalculatedPositionY;
    #endregion



    #region CheckForOutsideScreen
    Vector3 moveDirection;
    Bounds ColliderBounds;
    Vector3 ScreenmMin;
    Vector3 ScreenMax;
    bool outsideLeft;
    bool outsideRight;
    bool outsideBottom;
    bool outsideTop;
    #endregion

    #region SizeControllOnMove Variables
    float lerpValue;
    float updatedCharacterScale;
    [SerializeField] float currentWalkSpeed;
    #endregion




    void Start()
    {
        newPositionTarget = chatacter.position;
        SetDefaultAngle();
        SizeControllOnMove();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) 
        {
            if (EventSystem.current.IsPointerOverGameObject()) return;

            newPositionTarget = mainCamera.ScreenToWorldPoint(Input.mousePosition);

           // if(newPositionTarget.y > characterMaxPositionOnY || newPositionTarget.y < characterMinPositionOnY) return;

            newPositionTarget.z = chatacter.position.z;

            SetDirectionAngle();
            if (!canMove)
            {
                Debug.Log("Start Moving");
                canMove = true;
                animatorController.PlayWalkAnimation();
            }

        }
        Move();
    }

    private void SetDefaultAngle() 
    {
        //Quaternion targetRotation = Quaternion.Euler(0f, defaultAngle, 0f);
        ////chatacter.rotation = Quaternion.RotateTowards(
        ////    chatacter.rotation,
        ////    targetRotation,
        ////    rotationSpeed * Time.deltaTime
        ////    );
        //chatacterMainBody.rotation = targetRotation;
    }
    private void SetDirectionAngle() 
    {
        Vector3 dir = newPositionTarget - chatacter.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.Euler(0f, -1 * angle + 90, 0f);

        chatacterMainBody.rotation = rotation;
     
    }

    private void Move()
    {
        if(!canMove) return;

        // newCalculatedPositionX = Vector3.MoveTowards(chatacter.position, newPositionTarget, walkSpeedMin * Time.deltaTime);
        // newCalculatedPositionY = Vector3.MoveTowards(chatacter.position, newPositionTarget, (walkSpeedMin/3.5f) * Time.deltaTime);
        // chatacter.position = new Vector3(newCalculatedPositionX.x, newCalculatedPositionY.y , chatacter.position.z);


        CheckForOutsideScreen();

        chatacter.position = Vector3.MoveTowards(chatacter.position, newPositionTarget, currentWalkSpeed * Time.deltaTime);
        chatacterMainBody.localPosition = Vector3.zero;

        SizeControllOnMove();

        if (Vector3.Distance(chatacter.position, newPositionTarget) <= reachThreshold)
        {
            canMove = false;
            IdleOnReachedTarget();
        }

    }
    private void SizeControllOnMove() 
    {
        lerpValue = Mathf.InverseLerp(
            characterMinPositionOnY,
            characterMaxPositionOnY,
            chatacter.position.y
        );

        updatedCharacterScale = Mathf.Lerp(
            characterMinSizeWhileMoving,
            characterMaxSizeWhileMoving,
            lerpValue
        );
        transform.localScale = Vector3.one * updatedCharacterScale;

        currentWalkSpeed = Mathf.Lerp(
            walkSpeedMax,
            walkSpeedMin,
            lerpValue
        );
    }

    private void CheckForOutsideScreen()
    {
        ColliderBounds = characterCollider.bounds;
        ColliderBounds.max = new Vector3(ColliderBounds.max.x , ColliderBounds.max.y + mainCharacterTopPadding, ColliderBounds.max.z);
       // ColliderBounds.min = new Vector3(ColliderBounds.min.x - 0.5f, ColliderBounds.max.y , ColliderBounds.max.z);

        ScreenmMin = Camera.main.WorldToViewportPoint(ColliderBounds.min);
        ScreenMax = Camera.main.WorldToViewportPoint(ColliderBounds.max);

        moveDirection = newPositionTarget - chatacter.position;
        moveDirection.Normalize(); 

        outsideLeft = ScreenmMin.x < 0f && moveDirection.x < 0f;
        outsideRight = ScreenMax.x > 1f && moveDirection.x > 0f;
        outsideBottom = ScreenmMin.y < 0f && moveDirection.y < 0f;
        outsideTop = ScreenMax.y > 1f && moveDirection.y > 0f;


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
       // IdleOnReachedTarget();
    }

}
