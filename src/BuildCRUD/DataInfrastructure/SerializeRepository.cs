using DataInfrastructure.Model;
using Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;

namespace DataInfrastructure.Infrastructure
{
    static public class SerializeRepository
    {

        static public ApiBuilding AsApiBuilding(this Building src)
        {

            ApiBuilding dest = new ApiBuilding();
            var sourceType = src.GetType();
            var targetType = dest.GetType();
            var propMap = GetMatchingProperties(sourceType, targetType);
            for (var i = 0; i < propMap.Count; i++)
            {
                var prop = propMap[i];
                var sourceValue = prop.SourceProperty.GetValue(src, null);
                prop.TargetProperty.SetValue(dest, sourceValue, null);
            }
            return dest;
        }

        static public ApiCompany AsApiCompany(this Company src)
        {

            ApiCompany dest = new ApiCompany();
            var sourceType = src.GetType();
            var targetType = dest.GetType();
            var propMap = GetMatchingProperties(sourceType, targetType);
            for (var i = 0; i < propMap.Count; i++)
            {
                var prop = propMap[i];
                var sourceValue = prop.SourceProperty.GetValue(src, null);
                prop.TargetProperty.SetValue(dest, sourceValue, null);
            }
            return dest;
        }

        static public ApiEmployeeDetails AsApiEmployeeDetails(this EmployeeDetail src)
        {

            ApiEmployeeDetails dest = new ApiEmployeeDetails();
            var sourceType = src.GetType();
            var targetType = dest.GetType();
            var propMap = GetMatchingProperties(sourceType, targetType);
            for (var i = 0; i < propMap.Count; i++)
            {
                var prop = propMap[i];
                var sourceValue = prop.SourceProperty.GetValue(src, null);
                prop.TargetProperty.SetValue(dest, sourceValue, null);
            }
            return dest;
        }

        static public ApiEmployee AsApiEmployee(this Employee src)
        {

            ApiEmployee dest = new ApiEmployee();
            var sourceType = src.GetType();
            var targetType = dest.GetType();
            var propMap = GetMatchingProperties(sourceType, targetType);
            for (var i = 0; i < propMap.Count; i++)
            {
                var prop = propMap[i];
                var sourceValue = prop.SourceProperty.GetValue(src, null);
                prop.TargetProperty.SetValue(dest, sourceValue, null);
            } 
            return dest;
        }

        static public Employee AsEmployee(this ApiEmployee src)
        {

            Employee dest = new Employee();
            var sourceType = src.GetType();
            var targetType = dest.GetType();
            var propMap = GetMatchingProperties(sourceType, targetType);
            for (var i = 0; i < propMap.Count; i++)
            {
                var prop = propMap[i];
                var sourceValue = prop.SourceProperty.GetValue(src, null);
                prop.TargetProperty.SetValue(dest, sourceValue, null);
            }
            return dest;
        }

        static public ApiBeingHiredFor AsApiBeingHiredFor(this BeingHiredFor src)
        {

            ApiBeingHiredFor dest = new ApiBeingHiredFor();
            var sourceType = src.GetType();
            var targetType = dest.GetType();
            var propMap = GetMatchingProperties(sourceType, targetType);
            for (var i = 0; i < propMap.Count; i++)
            {
                var prop = propMap[i];
                var sourceValue = prop.SourceProperty.GetValue(src, null);
                prop.TargetProperty.SetValue(dest, sourceValue, null);
            }
            return dest;
        }

        static public BeingHiredFor AsBeingHiredFor(this ApiBeingHiredFor src)
        {

            BeingHiredFor dest = new BeingHiredFor();
            var sourceType = src.GetType();
            var targetType = dest.GetType();
            var propMap = GetMatchingProperties(sourceType, targetType);
            for (var i = 0; i < propMap.Count; i++)
            {
                var prop = propMap[i];
                var sourceValue = prop.SourceProperty.GetValue(src, null);
                prop.TargetProperty.SetValue(dest, sourceValue, null);
            }
            return dest;
        }




        public static IList<PropertyMap> GetMatchingProperties(Type sourceType, Type targetType)
        {

            var sourceProperties = sourceType.GetProperties();
            var targetProperties = targetType.GetProperties();

            var properties = (from s in sourceProperties
                              from t in targetProperties
                              where s.Name == t.Name
                              && s.GetType() == t.GetType()
                              && s.GetGetMethod().ReturnType == t.GetGetMethod().ReturnType
                              select  new PropertyMap
                                         {

                                             SourceProperty = s,
                                             TargetProperty = t

                                         }).ToList();
            return properties;
        }



    }

    public class PropertyMap
    {

        public PropertyInfo SourceProperty { get; set; }

        public PropertyInfo TargetProperty { get; set; }

    }
}