using UnityEngine;
using UnityEngine.UI;

public class DialogueBox : MonoBehaviour
{
    [SerializeField]
    private TypewriterEffect typewriterEffectDialogieBox;
    [SerializeField]
    private Image dialogueBoxImage;

    [SerializeField]
    private float alphabetToShowTime;

    private void OnEnable()
    {
        dialogueBoxImage.color = new Color (dialogueBoxImage.color.r, dialogueBoxImage.color.g, dialogueBoxImage.color.b, 0f);
    }
    public void ShowDialogueBox(string _message,float _messageShowTime)
    {
        dialogueBoxImage.color = new Color(dialogueBoxImage.color.r, dialogueBoxImage.color.g, dialogueBoxImage.color.b, 1f);
        typewriterEffectDialogieBox.SetText(_message, alphabetToShowTime);
        Invoke(nameof(CloseTheMessage), _messageShowTime);
    }
    private void CloseTheMessage() 
    {
        dialogueBoxImage.color = new Color(dialogueBoxImage.color.r, dialogueBoxImage.color.g, dialogueBoxImage.color.b, 0f);
        typewriterEffectDialogieBox.ClearText();
    }
}
