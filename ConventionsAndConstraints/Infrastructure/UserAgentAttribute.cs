using Microsoft.AspNetCore.Mvc.ActionConstraints;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace ConventionsAndConstraints.Infrastructure
{

    public class UserAgentAttribute : Attribute, IActionConstraintFactory
    {
        public string substring;

        public UserAgentAttribute(string substring)
        {
            this.substring = substring;
        }


        public IActionConstraint CreateInstance(IServiceProvider services)
        {
            return new UserAgentConstraint(services.GetService<UserAgentComparer>(), substring);
        }

        public bool IsReusable => false;



        private class UserAgentConstraint : IActionConstraint
        {
            private UserAgentComparer comparer;
            private string substring;
            public UserAgentConstraint(UserAgentComparer comp, string sub)
            {
                comparer = comp;
                substring = sub.ToLower();
            }

            public int Order { get; set; } = 0;

            public bool Accept(ActionConstraintContext context)
            {
                return comparer.ContainsString(context.RouteContext.HttpContext.Request, substring)
                           || context.Candidates.Count() == 1;
            }
        }

    }
}
