using AzureSearchIndex = JuniorMath.ApplicationCore.DTOs.SearchIndex.AzureSearch;
using JuniorMath.ApplicationCore.Enums;
using JuniorMath.ApplicationCore.Interfaces.Base;
using JuniorMath.ApplicationCore.Extensions;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Microsoft.Azure.Search.Models;
using Microsoft.Azure.Search;

namespace JuniorMath.Infrastructure.Services.ThirdParty.Search.AzureSearch
{
    public class AzureSearchService : IAzureSearchService
    {
        private static SearchServiceClient _searchClient;

        public static string errorMessage;

        static AzureSearchService()
        {
            try
            {
                string searchServiceName = "smyls-patient";
                string apiKey = "7EA6F8B6137FAA3A9D3BCFEA7833D720";

                _searchClient = new SearchServiceClient(searchServiceName, new SearchCredentials(apiKey));
            }
            catch (Exception e)
            {
                errorMessage = e.Message.ToString();
            }
        }

        private ISearchIndexClient GetIndexClient(IndexNameType indexNameType)
        {
            var indexName = indexNameType.GetDescription();
            var indexClient = _searchClient.Indexes.GetClient(indexName);
            return indexClient;
        }
        public IList<AzureSearchIndex.SuggestResult<AzureSearchIndex.Document>> Suggest(IndexNameType indexNameType, bool highlights, bool fuzzy, string searchText)
        {
            try
            {
                SuggestParameters sp = new SuggestParameters()
                {
                    UseFuzzyMatching = fuzzy,
                    Top = 5
                };

                if (highlights)
                {
                    sp.HighlightPreTag = "<b>";
                    sp.HighlightPostTag = "</b>";
                }

                var indexClient = GetIndexClient(indexNameType);

                var result = indexClient.Documents.Suggest(searchText, "sg", sp).Results.Select(p => new AzureSearchIndex.SuggestResult<AzureSearchIndex.Document> { 
                Document = new AzureSearchIndex.Document() { },
                Text = p.Text
                }).ToList();

                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error querying index: {0}\r\n", ex.Message.ToString());
            }
            return null;
        }
    }
}
