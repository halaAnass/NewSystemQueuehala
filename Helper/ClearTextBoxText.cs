using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NewSystemQueue.Helper
{
    public static class ClearTextBoxText
    {
        /// <summary>
        /// this method to clear text inside text box 
        /// </summary>
        /// <param name="form">form control pass to clear data</param>
        public static void ClearText(Form form) {

            foreach (Control control in form.Controls)
            { 
            if(control is TextBox text)
                { text.Clear(); 
                }
            }
        
        }
    }
}
