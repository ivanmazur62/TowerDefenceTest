using System.Collections.Generic;
using UnityEngine;

namespace TowerDefence
{
    [CreateAssetMenu(fileName = "Enemy Wave", menuName = "ScriptableObjects/EnemyWave", order = 3)]
    public class EnemyWaveItem : ScriptableObject
    {
        public int duration;
        public List<EnemyItem> enemiesTypes;
        public int enemiesCount;

        public float GetSpawnInterwal()
        {
            return (float)duration / enemiesCount;
        }

        public EnemyItem GetRandomEnemy()
        {
            return enemiesTypes[Random.Range(0, enemiesTypes.Count)];
        }

    }
}
