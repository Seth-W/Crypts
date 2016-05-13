using System;
using UnityEngine;

namespace CFE
{
    class EndTurnButtonView : ButtonView
    {
        public override void OnDeactivate()
        {
            base.OnDeactivate();
            rend.material.color = Color.yellow;
        }

        public override void OnActivate()
        {
            base.OnActivate();
            rend.material.color = Color.green;
        }
    }
}
