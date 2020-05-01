namespace CTeleportTest.Repositories
{
    public interface IGenericRepository<T> where T : class
    {
        T DownloadSerializedJsonData<T>(string url) where T : new();
    }
}
