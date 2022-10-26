using System;

using R5T.F0002;
using R5T.F0020;
using R5T.F0024;
using R5T.F0041;
using R5T.F0042;


namespace R5T.F0056
{
    public static class Instances
    {
        public static ICommitMessages CommitMessages { get; } = F0042.CommitMessages.Instance;
        public static IFileSystemOperator FileSystemOperator { get; } = F0056.FileSystemOperator.Instance;
        public static IGitHubOperator GitHubOperator { get; } = F0041.GitHubOperator.Instance;
        public static F0019.IGitOperator GitOperator { get; } = F0019.GitOperator.Instance;
        public static ILicenseIdentifiers LicenseIdentifiers { get; } = F0056.LicenseIdentifiers.Instance;
        public static IProjectFileOperator ProjectFileOperator { get; } = F0020.ProjectFileOperator.Instance;
        public static F0051.IProjectOperator ProjectOperator { get; } = F0051.ProjectOperator.Instance;
        public static IRepositoryPathsOperator RepositoryPathsOperator { get; } = F0042.RepositoryPathsOperator.Instance;
        public static ISolutionOperations SolutionOperations { get; } = F0056.SolutionOperations.Instance;
        public static ISolutionOperator SolutionOperator { get; } = F0024.SolutionOperator.Instance;
        public static IStrings Strings { get; } = F0056.Strings.Instance;
    }
}