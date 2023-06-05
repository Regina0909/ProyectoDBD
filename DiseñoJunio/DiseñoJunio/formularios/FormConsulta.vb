Public Class FormConsulta

    Private dPaciente As New PacienteDao
    Private dServicio As New ServicioDao
    Private dConsulta As New ConsultaDao

    Sub LlnerarServicio()

        Try
            Dim dataTable As DataTable = dServicio.MostrarRegistros.Tables(0)
            dataTable.DefaultView.RowFilter = "deleted = 0" ' Filtrar los registros eliminados
            ServicioCbx.DataSource = dataTable.DefaultView
            ServicioCbx.DisplayMember = "nombreServicio"
            ServicioCbx.ValueMember = "servicioID"
            ServicioCbx.Refresh()
        Catch ex As Exception
            MsgBox("Error al mostrar Servicio", MsgBoxStyle.Critical, "Clinica")
        End Try

    End Sub

    Sub LlenarPaciente()

        Try
            Dim dataTable As DataTable = dPaciente.MostrarRegistros.Tables(0)
            dataTable.Columns.Add("nombreCompleto", GetType(String))

            For Each row As DataRow In dataTable.Rows
                Dim nombre As String = row("nombrePaciente").ToString()
                Dim apellido As String = row("apellidoPaciente").ToString()
                row("nombreCompleto") = nombre & " " & apellido
            Next

            dataTable.DefaultView.RowFilter = "deleted = 0" ' Filtrar los registros eliminados
            PacienteCbx.DataSource = dataTable.DefaultView
            PacienteCbx.DisplayMember = "nombreCompleto"
            PacienteCbx.ValueMember = "pacienteID"
            PacienteCbx.Refresh()
        Catch ex As Exception
            MsgBox("Error al mostrar Paciente", MsgBoxStyle.Critical, "Clinica")
        End Try

    End Sub



    Private Sub FormConsulta_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        MostrarRegistros()
        LlenarPaciente()
        LlnerarServicio()

    End Sub

    Sub MostrarRegistros()

        Try
            Dim ds As DataSet = dConsulta.MostrarRegistros()

            ' Asignar el DataTable del DataSet al DataSource del DataGridView
            DGVconsulta.DataSource = ds.Tables(0)
            DGVconsulta.Refresh()

            'DiseñoGrid()
            GroupBox2.Text = "Registros almacenados: " & DGVconsulta.Rows.Count
        Catch ex As Exception
            ' Manejar la excepción aquí...
        End Try
    End Sub

    Private Sub BtnBuscar_Click(sender As Object, e As EventArgs) Handles BtnBuscar.Click

        Dim pacienteID As Integer

        If Integer.TryParse(TxtBuscar.Text.Trim(), pacienteID) Then
            FiltrarRegistrosPorPacienteID(pacienteID)
        Else
            MostrarRegistros() ' Mostrar todos los registros si no se ingresó un ID de paciente válido
        End If
    End Sub

    Private Sub FiltrarRegistrosPorPacienteID(pacienteID As Integer)
        Try
            Dim ds As DataSet = dPaciente.MostrarRegistros()
            Dim dt As DataTable = ds.Tables(0)

            ' Filtrar los registros en el DataTable según el ID del paciente
            Dim dv As New DataView(dt)
            dv.RowFilter = $"pacienteID = {pacienteID}"

            ' Mostrar los registros filtrados en el DataGridView
            DGVconsulta.DataSource = dv
            DGVconsulta.Refresh()

            GroupBox2.Text = "Registros Guardados: " & DGVconsulta.Rows.Count
        Catch ex As Exception
            ' Manejar cualquier excepción que ocurra durante la búsqueda
            MsgBox("Error al buscar registros: " & ex.Message, MsgBoxStyle.Critical, "Clinica")
        End Try

    End Sub

    Private Sub BtnGuardar_Click(sender As Object, e As EventArgs) Handles BtnGuardar.Click

        Try
            Dim consulta As New ConsultaEntidad
            consulta.CantServicios = NumServicios.Value
            consulta.FechaConsulta = DateConsulta.Value



            consulta.servicioID.ServicioID = ServicioCbx.SelectedValue
            consulta.PacienteID.PacienteID = ServicioCbx.SelectedValue




            If (dConsulta.GuardarRegistro(consulta) = True) Then
                MsgBox("Registro guardado satisfactoriamente.", MsgBoxStyle.Information, "Clinica")
            Else
                MsgBox("No se pudo guardar el registro...", MsgBoxStyle.Exclamation, "Clinica")
            End If
        Catch ex As Exception
            MsgBox("Error al guardar registro: " & ex.Message, MsgBoxStyle.Critical, "Clinica")
        End Try
        MostrarRegistros()






    End Sub



    Private Sub BtnEliminar_Click(sender As Object, e As EventArgs) Handles BtnEliminar.Click
        Try
            Dim selectedRow As DataGridViewRow = DGVconsulta.SelectedRows(0)
            Dim consultaID As Integer = CInt(selectedRow.Cells("consultaID").Value)

            If dConsulta.EliminarRegistro(consultaID) Then
                MsgBox("Registro eliminado satisfactoriamente.", MsgBoxStyle.Information, "Clinica")
            Else
                MsgBox("No se pudo eliminar el registro.", MsgBoxStyle.Exclamation, "Clinica")
            End If
        Catch ex As Exception
            MsgBox("Error al eliminar el registro: " & ex.Message, MsgBoxStyle.Critical, "Clinica")
        End Try

        MostrarRegistros()
    End Sub

    Private Sub BtnEditar_Click(sender As Object, e As EventArgs) Handles BtnEditar.Click
        If DGVconsulta.SelectedRows.Count > 0 Then
            Dim consultaID As Integer = CInt(DGVconsulta.SelectedRows(0).Cells("consultaID").Value)

            Dim consulta As New ConsultaEntidad()
            consulta.ConsultaID = consultaID
            consulta.CantServicios = NumServicios.Value
            consulta.FechaConsulta = DateConsulta.Value

            consulta.PacienteID.PacienteID = PacienteCbx.SelectedValue
            consulta.ServicioID.ServicioID = ServicioCbx.SelectedValue




            Try
                Dim resp = dConsulta.EditarRegistro(consulta)
                If (resp) Then
                    MsgBox("Registro editado satisfactoriamente", MsgBoxStyle.Information, "Clinica")
                Else
                    MsgBox("No se pudo editar el registro.", MsgBoxStyle.Exclamation, "Clinica")
                End If
            Catch ex As Exception
                MsgBox("Error al editar el registro: " & ex.Message, MsgBoxStyle.Critical, "Clinica")
            End Try
        Else
            MsgBox("No se ha seleccionado ningún registro para editar.", MsgBoxStyle.Exclamation, "Clinica")
        End If

        MostrarRegistros()
    End Sub

    Private Sub BtnNuevo_Click(sender As Object, e As EventArgs) Handles BtnNuevo.Click

        NumServicios.Value = 0
        DateConsulta.Value = DateTime.Now

        PacienteCbx.SelectedValue = -1
        ServicioCbx.SelectedValue = -1

        BtnEditar.Enabled = False
        BtnEliminar.Enabled = False
        BtnGuardar.Enabled = True



        NumServicios.Select()
        DateConsulta.Select()

    End Sub





    Private Sub DGVconsulta_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DGVconsulta.CellContentClick
        ' Verificar si hay una fila seleccionada en el DataGridView
        If DGVconsulta.SelectedRows.Count > 0 Then
            btnFacturar.Enabled = True ' Habilitar el botón de facturar
        Else
            btnFacturar.Enabled = False ' Deshabilitar el botón de facturar si no hay filas seleccionadas
        End If

    End Sub

    Private Sub btnFacturar_Click(sender As Object, e As EventArgs) Handles btnFacturar.Click

        If DGVconsulta.SelectedRows.Count > 0 Then
            Dim frmFactura As New FormImprimir()

            ' Obtener el valor de la columna "consultaID" de la fila seleccionada en el DataGridView
            Dim consultaID As Integer = Convert.ToInt32(DGVconsulta.SelectedRows(0).Cells("consultaID").Value)

            ' Asignar el valor de consultaID al TextBox "txtConsultaID" en el formulario Factura

            frmFactura.ShowDialog()
        End If


    End Sub

    Private Sub DGVconsulta_SelectionChanged(sender As Object, e As EventArgs) Handles DGVconsulta.SelectionChanged

        If DGVconsulta.SelectedRows.Count > 0 Then
            Dim row As DataGridViewRow = DGVconsulta.SelectedRows(0)

            ' Set the selected value for PacienteCbx ComboBox
            Dim pacienteID As Integer = Convert.ToInt32(row.Cells("PacienteID").Value)
            PacienteCbx.SelectedValue = pacienteID.ToString()

            ' Set the selected value for ServicioCbx ComboBox
            Dim servicioID As Integer = Convert.ToInt32(row.Cells("Servicio").Value)
            ServicioCbx.SelectedValue = servicioID.ToString()

            ' Set the value for NumServicios NumericUpDown control
            If TypeOf row.Cells("cantServicios").Value Is Integer Then
                Dim cantServicios As Integer = Convert.ToInt32(row.Cells("cantServicios").Value)
                NumServicios.Value = cantServicios
            End If

            ' Set the value for DateConsulta DateTimePicker control
            If TypeOf row.Cells("fechaConsulta").Value Is DateTime Then
                Dim fechaConsulta As DateTime = DirectCast(row.Cells("fechaConsulta").Value, DateTime)
                DateConsulta.Value = fechaConsulta
            End If
        End If


    End Sub
End Class