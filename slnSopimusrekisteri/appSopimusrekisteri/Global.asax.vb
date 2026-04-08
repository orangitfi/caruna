Imports System.Web.Optimization

Public Class Global_asax
    Inherits HttpApplication

    Delegate Sub SopimusarkistoPaivitys()

    Sub Application_Start(ByVal sender As Object, ByVal e As EventArgs)
        ' Fires when the application is started
        BundleConfig.RegisterBundles(BundleTable.Bundles)
        AuthConfig.RegisterOpenAuth()
        RegisterRoutes(RouteTable.Routes)
    End Sub

    Sub Application_BeginRequest(ByVal sender As Object, ByVal e As EventArgs)
        ' Fires at the beginning of each request
    End Sub

    Sub Application_AuthenticateRequest(ByVal sender As Object, ByVal e As EventArgs)
        ' Fires upon attempting to authenticate the use
    End Sub

    Sub Application_Error(ByVal sender As Object, ByVal e As EventArgs)
        ' Fires when an error occurs
    End Sub

    Sub Application_End(ByVal sender As Object, ByVal e As EventArgs)
        ' Fires when the application ends
    End Sub

    Sub Session_Start(ByVal sender As Object, ByVal e As EventArgs)

        Try

            Dim paivitys As New SopimusarkistoPaivitys(AddressOf Liittymat.Sopimusarkisto.Operaatiot.PaivitaSopimusarkisto)

            If Konfiguraatiot.SopimusarkistoIntegraatioPaalla Then
                paivitys.BeginInvoke(Nothing, Nothing)
            End If

        Catch ex As Exception

        End Try

    End Sub

    Sub Session_End(ByVal sender As Object, ByVal e As EventArgs)

        Try

            Dim tietokanta As New BLL.Poiminta()

            tietokanta.TyhjennaPoiminta(Session.SessionID)

        Catch ex As Exception

        End Try

    End Sub

    Sub RegisterRoutes(routes As RouteCollection)

        routes.MapPageRoute("etusivu", "", "~/Etusivu.aspx", True)

        routes.MapPageRoute("organisaation-nayttaminen", "organisaatio/nayta/{id}", "~/Taho/Organisaatio/Tiedot.aspx", True)
        routes.MapPageRoute("organisaation-haku", "organisaatio/hae/", "~/Taho/Organisaatio/Haku.aspx", True)
        routes.MapPageRoute("organisaation-lisays", "organisaatio/lisaa/", "~/Taho/Organisaatio/Muokkaa.aspx", True)
        routes.MapPageRoute("organisaation-muokkaus", "organisaatio/muokkaa/{id}", "~/Taho/Organisaatio/Muokkaa.aspx", True)

        routes.MapPageRoute("henkilon-nayttaminen", "henkilo/nayta/{id}", "~/Taho/Henkilo/Tiedot.aspx", True)
        routes.MapPageRoute("henkilon-haku", "henkilo/hae/", "~/Taho/Henkilo/Haku.aspx", True)
        routes.MapPageRoute("henkilon-lisays", "henkilo/lisaa/", "~/Taho/Henkilo/Muokkaa.aspx", True)
        routes.MapPageRoute("henkilon-muokkaus", "henkilo/muokkaa/{id}", "~/Taho/Henkilo/Muokkaa.aspx", True)

        routes.MapPageRoute("kiinteiston-nayttaminen", "kiinteisto/nayta/{id}", "~/Kiinteisto/Tiedot.aspx", True)
        routes.MapPageRoute("kiinteiston-haku", "kiinteisto/hae/", "~/Kiinteisto/Haku.aspx", True)
        routes.MapPageRoute("kiinteiston-lisays", "kiinteisto/lisaa/", "~/Kiinteisto/Muokkaa.aspx", True)
        routes.MapPageRoute("kiinteiston-muokkaus", "kiinteisto/muokkaa/{id}", "~/Kiinteisto/Muokkaa.aspx", True)

        routes.MapPageRoute("sopimuksen-nayttaminen", "sopimus/nayta/{id}", "~/Sopimus/JAS/Tiedot.aspx", True)
        routes.MapPageRoute("sopimuksen-haku", "sopimus/hae/", "~/Sopimus/Haku.aspx", True)
        routes.MapPageRoute("sopimuksen-lisays", "sopimus/lisaa/", "~/Sopimus/JAS/Muokkaa.aspx", True)
        routes.MapPageRoute("sopimuksen-muokkaus", "sopimus/muokkaa/{id}", "~/Sopimus/JAS/Muokkaa.aspx", True)


    End Sub

End Class