using System;
using System.Collections.Generic;
using System.Text;

namespace StockAndBuy
{
    public class Node
    {
        public int Id { get; set; }
        public string Name { get; set; } 
        public int ParentId { get; private set; } 
        public Node(string name,int parentId)
        { 
            this.Name = name; 
            this.ParentId = parentId;
        }
         
    }
}
