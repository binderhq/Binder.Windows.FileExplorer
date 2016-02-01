using System.Net;

namespace Binder.Client.StorageEngine.RequestClasses
{
    interface IHiggsRequest
    {
        WebRequest GetRequest();
    }
}
