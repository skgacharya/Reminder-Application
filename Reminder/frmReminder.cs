using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Reminder
{
    public partial class frmReminder : Form
    {
        public frmReminder()
        {
            InitializeComponent();
        }

        private void frmReminder_Load(object sender, EventArgs e)
        {

        }
        private void MinimzedTray()
        {
            notifyIcon1.Visible = true;
            notifyIcon1.Icon = SystemIcons.Application;
            notifyIcon1.ShowBalloonTip(500, "Reminder", "Your Application is Running in BackGround", ToolTipIcon.Info);

        }

        private void MaxmizedFromTray()
        {
            notifyIcon1.Visible = true;
            notifyIcon1.ShowBalloonTip(500, "Reminder", "Your Application is Running in BackGround", ToolTipIcon.Info);
        }


        private void frmReminder_FormClosing(object sender, FormClosingEventArgs e)
        {
           
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                this.WindowState = FormWindowState.Minimized;
                this.ShowInTaskbar = false;
                this.Hide();

            }
        }

        private void frmReminder_Resize(object sender, EventArgs e)
        {
            if (FormWindowState.Minimized == this.WindowState)
            {
                MinimzedTray();
            }
            else if (FormWindowState.Normal == this.WindowState)
            {

                MaxmizedFromTray();
            }
        }

        private void notifyIcon1_DoubleClick(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            frmReminder frm = new frmReminder();
            frm.Show();
            MaxmizedFromTray();
        }

        private void notifyIcon1_MouseClick(object sender, MouseEventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
        }

        private void notifyIcon1_Click(object sender, EventArgs e)
        {
            MaxmizedFromTray();
        }
        
    }
}
