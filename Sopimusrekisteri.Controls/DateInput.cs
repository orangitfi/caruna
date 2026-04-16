using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AjaxControlToolkit;

namespace Sopimusrekisteri.Controls
{
  public class DateInput : PlaceHolder, INamingContainer
  {

    private TextBox txtDate;
    private Image imgPopup;
    private CalendarExtender calendar;

    public DateInput()
    {

    }

    protected override void OnInit(EventArgs e)
    {
      base.OnInit(e);

      this.txtDate = new TextBox() { SkinID = "Datetime" };
      this.imgPopup = new Image() { ImageUrl = this.ImageUrl, AlternateText = "Valitse päivämäärä" };
      this.calendar = new CalendarExtender();
      this.calendar.Format = "dd.MM.yyyy";

      this.Controls.Add(this.txtDate);
      this.Controls.Add(this.imgPopup);
      this.Controls.Add(this.calendar);

      this.txtDate.ID = "txtDate";
      this.imgPopup.ID = "imgPopup";
      calendar.PopupButtonID = this.imgPopup.ID;
      calendar.TargetControlID = this.txtDate.ID;
    }

    public string Text
    {
      get { return this.txtDate.Text; }
      set { this.txtDate.Text = value; }
    }

    public DateTime? DateValue
    {
      get
      {
        if (string.IsNullOrEmpty(this.txtDate.Text))
          return null;
        return DateTime.Parse(this.txtDate.Text);
      }
      set
      {
        if (value.HasValue)
          this.txtDate.Text = value.Value.ToShortDateString();
      }
    }

    public string ValidationGroup
    {
      get { return this.txtDate.ValidationGroup; }
      set { this.txtDate.ValidationGroup = value; }
    }

    public bool Enabled
    {
      get { return this.txtDate.Enabled; }
      set { this.txtDate.Enabled = value; }
    }

    public string ImageUrl { get; set; }

  }
}