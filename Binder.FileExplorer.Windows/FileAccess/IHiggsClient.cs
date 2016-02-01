using System.IO;

namespace Binder.Client.StorageEngine
{
    public interface IHiggsClient
    {
        void PostStream(string piecehash, Stream data);
        Stream GetStream(string piecehash);
    }
}