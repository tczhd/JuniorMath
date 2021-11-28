using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace JuniorMath.ApplicationCore.DTOs.SearchIndex.AzureSearch
{
    public class SuggestResult<T>
    {
        public T Document { get; set; }
        [JsonProperty(PropertyName = "@search.text")]
        public string Text { get; set; }

        public SuggestResult() { }
        public SuggestResult(T document, string text = null) {
            Document = document;
            Text = text;
        }


    }
}
