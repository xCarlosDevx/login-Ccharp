using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Datos;
using System.Data;

    //Referencias e importar capa datos e indentidad
namespace Negocios { 
public class N_Usuario
    {
        private D_Usuario userData = new D_Usuario(); 
        public int createUser(string nombre, string apellido, string nombreUsuario, string contraseña) {
            return userData.insertUser(nombre, apellido, nombreUsuario, contraseña);
        }
        public int loginUser(string nombreUsuario, string contraseña)
        {
            return userData.selectUser(nombreUsuario, contraseña);
        }
    }
} 