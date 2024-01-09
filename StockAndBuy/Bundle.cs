using System;
using System.Collections.Generic;
using System.Text;

namespace StockAndBuy
{
    public class Bundle
    {
        public string Name { get; set; }
        public int RequiredUnits { get; set; }
        public int TotalUnits { get; set; } 
        public List<Bundle> Children { get; set; }
        public bool IsLeaf()
        {
            return this.Children == null || this.Children.Count == 0;
        } 
    } 
}
