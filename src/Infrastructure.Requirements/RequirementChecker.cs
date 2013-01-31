using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infrastructure.Requirements
{
	public class RequirementChecker : IRequirementChecker
	{
		private List<IRequirement> _requirements;

		public RequirementChecker()
		{
			_requirements = new List<IRequirement>();
		}

		#region Implementation of IRequirementChecker

		public void AddRequirement(IRequirement requirement)
		{
			_requirements.Add(requirement);
			_requirements = _requirements.OrderBy(r => r.DeweySequence).ToList();
		}

		public void RemoveRequirement(IRequirement requirement)
		{
			_requirements.Remove(requirement);
		}

		public bool CheckAllRequirements()
		{
			return CheckAllRequirements(null, true);
		}

		public bool CheckAllRequirements(Action<IRequirement> onFailed, bool haltOnFailure)
		{
			var isSuccess = true;
			foreach (var requirement in _requirements)
			{
				var success = requirement.CheckRequirement();
				if (!success 
					&& requirement.AttemptCorrection 
					&& requirement.Correction != null)
				{
					success = requirement.Correction(requirement);
				}

				isSuccess = isSuccess && success;
				if (!isSuccess)
				{
					if (onFailed != null)
						onFailed(requirement);
					if(haltOnFailure)
						return false;
				}
			}
			return isSuccess;
		}

		#endregion
	}
}
