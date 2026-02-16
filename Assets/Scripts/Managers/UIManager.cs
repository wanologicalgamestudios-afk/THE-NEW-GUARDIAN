using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class TrakingAttributes
{
    public string name;
    public bool canDeletePrevious;
    public Transform transform;
}
public class UIManager : MonoBehaviour
{
    [SerializeField]
    private GameManager gameManager;
    [SerializeField]
    private WarningsPanelUI warningsPanelUI;
    [SerializeField]
    private string allPanelPathInResourcesFolder = "Menus/";
    [SerializeField]
    private bool isShowingAds = false;
    [SerializeField]
    private bool startGamePlay = false;
    [SerializeField]
    private MyCrossFade myCrossFade;
    [SerializeField]
    private float transitionTime;

    public GameManager GameManager => gameManager;

    private string panelName;

    private bool canDeletePrevious;
    private GameObject currentPanel;
    private TrakingAttributes trakingAttributes;
    private List<TrakingAttributes> trakingList;

    private static GameObject _thisGameObject;
    private static UIManager myInstance = null;
    /// <summary>
    /// just a Awake fuction.
    /// </summary>
    void Awake()
    {
        if (myInstance != null && myInstance != this)
        {
            Destroy(gameObject);
            return;
        }

        _thisGameObject = this.gameObject;
        DontDestroyOnLoad(gameObject);
    }
    /// <summary>
    /// this fuctoin will make a static instance of this class.
    /// </summary>
    /// <returns>UIManager</returns>
    public static UIManager GetInstance()
    {
        if (myInstance == null && _thisGameObject != null)
        {
            myInstance = _thisGameObject.GetComponent<UIManager>();
        }
        return myInstance;
    }
    // Start is called before the first frame update
    void Start()
    {
        SetAtStart();
    }
    /// <summary>
    /// this fuction will set some variables at the start function.
    /// </summary>
    void SetAtStart()
    {
        SpawnSplashScreen();
    }
    /// <summary>
    /// this function will active HomeUI;
    /// </summary>
    void SpawnSplashScreen()
    {
        currentPanel = null;
        trakingAttributes = null;
        canDeletePrevious = false;
        trakingList = new List<TrakingAttributes>();
        SpawnUIPanel(nameof(HomeUI), this.transform);
    }
    public void RestMenusToHome()
    {
        for (int i = 0; i < this.transform.childCount; i++)
        {
            Destroy(this.transform.GetChild(i).gameObject);
        }
        currentPanel = null;
        trakingAttributes = null;
        canDeletePrevious = false;
        trakingList = new List<TrakingAttributes>();
        SpawnUIPanel(nameof(HomeUI), this.transform);
    }
    public void RestMenusToPerticularPanel(String _panelName)
    {
        int indexOfPanelToSpawn = trakingList.FindIndex(x => x.name == _panelName);
        if (indexOfPanelToSpawn != -1) 
        {
            string nameOfPanelToSpawn = trakingList[indexOfPanelToSpawn].name;
            for (int i = trakingList.Count - 1; i >= indexOfPanelToSpawn; i--)
            {
                trakingList.RemoveAt(i);
            }
            for (int i = 0; i < this.transform.childCount; i++)
            {
                Destroy(this.transform.GetChild(i).gameObject);
            }
            canDeletePrevious = true;
            SpawnUIPanel(nameOfPanelToSpawn, this.transform);
        }
    }
    public void ResetOnLogout()
    {
        for (int i = 0; i < this.transform.childCount; i++)
        {
            Destroy(this.transform.GetChild(i).gameObject);
        }
        currentPanel = null;
        trakingAttributes = null;
        canDeletePrevious = false;
        trakingList = new List<TrakingAttributes>();
       // SpawnUIPanel(nameof(AuthenticationUI), this.transform);
    }
    void CrossFadeInAnimation(Action _callbackCrossFadeInAnimation)
    {
        myCrossFade.PlayCrossFadeInAnimation(_callbackCrossFadeInAnimation);
        
    }
    
    void CrossFadeOutAnimation()
    {
        myCrossFade.PlayCrossFadeOutAnimation();
    }

    /// <summary>
    /// this is just a update function.
    /// </summary>
    void Update()
    {
        if (Keyboard.current != null && Keyboard.current.escapeKey.wasPressedThisFrame)
        {
            BackButtonIsPressed();
        }
        //if (Input.GetKeyDown(KeyCode.Escape))
        //{
        //    BackButtonIsPressed();
        //}
    }
    /// <summary>
    /// will spawn a next panel. 
    /// </summary>
    /// <param name="_nameOfMenu"></param>
    /// <param name="_canDeletePrevious"></param>
    public void SpawnNextPanel(string _nameOfMenu, bool _canDeletePrevious)
    {
        canDeletePrevious = _canDeletePrevious;
        panelName = _nameOfMenu;
        if (canDeletePrevious)
        {
            CrossFadeInAnimation(SpawnNextPanelAfter);
          //crossFadeAction = SpawnNextPanelAfter;
        }
        else
        {
          SpawnNextPanelAfter();
        }
        //SpawnNextPanelAfter();
    }

    void SpawnNextPanelAfter()
    {
        if (canDeletePrevious)
        {
            StartCoroutine(DestroyGameObjects(currentPanel));
            CrossFadeOutAnimation();
        }

        SpawnUIPanel(panelName, this.transform);
    }

    /// <summary>
    /// this funtion will be called on the native android button or any back button that change ui to ome panel to anothe panel. 
    /// </summary>
    public void BackButtonIsPressed()
    {
        Debug.Log("Back");
        if (isShowingAds 
            || currentPanel.name == nameof(SplashAndLoadingScreenUI) 

           )
        {
        }
        else if (currentPanel.name == nameof(HomeUI))
        {
            SpawnNextPanel(nameof(QuitPanelUI), false);
        }
        else
        {
            if (trakingList[trakingList.Count - 1].canDeletePrevious)
            {
                CrossFadeInAnimation(BackButtonIsPressedAfterAnimation);
            }
            else
            {
                BackButtonIsPressedAfterAnimation();
            }
        }
    }

    void BackButtonIsPressedAfterAnimation()
    {
        if (!trakingList[trakingList.Count - 1].canDeletePrevious)
        {
            StartCoroutine(DestroyGameObjects(currentPanel));
            trakingList.RemoveAt(trakingList.Count - 1);

            currentPanel = trakingList[trakingList.Count - 1].transform.gameObject;
        }
        else
        {
            StartCoroutine(DestroyGameObjects(currentPanel));
            trakingList.RemoveAt(trakingList.Count - 1);

            string panelNameToBeSpawn = trakingList[trakingList.Count - 1].name;

            trakingList.RemoveAt(trakingList.Count - 1);
            SpawnUIPanel(panelNameToBeSpawn, this.transform);

            CrossFadeOutAnimation();
        }

        Screen.orientation = ScreenOrientation.LandscapeLeft;
    }
    /// <summary>
    /// this will spawn a panel in the ui on ask. 
    /// </summary>
    /// <param name="_nameOfMenu"></param>
    /// <param name="_parent"></param>
    void SpawnUIPanel(string _nameOfMenu, Transform _parent)
    {
        var prefabe = Resources.Load(allPanelPathInResourcesFolder+ _nameOfMenu);
        currentPanel = Instantiate(prefabe) as GameObject;
        currentPanel.transform.SetParent(_parent);
        currentPanel.transform.localScale = Vector3.one;
        currentPanel.name = _nameOfMenu;
        RectTransform rectTrans = currentPanel.GetComponent<RectTransform>();
        rectTrans.offsetMin = new Vector2(0, 0);
        rectTrans.offsetMax = new Vector2(0, 0);

        trakingAttributes = new TrakingAttributes();
        trakingAttributes.name = _nameOfMenu;
        trakingAttributes.canDeletePrevious = canDeletePrevious;
        trakingAttributes.transform = currentPanel.transform;

        trakingList.Add(trakingAttributes);
    }
    /// <summary>
    /// this will destroy a game object using Coroutine.
    /// </summary>
    /// <param name="_gameObjectToDestroy"></param>
    /// <returns></returns>
    IEnumerator DestroyGameObjects(GameObject _gameObjectToDestroy)
    {
        yield return new WaitForSeconds(0.0f);
        Destroy(_gameObjectToDestroy);
    }

    /// <summary>
    /// will reture curret panel being showed in ui currently.
    /// </summary>
    /// <returns></returns>
    public GameObject GetCurrentPanel()
    {
        return currentPanel;
    }
    public GameObject GetSecondLastPanel()
    {
        return trakingList[^2].transform.gameObject;
    }


    public void ActiveNoWifi()
    {
        warningsPanelUI.SetActiveNoWifi();
    }
    public void ActiveLoadingPanel()
    {
        warningsPanelUI.SetActiveLoadingPanel();
    }
    public void InactiveLoadingPanel()
    {
        warningsPanelUI.InactiveLoadingPanel();
    }
    public void ActiveMessagePanel(string _message, float _duration = 3.0f)
    {
        warningsPanelUI.ActiveWarningMessagePanel(_message, _duration);
    }
    public void InactiveMessagePanel()
    {
        warningsPanelUI.InactiveWarningMessage();
    }
   // public bool IsInternetAvailable()
   // {
       // return gameManager.IsInternetAvailable();
   // }
}

