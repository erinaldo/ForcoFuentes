<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
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
        Me.GroupControl2 = New DevExpress.XtraEditors.GroupControl()
        Me.gcDetalle = New DevExpress.XtraGrid.GridControl()
        Me.gvDetalle = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.lblSubTotal = New System.Windows.Forms.Label()
        Me.LabelControl17 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl10 = New DevExpress.XtraEditors.LabelControl()
        Me.lblTotalNeto = New System.Windows.Forms.Label()
        Me.lblTax = New System.Windows.Forms.Label()
        Me.LabelControl11 = New DevExpress.XtraEditors.LabelControl()
        Me.lblDescuento = New System.Windows.Forms.Label()
        Me.LabelControl12 = New DevExpress.XtraEditors.LabelControl()
        Me.lblTotal = New System.Windows.Forms.Label()
        Me.LabelControl13 = New DevExpress.XtraEditors.LabelControl()
        Me.bbEdit = New DevExpress.XtraEditors.SimpleButton()
        Me.bbAdd = New DevExpress.XtraEditors.SimpleButton()
        Me.bSave = New DevExpress.XtraBars.BarButtonItem()
        Me.DefaultLookAndFeel1 = New DevExpress.LookAndFeel.DefaultLookAndFeel(Me.components)
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.lblDireccion = New System.Windows.Forms.Label()
        Me.LabelControl15 = New DevExpress.XtraEditors.LabelControl()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.LabelControl14 = New DevExpress.XtraEditors.LabelControl()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.LabelControl9 = New DevExpress.XtraEditors.LabelControl()
        Me.lblCorreo = New System.Windows.Forms.Label()
        Me.LabelControl8 = New DevExpress.XtraEditors.LabelControl()
        Me.lblTelefono = New System.Windows.Forms.Label()
        Me.LabelControl7 = New DevExpress.XtraEditors.LabelControl()
        Me.lblCedula = New System.Windows.Forms.Label()
        Me.LabelControl6 = New DevExpress.XtraEditors.LabelControl()
        Me.lkCliente = New DevExpress.XtraEditors.LookUpEdit()
        Me.LabelControl4 = New DevExpress.XtraEditors.LabelControl()
        Me.lkRazon = New DevExpress.XtraEditors.LookUpEdit()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.lkVenta = New DevExpress.XtraEditors.LookUpEdit()
        Me.lblNumero = New System.Windows.Forms.Label()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl5 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl33 = New DevExpress.XtraEditors.LabelControl()
        Me.lkConcepto = New DevExpress.XtraEditors.LookUpEdit()
        Me.dtpFecha = New System.Windows.Forms.DateTimePicker()
        Me.cbDollar = New DevExpress.XtraEditors.CalcEdit()
        Me.LabelControl21 = New DevExpress.XtraEditors.LabelControl()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        CType(Me.RibbonControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GroupControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl2.SuspendLayout()
        CType(Me.gcDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gvDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage1.SuspendLayout()
        CType(Me.lkCliente.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lkRazon.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lkVenta.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lkConcepto.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbDollar.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.RibbonControl1.Size = New System.Drawing.Size(907, 93)
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
        'GroupControl2
        '
        Me.GroupControl2.AppearanceCaption.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.GroupControl2.AppearanceCaption.ForeColor = System.Drawing.Color.White
        Me.GroupControl2.AppearanceCaption.Options.UseFont = True
        Me.GroupControl2.AppearanceCaption.Options.UseForeColor = True
        Me.GroupControl2.Controls.Add(Me.gcDetalle)
        Me.GroupControl2.Location = New System.Drawing.Point(0, 315)
        Me.GroupControl2.LookAndFeel.SkinName = "Office 2016 Dark"
        Me.GroupControl2.LookAndFeel.UseDefaultLookAndFeel = False
        Me.GroupControl2.Name = "GroupControl2"
        Me.GroupControl2.Size = New System.Drawing.Size(907, 286)
        Me.GroupControl2.TabIndex = 15
        Me.GroupControl2.Text = ":: Detalle ::"
        '
        'gcDetalle
        '
        Me.gcDetalle.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gcDetalle.Location = New System.Drawing.Point(2, 21)
        Me.gcDetalle.MainView = Me.gvDetalle
        Me.gcDetalle.Name = "gcDetalle"
        Me.gcDetalle.Size = New System.Drawing.Size(903, 263)
        Me.gcDetalle.TabIndex = 0
        Me.gcDetalle.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.gvDetalle})
        '
        'gvDetalle
        '
        Me.gvDetalle.GridControl = Me.gcDetalle
        Me.gvDetalle.Name = "gvDetalle"
        Me.gvDetalle.OptionsView.ShowGroupPanel = False
        '
        'lblSubTotal
        '
        Me.lblSubTotal.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lblSubTotal.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblSubTotal.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lblSubTotal.Location = New System.Drawing.Point(778, 116)
        Me.lblSubTotal.Name = "lblSubTotal"
        Me.lblSubTotal.Size = New System.Drawing.Size(125, 20)
        Me.lblSubTotal.TabIndex = 327
        Me.lblSubTotal.Text = "0.00"
        Me.lblSubTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LabelControl17
        '
        Me.LabelControl17.Appearance.ForeColor = System.Drawing.Color.Black
        Me.LabelControl17.Location = New System.Drawing.Point(713, 120)
        Me.LabelControl17.Name = "LabelControl17"
        Me.LabelControl17.Size = New System.Drawing.Size(62, 13)
        Me.LabelControl17.TabIndex = 328
        Me.LabelControl17.Text = "SUB-TOTAL :"
        '
        'LabelControl10
        '
        Me.LabelControl10.Appearance.ForeColor = System.Drawing.Color.Black
        Me.LabelControl10.Location = New System.Drawing.Point(706, 200)
        Me.LabelControl10.Name = "LabelControl10"
        Me.LabelControl10.Size = New System.Drawing.Size(69, 13)
        Me.LabelControl10.TabIndex = 326
        Me.LabelControl10.Text = "TOTAL NETO :"
        '
        'lblTotalNeto
        '
        Me.lblTotalNeto.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lblTotalNeto.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblTotalNeto.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lblTotalNeto.Location = New System.Drawing.Point(778, 196)
        Me.lblTotalNeto.Name = "lblTotalNeto"
        Me.lblTotalNeto.Size = New System.Drawing.Size(125, 20)
        Me.lblTotalNeto.TabIndex = 325
        Me.lblTotalNeto.Text = "0.00"
        Me.lblTotalNeto.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblTax
        '
        Me.lblTax.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lblTax.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblTax.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lblTax.Location = New System.Drawing.Point(778, 176)
        Me.lblTax.Name = "lblTax"
        Me.lblTax.Size = New System.Drawing.Size(125, 20)
        Me.lblTax.TabIndex = 323
        Me.lblTax.Text = "0.00"
        Me.lblTax.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LabelControl11
        '
        Me.LabelControl11.Appearance.ForeColor = System.Drawing.Color.Black
        Me.LabelControl11.Location = New System.Drawing.Point(751, 181)
        Me.LabelControl11.Name = "LabelControl11"
        Me.LabelControl11.Size = New System.Drawing.Size(24, 13)
        Me.LabelControl11.TabIndex = 324
        Me.LabelControl11.Text = "IVA :"
        '
        'lblDescuento
        '
        Me.lblDescuento.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lblDescuento.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDescuento.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lblDescuento.Location = New System.Drawing.Point(778, 136)
        Me.lblDescuento.Name = "lblDescuento"
        Me.lblDescuento.Size = New System.Drawing.Size(125, 20)
        Me.lblDescuento.TabIndex = 321
        Me.lblDescuento.Text = "0.00"
        Me.lblDescuento.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LabelControl12
        '
        Me.LabelControl12.Appearance.ForeColor = System.Drawing.Color.Black
        Me.LabelControl12.Location = New System.Drawing.Point(708, 140)
        Me.LabelControl12.Name = "LabelControl12"
        Me.LabelControl12.Size = New System.Drawing.Size(67, 13)
        Me.LabelControl12.TabIndex = 322
        Me.LabelControl12.Text = "DESCUENTO :"
        '
        'lblTotal
        '
        Me.lblTotal.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lblTotal.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblTotal.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lblTotal.Location = New System.Drawing.Point(778, 156)
        Me.lblTotal.Name = "lblTotal"
        Me.lblTotal.Size = New System.Drawing.Size(125, 20)
        Me.lblTotal.TabIndex = 319
        Me.lblTotal.Text = "0.00"
        Me.lblTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LabelControl13
        '
        Me.LabelControl13.Appearance.ForeColor = System.Drawing.Color.Black
        Me.LabelControl13.Location = New System.Drawing.Point(736, 160)
        Me.LabelControl13.Name = "LabelControl13"
        Me.LabelControl13.Size = New System.Drawing.Size(39, 13)
        Me.LabelControl13.TabIndex = 320
        Me.LabelControl13.Text = "TOTAL :"
        '
        'bbEdit
        '
        Me.bbEdit.Location = New System.Drawing.Point(814, 290)
        Me.bbEdit.Name = "bbEdit"
        Me.bbEdit.Size = New System.Drawing.Size(88, 21)
        Me.bbEdit.TabIndex = 334
        Me.bbEdit.Text = "F2 - Editar"
        '
        'bbAdd
        '
        Me.bbAdd.Location = New System.Drawing.Point(723, 290)
        Me.bbAdd.Name = "bbAdd"
        Me.bbAdd.Size = New System.Drawing.Size(88, 21)
        Me.bbAdd.TabIndex = 333
        Me.bbAdd.Text = "F1 - Agregar"
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
        Me.TabPage1.Controls.Add(Me.lblDireccion)
        Me.TabPage1.Controls.Add(Me.LabelControl15)
        Me.TabPage1.Controls.Add(Me.Label5)
        Me.TabPage1.Controls.Add(Me.LabelControl14)
        Me.TabPage1.Controls.Add(Me.Label4)
        Me.TabPage1.Controls.Add(Me.LabelControl9)
        Me.TabPage1.Controls.Add(Me.lblCorreo)
        Me.TabPage1.Controls.Add(Me.LabelControl8)
        Me.TabPage1.Controls.Add(Me.lblTelefono)
        Me.TabPage1.Controls.Add(Me.LabelControl7)
        Me.TabPage1.Controls.Add(Me.lblCedula)
        Me.TabPage1.Controls.Add(Me.LabelControl6)
        Me.TabPage1.Controls.Add(Me.lkCliente)
        Me.TabPage1.Controls.Add(Me.LabelControl4)
        Me.TabPage1.Controls.Add(Me.lkRazon)
        Me.TabPage1.Controls.Add(Me.LabelControl1)
        Me.TabPage1.Controls.Add(Me.lkVenta)
        Me.TabPage1.Controls.Add(Me.lblNumero)
        Me.TabPage1.Controls.Add(Me.LabelControl3)
        Me.TabPage1.Controls.Add(Me.LabelControl2)
        Me.TabPage1.Controls.Add(Me.LabelControl5)
        Me.TabPage1.Controls.Add(Me.LabelControl33)
        Me.TabPage1.Controls.Add(Me.lkConcepto)
        Me.TabPage1.Controls.Add(Me.dtpFecha)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(693, 195)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "General"
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
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label5.Location = New System.Drawing.Point(84, 158)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(323, 20)
        Me.Label5.TabIndex = 375
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label5.Visible = False
        '
        'LabelControl14
        '
        Me.LabelControl14.Appearance.ForeColor = System.Drawing.Color.Black
        Me.LabelControl14.Location = New System.Drawing.Point(41, 162)
        Me.LabelControl14.Name = "LabelControl14"
        Me.LabelControl14.Size = New System.Drawing.Size(34, 13)
        Me.LabelControl14.TabIndex = 376
        Me.LabelControl14.Text = "Clave :"
        Me.LabelControl14.Visible = False
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label4.Location = New System.Drawing.Point(84, 134)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(323, 20)
        Me.Label4.TabIndex = 373
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label4.Visible = False
        '
        'LabelControl9
        '
        Me.LabelControl9.Appearance.ForeColor = System.Drawing.Color.Black
        Me.LabelControl9.Location = New System.Drawing.Point(9, 138)
        Me.LabelControl9.Name = "LabelControl9"
        Me.LabelControl9.Size = New System.Drawing.Size(66, 13)
        Me.LabelControl9.TabIndex = 374
        Me.LabelControl9.Text = "Consecutivo :"
        Me.LabelControl9.Visible = False
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
        'lkRazon
        '
        Me.lkRazon.Location = New System.Drawing.Point(84, 58)
        Me.lkRazon.Name = "lkRazon"
        Me.lkRazon.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.lkRazon.Properties.NullText = ""
        Me.lkRazon.Size = New System.Drawing.Size(257, 20)
        Me.lkRazon.TabIndex = 364
        '
        'LabelControl1
        '
        Me.LabelControl1.Appearance.ForeColor = System.Drawing.Color.Black
        Me.LabelControl1.Location = New System.Drawing.Point(17, 87)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(58, 13)
        Me.LabelControl1.TabIndex = 310
        Me.LabelControl1.Text = "Tipo Venta :"
        '
        'lkVenta
        '
        Me.lkVenta.Location = New System.Drawing.Point(84, 84)
        Me.lkVenta.Name = "lkVenta"
        Me.lkVenta.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.lkVenta.Properties.NullText = ""
        Me.lkVenta.Size = New System.Drawing.Size(120, 20)
        Me.lkVenta.TabIndex = 309
        '
        'lblNumero
        '
        Me.lblNumero.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lblNumero.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblNumero.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lblNumero.Location = New System.Drawing.Point(84, 110)
        Me.lblNumero.Name = "lblNumero"
        Me.lblNumero.Size = New System.Drawing.Size(118, 20)
        Me.lblNumero.TabIndex = 3
        Me.lblNumero.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LabelControl3
        '
        Me.LabelControl3.Appearance.ForeColor = System.Drawing.Color.Black
        Me.LabelControl3.Location = New System.Drawing.Point(25, 63)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(50, 13)
        Me.LabelControl3.TabIndex = 353
        Me.LabelControl3.Text = "Sociedad :"
        '
        'LabelControl2
        '
        Me.LabelControl2.Appearance.ForeColor = System.Drawing.Color.Black
        Me.LabelControl2.Location = New System.Drawing.Point(31, 114)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(44, 13)
        Me.LabelControl2.TabIndex = 306
        Me.LabelControl2.Text = "Factura :"
        '
        'LabelControl5
        '
        Me.LabelControl5.Appearance.ForeColor = System.Drawing.Color.Black
        Me.LabelControl5.Location = New System.Drawing.Point(22, 36)
        Me.LabelControl5.Name = "LabelControl5"
        Me.LabelControl5.Size = New System.Drawing.Size(53, 13)
        Me.LabelControl5.TabIndex = 308
        Me.LabelControl5.Text = "Concepto :"
        '
        'LabelControl33
        '
        Me.LabelControl33.Appearance.ForeColor = System.Drawing.Color.Black
        Me.LabelControl33.Location = New System.Drawing.Point(39, 11)
        Me.LabelControl33.Name = "LabelControl33"
        Me.LabelControl33.Size = New System.Drawing.Size(36, 13)
        Me.LabelControl33.TabIndex = 247
        Me.LabelControl33.Text = "Fecha :"
        '
        'lkConcepto
        '
        Me.lkConcepto.Enabled = False
        Me.lkConcepto.Location = New System.Drawing.Point(84, 33)
        Me.lkConcepto.Name = "lkConcepto"
        Me.lkConcepto.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.lkConcepto.Properties.NullText = ""
        Me.lkConcepto.Size = New System.Drawing.Size(120, 20)
        Me.lkConcepto.TabIndex = 2
        '
        'dtpFecha
        '
        Me.dtpFecha.Enabled = False
        Me.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFecha.Location = New System.Drawing.Point(84, 7)
        Me.dtpFecha.Name = "dtpFecha"
        Me.dtpFecha.Size = New System.Drawing.Size(120, 20)
        Me.dtpFecha.TabIndex = 4
        '
        'cbDollar
        '
        Me.cbDollar.EditValue = New Decimal(New Integer() {700, 0, 0, 0})
        Me.cbDollar.Location = New System.Drawing.Point(781, 242)
        Me.cbDollar.Name = "cbDollar"
        Me.cbDollar.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cbDollar.Properties.DisplayFormat.FormatString = "n2"
        Me.cbDollar.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.cbDollar.Properties.EditFormat.FormatString = "n2"
        Me.cbDollar.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.cbDollar.Size = New System.Drawing.Size(120, 20)
        Me.cbDollar.TabIndex = 402
        '
        'LabelControl21
        '
        Me.LabelControl21.Appearance.ForeColor = System.Drawing.Color.Black
        Me.LabelControl21.Location = New System.Drawing.Point(719, 245)
        Me.LabelControl21.Name = "LabelControl21"
        Me.LabelControl21.Size = New System.Drawing.Size(57, 13)
        Me.LabelControl21.TabIndex = 403
        Me.LabelControl21.Text = "T.CAMBIO :"
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
        Me.ClientSize = New System.Drawing.Size(907, 602)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.bbEdit)
        Me.Controls.Add(Me.cbDollar)
        Me.Controls.Add(Me.LabelControl21)
        Me.Controls.Add(Me.bbAdd)
        Me.Controls.Add(Me.lblSubTotal)
        Me.Controls.Add(Me.LabelControl17)
        Me.Controls.Add(Me.LabelControl10)
        Me.Controls.Add(Me.lblTotalNeto)
        Me.Controls.Add(Me.lblTax)
        Me.Controls.Add(Me.LabelControl11)
        Me.Controls.Add(Me.lblDescuento)
        Me.Controls.Add(Me.LabelControl12)
        Me.Controls.Add(Me.lblTotal)
        Me.Controls.Add(Me.LabelControl13)
        Me.Controls.Add(Me.GroupControl2)
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
        CType(Me.GroupControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl2.ResumeLayout(False)
        CType(Me.gcDetalle, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gvDetalle, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        CType(Me.lkCliente.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lkRazon.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lkVenta.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lkConcepto.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbDollar.Properties, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents GroupControl2 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents gcDetalle As DevExpress.XtraGrid.GridControl
    Friend WithEvents gvDetalle As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents lblSubTotal As System.Windows.Forms.Label
    Friend WithEvents LabelControl17 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl10 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lblTotalNeto As System.Windows.Forms.Label
    Friend WithEvents lblTax As System.Windows.Forms.Label
    Friend WithEvents LabelControl11 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lblDescuento As System.Windows.Forms.Label
    Friend WithEvents LabelControl12 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lblTotal As System.Windows.Forms.Label
    Friend WithEvents LabelControl13 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents bbEdit As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents bbAdd As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents txtStatus As DevExpress.XtraBars.BarStaticItem
    Friend WithEvents bSave As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents DefaultLookAndFeel1 As DevExpress.LookAndFeel.DefaultLookAndFeel
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lkVenta As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents LabelControl5 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lblNumero As Label
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lkConcepto As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents LabelControl33 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents dtpFecha As DateTimePicker
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents lblCorreo As Label
    Friend WithEvents LabelControl8 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lblTelefono As Label
    Friend WithEvents LabelControl7 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lblCedula As Label
    Friend WithEvents LabelControl6 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lkCliente As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents LabelControl4 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lkRazon As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents Label5 As Label
    Friend WithEvents LabelControl14 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents Label4 As Label
    Friend WithEvents LabelControl9 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents cbDollar As DevExpress.XtraEditors.CalcEdit
    Friend WithEvents LabelControl21 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lblDireccion As Label
    Friend WithEvents LabelControl15 As DevExpress.XtraEditors.LabelControl
End Class
