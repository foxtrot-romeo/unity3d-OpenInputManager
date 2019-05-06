﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace OpenInputManager
{
    public static class UnityFormat
    {
        public const string UnityJoystickName = "joystick";
        public const string UnityJoystickButtonName = "button";
        public const string UnityMouseButtonName = "mouse";

        public static string JoystickButtonName(
            JoystickNumber joystickNumber,
            JoystickButtonNumber? joystickButtonNumber,
            string joystickName = UnityJoystickName,
            string joystickButtonName = UnityJoystickButtonName)
        {
            return joystickButtonNumber == null
                ? null
                : JoystickButtonName(joystickNumber, (JoystickButtonNumber)joystickButtonNumber, joystickName, joystickButtonName);
        }
        public static string JoystickButtonName(
            JoystickNumber joystickNumber,
            JoystickButtonNumber joystickButtonNumber,
            string joystickName = UnityJoystickName,
            string joystickButtonName = UnityJoystickButtonName)
        {
            return JoystickName(joystickNumber, joystickName) + " " + JoystickButtonName(joystickButtonNumber, joystickButtonName);
        }
        public static string JoystickButtonName(
            JoystickButtonNumber joystickButtonNumber,
            string joystickButtonName = UnityJoystickButtonName)
        {
            return joystickButtonName + " " + (int)joystickButtonNumber;
        }
        public static string JoystickName(
            JoystickNumber joystickNumber,
            string joystickName = UnityJoystickName)
        {
            if (joystickNumber == JoystickNumber.AllJoysticks)
                return joystickName;

            else
                return joystickName + " " + (int)joystickNumber;
        }

        public static string MouseButtonName(
            MouseButtonNumber? mouseButtonNumber,
            string mouseButtonName = UnityMouseButtonName)
        {
            return mouseButtonNumber == null
                ? null
                : MouseButtonName((MouseButtonNumber)mouseButtonNumber, mouseButtonName);
        }
        public static string MouseButtonName(
            MouseButtonNumber mouseButtonNumber,
            string mouseButtonName = UnityMouseButtonName)
        {
            return mouseButtonName + " " + (int)mouseButtonNumber;
        }


        public const int UnityJoystickButtonCount = KeyCode.Joystick2Button0 - KeyCode.Joystick1Button0;
        public static KeyCode UnityKeyCode(this MouseButtonNumber mouseButtonNumber)
        {
            if (mouseButtonNumber > MouseButtonNumber.Mouse6)
                throw new NotSupportedException("KeyCode for mouse button is only supported up to mouse button 6.");

            else
                return KeyCode.Mouse0 + (int)mouseButtonNumber;
        }
        public static KeyCode UnityKeyCode(JoystickNumber joystickNumber, JoystickButtonNumber joystickButtonNumber)
        {
            if (joystickNumber > JoystickNumber.Joystick8)
                throw new NotSupportedException("KeyCode for joystick button is only supported up to joystick 8.");

            else if ((int)joystickButtonNumber > UnityJoystickButtonCount)
                throw new NotSupportedException("KeyCode for joystick button is only supported up to button " + UnityJoystickButtonCount + ".");

            else
                return KeyCode.JoystickButton0 + ((int)joystickButtonNumber * UnityJoystickButtonCount) + (int)joystickButtonNumber;
        }
    }
}
