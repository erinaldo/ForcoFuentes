<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_exportreport
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
        Me.Txtbodega = New System.Windows.Forms.TextBox()
        Me.b_generatodo = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtnombre = New System.Windows.Forms.TextBox()
        Me.message = New System.Windows.Forms.Label()
        Me.b_genera = New System.Windows.Forms.Button()
        Me.cmb_bodegas = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'Txtbodega
        '
        Me.Txtbodega.Location = New System.Drawing.Point(105, 53)
        Me.Txtbodega.Name = "Txtbodega"
        Me.Txtbodega.Size = New System.Drawing.Size(56, 20)
        Me.Txtbodega.TabIndex = 9
        '
        'b_generatodo
        '
        Me.b_generatodo.Location = New System.Drawing.Point(205, 106)
        Me.b_generatodo.Name = "b_generatodo"
        Me.b_generatodo.Size = New System.Drawing.Size(95, 23)
        Me.b_generatodo.TabIndex = 8
        Me.b_generatodo.Text = "Generar Todo"
        Me.b_generatodo.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.White
        Me.Label2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(43, 56)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(48, 14)
        Me.Label2.TabIndex = 11
        Me.Label2.Text = "Bodega"
        '
        'txtnombre
        '
        Me.txtnombre.Location = New System.Drawing.Point(167, 53)
        Me.txtnombre.Name = "txtnombre"
        Me.txtnombre.Size = New System.Drawing.Size(169, 20)
        Me.txtnombre.TabIndex = 13
        '
        'message
        '
        Me.message.AutoSize = True
        Me.message.Location = New System.Drawing.Point(264, 83)
        Me.message.Name = "message"
        Me.message.Size = New System.Drawing.Size(0, 13)
        Me.message.TabIndex = 14
        '
        'b_genera
        '
        Me.b_genera.Location = New System.Drawing.Point(104, 106)
        Me.b_genera.Name = "b_genera"
        Me.b_genera.Size = New System.Drawing.Size(95, 23)
        Me.b_genera.TabIndex = 8
        Me.b_genera.Text = "Generar"
        Me.b_genera.UseVisualStyleBackColor = True
        '
        'cmb_bodegas
        '
        Me.cmb_bodegas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_bodegas.FormattingEnabled = True
        Me.cmb_bodegas.Location = New System.Drawing.Point(105, 20)
        Me.cmb_bodegas.Name = "cmb_bodegas"
        Me.cmb_bodegas.Size = New System.Drawing.Size(231, 21)
        Me.cmb_bodegas.TabIndex = 15
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.White
        Me.Label1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(43, 23)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(55, 14)
        Me.Label1.TabIndex = 11
        Me.Label1.Text = "Bodegas"
        '
        'Frm_exportreport
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.SIMPRODE.My.Resources.Resources._3
        Me.ClientSize = New System.Drawing.Size(401, 141)
        Me.Controls.Add(Me.cmb_bodegas)
        Me.Controls.Add(Me.message)
        Me.Controls.Add(Me.txtnombre)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Txtbodega)
        Me.Controls.Add(Me.b_genera)
        Me.Controls.Add(Me.b_generatodo)
        Me.Name = "Frm_exportreport"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Reporte Comparativo Tiendas"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Txtbodega As System.Windows.Forms.TextBox
    Friend WithEvents b_generatodo As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtnombre As System.Windows.Forms.TextBox
    Friend WithEvents message As System.Windows.Forms.Label
    Friend WithEvents b_genera As System.Windows.Forms.Button
    Friend WithEvents cmb_bodegas As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
End Class
