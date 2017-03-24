using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Tools.qiming.Class;

namespace Tools.qiming
{
    public class qiming
    {
        private BasicInfo _info;
        private List<NameDetail> _result;
        private object obj = new object();
        public qiming(BasicInfo info)
        {
            this._info = info;
            _result = new List<NameDetail>();
        }
        private List<NameDetail> Result
        {
            get
            {
                if (_result == null)
                    return null;
                return _result.Where(x => x.msg == "success").OrderByDescending(x => x.data.scoreInfo.value).ToList();
            }
        }
        public const string Url = "https://sp0.baidu.com/5LMDcjW6BwF3otqbppnN2DJv/qiming.pae.baidu.com/data/namedetail?";
        const string paras = "fName={0}&lName={1}&year={2}&month={3}&day={4}&hour={5}&min={6}&timeType={7}&gender={8}&flag=1";
        public string BuildUrl(string fName, string lName, DateTime birth, TimeType timetype, Gender gender)
        {
            return Url + string.Format(paras, fName, lName, birth.Year, birth.Month, birth.Day, birth.Hour, birth.Minute, (int)timetype, (int)gender);
        }
        public List<string> GenerateNameList(string[] words,int wordNum,bool allowReduplication)
        {
            var namelist = new List<string>();
            switch (wordNum)
            {
                case 2:
                    foreach (var f in words)
                    {

                        var tmp = allowReduplication ? words : words.Where(x => x != f);
                        foreach (var l in tmp)
                        {
                            namelist.Add(f + l);
                        }
                    }
                    break;
                case 1:
                    foreach(var w in words)
                    {
                        namelist.Add(w);
                    }
                    break;
            }
                  
            return namelist;
        }

        public string GetJsonResult()
        {
            Launch();
            return JsonConvert.SerializeObject(Result);
        }
        public List<NameDetail> GetResult()
        {
            Launch();
            return Result;
        }
        public void Launch()
        {
            if (_info.Words.Length > 15)
                _info.Words = _info.Words.Take(15).ToArray();
            var namelist = GenerateNameList(_info.Words,_info.WordNum,_info.AllowReduplication);
            var tasks=namelist.Select(n => GetNameDetailAsync(n, _info.FirstName, _info.BirthDay, _info.IsLunar, _info.Gender));
            Task.WaitAll(tasks.ToArray());
            
        }
        async Task GetNameDetailAsync(string name,string firstName,DateTime birthDay,TimeType timetype,Gender gender)
        {
            //HttpClient http = new HttpClient();
            var n = BuildUrl(firstName, name,birthDay, timetype, gender);
            HttpClient http = new HttpClient();
            var res = await http.GetAsync(n);
            var str =await res.Content.ReadAsStringAsync();            
            //var str = HttpHelper.HttpGet(n, null);
            try
            {
                //Console.WriteLine(str);
                var result = JsonConvert.DeserializeObject<NameDetail>(str);
                lock (obj)
                {
                    _result.Add(result);
                }
            }
            catch (Exception e)
            {
                //Console.WriteLine(e.Message);
                Debug.WriteLine(e.Message);
            }
        }
    }
}
