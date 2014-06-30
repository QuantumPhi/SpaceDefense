﻿using Engine;
using SpaceDefense.Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SpaceDefense
{
    class Cannon : GameObject
    {
        public int Health { get; set; }

        protected GameObject core = new GameObject("CORE", (uint)Math.Round(7 * (48f / 15)), (uint)Math.Round(7 * (48f / 15)), "cannon_core.png");
        protected int fadeTime = 50;
        bool fade;

        public Cannon() : base("CANNON", 48, 48, "cannon.png") { }

        public override void Initialize()
        {
            base.Initialize();

            CollisionData.SetCollisionData(Width, Height);
            CollisionData.CollisionEnabled = true;

            Health = 100;
            core.Position = Position;
            ObjectManager.AddGameObject(core);
        }

        public override void Update()
        {
            base.Update();

            core.Position = Position;
            if (fadeTime != 50 && !fade)
                fadeTime++;
            else if (fadeTime != 1 && fade)
                fadeTime--;
            else
                fade = !fade;
            core.SetModulationColor(0f, 0f, 0f, (1f / 75) * fadeTime);
            Rotation += 2;
            Rotation %= 360;
            core.Rotation += 2;
            core.Rotation %= 360;

            Cursor cursor = (ObjectManager.GetObjectByName("CURSOR") as Cursor);

            if (cursor.XBController.IsTriggered(XboxKeys.RT))
            {
                Vector2f mouse = new Vector2f(cursor.Position.X, cursor.Position.Y);
                Vector2f vel = new Vector2f(Position.X - mouse.X, Position.Y - mouse.Y);
                GameObject laser = new Laser(vel);
                laser.Position = Position;
                laser.ZOrder = -1;
                laser.Rotation = (float)(Math.Atan2(vel.Y, vel.X) * 180 / Math.PI + 90);
                ObjectManager.AddGameObject(laser);
            }
        }
    }
}
