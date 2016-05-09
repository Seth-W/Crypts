using System;
using UnityEngine;

namespace CFE
{
    [RequireComponent(typeof(EndTurnButtonControl))]
    [RequireComponent(typeof(EndTurnButtonView))]
    class EndTurnButtonModel : ButtonModel
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
