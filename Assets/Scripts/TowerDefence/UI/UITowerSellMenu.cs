using UnityEngine;

namespace TowerDefence
{
    public class UITowerSellMenu : MonoBehaviour
    {
        public TowerBase currentTowerBase;

        public void EnableMenu(TowerBase towerBase)
        {            
            currentTowerBase = towerBase;
            gameObject.transform.position = towerBase.transform.position;
            gameObject.SetActive(true);
        }

        public void SellTower()
        {
            currentTowerBase.SellTower();
            gameObject.SetActive(false);
        }
    }
}
