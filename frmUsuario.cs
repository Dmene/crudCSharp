using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace crud
{
    public partial class frmUsuario : Form
    {
        private int? Id;
        public frmUsuario( int? Id= null)
        {
            InitializeComponent();
            this.Id = Id;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dsCrudTableAdapters.usuarioTableAdapter ta =
                new dsCrudTableAdapters.usuarioTableAdapter();
            if (Id == null)
            {
                ta.Insertar(txtName.Text.Trim(), txtCedula.Text.Trim(),
                     txtDir.Text.Trim(), txtEmail.Text.Trim(), txtClave.Text.Trim());
            }
            else {
                ta.Edit(txtName.Text.Trim(), txtCedula.Text.Trim(),
                   txtDir.Text.Trim(), txtEmail.Text.Trim(), txtClave.Text.Trim(),(int) Id);
            }
                this.Close();
        }

        private void frmUsuario_Load(object sender, EventArgs e)
        {
            if (Id != null)
            {
                dsCrudTableAdapters.usuarioTableAdapter ta =
                    new dsCrudTableAdapters.usuarioTableAdapter();
                dsCrud.usuarioDataTable dt = ta.GetDataById((int)Id);
                dsCrud.usuarioRow row = (dsCrud.usuarioRow)dt.Rows[0];
                txtName.Text = row.nomUsuario;
                txtCedula.Text = row.cedUsuario;
                txtDir.Text = row.DirUsuario;
                txtEmail.Text = row.emUsuario;
                txtClave.Text = row.claveUsuario;

            }
        }
    }
}
