using System;

using Microsoft.Extensions.Logging;

using R5T.T0132;


namespace R5T.F0056
{
	[DraftFunctionalityMarker]
	public partial interface IRepositoryOperator : IDraftFunctionalityMarker,
		F0042.IRepositoryOperator
	{
		/// <summary>
		/// Pushes all changes to a repository using the <see cref="F0042.ICommitMessages.InitialCommit"/> commit message.
		/// </summary>
		/// <inheritdoc cref="F0041.IGitHubOperator.PushAllChanges(string, string, ILogger)" path="/returns"/>
		public new bool PerformInitialCommit(
			string repositoryLocalDirectoryPath,
			ILogger logger)
		{
			var pushAllChangesResult = Instances.GitHubOperator.PushAllChanges(
				repositoryLocalDirectoryPath,
				Instances.CommitMessages.InitialCommit,
				logger);

			return pushAllChangesResult;
		}
	}
}