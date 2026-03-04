using UnityEngine;
using TMPro;

public class CharacterUI : MonoBehaviour
{
    [SerializeField]
    private DialogueBox characterDialogueBox;
    [SerializeField]
    private float characterDialogueBoxDisplayTime;

    void Start()
    {
        ShowDialogueBox();
    }
    private void ShowDialogueBox()
    {
        characterDialogueBox.ShowDialogueBox("Hello! I am Same. Welcome to the gameplay.", characterDialogueBoxDisplayTime);
    }
}
