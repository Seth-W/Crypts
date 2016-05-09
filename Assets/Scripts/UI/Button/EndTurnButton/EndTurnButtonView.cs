using System;
using UnityEngine;

namespace CFE
{
    [RequireComponent(typeof(EndTurnButtonModel))]
    [RequireComponent(typeof(EndTurnButtonControl))]
    class EndTurnButtonView : ButtonView
    {
        public override void OnDisable()
        {
            base.OnDisable();
            rend.material.color = Color.yellow;
        }

        public override void OnEnable()
        {
            base.OnEnable();
            rend.material.color = Color.green;
        }
    }
}
