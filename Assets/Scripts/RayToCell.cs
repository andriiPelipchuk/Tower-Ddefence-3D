using System.Collections;
using UnityEngine;

namespace Assets.Scripts
{
    public class RayToCell : MonoBehaviour
    {
        private bool _cellSelect;
        private Cell _recorderCell;
        private void Update()
        {
            SelectCell();
        }
        public void SetBoolFalse()
        {
            _cellSelect = false;
        }

        public void RestartCell()
        {
            _recorderCell.gunPlace = true;
        }

        private void SelectCell()
        {
            if (!_cellSelect)//block the ray when cell is selected
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                Physics.Raycast(ray, out RaycastHit hit);
                if (hit.collider != null)
                {
                    if (Input.GetMouseButtonDown(0))
                    {
                        var gameManager = gameObject.GetComponent<GameManager>();

                        if (hit.collider.gameObject.GetComponent<Cell>())
                        {
                            var cell = hit.collider.gameObject.GetComponent<Cell>(); 
                            _recorderCell = cell;

                            if (cell.gunPlace)
                            {
                                _cellSelect = true;

                                cell.DeactiveMarking();

                                gameManager.OpenPopUpTower(true);
                                gameManager.SetPostionTower(hit.collider.transform.position);
                            }
                        }

                        if (hit.collider.gameObject.GetComponent<Tower>())
                        {
                            var tower = hit.collider.gameObject.GetComponent<Tower>();                            
                            gameManager.UpgradePopup(tower.GetLevel(), tower);

                        }

                        
                    }
                }
            }
        }
    }
}