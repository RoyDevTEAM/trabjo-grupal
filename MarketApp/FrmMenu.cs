using FontAwesome.Sharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MarketApp
{
    public partial class FrmMenu : Form
    {
        //fields
        private IconButton currentBtn;
        private Panel lefBorderBtn;
        private Form currentChildForm;

        public FrmMenu()
        {
            InitializeComponent();
            lefBorderBtn = new Panel();
            lefBorderBtn.Size = new Size(7, 60);
            panelMenu.Controls.Add(lefBorderBtn);

            //form
            //this.Text = string.Empty;
            //this.ControlBox = false;
            //this.DoubleBuffered = true;
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
        }

        //structs
        private struct RGBColors
        {

            public static Color color1 = Color.FromArgb(172, 126, 241);
            public static Color color2 = Color.FromArgb(249, 118, 176);
            public static Color color3 = Color.FromArgb(253, 138, 114);
            public static Color color4 = Color.FromArgb(95, 77, 221);
            public static Color color5 = Color.FromArgb(249, 88, 155);
            public static Color color6 = Color.FromArgb(24, 161, 251);
        }


        //metodos
        private void ActivateButton(object senderbtn, Color color)
        {
            if (senderbtn == null)
            {
                DisableButton();
                currentBtn = (IconButton)senderbtn;
                currentBtn.BackColor = Color.FromArgb(37, 36, 81);
                currentBtn.ForeColor = color;
                currentBtn.TextAlign = ContentAlignment.MiddleCenter;
                currentBtn.IconColor = color;
                currentBtn.TextImageRelation = TextImageRelation.ImageBeforeText;
                currentBtn.ImageAlign = ContentAlignment.MiddleRight;
                //left border button
                lefBorderBtn.BackColor = color;
                lefBorderBtn.Location = new Point(0, currentBtn.Location.Y);
                lefBorderBtn.Visible = true;
                lefBorderBtn.BringToFront();

                //icon
                iconCurrentChildForm.IconChar = currentBtn.IconChar;
                iconCurrentChildForm.IconColor = color;
            }
        }

        private void DisableButton()
        {
            if (currentBtn != null)
            {

                currentBtn.BackColor = Color.FromArgb(31, 30, 68);
                currentBtn.ForeColor = Color.Gainsboro;
                currentBtn.TextAlign = ContentAlignment.MiddleLeft;
                currentBtn.IconColor = Color.Gainsboro;
                currentBtn.TextImageRelation = TextImageRelation.ImageBeforeText;
                currentBtn.ImageAlign = ContentAlignment.MiddleLeft;
            }
        }

        private void OpenChildForm(Form chilForm)
        {
            if (currentChildForm != null)
            {
                //opne only form
                currentChildForm.Close();
            }
            currentChildForm = chilForm;
            chilForm.TopLevel = false;
            chilForm.FormBorderStyle = FormBorderStyle.None;
            chilForm.Dock = DockStyle.Fill;
            panelDesktop.Controls.Add(chilForm);
            panelDesktop.Tag = chilForm;
            chilForm.BringToFront();
            chilForm.Show();
            lblTitleChildForm.Text = chilForm.Text;
        }


        //private void btnDashboard_Click(object sender, EventArgs e)
        //{
        //    ActivateButton(sender, RGBColors.color1);
        //    OpenChildForm(FrmTrabajador.GetInstancia()); // llamar al form con get instancia, sin el new
        //}
        private void btnVenta_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color2);
            OpenChildForm(FrmVenta.GetInstancia()); // llamar al form con get instancia, sin el new
        }

        

        //private void btnProduct_Click(object sender, EventArgs e)
        //{
        //    ActivateButton(sender, RGBColors.color3);
        //    OpenChildForm(FrmArticulo.GetInstancia());
        //}

        //private void btnCustomer_Click(object sender, EventArgs e)
        //{
        //    ActivateButton(sender, RGBColors.color4);
        //    OpenChildForm(FrmProveedor.GetInstancia());
        //}

        //private void btnMarketing_Click(object sender, EventArgs e)
        //{
        //    ActivateButton(sender, RGBColors.color5);
        //    OpenChildForm(FrmClientes.GetInstancia());
        //}

        //private void btnSetting_Click(object sender, EventArgs e)
        //{
        //    ActivateButton(sender, RGBColors.color6);
        //    OpenChildForm(FrmCategoria.GetInstancia());
        //}

        private void btnHome_Click(object sender, EventArgs e)
        {
            currentChildForm.Close();
            Reset();
        }

        private void Reset()
        {
            DisableButton();
            lefBorderBtn.Visible = false;

            //
            iconCurrentChildForm.IconChar = IconChar.Home;
            iconCurrentChildForm.IconColor = Color.Gainsboro;
            lblTitleChildForm.Text = "Home";
        }

        //drag form
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void Releasecapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void panelTitleBar_MouseDown(object sender, MouseEventArgs e)
        {
            Releasecapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color2);
            OpenChildForm(FrmCliente.GetInstancia()); // llamar al form con get instancia, sin el new
        }
    }
}
