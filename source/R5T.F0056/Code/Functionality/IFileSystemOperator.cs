using System;
using System.Collections.Generic;

using R5T.T0132;


namespace R5T.F0056
{
	[FunctionalityMarker]
	public partial interface IFileSystemOperator : IFunctionalityMarker,
		F0002.IFileSystemOperator
	{
		public IEnumerable<string> FindSolutionFilesInDirectoryOrParentDirectories(string directoryPath)
        {
			var output = this.FindFilesInDirectoryOrParentDirectories(
				directoryPath,
				Instances.SearchPatternGenerator.For_SolutionFiles());

			return output;
        }

		public IEnumerable<string> FindSolutionFilesInDirectoryOfFileOrParentDirectories(string filePath)
		{
			var directoryPath = F0002.PathOperator.Instance.Get_ParentDirectoryPath_ForFile(filePath);

			var output = this.FindSolutionFilesInDirectoryOrParentDirectories(directoryPath);
			return output;
		}
	}
}