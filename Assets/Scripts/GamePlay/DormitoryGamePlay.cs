using UnityEngine;

public class DormitoryGamePlay : MonoBehaviour
{
    [SerializeField] Vector3 characterPositionAtSceneBegin;
    [SerializeField] Vector3 characterPositionAtGameStart;
    [SerializeField] CharacterControllerCustom characterController;
    [SerializeField] float timeToStartYawnAnimation;
    [SerializeField] float timeToStartGame;
    [SerializeField] Obstacle samBed;

    private GamePlayUI gamePlayUI;

    private void Start()
    {
        BeginScene();
    }

    private void BeginScene() 
    {
        Debug.Log("StartGame");
        characterController.transform.position = characterPositionAtSceneBegin;
        characterController.AnimatorController.PlaySittingAnimation();
        Invoke(nameof(PlayYawnAnimation), timeToStartYawnAnimation);
    }

    private void PlayYawnAnimation()
    { 
         characterController.AnimatorController.PlayYawnAnimation(CallbackOnYawnAnimationEnd);
    }

    private void CallbackOnYawnAnimationEnd()
    {
        Invoke(nameof(StartGameplay), timeToStartGame);
    }

    private void StartGameplay() 
    {
        characterController.AnimatorController.PlayIdleAnimation();
        characterController.transform.position = characterPositionAtGameStart;
        samBed.SetObstacleForNewGame();
        UIManager.GetInstance().GetCurrentPanel().GetComponent<GamePlayUI>().CannotPlayLayer.SetActive(false);
    }

}
