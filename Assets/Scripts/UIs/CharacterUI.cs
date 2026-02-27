using UnityEngine;

public class CharacterUI : MonoBehaviour
{
    [SerializeField]
    private GameObject characterDialogueBox;
    [SerializeField]
    private float characterDialogueBoxDisplayTime;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Invoke(nameof(CloseCharacterDialogueBox), characterDialogueBoxDisplayTime);
    }

    private void CloseCharacterDialogueBox() 
    {
        characterDialogueBox.SetActive(false);
    }
}
