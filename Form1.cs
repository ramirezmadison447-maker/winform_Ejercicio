using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using winform_Ejercicio1.Dato;
using winform_Ejercicio1.Modelo;

namespace winform_Ejercicio1
{
    public partial class Form1 : Form
    {
        DataTable tabla;
        Usuarios dato = new Usuarios();
        public Form1()
        {
            InitializeComponent();
            Iniciar();
        }

        private void btnguardar_Click(object sender, EventArgs e)
        {
            if (!Guardar()) return;
            Limpiar();
            Consultar();
        }

        private void btnlimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void Iniciar()
        {
            tabla = new DataTable();
            tabla.Columns.Add("Nombre");
            tabla.Columns.Add("Edad");
            grilla.DataSource = tabla;
        }

        private bool Guardar()
        {
           
           if (string.IsNullOrWhiteSpace(txtnombre.Text))
           {
           MessageBox.Show("Escribe un nombre. ");
           txtedad.Focus();
                return false;

           }

           if(!int.TryParse(txtedad.Text, out int edad) || edad < 0)
            {
                MessageBox.Show("La edad debe ser un numero valido. ");
                txtedad.Focus();
                return false;
            }


            UsuarioModelo modelo = new UsuarioModelo
            {
                Nombre = txtnombre.Text.Trim(),
                Edad = edad
            };

            dato.Guardar(modelo);
            return true;

        }

        private void Consultar()
        {
            tabla.Rows.Clear();
            foreach(var item in dato.Consultar())
            {
                DataRow fila = tabla.NewRow();
                fila["Nombre"] = item.Nombre;
                fila["Edad"] = item.Edad;
                tabla.Rows.Add(fila);
            }
        }

       private void Limpiar()
        {
            txtnombre.Clear();
            txtedad.Clear();
            txtnombre.Focus();
        }
    }
}
