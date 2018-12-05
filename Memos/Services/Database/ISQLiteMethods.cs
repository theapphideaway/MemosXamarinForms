using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Memos.Models;

namespace Memos.Services.Database
{
    public interface ISQLiteMethods
    {
        Task<IEnumerable<Memo>> GetMemoAsync();
        Task<Memo> GetMemo(int id);
        Task AddMemo(Memo memo);
        Task UpdateMemo(Memo memo);
        Task DeleteMemo(Memo memo);
    }
}
