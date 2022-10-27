using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts 
{
    public class Spawn : MonoBehaviour
    {

        [SerializeField] private GameObject _enemyPrefab, _negativeBalancePopUp;
        [SerializeField] private GameObject _frozenTowerPrefab, _basicTowerPrefab;
        

        public static List<GameObject> enemyes = new List<GameObject>();

        private int _health = 1, _numberEnemyes;



        public void SpawnWaveEnemys(int numberEnemyes)
        {
            _health++;
            _numberEnemyes = numberEnemyes; 
            StartCoroutine(IntervalEnemySpawn());
            StopCoroutine(IntervalEnemySpawn());
        }

        public bool Tower(Vector3 positionToSpawn, bool basicTower, int price)
        {
            if (basicTower && price >= 2)
            {
                SelectTower(positionToSpawn, _basicTowerPrefab);
                return true;
            }
            else if(!basicTower && price >= 1)
            {
                SelectTower(positionToSpawn, _frozenTowerPrefab);
                return true;
            }
            else
            {
                NegativeBalancePopUp();
                return false;
            }
        }

        public void NegativeBalancePopUp()
        {
            StartCoroutine(AnimPopUp());
            StopCoroutine(AnimPopUp());
        }

        private void SelectTower(Vector3 positionToSpawn, GameObject tower)
        {
            var x = positionToSpawn.x;
            var z = positionToSpawn.z;
            Instantiate(tower, new Vector3(x, 0, z), Quaternion.identity);
        }

        IEnumerator IntervalEnemySpawn( )
        {
            for (int i = 0; i < _numberEnemyes; i++)
            {
                var enemy = Instantiate(_enemyPrefab, gameObject.transform.position, Quaternion.identity);
                var heathEnemy = enemy.GetComponent<HealthEnemy>();
                heathEnemy.SetHeath(_health);
                enemyes.Add(enemy);
                yield return new WaitForSeconds(0.5f);
            }
        }

        IEnumerator AnimPopUp()
        {
            _negativeBalancePopUp.SetActive(true);
            yield return new WaitForSeconds(2);
            _negativeBalancePopUp.SetActive(false);
        }
    }
}

