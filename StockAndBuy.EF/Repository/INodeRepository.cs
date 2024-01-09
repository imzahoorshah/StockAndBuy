using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StockAndBuy.EF.Repository
{
    public interface INodeRepository
    {
        int GetMaxBundles(int Id);
        int Save(Node aNode);
        void FlushNodes();
    }
}