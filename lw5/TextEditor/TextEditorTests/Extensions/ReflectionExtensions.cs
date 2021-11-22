using System;
using System.Linq.Expressions;
using System.Reflection;

namespace TextEditorTests.Extensions
{
    public static class ReflectionExtensions
    {
        public static void SetProperty<TSource, TProperty>(
            this TSource source,
            Expression<Func<TSource, TProperty>> prop,
            TProperty value )
        {
            var propertyInfo = ( PropertyInfo )( ( MemberExpression )prop.Body ).Member;
            propertyInfo.SetValue( source, value );
        }

        public static void SetField<T>( this T obj, string fieldName, object value )
        {
            FieldInfo fieldInfo = GetFieldInfo<T>( fieldName );
            fieldInfo.SetValue( obj, value );
        }

        public static TValue GetFieldValue<TSource, TValue>( this TSource source, string fieldName )
        {
            return ( TValue )typeof( TSource ).GetField( fieldName, BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static ).GetValue( source );
        }

        private static FieldInfo GetFieldInfo<T>(string fieldName)
        {
            return typeof( T ).GetField( fieldName, BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static );
        }
    }
}
