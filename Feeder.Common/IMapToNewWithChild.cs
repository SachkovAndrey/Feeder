namespace Feeder.Common
{
    public interface IMapToNewWithChild<in TSource, in TChildSource, out TTarget>
    {
        #region Methods

        TTarget Map(TSource source, TChildSource childSource);

        #endregion
    }
}
