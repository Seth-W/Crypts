using System;
using UnityEngine;

namespace CFE
{
    /**
    *<summary>
    *Contains the simulation information for a Player Entity
    *</summary>
    */
    class PlayerEntityModel : ObjectModel
    {
        public delegate void OnDeactivate();
        public delegate void OnActivate();

        public event OnDeactivate PlayerEntityDeactivateEvent;
        public event OnActivate PlayerEntityActivateEvent;


        //Base FloorEntityModel does not Enable or Disable
        public override void Deactivate()
        {
            Debug.Log("Called Disable for " + this);
            PlayerEntityDeactivateEvent();
        }

        //Base FloorEntityModel does not Enable or Disable
        public override void Activate()
        {
            Debug.Log("Called Enable for " + this);
            PlayerEntityActivateEvent();
        }
    }
}
