using Engine;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SpaceDefense
{
    class HealthBar
    {
        public static void Render(PointF pos, int health, uint maxHealth)
        {
            health = health < 0 ? 0 : health;

            GameObject temp;
            for (int i = 0; i < health; i++)
            {
                temp = new GameObject("HEALTH", 50 / maxHealth, 5, "Health_POSITIVE.png");
                temp.Position = pos;
                temp.Position.Y -= 25;
                ObjectManager.AddGameObject(temp);
            }

            for (int i = 0; i < maxHealth - health; i++)
            {
                temp = new GameObject("HEALTH", 50 / maxHealth, 5, "Health_NEGATIVE.png");
                temp.Position = pos;
                temp.Position.Y -= 25;
                ObjectManager.AddGameObject(temp);
            }
        }
    }
}
