using System.IO;

namespace Binder.Client.StorageEngine
{
    public interface ILocalPieceCache
    {
        bool ContainsPiece(string pieceHash);
        void PutPieceInCache(string pieceHash, Stream data);
        Stream GetPieceFromCache(string pieceHash);
    }
}
