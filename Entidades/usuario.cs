﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPAI_REDSISMICA.Entidades
{
    public class Usuario
    {
        private string contraseña { get; set; }

        private string nombreUsuario { get; set; }

        public Usuario(string nombreUsuario, string contraseña)
        {
            this.nombreUsuario = nombreUsuario;
            this.contraseña = contraseña;
        }
        
        public Usuario()
        {
            // Constructor por defecto
        }

        public static Usuario obtenerLogueado(Usuario usuario)
        {
            return usuario;
        }


    }
}
