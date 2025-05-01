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

    if (string.IsNullOrWhiteSpace(txtId.Text))
    {
        // Si txtId está vacío, agregamos un nuevo registro
        int resultado = PersonaAgregar.AgregarP(persona);
        if (resultado > 0)
        {
            MessageBox.Show("Empleado guardado exitosamente!");
        }
        else
        {
            MessageBox.Show("El empleado no se pudo guardar");
        }
    }
    else
    {
        // Si txtId tiene valor, modificamos el registro existente
        persona.Id = Convert.ToInt32(txtId.Text);
        int resultado = PersonaAgregar.modificarPersona(persona);
        if (resultado > 0)
        {
            MessageBox.Show("Empleado actualizado exitosamente!");
        }
        else
        {
            MessageBox.Show("El empleado no se pudo actualizar");
        }
    }

    refrescarPantalla();
    limpiarCampos();
}
        private void Form1_Load(object sender, EventArgs e)
        {

            dataGridView1.SelectionChanged += dataGridView1_SelectionChanged;
            refrescarPantalla();
            txtId.Enabled=false; 
        
        }

        public void refrescarPantalla()
        {
        dataGridView1.DataSource = PersonaAgregar.MostrarRegistro();
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                txtId.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["Id"].Value);
                txtNombre.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["Nombre"].Value);
                txtApellido.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["Apellido"].Value);
                txtEmail.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["Email"].Value);
                txtTelefono.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["Telefono"].Value);
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
        txtId.Clear();
            txtNombre.Clear();
            txtApellido.Clear();
            txtEmail.Clear();
            txtTelefono.Clear();
            dataGridView1.CurrentCell = null;
            limpiarCampos();
        }

        private void limpiarCampos()
        {
            txtId.Clear();
            txtNombre.Clear();
            txtApellido.Clear();
            txtEmail.Clear();
            txtTelefono.Clear();
            dataGridView1.ClearSelection();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 1)
            {
                int Id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["Id"].Value);

                int resultado = PersonaAgregar.EliminarP(Id);
                if(resultado > 0) 
                {
                    MessageBox.Show("Empleado eliminado con exito!");

                }
                else
                {
                    MessageBox.Show("El empleado no se pudo eliminar");
                }
                refrescarPantalla();
            }
        }
    }
}
