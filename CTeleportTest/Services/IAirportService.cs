namespace CTeleportTest.Services
{
    public interface IAirportService
    {
        double GetByIATA(string sourceIATA, string targetIATA);
    }
}
