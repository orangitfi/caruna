using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;

namespace KT.Utils.Mapping
{
  public class ColumnBindingMapper
  {

    public static ColumnBinding GetColumnBinding<T>(string headerText, Expression<Func<T, object>> columnFunction, Type columnType)
    {
      
      return new ColumnBinding(headerText, GenericPropertyAccessor.GetPropertyPath<T>(columnFunction), columnType);

    }

  }
}
