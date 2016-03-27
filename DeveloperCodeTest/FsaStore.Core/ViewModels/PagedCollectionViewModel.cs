using System.Collections.Generic;

namespace FsaStore.Core.ViewModels
{
    public class PagedCollectionViewModel<T>
    {
        public IEnumerable<T> Data { get; set; }

        public int TotalCount { get; set; }
    }
}