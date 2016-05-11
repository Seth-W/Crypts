using System;
using UnityEngine;

namespace CFE
{
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
