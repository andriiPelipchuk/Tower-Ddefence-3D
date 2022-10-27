using System.Collections;
using UnityEngine;
using TMPro;

namespace Assets.Scripts
{
    public class HealthBar : MonoBehaviour
    {
        public TextMeshProUGUI _textHP;
        private int _health = 3;
        public int GetHealth()
        {
            return _health;
        }

        public void TakeHP()
        {
            _health--;
            _textHP.text = _health.ToString();
        }
    }
}