using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace GitHubTrendings.Models
{
    [DataContract]
    public class RootGitHub
    {
        public int total_count { get; set; }
        public bool incomplete_results { get; set; }
        [DataMember]
        public List<ItemGitHub> items { get; set; }

        //public RootGitHub(int totalcount, bool incompleteresult, List<ItemGitHub> item)
        //{
        //    total_count = totalcount;
        //    incomplete_results = incompleteresult;
        //    items = item;
        //}
    }
}