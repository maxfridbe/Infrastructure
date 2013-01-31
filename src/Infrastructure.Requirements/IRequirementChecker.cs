using System;

namespace Infrastructure.Requirements
{
	public interface IRequirementChecker
	{
		void AddRequirement(IRequirement requirement);
		void RemoveRequirement(IRequirement requirement);
		bool CheckAllRequirements();
		bool CheckAllRequirements(Action<IRequirement> onFailed, bool haltOnFailure);
	}
}