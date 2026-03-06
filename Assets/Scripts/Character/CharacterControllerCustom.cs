using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.TextCore.Text;

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
    private Vector3 newMouseInputPosition;
    private Vector3 newPositionTarget;
    private bool canMove = false;
    private bool canMoveOnY = true;
    #endregion

    #region CheckForOutsideScreen
    private Vector3 moveDirection;
    private Bounds ColliderBounds;
    private Vector3 ScreenmMin;
    private Vector3 ScreenMax;
    private bool outsideLeft;
    private bool outsideRight;
    private bool outsideBottom;
    private bool outsideTop;
    #endregion

    #region SizeControllOnMove Variables
    private float lerpValue;
    private float updatedCharacterScale;
    private float currentWalkSpeed;
    #endregion

    #region OnTriggerStay
    private Obstacle obstacle;
    private Vector3 obstacleMainPoint;
    private Vector3 moveDirectionWRTObstacle;
    private float moveDistanceWRTObstacle;
    #endregion


    public AnimatorController AnimatorController => animatorController;

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
            newMouseInputPosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
            newPositionTarget = newMouseInputPosition;
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
        chatacterMainBody.localPosition = Vector3.zero;
    }

    private void Move()
    {
        if(!canMove) return;

        CheckForOutsideScreen();

        chatacter.position = Vector3.MoveTowards(chatacter.position, newPositionTarget, currentWalkSpeed * Time.deltaTime);
       

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

        ScreenmMin = Camera.main.WorldToViewportPoint(ColliderBounds.min);
        ScreenMax = Camera.main.WorldToViewportPoint(ColliderBounds.max);

        moveDirection = newMouseInputPosition - chatacter.position;
        moveDirection.Normalize(); 

        outsideLeft = ScreenmMin.x < 0f && moveDirection.x < 0f;
        outsideRight = ScreenMax.x > 1f && moveDirection.x > 0f;
        outsideBottom = ScreenmMin.y < 0f && moveDirection.y < 0f;
        outsideTop = ScreenMax.y > 1f && moveDirection.y > 0f;


        if (outsideLeft || outsideRight)
        {
            newPositionTarget = new Vector3(chatacter.position.x, newPositionTarget.y, newPositionTarget.z);
        }
        if (outsideBottom || outsideTop || !canMoveOnY)
        {
            newPositionTarget = new Vector3(newPositionTarget.x, chatacter.position.y, newPositionTarget.z);
        }
    }
    private void IdleOnReachedTarget()
    {
        animatorController.PlayIdleAnimation();
        SetDefaultAngle();
    }

    public void SetCharacterForNewGame() 
    {
        canMove = false;
       // IdleOnReachedTarget();
    }

    void OnTriggerEnter(Collider other)
    {
  
        //

        //moveDistanceWRTObstacle = chatacter.position.y - obstacleMainPoint.y;
        //// Left / Right
        //if (chatacter.position.x > obstacleMainPoint.x && moveDistanceWRTObstacle < (2*obstacle.MainPointFactor) && moveDistanceWRTObstacle > 0.0f)
        //{
        //  //  newPositionTarget = new Vector3(chatacter.position.x, newPositionTarget.y, newPositionTarget.z);
        //}
        //else if (chatacter.position.x < obstacleMainPoint.x && moveDistanceWRTObstacle < (2 * obstacle.MainPointFactor) && moveDistanceWRTObstacle > 0.0f)
        //{
        //  //  newPositionTarget = new Vector3(chatacter.position.x, newPositionTarget.y, newPositionTarget.z);
        //}
    }

    private void OnTriggerStay(Collider other)
    {

        obstacle = other.GetComponent<Obstacle>();
        obstacleMainPoint = obstacle.MainPointPoition;


        moveDirectionWRTObstacle = chatacter.position - obstacleMainPoint;
        moveDistanceWRTObstacle = chatacter.position.y - obstacleMainPoint.y;

        if (Mathf.Abs(moveDirectionWRTObstacle.y) > 1) return;

        newMouseInputPosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        moveDirection = newMouseInputPosition - chatacter.position;
        moveDirection.Normalize();



        if (moveDirectionWRTObstacle.y > 0 && moveDistanceWRTObstacle < obstacle.MainPointFactor && moveDistanceWRTObstacle > 0.0f && moveDirection.y < 0.0f)
        {
            canMoveOnY = false;
        }
        else if (moveDirectionWRTObstacle.y < 0 && moveDistanceWRTObstacle >= (-1 * obstacle.MainPointFactor) && moveDistanceWRTObstacle < 0.0f && moveDirection.y > 0.0f)
        {
            canMoveOnY = false;
        }
        else 
        {
            canMoveOnY = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
       canMoveOnY = true;
    }
}
