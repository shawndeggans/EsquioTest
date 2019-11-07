using System;
using System.Collections.Generic;

namespace EsqFeatureToggle.MVC.Settings
{
    public class UserRoleSettings
    {
        public IEnumerable<string> AllowedUsers { get; set; }
    }
}
