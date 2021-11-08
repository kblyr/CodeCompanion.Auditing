namespace CodeCompanion.Auditing
{
    public interface ICurrentFootprintProvider
    {
        Footprint Current { get; }
    }
}