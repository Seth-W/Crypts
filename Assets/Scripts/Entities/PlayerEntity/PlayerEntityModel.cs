using System;
using UnityEngine;

namespace CFE
{ 
    [RequireComponent(typeof (PlayerEntityView))]
    [RequireComponent(typeof(PlayerEntityControl))]
    class PlayerEntityModel : EntityModel
    {
        public override void Disable()
        {
            throw new NotImplementedException();
        }

        public override void Enable()
        {
            throw new NotImplementedException();
        }
    }
}
