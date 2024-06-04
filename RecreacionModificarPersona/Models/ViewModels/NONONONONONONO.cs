using Entidades;
using Microsoft.AspNetCore.Mvc;

namespace RecreacionModificarPersona.Models.ViewModels
{
    public class NONONONONONONO : clasePersona
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
        public NONONONONONONO(claseDepartamento departamento)
        {
            nombreDepartamento = departamento.Nombre;
        }

        /// <summary>
        /// constructor con parametros
        /// </summary>
        public NONONONONONONO(claseDepartamento departamento,Boolean seleccionar)
        {
            this.nombreDepartamento=departamento.Nombre;
            this.seleccionar = seleccionar;

        }



    }
}
