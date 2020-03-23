using TMPro;
using UnityEngine;

namespace TowerDefence
{
    public class UIMainState : MonoBehaviour
    {
        public TextMeshProUGUI health;
        public TextMeshProUGUI waves;
        public TextMeshProUGUI coins;

        public void UpdateHealth()
        {
            health.text = GameManager.Instance.castle.Health.ToString();            
        }

        public void UpdateWaves()
        {
            waves.text = (GameManager.Instance.enemySpawner.CurrentWave + 1) + "/" + GameManager.Instance.enemySpawner.enemyWawes.Count;
        }

        public void UpdateCoins()
        {
            coins.text = GameManager.Instance.Coins.ToString();
        }

        public void Initialization()
        {
            UpdateHealth();
            UpdateWaves();
            UpdateCoins();
        }
    }
}
