using System;
using System.Collections.Generic;
using TextEditor.DocumentItems;
using TextEditor.Extensions;

namespace TextEditor.Commands
{
    public class InsertItemCommand : AbstractCommand
    {
        private List<IDocumentItem> _items;
        private IDocumentItem _documentItem;
        private int? _index;

        public InsertItemCommand( List<IDocumentItem> items, IDocumentItem documentItem, int? index = null )
            : base()
        {
            if ( items is null )
            {
                throw new ArgumentNullException( nameof( items ) );
            }

            if ( documentItem is null )
            {
                throw new ArgumentNullException( nameof( documentItem ) );
            }

            _items = items;
            _documentItem = documentItem;
             _index = index;
        }

        protected override void DoInvoke()
        {
            base.DoInvoke();
            if ( _index.HasValue )
            {
                _items.Insert( _index.Value, _documentItem );
            }
            else
            {
                _items.Add( _documentItem );
            }
        }

        protected override void DoUndo()
        {
            base.DoUndo();
            if ( _index.HasValue )
            {
                _items.RemoveAt( _index.Value );
            }
            else
            {
                _items.RemoveAt( _items.Count - 1 );
            }

            _items.Resize( _items.Count );
        }
    }
}
