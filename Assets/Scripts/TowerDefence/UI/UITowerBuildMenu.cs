using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace TowerDefence
{
    public enum TowerBuildType { None, Build, Sell }

    public class UITowerBuildMenu : MonoBehaviour
    {
        public TowerBase currentTowerBase;

        public List<Button> towersBtn;
        public Button sellBtn;

        public void EnableMenu(TowerBase towerBase)
        {            
            if (towerBase.tower.gameObject.activeInHierarchy)
                SetActiveMenu(TowerBuildType.Sell);
            else
                SetActiveMenu(TowerBuildType.Build);

            currentTowerBase = towerBase;
            gameObject.transform.position = towerBase.transform.position;
            gameObject.SetActive(true);
        }

        public void BuildTower(TowerItem towerItem)
        {
            currentTowerBase.BuyTower(towerItem);
            gameObject.SetActive(false);
        }

        public void SellTower()
        {
            currentTowerBase.SellTower();
            gameObject.SetActive(false);
        }

        public void SetActiveMenu(TowerBuildType type)
        {            
            foreach (Button item in towersBtn)
                item.gameObject.SetActive(type == TowerBuildType.Build);

            sellBtn.gameObject.SetActive(type == TowerBuildType.Sell);
        }
        public void HideMenu()
        {
            SetActiveMenu(TowerBuildType.None);
        }
    }
}