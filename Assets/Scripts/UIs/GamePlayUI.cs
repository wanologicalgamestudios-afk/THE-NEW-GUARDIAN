using UnityEngine;

public class GamePlayUI : MonoBehaviour
{
    public void OnPauseButtonCall() 
    {
        UIManager.GetInstance().SpawnNextPanel(nameof(PauseUI), false);
    }
}
