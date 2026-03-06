using UnityEngine;

public class GamePlayUI : MonoBehaviour
{
    [SerializeField] GameObject cannotPlayLayer;

    public GameObject CannotPlayLayer => cannotPlayLayer;
    public void OnPauseButtonCall() 
    {
        UIManager.GetInstance().SpawnNextPanel(nameof(PauseUI), false);
    }

 
}
