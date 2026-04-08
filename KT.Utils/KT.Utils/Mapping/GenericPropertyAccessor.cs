using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Linq.Expressions;

namespace KT.Utils.Mapping
{
  public class GenericPropertyAccessor
  {
    private const char PropertySeparator = '.';
    private GenericPropertyAccessor _propertyAccessor;
    private Dictionary<KeyValuePair<Type, string>, PropertyInfo> _propertyInfos;
    private const string TypeNameString = "String";

    public GenericPropertyAccessor()
    {
    }

    private Dictionary<KeyValuePair<Type, string>, PropertyInfo> PropertyInfos
    {
      get
      {
        if (this._propertyInfos == null) this._propertyInfos = new Dictionary<KeyValuePair<Type, string>, PropertyInfo>();
        return this._propertyInfos;
      }
    }

    public PropertyInfo GetPropertyInfoFromType(Type t, string propertyChain)
    {
      if (!propertyChain.Contains(PropertySeparator)) return t.GetProperty(propertyChain);

      string[] properties = propertyChain.Split(PropertySeparator);

      Type currentType = t;

      for (int i = 0; i < properties.Length; i++)
      {

        string propertyName = properties[i];
        PropertyInfo pi = currentType.GetProperty(propertyName);

        if (pi == null) return pi;

        if (i < properties.Length - 1)
        {
          currentType = pi.PropertyType;
        }
        else
        {
          return pi;
        }
      }

      throw new ArgumentException(string.Format("Could not resolve property '{0}'.", propertyChain));

    }
    public PropertyInfo GetPropertyInfo(Type t, string propertyName)
    {
      KeyValuePair<Type, string> key = new KeyValuePair<Type, string>(t, propertyName);
      if (!this.PropertyInfos.ContainsKey(key))
      {
        this.PropertyInfos[key] = t.GetProperty(propertyName, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
      }
      return this.PropertyInfos[key];
    }

    public IEnumerable<PropertyInfo> GetPropertyInfosByType(Type t)
    {
      List<PropertyInfo> piList = new List<PropertyInfo>();
      foreach (KeyValuePair<Type, string> key in this.PropertyInfos.Keys)
      {
        if (key.Key == t) piList.Add(this.PropertyInfos[key]);
      }
      return piList;
    }

    public KeyValuePair<object, PropertyInfo> GetPropertyInfoAndEntity(Type t, object entity, string propertyChain)
    {
      if (!propertyChain.Contains(PropertySeparator)) return new KeyValuePair<object, PropertyInfo>(entity, GetPropertyInfo(t, propertyChain));

      string[] properties = propertyChain.Split(PropertySeparator);

      object currentEntity = entity;
      Type currentType = t;

      for (int i = 0; i < properties.Length; i++)
      {
        if (currentEntity == null) return new KeyValuePair<object, PropertyInfo>(null, null);
        string propertyName = properties[i];
        PropertyInfo pi = this.GetPropertyInfo(currentType, propertyName);

        if (i < properties.Length - 1)
        {
          currentType = pi.PropertyType;
          currentEntity = pi.GetValue(currentEntity, null);
        }
        else
        {
          return new KeyValuePair<object, PropertyInfo>(currentEntity, pi);
        }
      }

      throw new ArgumentException(string.Format("Could not resolve property '{0}'.", propertyChain));
      //return new KeyValuePair<object,PropertyInfo>(null, null);
    }

    public void AddPropertiesFromType(Type t)
    {
      this.AddPropertiesFromType(t, false);
    }

    public void AddPropertiesFromType(Type t, bool skipReferenceProperties)
    {
      foreach (PropertyInfo pi in t.GetProperties(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance))
      {
        if (skipReferenceProperties && !pi.PropertyType.IsValueType && pi.PropertyType.Name != TypeNameString) continue;
        KeyValuePair<Type, string> key = new KeyValuePair<Type, string>(t, pi.Name);
        if (!this.PropertyInfos.ContainsKey(key)) this.PropertyInfos.Add(key, pi);
      }
    }

    public void SetValue(Type t, object entity, string propertyName, object value)
    {
      PropertyInfo pi = this.GetPropertyInfo(t, propertyName);
      pi.SetValue(entity, value, null);
    }

    public object GetValue(Type t, object entity, string propertyName)
    {
      PropertyInfo pi = this.GetPropertyInfo(t, propertyName);
      return pi.GetValue(entity, null);
    }

    public static string GetPropertyName<T>(Expression<Func<T, object>> property)
    {

      MemberExpression body;

      if (property.Body is MemberExpression)
      {
        body = (MemberExpression)property.Body;
      }
      else
      {
        var operand = ((UnaryExpression)property.Body).Operand;

        body = (MemberExpression)operand;
      }

      return body.Member.Name;
    }

    public static string GetPropertyPath<T>(Expression<Func<T, object>> property)
    {
      var path = new StringBuilder();
      MemberExpression memberExpression = ExpressionUtils.GetMemberExpression(property);
      do
      {
        if (path.Length > 0)
        {
          path.Insert(0, ".");
        }
        path.Insert(0, memberExpression.Member.Name);
        memberExpression = ExpressionUtils.GetMemberExpression(memberExpression.Expression);
      }
      while (memberExpression != null);
      return path.ToString();
    }

  }
}
