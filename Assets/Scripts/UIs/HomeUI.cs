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
    public void CreditsButtonCall()
    {
        UIManager.GetInstance().SpawnNextPanel(nameof(CreditsUI), true);
    }

    public void OnQuitButtonCall()
    {
        UIManager.GetInstance().SpawnNextPanel(nameof(PauseUI), true);
    }
}
