Imports System.Data.SqlClient

Public Class Form1
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub BtnIngresar_Click(sender As Object, e As EventArgs) Handles BtnIngresar.Click

        Dim nombreUsuario As String = txtNombreUsuario.Text.Trim()
        Dim claveUsuario As String = txtClaveUsuario.Text.Trim()

        Dim usuarioDao As New UsuarioDao()
        Dim usuario As UsuarioEntidad = usuarioDao.BuscarRegistro(nombreUsuario)

        If usuario IsNot Nothing AndAlso usuario.ClaveUsuario = claveUsuario Then
            ' Usuario y contraseña coinciden, inicio de sesión exitoso
            MessageBox.Show("Inicio de sesión exitoso.")
            FormOpciones.Show()
            ' Aquí puedes abrir el formulario principal o realizar otras acciones necesarias
        Else
            ' Usuario o contraseña incorrectos
            MessageBox.Show("Usuario o contraseña incorrectos.")
        End If
        'FormOpciones.Show()

    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub

    Private Sub txtNombreUsuario_TextChanged(sender As Object, e As EventArgs) Handles txtNombreUsuario.TextChanged

    End Sub
End Class
