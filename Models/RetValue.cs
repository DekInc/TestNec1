namespace Models
{
    /// <summary>
    /// Clase para retornar valores al frontend o retornar un error
    /// </summary>
    /// <typeparam name="retType"></typeparam>
    public class RetValue<retType>
    {
        public retType? Value { get; set; }
        public string ErrorMessage { get; set; } = "";
    }
}