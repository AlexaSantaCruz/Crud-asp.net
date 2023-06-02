namespace crudTortillas.Model
{
    public class cuponesDescuento
    {
        public int id { get; set; }
        public DateTime fechaCaducidad { get; set; }

        public float porcentaje { get; set; }

        public string codigo { get; set; }

    }
}
