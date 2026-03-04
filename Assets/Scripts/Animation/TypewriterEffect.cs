using UnityEngine;
using TMPro;
using System;
using System.Collections;

//[RequireComponent(typeof(TextMeshProUGUI))]
public class TypewriterEffect : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _textBox;

    [SerializeField]
    private float interpunctuationDelay = 0.5f;    

    private void StartTypewriter(string text)
    {
        StartCoroutine(Typewriter(text));
    }

    public void SetText(string text,float _textShowTime)
    {
        interpunctuationDelay = _textShowTime;
        StartTypewriter(text);
    }

    private IEnumerator Typewriter(string _originalText)
    {
        string text = _originalText;
        yield return new WaitForSeconds(0.1f);      //Delay to make sure textInfo is updated

        char[] AllCharacters = text.ToCharArray();

        for (int i = 0; i < AllCharacters.Length; i++)
        {
            yield return new WaitForSeconds(interpunctuationDelay);
            _textBox.text += AllCharacters[i];
        }
    }

    public void ClearText()
    {
		_textBox.text = string.Empty;
    }
}