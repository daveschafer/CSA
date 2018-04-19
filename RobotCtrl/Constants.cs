//------------------------------------------------------------------------------
// C #   I N   A C T I O N   ( C S A )
//------------------------------------------------------------------------------
// Repository:
//    $Id: Constants.cs 843 2012-10-10 14:02:01Z zajost $
//------------------------------------------------------------------------------
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace RobotCtrl
{
    public enum RunMode { Virtual, Real };

    public static class Constants
    {

        public static bool IsWinCE { get { return Environment.OSVersion.Platform == PlatformID.WinCE; } }

        // Roboter-Kennzahlen
        public const float WheelDiameter = 0.076f;
        public const float AxleLength = 0.263f;
        public const int TicksPerRevolution = 28672;
        public const float WheelCircumference = (float)(Math.PI * WheelDiameter);
        public const float MeterPerTick = WheelCircumference / TicksPerRevolution;
        public const float Width = 0.28f;
        public const float HalfWidth = Width / 2;

        // IO-Adressen
        public const int IOConsoleLED = 0xF303;
        public const int IOConsoleSWITCH = 0xF303;
        public const int IORadarSensor = 0xF310;
        public const int IODriveCtrl = 0xF330;
        public const int IOMotorCtrlRight = 0xF320;
        public const int IOMotorCtrlLeft = 0xF328;

    }
}
