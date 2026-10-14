using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using winform_Ejercicio1.Modelo;

namespace winform_Ejercicio1.Dato
{
    public class Usuarios
    {
        List<UsuarioModelo> lista = new List<UsuarioModelo>();
        /// <summary>
        /// Guarda los usuarios
        /// </summary>
        /// <param name="modelo"> datos del usuario</param>
        public void Guardar(UsuarioModelo modelo)
        {
            lista.Add(modelo);
        }



        public List<UsuarioModelo> Consultar()
        {
            return lista; 
        }
    }
}
