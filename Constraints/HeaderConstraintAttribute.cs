using Microsoft.AspNetCore.Mvc.ActionConstraints;
using System;
using System.Linq;

namespace ActionConstraints.Constraints
{
    /// <summary>
    /// Attribute used to impose a constaint on a route based on a specific HTTP header/
    /// </summary>
    public class HeaderConstraintAttribute : Attribute, IActionConstraint
    {
        /// <summary>
        /// The order in which this filter is being processed.
        /// </summary>
        public int Order => 0;

        /// <summary>
        /// The name of the header to look for/
        /// </summary>
        private string Header { get; }

        /// <summary>
        /// The value of the header to filter on/
        /// </summary>
        private string Value { get; }

        public HeaderConstraintAttribute(string header, string value)
        {
            Header = header;
            Value = value;
        }

        public bool Accept(ActionConstraintContext context)
        {
            if (context.RouteContext.HttpContext.Request.Headers.TryGetValue(Header, out var value) && value.Any())
            {
                return value[0] == Value;
            }

            return false;
        }
    }
}
