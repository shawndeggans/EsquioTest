using System;
using Microsoft.FeatureManagement;
using EsqFeatureToggle.MVC.Settings;
using System.Linq;
using Microsoft.Extensions.Configuration;

namespace EsqFeatureToggle.MVC.Features
{
    public class AbstractFilter : IFeatureFilter
    {
        private static string _hardCodedRoleName = CurrentUserRole.UserRole;

        public bool Evaluate(FeatureFilterEvaluationContext context)
        {
            UserRoleSettings settings = context.Parameters.Get<UserRoleSettings>();
            return settings == null || settings.AllowedUsers.Contains(_hardCodedRoleName);
        }
    }
}
