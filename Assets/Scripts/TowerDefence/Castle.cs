using UnityEngine;

namespace TowerDefence
{
    [RequireComponent(typeof(CircleCollider2D))]
    public class Castle : MonoBehaviour
    {
        public int Health { get; private set; }

        public void Initialisation(int health)
        {
            Health = health;
        }

        public void TakeDamage(int damage)
        {
            Health -= damage;

            if (Health <= 0)
            {
                Health = 0;
                GameOver();
            }
            UIManager.Instance.uIMainState.UpdateHealth();
        }

        public void GameOver()
        {
            UIManager.Instance.GameOver();
        }
    }
}