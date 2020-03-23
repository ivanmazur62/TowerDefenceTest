using UnityEngine;

namespace TowerDefence
{
    [CreateAssetMenu(fileName = "Enemy Item", menuName = "ScriptableObjects/EnemyItem", order = 2)]
    public class EnemyItem : ScriptableObject
    {
        public Sprite sprite;
        public int health;
        public float movingSpeed;        
        public int damage;
        public int minCoins;
        public int maxCoins;
    }
}
