using System;


namespace R5T.F0056
{
    public static class Instances
    {
        public static Z0036.ICommitMessages CommitMessages => Z0036.CommitMessages.Instance;
        public static IFileSystemOperator FileSystemOperator => F0056.FileSystemOperator.Instance;
        public static F0041.IGitHubOperator GitHubOperator => F0041.GitHubOperator.Instance;
        public static F0019.IGitOperator GitOperator => F0019.GitOperator.Instance;
        public static ILicenseIdentifiers LicenseIdentifiers => F0056.LicenseIdentifiers.Instance;
        public static F0020.IProjectFileOperator ProjectFileOperator => F0020.ProjectFileOperator.Instance;
        public static F0051.IProjectOperator ProjectOperator => F0051.ProjectOperator.Instance;
        public static F0042.IRepositoryPathsOperator RepositoryPathsOperator => F0042.RepositoryPathsOperator.Instance;
        public static F0016.F001.IProjectReferencesOperator ProjectReferencesOperator => F0016.F001.ProjectReferencesOperator.Instance;
        public static ISolutionOperations SolutionOperations => F0056.SolutionOperations.Instance;
        public static F0024.ISolutionOperator SolutionOperator => F0024.SolutionOperator.Instance;
        public static IStrings Strings => F0056.Strings.Instance;
    }
}