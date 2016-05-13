using System;
using UnityEngine;

namespace CFE
{

    /**
    *<summary>
    *Contains the simulation information for a gameEntity representing the floor
    *</summary>
    */
    class FloorEntityModel : ObjectModel
    {
        public delegate void OnDeactivate();
        public delegate void OnActivate();
        public event OnDeactivate FloorEntityActivateEvent;
        public event OnActivate FloorEntityDeactivateEvent;

        //Base FloorEntityModel does not Enable or Disable
        public override void Deactivate()
        {
            //Debug.Log("Called Deactivate for " + this);
            FloorEntityActivateEvent();
        }

        //Base FloorEntityModel does not Enable or Disable
        public override void Activate()
        {
            //Debug.Log("Called Enable for " + this);
            FloorEntityDeactivateEvent();
        }
    }
}
