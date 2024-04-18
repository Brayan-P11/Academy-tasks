namespace task_torneoMK_120424.Services
{
    public interface IService<T>
    {
        IEnumerable<T> PrendiliTutti(); // metodo che andra a prendere tutti gli oggetti di una classe REPO
    }
}
