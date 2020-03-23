using System.Collections.Generic;
using UnityEngine;

namespace TowerDefence
{
    public class EnemySpawner : MonoBehaviour
    {
        public List<EnemyWaveItem> enemyWawes;
        public Enemy enemy;
        public int CurrentWave { get; private set; }
        public Transform spawnPosition;
        public LineRenderer lineRendererPath;
        public Transform EnemiesParent;

        private List<Vector2> path;
        private float currentTime = 0;
        private float currentTimeWave = 0;
        private bool wavesCompleted = true;

        public void Initialisation()
        {
            GetPath();
            wavesCompleted = false;
            CurrentWave = 0;
            CleanAllEnemies();
        }

        private void CleanAllEnemies()
        {
            for (int i = EnemiesParent.childCount - 1; i >= 0; i--)
            {
                Destroy(EnemiesParent.GetChild(i).gameObject);
            }
        }

        private void FixedUpdate()
        {
            if (!wavesCompleted)
            {
                currentTime += Time.deltaTime;
                currentTimeWave += Time.deltaTime;

                if (currentTimeWave >= enemyWawes[CurrentWave].GetSpawnInterwal())
                {
                    currentTimeWave = 0;
                    SpawnEnemy(enemyWawes[CurrentWave]);
                }

                if (currentTime >= enemyWawes[CurrentWave].duration)
                {
                    currentTime = 0;
                    CurrentWave++;

                    if (CurrentWave >= enemyWawes.Count)
                    {
                        CurrentWave = 0;
                        wavesCompleted = true;
                    }
                    else
                        UIManager.Instance.uIMainState.UpdateWaves();
                }
            }
            
        }

        public void SpawnEnemy(EnemyWaveItem enemyWaveItem)
        {
            GameObject tempEnemy = Instantiate(enemy.gameObject, spawnPosition.position, Quaternion.identity, EnemiesParent);
            tempEnemy.GetComponent<Enemy>().SetEnemy(enemyWaveItem.GetRandomEnemy());
            tempEnemy.GetComponent<Enemy>().Initialisation(path);
        }

        //Get Path from LineRenderer
        private void GetPath()
        {
            Vector3[] tempV3Path = new Vector3[lineRendererPath.positionCount];
            lineRendererPath.GetPositions(tempV3Path);
            path = new List<Vector2>();

            foreach (Vector3 item in tempV3Path)
                path.Add(item);
        }
        
    }
}
