namespace CICD.Infrastructure.Enums
{
    public enum SubjectType
    {
        /// <summary>
        /// User
        /// </summary>
        User = 0,

        /// <summary>
        /// Application
        /// </summary>
        Application,

        /// <summary>
        /// Device
        /// </summary>
        Device
    }

    public enum NodeType
    {
        /// <summary>
        /// UI
        /// </summary>
        UI = 0,

        /// <summary>
        /// API
        /// </summary>
        API = 0,

        /// <summary>
        /// DB
        /// </summary>
        DB
    }

    public enum ArtifactType
    {
        /// <summary>
        /// Code
        /// </summary>
        Code = 0,

        /// <summary>
        /// Configuration
        /// </summary>
        Configuration,

        /// <summary>
        /// Tests
        /// </summary>
        Tests
    }
}