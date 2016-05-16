using UnityEngine;

namespace CFE
{
    /**
    *<summary>
    *A NULL Command to create when you want to do nothing
    *</summary>
    */
    class NullCommand : ICommand
    {
        EntityModel actor, target;

        /**
        *<summary>
        *Constructor for NullCommand objects
        *</summary>
        *<param name="actor">The entity making taking action</param>
        *<param name="target">The entity receiving the action</param>
        */
        public NullCommand(EntityModel actor, EntityModel target)
        {
            this.actor = null;
            this.target = null;
        }

        public void Exectute()
        {
            Debug.LogWarning("Called a NULL Command");
        }

        public void Undo()
        {
            Debug.LogError("Undo not implemented for Null Commands");
        }
    }
}
