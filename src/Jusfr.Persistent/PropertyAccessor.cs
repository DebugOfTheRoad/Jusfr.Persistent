﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Jusfr.Persistent {
    internal class PropertyAccessor {
        public static Object Get(Object entry, String propertyName) {
            var getFunc = CreateGetFunction(entry.GetType(), propertyName);
            return getFunc(entry);
        }

        public static void Set(Object entry, String propertyName, Object value) {
            var setAct = CreateSetAction(entry.GetType(), propertyName);
            setAct(entry, value);
        }

        public static void Set<TValue>(Object entry, String propertyName, TValue value) {
            var set = CreateSetAction(entry.GetType(), propertyName);
            set(entry, value);
        }

        public static Func<TEntry, Object> CreateGetFunction<TEntry>(String propertyName) {
            var targetType = typeof(TEntry);
            var property = targetType.GetProperty(propertyName);
            var getMethod = property.GetGetMethod();
            var target = Expression.Parameter(typeof(Object), "target");
            var castedTarget = getMethod.IsStatic ? null : Expression.Convert(target, targetType);
            var getProperty = Expression.Property(castedTarget, property);
            var castPropertyValue = Expression.Convert(getProperty, typeof(object));
            return Expression.Lambda<Func<TEntry, Object>>(castPropertyValue, target).Compile();
        }

        public static Func<Object, Object> CreateGetFunction(Type targetType, String propertyName) {
            var property = targetType.GetProperty(propertyName);
            var getMethod = property.GetGetMethod();
            var target = Expression.Parameter(typeof(Object), "target");
            var castedTarget = getMethod.IsStatic ? null : Expression.Convert(target, targetType);
            var getProperty = Expression.Property(castedTarget, property);
            var castPropertyValue = Expression.Convert(getProperty, typeof(object));
            return Expression.Lambda<Func<Object, Object>>(castPropertyValue, target).Compile();
        }

        public static Action<TEntry, Object> CreateSetAction<TEntry>(String propertyName) {
            var targetType = typeof(TEntry);
            var property = targetType.GetProperty(propertyName);
            var propertyType = property.PropertyType;
            var setMethod = property.GetSetMethod();
            var target = Expression.Parameter(typeof(object), "target");
            var propertyValue = Expression.Parameter(typeof(object), "value");
            var castedTarget = setMethod.IsStatic ? null : Expression.Convert(target, targetType);
            var castedpropertyValue = Expression.Convert(propertyValue, propertyType);
            var propertySet = Expression.Call(castedTarget, setMethod, castedpropertyValue);
            return Expression.Lambda<Action<TEntry, Object>>(propertySet, target, propertyValue).Compile();
        }

        public static Action<Object, Object> CreateSetAction(Type targetType, String propertyName) {
            var property = targetType.GetProperty(propertyName);
            var propertyType = property.PropertyType;
            var setMethod = property.GetSetMethod();
            var target = Expression.Parameter(typeof(object), "target");
            var propertyValue = Expression.Parameter(typeof(object), "value");
            var castedTarget = setMethod.IsStatic ? null : Expression.Convert(target, targetType);
            var castedpropertyValue = Expression.Convert(propertyValue, propertyType);
            var propertySet = Expression.Call(castedTarget, setMethod, castedpropertyValue);
            return Expression.Lambda<Action<Object, Object>>(propertySet, target, propertyValue).Compile();
        }
    }
}
