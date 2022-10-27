using UnityEngine;
using System.Collections.Generic;
namespace Assets.Scripts
{
    public interface IProjectile 
    {
        /*the sheet is necessary to transmit information to the projectile about the number of targets hit
         * use factory pattern
         */
        void TypeDamage(List<GameObject> enemyes, int damage);
        
    }
}