using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
namespace StockAndBuy.EF.Repository
{
    public class NodeRepository : Repository<Node>, INodeRepository
    {
        private bool disposed = false;
        public NodeRepository(BundleContext bundleContext) : base(bundleContext)
        {
        }

        public int Save(Node aNode)
        {
            _bundleContext.Nodes.Add(aNode);
            _bundleContext.SaveChanges();
            Sleep();
            return aNode.ID;
        } 
        int INodeRepository.GetMaxBundles(int id)
        {
            var items = _bundleContext.Nodes
            .GroupBy(o => o.BUNDLEID)
            .Select(g => new { completeBundles = g.Key, bundleCount = g.Count() })
            .Where(g => g.bundleCount > id)
            .ToList();
            return items.Count();
        }

        public void FlushNodes()
        {
            DeleteAllAsync();
            Sleep();
        }
         

        private void Sleep()
        {
             System.Threading.Thread.Sleep(100);
        }

    }
}
