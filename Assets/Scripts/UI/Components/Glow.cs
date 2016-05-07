using UnityEngine;

namespace CFE
{
    class Glow : MonoBehaviour
    {
        bool _active;
        bool active
        {
            get { return _active; }
            set {; }
        }

        private void setActive(bool b)
        {
            _active = b;
            if (b)
                Enable();
            else
                Disable();
        }
        private void Enable()
        {
            Debug.LogError("Not Implemented");
        }
        private void Disable()
        {
            Debug.LogError("Not Implemented");
        }
    }
}
