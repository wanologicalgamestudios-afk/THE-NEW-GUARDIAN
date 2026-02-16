//using BestHTTP;
//using BestHTTP.JSON;
#if UNITY_ANDROID
//using Google;
#endif
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;


public class GameManager : MonoBehaviour
{
    #region IPIs
    //[Header("APIs")]
    //[SerializeField]
    //private bool isLocal;
    //[SerializeField]
    //private string webURLPrefixLocal;
    //[SerializeField]
    //private string webURLPrefix;
    //[SerializeField]
    //private string authenticationAPI;

    #endregion

    #region party Authentication
    //    [Header("Others")]
    //    [SerializeField]
    //    private FacebookManager facebookManager;
    //    [SerializeField]
    //    private FirebaseManager firebaseManager;
    //#if UNITY_IOS
    //    [SerializeField]
    //    private LCGoogleSignInManager lcGoogleSignInManager;
    //    [SerializeField]
    //    private AppleSignInManager appleSignInManager;
    //#endif
    #endregion

    #region Sokit IO
    //[SerializeField]
    //private SocketIOManager socketIOManager;
    #endregion

    #region Meta Data
    //private PlayerProfileMetaData playerProfileMetaData;
    //private FriendsMetaData friendsMetaData;
    //private RoadmapMetaData roadmapMetaData;
    //private RoadmapMetaData benchmarkMetaData;
    //private SubmitMediaResponseMetaData submitMediaResponseMetaData;
    #endregion

    #region APIs Getters and Setters
    //public string AuthenticationAPI => authenticationAPI;
    //public string CurrentUserAPI => currentUserAPI;
    //public string DailyDrillsAPI => dailyDrillsAPI;
    //public string PrivacyPolicyAPI => privacyPolicyURL;
    //public string TermsOfUseAPI => termsOfUseURL;
    #endregion

    #region Getters
    //public SocketIOManager SocketIOManager => socketIOManager;
    //public AuthenticationMetadata AuthenticationMetadata => authenticationForm;
    //public PlayerProfileMetaData PlayerProfileMetaData => playerProfileMetaData;
    //public RoadmapMetaData RoadmapMetaData => roadmapMetaData;

    public SoundManager SoundManager => soundManager;
    #endregion

    #region APIs responces
    //private Dictionary<string, object> authenticationResponce;


    #endregion

    #region Action Callbacks
    //private Action onSucessfulSocialMediaAuthentication;
    #endregion

    [SerializeField]
    private SoundManager soundManager;
    [SerializeField]
    private EnumsManager enumsManager;
    [SerializeField]
    private float playerMetaDataVersion;



    private string deviceId;
    private bool isInternetAvailable;

    #region TestJsonMaker
    private void TestJsonMaker()
    {

    }
    #endregion
    private void Awake()
    {
        //  if (isLocal)
        //     webURLPrefix = webURLPrefixLocal;

        // Application.runInBackground = true;
        SetDeviceId();
        SetPlayerPrefsOnVeryFirstRun();
        SetLocalSavedUser();
    }
    private void OnEnable()
    {
        RegisterEvents();
    }
    private void OnDisable()
    {
        DeregisterEvents();
    }
    void Start()
    {
        TestJsonMaker();
    }
    private void RegisterEvents()
    {
        //socketIOManager.onNotificationRecived += OnHaveANewFriendRequest;
        //socketIOManager.onRejectFriendRequest += OnFriendRequestRejected;
        //socketIOManager.onFirendRemoveMe += OnFriendRemoveMe;
        //socketIOManager.onFirendOnlineStatusChanged += OnFriendOnlineStatusChanged;
        //socketIOManager.onFirendRequestAccepted += OnFriendRequestAccepted;
    }
    private void DeregisterEvents()
    {
        //socketIOManager.onNotificationRecived -= OnHaveANewFriendRequest;
        //socketIOManager.onRejectFriendRequest -= OnFriendRequestRejected;
        //socketIOManager.onFirendRemoveMe -= OnFriendRemoveMe;
        //socketIOManager.onFirendOnlineStatusChanged -= OnFriendOnlineStatusChanged;
        //socketIOManager.onFirendRequestAccepted -= OnFriendRequestAccepted;
    }



    void SetPlayerPrefsOnVeryFirstRun()
    {
        SaveLocalUserVeryOnVersionCheck();
        if (PlayerPrefs.GetInt("isFirstRun") == 0)
        {
            #region Register Player Prefs
            PlayerPrefs.SetString("authToken", "");
            #endregion

            #region Settings Prefs
            PlayerPrefs.SetInt("isSoundOn", 1);
            PlayerPrefs.SetInt("isMusicOn", 1);
            PlayerPrefs.SetInt("isViberationOn", 1);
            PlayerPrefs.SetInt("areNotificationsOn", 1);
            #endregion
            PlayerPrefs.SetInt("isFirstRun", 1);
        }  
    }
    private void SetDeviceId()
    {
        deviceId = SystemInfo.deviceUniqueIdentifier;
    }

    private void SaveLocalUserVeryOnVersionCheck() 
    {
        if (PlayerPrefs.GetFloat("playerMetaDataVersion") < playerMetaDataVersion) 
        {
            Debug.Log("Creating Local Player Meta Data for the new version.");
            
            //playerMetaData = new PlayerMetaData();

            //playerMetaData = JsonUtility.FromJson <PlayerMetaData> (PlayerPrefs.GetString("playerMetaData", JsonUtility.ToJson(playerMetaData)));

            //if (playerMetaData.legionariesMetaDatas.Count == 0)
            //{
            //    Debug.Log("Creating legionariesMetaDatas");

            //    playerMetaData.legionariesMetaDatas = new List<LegionaryMetaData>();

            //    LegionaryMetaData _legionaryMetaData;

            //    for (int i = 0; i < baseLegionariestotal; i++)
            //    {
            //        _legionaryMetaData = new LegionaryMetaData
            //        {
            //            maxHealth = baseLegionaryHealth,
            //            attackPower = baseLegionaryAttackPower,
            //            defensePower = baseLegionaryDefencePower
            //        };

            //        playerMetaData.legionariesMetaDatas.Add(_legionaryMetaData);
            //    }
            //}

            //PlayerPrefs.SetString("playerMetaData", JsonUtility.ToJson(playerMetaData));

            PlayerPrefs.SetFloat("playerMetaDataVersion", playerMetaDataVersion);
        }
    }

    private void SetLocalSavedUser()
    {
        //SetDrakonMetaData();

        //playerMetaData = new PlayerMetaData();
        //playerMetaData = JsonUtility.FromJson<PlayerMetaData>(PlayerPrefs.GetString("playerMetaData"));

        //legionaryNames = new List<string>();

        //for (int i = 0; i < playerMetaData.legionariesMetaDatas.Count; i++) 
        //{
        //    if (string.IsNullOrEmpty(playerMetaData.legionariesMetaDatas[i].legionaryName)) 
        //    {
        //        legionaryNames.Add(playerMetaData.legionariesMetaDatas[i].legionaryName);
        //    }
        //}

        //authenticationForm = new AuthenticationMetadata
        //{
        //    authenticationToken = AuthenticationToken,
        //    deviceId = deviceId
        //};
    }
    private void UpdateAuthenticationFormOnProfileUpdate()
    {
        //authenticationForm.authId = playerProfileMetaData.authId;
        //authenticationForm.email = playerProfileMetaData.email;
        //authenticationForm.authProvider = playerProfileMetaData.authProvider;
        //authenticationForm.deviceId = playerProfileMetaData.deviceId;
        //authenticationForm.gender = playerProfileMetaData.gender;
        //authenticationForm.age = playerProfileMetaData.age.ToString();
        //authenticationForm.skillLevel = playerProfileMetaData.skillLevel;
        //authenticationForm.avatar = playerProfileMetaData.avatar;
        //authenticationForm.displayName = playerProfileMetaData.displayName;
        //authenticationForm.authenticationToken = AuthenticationToken;
    }

    #region Friending Event Handlers
    //private void OnHaveANewFriendRequest(NotificationMetaData _notificationMetaData)
    //{
    //    inboxMetaData.hasNewFriendRequest = true;

    //    indexOfAlreadyHaveRequest = inboxMetaData.friendRequests.FindIndex(x => x.id == _notificationMetaData.metaData.friend.id);
    //    if (indexOfAlreadyHaveRequest != -1)
    //    {
    //        inboxMetaData.friendRequests[indexOfAlreadyHaveRequest] = _notificationMetaData.metaData.friend;
    //    }
    //    else
    //    {
    //        // Add the new item
    //        inboxMetaData.friendRequests.Add(_notificationMetaData.metaData.friend);
    //    }
    //}
    //private void OnFriendRequestRejected(FriendMetaData _friendMetaData)
    //{
    //    indexOfAlreadySearchedFriend = searchForFriendResult.users.FindIndex(x => x.id == _friendMetaData.id);
    //    if (indexOfAlreadySearchedFriend != -1)
    //    {
    //        searchForFriendResult.users[indexOfAlreadySearchedFriend].id = _friendMetaData.id;
    //        searchForFriendResult.users[indexOfAlreadySearchedFriend].name = _friendMetaData.displayName;
    //        searchForFriendResult.users[indexOfAlreadySearchedFriend].profileImageUrl = _friendMetaData.profileImageUrl;
    //        searchForFriendResult.users[indexOfAlreadySearchedFriend].friendshipStatus.status = "";
    //        searchForFriendResult.users[indexOfAlreadySearchedFriend].friendshipStatus.requestSentByMe = false;
    //    }
    //}
    //private void OnFriendRemoveMe(FriendMetaData _friendMetaData)
    //{
    //    indexOfAlreadySearchedFriend = searchForFriendResult.users.FindIndex(x => x.id == _friendMetaData.id);
    //    if (indexOfAlreadySearchedFriend != -1)
    //    {
    //        searchForFriendResult.users[indexOfAlreadySearchedFriend].id = _friendMetaData.id;
    //        searchForFriendResult.users[indexOfAlreadySearchedFriend].name = _friendMetaData.displayName;
    //        searchForFriendResult.users[indexOfAlreadySearchedFriend].profileImageUrl = _friendMetaData.profileImageUrl;
    //        searchForFriendResult.users[indexOfAlreadySearchedFriend].friendshipStatus.status = "";
    //        searchForFriendResult.users[indexOfAlreadySearchedFriend].friendshipStatus.requestSentByMe = false;
    //    }

    //    indexOfFriendToRemove = friendsMetaData.friends.FindIndex(x => x.id == _friendMetaData.id);
    //    if (indexOfFriendToRemove != -1)
    //    {
    //        friendsMetaData.friends.RemoveAll(x => x.id == _friendMetaData.id);
    //    }
    //}
    //private void OnFriendOnlineStatusChanged(FriendMetaData _friendMetaData)
    //{
    //    indexOfFriendToChangeOnlineStatus = friendsMetaData.friends.FindIndex(x => x.id == _friendMetaData.id);
    //    if (indexOfFriendToChangeOnlineStatus != -1)
    //    {
    //        friendsMetaData.friends[indexOfFriendToChangeOnlineStatus].onlineStatus = _friendMetaData.onlineStatus;
    //    }
    //}
    //private void OnFriendRequestAccepted(FriendMetaData _friendMetaData)
    //{
    //    indexOfAlreadySearchedFriend = searchForFriendResult.users.FindIndex(x => x.id == _friendMetaData.id);
    //    if (indexOfAlreadySearchedFriend != -1)
    //    {
    //        searchForFriendResult.users[indexOfAlreadySearchedFriend].id = _friendMetaData.id;
    //        searchForFriendResult.users[indexOfAlreadySearchedFriend].name = _friendMetaData.displayName;
    //        searchForFriendResult.users[indexOfAlreadySearchedFriend].profileImageUrl = _friendMetaData.profileImageUrl;
    //        searchForFriendResult.users[indexOfAlreadySearchedFriend].friendshipStatus.status = FriendshipStatus.ACCEPTED.ToString();
    //        searchForFriendResult.users[indexOfAlreadySearchedFriend].friendshipStatus.requestSentByMe = true;
    //    }

    //    indexOfFriendHowAcceptedMyRequest = friendsMetaData.friends.FindIndex(x => x.id == _friendMetaData.id);
    //    if (indexOfFriendHowAcceptedMyRequest == -1)
    //    {
    //        if (friendsMetaData.friends.Count < 1)
    //        {
    //            friendsMetaData.friends.Add(_friendMetaData);
    //        }
    //        else
    //        {
    //            for (int i = 0; i < friendsMetaData.friends.Count; i++)
    //            {
    //                if (friendsMetaData.friends[i].overallRating.currentLevel <= _friendMetaData.overallRating.currentLevel)
    //                {
    //                    friendsMetaData.friends.Insert(i, _friendMetaData);
    //                    break;
    //                }
    //            }
    //        }

    //        Debug.Log(friendsMetaData.friends.Count);
    //    }
    //}
    #endregion

    #region API calls
    //private void Authentication(AuthenticationMetadata _authenticationMetadata, string _postURL, HTTPMethods _hTTPMethods, Action _callBacKOnSuccess, Action _callBacKOnfailed)
    //{
    //    if (!UIManager.GetInstance().IsInternetAvailable())
    //    {
    //        UIManager.GetInstance().ActiveNoWifi();
    //        UIManager.GetInstance().InactiveLoadingPanel();
    //        _callBacKOnfailed();
    //    }
    //    else
    //    {
    //        Debug.Log(webURLPrefix + _postURL);

    //        HTTPRequest www = new HTTPRequest(new Uri(webURLPrefix + _postURL), _hTTPMethods, (request, response) =>
    //        {
    //            HTTPResponse res = (HTTPResponse)response;
    //            Debug.Log("messsage  = " + res.DataAsText);
    //            Debug.Log("status code: " + res.StatusCode);

    //            if (res.IsSuccess)
    //            {
    //                authenticationResponce = new Dictionary<string, object>();
    //                authenticationResponce = Json.Decode(res.DataAsText) as Dictionary<string, object>;
    //                authenticationData = Json.Encode(authenticationResponce["data"]);

    //                playerProfileMetaData = new PlayerProfileMetaData();
    //                playerProfileMetaData = JsonUtility.FromJson<PlayerProfileMetaData>(authenticationData);


    //                if (!string.IsNullOrEmpty(playerProfileMetaData.token))
    //                    AuthenticationToken = playerProfileMetaData.token;

    //                UpdateAuthenticationFormOnProfileUpdate();
    //                if (string.IsNullOrEmpty(playerProfileMetaData.profileImageUrl))
    //                    playerProfileMetaData.profileImageUrl = defaultProfileImageUI;

    //                _callBacKOnSuccess();
    //            }
    //            else
    //            {
    //                try
    //                {
    //                    errorMetaData = new ErrorMetaData();
    //                    errorMetaData = JsonUtility.FromJson<ErrorMetaData>(res.DataAsText);
    //                    UIManager.GetInstance().ActiveMessagePanel(errorMetaData.errorDetail[0].errors[0].message);
    //                }
    //                catch
    //                {
    //                    UIManager.GetInstance().ActiveMessagePanel("Cannot reach to the server!");
    //                }
    //                _callBacKOnfailed();
    //            }
    //        });

    //        www.AddHeader("Content-Type", "application/json");

    //        Debug.Log(_authenticationMetadata.authenticationToken);
    //        if (!string.IsNullOrEmpty(_authenticationMetadata.authenticationToken))
    //            www.AddHeader("authorization", _authenticationMetadata.authenticationToken);

    //        if (!string.IsNullOrEmpty(_authenticationMetadata.deviceId))
    //            www.AddHeader("deviceId", _authenticationMetadata.deviceId);

    //        www.RawData = System.Text.Encoding.UTF8.GetBytes(JsonUtility.ToJson(_authenticationMetadata));

    //        www.Send();
    //    }
    //}
    //private void DownloadDailyDrillsData(AuthenticationMetadata _authenticationMetadata, string _postURL, HTTPMethods _hTTPMethods, Action _callBacKOnSuccess, Action _callBacKOnfailed, Action<float> _callBackUploadingProgress)
    //{
    //    if (!UIManager.GetInstance().IsInternetAvailable())
    //    {
    //        UIManager.GetInstance().ActiveNoWifi();
    //        UIManager.GetInstance().InactiveLoadingPanel();
    //        _callBacKOnfailed();
    //    }
    //    else
    //    {
    //        HTTPRequest www = new HTTPRequest(new Uri(webURLPrefix + _postURL), _hTTPMethods, (request, response) =>
    //        {
    //            HTTPResponse res = (HTTPResponse)response;

    //            Debug.Log("messsage  = " + res.DataAsText);
    //            Debug.Log("status code: " + res.StatusCode);

    //            if (res.IsSuccess)
    //            {
    //                dailyDrillsResponce = new Dictionary<string, object>();
    //                dailyDrillsResponce = Json.Decode(res.DataAsText) as Dictionary<string, object>;
    //                dailyDrillsData = Json.Encode(dailyDrillsResponce["data"]);

    //                roadmapMetaData = new RoadmapMetaData();
    //                roadmapMetaData = JsonUtility.FromJson<RoadmapMetaData>(dailyDrillsData);
    //                _callBacKOnSuccess();
    //            }
    //            else
    //            {
    //                try
    //                {
    //                    errorMetaData = new ErrorMetaData();
    //                    errorMetaData = JsonUtility.FromJson<ErrorMetaData>(res.DataAsText);
    //                    UIManager.GetInstance().ActiveMessagePanel(errorMetaData.errorDetail[0].errors[0].message);
    //                }
    //                catch
    //                {
    //                    UIManager.GetInstance().ActiveMessagePanel("Cannot reach to the server!");
    //                }

    //                _callBacKOnfailed();
    //            }
    //        });

    //        www.AddHeader("Content-Type", "application/json");

    //        if (!string.IsNullOrEmpty(_authenticationMetadata.authenticationToken))
    //            www.AddHeader("authorization", _authenticationMetadata.authenticationToken);

    //        www.OnDownloadProgress = (req, uploaded, total) =>
    //        {
    //            float progress = (float)uploaded / total;
    //            _callBackUploadingProgress(progress);
    //        };

    //        www.Send();
    //    }
    //}
    //private void DownloadBenchmarkData(AuthenticationMetadata _authenticationMetadata, string _postURL, HTTPMethods _hTTPMethods, Action _callBacKOnSuccess, Action _callBacKOnfailed, Action<float> _callBackUploadingProgress)
    //{
    //    if (!UIManager.GetInstance().IsInternetAvailable())
    //    {
    //        UIManager.GetInstance().ActiveNoWifi();
    //        UIManager.GetInstance().InactiveLoadingPanel();
    //        _callBacKOnfailed();
    //    }
    //    else
    //    {
    //        HTTPRequest www = new HTTPRequest(new Uri(webURLPrefix + _postURL), _hTTPMethods, (request, response) =>
    //        {
    //            HTTPResponse res = (HTTPResponse)response;

    //            Debug.Log("messsage  = " + res.DataAsText);
    //            Debug.Log("status code: " + res.StatusCode);

    //            if (res.IsSuccess)
    //            {
    //                benchmarkResponce = new Dictionary<string, object>();
    //                benchmarkResponce = Json.Decode(res.DataAsText) as Dictionary<string, object>;
    //                benchmarkData = Json.Encode(benchmarkResponce["data"]);

    //                benchmarkMetaData = new RoadmapMetaData();
    //                benchmarkMetaData = JsonUtility.FromJson<RoadmapMetaData>(benchmarkData);

    //                _callBacKOnSuccess();
    //            }
    //            else
    //            {
    //                try
    //                {
    //                    errorMetaData = new ErrorMetaData();
    //                    errorMetaData = JsonUtility.FromJson<ErrorMetaData>(res.DataAsText);
    //                    UIManager.GetInstance().ActiveMessagePanel(errorMetaData.errorDetail[0].errors[0].message);
    //                }
    //                catch
    //                {
    //                    UIManager.GetInstance().ActiveMessagePanel("Cannot reach to the server!");
    //                }

    //                _callBacKOnfailed();
    //            }
    //        });

    //        www.AddHeader("Content-Type", "application/json");

    //        if (!string.IsNullOrEmpty(_authenticationMetadata.authProvider))
    //            www.AddHeader("authProvider", _authenticationMetadata.authProvider);

    //        if (!string.IsNullOrEmpty(_authenticationMetadata.authenticationToken))
    //            www.AddHeader("authorization", _authenticationMetadata.authenticationToken);

    //        www.OnDownloadProgress = (req, uploaded, total) =>
    //        {
    //            float progress = (float)uploaded / total;
    //            _callBackUploadingProgress(progress);
    //        };

    //        www.Send();
    //    }
    //}
    //private void SendTimeLogs(AuthenticationMetadata _authenticationMetadata, TimeLogsMetaData _timeLogsToSend, string _postURL, HTTPMethods _hTTPMethods, Action _callBacK)
    //{
    //    if (!UIManager.GetInstance().IsInternetAvailable())
    //    {
    //        UIManager.GetInstance().ActiveNoWifi();
    //        UIManager.GetInstance().InactiveLoadingPanel();
    //    }
    //    else
    //    {
    //        HTTPRequest www = new HTTPRequest(new Uri(webURLPrefix + _postURL), _hTTPMethods, (request, response) =>
    //        {
    //            HTTPResponse res = (HTTPResponse)response;

    //            Debug.Log("messsage  = " + res.DataAsText);
    //            Debug.Log("status code: " + res.StatusCode);

    //            if (res.IsSuccess)
    //            {
    //                _callBacK();
    //            }
    //            else
    //            {
    //                try
    //                {
    //                    errorMetaData = new ErrorMetaData();
    //                    errorMetaData = JsonUtility.FromJson<ErrorMetaData>(res.DataAsText);
    //                    UIManager.GetInstance().ActiveMessagePanel(errorMetaData.errorDetail[0].errors[0].message);
    //                }
    //                catch
    //                {
    //                    UIManager.GetInstance().ActiveMessagePanel("Cannot reach to the server!");
    //                }
    //            }
    //        });


    //        www.AddHeader("Content-Type", "application/json");

    //        if (!string.IsNullOrEmpty(_authenticationMetadata.authenticationToken))
    //            www.AddHeader("authorization", _authenticationMetadata.authenticationToken);

    //        www.RawData = System.Text.Encoding.UTF8.GetBytes(JsonUtility.ToJson(_timeLogsToSend));

    //        www.Send();
    //    }
    //}
    //private void SubmitMedia(AuthenticationMetadata _authenticationMetadata, MediaToSubmitMetaData _mediaToSubmitMetaData, string _postURL, HTTPMethods _hTTPMethods, Action _callBacKOnSuccess, Action _callBacKOnfailed, Action<float> _callBackUploadingProgress)
    //{
    //    if (!UIManager.GetInstance().IsInternetAvailable())
    //    {
    //        UIManager.GetInstance().ActiveNoWifi();
    //        UIManager.GetInstance().InactiveLoadingPanel();
    //    }
    //    else
    //    {
    //        HTTPRequest www = new HTTPRequest(new Uri(webURLPrefix + _postURL), _hTTPMethods, (request, response) =>
    //        {
    //            HTTPResponse res = (HTTPResponse)response;

    //            Debug.Log("messsage  = " + res.DataAsText);
    //            Debug.Log("status code: " + res.StatusCode);

    //            if (res.IsSuccess)
    //            {
    //                submitMediaResponse = new Dictionary<string, object>();
    //                submitMediaResponse = Json.Decode(res.DataAsText) as Dictionary<string, object>;
    //                submitMediaResponseData = Json.Encode(submitMediaResponse["data"]);

    //                submitMediaResponseMetaData = new SubmitMediaResponseMetaData();
    //                submitMediaResponseMetaData = JsonUtility.FromJson<SubmitMediaResponseMetaData>(submitMediaResponseData);

    //                _callBacKOnSuccess();
    //            }
    //            else
    //            {
    //                try
    //                {
    //                    errorMetaData = new ErrorMetaData();
    //                    errorMetaData = JsonUtility.FromJson<ErrorMetaData>(res.DataAsText);
    //                    UIManager.GetInstance().ActiveMessagePanel(errorMetaData.errorDetail[0].errors[0].message);
    //                }
    //                catch
    //                {
    //                    UIManager.GetInstance().ActiveMessagePanel("Cannot reach to the server!");
    //                }

    //                _callBacKOnfailed();
    //            }
    //        });

    //        www.AddHeader("Content-Type", "multipart/form-data");
    //        videoData = File.ReadAllBytes(_mediaToSubmitMetaData.filePath);

    //        www.AddField("key", _mediaToSubmitMetaData.mediaKey);
    //        www.AddField("prefix", _mediaToSubmitMetaData.prefix);
    //        www.AddField("mode", _mediaToSubmitMetaData.mediaMode);
    //        www.AddField("uid", _mediaToSubmitMetaData.mediaUid);
    //        www.AddField("taskType", _mediaToSubmitMetaData.taskType);

    //        www.AddBinaryData("file", videoData);

    //        if (!string.IsNullOrEmpty(_authenticationMetadata.authenticationToken))
    //            www.AddHeader("authorization", _authenticationMetadata.authenticationToken);

    //        www.OnUploadProgress = (req, uploaded, total) =>
    //        {
    //            float progress = (float)uploaded / total;
    //            _callBackUploadingProgress(progress);
    //        };

    //        www.Send();
    //    }
    //}
    //private void SubmitDrill(AuthenticationMetadata _authenticationMetadata, RoadmapSubmissionMetaData _drillSubmissionMetaData, string _postURL, HTTPMethods _hTTPMethods, Action _callBacKOnSuccess, Action _callBacKOnfailed, Action <float>_callBackUploadingProgress)
    //{
    //    if (!UIManager.GetInstance().IsInternetAvailable())
    //    {
    //        UIManager.GetInstance().ActiveNoWifi();
    //        UIManager.GetInstance().InactiveLoadingPanel();
    //        _callBacKOnfailed();
    //    }
    //    else
    //    {
    //        HTTPRequest www = new HTTPRequest(new Uri(webURLPrefix + _postURL), _hTTPMethods, (request, response) =>
    //        {
    //            HTTPResponse res = (HTTPResponse)response;

    //            Debug.Log("messsage  = " + res.DataAsText);
    //            Debug.Log("status code: " + res.StatusCode);

    //            if (res.IsSuccess)
    //            {
    //                //  benchmarkResponce = new Dictionary<string, object>();
    //                // benchmarkResponce = Json.Decode(res.DataAsText) as Dictionary<string, object>;
    //                //  benchmarkData = Json.Encode(benchmarkResponce["data"]);

    //                // benchmarkMetaData = new RoadmapMetaData();
    //                //  benchmarkMetaData = JsonUtility.FromJson<RoadmapMetaData>(benchmarkData);

    //                _callBacKOnSuccess();
    //            }
    //            else
    //            {
    //                try
    //                {
    //                    errorMetaData = new ErrorMetaData();
    //                    errorMetaData = JsonUtility.FromJson<ErrorMetaData>(res.DataAsText);
    //                    UIManager.GetInstance().ActiveMessagePanel(errorMetaData.errorDetail[0].errors[0].message);
    //                }
    //                catch
    //                {
    //                    UIManager.GetInstance().ActiveMessagePanel("Cannot reach to the server!");
    //                }

    //                _callBacKOnfailed();
    //            }
    //        });

    //        www.AddHeader("Content-Type", "application/json");

    //        if (!string.IsNullOrEmpty(_authenticationMetadata.authenticationToken))
    //            www.AddHeader("authorization", _authenticationMetadata.authenticationToken);

    //        www.RawData = System.Text.Encoding.UTF8.GetBytes(JsonUtility.ToJson(_drillSubmissionMetaData));

    //        www.OnUploadProgress = (req, uploaded, total) =>
    //        {
    //            float progress = (float)uploaded / total;
    //            _callBackUploadingProgress(progress);
    //        };

    //        www.Send();
    //    }
    //}
    //private void AskForOTP(AuthenticationMetadata _authenticationMetadata, string _postURL, HTTPMethods _hTTPMethods, Action _callBacKOnSuccess, Action _callBacKOnfailed)
    //{
    //    if (!UIManager.GetInstance().IsInternetAvailable())
    //    {
    //        UIManager.GetInstance().ActiveNoWifi();
    //        UIManager.GetInstance().InactiveLoadingPanel();
    //        _callBacKOnfailed();
    //    }
    //    else
    //    {
    //        Debug.Log(webURLPrefix + _postURL);

    //        HTTPRequest www = new HTTPRequest(new Uri(webURLPrefix + _postURL), _hTTPMethods, (request, response) =>
    //        {
    //            HTTPResponse res = (HTTPResponse)response;
    //            Debug.Log("messsage  = " + res.DataAsText);
    //            Debug.Log("status code: " + res.StatusCode);

    //            if (res.IsSuccess)
    //            {
    //                UIManager.GetInstance().ActiveMessagePanel("Please check your mail box!");
    //                _callBacKOnSuccess();
    //            }
    //            else
    //            {
    //                try
    //                {
    //                    errorMetaData = new ErrorMetaData();
    //                    errorMetaData = JsonUtility.FromJson<ErrorMetaData>(res.DataAsText);
    //                    UIManager.GetInstance().ActiveMessagePanel(errorMetaData.errorDetail[0].errors[0].message);
    //                }
    //                catch
    //                {
    //                    UIManager.GetInstance().ActiveMessagePanel("Cannot reach to the server!");
    //                }
    //                _callBacKOnfailed();
    //            }
    //        });

    //        www.AddHeader("Content-Type", "application/json");

    //        if (!string.IsNullOrEmpty(_authenticationMetadata.authenticationToken))
    //            www.AddHeader("authorization", _authenticationMetadata.authenticationToken);

    //        if (!string.IsNullOrEmpty(_authenticationMetadata.deviceId))
    //            www.AddHeader("deviceId", _authenticationMetadata.deviceId);

    //        www.RawData = System.Text.Encoding.UTF8.GetBytes(JsonUtility.ToJson(_authenticationMetadata));

    //        www.Send();
    //    }
    //}
    //private void UserFirendList(AuthenticationMetadata _authenticationMetadata, string _postURL, HTTPMethods _hTTPMethods, Action _callBacKOnSuccess, Action _callBacKOnfailed)
    //{
    //    if (!UIManager.GetInstance().IsInternetAvailable())
    //    {
    //        UIManager.GetInstance().ActiveNoWifi();
    //        UIManager.GetInstance().InactiveLoadingPanel();
    //        _callBacKOnfailed();
    //    }
    //    else
    //    {
    //        Debug.Log(webURLPrefix + _postURL);

    //        HTTPRequest www = new HTTPRequest(new Uri(webURLPrefix + _postURL), _hTTPMethods, (request, response) =>
    //        {
    //            HTTPResponse res = (HTTPResponse)response;
    //            Debug.Log("messsage  = " + res.DataAsText);
    //            Debug.Log("status code: " + res.StatusCode);

    //            if (res.IsSuccess)
    //            {
    //                friendsListResponse = new Dictionary<string, object>();
    //                friendsListResponse = Json.Decode(res.DataAsText) as Dictionary<string, object>;
    //                friendsListData = Json.Encode(friendsListResponse["data"]);

    //                friendsMetaData = new FriendsMetaData();
    //                friendsMetaData = JsonUtility.FromJson<FriendsMetaData>(friendsListData);

    //                _callBacKOnSuccess();
    //            }
    //            else
    //            {
    //                try
    //                {
    //                    errorMetaData = new ErrorMetaData();
    //                    errorMetaData = JsonUtility.FromJson<ErrorMetaData>(res.DataAsText);
    //                    UIManager.GetInstance().ActiveMessagePanel(errorMetaData.errorDetail[0].errors[0].message);
    //                }
    //                catch
    //                {
    //                    UIManager.GetInstance().ActiveMessagePanel("Cannot reach to the server!");
    //                }
    //                _callBacKOnfailed();
    //            }
    //        });

    //        www.AddHeader("Content-Type", "application/json");

    //        if (!string.IsNullOrEmpty(_authenticationMetadata.authenticationToken))
    //            www.AddHeader("authorization", _authenticationMetadata.authenticationToken);

    //        if (!string.IsNullOrEmpty(_authenticationMetadata.deviceId))
    //            www.AddHeader("deviceId", _authenticationMetadata.deviceId);

    //        www.RawData = System.Text.Encoding.UTF8.GetBytes(JsonUtility.ToJson(_authenticationMetadata));

    //        www.Send();
    //    }
    //}
    //private void GetDailyStats(AuthenticationMetadata _authenticationMetadata, string _date, string _postURL, HTTPMethods _hTTPMethods, Action _callBacKOnSuccess, Action _callBacKOnfailed)
    //{
    //    if (!UIManager.GetInstance().IsInternetAvailable())
    //    {
    //        UIManager.GetInstance().ActiveNoWifi();
    //        UIManager.GetInstance().InactiveLoadingPanel();
    //        _callBacKOnfailed();
    //    }
    //    else
    //    {
    //        Debug.Log(webURLPrefix + _postURL);

    //        HTTPRequest www = new HTTPRequest(new Uri(webURLPrefix + _postURL), _hTTPMethods, (request, response) =>
    //        {
    //            HTTPResponse res = (HTTPResponse)response;
    //            Debug.Log("messsage  = " + res.DataAsText);
    //            Debug.Log("status code: " + res.StatusCode);

    //            if (res.IsSuccess)
    //            {
    //                dailyStatsResponse = new Dictionary<string, object>();
    //                dailyStatsResponse = Json.Decode(res.DataAsText) as Dictionary<string, object>;
    //                dailyStatsData = Json.Encode(dailyStatsResponse["data"]);

    //                dailyStats = new DailyStats();
    //                dailyStats = JsonUtility.FromJson<DailyStats>(dailyStatsData);

    //                Debug.Log("dailyStats" + JsonUtility.ToJson(dailyStats));
    //                _callBacKOnSuccess();
    //            }
    //            else
    //            {
    //                try
    //                {
    //                    errorMetaData = new ErrorMetaData();
    //                    errorMetaData = JsonUtility.FromJson<ErrorMetaData>(res.DataAsText);
    //                    UIManager.GetInstance().ActiveMessagePanel(errorMetaData.errorDetail[0].errors[0].message);
    //                }
    //                catch
    //                {
    //                    UIManager.GetInstance().ActiveMessagePanel("Cannot reach to the server!");
    //                }
    //                _callBacKOnfailed();
    //            }
    //        });

    //        www.AddHeader("Content-Type", "application/json");

    //        if (!string.IsNullOrEmpty(_authenticationMetadata.authenticationToken))
    //            www.AddHeader("authorization", _authenticationMetadata.authenticationToken);

    //        if (!string.IsNullOrEmpty(_authenticationMetadata.deviceId))
    //            www.AddHeader("deviceId", _authenticationMetadata.deviceId);

    //        www.RawData = System.Text.Encoding.UTF8.GetBytes(JsonUtility.ToJson(_authenticationMetadata));

    //        www.Send();
    //    }
    //}
    //private void GetFriendForRequest(AuthenticationMetadata _authenticationMetadata, FriendingMetaData _friendingMetaData, string _postURL, HTTPMethods _hTTPMethods, Action _callBacKOnSuccess, Action _callBacKOnfailed)
    //{
    //    if (!UIManager.GetInstance().IsInternetAvailable())
    //    {
    //        UIManager.GetInstance().ActiveNoWifi();
    //        UIManager.GetInstance().InactiveLoadingPanel();
    //        _callBacKOnfailed();
    //    }
    //    else
    //    {
    //        Debug.Log(webURLPrefix + _postURL);

    //        HTTPRequest www = new HTTPRequest(new Uri(webURLPrefix + _postURL), _hTTPMethods, (request, response) =>
    //        {
    //            HTTPResponse res = (HTTPResponse)response;
    //            Debug.Log("messsage  = " + res.DataAsText);
    //            Debug.Log("status code: " + res.StatusCode);

    //            if (res.IsSuccess)
    //            {
    //                searchUserForRequestResponse = new Dictionary<string, object>();
    //                searchUserForRequestResponse = Json.Decode(res.DataAsText) as Dictionary<string, object>;
    //                searchUserForRequestData = Json.Encode(searchUserForRequestResponse["data"]);

    //                searchForFriendResult = new SearchForFriendResult();
    //                searchForFriendResult = JsonUtility.FromJson<SearchForFriendResult>(searchUserForRequestData);

    //                _callBacKOnSuccess();
    //            }
    //            else
    //            {
    //                try
    //                {
    //                    errorMetaData = new ErrorMetaData();
    //                    errorMetaData = JsonUtility.FromJson<ErrorMetaData>(res.DataAsText);
    //                    UIManager.GetInstance().ActiveMessagePanel(errorMetaData.errorDetail[0].errors[0].message);
    //                }
    //                catch
    //                {
    //                    UIManager.GetInstance().ActiveMessagePanel("Cannot reach to the server!");
    //                }
    //                _callBacKOnfailed();
    //            }
    //        });

    //        www.AddHeader("Content-Type", "application/json");

    //        if (!string.IsNullOrEmpty(_authenticationMetadata.authenticationToken))
    //            www.AddHeader("authorization", _authenticationMetadata.authenticationToken);

    //        if (!string.IsNullOrEmpty(_authenticationMetadata.deviceId))
    //            www.AddHeader("deviceId", _authenticationMetadata.deviceId);

    //        www.RawData = System.Text.Encoding.UTF8.GetBytes(JsonUtility.ToJson(_friendingMetaData));

    //        www.Send();
    //    }
    //}
    //private void SendFriendRequest(AuthenticationMetadata _authenticationMetadata, FriendingMetaData _friendingMetaData, string _postURL, HTTPMethods _hTTPMethods, Action _callBacKOnSuccess, Action _callBacKOnfailed)
    //{
    //    if (!UIManager.GetInstance().IsInternetAvailable())
    //    {
    //        UIManager.GetInstance().ActiveNoWifi();
    //        UIManager.GetInstance().InactiveLoadingPanel();
    //        _callBacKOnfailed();
    //    }
    //    else
    //    {
    //        Debug.Log(webURLPrefix + _postURL);

    //        HTTPRequest www = new HTTPRequest(new Uri(webURLPrefix + _postURL), _hTTPMethods, (request, response) =>
    //        {
    //            HTTPResponse res = (HTTPResponse)response;
    //            Debug.Log("messsage  = " + res.DataAsText);
    //            Debug.Log("status code: " + res.StatusCode);

    //            if (res.IsSuccess)
    //            {

    //                _callBacKOnSuccess();
    //            }
    //            else
    //            {
    //                try
    //                {
    //                    errorMetaData = new ErrorMetaData();
    //                    errorMetaData = JsonUtility.FromJson<ErrorMetaData>(res.DataAsText);
    //                    UIManager.GetInstance().ActiveMessagePanel(errorMetaData.errorDetail[0].errors[0].message);
    //                }
    //                catch
    //                {
    //                    UIManager.GetInstance().ActiveMessagePanel("Cannot reach to the server!");
    //                }
    //                _callBacKOnfailed();
    //            }
    //        });

    //        www.AddHeader("Content-Type", "application/json");

    //        if (!string.IsNullOrEmpty(_authenticationMetadata.authenticationToken))
    //            www.AddHeader("authorization", _authenticationMetadata.authenticationToken);

    //        if (!string.IsNullOrEmpty(_authenticationMetadata.deviceId))
    //            www.AddHeader("deviceId", _authenticationMetadata.deviceId);

    //        www.RawData = System.Text.Encoding.UTF8.GetBytes(JsonUtility.ToJson(_friendingMetaData));

    //        www.Send();
    //    }
    //}
    //private void AcceptFriendRequest(AuthenticationMetadata _authenticationMetadata, FriendingMetaData _friendingMetaData, string _postURL, HTTPMethods _hTTPMethods, Action _callBacKOnSuccess, Action _callBacKOnfailed)
    //{
    //    if (!UIManager.GetInstance().IsInternetAvailable())
    //    {
    //        UIManager.GetInstance().ActiveNoWifi();
    //        UIManager.GetInstance().InactiveLoadingPanel();
    //        _callBacKOnfailed();
    //    }
    //    else
    //    {
    //        Debug.Log(webURLPrefix + _postURL);

    //        HTTPRequest www = new HTTPRequest(new Uri(webURLPrefix + _postURL), _hTTPMethods, (request, response) =>
    //        {
    //            HTTPResponse res = (HTTPResponse)response;
    //            Debug.Log("messsage  = " + res.DataAsText);
    //            Debug.Log("status code: " + res.StatusCode);

    //            if (res.IsSuccess)
    //            {

    //                _callBacKOnSuccess();
    //            }
    //            else
    //            {
    //                try
    //                {
    //                    errorMetaData = new ErrorMetaData();
    //                    errorMetaData = JsonUtility.FromJson<ErrorMetaData>(res.DataAsText);
    //                    UIManager.GetInstance().ActiveMessagePanel(errorMetaData.errorDetail[0].errors[0].message);
    //                }
    //                catch
    //                {
    //                    UIManager.GetInstance().ActiveMessagePanel("Cannot reach to the server!");
    //                }
    //                _callBacKOnfailed();
    //            }
    //        });

    //        www.AddHeader("Content-Type", "application/json");

    //        if (!string.IsNullOrEmpty(_authenticationMetadata.authenticationToken))
    //            www.AddHeader("authorization", _authenticationMetadata.authenticationToken);

    //        if (!string.IsNullOrEmpty(_authenticationMetadata.deviceId))
    //            www.AddHeader("deviceId", _authenticationMetadata.deviceId);

    //        www.RawData = System.Text.Encoding.UTF8.GetBytes(JsonUtility.ToJson(_friendingMetaData));

    //        www.Send();
    //    }
    //}
    //private void GetInboxMessages(AuthenticationMetadata _authenticationMetadata, FriendingMetaData _friendingMetaData, string _postURL, HTTPMethods _hTTPMethods, Action _callBacKOnSuccess, Action _callBacKOnfailed, Action<float> _callBackUploadingProgress)
    //{
    //    if (!UIManager.GetInstance().IsInternetAvailable())
    //    {
    //        UIManager.GetInstance().ActiveNoWifi();
    //        UIManager.GetInstance().InactiveLoadingPanel();
    //        _callBacKOnfailed();
    //    }
    //    else
    //    {
    //        Debug.Log(webURLPrefix + _postURL);

    //        HTTPRequest www = new HTTPRequest(new Uri(webURLPrefix + _postURL), _hTTPMethods, (request, response) =>
    //        {
    //            HTTPResponse res = (HTTPResponse)response;
    //            Debug.Log("messsage  = " + res.DataAsText);
    //            Debug.Log("status code: " + res.StatusCode);

    //            if (res.IsSuccess)
    //            {

    //                inboxRequestResponse = new Dictionary<string, object>();
    //                inboxRequestResponse = Json.Decode(res.DataAsText) as Dictionary<string, object>;
    //                inboxRequestData = Json.Encode(inboxRequestResponse["data"]);

    //                inboxMetaData = new InboxMetaData();
    //                inboxMetaData = JsonUtility.FromJson<InboxMetaData>(inboxRequestData);

    //                _callBacKOnSuccess();
    //            }
    //            else
    //            {
    //                try
    //                {
    //                    errorMetaData = new ErrorMetaData();
    //                    errorMetaData = JsonUtility.FromJson<ErrorMetaData>(res.DataAsText);
    //                    UIManager.GetInstance().ActiveMessagePanel(errorMetaData.errorDetail[0].errors[0].message);
    //                }
    //                catch
    //                {
    //                    UIManager.GetInstance().ActiveMessagePanel("Cannot reach to the server!");
    //                }
    //                _callBacKOnfailed();
    //            }
    //        });

    //        www.AddHeader("Content-Type", "application/json");

    //        if (!string.IsNullOrEmpty(_authenticationMetadata.authenticationToken))
    //            www.AddHeader("authorization", _authenticationMetadata.authenticationToken);

    //        if (!string.IsNullOrEmpty(_authenticationMetadata.deviceId))
    //            www.AddHeader("deviceId", _authenticationMetadata.deviceId);

    //        www.RawData = System.Text.Encoding.UTF8.GetBytes(JsonUtility.ToJson(_friendingMetaData));

    //        www.OnDownloadProgress = (req, uploaded, total) =>
    //        {
    //            float progress = (float)uploaded / total;
    //            _callBackUploadingProgress(progress);
    //        };

    //        www.Send();
    //    }
    //}
    //private void ContractSigning(AuthenticationMetadata _authenticationMetadata, string _postURL, HTTPMethods _hTTPMethods, Action _callBacKOnSuccess, Action _callBacKOnfailed)
    //{
    //    if (!UIManager.GetInstance().IsInternetAvailable())
    //    {
    //        UIManager.GetInstance().ActiveNoWifi();
    //        UIManager.GetInstance().InactiveLoadingPanel();
    //        _callBacKOnfailed();
    //    }
    //    else
    //    {
    //        Debug.Log(webURLPrefix + _postURL);

    //        HTTPRequest www = new HTTPRequest(new Uri(webURLPrefix + _postURL), _hTTPMethods, (request, response) =>
    //        {
    //            HTTPResponse res = (HTTPResponse)response;
    //            Debug.Log("messsage  = " + res.DataAsText);
    //            Debug.Log("status code: " + res.StatusCode);

    //            if (res.IsSuccess)
    //            {



    //                _callBacKOnSuccess();
    //            }
    //            else
    //            {
    //                try
    //                {
    //                    errorMetaData = new ErrorMetaData();
    //                    errorMetaData = JsonUtility.FromJson<ErrorMetaData>(res.DataAsText);
    //                    UIManager.GetInstance().ActiveMessagePanel(errorMetaData.errorDetail[0].errors[0].message);
    //                }
    //                catch
    //                {
    //                    UIManager.GetInstance().ActiveMessagePanel("Cannot reach to the server!");
    //                }
    //                _callBacKOnfailed();
    //            }
    //        });

    //        www.AddHeader("Content-Type", "application/json");

    //        if (!string.IsNullOrEmpty(_authenticationMetadata.authenticationToken))
    //            www.AddHeader("authorization", _authenticationMetadata.authenticationToken);

    //        if (!string.IsNullOrEmpty(_authenticationMetadata.deviceId))
    //            www.AddHeader("deviceId", _authenticationMetadata.deviceId);

    //        www.RawData = System.Text.Encoding.UTF8.GetBytes(JsonUtility.ToJson(authenticationForm));

    //        www.Send();
    //    }
    //}
    //private void GetAchievements(AuthenticationMetadata _authenticationMetadata, string _postURL, HTTPMethods _hTTPMethods, Action _callBacKOnSuccess, Action _callBacKOnfailed)
    //{
    //    if (!UIManager.GetInstance().IsInternetAvailable())
    //    {
    //        UIManager.GetInstance().ActiveNoWifi();
    //        UIManager.GetInstance().InactiveLoadingPanel();
    //        _callBacKOnfailed();
    //    }
    //    else
    //    {
    //        Debug.Log(webURLPrefix + _postURL);

    //        HTTPRequest www = new HTTPRequest(new Uri(webURLPrefix + _postURL), _hTTPMethods, (request, response) =>
    //        {
    //            HTTPResponse res = (HTTPResponse)response;
    //            Debug.Log("messsage  = " + res.DataAsText);
    //            Debug.Log("status code: " + res.StatusCode);

    //            if (res.IsSuccess)
    //            {
    //                achievementsResponce = new Dictionary<string, object>();
    //                achievementsResponce = Json.Decode(res.DataAsText) as Dictionary<string, object>;
    //                achievementsData = Json.Encode(achievementsResponce["data"]);

    //                achievementsMetaData = new AchievementsMetaData();
    //                achievementsMetaData = JsonUtility.FromJson<AchievementsMetaData>(achievementsData);

    //                _callBacKOnSuccess();
    //            }
    //            else
    //            {
    //                try
    //                {
    //                    errorMetaData = new ErrorMetaData();
    //                    errorMetaData = JsonUtility.FromJson<ErrorMetaData>(res.DataAsText);
    //                    UIManager.GetInstance().ActiveMessagePanel(errorMetaData.errorDetail[0].errors[0].message);
    //                }
    //                catch
    //                {
    //                    UIManager.GetInstance().ActiveMessagePanel("Cannot reach to the server!");
    //                }
    //                _callBacKOnfailed();
    //            }
    //        });

    //        www.AddHeader("Content-Type", "application/json");

    //        if (!string.IsNullOrEmpty(_authenticationMetadata.authenticationToken))
    //            www.AddHeader("authorization", _authenticationMetadata.authenticationToken);

    //        if (!string.IsNullOrEmpty(_authenticationMetadata.deviceId))
    //            www.AddHeader("deviceId", _authenticationMetadata.deviceId);

    //        www.RawData = System.Text.Encoding.UTF8.GetBytes(JsonUtility.ToJson(_authenticationMetadata));

    //        www.Send();
    //    }
    //}
    //private void GetBadges(AuthenticationMetadata _authenticationMetadata, string _postURL, HTTPMethods _hTTPMethods, Action _callBacKOnSuccess, Action _callBacKOnfailed)
    //{
    //    if (!UIManager.GetInstance().IsInternetAvailable())
    //    {
    //        UIManager.GetInstance().ActiveNoWifi();
    //        UIManager.GetInstance().InactiveLoadingPanel();
    //        _callBacKOnfailed();
    //    }
    //    else
    //    {
    //        Debug.Log(webURLPrefix + _postURL);

    //        HTTPRequest www = new HTTPRequest(new Uri(webURLPrefix + _postURL), _hTTPMethods, (request, response) =>
    //        {
    //            HTTPResponse res = (HTTPResponse)response;
    //            Debug.Log("messsage  = " + res.DataAsText);
    //            Debug.Log("status code: " + res.StatusCode);

    //            if (res.IsSuccess)
    //            {
    //                badgesResponce = new Dictionary<string, object>();
    //                badgesResponce = Json.Decode(res.DataAsText) as Dictionary<string, object>;
    //                badgesData = Json.Encode(badgesResponce["data"]);

    //                badgesMetaData = new BadgesMetaData();
    //                badgesMetaData = JsonUtility.FromJson<BadgesMetaData>(badgesData);

    //                _callBacKOnSuccess();
    //            }
    //            else
    //            {
    //                try
    //                {
    //                    errorMetaData = new ErrorMetaData();
    //                    errorMetaData = JsonUtility.FromJson<ErrorMetaData>(res.DataAsText);
    //                    UIManager.GetInstance().ActiveMessagePanel(errorMetaData.errorDetail[0].errors[0].message);
    //                }
    //                catch
    //                {
    //                    UIManager.GetInstance().ActiveMessagePanel("Cannot reach to the server!");
    //                }
    //                _callBacKOnfailed();
    //            }
    //        });

    //        www.AddHeader("Content-Type", "application/json");

    //        if (!string.IsNullOrEmpty(_authenticationMetadata.authenticationToken))
    //            www.AddHeader("authorization", _authenticationMetadata.authenticationToken);

    //        if (!string.IsNullOrEmpty(_authenticationMetadata.deviceId))
    //            www.AddHeader("deviceId", _authenticationMetadata.deviceId);

    //        www.RawData = System.Text.Encoding.UTF8.GetBytes(JsonUtility.ToJson(_authenticationMetadata));

    //        www.Send();
    //    }
    //}
    //private void GetOtherPlayerProfile(OtherPlayerAuthMetadata _otherPlayerAuthMetadata, AuthenticationMetadata _authenticationMetadata, string _postURL, HTTPMethods _hTTPMethods, Action _callBacKOnSuccess, Action _callBacKOnfailed)
    //{
    //    if (!UIManager.GetInstance().IsInternetAvailable())
    //    {
    //        UIManager.GetInstance().ActiveNoWifi();
    //        UIManager.GetInstance().InactiveLoadingPanel();
    //        _callBacKOnfailed();
    //    }
    //    else
    //    {
    //        Debug.Log(webURLPrefix + _postURL);

    //        HTTPRequest www = new HTTPRequest(new Uri(webURLPrefix + _postURL), _hTTPMethods, (request, response) =>
    //        {
    //            HTTPResponse res = (HTTPResponse)response;
    //            Debug.Log("messsage  = " + res.DataAsText);
    //            Debug.Log("status code: " + res.StatusCode);

    //            if (res.IsSuccess)
    //            {
    //                otherPlayerProfileResponce = new Dictionary<string, object>();
    //                otherPlayerProfileResponce = Json.Decode(res.DataAsText) as Dictionary<string, object>;
    //                otherPlayerProfileData = Json.Encode(otherPlayerProfileResponce["data"]);

    //                otherPlayerProfileMetaData = new PlayerProfileMetaData();
    //                otherPlayerProfileMetaData = JsonUtility.FromJson<PlayerProfileMetaData>(otherPlayerProfileData);
    //                otherPlayerProfileMetaData.id = _otherPlayerAuthMetadata.authId;
    //                _callBacKOnSuccess();
    //            }
    //            else
    //            {
    //                try
    //                {
    //                    errorMetaData = new ErrorMetaData();
    //                    errorMetaData = JsonUtility.FromJson<ErrorMetaData>(res.DataAsText);
    //                    UIManager.GetInstance().ActiveMessagePanel(errorMetaData.errorDetail[0].errors[0].message);
    //                }
    //                catch
    //                {
    //                    UIManager.GetInstance().ActiveMessagePanel("Cannot reach to the server!");
    //                }
    //                _callBacKOnfailed();
    //            }
    //        });

    //        www.AddHeader("Content-Type", "application/json");

    //        if (!string.IsNullOrEmpty(_authenticationMetadata.authenticationToken))
    //            www.AddHeader("authorization", _authenticationMetadata.authenticationToken);

    //        if (!string.IsNullOrEmpty(_authenticationMetadata.deviceId))
    //            www.AddHeader("deviceId", _authenticationMetadata.deviceId);

    //        www.Send();
    //    }
    //}
    //private void GetFocusesData(AuthenticationMetadata _authenticationMetadata, string _postURL, HTTPMethods _hTTPMethods, Action _callBacKOnSuccess, Action _callBacKOnfailed, Action<float> _callBackUploadingProgress)
    //{
    //    if (!UIManager.GetInstance().IsInternetAvailable())
    //    {
    //        UIManager.GetInstance().ActiveNoWifi();
    //        UIManager.GetInstance().InactiveLoadingPanel();
    //        _callBacKOnfailed();
    //    }
    //    else
    //    {
    //        Debug.Log(webURLPrefix + _postURL);

    //        HTTPRequest www = new HTTPRequest(new Uri(webURLPrefix + _postURL), _hTTPMethods, (request, response) =>
    //        {
    //            HTTPResponse res = (HTTPResponse)response;
    //            Debug.Log("messsage  = " + res.DataAsText);
    //            Debug.Log("status code: " + res.StatusCode);

    //            if (res.IsSuccess)
    //            {
    //                focusesResponce = new Dictionary<string, object>();
    //                focusesResponce = Json.Decode(res.DataAsText) as Dictionary<string, object>;
    //                focusesData = Json.Encode(focusesResponce["data"]);

    //                focusesMetaData = new FocusesMetaData();
    //                focusesMetaData = JsonUtility.FromJson<FocusesMetaData>(focusesData);
    //                _callBacKOnSuccess();
    //            }
    //            else
    //            {
    //                try
    //                {
    //                    errorMetaData = new ErrorMetaData();
    //                    errorMetaData = JsonUtility.FromJson<ErrorMetaData>(res.DataAsText);
    //                    UIManager.GetInstance().ActiveMessagePanel(errorMetaData.errorDetail[0].errors[0].message);
    //                }
    //                catch
    //                {
    //                    UIManager.GetInstance().ActiveMessagePanel("Cannot reach to the server!");
    //                }
    //                _callBacKOnfailed();
    //            }
    //        });

    //        www.AddHeader("Content-Type", "application/json");

    //        if (!string.IsNullOrEmpty(_authenticationMetadata.authenticationToken))
    //            www.AddHeader("authorization", _authenticationMetadata.authenticationToken);

    //        if (!string.IsNullOrEmpty(_authenticationMetadata.deviceId))
    //            www.AddHeader("deviceId", _authenticationMetadata.deviceId);

    //        www.OnDownloadProgress = (req, uploaded, total) =>
    //        {
    //            float progress = (float)uploaded / total;
    //            _callBackUploadingProgress(progress);
    //        };

    //        www.Send();
    //    }
    //}
    //private void InformOnFocusesSelection(AuthenticationMetadata _authenticationMetadata, FocusMetaData _focusMetaData, string _postURL, HTTPMethods _hTTPMethods, Action _callBacKOnSuccess, Action _callBacKOnfailed)
    //{
    //    if (!UIManager.GetInstance().IsInternetAvailable())
    //    {
    //        UIManager.GetInstance().ActiveNoWifi();
    //        UIManager.GetInstance().InactiveLoadingPanel();
    //        _callBacKOnfailed();
    //    }
    //    else
    //    {
    //        Debug.Log(webURLPrefix + _postURL);

    //        HTTPRequest www = new HTTPRequest(new Uri(webURLPrefix + _postURL), _hTTPMethods, (request, response) =>
    //        {
    //            HTTPResponse res = (HTTPResponse)response;
    //            Debug.Log("messsage  = " + res.DataAsText);
    //            Debug.Log("status code: " + res.StatusCode);

    //            if (res.IsSuccess)
    //            {
    //                _callBacKOnSuccess();
    //            }
    //            else
    //            {
    //                try
    //                {
    //                    errorMetaData = new ErrorMetaData();
    //                    errorMetaData = JsonUtility.FromJson<ErrorMetaData>(res.DataAsText);
    //                    UIManager.GetInstance().ActiveMessagePanel(errorMetaData.errorDetail[0].errors[0].message);
    //                }
    //                catch
    //                {
    //                    UIManager.GetInstance().ActiveMessagePanel("Cannot reach to the server!");
    //                }
    //                _callBacKOnfailed();
    //            }
    //        });

    //        www.AddHeader("Content-Type", "application/json");

    //        if (!string.IsNullOrEmpty(_authenticationMetadata.authenticationToken))
    //            www.AddHeader("authorization", _authenticationMetadata.authenticationToken);

    //        if (!string.IsNullOrEmpty(_authenticationMetadata.deviceId))
    //            www.AddHeader("deviceId", _authenticationMetadata.deviceId);

    //        www.RawData = System.Text.Encoding.UTF8.GetBytes(JsonUtility.ToJson(_focusMetaData));

    //        www.Send();
    //    }
    //}
    //private void GetFacts(AuthenticationMetadata _authenticationMetadata, string _postURL, HTTPMethods _hTTPMethods, Action _callBacKOnSuccess, Action _callBacKOnfailed, Action<float> _callBackUploadingProgress)
    //{
    //    if (!UIManager.GetInstance().IsInternetAvailable())
    //    {
    //        UIManager.GetInstance().ActiveNoWifi();
    //        UIManager.GetInstance().InactiveLoadingPanel();
    //        _callBacKOnfailed();
    //    }
    //    else
    //    {
    //        Debug.Log(webURLPrefix + _postURL);

    //        HTTPRequest www = new HTTPRequest(new Uri(webURLPrefix + _postURL), _hTTPMethods, (request, response) =>
    //        {
    //            HTTPResponse res = (HTTPResponse)response;
    //            Debug.Log("messsage  = " + res.DataAsText);
    //            Debug.Log("status code: " + res.StatusCode);

    //            if (res.IsSuccess)
    //            {
    //                factsResponce = new Dictionary<string, object>();
    //                factsResponce = Json.Decode(res.DataAsText) as Dictionary<string, object>;
    //                factsData = Json.Encode(factsResponce["data"]);

    //                factsMetaData = new FactsMetaData();
    //                factsMetaData = JsonUtility.FromJson<FactsMetaData>(factsData);

    //                _callBacKOnSuccess();
    //            }
    //            else
    //            {
    //                try
    //                {
    //                    errorMetaData = new ErrorMetaData();
    //                    errorMetaData = JsonUtility.FromJson<ErrorMetaData>(res.DataAsText);
    //                    UIManager.GetInstance().ActiveMessagePanel(errorMetaData.errorDetail[0].errors[0].message);
    //                }
    //                catch
    //                {
    //                    UIManager.GetInstance().ActiveMessagePanel("Cannot reach to the server!");
    //                }
    //                _callBacKOnfailed();
    //            }
    //        });

    //        www.AddHeader("Content-Type", "application/json");

    //        if (!string.IsNullOrEmpty(_authenticationMetadata.authenticationToken))
    //            www.AddHeader("authorization", _authenticationMetadata.authenticationToken);

    //        if (!string.IsNullOrEmpty(_authenticationMetadata.deviceId))
    //            www.AddHeader("deviceId", _authenticationMetadata.deviceId);

    //        www.OnDownloadProgress = (req, uploaded, total) =>
    //        {
    //            float progress = (float)uploaded / total;
    //            _callBackUploadingProgress(progress);
    //        };

    //        www.Send();
    //    }
    //}
    #endregion

    #region callbacks
    //private void OnFacebookAuthenticationSuccessful(Dictionary<string, object> _fbUserDetails, string _userCurrentAccessToken)
    //{
    //    fbPicture = new Dictionary<string, object>();
    //    fbPictureData = new Dictionary<string, object>();
    //    fbPicture = (Dictionary<string, object>)_fbUserDetails["picture"];
    //    fbPictureData = (Dictionary<string, object>)fbPicture["data"];

    //    authenticationForm.authId = _fbUserDetails["id"].ToString();
    //    authenticationForm.email = _fbUserDetails["email"].ToString();
    //    authenticationForm.profileImageUrl = fbPictureData["url"].ToString();
    //    authenticationForm.authProvider = authProvider.ToString();

    //    Authentication(authenticationForm, AuthenticationAPI, HTTPMethods.Post, onSucessfulSocialMediaAuthentication, OnFacebookAuthenticationFailed);
    //}
    //private void OnFacebookAuthenticationFailed()
    //{
    //    UIManager.GetInstance().InactiveLoadingPanel();
    //    UIManager.GetInstance().ActiveMessagePanel("Some this is wrong. Can not authenticate with Facebook.");
    //}
    //private void OnGoogleAuthenticationSuccessful(GoogleSignInUser _googleUser)
    //{
    //    authenticationForm.authId = _googleUser.UserId;
    //    authenticationForm.email = _googleUser.Email;
    //    authenticationForm.profileImageUrl = _googleUser.ImageUrl.ToString();
    //    authenticationForm.authProvider = authProvider.ToString();

    //    Authentication(authenticationForm, AuthenticationAPI, HTTPMethods.Post, onSucessfulSocialMediaAuthentication, OnGoogleAuthenticationFailed);
    //}
    //private void OnGoogleAuthenticationFailed()
    //{
    //    UIManager.GetInstance().InactiveLoadingPanel();
    //    UIManager.GetInstance().ActiveMessagePanel("Some this is wrong. Can not authenticate with Google.");
    //}
    //private void OnGoogleAuthenticationSuccessfulForApple(AuthenticationMetadata _googleUser)
    //{
    //    authenticationForm.authId = _googleUser.authId;
    //    authenticationForm.email = _googleUser.email;
    //    authenticationForm.profileImageUrl = _googleUser.profileImageUrl;
    //    authenticationForm.authProvider = authProvider.ToString();

    //    Authentication(authenticationForm, AuthenticationAPI, HTTPMethods.Post, onSucessfulSocialMediaAuthentication, OnGoogleAuthenticationFailedForApple);
    //}
    //private void OnGoogleAuthenticationFailedForApple()
    //{
    //    UIManager.GetInstance().InactiveLoadingPanel();
    //    UIManager.GetInstance().ActiveMessagePanel("Some this is wrong. Can not authenticate with Google.");
    //}
    //private void OnAppleAuthenticationSuccessfulForApple(AuthenticationMetadata _appleUser)
    //{
    //    authenticationForm.authId = _appleUser.authId;
    //    authenticationForm.email = _appleUser.email;
    //    authenticationForm.profileImageUrl = _appleUser.profileImageUrl;
    //    authenticationForm.authProvider = authProvider.ToString();

    //    Authentication(authenticationForm, AuthenticationAPI, HTTPMethods.Post, onSucessfulSocialMediaAuthentication, OnAppleAuthenticationFailedForApple);
    //}
    //private void OnAppleAuthenticationFailedForApple()
    //{
    //    UIManager.GetInstance().InactiveLoadingPanel();
    //    UIManager.GetInstance().ActiveMessagePanel("Some this is wrong. Can not authenticate with Apple.");
    //}
    #endregion

    #region Public methods For API Calls
    //    public void AuthenticateWithSocialMedia(Action _onSucessfulSocialMediaAuthentication, AuthProvider _authProvider)
    //    {
    //        onSucessfulSocialMediaAuthentication = _onSucessfulSocialMediaAuthentication;
    //        authProvider = _authProvider;
    //        if (_authProvider == AuthProvider.FACEBOOK)
    //        {
    //            facebookManager.LoginToFacebook(OnFacebookAuthenticationSuccessful, OnFacebookAuthenticationFailed);
    //        }
    //#if UNITY_ANDROID
    //        else if (_authProvider == AuthProvider.GOOGLE)
    //        {
    //            firebaseManager.OnGoogleSignIn(OnGoogleAuthenticationSuccessful, OnGoogleAuthenticationFailed);
    //        }
    //#endif
    //#if UNITY_IOS
    //        else if (_authProvider == AuthProvider.GOOGLE)
    //        {
    //            lcGoogleSignInManager.OnGoogleSignIn(OnGoogleAuthenticationSuccessfulForApple, OnGoogleAuthenticationFailedForApple);
    //        }
    //        if (_authProvider == AuthProvider.APPLE)
    //        {
    //            appleSignInManager.OnAppleSignInCall(OnAppleAuthenticationSuccessfulForApple, OnAppleAuthenticationFailedForApple);
    //        }
    //#endif
    //    }
    //    public void OnGuestUserAuthenticationCall(string _apiEndPoint, HTTPMethods _hTTPMethods, Action _callBackOnSuccess, Action _callBackOnFailed)
    //    {
    //        Authentication(authenticationForm, _apiEndPoint, _hTTPMethods, _callBackOnSuccess, _callBackOnFailed);
    //    }
    //    public void OnAuthenticationCall(string _apiEndPoint, HTTPMethods _hTTPMethods, Action _callBackOnSuccess, Action _callBackOnFailed)
    //    {
    //        Authentication(authenticationForm, _apiEndPoint, _hTTPMethods, _callBackOnSuccess, _callBackOnFailed);
    //    }
    //    public void OnUpdateProfileCall(AuthenticationMetadata _authenticationMetadata, string _apiEndPoint, HTTPMethods _hTTPMethods, Action _callBackOnSuccess, Action _callBackOnFailed)
    //    {
    //        authenticationForm = _authenticationMetadata;
    //        Authentication(authenticationForm, _apiEndPoint, _hTTPMethods, _callBackOnSuccess, _callBackOnFailed);
    //    }
    //    public void OnDownloadDailDrillCall(string _apiEndPoint, HTTPMethods _hTTPMethods, Action _callBackOnSuccess, Action _callBackOnFailed, Action<float> _callBackUploadingProgress)
    //    {
    //        DownloadDailyDrillsData(authenticationForm, _apiEndPoint, _hTTPMethods, _callBackOnSuccess, _callBackOnFailed, _callBackUploadingProgress);
    //    }
    //    public void OnDownloadBenchmarkCall(string _apiEndPoint, HTTPMethods _hTTPMethods, Action _callBackOnSuccess, Action _callBackOnFailed, Action<float> _callBackUploadingProgress)
    //    {
    //        DownloadBenchmarkData(authenticationForm, _apiEndPoint, _hTTPMethods, _callBackOnSuccess, _callBackOnFailed, _callBackUploadingProgress);
    //    }
    //    public void OnSendTimeLogsCall(TimeLogsMetaData _timeLogsToSend, Action _callBacK)
    //    {
    //        SendTimeLogs(authenticationForm, _timeLogsToSend, TimeLogsAPI, HTTPMethods.Post, _callBacK);
    //    }
    //    public void OnSubmitMediaCall(MediaToSubmitMetaData _mediaToSubmitMetaData, string _postURL, HTTPMethods _hTTPMethods, Action _callBacKOnSuccess, Action _callBacKOnfailed, Action<float> _callBackUploadingProgress)
    //    {
    //        SubmitMedia(authenticationForm, _mediaToSubmitMetaData, _postURL, _hTTPMethods, _callBacKOnSuccess, _callBacKOnfailed, _callBackUploadingProgress);
    //    }
    //    public void OnSubmitDrillCall(RoadmapSubmissionMetaData _drillSubmissionMetaData, string _postURL, HTTPMethods _hTTPMethods, Action _callBacKOnSuccess, Action _callBacKOnfailed,Action <float>_callBackUploadingProgress)
    //    {
    //        SubmitDrill(authenticationForm, _drillSubmissionMetaData, _postURL, _hTTPMethods, _callBacKOnSuccess, _callBacKOnfailed, _callBackUploadingProgress);
    //    }
    //    public void OnAskForOTP(string _email, string _authProvider, string _postURL, HTTPMethods _hTTPMethods, Action _callBacKOnSuccess, Action _callBacKOnfailed)
    //    {
    //        authenticationForm.email = _email;
    //        Debug.Log(authenticationForm.email);
    //        authenticationForm.authProvider = _authProvider;
    //        AskForOTP(authenticationForm, _postURL, _hTTPMethods, _callBacKOnSuccess, _callBacKOnfailed);
    //    }
    //    public void OnAuthenticateWithOTP(string _otp, string _postURL, HTTPMethods _hTTPMethods, Action _callBacKOnSuccess, Action _callBacKOnfailed)
    //    {
    //        authenticationForm.otp = _otp;
    //        Authentication(authenticationForm, _postURL, _hTTPMethods, _callBacKOnSuccess, _callBacKOnfailed);
    //    }
    //    public void OnUserFirendList(string _postURL, HTTPMethods _hTTPMethods, Action _callBacKOnSuccess, Action _callBacKOnfailed)
    //    {
    //        UserFirendList(authenticationForm, _postURL, _hTTPMethods, _callBacKOnSuccess, _callBacKOnfailed);
    //    }
    //    public void OnDailyStats(string _date, string _postURL, HTTPMethods _hTTPMethods, Action _callBacKOnSuccess, Action _callBacKOnfailed)
    //    {
    //        authenticationForm.date = _date;
    //        GetDailyStats(authenticationForm, _date, _postURL, _hTTPMethods, _callBacKOnSuccess, _callBacKOnfailed);
    //    }
    //    public void OnSearchForFriend(string _searchKey, string _postURL, HTTPMethods _hTTPMethods, Action _callBacKOnSuccess, Action _callBacKOnfailed)
    //    {
    //        friendingMetaData = new FriendingMetaData();
    //        friendingMetaData.searchQuery = _searchKey;
    //        GetFriendForRequest(authenticationForm, friendingMetaData, _postURL, _hTTPMethods, _callBacKOnSuccess, _callBacKOnfailed);
    //    }
    //    public void OnSendFriendRequest(string _friendId, string _postURL, HTTPMethods _hTTPMethods, Action _callBacKOnSuccess, Action _callBacKOnfailed)
    //    {
    //        friendingMetaData = new FriendingMetaData();
    //        friendingMetaData.friendId = _friendId;
    //        SendFriendRequest(authenticationForm, friendingMetaData, _postURL, _hTTPMethods, _callBacKOnSuccess, _callBacKOnfailed);
    //    }
    //    public void OnAcceptFriendRequest(string _friendId, string _postURL, HTTPMethods _hTTPMethods, Action _callBacKOnSuccess, Action _callBacKOnfailed)
    //    {
    //        friendingMetaData = new FriendingMetaData();
    //        friendingMetaData.friendId = _friendId;
    //        AcceptFriendRequest(authenticationForm, friendingMetaData, _postURL, _hTTPMethods, _callBacKOnSuccess, _callBacKOnfailed);
    //    }
    //    public void OnRejectFriendRequest(string _friendId, string _postURL, HTTPMethods _hTTPMethods, Action _callBacKOnSuccess, Action _callBacKOnfailed)
    //    {
    //        friendingMetaData = new FriendingMetaData();
    //        friendingMetaData.friendId = _friendId;
    //        AcceptFriendRequest(authenticationForm, friendingMetaData, _postURL, _hTTPMethods, _callBacKOnSuccess, _callBacKOnfailed);
    //    }
    //    public void OnRemoveFriendRequest(string _friendId, string _postURL, HTTPMethods _hTTPMethods, Action _callBacKOnSuccess, Action _callBacKOnfailed)
    //    {
    //        friendingMetaData = new FriendingMetaData();
    //        friendingMetaData.friendId = _friendId;
    //        AcceptFriendRequest(authenticationForm, friendingMetaData, _postURL, _hTTPMethods, _callBacKOnSuccess, _callBacKOnfailed);
    //    }
    //    public void OnGetInboxMessages(string _postURL, HTTPMethods _hTTPMethods, Action _callBacKOnSuccess, Action _callBacKOnfailed, Action<float> _callBackUploadingProgress)
    //    {
    //        friendingMetaData = new FriendingMetaData();
    //        friendingMetaData.types.Add(NotificationType.FRIENDING.ToString());
    //        GetInboxMessages(authenticationForm, friendingMetaData, _postURL, _hTTPMethods, _callBacKOnSuccess, _callBacKOnfailed, _callBackUploadingProgress);
    //    }
    //    public void OnContractSignSubmit(string _postURL, HTTPMethods _hTTPMethods, Action _callBacKOnSuccess, Action _callBacKOnfailed)
    //    {
    //        authenticationForm.contractSigned = true;
    //        ContractSigning(authenticationForm, _postURL, _hTTPMethods, _callBacKOnSuccess, _callBacKOnfailed);
    //    }
    //    public void OnGetAchievement(string _postURL, HTTPMethods _hTTPMethods, Action _callBacKOnSuccess, Action _callBacKOnfailed)
    //    {
    //        GetAchievements(authenticationForm, _postURL, _hTTPMethods, _callBacKOnSuccess, _callBacKOnfailed);
    //    }
    //    public void OnGetBadges(string _postURL, HTTPMethods _hTTPMethods, Action _callBacKOnSuccess, Action _callBacKOnfailed)
    //    {
    //        GetBadges(authenticationForm, _postURL, _hTTPMethods, _callBacKOnSuccess, _callBacKOnfailed);
    //    }
    //    public void OnOtherPlayerProfileCall(string _userId, string _apiEndPoint, HTTPMethods _hTTPMethods, Action _callBackOnSuccess, Action _callBackOnFailed)
    //    {
    //        otherPlayerAuthMetadata = new OtherPlayerAuthMetadata();
    //        otherPlayerAuthMetadata.authId = _userId;
    //        GetOtherPlayerProfile(otherPlayerAuthMetadata, authenticationForm, _apiEndPoint, _hTTPMethods, _callBackOnSuccess, _callBackOnFailed);
    //    }
    //    public void OnFocusesCall(string _postURL, HTTPMethods _hTTPMethods, Action _callBacKOnSuccess, Action _callBacKOnfailed, Action<float> _callBackUploadingProgress)
    //    {
    //        GetFocusesData(authenticationForm, _postURL, _hTTPMethods, _callBacKOnSuccess, _callBacKOnfailed, _callBackUploadingProgress);
    //    }
    //    public void OnFocusesSelectionCall(string _postURL, FocusMetaData _focusMetaData, HTTPMethods _hTTPMethods, Action _callBacKOnSuccess, Action _callBacKOnfailed)
    //    {
    //        InformOnFocusesSelection(authenticationForm, _focusMetaData, _postURL, _hTTPMethods, _callBacKOnSuccess, _callBacKOnfailed);
    //    }
    //    public void OnFactsCall(string _postURL, HTTPMethods _hTTPMethods, Action _callBacKOnSuccess, Action _callBacKOnfailed, Action<float> _callBackUploadingProgress)
    //    {
    //        GetFacts(authenticationForm, _postURL, _hTTPMethods, _callBacKOnSuccess, _callBacKOnfailed, _callBackUploadingProgress);
    //    }
    //public void OnLogoutCall(Action _callBack)
    //{
    //    AuthenticationToken = string.Empty;
    //    playerProfileMetaData = new PlayerProfileMetaData();
    //    _callBack.Invoke();
    //}
    #endregion

    public bool IsInternetAvailable()
    {
        if (Application.internetReachability == NetworkReachability.NotReachable)
        {
            isInternetAvailable = false;
        }
        else
        {
            isInternetAvailable = true;
        }

        return isInternetAvailable;
    }
    public string AuthenticationToken
    {
        get { return PlayerPrefs.GetString("authToken"); }
        set { PlayerPrefs.SetString("authToken", value); }
    }
    public int IsSoundOn
    {
        get { return soundManager.IsSoundOn; }
        set { soundManager.IsSoundOn = value; }
    }
    public int IsMusicOn
    {
        get { return soundManager.IsMusicOn; }
        set { soundManager.IsMusicOn = value; }
    }
    public int IsViberationOn
    {
        get { return PlayerPrefs.GetInt("isViberationOn", 1); }
        set { PlayerPrefs.SetInt("isViberationOn", value); }
    }
    public void GiveAndSaveDailyReward()
    {
        //this.signupLoginMetadata = new SignupLoginMetadata();
        //signupLoginMetadata.authenticationToken = AuthToken;

        //if (GetRewadDay() == 1)
        //{
        //    signupLoginMetadata.totalCoins = (playerProfileMetaData.user_profile_data.totalCoins += 100).ToString();
        //    //SaveCoins(100);
        //}
        //else if (GetRewadDay() == 2)
        //{
        //    signupLoginMetadata.totalCoins = (playerProfileMetaData.user_profile_data.totalCoins += 150).ToString();
        //    signupLoginMetadata.totalDiamonds = (playerProfileMetaData.user_profile_data.totalDiamonds += 2).ToString();

        //    //SaveCoins(150);
        //    //SaveDiamonds(2);
        //}
        //else if (GetRewadDay() == 3)
        //{
        //    signupLoginMetadata.totalCoins = (playerProfileMetaData.user_profile_data.totalCoins += 200).ToString();
        //    signupLoginMetadata.totalDiamonds = (playerProfileMetaData.user_profile_data.totalDiamonds += 6).ToString();

        //    //SaveCoins(200);
        //    //SaveDiamonds(6);
        //}

        //PlayerPrefs.SetInt("rewardDay", PlayerPrefs.GetInt("rewardDay") + 1);
        //if (PlayerPrefs.GetInt("rewardDay", 1) > 3)
        //{
        //    PlayerPrefs.SetInt("rewardDay", 1);
        //}
        //PlayerPrefs.SetString("savedDateTime", DateTime.Today.AddDays(1).ToBinary().ToString());

        //Authentication(signupLoginMetadata, "/update-ludo-user", HTTPMethods.Post, CallbackResourcesUpdate);
    }
    public void DeductDiamonds(int amount)
    {
        //if (!isGuestUser)
        //{
        //    this.signupLoginMetadata = new SignupLoginMetadata();
        //    signupLoginMetadata.authenticationToken = AuthToken;

        //    signupLoginMetadata.totalDiamonds = (playerProfileMetaData.user_profile_data.totalDiamonds -= amount).ToString();
        //    Authentication(signupLoginMetadata, "/update-ludo-user", HTTPMethods.Post, CallbackResourcesUpdate);
        //}
        //else
        //{
        //    GuestUserTotalDiamonds -= amount;
        //}
    }
    public void AddDiamonds(int amount)
    {
        //if (!isGuestUser)
        //{
        //    this.signupLoginMetadata = new SignupLoginMetadata();
        //    signupLoginMetadata.authenticationToken = AuthToken;

        //    signupLoginMetadata.totalDiamonds = (playerProfileMetaData.user_profile_data.totalDiamonds += amount).ToString();
        //    Authentication(signupLoginMetadata, "/update-ludo-user", HTTPMethods.Post, OnProfileUpdated);
        //}
        //else
        //{
        //    GuestUserTotalDiamonds += amount;
        //    OnProfileUpdated?.Invoke();
        //}
    }
    public void AddCoins(int amount)
    {
        //if (!isGuestUser)
        //{
        //    this.signupLoginMetadata = new SignupLoginMetadata();
        //    signupLoginMetadata.authenticationToken = AuthToken;

        //    signupLoginMetadata.totalCoins = (playerProfileMetaData.user_profile_data.totalCoins += amount).ToString();
        //    Authentication(signupLoginMetadata, "/update-ludo-user", HTTPMethods.Post, OnProfileUpdated);
        //}
        //else
        //{
        //    GuestUserTotalCoins += amount;
        //    OnProfileUpdated?.Invoke();
        //}
    }
}
