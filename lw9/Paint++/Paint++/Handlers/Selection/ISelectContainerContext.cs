namespace Paint__.Handlers;

public interface ISelectableItemContainerContext
{
    public object GetSelected();
    public void SelectObject( object obj );
    public void RemoveSelection();
}