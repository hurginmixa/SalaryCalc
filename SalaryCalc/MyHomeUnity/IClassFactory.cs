namespace MyHomeUnity
{
    public interface IClassFactory
    {
        T GetInstance<T>() where T : class;
    }
}