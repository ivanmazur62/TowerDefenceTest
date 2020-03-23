using System.Collections.Generic;
using UnityEngine;

namespace TowerDefence
{
    [RequireComponent(typeof(SpriteRenderer))]
    [RequireComponent(typeof(CircleCollider2D))]
    public class Enemy : MonoBehaviour
    {        
        private int health;
        private float movingSpeed;
        private int coins;
        private int damage;
        private List<Vector2> path;

        private Vector2 startPosition;
        private Vector2 nextPosition;
        private int currentPathPoint = 0;
        private float movingProgress;
        private float currentStep;
        bool stopWalk = false;

        public void Initialisation(List<Vector2> path)
        {
            startPosition = gameObject.transform.position;
            this.path = path;
            nextPosition = path[0];
        }

        public void SetEnemy(EnemyItem item)
        {
            GetComponent<SpriteRenderer>().sprite = item.sprite;
            health = item.health;
            movingSpeed = item.movingSpeed;
            damage = item.damage;
            coins = Random.Range(item.minCoins, item.maxCoins + 1);
        }

        public void TakeDamage(int damage)
        {
            health -= damage;

            if (health <= 0)
                Die();
        }

        private void FixedUpdate()
        {
            if(!stopWalk)
                Walk();
        }

        private void Walk()
        {
            if (movingProgress >= 1)
            {
                movingProgress = 0;

                startPosition = nextPosition;
                currentPathPoint = currentPathPoint + 1 >= path.Count ? path.Count - 1 : currentPathPoint + 1;                                
                nextPosition = path[currentPathPoint];                
                
                currentStep = movingSpeed / Vector2.Distance(startPosition, nextPosition);

                if (startPosition == nextPosition)
                    stopWalk = true;
            }
            movingProgress += movingSpeed;
            gameObject.GetComponent<Rigidbody2D>().MovePosition(Vector2.Lerp(startPosition, nextPosition, movingProgress));

        }

        private void Die()
        {
            GameManager.Instance.AddCoins(coins);
            Destroy(gameObject);
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.GetComponent<Castle>())
            {
                collision.gameObject.GetComponent<Castle>().TakeDamage(damage);
                Destroy(gameObject);
            }
        }
    }
}