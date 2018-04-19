//------------------------------------------------------------------------------
// C #   I N   A C T I O N   ( C S A )
//------------------------------------------------------------------------------
// Repository:
//    $Id: IOPort.cs 1027 2016-10-11 12:15:12Z chj-hslu $
//------------------------------------------------------------------------------
#define USE_EXTERNAL_DLL
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace RobotCtrl
{

    /// <summary>
    /// Klasse für den Hardware-Zugriff auf den Roboter.
    /// </summary>
	public static class IOPort
    {

#if USE_EXTERNAL_DLL

        #region members
        private static MethodInfo writeMethod;
        private static MethodInfo readMethod;
        #endregion


        #region constructor & destructor
        static IOPort()
        {
            try
            {
                Assembly a = Assembly.LoadFrom("RobotIO.dll");
                Type[] t = a.GetTypes();
                writeMethod = t[3].GetMethod("Write", BindingFlags.Public | BindingFlags.Static);
                readMethod = t[3].GetMethod("Read", BindingFlags.Public | BindingFlags.Static);
            }
            catch (IOException ex)
            {
                MessageBox.Show("RobotIO.dll nicht gefunden.\r\nIm aktuellen Projekt unter References das RobotIO Projekt hinzufügen!\r\n\r\n" + ex.Message,
                    "RobotIO.dll nicht gefunden!", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1);
            }
        }
        #endregion


        #region methods
        /// <summary>
        /// Schreibt ein Byte auf eine Port-Adresse
        /// </summary>
        /// <param name="port">die gewünschte Port-Adresse (16 Bit)</param>
        /// <param name="data">das gewünschte Datenbyte</param>
        public static void Write(int port, int data)
        {
            writeMethod.Invoke(null, new object[] { port, data });
        }


        /// <summary>
        /// Liest ein Byte von einer Port-Adresse
        /// </summary>
        /// <param name="port">die gewünschte Port-Adresse (16 Bit)</param>
        /// <returns>das gelesene Byte</returns>
        public static int Read(int port)
        {
            return (int)readMethod.Invoke(null, new object[] { port });
        }
        #endregion

#else

        #region methods
        /// <summary>
        /// Schreibt ein Byte auf eine Port-Adresse
        /// </summary>
        /// <param name="port">die gewünschte Port-Adresse (16 Bit)</param>
        /// <param name="data">das gewünschte Datenbyte</param>
        public static void Write(int port, int data)
        {
            WriteByte((ushort)port, (byte)data);
        }

        /// <summary>
        /// Liest ein Byte von einer Port-Adresse
        /// </summary>
        /// <param name="port">die gewünschte Port-Adresse (16 Bit)</param>
        /// <returns>das gelesene Byte</returns>
        public static int Read(int port)
        {
            return ReadByte((ushort)port);
        }
        
        [DllImport("CEDDK.dll", EntryPoint = "WRITE_PORT_UCHAR", CharSet = CharSet.Auto)]
        private static extern void WriteByte(ushort Addr, byte Value);

        [DllImport("CEDDK.dll", EntryPoint = "READ_PORT_UCHAR", CharSet = CharSet.Auto)]
        private static extern byte ReadByte(ushort Addr);
        #endregion
#endif
    }
}

