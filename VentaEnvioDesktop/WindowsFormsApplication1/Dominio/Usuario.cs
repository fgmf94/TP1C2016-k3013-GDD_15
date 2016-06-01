using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MercadoEnvio.Dominio
{
    public class Usuario
    {
        string username;
        string password;
        string rol;
        
        string mail;
        string telefono;
        string calle;
        int numeroCalle;
        string piso;
        string depto;
        string codigoPostal;
        
        string cliNombre;
        string cliApellido;
        string cliTipoDocumento;
        string cliNumeroDocumento;
        string cliFechaNac;
 
        string empRazonSocial;
        string empCiudad;
        string empCuit;
        string empNombreContacto;
        string empRubroPrincipal;
        string empFechaCreacion;

        public Usuario(String nombre, String pass, String rols)
        {
            username = nombre;
            password = pass;
            rol = rols;
        }

    }
}
