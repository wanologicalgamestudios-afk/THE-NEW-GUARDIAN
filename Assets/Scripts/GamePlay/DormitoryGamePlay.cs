using TMPro;
using UnityEngine;

public class DormitoryGamePlay : MonoBehaviour
{
    [SerializeField] Camera mainCamera;
    [SerializeField] float cameraPanTime;
    [SerializeField] float cameraSizeTo;
    [SerializeField] Vector3 cameraPositionTo;

    [SerializeField] Vector3 characterPositionAtSceneBegin;
    [SerializeField] Vector3 characterPositionAtGameStart;
    [SerializeField] CharacterControllerCustom characterController;
    [SerializeField] float timeToBeginScene;
    [SerializeField] float timeToStartYawnAnimation;
    [SerializeField] float timeToStartGame;
    [SerializeField] Obstacle samBed;

    private GamePlayUI gamePlayUI;

    private float cameraOrignalSize;
    private Vector3 cameraOrignalPosition;


    private void Start()
    {
        BeginScene();
    }

    private void BeginScene() 
    {
        characterController.transform.position = characterPositionAtSceneBegin;
        characterController.AnimatorController.PlaySittingAnimation();
        Invoke(nameof(StartYawnAnimation), timeToStartYawnAnimation);
        //Invoke(nameof(PanTheCamera), timeToBeginScene); 
    }
    private void PanTheCamera() 
    {
        cameraOrignalSize = mainCamera.orthographicSize;
        cameraOrignalPosition = mainCamera.transform.position;
        ZoomTheCamera(mainCamera.gameObject,cameraOrignalSize, cameraSizeTo, cameraPanTime);
     
      //  MovetheCameraToPosition();
    }
    private void ZoomTheCamera(GameObject _gameObject, float _from, float _to, float _time) 
    {
        iTween.ValueTo(_gameObject, iTween.Hash(
        "from", _from,
        "to", _to,
        "time", _time,
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
            "oncomplete", "MoveCompleted",
            "oncompletetarget", gameObject
            ));
    }



    private void CallbackOnYawnAnimationEnd()
    {
        Invoke(nameof(StartGameplay), timeToStartGame);
    }

    private void StartYawnAnimation() 
    {
        characterController.AnimatorController.PlayYawnAnimation(CallbackOnYawnAnimationEnd);
    }

    private void StartGameplay() 
    {
        characterController.AnimatorController.PlayIdleAnimation();
        characterController.transform.position = characterPositionAtGameStart;
        samBed.SetObstacleForNewGame();
        UIManager.GetInstance().GetCurrentPanel().GetComponent<GamePlayUI>().CannotPlayLayer.SetActive(false);
    }

}
