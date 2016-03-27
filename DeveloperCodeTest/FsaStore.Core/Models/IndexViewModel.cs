namespace FsaStore.Core.Models
{
    /// <summary>
    /// The model for Home Index
    /// </summary>
    public class IndexViewModel
    {
        public bool IsAuthenticated { get; set; }

        public string UserName { get; set; }

        public string WelcomeMessage { get; set; }
    }
}