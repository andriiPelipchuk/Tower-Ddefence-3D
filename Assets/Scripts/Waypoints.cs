using System.Collections;
using UnityEngine;

namespace Assets.Scripts
{
    public class Waypoints : MonoBehaviour
    {

        public static Transform[] positions;

        private void Awake()
        {
            //write waypoints to static array 
            positions = new Transform[transform.childCount];
            for (int i = 0; i < positions.Length; i++)
            {
                positions[i] = transform.GetChild(i);
            }
        }
    }
}