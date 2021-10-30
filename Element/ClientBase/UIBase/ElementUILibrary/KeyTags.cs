﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Element.ClientBase.UIBase.ElementUILibrary
{
    public class KeyTags
    {
        public Dictionary<string, object> TagDictionary { get; set; }
        public KeyTags() => TagDictionary = new Dictionary<string, object>();
        public Element Add(string key, object value) => TagDictionary.Add(key, value);
        public object Get(string key) => TagDictionary[key];
    }
}
