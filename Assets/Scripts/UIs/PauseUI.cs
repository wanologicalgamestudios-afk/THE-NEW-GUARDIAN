using UnityEngine;

public class PauseUI : MonoBehaviour
{
    private GameManager gameManager;
    void Start()
    {
        gameManager = UIManager.GetInstance().GameManager;
    }
    public void ResumeButtonCall()
    {
        gameManager.SoundManager.PlayButtonClickSound();
       // UIManager.GetInstance().SpawnNextPanel(nameof(GameUI), true);
    }
    public void HomeButtonCall()
    {
        gameManager.SoundManager.PlayButtonClickSound();
        UIManager.GetInstance().SpawnNextPanel(nameof(HomeUI), true);
    }
}
