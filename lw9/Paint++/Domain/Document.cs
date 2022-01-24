namespace Domain;

public class Document
{
    private Canvas _canvas;

    public Canvas Canvas => _canvas;

    public Document( Canvas canvas )
    {
        _canvas = canvas ?? throw new ArgumentNullException( nameof( canvas ) );
    }
}
