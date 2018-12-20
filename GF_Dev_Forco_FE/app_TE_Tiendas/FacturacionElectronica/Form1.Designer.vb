<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.Timer1 = New System.Windows.Forms.Timer()
        Me.DataGridView2 = New System.Windows.Forms.DataGridView()
        Me.Timer2 = New System.Windows.Forms.Timer()
        Me.btnMensajeRechazados = New System.Windows.Forms.Button()
        Me.btnVerificarEstado = New System.Windows.Forms.Button()
        Me.lblVerificarEstado = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblFecha = New System.Windows.Forms.Label()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(12, 139)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.Size = New System.Drawing.Size(582, 373)
        Me.DataGridView1.TabIndex = 1
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        Me.Timer1.Interval = 60000
        '
        'DataGridView2
        '
        Me.DataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView2.Location = New System.Drawing.Point(618, 55)
        Me.DataGridView2.Name = "DataGridView2"
        Me.DataGridView2.Size = New System.Drawing.Size(575, 457)
        Me.DataGridView2.TabIndex = 2
        '
        'Timer2
        '
        Me.Timer2.Enabled = True
        Me.Timer2.Interval = 3600000
        '
        'btnMensajeRechazados
        '
        Me.btnMensajeRechazados.Location = New System.Drawing.Point(1008, 31)
        Me.btnMensajeRechazados.Name = "btnMensajeRechazados"
        Me.btnMensajeRechazados.Size = New System.Drawing.Size(185, 23)
        Me.btnMensajeRechazados.TabIndex = 3
        Me.btnMensajeRechazados.Text = "Actualizar Mensaje Rechazados"
        Me.btnMensajeRechazados.UseVisualStyleBackColor = True
        '
        'btnVerificarEstado
        '
        Me.btnVerificarEstado.Location = New System.Drawing.Point(1008, 12)
        Me.btnVerificarEstado.Name = "btnVerificarEstado"
        Me.btnVerificarEstado.Size = New System.Drawing.Size(185, 23)
        Me.btnVerificarEstado.TabIndex = 4
        Me.btnVerificarEstado.Text = "Verificar Estado"
        Me.btnVerificarEstado.UseVisualStyleBackColor = True
        '
        'lblVerificarEstado
        '
        Me.lblVerificarEstado.AutoSize = True
        Me.lblVerificarEstado.Location = New System.Drawing.Point(1008, 36)
        Me.lblVerificarEstado.Name = "lblVerificarEstado"
        Me.lblVerificarEstado.Size = New System.Drawing.Size(16, 13)
        Me.lblVerificarEstado.TabIndex = 5
        Me.lblVerificarEstado.Text = "..."
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(850, 24)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "app_TE_Tiendas Modificado Jorge López 17 Diciembre 2018 Menos Sucursales 105 y 13" &
    "0"
        '
        'lblFecha
        '
        Me.lblFecha.AutoSize = True
        Me.lblFecha.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFecha.ForeColor = System.Drawing.Color.White
        Me.lblFecha.Location = New System.Drawing.Point(116, 55)
        Me.lblFecha.Name = "lblFecha"
        Me.lblFecha.Size = New System.Drawing.Size(0, 24)
        Me.lblFecha.TabIndex = 7
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Blue
        Me.ClientSize = New System.Drawing.Size(1156, 544)
        Me.Controls.Add(Me.lblFecha)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.lblVerificarEstado)
        Me.Controls.Add(Me.btnVerificarEstado)
        Me.Controls.Add(Me.btnMensajeRechazados)
        Me.Controls.Add(Me.DataGridView2)
        Me.Controls.Add(Me.DataGridView1)
        Me.ForeColor = System.Drawing.Color.Black
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Tiquete Electrónico - Tiendas (MM, MC, SHOPPERS)"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents Timer1 As Timer
    Friend WithEvents DataGridView2 As DataGridView
    Friend WithEvents Timer2 As Timer
    Friend WithEvents btnMensajeRechazados As Button
    Friend WithEvents btnVerificarEstado As Button
    Friend WithEvents lblVerificarEstado As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents lblFecha As Label
End Class
