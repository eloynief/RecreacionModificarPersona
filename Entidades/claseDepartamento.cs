namespace Entidades
{
    public class claseDepartamento
    {
        private int id;
        private string nombre;

        // Propiedades
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        #region constructores

        // Constructor vacío
        public claseDepartamento() { }

        // Constructor con parámetros
        public claseDepartamento(int id, string nombre)
        {
            this.id = id;
            this.nombre = nombre;
        }

        #endregion

    }


}