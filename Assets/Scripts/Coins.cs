using System.Collections;
using TMPro;
using UnityEngine;

namespace Assets.Scripts
{
    public class Coins : MonoBehaviour
    {

        [SerializeField] private TextMeshProUGUI _textCoinsPopUp;

        private int coins;

        public void AddCoin(int coin)
        {
            coins += coin;
            UpdateCoinsPopUp();
        }

        public void TakeCoin(int coin)
        {
            coins -= coin;
            UpdateCoinsPopUp();
        }

        public int BalanceOfCoins()
        {
            return coins;
        }

        private void UpdateCoinsPopUp()
        {
            _textCoinsPopUp.text = coins.ToString();
        }
    }
}