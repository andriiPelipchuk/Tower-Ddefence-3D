using System.Collections;
using UnityEngine;
namespace Assets.Scripts 
{
    public class Tower : MonoBehaviour
    {
        [SerializeField] int _range;
        [SerializeField] GameObject _projectileFrozen, _projectileBasic;
        [SerializeField] ProjectileType _projectileType;

        private float _timer, _coolDown;
        private Transform _target;
        [SerializeField] private int _towerLevel = 1;

        private void Update()
        {
            _timer += Time.deltaTime;
            FindTarget();
        }

        public int GetLevel()
        {
            return _towerLevel;
        }

        public void Upgrade()
        {
            //I increase the level of the tower. with what increases his damage
            _towerLevel++;
        }

        public void Shot()
        {
            //I create a projectile of the required type and pass data to it
            //use factory pattern
            switch (_projectileType) 
            {
                case ProjectileType.Frozen:
                    SetDataProjectile(InstantiateProjectile(_projectileFrozen), 15, 2, 1 * _towerLevel);
                    break;
                case ProjectileType.Basic:
                    SetDataProjectile(InstantiateProjectile(_projectileBasic), 40, 0.5f, 2 * _towerLevel);
                    break;

            }
        }
        private ProjectileData InstantiateProjectile(GameObject _projectile)
        {
            var projectile = Instantiate(_projectile, transform.GetChild(0).position, Quaternion.identity);
            var projectileData = projectile.GetComponent<ProjectileData>();
            return projectileData;
        }
        private void SetDataProjectile(ProjectileData projectileData, int speed, float range, int damage)
        {
            projectileData.SetDataProjectile(_target, speed, range, damage);
        }

        public void FindTarget()
        {
            var enemyes = Spawn.enemyes;
            var shortDistance = 25f;
            GameObject nearEnemy = null;

            foreach (var enemy in enemyes)
            {

                float distanceEnemy = Vector3.Distance(transform.position, enemy.transform.position);
                
                if (distanceEnemy < shortDistance)
                {
                    shortDistance = distanceEnemy;
                    nearEnemy = enemy;
                }
            }
            if (nearEnemy != null && shortDistance <= _range)
            {
                _target = nearEnemy.transform;

                if (_timer >= 0.5f)
                {
                    Shot();

                    _timer = _coolDown;
                }
            }
            else
                _target = null;
        }
        //visual display of the radius
        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, _range);
        }
    }
}
