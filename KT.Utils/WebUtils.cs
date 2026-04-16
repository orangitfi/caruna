using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace KT.Utils
{
  public class WebUtils
  {


    #region Yleiset

    public delegate ListItem ListItemCreatorDelegate<T>(T dataItem);
    public delegate ListItem EmptyListItemCreator();


    public static Control FindControlRecursive(Control rootControl, string controlId)
    {
      foreach (Control c in rootControl.Controls)
      {
        if (c.ID == controlId)
          return c;
      }

      foreach (Control c in rootControl.Controls)
      {
        Control result = FindControlRecursive(c, controlId);
        if ((result != null))
          return result;
      }

      return null;

    }

    public static T FindChildControl<T>(Control parentCtrl, string ctrlName) where T : Control
    {
      return (T)parentCtrl.FindControl(ctrlName);
    }

    public static IEnumerable<T> GetChildControlsByType<T>(Control c) where T : Control
    {
      List<T> childControls = new List<T>();
      GetChildControlsByType<T>(c, childControls);
      return childControls;
    }

    private static void GetChildControlsByType<T>(Control c, List<T> childControls) where T : Control
    {
      foreach (Control child in c.Controls)
      {
        T tmp = child as T;
        if (tmp != null) childControls.Add(tmp);
        GetChildControlsByType<T>(child, childControls);
      }
    }

    public static IEnumerable<Control> FindControlsByName(Control rootControl, Func<string, bool> compareFunction)
    {
      List<Control> results = new List<Control>();
      FindControlsByName(rootControl, compareFunction, results);

      return results;
    }

    private static void FindControlsByName(Control rootControl, Func<string, bool> compareFunction, List<Control> results)
    {
      foreach (Control c in rootControl.Controls)
      {
        if (c.ID != null && compareFunction(c.ID))
          results.Add(c);

        FindControlsByName(c, compareFunction, results);
      }
    }

    #endregion

    #region Label

    public static void PrintMessage(Label lbl, string message)
    {
      PrintMessage(lbl, message, null);
    }

    public static void PrintMessage(Label lbl, string message, System.Drawing.Color? textColor)
    {
      lbl.Text = message;
      lbl.Visible = !string.IsNullOrEmpty(message);
      if (textColor.HasValue) lbl.ForeColor = textColor.Value;
    }

    #endregion

    #region CheckBoxList

    public static void SetCheckBoxListSelectedValues<T>(CheckBoxList chkList, IEnumerable<T> selectedValues)
    {
      foreach (ListItem itm in chkList.Items)
      {
        itm.Selected = selectedValues.Any(x => x.ToString() == itm.Value);
      }
    }

    public static IEnumerable<T> GetCheckBoxListSelectedValues<T>(CheckBoxList chkList)
    {
      List<T> values = new List<T>();

      foreach (ListItem itm in chkList.Items)
      {
        if (itm.Selected) values.Add(DataUtils.ParseValue<T>(itm.Value));
      }

      return values;
    }

    #endregion

    #region DropDownList

    public static void DataBindDropDownList<T>(DropDownList ddl, IEnumerable<T> dataItems, ListItemCreatorDelegate<T> itemCreator)
    {
      DataBindDropDownList<T>(ddl, dataItems, itemCreator, null, null);
    }

    public static void DataBindDropDownList<T>(DropDownList ddl, IEnumerable<T> dataItems, ListItemCreatorDelegate<T> itemCreator, string emptyItemText, string emptyItemValue)
    {
      ddl.Items.Clear();
      if (!string.IsNullOrEmpty(emptyItemText)) ddl.Items.Add(new ListItem(emptyItemText, emptyItemValue));

      foreach (T dataItem in dataItems)
      {
        ddl.Items.Add(itemCreator(dataItem));
      }
    }

    #endregion

    public static void DataBindList(ListControl list, object datasource, string dataTextField, string dataValueField)
    {

      if (!string.IsNullOrEmpty(dataTextField))
        list.DataTextField = dataTextField;
      if (!string.IsNullOrEmpty(dataValueField))
        list.DataValueField = dataValueField;

      list.DataSource = datasource;
      list.DataBind();

    }

    public static void DataBindList<T>(ListControl list, IEnumerable<T> datasource, ListItemCreatorDelegate<T> listItemCreator)
    {

      foreach (T item in datasource)
      {
        list.Items.Add(listItemCreator.Invoke(item));
      }

    }

    public static void DataBindList<T>(ListControl list, IEnumerable<T> datasource, ListItemCreatorDelegate<T> listItemCreator, EmptyListItemCreator emptyItemCreator)
    {

      DataBindList<T>(list, datasource, listItemCreator);

      list.Items.Insert(0, emptyItemCreator.Invoke());

    }

    public static void DataBindList(ListControl list, object datasource, string dataTextField, string dataValueField, EmptyListItemCreator emptyItemCreator)
    {
      DataBindList(list, datasource, dataTextField, dataValueField);

      list.Items.Insert(0, emptyItemCreator.Invoke());
    }

    #region Listbox

    public static void DataBindListBox<T>(ListBox lst, IEnumerable<T> dataItems, string dataTextField, string dataValueField)
    {
      lst.DataTextField = dataTextField;
      lst.DataValueField = dataValueField;

      lst.DataSource = dataItems;
      lst.DataBind();
    }

    public static void DataBindListBox<T>(ListBox lst, IEnumerable<T> dataItems, ListItemCreatorDelegate<T> itemCreator)
    {
      lst.Items.Clear();
      foreach (T dataItem in dataItems)
      {
        lst.Items.Add(itemCreator(dataItem));
      }
    }

    public static IEnumerable<ListItem> GetListBoxSelectedItems(ListBox lb)
    {
      List<ListItem> values = new List<ListItem>(lb.Items.Count);

      foreach (ListItem itm in lb.Items)
      {
        if (itm.Selected) values.Add(itm);
      }

      return values;
    }

    public static IEnumerable<string> GetListBoxSelectedTexts(ListBox lb)
    {
      return GetListBoxSelectedItems(lb).Select(x => x.Text);
    }

    public static IEnumerable<string> GetListBoxSelectedValues(ListBox lb)
    {
      return GetListBoxSelectedItems(lb).Select(x => x.Value);
    }

    public static IEnumerable<T> GetListBoxSelectedValues<T>(ListBox lb)
    {
      List<T> values = new List<T>();

      foreach (string s in GetListBoxSelectedValues(lb))
      {
        values.Add(DataUtils.ParseValue<T>(s));
      }

      return values;
    }

    public static void SetListBoxSelectedValues<T>(ListBox lb, IEnumerable<T> selectedValues)
    {
      foreach (ListItem itm in lb.Items)
      {
        itm.Selected = selectedValues.Any(x => x.ToString() == itm.Value);
      }
    }

    #endregion

    #region ListView

    public delegate void ListViewDataBoundHandler<T>(ListViewDataItem d, T entity);

    public static T GetListViewDataKeyValue<T>(ListView lv, ListViewItem item, string keyName)
    {
      ListViewDataItem d = (ListViewDataItem)item;
      return (T)lv.DataKeys[d.DataItemIndex][keyName];
    }

    public static void HandleListViewItemDataBound<T>(ListViewItem item, ListViewDataBoundHandler<T> itemhandler)
    {
      if (item.ItemType == ListViewItemType.DataItem)
      {
        ListViewDataItem d = (ListViewDataItem)item;
        T entity = (T)d.DataItem;

        itemhandler(d, entity);
      }

    }

    #endregion

  }


}
