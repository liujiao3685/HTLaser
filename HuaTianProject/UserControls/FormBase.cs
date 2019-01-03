using System.Windows.Forms;

namespace HuaTianProject.UserControls
{
    public partial class FormBase : UserControl
    {
        public string ControlName { set; get; }

        public FormBase()
        {
            InitializeComponent();
        }
    }
}
