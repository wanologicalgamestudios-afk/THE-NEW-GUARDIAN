using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SplashAndLoadingScreenUI : MonoBehaviour
{
    //private GameManager gameManager;

    [SerializeField] private TextMeshProUGUI loadingText;
    [SerializeField] private float speed = 0.5f;
    [SerializeField] private Slider loadingBar;
    [SerializeField] private float loadingScreenMaxTime = 3f;
    [SerializeField] private string[] notes;
    [SerializeField] private TextMeshProUGUI noteText;
    [SerializeField] private float noteDuration;


    private float loadingScreenActualTime = 0; 

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       // gameManager = GameManager.Instance;
        StartCoroutine(AnimateLoading());
        StartCoroutine(ChangeNotes());
        StartProgress();
    }


    IEnumerator ChangeNotes()
    {
        noteText.text = notes[Random.Range(0, notes.Length)];
        yield return new WaitForSeconds(noteDuration);
        StartCoroutine(ChangeNotes());
    }
    IEnumerator AnimateLoading()
    {
        string baseText = "LOADING";
        int dotCount = 0;

        while (true)
        {
            loadingText.text = baseText + new string('.', dotCount);
            dotCount = (dotCount + 1) % 4; // 0–3 dots
            yield return new WaitForSeconds(speed);
        }
    }
    private void UpdateLoadingbar(float _value) 
    {
        loadingBar.value = _value;
    }
    private void StartProgress() 
    {
        loadingScreenActualTime = Random.Range(2f, loadingScreenMaxTime + 1);
        iTween.ValueTo(gameObject, iTween.Hash(
                  "from", 0.0f,
                  "to", 1.0f,
                  "time", loadingScreenActualTime,
                  "onupdate", nameof(UpdateLoadingbar),
                  "onupdatetarget", this.gameObject,
                  "oncomplete", nameof(GotoMainMenuUI),
                  "oncompletetarget", this.gameObject
                  )
            );
    }

    #region without authentication logic
    private void WithoutUserAuthentication()
    {
        Invoke(nameof(GotoMainMenuUI), 2f);
    }
    #endregion

    #region with authentication logic
    //private void CheckUserAuthentication()
    //{
    //    if (string.IsNullOrEmpty(gameManager.AuthenticationToken))
    //     {
    //        Invoke(nameof(GotoLoginUI), 2f);
    //     }
    //     else 
    //     {
    //          Invoke(nameof(GotoMainMenuUI), 2f);
    //     }
    //}
    #endregion

    public void GotoMainMenuUI()
    {
        UIManager.GetInstance().SpawnNextPanel(nameof(HomeUI), true);
    }
    public void GotoLoginUI()
    {
       // UIManager.GetInstance().SpawnNextPanel(nameof(AuthenticationUI), true);
    }
}
