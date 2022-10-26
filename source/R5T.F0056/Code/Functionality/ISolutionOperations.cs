using System;
using System.Collections.Generic;
using System.Linq;

using R5T.T0132;


namespace R5T.F0056
{
	[FunctionalityMarker]
	public partial interface ISolutionOperations : IFunctionalityMarker
	{
        /// <summary>
        /// Finds solution files in the project's directory or parent directories, that are then tested for whether they contain the project file.
        /// </summary>
        public string[] GetSolutionFilePathsContainingProject(string projectFilePath)
        {
            var solutionFilePaths = Instances.FileSystemOperator.FindSolutionFilesInDirectoryOfFileOrParentDirectories(
                projectFilePath);

            var output = this.GetSolutionFilePathsContainingProject(
                solutionFilePaths,
                projectFilePath);

            return output;
        }

        public string[] GetSolutionFilePathsContainingProject(
             IEnumerable<string> solutionFilePaths,
             string projectFilePath)
        {
            var output = Instances.SolutionOperator.GetSolutionsContainingProject(
                solutionFilePaths,
                projectFilePath)
                .Now();

            return output;
        }
    }
}