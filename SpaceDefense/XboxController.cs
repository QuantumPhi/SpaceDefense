/******************************************************************************/
/*!
\file XboxController.cs
\author Jeison Salazar
\par ProjectFUN
\date 07/17/2013
\brief
  Xbox Controller implementation for the Advanced 2D Video Game Programming
  ProjectFUN Class.
\par Copyright 2013 DigiPen (USA) Corporation. All Rights Reserved.
*/
/******************************************************************************/

using System;
using SlimDX;
using SlimDX.XInput;

namespace SpaceDefense
{
    class XboxController
    {
        // Constructor
        public XboxController(UserIndex playerIndex)
        {
            PlayerIndex = playerIndex;
            Controller = new Controller(playerIndex);
        }

        // Data members
        uint lastPacket;

        public readonly UserIndex PlayerIndex;
        public readonly Controller Controller;

        private ButtonState lastBState;
        private ButtonState currentBState;
        private Gamepad currentState;

        public ArrowsState Arrows { get; private set; }
        public StickState LeftStick { get; private set; }
        public StickState RightStick { get; private set; }

        public bool A { get; private set; }
        public bool B { get; private set; }
        public bool X { get; private set; }
        public bool Y { get; private set; }

        public bool RB { get; private set; }
        public bool LB { get; private set; }

        public bool START { get; private set; }
        public bool BACK { get; private set; }

        public float RightTrigger { get; private set; }
        public float LeftTrigger { get; private set; }

        public bool RT { get; private set; }
        public bool LT { get; private set; }

        public bool IsConnected { get { return Controller.IsConnected; } }
        
        //Methods
        public void SetVibration(float lowFrequencyMotorSpeed, float highFrequencyMotorSpeed)
        {
            Vibration vb = new Vibration 
            {
                LeftMotorSpeed = (ushort) (MathHelper.Saturate(lowFrequencyMotorSpeed) * ushort.MaxValue), 
                RightMotorSpeed = (ushort) (MathHelper.Saturate(highFrequencyMotorSpeed) * ushort.MaxValue)
            };
            Controller.SetVibration(vb);
        }

        public bool IsTriggered(XboxKeys button)
        {
            switch (button)
            {
                case XboxKeys.A:
                    return ((!lastBState.A) && (lastBState.A != currentBState.A));
                case XboxKeys.B:
                    return ((!lastBState.B) && (lastBState.B != currentBState.B));
                case XboxKeys.X:
                    return ((!lastBState.X) && (lastBState.X != currentBState.X));
                case XboxKeys.Y:
                    return ((!lastBState.Y) && (lastBState.Y != currentBState.Y));
                case XboxKeys.RB:
                    return ((!lastBState.RB) && (lastBState.RB != currentBState.RB));
                case XboxKeys.LB:
                    return ((!lastBState.LB) && (lastBState.LB != currentBState.LB));
                case XboxKeys.RT:
                    return ((!lastBState.RT) && (lastBState.RT != currentBState.RT));
                case XboxKeys.LT:
                    return ((!lastBState.LT) && (lastBState.LT != currentBState.LT));
                case XboxKeys.LS:
                    return ((!lastBState.LS) && (lastBState.LS != currentBState.LS));
                case XboxKeys.RS:
                    return ((!lastBState.RS) && (lastBState.RS != currentBState.RS));
                case XboxKeys.START:
                    return ((!lastBState.START) && (lastBState.START != currentBState.START));
                case XboxKeys.BACK:
                    return ((!lastBState.BACK) && (lastBState.BACK != currentBState.BACK));
                default:
                    return false;
            }
        }

        public bool IsPressed(XboxKeys button)
        {
            switch (button)
            {
                case XboxKeys.A:
                    return A;
                case XboxKeys.B:
                    return B;
                case XboxKeys.X:
                    return X;
                case XboxKeys.Y:
                    return Y;
                case XboxKeys.RB:
                    return RB;
                case XboxKeys.LB:
                    return LB;
                case XboxKeys.RT:
                    return RT;
                case XboxKeys.LT:
                    return LT;
                case XboxKeys.LS:
                    return LeftStick.IsClicked;
                case XboxKeys.RS:
                    return RightStick.IsClicked;
                case XboxKeys.START:
                    return START;
                case XboxKeys.BACK:
                    return BACK;
                default:
                    return false;
            }
        }

        public bool IsReleased(XboxKeys button)
        {
            return !IsTriggered(button);
        }

        public void Update()
        {
            // Check that the controller is connected
            if (!IsConnected) return;

            // Update the state of the controller
            SlimDX.XInput.State state = Controller.GetState();


           lastBState = new ButtonState(A, B, X, Y, LB, LT, RB, RT, Arrows.Up, Arrows.Down, Arrows.Left, Arrows.Right, START, BACK, LeftStick.IsClicked, RightStick.IsClicked);
           currentState = state.Gamepad;


            LB = (currentState.Buttons & GamepadButtonFlags.LeftShoulder) != 0;
            RB = (currentState.Buttons & GamepadButtonFlags.RightShoulder) != 0;

            START = (currentState.Buttons & GamepadButtonFlags.Start) != 0;
            BACK = (currentState.Buttons & GamepadButtonFlags.Back) != 0;

            A = (currentState.Buttons & GamepadButtonFlags.A) != 0;
            B = (currentState.Buttons & GamepadButtonFlags.B) != 0;
            X = (currentState.Buttons & GamepadButtonFlags.X) != 0;
            Y = (currentState.Buttons & GamepadButtonFlags.Y) != 0;

            // Analog Input
            LeftTrigger = currentState.LeftTrigger / (float)byte.MaxValue;
            RightTrigger = currentState.RightTrigger / (float)byte.MaxValue;

            LeftStick = new StickState(Normalize(currentState.LeftThumbX, currentState.LeftThumbY, Gamepad.GamepadLeftThumbDeadZone), (currentState.Buttons & GamepadButtonFlags.LeftThumb) != 0);
            RightStick = new StickState(Normalize(currentState.RightThumbX, currentState.RightThumbY, Gamepad.GamepadRightThumbDeadZone), (currentState.Buttons & GamepadButtonFlags.RightThumb) != 0);

            // Digital Input for analog triggers
            LT = LeftTrigger > 0;
            RT = RightTrigger > 0;

            Arrows = new ArrowsState((currentState.Buttons & GamepadButtonFlags.DPadUp) != 0, (currentState.Buttons & GamepadButtonFlags.DPadDown) != 0,
                                     (currentState.Buttons & GamepadButtonFlags.DPadLeft) != 0, (currentState.Buttons & GamepadButtonFlags.DPadRight) != 0);
            
            
            currentBState = new ButtonState(A, B, X, Y, LB, LT, RB, RT, Arrows.Up, Arrows.Down, Arrows.Left, Arrows.Right, START, BACK, LeftStick.IsClicked, RightStick.IsClicked);
            
        }

        static Vector2 Normalize(short X, short Y, short deadzone)
        {
            var value = new Vector2(X, Y);
            var magnitude = value.Length();
            var direction = value / (magnitude == 0 ? 1 : magnitude);

            var nMagnitude = 0.0f;
            if (magnitude - deadzone > 0)
            {
                nMagnitude = Math.Min((magnitude - deadzone) / (short.MaxValue - deadzone), 1);
            }

            return direction * nMagnitude;
        }

        // Helper Structures

        public struct ArrowsState
        {
            public readonly bool Up, Down, Left, Right;
            public ArrowsState(bool up, bool down, bool left, bool right)
            {
                Up = up;
                Down = down;
                Left = left;
                Right = right;
            }
        }

        public struct StickState
        {
            public readonly Vector2 Position;
            public readonly bool IsClicked;
            public StickState(Vector2 position, bool isClicked)
            {
                IsClicked = isClicked;
                Position = position;
            }
        }
        public struct ButtonState
        {
            public readonly bool A;
            public readonly bool B;
            public readonly bool X;
            public readonly bool Y;

            public readonly bool Up;
            public readonly bool Down;
            public readonly bool Left;
            public readonly bool Right;

            public readonly bool LB;
            public readonly bool LT;
            public readonly bool RB;
            public readonly bool RT;

            public readonly bool START;
            public readonly bool BACK;
            public readonly bool LS;
            public readonly bool RS;

            public ButtonState(bool a, bool b, bool x, bool y, bool lb, bool lt, bool rb, bool rt, bool up, bool down, bool left, bool right, bool start, bool back, bool ls, bool rs)
            {
                A = a;
                B = b;
                X = x;
                Y = y;

                Up = up;
                Down = down;
                Left = left;
                Right = right;

                RB = rb;
                RT = rt;
                LB = lb;
                LT = lt;

                START = start;
                BACK = back;
                LS = ls;
                RS = rs;
            }
        }
    }

    public static class MathHelper
    {
        public static float Saturate(float value)
        {
            return value < 0 ? 0 : value > 1 ? 1 : value;
        }
    }

    public enum XboxKeys
    {
        A,
        B,
        X,
        Y,
        LB,
        RB,
        LT,
        RT,
        LS,
        RS,
        UP,
        DOWN,
        LEFT,
        RIGHT,
        START,
        BACK
    }
}
