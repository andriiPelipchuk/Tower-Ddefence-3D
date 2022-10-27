using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts 
{
    public class MoveEnemy : MonoBehaviour
    {
        public static Action takeLife;
        private float _speed = 2;
        private Transform _target;
        private int _index = 0;
        private bool _slowEnemy = false;

        private void Start()
        {
            _target = Waypoints.positions[_index];
        }
        private void FixedUpdate()
        {
            Move();
        }

        public void SpeedDown(int damage)
        {
            if (!_slowEnemy)
            {
                _slowEnemy = true;
                _speed /= damage;
                StartCoroutine(SpeedRecoveryTime());
                StopCoroutine(SpeedRecoveryTime());
            }
        }

        private void Move()
        {
            if (_index == Waypoints.positions.Length - 1)
            {
                for (int i = 0; i < Spawn.enemyes.Count; i++)
                {
                    if (Spawn.enemyes[i] == gameObject)
                    {
                        Spawn.enemyes.RemoveAt(i);
                        takeLife?.Invoke();
                        Destroy(gameObject);
                    }
                }
            }

            if(Vector3.Distance(transform.position, _target.position) <= 0.1f)//cures a bug: the enemy does not move to the next point
            {
                _index++;
                _target = Waypoints.positions[_index];
            }
            var direction = _target.position - transform.position;
            direction = direction.normalized;
            transform.position = transform.position + direction * _speed * Time.fixedDeltaTime;
        }

        IEnumerator SpeedRecoveryTime()
        {
            yield return new WaitForSeconds(3);
            _speed *= 2;
            _slowEnemy = false;
        }
    }
}
