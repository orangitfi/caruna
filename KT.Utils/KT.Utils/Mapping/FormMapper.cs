using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace KT.Utils.Mapping
{

  public class FormMapper
  {

    #region Attribuutit ja vakiot

    private GenericPropertyAccessor _propertyAccessor;
    private Dictionary<string, PropertyInfo> typeSetterProperties;
    private Dictionary<string, TypeFormatter> _typeFormatters;
    private bool _useEnumIntValue = true;

    private const string TypeNameString = "String";

    #endregion

    #region Konstruktorit

    public FormMapper()
    {
      this.InitializeTypeSetterProperties();
    }

    #endregion

    #region Propertyt

    public bool UseEnumIntValue
    {
      get { return this._useEnumIntValue; }
      set { this._useEnumIntValue = value; }
    }

    private Dictionary<string, TypeFormatter> TypeFormatters
    {
      get
      {
        if ((this._typeFormatters == null))
          this._typeFormatters = new Dictionary<string, TypeFormatter>();
        return this._typeFormatters;
      }
    }

    private GenericPropertyAccessor PropertyAccessor
    {
      get
      {
        if (this._propertyAccessor == null) this._propertyAccessor = new GenericPropertyAccessor();
        return this._propertyAccessor;
      }
    }

    #endregion

    #region Julkiset metodit

    public void AddTypeFormatter(string typeName, TypeFormatter formatter)
    {
      this.TypeFormatters[typeName] = formatter;
    }

    public void AddTypeFormatter(Type t, TypeFormatter formatter)
    {
      this.TypeFormatters[t.Name] = formatter;
    }

    public void AddTypeSetter(Type t, string propertyName)
    {
      this.typeSetterProperties.Add(t.Name, t.GetProperty(propertyName));
    }

    public void AddTypeSetter(string typeName, string propertyName)
    {
      this.AddTypeSetter(Type.GetType(typeName), propertyName);
    }

    public SqlCommand CreateSqlCommandFromFormValues(string connectionString, Control c, string ctrlIdPrefix, object idValue, string tableName, string idFieldName)
    {
      return CreateSqlCommandFromFormValues(connectionString, c, ctrlIdPrefix, idValue, tableName, idFieldName, null);
    }

    public SqlCommand CreateSqlCommandFromFormValues(string connectionString, Control c, string ctrlIdPrefix, object idValue, string tableName, string idFieldName, KeyObjectValuePair[] additionalValues)
    {
      DbUtils dbu = new DbUtils(connectionString);
      DataTable schemaTable = dbu.GetTableSchema(tableName);
      SqlCommand cmd = new SqlCommand();
      StringBuilder valuesStr = new StringBuilder();
      StringBuilder setStr = new StringBuilder();
      bool update = (idValue != null);


      foreach (DataColumn column in schemaTable.Columns)
      {
        string columnName = column.ColumnName;

        if ((additionalValues != null))
        {
          KeyObjectValuePair valuePair = additionalValues.SingleOrDefault(f => f.Key == columnName);
          if ((valuePair != null))
          {
            this.AddSqlParameterValue(cmd, update, valuePair.Value, column, setStr, valuesStr);
            continue;
          }
        }

        Control sourceControl = c.FindControl(ctrlIdPrefix + columnName);

        if ((sourceControl != null))
        {
          Type ctrlType = sourceControl.GetType();

          if (this.typeSetterProperties.ContainsKey(ctrlType.Name))
          {
            PropertyInfo ctrlProperty = this.typeSetterProperties[ctrlType.Name];
            object value = ctrlProperty.GetValue(sourceControl, null);


            if (ctrlProperty.PropertyType != column.DataType)
            {
              if (ctrlProperty.PropertyType.Name == "String")
              {
                if (string.IsNullOrEmpty(Convert.ToString(value)))
                  value = null;
              }
            }

            this.AddSqlParameterValue(cmd, update, value, column, setStr, valuesStr);

          }

        }

      }

      string insertUpdate = null;

      string whereStr = null;

      if (update)
      {
        insertUpdate = string.Format("update {0} SET ", tableName) + setStr.ToString();
        whereStr = string.Format(" where {0} = {1}", idFieldName, idValue);
      }
      else
      {
        insertUpdate = string.Format("insert into {0} ({1}) VALUES ({2})", tableName, setStr.ToString(), valuesStr.ToString());
        whereStr = string.Empty;
      }

      SqlParameter returnParam = new SqlParameter("returnId", SqlDbType.VarChar, 100);
      returnParam.Direction = System.Data.ParameterDirection.Output;
      cmd.Parameters.Add(returnParam);

      cmd.CommandText = insertUpdate + whereStr + "; SET @returnId = scope_identity();";
      cmd.Connection = dbu.GetConnection();

      return cmd;

    }


    public void FillDataRow(Control c, DataRow dr, string idPrefix)
    {
      foreach (DataColumn column in dr.Table.Columns)
      {
        Control targetControl = c.FindControl(idPrefix + column.ColumnName);


        if ((targetControl != null))
        {
          object value = null;
          Type controlType = targetControl.GetType();

          if (this.typeSetterProperties.ContainsKey(controlType.Name))
          {
            PropertyInfo ctrlProperty = this.typeSetterProperties[controlType.Name];
            value = ctrlProperty.GetValue(targetControl, null);

            if (ctrlProperty.PropertyType != column.DataType)
            {
              System.ComponentModel.TypeConverter conv = default(System.ComponentModel.TypeConverter);
              conv = System.ComponentModel.TypeDescriptor.GetConverter(column.DataType);
              value = conv.ConvertFrom(value);
            }

          }

        }
      }

    }

    public void FillObject(Control c, object valueObj, string idPrefix)
    {
      Type t = valueObj.GetType();

      foreach (PropertyInfo pInfo in t.GetProperties())
      {
        if (pInfo.PropertyType.IsValueType || pInfo.PropertyType.Name == "String")
        {
          Control targetControl = c.FindControl(idPrefix + pInfo.Name);
          if ((targetControl != null))
          {
            object value = null;
            Type controlType = targetControl.GetType();

            if (this.typeSetterProperties.ContainsKey(controlType.Name))
            {
              PropertyInfo ctrlProperty = this.typeSetterProperties[controlType.Name];
              Type controlPropertyType = ctrlProperty.PropertyType;
              Type controlPropertyNullableBaseType = Nullable.GetUnderlyingType(controlPropertyType);
              if (controlPropertyNullableBaseType != null) controlPropertyType = controlPropertyNullableBaseType;
              value = ctrlProperty.GetValue(targetControl, null);
              if (controlPropertyType != pInfo.PropertyType && value != null && !string.IsNullOrEmpty(value.ToString())) // ctrlProperty.PropertyType
              {
                if (pInfo.PropertyType.IsEnum)
                {
                  value = Enum.Parse(pInfo.PropertyType, value.ToString());
                }
                else
                {
                  System.ComponentModel.TypeConverter conv = default(System.ComponentModel.TypeConverter);
                  conv = System.ComponentModel.TypeDescriptor.GetConverter(pInfo.PropertyType);
                  value = conv.ConvertFrom(value);
                }

              }

            }
            if (value == null || string.IsNullOrEmpty(value.ToString()))
            {
              if (pInfo.PropertyType.Name == "String")
              {
                value = null;
              }
              else value = Activator.CreateInstance(pInfo.PropertyType);
            }

            pInfo.SetValue(valueObj, value, null);

            //if ((value != null) && (pInfo.PropertyType.Name == "String" || !string.IsNullOrEmpty(value.ToString())))
            //{
            //    pInfo.SetValue(valueObj, value, null);
            //}
          }

        }
      }

    }

    public object SaveFormValuesToDataBase(string connectionString, Control c, string ctrlPrefix, object idValue, string tableName, string idField, KeyObjectValuePair[] additionalValues)
    {
      object returnId = null;
      using (SqlCommand cmd = this.CreateSqlCommandFromFormValues(connectionString, c, ctrlPrefix, idValue, tableName, idField, additionalValues))
      {

        cmd.Connection.Open();
        cmd.ExecuteNonQuery();
        cmd.Connection.Close();

        if ((idValue == null))
        {
          returnId = cmd.Parameters["returnId"].Value;
        }
        else
        {
          returnId = idValue;
        }

      }
      return returnId;
    }

    #endregion

    #region Lomakkeen täyttö

    public void FillForm(Control c, object valueObj)
    {
      this.FillForm(c, valueObj, string.Empty);
    }


    public void FillForm(Control c, object valueObj, string idPrefix)
    {
      Type t = valueObj.GetType();

      this.PropertyAccessor.AddPropertiesFromType(t);
      IEnumerable<PropertyInfo> pInfos = this.PropertyAccessor.GetPropertyInfosByType(t);

      foreach (PropertyInfo pInfo in pInfos)
      {
        if (pInfo.PropertyType.IsValueType || pInfo.PropertyType.Name == TypeNameString)
        {
          Control targetControl = c.FindControl(idPrefix + pInfo.Name);
          this.FillFieldValueType(valueObj, targetControl, pInfo, idPrefix);
        }
        else
        {
          IEnumerable<Control> targetControls = WebUtils.FindControlsByName(c, x => x.StartsWith(idPrefix + pInfo.Name + "_"));

          foreach (Control targetControl in targetControls)
          {
            int prefixLength = (string.IsNullOrEmpty(idPrefix) ? 0 : idPrefix.Length);
            KeyValuePair<object, PropertyInfo> propertyData = this.PropertyAccessor.GetPropertyInfoAndEntity(t, valueObj, targetControl.ID.Replace("_", ".").Substring(prefixLength));
            if (propertyData.Key != null && propertyData.Value != null)
              FillFieldValueType(propertyData.Key, targetControl, propertyData.Value, idPrefix);
          }
        }
      }

    }

    private void FillFieldValueType(object valueObj, Control targetControl, PropertyInfo pInfo, string idPrefix)
    {

      if ((targetControl != null))
      {
        object value = null;
        value = pInfo.GetValue(valueObj, null);

        if ((value != null) && this.UseEnumIntValue)
        {
          if (pInfo.PropertyType.IsEnum)
          {
            value = Convert.ToInt32(value);
          }
          else
          {
            Type nullableType = Nullable.GetUnderlyingType(pInfo.PropertyType);
            bool isNullableType = (nullableType != null);
            if (isNullableType && nullableType.IsEnum)
              value = Convert.ToInt32(value);
          }
        }

        this.SetValue(targetControl, value);
      }
    }

    public void FillFormFromDataRow(Control c, DataRow dr)
    {
      this.FillFormFromDataRow(c, dr, string.Empty);
    }


    public void FillFormFromDataRow(Control c, DataRow dr, string idPrefix)
    {
      foreach (DataColumn column in dr.Table.Columns)
      {
        Control targetControl = c.FindControl(idPrefix + column.ColumnName);
        if ((targetControl != null))
          if (!Convert.IsDBNull(dr[column]))
            this.SetValue(targetControl, dr[column]);
      }

    }

    #endregion

    #region Apumetodit

    private void AddSqlParameterValue(SqlCommand cmd, bool update, object value, DataColumn column, StringBuilder setStr, StringBuilder valuesStr)
    {
      SqlParameter param = default(SqlParameter);
      if ((value == null))
      {
        param = new SqlParameter(column.ColumnName, DBNull.Value);
        param.IsNullable = true;
      }
      else
      {
        param = new SqlParameter(column.ColumnName, Convert.ChangeType(value, column.DataType));
      }

      cmd.Parameters.Add(param);

      if (update)
      {
        if (setStr.Length > 0)
          setStr.Append(", ");
        setStr.Append(column.ColumnName + " = " + "@" + column.ColumnName);
      }
      else
      {
        if (setStr.Length > 0)
          setStr.Append(", ");
        setStr.Append(column.ColumnName);
        if (valuesStr.Length > 0)
          valuesStr.Append(", ");
        valuesStr.Append("@" + column.ColumnName);
      }
    }

    private object GetValue(Control c)
    {
      object value = null;
      Type controlType = c.GetType();
      if (this.typeSetterProperties.ContainsKey(controlType.Name))
      {
        value = this.typeSetterProperties[controlType.Name].GetValue(c, null);
      }
      return value;
    }

    private void InitializeTypeSetterProperties()
    {
      this.typeSetterProperties = new Dictionary<string, PropertyInfo>();
      this.AddTypeSetter(typeof(TextBox), "Text");
      this.AddTypeSetter(typeof(DropDownList), "SelectedValue");
      this.AddTypeSetter(typeof(CheckBox), "Checked");
      this.AddTypeSetter(typeof(RadioButtonList), "SelectedValue");
      this.AddTypeSetter(typeof(Label), "Text");
      this.AddTypeSetter(typeof(HtmlInputHidden), "Value");
    }

    private void SetValue(Control c, object value)
    {
      if ((value == null))
        return;
      Type controlType = c.GetType();

      if (this.typeSetterProperties.ContainsKey(controlType.Name))
      {
        PropertyInfo pInfo = this.typeSetterProperties[controlType.Name];
        object objValue = null;
        Type valueType = value.GetType();
        Type valueNullableType = Nullable.GetUnderlyingType(valueType);
        Type ctrlNullableType = Nullable.GetUnderlyingType(pInfo.PropertyType);

        if (pInfo.PropertyType == valueType || valueNullableType == pInfo.PropertyType || ctrlNullableType == valueType)
        {
          objValue = value;
        }
        else
        {
          if ((this._typeFormatters != null))
          {
            if (this._typeFormatters.ContainsKey(valueType.Name))
            {
              objValue = this._typeFormatters[valueType.Name](value);
            }
            else
            {
              objValue = Convert.ChangeType(value, pInfo.PropertyType);
            }
          }
          else
          {
            objValue = Convert.ChangeType(value, pInfo.PropertyType);
          }
        }

        pInfo.SetValue(c, objValue, null);
      }

    }

    #endregion


  }

  public delegate object TypeFormatter(object value);

}
