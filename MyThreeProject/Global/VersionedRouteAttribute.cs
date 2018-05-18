using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc.Routing;
using System.Web.Routing;

namespace MyThreeProject.Global
{
    public class VersionedRouteAttribute: RouteFactoryAttribute
    {
        public VersionedRouteAttribute(string template, int version)
            : base(template)
        {
            Version = Math.Max(1, version); 
        }

        public int Version {
            get;
            private set;
        }

        public override RouteValueDictionary Constraints
        {
            get
            {
                var constraints = new RouteValueDictionary();
                constraints.Add("version", new VersionedRouteConstraint(Version));
                return constraints;
            }
        }

        public override RouteValueDictionary Defaults
        {
            get
            {
                var defaults = new RouteValueDictionary();
                defaults.Add("version", Version);
                return defaults;
            }
        }

    }
}