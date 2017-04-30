﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trinity;
using TriSQL;

namespace TriSQLApp
{
    //以下全是测试代码
    internal class Program
    {
        static void Main1(string[] args)
        {
            List<int> a = new List<int> { 43, 23, 80, 15, 789, 27, 90, 69, 66, 158, 45, 32, 1, 22, 77, 66, 44 };
            List<List<Element>> b = new List<List<Element>>();
            int c = 0;
            foreach (int aa in a)
            {
                Element e = new Element(intField: aa);
                List<Element> ee = new List<Element>();
                ee.Add(e);
                b.Add(ee);
            }
            foreach (var oo in b)
            {
                foreach (var pp in oo)
                {
                    Console.Write(pp.intField+" ");
                }
            }
            Console.WriteLine();
            //Table.QuickSort(b, 0, b.Count - 1,);
            foreach(var oo in b)
            {
                foreach(var pp in oo)
                {
                    Console.Write(pp.intField+" ");
                }
            }
            Console.WriteLine();
            Console.ReadLine();
        }

        static void Main(string[] args)
        {
            //TrinityConfig.AddServer(new Trinity.Network.ServerInfo("192.168.1.112", 5304, Global.MyAssemblyPath, Trinity.Diagnostics.LogLevel.Error));
            //TrinityConfig.AddServer(new Trinity.Network.ServerInfo("192.168.1.102", 5304, Global.MyAssemblyPath, Trinity.Diagnostics.LogLevel.Error));
            //TrinityConfig.AddServer(new Trinity.Network.ServerInfo("127.0.0.1", 5305, Global.MyAssemblyPath, Trinity.Diagnostics.LogLevel.Error));
            //TrinityConfig.AddServer(new Trinity.Network.ServerInfo("127.0.0.1", 5306, Global.MyAssemblyPath, Trinity.Diagnostics.LogLevel.Error));
            //TrinityConfig.AddServer(new Trinity.Network.ServerInfo("127.0.0.1", 5307, Global.MyAssemblyPath, Trinity.Diagnostics.LogLevel.Error));
            if (args.Length > 0 && args[0].Equals("-s"))
            //{
            {
                TrinityConfig.CurrentRunningMode = RunningMode.Server;
                DatabaseServer ds = new DatabaseServer();
                ds.Start();
            }
            else if (args.Length >0 && args[0].Equals("-p"))
            {
                TrinityConfig.CurrentRunningMode = RunningMode.Proxy;
                DatabaseProxy dp = new DatabaseProxy();
                dp.Start();
            }
            //}
            else
            {
                TrinityConfig.CurrentRunningMode = RunningMode.Client;
                Global.CloudStorage.LoadStorage();
                Console.WriteLine("读取完毕");
                Database.createDatabase("test");
                Database database = new Database("test");
                //    /*
                Table tableA = database.createTable("tableA", new string[] { "class" },
                                new Tuple<int, string, object>(FieldType.INTEGER, "class", 2),
                                new Tuple<int, string, object>(FieldType.STRING, "name", "hhh"),
                               new Tuple<int, string, object>(FieldType.INTEGER, "age", 1));

                Table tableB = database.createTable("tableB", new string[] { "cnumber" },
                                new Tuple<int, string, object>(FieldType.INTEGER, "cnumber", 1),
                                new Tuple<int, string, object>(FieldType.STRING, "score", "hhh"));
                Table tableC = database.createTable("tableC", null,
                    new Tuple<int, string, object>(FieldType.INTEGER, "id", 0),
                    new Tuple<int, string, object>(FieldType.LONG, "long", 1));

                //Table tableA = new Table("tableC");
                //Table tableB = new Table("tableB");
                //Table tableC = new Table("tableC");

                tableA.insert(new string[] { "class", "name", "age" }, new Object[] { 1, "111", 1 });
                tableA.insert(new string[] { "class", "name", "age" }, new Object[] { 2, "222", 2 });
                tableA.insert(new string[] { "class", "name", "age" }, new Object[] { 3, "333", 3 });
                tableA.insert(new string[] { "class", "name", "age" }, new Object[] { 4, "444", 4 });
                tableA.insert(new string[] { "class", "name", "age" }, new Object[] { 5, "555", 5 });
                tableA.insert(new string[] { "class", "name", "age" }, new Object[] { 6, "666", 6 });
                tableB.insert(new string[] { "cnumber", "score" }, new Object[] { 1, "c111" });
                tableB.insert(new string[] { "cnumber", "score" }, new Object[] { 2, "c222" });
                tableB.insert(new string[] { "cnumber", "score" }, new Object[] { 3, "c333" });
                tableB.insert(new string[] { "cnumber", "score" }, new Object[] { 4, "c444" });
                tableB.insert(new string[] { "cnumber", "score" }, new Object[] { 5, "c555" });
                tableC.insert(new string[] { "id", "long" }, new Object[] { 123, 123 });
                tableC.insert(new string[] { "id", "long" }, new Object[] { 234, 234 });
                tableC.insert(new string[] { "id", "long" }, new Object[] { 345, 345 });
                tableC.insert(new string[] { "id", "long" }, new Object[] { 456, 456 });
                tableC.insert(new string[] { "id", "long" }, new Object[] { 567, 567 });

                //tableA.print();
                //tableB.print();
                //tableC.print();
                //Table tableABC = new Table("tableA", "tableC", "tableB");
                //tableABC.print();
                Table tA = tableA.select(new Tuple<string, string>[] {
                    new Tuple<string, string>("*", "*") }, "a");
                Global.CloudStorage.SaveStorage();
                tA.print();
                //Global.CloudStorage.SaveStorage();
            }

            }
    }
}