// <copyright file="FibonacciConstraint.cs" company="No Company">
// Copyright (c) Sprocket Enterprises. All rights reserved.
// </copyright>
// <author>Ilya Myalik</author>
namespace WebApplicationTask.Constraints
{
    using System.Web;
    using System.Web.Routing;

    /// <summary>
    /// Custom constraint.
    /// </summary>
    public class FibonacciConstraint : IRouteConstraint
    {
        /// <summary>
        /// Determines whether the URL parameter contains a valid value for this constraint.
        /// </summary>
        /// <param name="httpContext">An object that encapsulates information about the HTTP request.</param>
        /// <param name="route">The object that this constraint belongs to.</param>
        /// <param name="parameterName">The name of the parameter that is being checked.</param>
        /// <param name="values">An object that contains the parameters for the URL.</param>
        /// <param name="routeDirection">An object that indicates whether the constraint check is being performed when an incoming request is being handled or when a URL is being generated.</param>
        /// <returns>true if the URL parameter contains a valid value; otherwise, false.</returns>
        public bool Match(HttpContextBase httpContext, Route route, string parameterName, RouteValueDictionary values, RouteDirection routeDirection)
        {
            var fibParam = values[parameterName].ToString();
            long fibNumber;
            if (!long.TryParse(fibParam, out fibNumber))
            {
                return false;
            }

            return fibNumber == FibonacciCounter(fibNumber);
        }

        /// <summary>
        /// Method for calculating fib-numbers.
        /// </summary>
        /// <param name="number">Number instance.</param>
        /// <returns>Final fibonacci number.</returns>
        private static long FibonacciCounter(long number)
        {
            long temp = 0, current = 1, prev = 1;
            while (temp < number)
            {
                temp = prev + current;
                prev = current;
                current = temp;
            }

            return number == 1 ? 1 : temp;
        }
    }
}