//------------------------------------------------------------------------------
// C #   I N   A C T I O N   ( C S A )
//------------------------------------------------------------------------------
// Repository:
//    $Id: DriveInfo.cs 1039 2016-10-25 11:56:45Z chj-hslu $
//------------------------------------------------------------------------------
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace RobotCtrl
{
    public struct DriveInfo
    {

        #region members
        public PositionInfo Position;
        public float Runtime;
        public float SpeedL;
        public float SpeedR;
        public float DistanceL;
        public float DistanceR;
        public int DriveStatus;
        public int MotorStatusL;
        public int MotorStatusR;
        #endregion


        public DriveInfo(PositionInfo position,
            float runtime,
            float speedL, float speedR,
            float distanceL, float distanceR,
            int driveStatus,
            int motorStatusL, int motorStatusR
            )
        {
            Position = position;
            Runtime = runtime;
            SpeedL = speedL;
            SpeedR = speedR;
            DistanceL = distanceL;
            DistanceR = distanceR;
            DriveStatus = driveStatus;
            MotorStatusL = motorStatusL;
            MotorStatusR = motorStatusR;
        }

    }
}
