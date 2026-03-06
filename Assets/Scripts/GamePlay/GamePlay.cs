using UnityEngine;

public class GamePlay : MonoBehaviour
{
    [SerializeField] GameObject mainCharacter;
    [SerializeField] GameObject environment;
    [SerializeField] CharacterControllerCustom mainCharacterController;

    [SerializeField] DormitoryGamePlay dormitoryGamePlay;


    private void StartGame() 
    {
        Debug.Log("StartGame");
        mainCharacter.SetActive(true);
       // environment.SetActive(true);
        mainCharacterController.SetCharacterForNewGame();
        dormitoryGamePlay.gameObject.SetActive(true);
    }

    public void ExitGame() 
    {
        mainCharacter.SetActive(false);
        environment.SetActive(false);
    }
    
    public void StartNewGame() 
    {
        StartGame();
    }
}
