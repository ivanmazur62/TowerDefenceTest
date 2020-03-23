using UnityEngine;

namespace TowerDefence
{
    public class TowerBase : MonoBehaviour
    {
        public Tower tower;

        public void BuyTower(TowerItem towerItem)
        {
            if (GameManager.Instance.Buy(towerItem.price))
            {
                tower.SetTower(towerItem);
                tower.gameObject.SetActive(true);
            }
        }

        public void SellTower()
        {
            GameManager.Instance.AddCoins(tower.Price);
            tower.gameObject.SetActive(false);
        }

        public void CleanTower()
        {
            tower.gameObject.SetActive(false);
        }

        private void OnMouseUp()
        {                 
            UIManager.Instance.towerBuildMenu.EnableMenu(this);                
        }
    }
}