using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EsqFeatureToggle.MVC.Features
{
    public static class CurrentUserRole
    {
        public static string UserRole = nameof(UserRoles.PremiumPlus);
    }

    public enum UserRoles
    {
        Trial,
        Premium,
        PremiumPlus
    }
}
