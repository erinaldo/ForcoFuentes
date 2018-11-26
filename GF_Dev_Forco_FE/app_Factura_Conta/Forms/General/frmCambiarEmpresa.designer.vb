<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCambiarEmpresa
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
        Me.components = New System.ComponentModel.Container
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCambiarEmpresa))
        Me.dgvEmpresas = New System.Windows.Forms.DataGridView
        Me.nActiva = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.nCodigo = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.strNombre = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.nMoneda = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip
        Me.nRegistros = New System.Windows.Forms.ToolStripStatusLabel
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.cmdSalir = New System.Windows.Forms.Button
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn
        CType(Me.dgvEmpresas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'dgvEmpresas
        '
        Me.dgvEmpresas.AllowUserToAddRows = False
        Me.dgvEmpresas.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.SkyBlue
        Me.dgvEmpresas.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvEmpresas.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgvEmpresas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgvEmpresas.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.nActiva, Me.nCodigo, Me.strNombre, Me.nMoneda})
        Me.dgvEmpresas.Location = New System.Drawing.Point(0, 0)
        Me.dgvEmpresas.MultiSelect = False
        Me.dgvEmpresas.Name = "dgvEmpresas"
        Me.dgvEmpresas.RowHeadersWidth = 25
        Me.dgvEmpresas.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.dgvEmpresas.RowTemplate.Height = 20
        Me.dgvEmpresas.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvEmpresas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.dgvEmpresas.Size = New System.Drawing.Size(538, 205)
        Me.dgvEmpresas.TabIndex = 3
        '
        'nActiva
        '
        Me.nActiva.HeaderText = "Activa"
        Me.nActiva.Name = "nActiva"
        Me.nActiva.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.nActiva.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.nActiva.Width = 60
        '
        'nCodigo
        '
        Me.nCodigo.HeaderText = "Código"
        Me.nCodigo.Name = "nCodigo"
        Me.nCodigo.ReadOnly = True
        Me.nCodigo.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.nCodigo.Width = 80
        '
        'strNombre
        '
        Me.strNombre.HeaderText = "Nombre"
        Me.strNombre.Name = "strNombre"
        Me.strNombre.ReadOnly = True
        Me.strNombre.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.strNombre.Width = 350
        '
        'nMoneda
        '
        Me.nMoneda.HeaderText = "Moneda"
        Me.nMoneda.Name = "nMoneda"
        Me.nMoneda.ReadOnly = True
        Me.nMoneda.Visible = False
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.nRegistros})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 236)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(541, 22)
        Me.StatusStrip1.TabIndex = 17
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'nRegistros
        '
        Me.nRegistros.BackColor = System.Drawing.Color.Transparent
        Me.nRegistros.Name = "nRegistros"
        Me.nRegistros.Size = New System.Drawing.Size(62, 17)
        Me.nRegistros.Text = "nRegistros"
        '
        'cmdSalir
        '
        Me.cmdSalir.Location = New System.Drawing.Point(3, 208)
        Me.cmdSalir.Name = "cmdSalir"
        Me.cmdSalir.Size = New System.Drawing.Size(63, 23)
        Me.cmdSalir.TabIndex = 19
        Me.cmdSalir.Text = "Salir"
        Me.cmdSalir.UseVisualStyleBackColor = True
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.HeaderText = "Código"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        Me.DataGridViewTextBoxColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridViewTextBoxColumn1.Width = 80
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.HeaderText = "Nombre"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        Me.DataGridViewTextBoxColumn2.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridViewTextBoxColumn2.Width = 350
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.HeaderText = "Moneda"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.ReadOnly = True
        Me.DataGridViewTextBoxColumn3.Visible = False
        '
        'frmCambiarEmpresa
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(541, 258)
        Me.ControlBox = False
        Me.Controls.Add(Me.cmdSalir)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.dgvEmpresas)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmCambiarEmpresa"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Empresas"
        CType(Me.dgvEmpresas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dgvEmpresas As System.Windows.Forms.DataGridView
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents nRegistros As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents cmdSalir As System.Windows.Forms.Button
    Friend WithEvents nCodigo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents strNombre As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents nActiva As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents nMoneda As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn

End Class
