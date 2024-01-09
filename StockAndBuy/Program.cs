using Newtonsoft.Json;
using StockAndBuy.EF;
using System;
using System.Collections.Generic;

namespace StockAndBuy
{
    class Program
    {
        static bool leafCount = true;
        static int NodeCount = 0;
        static int BundleCount = 0;
        static BundleContext context = null;
        static void Main(string[] args)
        {

            Bundle aBundle = new Bundle
            {
                Name = "Bike",
                Children = new List<Bundle>
                {
                    new Bundle {Name = "Seat", RequiredUnits=1, TotalUnits=50},
                    new Bundle {Name = "Pedals" ,RequiredUnits=2, TotalUnits=60},
                    new Bundle {Name = "Wheels" ,RequiredUnits=2,
                    Children = new List<Bundle>
                    {
                        new Bundle {Name = "Frame" ,RequiredUnits=1, TotalUnits=60},
                        new Bundle {Name = "Tube" ,RequiredUnits=1, TotalUnits=35}
                    }
                    }
                }
            };
            //Add the Root Node
            while (leafCount)
            {
                BuildInventory(aBundle, 1);
            }

            //Console.WriteLine(JsonConvert.SerializeObject(new Bundle
            //{
            //    Name = "Bike",
            //    Children = new List<Bundle>
            //    {
            //        new Bundle {Name = "Seat", RequiredUnits=1, TotalUnits=50},
            //        new Bundle {Name = "Pedals" ,RequiredUnits=2, TotalUnits=60},
            //        new Bundle {Name = "Wheels" ,RequiredUnits=2,
            //        Children = new List<Bundle>
            //        {
            //            new Bundle {Name = "Frame" ,RequiredUnits=1, TotalUnits=60},
            //            new Bundle {Name = "Tube" ,RequiredUnits=1, TotalUnits=35}
            //        }
            //        }
            //    }
            //}, Formatting.Indented));

            Console.ReadKey();


            //Node<Int32> root = new Node<int>(1);
            //root = Generate(root);
            //List<Int32> order = root.LevelOrder();
            //foreach (int num in order)
            //    Console.Write(num + " "); 
        }

        private static void BuildInventory(Bundle aBundle, int parentId)
        {
            if (aBundle != null && aBundle.Children.Count > 0)
            {
                BundleCount++;
                foreach (Bundle child in aBundle.Children)
                {
                    if (child.IsLeaf())
                    {
                        if (child.TotalUnits > child.RequiredUnits)
                        {
                            EF.Node aNode = new EF.Node(child.Name, 1);
                            AddNodeToDB(aNode);
                            child.TotalUnits -= child.RequiredUnits;
                        }
                        else
                        {
                            leafCount = false;
                        }
                    }
                    else
                    {
                        EF.Node aNode = new EF.Node(child.Name, 1);
                        AddNodeToDB(aNode);
                        BuildInventory(child, parentId);
                    }
                    // Console.WriteLine(JsonConvert.SerializeObject(child, Formatting.Indented));
                }

            }
        }

        private static void AddNodeToDB(EF.Node aNode)
        {
            if (context == null)
                context = new BundleContext();
            context.Nodes.Add(aNode);
            context.SaveChanges();
        }

        static Node2<int> Generate(Node2<int> root)
        {
            Random rand = new Random();
            root.AddAllChildren(Make(rand.Next(0, 5)));
            for (int i = 0; i < root.children.Count; i++)
                root.children[i] = Generate(root.children[i]);
            return root;
        }
        static List<Node2<int>> Make(int children)
        {
            List<Node2<int>> list = new List<Node2<int>>();
            if (NodeCount > 100)
                return list;
            for (int i = 1; i <= children; i++)
            {
                NodeCount++;
                list.Add(new Node2<int>(NodeCount));
            }
            return list;
        }
    }
}
