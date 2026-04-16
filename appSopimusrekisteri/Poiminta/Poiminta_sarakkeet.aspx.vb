Imports Sopimusrekisteri.BLL_CF
Imports KT.Utils
Imports KT.Utils.Mapping

Public Class Poiminta_sarakkeet
  Inherits System.Web.UI.Page

  Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

  End Sub

  Private Function HaeSopimusSarakkeet() As IEnumerable(Of ColumnBinding)

    'Dim sarakkeet As ColumnBinding() = New ColumnBinding() _
    '  { _
    '    ColumnBindingMapper.GetColumnBinding(Of Sopimusrekisteri.BLL_CF.Sopimus)("Sopimusnumero", Function(x) x.Id, GetType(Integer)), _
    '    ColumnBindingMapper.GetColumnBinding(Of Sopimusrekisteri.BLL_CF.Sopimus)("Sopimustyyppi", Function(x) x.Sopimustyyppi.SopimustyyppiNimi, GetType(String)), _
    '    ColumnBindingMapper.GetColumnBinding(Of Sopimusrekisteri.BLL_CF.Sopimus)("Projektinumero", Function(x) x.PCSNumero, GetType(String)), _
    '    ColumnBindingMapper.GetColumnBinding(Of Sopimusrekisteri.BLL_CF.Sopimus)("Projektivalvoja", Function(x) x.Projektinvalvoja, GetType(String)), _
    '    ColumnBindingMapper.GetColumnBinding(Of Sopimusrekisteri.BLL_CF.Sopimus)("Muu tunniste", Function(x) x.MuuTunniste, GetType(String)), _
    '    ColumnBindingMapper.GetColumnBinding(Of Sopimusrekisteri.BLL_CF.Sopimus)("Sopimuksen laatija", Function(x) x.SopimuksenLaatija, GetType(String)), _
    '    ColumnBindingMapper.GetColumnBinding(Of Sopimusrekisteri.BLL_CF.Sopimus)("Korvaa sopimuksen", Function(x) x.Korvaa, GetType(String)), _
    '    ColumnBindingMapper.GetColumnBinding(Of Sopimusrekisteri.BLL_CF.Sopimus)("Verkkoyhtiön rooli sopimuksessa", Function(x) x.Id, _
    '    ColumnBindingMapper.GetColumnBinding(Of Sopimusrekisteri.BLL_CF.Sopimus)("Karttaliite", Function(x) x.Id), _
    '    ColumnBindingMapper.GetColumnBinding(Of Sopimusrekisteri.BLL_CF.Sopimus)("Asiakkaan allekirjoituspäivämäärä", Function(x) x.Id), _
    '    ColumnBindingMapper.GetColumnBinding(Of Sopimusrekisteri.BLL_CF.Sopimus)("Verkonhaltijan allekirjoituspäivämäärä", Function(x) x.Id), _
    '    ColumnBindingMapper.GetColumnBinding(Of Sopimusrekisteri.BLL_CF.Sopimus)("Alkupvm", Function(x) x.Id), _
    '    ColumnBindingMapper.GetColumnBinding(Of Sopimusrekisteri.BLL_CF.Sopimus)("Päättymispvm", Function(x) x.Id), _
    '    ColumnBindingMapper.GetColumnBinding(Of Sopimusrekisteri.BLL_CF.Sopimus)("Sopimuksen jatkoaika (kk)", Function(x) x.Id), _
    '    ColumnBindingMapper.GetColumnBinding(Of Sopimusrekisteri.BLL_CF.Sopimus)("Sopimuksen irtisanomisaika (kk)", Function(x) x.Id), _
    '    ColumnBindingMapper.GetColumnBinding(Of Sopimusrekisteri.BLL_CF.Sopimus)("Sopimuksen irtisanomistoimet", Function(x) x.Id), _
    '    ColumnBindingMapper.GetColumnBinding(Of Sopimusrekisteri.BLL_CF.Sopimus)("Kieli", Function(x) x.Id), _
    '    ColumnBindingMapper.GetColumnBinding(Of Sopimusrekisteri.BLL_CF.Sopimus)("Luonnos", Function(x) x.Id), _
    '    ColumnBindingMapper.GetColumnBinding(Of Sopimusrekisteri.BLL_CF.Sopimus)("Erityisehdot", Function(x) x.Id), _
    '    ColumnBindingMapper.GetColumnBinding(Of Sopimusrekisteri.BLL_CF.Sopimus)("Yläsopimuksen tyyppi", Function(x) x.Id), _
    '    ColumnBindingMapper.GetColumnBinding(Of Sopimusrekisteri.BLL_CF.Sopimus)("Alkuperäinen yhtiö", Function(x) x.Id), _
    '    ColumnBindingMapper.GetColumnBinding(Of Sopimusrekisteri.BLL_CF.Sopimus)("Julkisuusaste", Function(x) x.Id), _
    '    ColumnBindingMapper.GetColumnBinding(Of Sopimusrekisteri.BLL_CF.Sopimus)("Sopimuksen alaluokka", Function(x) x.Id), _
    '    ColumnBindingMapper.GetColumnBinding(Of Sopimusrekisteri.BLL_CF.Sopimus)("Sopimuksen ehtoversio", Function(x) x.Id), _
    '    ColumnBindingMapper.GetColumnBinding(Of Sopimusrekisteri.BLL_CF.Sopimus)("Sisällön yleiskuvaus", Function(x) x.Id), _
    '    ColumnBindingMapper.GetColumnBinding(Of Sopimusrekisteri.BLL_CF.Sopimus)("Sopimuksen siirto-oikeus verkonhaltija", Function(x) x.Id), _
    '    ColumnBindingMapper.GetColumnBinding(Of Sopimusrekisteri.BLL_CF.Sopimus)("Sopimuksen siirto-oikeus vastaosapuoli", Function(x) x.Id), _
    '    ColumnBindingMapper.GetColumnBinding(Of Sopimusrekisteri.BLL_CF.Sopimus)("Sopimuksen irtisanomispvm", Function(x) x.Id), _
    '    ColumnBindingMapper.GetColumnBinding(Of Sopimusrekisteri.BLL_CF.Sopimus)("Sopimuksen kohdekategoria", Function(x) x.Id), _
    '    ColumnBindingMapper.GetColumnBinding(Of Sopimusrekisteri.BLL_CF.Sopimus)("Puuston omistajuus", Function(x) x.Id), _
    '    ColumnBindingMapper.GetColumnBinding(Of Sopimusrekisteri.BLL_CF.Sopimus)("Puuston poisto", Function(x) x.Id) _
    '    }

  End Function

End Class