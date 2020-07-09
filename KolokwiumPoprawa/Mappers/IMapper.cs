namespace KolokwiumPoprawa.Mappers
{
    public interface IMapper<in TIn, out TOut>
    {
        TOut Map(TIn data);
    }
}