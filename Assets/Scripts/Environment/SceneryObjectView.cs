using UnityEngine;

namespace CFE
{
    class SceneryObjectView : ObjectView
    {
        Renderer rend;

        void Start()
        {
            rend = GetComponent<Renderer>();
        }

        public override void Disable()
        {
        }

        public override void Enable()
        {
        }

        public override void HoverOff()
        {
            rend.material.color = Color.gray;
        }

        public override void HoverOn()
        {
            rend.material.color = Color.white;
        }

        public override void MouseDown()
        {
        }

        public override void MouseUp()
        {
        }
    }
}
