using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using StockAndBuy.EF;
using StockAndBuy.EF.Repository;
using System;
using System.Collections.Generic;

namespace StockAndBuy
{
    class Program
    {
        static bool leafCount = false;
        static BundleContext context = null;
        static void Main(string[] args)
        {

            //Console.Write("Enter input in JSON format:");
            // string input = Console.ReadLine();   
            // Bundle newBundle = JsonConvert.DeserializeObject<Bundle>(input);
            // Bundle newBundle= JsonConvert.DeserializeObject<Bundle>("{\"Children\": [{\"Children\": [],\"Name\": \"Seat\",\"RequiredUnits\": 1,\"TotalUnits\": 50},{\"Children\": [],\"Name\": \"Pedals\",\"RequiredUnits\": 2,\"TotalUnits\": 60},{\"Children\": [{\"Children\": [],\"Name\": \"Frame\",\"RequiredUnits\": 2,\"TotalUnits\": 60},{\"Children\": [],\"Name\": \"Tube\",\"RequiredUnits\": 2,\"TotalUnits\": 35}],\"Name\": \"Wheels\",\"RequiredUnits\": 2,\"TotalUnits\": 0}],\"Name\": \"Bike\",\"RequiredUnits\": 0,\"TotalUnits\": 0}");
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
                        new Bundle {Name = "Frame" ,RequiredUnits=2, TotalUnits=60},
                        new Bundle {Name = "Tube" ,RequiredUnits=2, TotalUnits=35}
                    }
                    }
                }
            };

            //Create DBContext instance
            if (context == null)
                context = new BundleContext();

            //Flush DB
            FlushNodes();

            Random rand = new Random();
            while (!leafCount)
            {
                //Add the Root Node
                int bundleId = rand.Next(1000, 5000);
                EF.Node aNode = new EF.Node(aBundle.Name, null, bundleId);
                int parentId = AddNodeToDB(aNode);
                BuildInventory(aBundle, parentId, bundleId);
            }

            //Find the depth of the bundle--- track upto leaf nodes
            int bundleDepth = aBundle.DepthOfBundle(aBundle, 0);
            //Get the maximum number od bundles that can be create from the given input.
            int maxBundles = GetMaxBundles(bundleDepth);
             
            Console.WriteLine("The maximum bundles that can be created are: {0}",maxBundles); 

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
            //            new Bundle {Name = "Frame" ,RequiredUnits=2, TotalUnits=60},
            //            new Bundle {Name = "Tube" ,RequiredUnits=2, TotalUnits=35}
            //        }
            //        }
            //    }
            //}, Formatting.Indented));
            Console.ReadKey();

        }


        /// <summary>
        /// Build the inventory from the input JSON
        /// </summary>
        /// <param name="aBundle"></param>
        /// <param name="parentId"></param>
        /// <param name="bundleId"></param>
        private static void BuildInventory(Bundle aBundle, int parentId, int bundleId)
        {
            if (aBundle != null && aBundle.Children.Count > 0)
            {
                foreach (Bundle child in aBundle.Children)
                {
                    if (child.IsLeaf())
                    {
                        if (child.TotalUnits > child.RequiredUnits)
                        {
                            EF.Node aNode = new EF.Node(child.Name, parentId, bundleId);
                            int id = AddNodeToDB(aNode);
                            child.TotalUnits -= child.RequiredUnits;
                        }
                        else
                        {
                            leafCount = true;
                        }
                    }
                    else
                    {
                        EF.Node aNode = new EF.Node(child.Name, parentId, bundleId);
                        int id = AddNodeToDB(aNode);
                        BuildInventory(child, id, bundleId);
                    }
                }

            }
        }

        /// <summary>
        /// Add Bundle Node to the database
        /// </summary>
        /// <param name="aNode"></param>
        /// <returns></returns>
        private static int AddNodeToDB(EF.Node aNode)
        {
            INodeRepository nodeRepo = new NodeRepository(context);
            return nodeRepo.Save(aNode);

        }

        /// <summary>
        /// Get Maximum number of bundles that can be created
        /// </summary>
        /// <param name="bundleDepth"></param>
        /// <returns></returns>
        private static int GetMaxBundles(int bundleDepth)
        {
            INodeRepository nodeRepo = new NodeRepository(context);
            return nodeRepo.GetMaxBundles(bundleDepth);
        }


        /// <summary>
        /// FlushNodes
        /// </summary>
        private static void FlushNodes()
        {
            INodeRepository nodeRepo = new NodeRepository(context);
            nodeRepo.FlushNodes(); 
        }

    }
}
