//using System.Linq;
using System.Windows.Forms;

namespace ExifToFileName
{
    public partial class FrmErrorLog : Form
    {
        public FrmErrorLog()
        {
            InitializeComponent();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        public DialogResult ShowDialog(IWin32Window owner, string ErrorLogText)
        {
            TBLog.Text = ErrorLogText;
            TBLog.Select(0, 0); // jinak je nove pridany text vyselectovany ?

            return base.ShowDialog(owner);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        // esc => konec formu
        private void FrmErrorLog_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                Close();
        }
    }
}
