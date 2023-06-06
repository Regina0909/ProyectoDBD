Public Class FormImprimir
    Private dFactura As New FacturaDao



    Private Sub FormImprimir_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            Dim factura As New FacturaEntidad
            factura.FechaFactura = DateFactura.Value


            factura.TotalFactura = Decimal.Parse(txtTotal.Text)
            factura.ConsultaID.ConsultaID = txtConsultaID.Text



            If (dFactura.GuardarRegistro(factura) = True) Then
                MsgBox("Registro guardado satisfactoriamente.", MsgBoxStyle.Information, "Clinica")
            Else
                MsgBox("No se pudo guardar el registro...", MsgBoxStyle.Exclamation, "Clinica")
            End If
        Catch ex As Exception
            MsgBox("Error al guardar registro: " & ex.Message, MsgBoxStyle.Critical, "Clinica")
        End Try





    End Sub


End Class