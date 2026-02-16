using UnityEngine;

public class PauseUI : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }
    public void ResumeButtonCall()
    {
       // UIManager.GetInstance().SpawnNextPanel(nameof(GameUI), true);
    }
    public void HomeButtonCall()
    {
        UIManager.GetInstance().SpawnNextPanel(nameof(HomeUI), true);
    }
}
