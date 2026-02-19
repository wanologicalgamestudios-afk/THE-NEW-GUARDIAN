using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HomeUI : MonoBehaviour
{
    private GameManager gameManager;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameManager = UIManager.GetInstance().GameManager;
        gameManager.SoundManager.PlayBackgroundMusic();
    }

    private void SetUI() 
    {
       
    }
    public void OnNewGameButtonCall() 
    {
        gameManager.SoundManager.PlayButtonClickSound();
    }

    public void OnContinueButtonCall() 
    {
        gameManager.SoundManager.PlayButtonClickSound();
    }
    public void OnOptionsButtonCall()
    {
        gameManager.SoundManager.PlayButtonClickSound();
    }

    public void CreditsButtonCall()
    {
        gameManager.SoundManager.PlayButtonClickSound();
        UIManager.GetInstance().SpawnNextPanel(nameof(CreditsUI), true);
    }

    public void OnQuitButtonCall()
    {
        gameManager.SoundManager.PlayButtonClickSound();
        UIManager.GetInstance().SpawnNextPanel(nameof(QuitPanelUI), true);
    }
}
