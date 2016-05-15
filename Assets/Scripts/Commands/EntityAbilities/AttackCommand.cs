using UnityEngine;

namespace CFE
{
    /**
    *<summary>
    *Command to handle single target healing
    *</summary>
    */
    class AttackCommand : ICommand
    {
        EntityModel actor, target;

        /**
        *<summary>
        *Constructor for HealCommand objects
        *</summary>
        *<param name="actor"></param>
        *<param name="target"></param>
        */
        public AttackCommand(EntityModel actor, EntityModel target)
        {
            this.actor = actor;
            this.target = target;
        }

        public void Exectute()
        {
            Debug.Log(actor + " attacks " + target);
            //Debug.LogError("Execute not implemented for Attack Commands");
        }

        public void Undo()
        {
            Debug.LogError("Undo not implemented for Attack Commands");
        }
    }
}
