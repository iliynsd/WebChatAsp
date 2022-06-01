using System.Collections.Generic;

namespace WebChat.Domain.Bots
{
    public interface IBotIoC
    {
        public T Get<T>();
        public IEnumerable<T> GetServices<T>();
    }
}
