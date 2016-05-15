using UnityEngine;

namespace CFE
{
    /**
    *<summary>
    *Command to handle single target attacks
    *</summary>
    */
    class HealCommand : ICommand
    {
        EntityModel actor, target;

        /**
        *<summary>
        *Constructor for AttackCommand objects
        *</summary>
        *<param name="actor"></param>
        *<param name="target"></param>
        */
        public HealCommand(EntityModel actor, EntityModel target)
        {
            this.actor = actor;
            this.target = target;
        }

        public void Exectute()
        {
            Debug.Log(actor + " Healed " + target);
            Debug.LogWarning("Execute not implemented for Attack Commands");
        }

        public void Undo()
        {
            Debug.LogWarning("Undo not implemented for Attack Commands");
        }
    }
}
