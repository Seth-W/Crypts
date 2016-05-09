using UnityEngine.UI;
using UnityEngine;
using System;

namespace CFE.UI
{
    abstract class ActionButtonModel : MonoBehaviour
    {
        public bool actionAvailable
        { get { return isAvailable(); } }

        public abstract bool isAvailable();
    }
}
