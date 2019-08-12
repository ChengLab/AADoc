using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KetamaHash.Utils
{
    public class HashAlgorithmTest
    {
        static Random ran = new Random();

        /** key's count */
        private const int EXE_TIMES = 100000;

        private const int NODE_COUNT = 5;

        private const int VIRTUAL_NODE_COUNT = 4;

        public static void Test()
        {
            HashAlgorithmTest test = new HashAlgorithmTest();

            /** Records the times of locating node*/
            Dictionary<string, int> nodeRecord = new Dictionary<string, int>();

            List<string> allNodes = test.getNodes(NODE_COUNT);
            KetamaNodeLocator locator = new KetamaNodeLocator(allNodes, VIRTUAL_NODE_COUNT);

            List<String> allKeys = test.getAllStrings();
            foreach (string key in allKeys)
            {
                string node = locator.GetPrimary(key);
                if (!nodeRecord.ContainsKey(node))
                {
                    nodeRecord[node] = 1;
                }
                else
                {
                    nodeRecord[node] = nodeRecord[node] + 1;
                }
            }

            Console.WriteLine("Nodes count : " + NODE_COUNT + ", Keys count : " + EXE_TIMES + ", Normal percent : " + (float)100 / NODE_COUNT + "%");
            Console.WriteLine("-------------------- boundary  ----------------------");
            foreach (string key in nodeRecord.Keys)
            {
                Console.WriteLine("Node name :" + key + " - Times : " + nodeRecord[key] + " - Percent : " + (float)nodeRecord[key] / EXE_TIMES * 100 + "%");
            }
            Console.ReadLine();
        }



        public static void TestDb()
        {
            HashAlgorithmTest test = new HashAlgorithmTest();

            /** Records the times of locating node*/
            Dictionary<string, int> nodeRecord = new Dictionary<string, int>();

            List<string> allNodes = test.getNodes(NODE_COUNT);
            KetamaNodeLocator locator = new KetamaNodeLocator(allNodes, VIRTUAL_NODE_COUNT);

            List<string> allKeys =new List<string>{ "10","11","12","13","14"};
            foreach (string key in allKeys)
            {
                string node = locator.GetPrimary(key);
                Console.WriteLine("Node name :" + node+ " - key : " + key);
            }
            Console.ReadLine();
        }
        /**
         * Gets the mock node by the material parameter
         * 
         * @param nodeCount 
         * 		the count of node wanted
         * @return
         * 		the node list
         */
        private List<string> getNodes(int nodeCount)
        {
            List<string> nodes = new List<string>();

            //for (int k = 1; k <= nodeCount; k++)
            //{
            //    string node = "node" + k;
            //    nodes.Add(node);
            //}

            //在应用时，这里会添入memcached server的IP端口地址
            nodes.Add("192.168.4.101");
            nodes.Add("192.168.4.102");
            //nodes.Add("192.168.4.103");
            //nodes.Add("192.168.4.104");
            //nodes.Add("10.0.4.114:11214");
            //nodes.Add("10.0.4.114:11215");
            return nodes;
        }

        /**
         *	All the keys	
         */
        private List<String> getAllStrings()
        {
            //List<string> allStrings = new List<string>(EXE_TIMES);

            //for (int i = 0; i < EXE_TIMES; i++)
            //{
            //    allStrings.Add(generateRandomString(ran.Next(50)));
            //}
            List<string> allStrings = new List<string>(6);

            for (int i = 0; i < 6; i++)
            {
                allStrings.Add(i+1.ToString());
            }

            return allStrings;
        }

        /**
         * To generate the random string by the random algorithm
         * <br>
         * The char between 32 and 127 is normal char
         * 
         * @param length
         * @return
         */
        private String generateRandomString(int length)
        {
            StringBuilder sb = new StringBuilder(length);

            for (int i = 0; i < length; i++)
            {
                sb.Append((char)(ran.Next(95) + 32));
            }

            return sb.ToString();
        }
    }
}
