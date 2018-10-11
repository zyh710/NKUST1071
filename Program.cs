using System;
using OpenDataImport.Models;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace OpenDataImport
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");
            var nodes = FindOpenData();
            ShowOpenData(nodes);
            Console.ReadKey();
        }

        static List<OpenData> FindOpenData()
        {
            List<OpenData> result = new List<OpenData>();
            var xml = XElement.Load(@"C:\Users\彭冠勛\Desktop\臺中市托育(保母)人員專業訓練課程(126小時自費班).xml");
            var nodes = xml.Descendants("RECORD").ToList();

            for (var i = 0; i < nodes.Count; i++)
            {
                var node = nodes[i];
                OpenData item = new OpenData();

                item.班別名稱 = getValue(node, "班別名稱");
                item.辦理區域 = getValue(node, "辦理區域");
                item.上課地點學科 = getValue(node, "上課地點學科");
                item.訓練起日 = getValue(node, "訓練起日");
                item.訓練迄日 = getValue(node, "訓練迄日");
                result.Add(item);
            }
            return result;
        }
        public static string getValue(XElement node, string propertyName)
        {
            return node.Element(propertyName)?.Value?.Trim();
        }

        public static void ShowOpenData(List<OpenData> nodes)
        {
            Console.WriteLine(string.Format("共收到[0]筆的資料", nodes.Count));
            nodes.GroupBy(node => node.辦理區域).ToList()
                .ForEach(group =>
                {
                    var key = group.Key;
                    var groupDatas = group.ToList();
                    var message = $"辦理區域:{key},共有{groupDatas.Count()}筆資料";
                    Console.WriteLine(message);
                });
        }
    }
}