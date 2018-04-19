using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RobotIO
{
    public interface IIOPort
    {
        /// <summary>
        /// writes a byte to a port address.
        /// </summary>
        /// <param name="port">port address: address range is 2 bytes</param>
        /// <param name="data">data to write on the port: data range is 1 byte</param>
        void Write(int port, int data);

        /// <summary>
        /// reads a byte from the specified port
        /// </summary>
        /// <param name="port">port address (2 bytes)</param>
        /// <returns></returns>
        int Read(int port);
    }
}
