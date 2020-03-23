using UnityEngine;

namespace TowerDefence
{
    [RequireComponent(typeof(SpriteRenderer))]
    [RequireComponent(typeof(CircleCollider2D))]
    public class Tower : MonoBehaviour
    {
        public GameObject towerBase;
        public int Price { get; private set; }

        private float shootInterval;
        private int damage;

        private float currentTimeAfterShoot = 0;

        public void SetTower(TowerItem item)
        {
            GetComponent<SpriteRenderer>().sprite = item.sprite;
            GetComponent<CircleCollider2D>().radius = item.range;
            shootInterval = item.shootInterval;
            damage = item.damage;
            Price = item.price;
        }

        private void Update()
        {
            if (currentTimeAfterShoot < shootInterval)
                currentTimeAfterShoot += Time.deltaTime;
        }

        private void OnTriggerStay2D(Collider2D collision)
        {            
            if (currentTimeAfterShoot >= shootInterval)
            {
                if (collision.gameObject.GetComponent<Enemy>())
                {                    
                    collision.gameObject.GetComponent<Enemy>().TakeDamage(damage);
                    currentTimeAfterShoot = 0;
                }
            }
        }
    }
}