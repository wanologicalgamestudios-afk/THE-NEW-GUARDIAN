using TMPro;
using UnityEngine;

public class DormitoryGamePlay : MonoBehaviour
{
    [SerializeField] private Camera mainCamera;
    [SerializeField] private float cameraPanTime;
    [SerializeField] private float cameraSizeTo;
    [SerializeField] private Vector3 cameraPositionTo;

    [SerializeField] private Vector3 characterPositionAtSceneBegin;
    [SerializeField] private Vector3 characterPositionAtGameStart;

    [SerializeField] private float timeToBeginScene;
    [SerializeField] private float timeToStartYawnAnimation;
    [SerializeField] private float timeToStartGame;
    [SerializeField] private Obstacle samBed;

    [SerializeField] private Sprite mouseIcon;
    [SerializeField] private Sprite clockIcon;

    [SerializeField] private CharacterControllerCustom characterController;
    [SerializeField] private Cupboard cupboard;

    private GamePlayUI gamePlayUI;

    private float cameraOrignalSize;
    private Vector3 cameraOrignalPosition;
    private bool isYawnAnimationPlayed = true;


    private void Start()
    {
        BeginScene();
    }

    private void BeginScene() 
    {
        characterController.CanBeControl = false;
        characterController.transform.position = characterPositionAtSceneBegin;
        characterController.AnimatorController.PlaySittingAnimation();
         Invoke(nameof(PanTheCamera), timeToBeginScene);

    }
    private void PanTheCamera() 
    {
        UIManager.GetInstance().ActiveMessagePanel(clockIcon, "", "7:00 AM in the morning", 5.0f);
        isYawnAnimationPlayed = false;
        cameraOrignalSize = mainCamera.orthographicSize;
        cameraOrignalPosition = mainCamera.transform.position;
        ZoomTheCamera(mainCamera.gameObject, mainCamera.orthographicSize, cameraSizeTo, cameraPanTime);
        MovetheCameraToPosition(mainCamera.gameObject, cameraPositionTo, cameraPanTime);
    }
    private void ZoomTheCamera(GameObject _gameObject, float _from, float _to, float _time) 
    {
        iTween.ValueTo(_gameObject, iTween.Hash(
        "from", _from,
        "to", _to,
        "time", _time,
        "easetype", iTween.EaseType.linear,
        "onupdate", nameof(ZoomTheCameraUpdateMethod),
        "onupdatetarget", this.gameObject,
        "oncomplete", nameof(ZoomTheCameraCompleteMethod),
        "oncompletetarget", this.gameObject
         ));
    }

    private void ZoomTheCameraUpdateMethod(float newValue) 
    {
        mainCamera.orthographicSize = newValue;
    }

    private void ZoomTheCameraCompleteMethod()
    {
    }


    private void MovetheCameraToPosition(GameObject _gameObject, Vector3 _toPosition, float _moveToTime)
    {
        iTween.MoveTo(_gameObject, iTween.Hash(
            "position", _toPosition,
            "time", _moveToTime,
            "easetype", iTween.EaseType.linear,
            "oncomplete", nameof(MovetheCameraCompleted),
            "oncompletetarget", gameObject
            ));
    }

    private void MovetheCameraCompleted() 
    {
        if (!isYawnAnimationPlayed)
        {
            Debug.Log("Camera pan completed, starting yawn animation");
            StartYawnAnimation();
        }
        else 
        {
            StartGameplay();
        }
    }

    private void CallbackOnYawnAnimationEnd()
    {
        ZoomTheCamera(mainCamera.gameObject, mainCamera.orthographicSize, cameraOrignalSize, cameraPanTime);
        MovetheCameraToPosition(mainCamera.gameObject, cameraOrignalPosition, cameraPanTime);
    }

    private void StartYawnAnimation() 
    {
        isYawnAnimationPlayed = true;
        characterController.AnimatorController.PlayYawnAnimation(CallbackOnYawnAnimationEnd);
    }

    private void StartGameplay() 
    {
        UIManager.GetInstance().ActiveMessagePanel(mouseIcon, "Click", "anywhere to move Sam",3.0f);
        characterController.AnimatorController.PlayIdleAnimation();
        characterController.transform.position = characterPositionAtGameStart;
        samBed.ActiveObstacle();
        characterController.CanBeControl = true;
        OpenCupboard();
    }
    private void OpenCupboard() 
    {
        cupboard.OpenDoor(2);
    }
}
