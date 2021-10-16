using System.IO;

namespace ArtDesigner
{
    public interface IDesigner
    {
        public IPictureDraft CreateDraft( Stream stream );
    }
}
