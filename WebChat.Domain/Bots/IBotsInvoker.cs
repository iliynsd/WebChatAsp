using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebChat.Domain.Bots
{
    public interface IBotsInvoker<T1, T2>
    {
        public Task Invoke(IEnumerable<T1> bots, T2 param);
    }
}