using UnityEngine;
using YG;

public class ADReward  : MonoBehaviour
{
    private void OnEnable()
    {
        YandexGame.RewardVideoEvent += Rewarded;
        YandexGame.ErrorVideoEvent += VideoError;
    }

    private void OnDisable()
    {
        YandexGame.RewardVideoEvent -= Rewarded;
        YandexGame.ErrorVideoEvent -= VideoError;
    }

    private void Rewarded(int id)
    {
        if(id == 1)
        {
            Debug.Log("�������������� �� �������� ����� �������");
        }
        else
        {
            Debug.Log("��� �������������� �� �������� ����� �������");
        }
    }

    public void OpenAD()
    {
        YandexGame.RewVideoShow(UnityEngine.Random.Range(0,2));
    }

    public void VideoError()
    {
        Debug.Log("������ �������� �����, �������� AdBlock");
    }
}
