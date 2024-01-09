using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StockAndBuy.EF
{
    [Table("Node")]
    public class Node
    {
        [Key]
        public int ID { get; set; }
        [Required]
        [StringLength(25)]
        public string NAME { get; set; } 
        public int PARENTID { get; private set; }
        public Node(string name, int parentId)
        {
            this.NAME = name;
            this.PARENTID = parentId;
        }
    }
}
