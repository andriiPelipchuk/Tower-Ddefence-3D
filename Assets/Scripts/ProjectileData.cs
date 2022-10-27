using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    public class ProjectileData : MonoBehaviour
    {


        private Vector3 _direction;
        private int _speed, _damage;
        private float _range;


        private void Update()
        {
            transform.position = transform.position + _direction * _speed * Time.deltaTime;
        }
        public void SetDataProjectile(Transform target, int speed, float range, int damage)
        {
            _damage = damage;
            _speed = speed;
            _range = range;
            _direction = target.position - transform.position;
            _direction = _direction.normalized;
        }
        private void OnTriggerEnter(Collider other)
        {

            FindEnemy();
            
            Destroy(gameObject);
        }

        private void FindEnemy()
        {
            //after a collision, looks for opponents in a radius
            var typeDamage = gameObject.GetComponent<IProjectile>();
            List<GameObject> enemyArray = new List<GameObject>();
            var enemyesSpawn = Spawn.enemyes;
            var shortDistance = _range;
            foreach (var enemy in enemyesSpawn)
            {
                float distanceRange = Vector3.Distance(transform.position, enemy.transform.position);
                if (distanceRange < shortDistance)
                {
                    enemyArray.Add(enemy);
                }
            }
            if (enemyArray == null)
                return;
            else
                typeDamage.TypeDamage(enemyArray, _damage);

        }
    }
}