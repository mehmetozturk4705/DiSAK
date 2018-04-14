using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
namespace DisAK
{
    class Keyboard : IMessageFilter
    {
        const int WM_KEYDOWN = 0x100;
        bool Space = false;
        public bool PreFilterMessage(ref Message m)
        {
            if (m.Msg == ((int)WM_KEYDOWN))
            {
                switch ((int)m.WParam)
                {
                    case (int)Keys.Space:
                       
                        return true;
                    case (int)Keys.Right:
                        // Do Something
                        return true;
                    case (int)Keys.Left:
                        // Do Something
                        return true;
                    default:
                        Space = false;
                        break;

                }
            }

            return false;
        }
    }
}
    
