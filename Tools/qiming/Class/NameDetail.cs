using System;
using System.Collections.Generic;
using System.Text;

namespace Tools.qiming.Class
{
    public class NameDetail
    {
        public string msg { get; set; }
        public int status { get; set; }
        public Data data { get; set; }
    }

    public class Data
    {
        public Sancaiinfo sancaiInfo { get; set; }
        public Jibeninfo jibenInfo { get; set; }
        public Baziinfo baziInfo { get; set; }
        public Wenhuainfo wenhuaInfo { get; set; }
        public Scoreinfo scoreInfo { get; set; }
    }

    public class Sancaiinfo
    {
        public string key { get; set; }
        public string url { get; set; }
        public Value[] value { get; set; }
        public string di { get; set; }
        public int sec { get; set; }
        public string txt_1 { get; set; }
        public string txt_2 { get; set; }
        public string base_desc { get; set; }
        public string your_desc { get; set; }
    }

    public class Value
    {
        public string key { get; set; }
        public string value { get; set; }
    }

    public class Jibeninfo
    {
        public string key { get; set; }
        public Value1[] value { get; set; }
        public string name { get; set; }
    }

    public class Value1
    {
        public string key { get; set; }
        public string value { get; set; }
    }

    public class Baziinfo
    {
        public string key { get; set; }
        public string url { get; set; }
        public Value2[] value { get; set; }
        public Source source { get; set; }
        public string di { get; set; }
        public int sec { get; set; }
        public string txt_1 { get; set; }
        public string txt_2 { get; set; }
        public string base_desc { get; set; }
        public string your_desc { get; set; }
    }

    public class Source
    {
        public string url { get; set; }
        public string title { get; set; }
        public string di { get; set; }
        public int sec { get; set; }
    }

    public class Value2
    {
        public string key { get; set; }
        public string value { get; set; }
    }

    public class Wenhuainfo
    {
        public string key { get; set; }
        public string url { get; set; }
        public Value3[] value { get; set; }
        public string di { get; set; }
        public int sec { get; set; }
        public string txt_1 { get; set; }
        public string txt_2 { get; set; }
        public string base_desc { get; set; }
        public string your_desc { get; set; }
    }

    public class Value3
    {
        public string key { get; set; }
        public object[] value { get; set; }
    }

    public class Scoreinfo
    {
        public string key { get; set; }
        public string value { get; set; }
        public string danwei { get; set; }
        public string pinyin { get; set; }
        public string wenan { get; set; }
        public string text { get; set; }
        public string link { get; set; }
    }

}
