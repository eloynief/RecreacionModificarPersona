using DAL;
using Entidades;

namespace Modelos
{
    public class clasePersonaConNombreDep : clasePersona
    {

        String nombreDepartamento;
        Boolean seleccionar;


        #region propiedades

        public String NombreDepartamento
        {
            get{ return nombreDepartamento; }
        }
        public Boolean Seleccionar
        {
            get { return seleccionar; }
            set { seleccionar = value;}
        }

        #endregion




        /// <summary>
        /// constructor vacio
        /// </summary>

        /// <summary>
        /// constructor con la herencia de persona
        /// </summary>
        public clasePersonaConNombreDep(clasePersona p) : base(p.Id,p.Nombre,p.Apellidos,p.Telefono,p.Direccion,p.Foto,p.FechaNacimiento,p.IdDepartamento)
        {
            nombreDepartamento = ClaseListados.obtenerNombreDepPorId(IdDepartamento);
        }

        /// <summary>
        /// constructor con parametros
        /// </summary>
        public clasePersonaConNombreDep(claseDepartamento departamento,Boolean seleccionar)
        {
            this.nombreDepartamento=departamento.Nombre;
            this.seleccionar = seleccionar;

        }



    }
}
