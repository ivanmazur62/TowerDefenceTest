using System.Collections.Generic;
using UnityEngine;

namespace TowerDefence
{    
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance;
        public GameSettingsItem gameSettingsItem;

        public int Coins { get; private set; }
        public Castle castle;
        public EnemySpawner enemySpawner;
        public List<TowerBase> towers;


        private void Start()
        {
            if (Instance == null)
                Instance = this;
            else if (Instance == this)
                Destroy(gameObject);

            DontDestroyOnLoad(gameObject);
        }

        public void StopGame()
        {
            Time.timeScale = 0;
        }

        public void ResumeGame()
        {
            Time.timeScale = 1;
        }

        public void Initialization()
        {
            Coins = gameSettingsItem.Coins;
            castle.Initialisation(gameSettingsItem.Health);
            enemySpawner.Initialisation();

            foreach (TowerBase item in towers)
                item.CleanTower();
        }

        public void AddCoins(int value)
        {
            Coins += value;
            UIManager.Instance.uIMainState.UpdateCoins();
        }

        public bool Buy(int value)
        {
            if (Coins < value)
            {
                print("Not enough money");
                return false;
            }
            else
            {
                Coins -= value;
                UIManager.Instance.uIMainState.UpdateCoins();
                return true;
            }
        }
    }
}