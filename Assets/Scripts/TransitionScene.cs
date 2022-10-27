using UnityEngine.SceneManagement;
using UnityEngine;

namespace Assets.Scripts 
{
    public class TransitionScene : MonoBehaviour
    {
        //transition between menu and game
        public void PlayGame()
        {
            SceneManager.LoadScene(1);
            Time.timeScale = 1;
        }
    }
}
