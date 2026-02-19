using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.EventSystems;

public class UIButtonHoverSound : MonoBehaviour, IPointerEnterHandler
{
    public void OnPointerEnter(PointerEventData eventData)
    {
        UIManager.GetInstance().GameManager.SoundManager.PlayButtonHoverSound();
    }
}
