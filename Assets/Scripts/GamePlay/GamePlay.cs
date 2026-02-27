using UnityEngine;

public class GamePlay : MonoBehaviour
{
    [SerializeField] GameObject mainCharacter;
    [SerializeField] CharacterController mainCharacterController;


    private void StartGame() 
    {
        Debug.Log("StartGame");
        mainCharacter.SetActive(true);
        mainCharacterController.SetCharacterForNewGame();
    }

    public void ExitGame() 
    {
        mainCharacter.SetActive(false);
    }
    
    public void StartNewGame() 
    {
        StartGame();
    }
}
