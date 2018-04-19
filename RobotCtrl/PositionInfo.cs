//------------------------------------------------------------------------------
// C #   I N   A C T I O N   ( C S A )
//------------------------------------------------------------------------------
// Repository:
//    $Id: PositionInfo.cs 1039 2016-10-25 11:56:45Z chj-hslu $
//------------------------------------------------------------------------------
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace RobotCtrl
{
    public struct PositionInfo
    {
        public float X;
        public float Y;
        public float Angle;

        public PositionInfo(float x, float y, float angle)
        {
            X = x;
            Y = y;
            Angle = angle;
        }
    }
}
