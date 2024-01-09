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
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; } 
        public string NAME { get; set; } 
        public int? PARENTID { get; private set; }
        [Required]
        public int BUNDLEID { get; private set; }
        public Node(string NAME, int? PARENTID, int BUNDLEID)
        {
            this.NAME = NAME;
            this.PARENTID = PARENTID;
            this.BUNDLEID = BUNDLEID;
        }
    }
}
