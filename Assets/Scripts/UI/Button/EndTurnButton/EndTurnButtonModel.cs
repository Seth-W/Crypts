using System;
using UnityEngine;
using UnityEngine.UI;

namespace CFE.UI
{
    [RequireComponent(typeof(EndTurnButtonControl))]
    [RequireComponent(typeof(EndTurnButtonView))]
    class EndTurnButtonModel : ObjectModel
    {
        public override void Disable()
        {
            Debug.LogError("Disable not implemented for " + this);
        }

        public override void Enable()
        {
            Debug.LogError("Enable not implemented for " + this);
        }
    }
}