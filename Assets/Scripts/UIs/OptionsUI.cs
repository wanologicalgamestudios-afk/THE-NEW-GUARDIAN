using UnityEngine;

public class OptionsUI : MonoBehaviour
{
    public void OnBackButtonCall() 
    {
        UIManager.GetInstance().BackButtonIsPressed();
    }
}
