using System;

using R5T.T0132;


namespace R5T.F0056
{
	[FunctionalityMarker]
	public partial interface IStrings : IFunctionalityMarker
	{
		public string MitLicenseFirstLine => "MIT License";
		public string NoLicenseFoundExpression => "XXX No License File Found XXX";
	}
}