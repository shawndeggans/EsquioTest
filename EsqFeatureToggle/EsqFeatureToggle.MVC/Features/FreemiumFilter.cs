using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.FeatureManagement;
using EsqFeatureToggle.MVC.Settings;

namespace EsqFeatureToggle.MVC.Features
{
    [FilterAlias("Freemium")]
    public class FreemiumFilter : IFeatureFilter
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private static string _hardCodedRoleName = CurrentUserRole.UserRole;

        public FreemiumFilter(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public bool Evaluate(FeatureFilterEvaluationContext context)
        {
            UserRoleSettings settings = context.Parameters.Get<UserRoleSettings>();
            return settings == null || settings.AllowedUsers.Contains(_hardCodedRoleName);
        }
    }
}
