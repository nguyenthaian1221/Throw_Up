using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using System;

namespace HelperSystem
{

    public class HelperMath
    {

        // Convert Vector To Angle
        public static Vector2 EulerToVector(int degreeAngle)
        {
            Vector2 res;
            float radianAngle = degreeAngle * Mathf.Deg2Rad;
            res.x = Mathf.Cos(radianAngle);
            res.y = Mathf.Sin(radianAngle);
            return res.normalized;
        }




        // Deliver prediction for the player
        public static void Tracjectory(Vector2 curPos, Vector2 goal)
        {

            // DL 2 Newton
            // F = ma       // we set object weight 1k so F = a
            // v = vo + at  // Because object isn't moving so Vo = 0


            // Formula for predict the arch
            // x: x =xo + Vo.x * t
            // y: y = yo + Vo.y - 1/2 * g * t * t
            // Equivalent
            // x: x =xo + Vo * cos(&) * t
            // y: y = yo + Vo * sin(&) - 1/2 * g * t * t
            Debug.Log("Unavailable");

        }

        public static int ResultForce(Vector2 curPos, Vector2 goal, int angle)
        {
            int res;

            // x: x =xo + Vo.x * t
            // y: y = yo + Vo.y - 1/2 * g * t * t
            if (angle == 90 || angle == -90 || angle == -270 || angle == 270)
            {
                return res = -1;
            }

            // calculate tan value

            float tanValue = Mathf.Tan(angle * Mathf.Deg2Rad);

            // Calculate time to reach target point
            float time = Mathf.Sqrt((goal.y - curPos.y + tanValue * (curPos.x - goal.x)) / -4.905f);

            float VelocityX = (goal.x - curPos.x) / time;
            float VelocityY = tanValue * VelocityX;

            res = Mathf.RoundToInt(MathF.Sqrt((VelocityX * VelocityX + VelocityY * VelocityY) / 0.0004f));

            return res;
        }

        public static int ResultForceWithAirResistance(Vector2 curPos, Vector2 goal, int angle, float airResistence)
        {
            int res;

            // x: x =xo + Vo.x * t + a * t * t          
            // y: y = yo + Vo.y - 1/2 * g * t * t
            if (angle == 90 || angle == -90 || angle == -270 || angle == 270)
            {
                return res = -1;
            }

            // calculate tan value

            float tanValue = Mathf.Tan(angle * Mathf.Deg2Rad);

            // Calculate time to reach target point
            float time = Mathf.Sqrt(((goal.x - curPos.x) * tanValue - goal.y + curPos.y) / (4.905f + airResistence * tanValue * 0.5f));

            float VelocityX = ((goal.x - curPos.x) / time) - time *airResistence * 0.5f;
            float VelocityY = tanValue * VelocityX;

            res = Mathf.RoundToInt(MathF.Sqrt((VelocityX * VelocityX + VelocityY * VelocityY) / 0.0004f));

            return res;
        }

    }



}
