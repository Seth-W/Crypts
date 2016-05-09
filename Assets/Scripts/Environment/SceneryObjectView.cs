using UnityEngine;

namespace CFE
{
    class SceneryObjectView : ObjectView
    {

        public override void Disable()
        {
        }

        public override void Enable()
        {
        }

        public override void HoverOn()
        {
            rend.material.color = Color.white;
        }

        public override void HoverOff()
        {
            rend.material.color = new Color(.8f, .8f, .8f, 1f) ;
        }

        public override void MouseDown()
        {
        }

        public override void MouseUp()
        {
        }
    }
}
