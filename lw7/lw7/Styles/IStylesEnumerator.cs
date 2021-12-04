namespace lw7.Styles
{
    public interface IStylesEnumerator<T>
        where T : IStyle
    {
        public void Enumerate( Action<T> action );
    }
}
