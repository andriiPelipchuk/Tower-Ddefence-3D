using System.Collections;
using UnityEngine;
using System;

namespace Assets.Scripts
{
    public class HealthEnemy : MonoBehaviour
    {
        public static Action enemyDeath;
        public int _health;

        public void SetHeath(int health )
        {
            _health = health;
        }
        public void TakeDamage(int damage)
        {
            _health -= damage;
            if (_health <= 0)
            {
                for (int i = 0; i < Spawn.enemyes.Count; i++)
                {
                    if(Spawn.enemyes[i] == gameObject)
                    {
                        Spawn.enemyes.RemoveAt(i);
                        enemyDeath?.Invoke();
                        Destroy(gameObject);
                    }
                }
            }
        }
    }
}