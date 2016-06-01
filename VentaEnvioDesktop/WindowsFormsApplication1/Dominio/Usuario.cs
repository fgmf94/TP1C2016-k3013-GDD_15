using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MercadoEnvio.Dominio
{
    public class Usuario
    {
        public string username;
        public string password;
        public string rol;

        public string mail;
        public Int64 telefono;
        public string calle;
        public int numeroCalle;
        public string piso;
        public string depto;
        public string codigoPostal;

        public string cliNombre;
        public string cliApellido;
        public string cliTipoDocumento;
        public string cliNumeroDocumento;
        public string cliFechaNac;

        public string empRazonSocial;
        public string empCiudad;
        public string empCuit;
        public string empNombreContacto;
        public string empRubroPrincipal;
        public string empFechaCreacion;

        public Usuario(String nombre, String pass, String rols)
        {
            this.username = nombre;
            this.password = pass;
            this.rol = rols;
        }

    }
}
