using System;

namespace Infrastructure.Requirements
{
	public interface IRequirement
	{
		string RequirementName { get; }
		string RequirementDescription { get; }
		bool AttemptCorrection { get; }
		Func<IRequirement,bool> Correction { get; }
		float DeweySequence { get; }
		bool CheckRequirement();
	}
}