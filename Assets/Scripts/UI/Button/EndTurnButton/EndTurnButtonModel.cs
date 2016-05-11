using System;
using UnityEngine;

namespace CFE
{
    class EndTurnButtonModel : ObjectModel
    {
        public override void Start()
        {
            base.Start();
            Disable();
        }

        public override void Enable()
        {
            base.Enable();
        }
        public override void Disable()
        {
            base.Disable();
        }
    }
}
