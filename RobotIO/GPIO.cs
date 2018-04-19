using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace RobotIO
{
    public class GPIO
    {
        /// <summary>
        /// sets the pin function
        /// </summary>
        /// <param name="pinNum">pin number</param>
        /// <param name="altFn">alternative pin function: -1 for gpio</param>
        /// <param name="dirOut">direction (true for output and false for input)</param>
        /// <returns></returns>
        [DllImport("GPIOLib.dll", CharSet = CharSet.Auto)]  // Importing DLL
        public static extern bool SetPinAltFn(Int32 pinNum, Int32 altFn, bool dirOut); // External function declaration
        
        /// <summary>
        /// initializes the toradex gpio library
        /// </summary>
        [DllImport("GPIOLib.dll", CharSet = CharSet.Auto)]
        public static extern void InitGPIOLib();

        /// <summary>
        /// sets the pin level
        /// </summary>
        /// <param name="pinNum">pin number</param>
        /// <param name="val">value to set 0 or 1</param>
        /// <returns></returns>
        [DllImport("GPIOLib.dll", CharSet = CharSet.Auto)]
        public static extern bool SetPinLevel(Int32 pinNum, Int32 val);
        
        /// <summary>
        /// sets the direction (output or input) of the pin
        /// </summary>
        /// <param name="pinNum">pin number</param>
        /// <param name="dirOut">direction (true for output and false for input)</param>
        [DllImport("GPIOLib.dll", CharSet = CharSet.Auto)]
        public static extern void SetPinDir(Int32 pinNum, bool dirOut);

        /// <summary>
        /// gets the pin value
        /// </summary>
        /// <param name="pinNum">pin number</param>
        /// <returns></returns>
        [DllImport("GPIOLib.dll", CharSet = CharSet.Auto)]
        public static extern bool  GetPinLevel(Int32 pinNum);


        /// <summary>
        /// deinitializes the gpio library, makes a cleanup
        /// </summary>
        [DllImport("GPIOLib.dll", CharSet = CharSet.Auto)]
        public static extern void DeInitGPIOLib();
    }

}
