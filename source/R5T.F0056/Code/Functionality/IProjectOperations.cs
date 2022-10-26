using System;
using System.Linq;
using System.Threading.Tasks;

using R5T.T0132;


namespace R5T.F0056
{
	[FunctionalityMarker]
	public partial interface IProjectOperations : IFunctionalityMarker
	{
		/// <summary>
		/// Adds package properties using their default values.
		/// </summary>
		public void AddPackageProperties()
		{
			var projectFilePaths = new[]
			{
				@"C:\Code\DEV\Git\GitHub\SafetyCone\R5T.T0064\source\R5T.T0064\R5T.T0064.csproj",
			};

			foreach (var projectFilePath in projectFilePaths)
			{
				this.AddPackageProperties(projectFilePath);
			}
		}

		public void AddPackageProperties(string projectFilePath)
		{
			/// Inputs.
			var descriptionOverride =
				String.Empty
				//""
				;
			var licenseOverride =
				String.Empty
				//""
				;
			var packageTags =
				Array.Empty<string>()
				//new string[]
				//{

				//}
				;

			var version = F0020.ProjectOperator.Instance.GetDefaultVersion();
			var authors = new[]
			{
				"DCoats"
			};
			var company = "Rivet";
			var copyrightHolder = company;
			var copyrightText = $"Copyright (c) {copyrightHolder} {F0000.Instances.NowOperator.GetNowLocal().Year}";
			//var packageReadmeFileRelativePath = "Project Plan.md";
			var requireLicenseAcceptance = true;

			/// Run.
			// Start by creating a backup project file.
			Instances.FileSystemOperator.CreateBackupFile(projectFilePath);

			// Now modify the project file.
			//var description = ; // Get from project plan.
			//var repositoryUrl = ;// Get from repository.

			Instances.ProjectFileOperator.InModifyProjectFileContext(
				projectFilePath,
				projectElement =>
				{
					var projectXmlOperator = F0020.Instances.ProjectXmlOperator;

					// Version: Set the version first, so that other elements can find the right element.
					projectXmlOperator.SetVersion(projectElement, version);

					// Authors.
					projectXmlOperator.SetAuthors(projectElement, authors);

					// Company.
					projectXmlOperator.SetCompany(projectElement, company);

					// Copyright.
					projectXmlOperator.SetCopyright(projectElement, copyrightText);

					// Description.
					if (F0000.Instances.StringOperator.HasValue(descriptionOverride))
					{
						// Use the description override.
						projectXmlOperator.SetDescription(projectElement, descriptionOverride);
					}
					else
					{
						//// Get the description from the project plan file.
						//var projectPlanFilePath = Instances.ProjectPathsOperator.GetProjectPlanMarkdownFilePath(projectFilePath);
						var description = "--- ADD DESCRIPTION ---";
						projectXmlOperator.SetDescription(projectElement, description);
					}

					// License
					if (F0000.Instances.StringOperator.HasValue(licenseOverride))
					{
						projectXmlOperator.SetPackageLicenseExpression(projectElement, licenseOverride);
					}
					else
					{
						var repositoryDirectoryPath = Instances.GitOperator.GetRepositoryDirectoryPath(projectFilePath);
						var licenseFilePath = Instances.RepositoryPathsOperator.GetLicenseFilePath(repositoryDirectoryPath);
						var licenseTextLines = F0000.Instances.FileSystemOperator.ReadText_Lines(licenseFilePath);
						var licenseExpression = Instances.Strings.NoLicenseFoundExpression;
						var firstLicenseTextLine = licenseTextLines.First();
						if (firstLicenseTextLine == Instances.Strings.MitLicenseFirstLine)
						{
							projectXmlOperator.SetPackageLicenseExpression(projectElement, Instances.LicenseIdentifiers.MIT);
						}
					}

					//// Readme.
					//projectXmlOperator.SetPackageReadmeFile(projectElement, packageReadmeFileRelativePath);

					// Require license acceptance.
					projectXmlOperator.SetPackageRequireLicenseAcceptance(projectElement, requireLicenseAcceptance);

					// Repository URL.
					var repositoryUrl = Instances.GitOperator.GetRepositoryRemoteUrl(projectFilePath);
					projectXmlOperator.SetRepositoryUrl(projectElement, repositoryUrl);

					// Package tags.
					// Only set package tags if there are any.
					if (F0000.EnumerableOperator.Instance.HasAny(packageTags))
					{
						projectXmlOperator.SetPackageTags(projectElement, packageTags);
					}
				});
		}

		public async Task AddProjectReference_AndUpdateSolutions(
			string projectFilePath,
			string projectReferenceFilePath)
        {
			/// Prior work:
			/// * (best) ISolutionOperator_AddDependencyProjectReferenceAndRecursiveDependencies_R5T_X0002
			/// * ISolutionOperator_UpdateSolutionWithProject_R5T_T0113_X0001
			/// * IFileSystemOperator_FindSolutionFilesInFileDirectoryOrDirectParentDirectories_R5T_T0044_X0001
			/// * IProjectGenerator_CreateProjectAddProjectReferencesAndUpdateSolution_R5T_T0113_X0001

			// Add the project reference to the project.
			await Instances.ProjectFileOperator.AddProjectReference_Idempotent(
				projectFilePath,
				projectReferenceFilePath);

			// Get all recursive project references of the project, inclusive.
			var allProjectReferenceFilePaths = await F0016.F001.ProjectReferencesOperator.Instance.GetAllRecursiveProjectReferences_Inclusive(
				projectFilePath);

			// Get all solution files in parent directories of the project directory, which contain the project file.
			var solutionFilePaths = Instances.SolutionOperations.GetSolutionFilePathsContainingProject(
				projectFilePath);

			F0063.F001.SolutionOperator.Instance.AddDependencyProjects_Idempotent(
				solutionFilePaths,
				allProjectReferenceFilePaths);
        }
	}
}