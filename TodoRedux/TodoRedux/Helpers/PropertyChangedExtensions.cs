using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;

namespace TodoRedux.Helpers
{
    public static class PropertyChangedExtensions
    {
        public static void WhenAny<T, TProperty> (this T source, Action<string> action, params Expression<Func<T, TProperty>>[] properties) where T : INotifyPropertyChanged
        {
            Dictionary<string, Func<T, TProperty>> propertyNames = new Dictionary<string, Func<T, TProperty>> ();
            Expression<Func<T, TProperty>>[] properties2 = properties;
            for (int i = 0; i < properties2.Length; i++) {
                Expression<Func<T, TProperty>> expression = properties2 [i];
                propertyNames.Add (expression.GetPropertyInfo<T, TProperty> ().Name, expression.Compile ());
            }
            source.PropertyChanged += (object sender, PropertyChangedEventArgs e) => {
                if (propertyNames.ContainsKey (e.PropertyName)) {
                    action(e.PropertyName);
                }
            };
        }

        /// <summary>
        /// Gets property information for the specified <paramref name="property"/> expression.
        /// </summary>
        /// <typeparam name="TSource">Type of the parameter in the <paramref name="property"/> expression.</typeparam>
        /// <typeparam name="TValue">Type of the property's value.</typeparam>
        /// <param name="property">The expression from which to retrieve the property information.</param>
        /// <returns>Property information for the specified expression.</returns>
        /// <exception cref="ArgumentException">The expression is not understood.</exception>
        public static PropertyInfo GetPropertyInfo<TSource, TValue>(this Expression<Func<TSource, TValue>> property)
        {
            if (property == null)
                throw new ArgumentNullException("property");

            var body = property.Body as MemberExpression;
            if (body == null)
                throw new ArgumentException("Expression is not a property", "property");

            var propertyInfo = body.Member as PropertyInfo;
            if (propertyInfo == null)
                throw new ArgumentException("Expression is not a property", "property");

            return propertyInfo;
        }
    }
}

