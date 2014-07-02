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
    class HealthBar : GameObject
    {
        private GameObject type;
        private uint maxHealth;
        private int curHealth;

        public HealthBar(uint m, GameObject g)
            : base("HEALTH", 50, 10, "Health_POSITIVE.png")
        { maxHealth = m; curHealth = (int)m; type = g; }

        public override void Update()
        {
            base.Update();

            Position = type.Position;
            Position.Y -= 50;
            if (type is Player)
            {
                if ((type as Player).Health != curHealth)
                {
                    Scale.X -= (float)(curHealth - (type as Player).Health) / maxHealth;
                    curHealth = (type as Player).Health;
                }
            }
            else if (type is Cannon)
            {
                if ((type as Cannon).Health != curHealth)
                {
                    Scale.X -= (float)(curHealth - (type as Cannon).Health) / maxHealth;
                    curHealth = (type as Cannon).Health;
                }
            }
        }
    }
}
