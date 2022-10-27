using UnityEngine;

namespace Assets.Scripts
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private GameObject _popUpTowers, _popUpUpgradeTower, _PopUpHP;
        [SerializeField] private Coins _coins;
        [SerializeField] private HealthBar _hp;

        public Spawn spawn;

        private Tower _tower;
        private int _numberEnemyes = 4, _levelTower;
        private Vector3 position;


        private void Awake()
        {
            HealthEnemy.enemyDeath += ActionCoin;
            MoveEnemy.takeLife += GameOverPopUp;
            for (int i = 0; i < Spawn.enemyes.Count; i++)
            {
                Spawn.enemyes.RemoveAt(i);
            }
        }

        private void Update()
        {
            if(Spawn.enemyes.Count == 0)
            {
                spawn.SpawnWaveEnemys(_numberEnemyes);
                _numberEnemyes *= 2;
            }
        }

        public void GameOverPopUp()
        {
            _hp.TakeHP();
            if (_hp.GetHealth() == 0)
            {
                
                _PopUpHP.SetActive(true);
                Time.timeScale = 0;
            }

        }

        public void SetPostionTower(Vector3 position)
        {
            this.position = position;
        }

        public void UpgradePopup(int level, Tower tower)
        {
            _popUpUpgradeTower.SetActive(true);
            _levelTower = level;
            _tower = tower;
        }

        public void UpgradeTower()
        {
            if(_coins.BalanceOfCoins() >= 50 * _levelTower)
            {
                _popUpUpgradeTower.SetActive(false);
                _coins.TakeCoin(50 * _levelTower);
                _tower.Upgrade();
            }
            else
            {

                _popUpUpgradeTower.SetActive(false);
                spawn.NegativeBalancePopUp();
            }
        }

        public void OpenPopUpTower(bool activePopUp)
        {
            _popUpTowers.SetActive(activePopUp);
        }
        public void ClosePopUpTower(bool restartCell)
        {
            _popUpTowers.SetActive(false);
            ActivateRay();
            if (restartCell)
            {

                var rayCell = gameObject.GetComponent<RayToCell>();
                rayCell.RestartCell();
            }
        }
        public void FrozenTower()
        {
            var takeAway = spawn.Tower(position, false, _coins.BalanceOfCoins());
            if (takeAway)
            {
                _coins.TakeCoin(1);
                ClosePopUpTower(false);
            }
            else
                ClosePopUpTower(true);

        }
        public void BasicTower()
        {
            var takeAway = spawn.Tower(position, true, _coins.BalanceOfCoins());
            if (takeAway)
            {
                _coins.TakeCoin(2);
                ClosePopUpTower(false);
            }
            else
                ClosePopUpTower(true);
        }

        private void ActivateRay()
        {
            var rayCell = gameObject.GetComponent<RayToCell>();
            rayCell.SetBoolFalse();
        }

        private void ActionCoin()
        {
            _coins.AddCoin(1);
        }

    }
}