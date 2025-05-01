using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CRUD
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Personas persona = new Personas();


            persona.Nombre = txtNombre.Text;
            persona.Apellido = txtApellido.Text;
            persona.Email = txtEmail.Text;
            persona.Telefono = txtTelefono.Text;

            int resultado = PersonaAgregar.AgregarP(persona);
            if (resultado > 0)
            {
                MessageBox.Show("Empleado guardado exitosamente!");
            }
            else
            {
                MessageBox.Show("El empleado no se pudo guardar");
            }
            refrescarPantalla();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            dataGridView1.SelectionChanged += dataGridView1_SelectionChanged;
            refrescarPantalla();
        
        }

        public void refrescarPantalla()
        {
        dataGridView1.DataSource = PersonaAgregar.MostrarRegistro();
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                txtNombre.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["Nombre"].Value);
                txtApellido.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["Apellido"].Value);
                txtEmail.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["Email"].Value);
                txtTelefono.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["Telefono"].Value);
            }
        }

    }
}
