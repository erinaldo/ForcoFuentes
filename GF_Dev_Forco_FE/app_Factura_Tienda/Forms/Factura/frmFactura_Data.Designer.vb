﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmFactura_Data
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmFactura_Data))
        Me.RibbonControl1 = New DevExpress.XtraBars.Ribbon.RibbonControl()
        Me.bClose = New DevExpress.XtraBars.BarButtonItem()
        Me.bbSave = New DevExpress.XtraBars.BarButtonItem()
        Me.barText = New DevExpress.XtraBars.BarStaticItem()
        Me.txtStatus = New DevExpress.XtraBars.BarStaticItem()
        Me.RibbonPage1 = New DevExpress.XtraBars.Ribbon.RibbonPage()
        Me.RibbonPageGroup2 = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.bSave = New DevExpress.XtraBars.BarButtonItem()
        Me.DefaultLookAndFeel1 = New DevExpress.LookAndFeel.DefaultLookAndFeel(Me.components)
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.txtFactura = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        Me.txtCaja = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.txtSucursal = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.lblDireccion = New System.Windows.Forms.Label()
        Me.LabelControl15 = New DevExpress.XtraEditors.LabelControl()
        Me.lblCorreo = New System.Windows.Forms.Label()
        Me.LabelControl8 = New DevExpress.XtraEditors.LabelControl()
        Me.lblTelefono = New System.Windows.Forms.Label()
        Me.LabelControl7 = New DevExpress.XtraEditors.LabelControl()
        Me.lblCedula = New System.Windows.Forms.Label()
        Me.LabelControl6 = New DevExpress.XtraEditors.LabelControl()
        Me.lkCliente = New DevExpress.XtraEditors.LookUpEdit()
        Me.LabelControl4 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl33 = New DevExpress.XtraEditors.LabelControl()
        Me.dtpFecha = New System.Windows.Forms.DateTimePicker()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        CType(Me.RibbonControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage1.SuspendLayout()
        CType(Me.txtFactura.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCaja.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtSucursal.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lkCliente.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabControl1.SuspendLayout()
        Me.SuspendLayout()
        '
        'RibbonControl1
        '
        Me.RibbonControl1.ApplicationButtonText = Nothing
        Me.RibbonControl1.ExpandCollapseItem.Id = 0
        Me.RibbonControl1.Items.AddRange(New DevExpress.XtraBars.BarItem() {Me.RibbonControl1.ExpandCollapseItem, Me.bClose, Me.bbSave, Me.barText, Me.txtStatus})
        Me.RibbonControl1.Location = New System.Drawing.Point(0, 0)
        Me.RibbonControl1.MaxItemId = 27
        Me.RibbonControl1.Name = "RibbonControl1"
        Me.RibbonControl1.Pages.AddRange(New DevExpress.XtraBars.Ribbon.RibbonPage() {Me.RibbonPage1})
        Me.RibbonControl1.ShowPageHeadersMode = DevExpress.XtraBars.Ribbon.ShowPageHeadersMode.Hide
        Me.RibbonControl1.Size = New System.Drawing.Size(705, 93)
        Me.RibbonControl1.ToolbarLocation = DevExpress.XtraBars.Ribbon.RibbonQuickAccessToolbarLocation.Hidden
        '
        'bClose
        '
        Me.bClose.Caption = "Salir"
        Me.bClose.Id = 21
        Me.bClose.LargeGlyph = CType(resources.GetObject("bClose.LargeGlyph"), System.Drawing.Image)
        Me.bClose.Name = "bClose"
        '
        'bbSave
        '
        Me.bbSave.Caption = "Guardar"
        Me.bbSave.Id = 22
        Me.bbSave.LargeGlyph = CType(resources.GetObject("bbSave.LargeGlyph"), System.Drawing.Image)
        Me.bbSave.Name = "bbSave"
        '
        'barText
        '
        Me.barText.Caption = "Estado"
        Me.barText.Id = 25
        Me.barText.Name = "barText"
        Me.barText.TextAlignment = System.Drawing.StringAlignment.Near
        '
        'txtStatus
        '
        Me.txtStatus.Caption = "txtStatus"
        Me.txtStatus.Id = 26
        Me.txtStatus.Name = "txtStatus"
        Me.txtStatus.TextAlignment = System.Drawing.StringAlignment.Near
        '
        'RibbonPage1
        '
        Me.RibbonPage1.Groups.AddRange(New DevExpress.XtraBars.Ribbon.RibbonPageGroup() {Me.RibbonPageGroup2})
        Me.RibbonPage1.Name = "RibbonPage1"
        Me.RibbonPage1.Text = "Catálogo de Cuentas"
        '
        'RibbonPageGroup2
        '
        Me.RibbonPageGroup2.ItemLinks.Add(Me.bbSave)
        Me.RibbonPageGroup2.ItemLinks.Add(Me.bClose)
        Me.RibbonPageGroup2.Name = "RibbonPageGroup2"
        Me.RibbonPageGroup2.ShowCaptionButton = False
        '
        'bSave
        '
        Me.bSave.Caption = "Guardar"
        Me.bSave.Id = 22
        Me.bSave.LargeGlyph = CType(resources.GetObject("bSave.LargeGlyph"), System.Drawing.Image)
        Me.bSave.Name = "bSave"
        '
        'DefaultLookAndFeel1
        '
        Me.DefaultLookAndFeel1.LookAndFeel.SkinName = "Money Twins"
        '
        'TabPage1
        '
        Me.TabPage1.BackColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.TabPage1.Controls.Add(Me.txtFactura)
        Me.TabPage1.Controls.Add(Me.LabelControl3)
        Me.TabPage1.Controls.Add(Me.txtCaja)
        Me.TabPage1.Controls.Add(Me.LabelControl2)
        Me.TabPage1.Controls.Add(Me.txtSucursal)
        Me.TabPage1.Controls.Add(Me.LabelControl1)
        Me.TabPage1.Controls.Add(Me.lblDireccion)
        Me.TabPage1.Controls.Add(Me.LabelControl15)
        Me.TabPage1.Controls.Add(Me.lblCorreo)
        Me.TabPage1.Controls.Add(Me.LabelControl8)
        Me.TabPage1.Controls.Add(Me.lblTelefono)
        Me.TabPage1.Controls.Add(Me.LabelControl7)
        Me.TabPage1.Controls.Add(Me.lblCedula)
        Me.TabPage1.Controls.Add(Me.LabelControl6)
        Me.TabPage1.Controls.Add(Me.lkCliente)
        Me.TabPage1.Controls.Add(Me.LabelControl4)
        Me.TabPage1.Controls.Add(Me.LabelControl33)
        Me.TabPage1.Controls.Add(Me.dtpFecha)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(693, 195)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "General"
        '
        'txtFactura
        '
        Me.txtFactura.Location = New System.Drawing.Point(65, 81)
        Me.txtFactura.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtFactura.Name = "txtFactura"
        Me.txtFactura.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtFactura.Properties.MaxLength = 20
        Me.txtFactura.Size = New System.Drawing.Size(118, 20)
        Me.txtFactura.TabIndex = 3
        '
        'LabelControl3
        '
        Me.LabelControl3.Location = New System.Drawing.Point(11, 84)
        Me.LabelControl3.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(44, 13)
        Me.LabelControl3.TabIndex = 410
        Me.LabelControl3.Text = "Factura :"
        '
        'txtCaja
        '
        Me.txtCaja.Location = New System.Drawing.Point(65, 56)
        Me.txtCaja.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtCaja.Name = "txtCaja"
        Me.txtCaja.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCaja.Properties.MaxLength = 20
        Me.txtCaja.Size = New System.Drawing.Size(118, 20)
        Me.txtCaja.TabIndex = 2
        '
        'LabelControl2
        '
        Me.LabelControl2.Location = New System.Drawing.Point(26, 59)
        Me.LabelControl2.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(29, 13)
        Me.LabelControl2.TabIndex = 408
        Me.LabelControl2.Text = "Caja :"
        '
        'txtSucursal
        '
        Me.txtSucursal.EditValue = ""
        Me.txtSucursal.Location = New System.Drawing.Point(65, 32)
        Me.txtSucursal.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtSucursal.Name = "txtSucursal"
        Me.txtSucursal.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtSucursal.Properties.MaxLength = 20
        Me.txtSucursal.Size = New System.Drawing.Size(118, 20)
        Me.txtSucursal.TabIndex = 1
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(8, 35)
        Me.LabelControl1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(47, 13)
        Me.LabelControl1.TabIndex = 406
        Me.LabelControl1.Text = "Sucursal :"
        '
        'lblDireccion
        '
        Me.lblDireccion.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lblDireccion.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDireccion.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lblDireccion.Location = New System.Drawing.Point(425, 104)
        Me.lblDireccion.Name = "lblDireccion"
        Me.lblDireccion.Size = New System.Drawing.Size(257, 82)
        Me.lblDireccion.TabIndex = 404
        Me.lblDireccion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LabelControl15
        '
        Me.LabelControl15.Appearance.ForeColor = System.Drawing.Color.Black
        Me.LabelControl15.Location = New System.Drawing.Point(365, 108)
        Me.LabelControl15.Name = "LabelControl15"
        Me.LabelControl15.Size = New System.Drawing.Size(50, 13)
        Me.LabelControl15.TabIndex = 405
        Me.LabelControl15.Text = "Dirección :"
        '
        'lblCorreo
        '
        Me.lblCorreo.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lblCorreo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblCorreo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lblCorreo.Location = New System.Drawing.Point(425, 79)
        Me.lblCorreo.Name = "lblCorreo"
        Me.lblCorreo.Size = New System.Drawing.Size(257, 20)
        Me.lblCorreo.TabIndex = 371
        Me.lblCorreo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LabelControl8
        '
        Me.LabelControl8.Appearance.ForeColor = System.Drawing.Color.Black
        Me.LabelControl8.Location = New System.Drawing.Point(375, 83)
        Me.LabelControl8.Name = "LabelControl8"
        Me.LabelControl8.Size = New System.Drawing.Size(40, 13)
        Me.LabelControl8.TabIndex = 372
        Me.LabelControl8.Text = "Correo :"
        '
        'lblTelefono
        '
        Me.lblTelefono.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lblTelefono.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblTelefono.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lblTelefono.Location = New System.Drawing.Point(425, 55)
        Me.lblTelefono.Name = "lblTelefono"
        Me.lblTelefono.Size = New System.Drawing.Size(163, 20)
        Me.lblTelefono.TabIndex = 369
        Me.lblTelefono.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LabelControl7
        '
        Me.LabelControl7.Appearance.ForeColor = System.Drawing.Color.Black
        Me.LabelControl7.Location = New System.Drawing.Point(366, 59)
        Me.LabelControl7.Name = "LabelControl7"
        Me.LabelControl7.Size = New System.Drawing.Size(49, 13)
        Me.LabelControl7.TabIndex = 370
        Me.LabelControl7.Text = "Teléfono :"
        '
        'lblCedula
        '
        Me.lblCedula.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lblCedula.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblCedula.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lblCedula.Location = New System.Drawing.Point(425, 31)
        Me.lblCedula.Name = "lblCedula"
        Me.lblCedula.Size = New System.Drawing.Size(163, 20)
        Me.lblCedula.TabIndex = 367
        Me.lblCedula.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LabelControl6
        '
        Me.LabelControl6.Appearance.ForeColor = System.Drawing.Color.Black
        Me.LabelControl6.Location = New System.Drawing.Point(358, 35)
        Me.LabelControl6.Name = "LabelControl6"
        Me.LabelControl6.Size = New System.Drawing.Size(57, 13)
        Me.LabelControl6.TabIndex = 368
        Me.LabelControl6.Text = "C. Juridica :"
        '
        'lkCliente
        '
        Me.lkCliente.Location = New System.Drawing.Point(425, 7)
        Me.lkCliente.Name = "lkCliente"
        Me.lkCliente.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.lkCliente.Properties.NullText = ""
        Me.lkCliente.Size = New System.Drawing.Size(257, 20)
        Me.lkCliente.TabIndex = 366
        '
        'LabelControl4
        '
        Me.LabelControl4.Appearance.ForeColor = System.Drawing.Color.Black
        Me.LabelControl4.Location = New System.Drawing.Point(364, 12)
        Me.LabelControl4.Name = "LabelControl4"
        Me.LabelControl4.Size = New System.Drawing.Size(51, 13)
        Me.LabelControl4.TabIndex = 365
        Me.LabelControl4.Text = "Receptor :"
        '
        'LabelControl33
        '
        Me.LabelControl33.Appearance.ForeColor = System.Drawing.Color.Black
        Me.LabelControl33.Location = New System.Drawing.Point(19, 11)
        Me.LabelControl33.Name = "LabelControl33"
        Me.LabelControl33.Size = New System.Drawing.Size(36, 13)
        Me.LabelControl33.TabIndex = 247
        Me.LabelControl33.Text = "Fecha :"
        '
        'dtpFecha
        '
        Me.dtpFecha.Enabled = False
        Me.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFecha.Location = New System.Drawing.Point(65, 7)
        Me.dtpFecha.Name = "dtpFecha"
        Me.dtpFecha.Size = New System.Drawing.Size(120, 20)
        Me.dtpFecha.TabIndex = 0
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Location = New System.Drawing.Point(1, 94)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(701, 221)
        Me.TabControl1.TabIndex = 356
        '
        'frmFactura_Data
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(705, 319)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.RibbonControl1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmFactura_Data"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = ":: Facturación ::"
        CType(Me.RibbonControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        CType(Me.txtFactura.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCaja.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtSucursal.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lkCliente.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabControl1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents RibbonControl1 As DevExpress.XtraBars.Ribbon.RibbonControl
    Friend WithEvents bClose As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents bbSave As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents barText As DevExpress.XtraBars.BarStaticItem
    Friend WithEvents RibbonPage1 As DevExpress.XtraBars.Ribbon.RibbonPage
    Friend WithEvents RibbonPageGroup2 As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents txtStatus As DevExpress.XtraBars.BarStaticItem
    Friend WithEvents bSave As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents DefaultLookAndFeel1 As DevExpress.LookAndFeel.DefaultLookAndFeel
    Friend WithEvents LabelControl33 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents dtpFecha As DateTimePicker
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents lblCorreo As Label
    Friend WithEvents LabelControl8 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lblTelefono As Label
    Friend WithEvents LabelControl7 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lblCedula As Label
    Friend WithEvents LabelControl6 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lkCliente As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents LabelControl4 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lblDireccion As Label
    Friend WithEvents LabelControl15 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtFactura As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtCaja As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtSucursal As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
End Class
