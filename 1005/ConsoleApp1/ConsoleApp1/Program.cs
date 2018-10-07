using System;
using ConsoleApp1.Model;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace Model
{
    class Program
    {
        static void Main(string[] args)
        {
            var nodes = findOpenData();
            showOpenData(nodes);
            Console.ReadKey();
        }

        static List<OpenData> findOpenData()
        {
            List<OpenData> result = new List<OpenData>();

            var xml = XElement.Load(@"taipeiFactory.xml");
            var nodes = xml.Descendants("FCDBDATA").ToList();

            for (var i = 0; i < nodes.Count; i++)
            {
                var node = nodes[i];
                OpenData item = new OpenData();

                item.REGI_ID = getValue(node, "REGI_ID");
                item.FACT_NAME = getValue(node, "FACT_NAME");
                item.FACT_ADDR = getValue(node, "FACT_ADDR");
                item.BNAME = getValue(node, "BNAME");
                item.ADDR_X = getValue(node, "ADDR_X");
                item.ADDR_Y = getValue(node, "ADDR_Y");

                result.Add(item);

            }
            return result;
        }

        private static string getValue(XElement node, string header)
        {
            return node.Element(header).Value;
        }

        public static void showOpenData(List<OpenData> nodes)
        {
            Console.WriteLine(string.Format("登記在台北市的工廠，總共有{0}家", nodes.Count));
            nodes.GroupBy(node => node.REGI_ID).ToList()
                .ForEach(group =>
                {
                    var key = group.Key;
                    var allDatas = group.ToList();
                    var message = $"\n擁有此註冊序號:{key}的工廠數量為：{allDatas.Count()}";
                    Console.WriteLine(message);
                });


        }
    }
}