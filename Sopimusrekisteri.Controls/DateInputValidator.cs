using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using KT.Utils;

namespace Sopimusrekisteri.Controls
{
  public class DateInputValidator : PlaceHolder
  {

    private CompareValidator formatValidator;
    private RequiredFieldValidator requiredValidator;

    public DateInputValidator()
    {
      this.formatValidator = new CompareValidator()
      {
        Operator = ValidationCompareOperator.DataTypeCheck,
        Type = ValidationDataType.Date,
        ErrorMessage = this.InvalidFormatMessage //string.Format(this.InvalidFormatMessage, this.FieldName)
      };

      this.requiredValidator = new RequiredFieldValidator()
      {
        ErrorMessage = this.RequiredMessage //string.Format(this.RequiredMessage, this.FieldName)
      };
    }

    protected override void OnInit(EventArgs e)
    {
      base.OnInit(e);

      this.Controls.Add(this.formatValidator);
      this.SetTargetControl(this.formatValidator);

      this.Controls.Add(this.requiredValidator);
      this.SetTargetControl(this.requiredValidator);

      this.requiredValidator.Enabled = this.Required;
    }

    public string DateInputID
    {
      get
      {
        return DataUtils.GetStringValue(this.ViewState["DateInput"], string.Empty);
      }
      set
      {
        this.ViewState["DateInput"] = value;
      }
    }

    public string FieldName
    {
      get
      {
        return DataUtils.GetStringValue(this.ViewState["FieldName"], "Pvm");
      }
      set
      {
        this.ViewState["FieldName"] = value;
        this.formatValidator.ErrorMessage = string.Format(this.InvalidFormatMessage, this.FieldName);
        this.requiredValidator.ErrorMessage = string.Format(this.RequiredMessage, this.FieldName);
      }
    }

    public string InvalidFormatMessage
    {
      get
      {
        return string.Format(DataUtils.GetStringValue(this.ViewState["InvalidFormatMessage"], "Syötä {0} muodossa pp.kk.vvvv."), this.FieldName.ToLower());
      }
      set
      {
        this.ViewState["InvalidFormatMessage"] = value;
        this.formatValidator.ErrorMessage = string.Format(this.InvalidFormatMessage, this.FieldName);
      }
    }

    public bool Required
    {
      get
      {
        return DataUtils.GetBooleanValue(this.ViewState["Required"], false);
      }
      set
      {
        this.ViewState["Required"] = value;
      }
    }

    public string RequiredMessage
    {
      get
      {
        //return string.Format(DataUtils.GetStringValue(this.ViewState["RequiredMessage"], "{0} on pakollinen tieto."), System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(this.FieldName));
        return string.Format(DataUtils.GetStringValue(this.ViewState["RequiredMessage"], "{0} on pakollinen tieto."), this.FieldName);
      }
      set
      {
        this.ViewState["RequiredMessage"] = value;
        this.requiredValidator.ErrorMessage = string.Format(this.RequiredMessage, this.FieldName);
      }
    }

    public string ValidationGroup
    {
      get
      {
        return this.formatValidator.ValidationGroup;
      }
      set
      {
        this.formatValidator.ValidationGroup = value;
        this.requiredValidator.ValidationGroup = value;
      }
    }

    protected void SetTargetControl(BaseValidator validator)
    {
      DateInput di = KT.Utils.WebUtils.FindControlRecursive(this.Page, this.DateInputID) as DateInput;
      if (di == null) throw new ArgumentException(string.Format("Can't find control with id '{0}'", this.DateInputID));
      validator.ControlToValidate = this.DateInputID + "$txtDate";
    }

  }
}