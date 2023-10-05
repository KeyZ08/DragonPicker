using UnityEngine;
using YG;

public class CheckConnectYG : MonoBehaviour
{
    private void OnEnable() => YandexGame.GetDataEvent += CheckSDK;
    private void OnDisable() => YandexGame.GetDataEvent -= CheckSDK;

    void Start()
    {
        if (YandexGame.SDKEnabled)
        {
            CheckSDK();
        }
    }

    private void CheckSDK()
    {
        if (YandexGame.auth)
        {
            Debug.Log("User auth OK");
        }
        else
        {
            Debug.Log("User auth ERROR");
            YandexGame.AuthDialog();
        }
    }
}
