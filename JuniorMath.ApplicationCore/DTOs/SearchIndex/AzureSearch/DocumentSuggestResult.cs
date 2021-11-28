using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace JuniorMath.ApplicationCore.DTOs.SearchIndex.AzureSearch
{
    public class DocumentSuggestResult<T>
    {
        [JsonProperty(PropertyName = "value")]
        public IList<SuggestResult<T>> Results { get; }
        [JsonProperty(PropertyName = "@search.coverage")]
        public double? Coverage { get; }
        public DocumentSuggestResult() { }
        public DocumentSuggestResult(IList<SuggestResult<T>> results = null, double? coverage = null) {
            Results = results;
            Coverage = coverage;
        }


    }
}
