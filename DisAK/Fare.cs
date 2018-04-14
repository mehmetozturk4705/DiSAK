using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DisAK
{
    static class Fare
    {
        // import the necessary API function so .NET can
        // marshall parameters appropriately
        [DllImport("user32.dll")]
        static extern void mouse_event(int dwFlags, int dx, int dy, int dwData, int dwExtraInfo);

        // constants for the mouse_input() API function
        private const int MOUSEEVENTF_MOVE = 0x0001;
        private const int MOUSEEVENTF_LEFTDOWN = 0x0002;
        private const int MOUSEEVENTF_LEFTUP = 0x0004;
        private const int MOUSEEVENTF_RIGHTDOWN = 0x0008;
        private const int MOUSEEVENTF_RIGHTUP = 0x0010;
        private const int MOUSEEVENTF_MIDDLEDOWN = 0x0020;
        private const int MOUSEEVENTF_MIDDLEUP = 0x0040;
        private const int MOUSEEVENTF_ABSOLUTE = 0x8000;

        // simulates movement of the mouse.  parameters specify changes
        // in relative position.  positive values indicate movement
        // right or down
        public static void Git(int xDelta, int yDelta)
        {
            mouse_event(MOUSEEVENTF_MOVE, xDelta, yDelta, 0, 0);
        }

        // simulates movement of the mouse.  parameters specify an
        // absolute location, with the top left corner being the
        // origin
        public static void GitEx(int x, int y)
        {
            mouse_event(MOUSEEVENTF_ABSOLUTE | MOUSEEVENTF_MOVE, x, y, 0, 0);
        }

        // simulates a click-and-release action of the left mouse
        // button at its current position
        public static void SolBas()
        {
            mouse_event(MOUSEEVENTF_LEFTDOWN, Control.MousePosition.X, Control.MousePosition.Y, 0, 0);
      
        }
        public static void SolCek()
        {
            mouse_event(MOUSEEVENTF_LEFTUP, Control.MousePosition.X, Control.MousePosition.Y, 0, 0);

        }
        public static void SagBas()
        {
            mouse_event(MOUSEEVENTF_RIGHTDOWN, Control.MousePosition.X, Control.MousePosition.Y, 0, 0);
        
        }
        public static void SagCek()
        {
            mouse_event(MOUSEEVENTF_RIGHTUP, Control.MousePosition.X, Control.MousePosition.Y, 0, 0);

        }
    }
}
