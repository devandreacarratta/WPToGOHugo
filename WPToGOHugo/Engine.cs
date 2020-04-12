using System;
using System.Collections.Generic;
using System.Text;
using WPToGOHugo.WPEntity;

namespace WPToGOHugo
{
    public class Engine
    {
        private string _json = string.Empty;
        public Engine(string json)
        {
            _json = json;
        }

        public string Run()
        {
            var posts = Newtonsoft.Json.JsonConvert.DeserializeObject< PostCollection>(_json, JSONHelper.Converter.Settings);

               

            return string.Empty;
        }

        

    }
}
