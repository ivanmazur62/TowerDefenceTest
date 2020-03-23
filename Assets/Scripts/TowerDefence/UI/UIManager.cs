using UnityEngine;

namespace TowerDefence
{
    public class UIManager : MonoBehaviour
    {
        public static UIManager Instance;

        public UITowerBuildMenu towerBuildMenu;
        public UIMainState uIMainState;
        public UIMainMenu mainMenu;
        
        void Start()
        {            
            if (Instance == null)            
                Instance = this;            
            else if (Instance == this)            
                Destroy(gameObject);           

            DontDestroyOnLoad(gameObject);

            Initialization();
        }

        private void Initialization()
        {
            towerBuildMenu.SetActiveMenu(TowerBuildType.None);
            uIMainState.Initialization();
            mainMenu.gameObject.SetActive(true);
        }

        public void StartGame()
        {
            GameManager.Instance.Initialization();
            Initialization();
            mainMenu.gameObject.SetActive(false);
            mainMenu.ResumeBtn.gameObject.SetActive(false);
            GameManager.Instance.ResumeGame();
        }

        public void GameOver()
        {
            Initialization();
            GameManager.Instance.StopGame();
            mainMenu.ResumeBtn.gameObject.SetActive(false);
        }

        public void PausedGame()
        {
            mainMenu.gameObject.SetActive(true);
            mainMenu.ResumeBtn.gameObject.SetActive(true);
            GameManager.Instance.StopGame();
        }
        public void ContinuedGame()
        {
            mainMenu.gameObject.SetActive(false);
            GameManager.Instance.ResumeGame();
        }
    }
}
