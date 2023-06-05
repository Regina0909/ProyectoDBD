<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormImprimir
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.ClinicaBaseDataSet1 = New DiseñoJunio.ClinicaBaseDataSet()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.DateFactura = New System.Windows.Forms.DateTimePicker()
        Me.txtTotal = New System.Windows.Forms.TextBox()
        Me.txtConsultaID = New System.Windows.Forms.TextBox()
        Me.Button1 = New System.Windows.Forms.Button()
        CType(Me.ClinicaBaseDataSet1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(72, 65)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(51, 17)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Fecha:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(72, 127)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(44, 17)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Total:"
        '
        'ClinicaBaseDataSet1
        '
        Me.ClinicaBaseDataSet1.DataSetName = "ClinicaBaseDataSet"
        Me.ClinicaBaseDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(39, 193)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(84, 17)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Consulta ID:"
        '
        'DateFactura
        '
        Me.DateFactura.Location = New System.Drawing.Point(139, 65)
        Me.DateFactura.Name = "DateFactura"
        Me.DateFactura.Size = New System.Drawing.Size(274, 22)
        Me.DateFactura.TabIndex = 3
        '
        'txtTotal
        '
        Me.txtTotal.Location = New System.Drawing.Point(139, 127)
        Me.txtTotal.Name = "txtTotal"
        Me.txtTotal.Size = New System.Drawing.Size(274, 22)
        Me.txtTotal.TabIndex = 4
        '
        'txtConsultaID
        '
        Me.txtConsultaID.Location = New System.Drawing.Point(139, 190)
        Me.txtConsultaID.Name = "txtConsultaID"
        Me.txtConsultaID.Size = New System.Drawing.Size(274, 22)
        Me.txtConsultaID.TabIndex = 5
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(197, 293)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(116, 44)
        Me.Button1.TabIndex = 6
        Me.Button1.Text = "Guardar"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'FormImprimir
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.LightSeaGreen
        Me.ClientSize = New System.Drawing.Size(478, 393)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.txtConsultaID)
        Me.Controls.Add(Me.txtTotal)
        Me.Controls.Add(Me.DateFactura)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Name = "FormImprimir"
        Me.Text = "FormImprimir"
        CType(Me.ClinicaBaseDataSet1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents ClinicaBaseDataSet1 As ClinicaBaseDataSet
    Friend WithEvents Label3 As Label
    Friend WithEvents DateFactura As DateTimePicker
    Friend WithEvents txtTotal As TextBox
    Friend WithEvents txtConsultaID As TextBox
    Friend WithEvents Button1 As Button
End Class
