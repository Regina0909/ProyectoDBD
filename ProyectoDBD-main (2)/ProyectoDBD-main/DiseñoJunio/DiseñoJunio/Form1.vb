Imports System.Data.SqlClient
Imports System.Data



Public Class Form1
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Btn_ingresar.Click
        FormOpciones.Show()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs)
        FormPaciente.Show()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs)
        FormUsuario.Show()
    End Sub

    Private Sub Text_usuario_TextChanged(sender As Object, e As EventArgs) Handles Text_usuario.TextChanged

    End Sub

    Private Sub Text_contraseña_TextChanged(sender As Object, e As EventArgs)
        Dim usuario As String = Text_usuario.Text()
        Dim contraseña As String = Text_contraseña.Text()

        If String.IsNullOrEmpty(usuario) OrElse String.IsNullOrEmpty(contraseña) Then
            MessageBox.Show("porfavor llene el campo de usuario y contraseña")
            Return
        End If


        Dim connectionString As String = "Data Source=PC;Initial Catalog=ClinicaBase;Integrated Security=True"
        Dim query As String = "SELECT * FROM Usuario Where nombreUsuario=@nombre AND claveUsuario = @contraseña"
        Using connection As New SqlConnection(connectionString)
            Using Command As New SqlCommand(query, connection)

                Command.Parameters.AddWithValue("@nombre", usuario)
                Command.Parameters.AddWithValue("@contraseña", contraseña)


                Try
                    connection.Open()
                    Dim reader As SqlDataReader = Command.ExecuteReader()

                    If reader.Read() Then
                        MessageBox.Show("Inicio de seccion exitoso")
                        FormOpciones.Show()


                    Else
                        MessageBox.Show("usuario o contraseña incorrectas, xfavor intente nuevamente")

                    End If

                    reader.Close()
                Catch ex As Exception
                    MessageBox.Show("Error: " + ex.Message)
                End Try

            End Using
        End Using
    End Sub
End Class
