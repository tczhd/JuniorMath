using JuniorMath.ApplicationCore.DTOs.SearchIndex.AzureSearch;
using JuniorMath.ApplicationCore.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace JuniorMath.ApplicationCore.Interfaces.Base
{
    public interface IAzureSearchService
    {
        //public DocumentSearchResult<Document> Search(IndexNameType indexNameType, string searchText, string businessTitleFacet, string postingTypeFacet, string salaryRangeFacet,
        // string sortType, double lat, double lon, int currentPage, int maxDistance, string maxDistanceLat, string maxDistanceLon);

        //public DocumentSearchResult<Document> SearchZip(string zipCode)
        //{
        //    // Execute search based on query string
        //    try
        //    {
        //        SearchParameters sp = new SearchParameters()
        //        {
        //            SearchMode = SearchMode.All,
        //            Top = 1,
        //        };
        //        return _indexZipClient.Documents.Search(zipCode, sp);
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine("Error querying index: {0}\r\n", ex.Message.ToString());
        //    }
        //    return null;
        //}
        //public AutocompleteResult AutoComplete(IndexNameType indexNameType, string term);

      //  IList<SuggestResult<Document>> Suggest(IndexNameType indexNameType, bool highlights, bool fuzzy, string searchText);

        //public Document LookUp(IndexNameType indexNameType, string id);
    }
}
