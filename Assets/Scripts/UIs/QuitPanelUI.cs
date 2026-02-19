using UnityEngine;

public class QuitPanelUI : MonoBehaviour
{
    private GameManager gameManager;
    void Start()
    {
        gameManager = UIManager.GetInstance().GameManager;
    }
    public void OnNoButtonCall() 
    {
        gameManager.SoundManager.PlayButtonClickSound();
        UIManager.GetInstance().BackButtonIsPressed();
    }
    public void OnYesButtonCall() 
    {
        gameManager.SoundManager.PlayButtonClickSound();
        Application.Quit();
    }
}
