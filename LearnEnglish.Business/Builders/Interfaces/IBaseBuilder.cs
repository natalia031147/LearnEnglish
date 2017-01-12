namespace LearnEnglish.Business.Builders.Interfaces
{
    public interface IBaseBuilder<in TFrom, out TTo>
    {
        TTo Build(TFrom obj);
    }
}