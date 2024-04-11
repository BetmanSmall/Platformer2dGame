using TMPro;
using UnityEngine;

public class PlayerStatsCanvas : MonoBehaviour {
    [SerializeField] private TMP_Text coinsTMP;
    [SerializeField] private TMP_Text enemyTMP;

    public static PlayerStatsCanvas Instance;
    private int coinsCount, enemyCount;

    private void Start() {
        Instance = this;
    }

    public void AddCoinStat(int value) {
        coinsCount+=value;
        coinsTMP.text = coinsCount.ToString();
    }

    public void AddEnemyStat(int value) {
        enemyCount+=value;
        enemyTMP.text = enemyCount.ToString();
    }
}