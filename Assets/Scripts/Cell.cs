using System.Collections;
using UnityEngine;

namespace Assets.Scripts
{
    public class Cell : MonoBehaviour
    {
        private Animation _anim;
        public bool gunPlace;


        private void Start()
        {
            _anim = GetComponent<Animation>();
            
        }

        private void Update()
        {
            ActivateMarking();
        }

        // activate flicker cell to recognize active cells
        private void ActivateMarking()
        {
            if (gunPlace)
            {
                _anim.Play("cell_anim");

            }
        }

        public void DeactiveMarking()
        {
            gunPlace = false;
            _anim.Stop("cell_anim");
            transform.localScale = new Vector3(1, 1, 1);
        }

    }
}