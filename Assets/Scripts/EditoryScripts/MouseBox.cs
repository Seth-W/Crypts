using UnityEngine;
using Vectrosity;

namespace CFE.Editor
{
    class MouseBox : MonoBehaviour
    {
        public int xOffset, yOffset;
        VectorLine box;
        Vector2[] coordinates;
        

        void Start()
        {
            coordinates = new Vector2[5];
            setCoordinates();
            box = VectorLine.SetLine(Color.red, coordinates);
        }

        void Update()
        {
            setCoordinates();
            for(int i = 0; i < 5; i++)
            {
                box.points2[i] = coordinates[i];
            }
            box.Draw();
        }

        void setCoordinates()
        {
            Vector3 mousePos = Input.mousePosition;
            coordinates[0] = new Vector2(mousePos.x - xOffset, mousePos.y + yOffset); //Upper Left Corner
            coordinates[1] = new Vector2(mousePos.x + xOffset, mousePos.y + yOffset); //Upper Right Corner
            coordinates[2] = new Vector2(mousePos.x + xOffset, mousePos.y - yOffset); //Lower Right Corner
            coordinates[3] = new Vector2(mousePos.x - xOffset, mousePos.y - yOffset); //Lower Left Corner
            coordinates[4] = new Vector2(mousePos.x - xOffset, mousePos.y + yOffset); //Upper Right Corner
        }
    }
}
