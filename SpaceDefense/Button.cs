using Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceDefense
{
    class Button : GameObject
    {
        public enum StateSwitch
        {
            NORMAL_MODE,
            HARD_MODE
        }

        private StateSwitch state;

        public Button(uint width, uint height, string texture, StateSwitch s) 
            : base("BUTTON", width, height, texture) 
        {
            state = s;

            CollisionData.SetCollisionData(width, height);
            CollisionData.CollisionEnabled = true;
        }

        public override void CollisionReaction(CollisionInfo collisionInfo_)
        {
            base.CollisionReaction(collisionInfo_);

            if (collisionInfo_.collidedWithGameObject.Name == "CURSOR" && (collisionInfo_.collidedWithGameObject as Cursor).XBController.IsTriggered(XboxKeys.RT))
            {
                switch (state)
                {
                    case StateSwitch.NORMAL_MODE:
                        GameStateManager.GoToState(new Level());
                        break;
                    case StateSwitch.HARD_MODE:
                        Menu.HardMode = true;
                        GameStateManager.GoToState(new Level());
                        break;
                }
            }
        }
    }
}
