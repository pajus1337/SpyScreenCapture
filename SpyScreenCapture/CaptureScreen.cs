using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using Image = System.Drawing.Image;

namespace SpyScreenCapture
{
    public static class CaptureScreen
    {
        [DllImport("user32.dll")]
        static extern IntPtr GetDC(IntPtr hWnd);

        [DllImport("user32.dll")]
        static extern int ReleaseDC(IntPtr hWnd, IntPtr hDC);

        [DllImport("gdi32.dll")]
        static extern IntPtr DeleteDC(IntPtr hDC);

        [DllImport("gdi32.dll")]
        static extern IntPtr DeleteObject(IntPtr hObj);

        [DllImport("gdi32.dll")]
        static extern IntPtr CreateCompatibleBitmap(IntPtr hDC, int nWidth, int nHeight);

        [DllImport("gdi32.dll")]
        static extern IntPtr CreateCompatibleDC(IntPtr hDC);

        [DllImport("gdi32.dll")]
        static extern IntPtr SelectObject(IntPtr hDC, IntPtr hObj);

        [DllImport("gdi32.dll")]
        static extern bool BitBlt(IntPtr hDestDC, int x, int y, int nWidth, int nHeight, IntPtr hSrcDC, int xSrc, int ySrc, int dwRop);

        [DllImport("user32.dll")]
        static extern int GetSystemMetrics(int nIndex);

        const int SM_CXSCREEN = 0;
        const int SM_CYSCREEN = 1;
        const int SRCCOPY = 0x00CC0020;

        public static void CaptureScreenToFile(string filename, ImageFormat format)
        {
            int screenX = GetSystemMetrics(SM_CXSCREEN);
            int screenY = GetSystemMetrics(SM_CYSCREEN);

            IntPtr hScreenDC = GetDC(IntPtr.Zero);
            IntPtr hMemoryDC = CreateCompatibleDC(hScreenDC);
            IntPtr hBitmap = CreateCompatibleBitmap(hScreenDC, screenX, screenY);
            IntPtr oldBitmap = SelectObject(hMemoryDC, hBitmap);

            BitBlt(hMemoryDC, 0, 0, screenX, screenY, hScreenDC, 0, 0, SRCCOPY);
            SelectObject(hMemoryDC, oldBitmap);

            using (Bitmap bmp = Image.FromHbitmap(hBitmap))
            {
                bmp.Save(filename, format);
            }

            DeleteDC(hMemoryDC);
            DeleteObject(hBitmap);
            ReleaseDC(IntPtr.Zero, hScreenDC);
        }

        public static byte[] CaptureScreenToByteArray(ImageFormat format)
        {
            int screenX = GetSystemMetrics(SM_CXSCREEN);
            int screenY = GetSystemMetrics(SM_CYSCREEN);

            IntPtr hScreenDC = GetDC(IntPtr.Zero);
            IntPtr hMemoryDC = CreateCompatibleDC(hScreenDC);
            IntPtr hBitmap = CreateCompatibleBitmap(hScreenDC, screenX, screenY);
            IntPtr oldBitmap = SelectObject(hMemoryDC, hBitmap);

            BitBlt(hMemoryDC, 0, 0, screenX, screenY, hScreenDC, 0, 0, SRCCOPY);
            SelectObject(hMemoryDC, oldBitmap);

            byte[] byteImage;
            using (Bitmap bmp = Image.FromHbitmap(hBitmap))
            {
                using (MemoryStream stream = new MemoryStream())
                {
                    bmp.Save(stream, format);
                    byteImage = stream.ToArray();
                }
            }

            DeleteDC(hMemoryDC);
            DeleteObject(hBitmap);
            ReleaseDC(IntPtr.Zero, hScreenDC);

            return byteImage;
        }
    }
}

