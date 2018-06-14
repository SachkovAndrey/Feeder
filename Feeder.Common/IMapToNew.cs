namespace Feeder.Common
{
    public interface IMapToNew<in TSource, out TTarget>
    {
        #region Methods

        TTarget Map(TSource source);

        #endregion
    }
}
