using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using YG;

public class DragonPicker : MonoBehaviour
{
    public GameObject energyShieldPrefab;
    public int countEnergyShield = 3;
    public float energyShieldBottomY = -6f;
    public float energyShieldRadious = 1f;
    public TextMeshProUGUI UserName;

    private TextMeshProUGUI Score;
    private int scoreCount = 0;
    private List<EnergyShield> shieldList;

    private void OnEnable() => YandexGame.GetDataEvent += GetLoadSave;
    private void OnDisable() => YandexGame.GetDataEvent -= GetLoadSave;

    void Start()
    {
        if (YandexGame.SDKEnabled)
        {
            GetLoadSave();
        }

        Score = GameObject.FindGameObjectWithTag("Score").GetComponent<TextMeshProUGUI>();
        shieldList = new List<EnergyShield>();
        ShieldListFill();
    }

    private void ShieldListFill()
    {
        for (int i = 0; i < countEnergyShield; i++)
        {
            var tShieldGo = Instantiate(energyShieldPrefab, new Vector3(0, energyShieldBottomY, 0), Quaternion.identity);
            var scale = (i + 1f) * energyShieldRadious;
            tShieldGo.transform.localScale = new Vector3(scale, scale, scale);
            var shield = tShieldGo.GetComponent<EnergyShield>();
            shield.Collider = shield.GetComponent<Collider>();
            shield.Collider.enabled = false;
            shield.OnCollidedEgg += () =>
            {
                scoreCount++;
                Score.text = $"Score: {scoreCount}";
            };
            shieldList.Add(shield);
        }
        shieldList[shieldList.Count - 1].Collider.enabled = true;
    }

    public void DragonEggDestroyedWithoutOne(GameObject oneEgg)
    {
        var eggs = GameObject.FindGameObjectsWithTag("Dragon Egg");
        for(int i = 0; i < eggs.Length; i++)
        {
            if (eggs[i] == oneEgg) continue;
            Destroy(eggs[i]);
        }

        if (shieldList.Count > 0)
        {
            var shield = shieldList[shieldList.Count - 1];
            Destroy(shield.gameObject);
            shieldList.RemoveAt(shieldList.Count - 1);
            if (shieldList.Count > 0)
                shieldList[shieldList.Count - 1].Collider.enabled = true;
            else
            {
                LinkedList<string> achivs = new LinkedList<string>(YandexGame.savesData.achievments);
                achivs.AddFirst("Береги щиты!");
                YandexGame.savesData.achievments = achivs.ToArray();
                UserSave();
                SceneManager.LoadScene(0);
            }
        }
    }

    public void GetLoadSave()
    {
        UserName.text = YandexGame.playerName;
        Debug.Log("PlayerName: " + YandexGame.playerName);
        Debug.Log(YandexGame.savesData.bestScore);
    }

    public void UserSave()
    {
        if (YandexGame.savesData.bestScore < scoreCount)
        {
            YandexGame.savesData.bestScore = scoreCount;
            YandexGame.NewLeaderboardScores("TOPPlayerScore", scoreCount);
        }
        YandexGame.SaveProgress();
    }
}
