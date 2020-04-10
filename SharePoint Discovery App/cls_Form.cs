using System.Windows.Forms;

namespace SharePoint_Discovery_App
{
    class cls_Form
    {
        public static void ChangeButton(Button btn, bool start, string message = null)
        {
            if (start)
            {
                btn.Tag = btn.Text;
                btn.Height = 60;
                btn.Text = message;
            }
            else
            {
                btn.Text = btn.Tag.ToString();
                btn.Height = 30;
            }
        }
    }
}
