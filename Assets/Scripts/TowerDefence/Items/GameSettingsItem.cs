using UnityEngine;

namespace TowerDefence
{
    [CreateAssetMenu(fileName = "Game Settings Item", menuName = "ScriptableObjects/GameSettingsItem", order = 4)]
    public class GameSettingsItem : ScriptableObject
    {
        public int Health;
        public int Coins;
    }
}
