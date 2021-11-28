namespace lw7.Styles
{
    public interface IStylesContainer<T>
        where T : IStyle
    {
        public IReadOnlyList<T> Get();
    }
}
