using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace RobotIO
{
    public class GPIOPort : IIOPort
    {
        /// <summary>
        /// data pin numbers
        /// </summary>
        private static int[] DATA_PINS = new int[] { 187, 185, 183, 181, 179, 177, 175, 173 };

        /// <summary>
        /// address pin numbers
        /// </summary>
        private static int[] ADDR_PINS = new int[] { 1, 3, 5, 7, 15, 17, 6, 8 };

        /// <summary>
        /// io write pin
        /// </summary>
        private static int IOW_PIN = 135;

        /// <summary>
        /// io read pin
        /// </summary>
        private static int IOR_PIN = 159;

        private object portLock;

        private GPIOPort()
        {
            portLock = new Object();
        }

        private static GPIOPort g_GPIOPort;

        public static GPIOPort PORT
        {
            get
            {
                if (g_GPIOPort == null)
                {
                    g_GPIOPort = new GPIOPort();
                    g_GPIOPort.Init();
                }
                return g_GPIOPort;
            }
        }
        
        public static void WritePort(int port, int data)
        {
            PORT.Write(port, data);
        }

        /// <summary>
        /// reads a byte from the specified port
        /// </summary>
        /// <param name="port">port address (2 bytes)</param>
        /// <returns></returns>
        public static int ReadPort(int port)
        {
            return PORT.Read(port);
        }

        /// <summary>
        /// initializes the gpio library and all used pins
        /// </summary>
        public static void InitGPIO()
        {
            GPIO.InitGPIOLib();
            for (int i = 0; i < DATA_PINS.Length; i++)
            {
                int pin = DATA_PINS[i];
                GPIO.SetPinAltFn(pin, -1, false);
            }
            for (int i = 0; i < ADDR_PINS.Length; i++)
            {
                int pin = ADDR_PINS[i];
                GPIO.SetPinAltFn(pin, -1, true);
                GPIO.SetPinLevel(pin, 1);
            }
            GPIO.SetPinAltFn(IOW_PIN, -1, true);
            GPIO.SetPinLevel(IOW_PIN, 1);
            GPIO.SetPinAltFn(IOR_PIN, -1, true);
            GPIO.SetPinLevel(IOR_PIN, 1);
        }

        /// <summary>
        /// deinitializes the gpio library
        /// </summary>
        public static void DeInitGPIO()
        {
            GPIO.DeInitGPIOLib();
        }

        /// <summary>
        /// initializes the gpio library and all used pins
        /// </summary>
        public void Init()
        {
            InitGPIO();
        }

        /// <summary>
        /// writes a byte to the specified port
        /// </summary>
        /// <param name="port">port address</param>
        /// <param name="data">port data</param>
        public void Write(int port, int data)
        {
            lock (portLock)
            {
                for (int i = 0; i < DATA_PINS.Length; i++)
                {
                    GPIO.SetPinDir(DATA_PINS[i], true);
                    int j = 1<<i;
                    if ((data & j) > 0)
                    {
                        GPIO.SetPinLevel(DATA_PINS[i], 1);
                    }
                    else
                    {
                        GPIO.SetPinLevel(DATA_PINS[i], 0);
                    }
                }
                for (int i = 0; i < ADDR_PINS.Length; i++)
                {
                    int j = 1 << i;
                    if ((port & j) > 0)
                    {
                        GPIO.SetPinLevel(ADDR_PINS[i], 1);
                    }
                    else
                    {
                        GPIO.SetPinLevel(ADDR_PINS[i], 0);
                    }
                }

                GPIO.SetPinLevel(IOW_PIN, 0);

                GPIO.SetPinLevel(IOW_PIN, 1);
                for (int i = 0; i < DATA_PINS.Length; i++)
                {
                    int pin = DATA_PINS[i];
                    GPIO.SetPinDir(pin, false);
                }
            }
        }

        /// <summary>
        /// reads a byte from the specified port
        /// </summary>
        /// <param name="port">port address (2 bytes)</param>
        /// <returns>the data byte from the port</returns>
        public int Read(int port)
        {
            lock (portLock)
            {
                int ret = 0;
                for (int i = 0; i < ADDR_PINS.Length; i++)
                {
                    int j = 1 << i;
                    if ((port & j) > 0)
                    {
                        GPIO.SetPinLevel(ADDR_PINS[i], 1);
                    }
                    else
                    {
                        GPIO.SetPinLevel(ADDR_PINS[i], 0);
                    }
                }
                GPIO.SetPinLevel(IOR_PIN, 0);
                for (int i = 0; i < DATA_PINS.Length; i++)
                {
                    int pin = DATA_PINS[i];

                    bool level = GPIO.GetPinLevel(pin);
                    ret = level ? ret | (1 << i) : ret & ~(1 << i);
                }
                GPIO.SetPinLevel(IOR_PIN, 1);
                return ret;
            }
        }
    }
}
