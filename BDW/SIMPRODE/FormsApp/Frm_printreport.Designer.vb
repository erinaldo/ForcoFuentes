Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Windows
Imports CrystalDecisions.Shared
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_printreport
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_printreport))
        Me.Txtarchivo = New System.Windows.Forms.TextBox()
        Me.exportByType = New System.Windows.Forms.Button()
        Me.exportTypesList = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.message = New System.Windows.Forms.Label()
        Me.Visor_Reporte = New CrystalDecisions.Windows.Forms.CrystalReportViewer()
        Me.SuspendLayout()
        '
        'Txtarchivo
        '
        Me.Txtarchivo.Location = New System.Drawing.Point(139, 24)
        Me.Txtarchivo.Name = "Txtarchivo"
        Me.Txtarchivo.Size = New System.Drawing.Size(137, 20)
        Me.Txtarchivo.TabIndex = 9
        '
        'exportByType
        '
        Me.exportByType.Location = New System.Drawing.Point(282, 22)
        Me.exportByType.Name = "exportByType"
        Me.exportByType.Size = New System.Drawing.Size(75, 23)
        Me.exportByType.TabIndex = 8
        Me.exportByType.Text = "Exportar"
        Me.exportByType.UseVisualStyleBackColor = True
        '
        'exportTypesList
        '
        Me.exportTypesList.FormattingEnabled = True
        Me.exportTypesList.Location = New System.Drawing.Point(12, 24)
        Me.exportTypesList.Name = "exportTypesList"
        Me.exportTypesList.Size = New System.Drawing.Size(121, 21)
        Me.exportTypesList.TabIndex = 7
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(136, 7)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(49, 14)
        Me.Label2.TabIndex = 11
        Me.Label2.Text = "Archivo"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 7)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(31, 14)
        Me.Label1.TabIndex = 10
        Me.Label1.Text = "Tipo"
        '
        'message
        '
        Me.message.AutoSize = True
        Me.message.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.message.Location = New System.Drawing.Point(363, 28)
        Me.message.Name = "message"
        Me.message.Size = New System.Drawing.Size(0, 14)
        Me.message.TabIndex = 12
        Me.message.Visible = False
        '
        'Visor_Reporte
        '
        Me.Visor_Reporte.ActiveViewIndex = -1
        Me.Visor_Reporte.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Visor_Reporte.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Visor_Reporte.Cursor = System.Windows.Forms.Cursors.Default
        Me.Visor_Reporte.Location = New System.Drawing.Point(-2, 52)
        Me.Visor_Reporte.Name = "Visor_Reporte"
        Me.Visor_Reporte.Size = New System.Drawing.Size(907, 439)
        Me.Visor_Reporte.TabIndex = 13
        '
        'Frm_printreport
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.BackgroundImage = Global.BDW.My.Resources.Resources._3
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(904, 492)
        Me.Controls.Add(Me.Visor_Reporte)
        Me.Controls.Add(Me.message)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Txtarchivo)
        Me.Controls.Add(Me.exportByType)
        Me.Controls.Add(Me.exportTypesList)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Frm_printreport"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Pantalla de Impresión"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Txtarchivo As System.Windows.Forms.TextBox
    Friend WithEvents exportByType As System.Windows.Forms.Button
    Friend WithEvents exportTypesList As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents message As System.Windows.Forms.Label
    Private WithEvents Visor_Reporte As CrystalDecisions.Windows.Forms.CrystalReportViewer
End Class
