using System;
using ArtDesigner.Canvas;
using ArtDesigner.Primitives;
using System.Collections.Generic;

namespace ArtDesignerTests.TestObjects
{
    public class HistoryStoringCanvas : ICanvas
    {
        private List<string> _history;

        public List<string> History
        {
            get => _history ??= new();
            set => _history = value;
        }

        public void DrawEllipse( Point center, int width, int height )
        {
            History.Add( $"DrawEllipse Center:{center}, Width:{width}, Height:{height}" );
        }

        public void DrawLine( Point from, Point to )
        {
            History.Add( $"DrawLine {from}->{to}" );
        }

        public void SetPenColor( Color penColor )
        {
            History.Add( $"SetPenColor {penColor}" );
        }
    }
}
