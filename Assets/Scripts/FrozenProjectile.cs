using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    public class FrozenProjectile : MonoBehaviour,IProjectile
    {
        private ParticleSystem _particleSystem;

        private void Awake()
        {
            _particleSystem.Stop();
        }
        public void TypeDamage(List<GameObject> enemyes, int damage)
        {
            for (int i = 0; i < enemyes.Count; i++)
            {
                var enemy = enemyes[i].GetComponent<MoveEnemy>();
                enemy.SpeedDown(damage);
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            _particleSystem.Play();
        }
    }
}