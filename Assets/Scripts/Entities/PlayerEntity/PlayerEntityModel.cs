using System;
using UnityEngine;

namespace CFE
{
    /**
    *<summary>
    *Contains the simulation information for a Player Entity
    *</summary>
    */
    class PlayerEntityModel : EntityModel
    {
        public delegate void OnDeactivate();
        public delegate void OnActivate();

        public event OnDeactivate PlayerEntityDeactivateEvent;
        public event OnActivate PlayerEntityActivateEvent;

        /**
        *<summary>
        *Responds to ObjectModel.actice = false
        *</summary>
        */
        public override void Deactivate()
        {
            Debug.Log("Called Disable for " + this);
            if(PlayerEntityDeactivateEvent != null)
                PlayerEntityDeactivateEvent();
        }

        /**
        *<summary>
        *Responds to ObjectModel.actice = true
        *</summary>
        */
        public override void Activate()
        {
            Debug.Log("Called Enable for " + this);
            if (PlayerEntityActivateEvent != null)
                PlayerEntityActivateEvent();
        }
    }
}
