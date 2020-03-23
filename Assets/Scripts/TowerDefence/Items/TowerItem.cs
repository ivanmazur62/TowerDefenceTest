using UnityEngine;

namespace TowerDefence
{
    [CreateAssetMenu(fileName = "Tower Item", menuName = "ScriptableObjects/TowerItem", order = 1)]
    public class TowerItem : ScriptableObject
    {
        public Sprite sprite;
        public int price;
        public float range;
        public float shootInterval;
        public int damage;
    }
}