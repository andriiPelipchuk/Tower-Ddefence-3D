using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    public class BasicProjectile : MonoBehaviour, IProjectile
    {
        public void TypeDamage(List<GameObject> enemyes, int damage)
        {
            for (int i = 0; i < enemyes.Count; i++)
            {
                var enemy = enemyes[i].GetComponent<HealthEnemy>();
                enemy.TakeDamage(damage);
            }
        }
    }
}