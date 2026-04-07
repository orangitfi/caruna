using System;

namespace Sopimusrekisteri.BLL_CF
{
    public class Tiedosto : IEditable
  {
		#region Propertyt

		public int Id {get; private set;}
		public string TiedostoNimi {get; set;}
		public string URL {get; set;}
		public string Selite {get; set;}
		public int? TiedostoLahdeId {get; set;}
		public int? SopimusId {get; set;}
		public int? SharePointId {get; set;}
		public int? ArkistonSijaintiId {get; set;}
		public string DocumentID {get; set;}
		public string ArkistointiTunniste {get; set;}
		public int? Sivuja {get; set;}
		public string Info {get; set;}
		public DateTime Luotu {get; set;}
		public string Luoja {get; set;}
		public DateTime? Paivitetty {get; set;}
		public string Paivittaja {get; set;}
		public int? SopimusFormaattiId {get; set;}
		public string Asiakirjatarkenne {get; set; }
		public Guid? MFilesVault { get; set; }
		public int MFilesType { get; set; }
		public int? MFilesId { get; set; }
		public Guid? MFilesObject { get; set; }

		#endregion

		#region Read-only

		public string MFilesLink => GetMFilesLink(MFilesAction.Show);
		public TiedostonSijainti Sijainti => !string.IsNullOrEmpty(MFilesLink) ? TiedostonSijainti.MFiles : TiedostonSijainti.Sharepoint;

        #endregion

        #region Entiteettiviittaukset

        public virtual Tiedostolahde TiedostoLahde {get; set;}
		public virtual Sopimus Sopimus {get; set;}
		public virtual ArkistonSijainti ArkistonSijainti {get; set;}
		public virtual SopimusFormaatti SopimusFormaatti {get; set;}

		#endregion

		#region Metodit

		public override bool Equals(object obj)
		{
			var tmp = obj as Tiedosto;
			if (tmp == null) return false;
			return tmp.Id == Id;
		}

		public override int GetHashCode()
		{
			return Id.GetHashCode();
		}

		public override string ToString()
		{
			return Id.ToString();
		}

		public string GetMFilesLink(MFilesAction action)
        {
			if (MFilesVault.HasValue && MFilesId.HasValue)
            {
				string actionStr = action.ToString().ToLower();

				string link = $"m-files://{actionStr}/{MFilesVault.ToString().ToUpper()}/{MFilesType}-{MFilesId}";

				if (MFilesObject.HasValue)
					link += $"?object={MFilesObject.ToString().ToUpper()}";

				return link;
			}

			return string.Empty;
        }

		#endregion

  }
}
