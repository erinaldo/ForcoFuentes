<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmOrden_Data
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmOrden_Data))
        Me.RibbonControl1 = New DevExpress.XtraBars.Ribbon.RibbonControl()
        Me.bbClose = New DevExpress.XtraBars.BarButtonItem()
        Me.bbSave = New DevExpress.XtraBars.BarButtonItem()
        Me.barText = New DevExpress.XtraBars.BarStaticItem()
        Me.txtStatus = New DevExpress.XtraBars.BarStaticItem()
        Me.RibbonPage1 = New DevExpress.XtraBars.Ribbon.RibbonPage()
        Me.RibbonPageGroup2 = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.GroupNotas = New DevExpress.XtraEditors.GroupControl()
        Me.lblCodigo = New System.Windows.Forms.Label()
        Me.lblData = New System.Windows.Forms.Label()
        Me.lblClave = New System.Windows.Forms.Label()
        Me.lblCostoTotal = New System.Windows.Forms.Label()
        Me.LabelControl17 = New DevExpress.XtraEditors.LabelControl()
        Me.lblPaletas = New System.Windows.Forms.Label()
        Me.LabelControl12 = New DevExpress.XtraEditors.LabelControl()
        Me.lblCostoUnitario = New System.Windows.Forms.Label()
        Me.LabelControl13 = New DevExpress.XtraEditors.LabelControl()
        Me.cbCantidad = New DevExpress.XtraEditors.CalcEdit()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.bbAdd = New DevExpress.XtraEditors.SimpleButton()
        Me.LabelControl8 = New DevExpress.XtraEditors.LabelControl()
        Me.DateTimePicker3 = New System.Windows.Forms.DateTimePicker()
        Me.DateTimePicker4 = New System.Windows.Forms.DateTimePicker()
        Me.LabelControl7 = New DevExpress.XtraEditors.LabelControl()
        Me.dtpLunes6 = New System.Windows.Forms.DateTimePicker()
        Me.dtpLunes5 = New System.Windows.Forms.DateTimePicker()
        Me.LabelControl4 = New DevExpress.XtraEditors.LabelControl()
        Me.DateTimePicker2 = New System.Windows.Forms.DateTimePicker()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker()
        Me.lblNumero = New System.Windows.Forms.Label()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl6 = New DevExpress.XtraEditors.LabelControl()
        Me.lkReceta = New DevExpress.XtraEditors.LookUpEdit()
        Me.LabelControl5 = New DevExpress.XtraEditors.LabelControl()
        Me.txtNotas = New DevExpress.XtraEditors.MemoEdit()
        Me.LabelControl33 = New DevExpress.XtraEditors.LabelControl()
        Me.dtpFecha = New System.Windows.Forms.DateTimePicker()
        Me.DefaultLookAndFeel1 = New DevExpress.LookAndFeel.DefaultLookAndFeel(Me.components)
        Me.gcDetalle = New DevExpress.XtraGrid.GridControl()
        Me.gvDetalle = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GroupControl2 = New DevExpress.XtraEditors.GroupControl()
        CType(Me.RibbonControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GroupNotas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupNotas.SuspendLayout()
        CType(Me.cbCantidad.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lkReceta.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtNotas.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gcDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gvDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GroupControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl2.SuspendLayout()
        Me.SuspendLayout()
        '
        'RibbonControl1
        '
        Me.RibbonControl1.ApplicationButtonText = Nothing
        Me.RibbonControl1.ExpandCollapseItem.Id = 0
        Me.RibbonControl1.Items.AddRange(New DevExpress.XtraBars.BarItem() {Me.RibbonControl1.ExpandCollapseItem, Me.bbClose, Me.bbSave, Me.barText, Me.txtStatus})
        Me.RibbonControl1.Location = New System.Drawing.Point(0, 0)
        Me.RibbonControl1.MaxItemId = 27
        Me.RibbonControl1.Name = "RibbonControl1"
        Me.RibbonControl1.Pages.AddRange(New DevExpress.XtraBars.Ribbon.RibbonPage() {Me.RibbonPage1})
        Me.RibbonControl1.ShowPageHeadersMode = DevExpress.XtraBars.Ribbon.ShowPageHeadersMode.Hide
        Me.RibbonControl1.Size = New System.Drawing.Size(878, 93)
        Me.RibbonControl1.ToolbarLocation = DevExpress.XtraBars.Ribbon.RibbonQuickAccessToolbarLocation.Hidden
        '
        'bbClose
        '
        Me.bbClose.Caption = "Salir"
        Me.bbClose.Id = 21
        Me.bbClose.LargeGlyph = CType(resources.GetObject("bbClose.LargeGlyph"), System.Drawing.Image)
        Me.bbClose.Name = "bbClose"
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
        Me.RibbonPageGroup2.ItemLinks.Add(Me.bbClose)
        Me.RibbonPageGroup2.Name = "RibbonPageGroup2"
        Me.RibbonPageGroup2.ShowCaptionButton = False
        '
        'GroupNotas
        '
        Me.GroupNotas.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupNotas.AppearanceCaption.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupNotas.AppearanceCaption.Options.UseFont = True
        Me.GroupNotas.Controls.Add(Me.lblCodigo)
        Me.GroupNotas.Controls.Add(Me.lblData)
        Me.GroupNotas.Controls.Add(Me.lblClave)
        Me.GroupNotas.Controls.Add(Me.lblCostoTotal)
        Me.GroupNotas.Controls.Add(Me.LabelControl17)
        Me.GroupNotas.Controls.Add(Me.lblPaletas)
        Me.GroupNotas.Controls.Add(Me.LabelControl12)
        Me.GroupNotas.Controls.Add(Me.lblCostoUnitario)
        Me.GroupNotas.Controls.Add(Me.LabelControl13)
        Me.GroupNotas.Controls.Add(Me.cbCantidad)
        Me.GroupNotas.Controls.Add(Me.LabelControl1)
        Me.GroupNotas.Controls.Add(Me.bbAdd)
        Me.GroupNotas.Controls.Add(Me.LabelControl8)
        Me.GroupNotas.Controls.Add(Me.DateTimePicker3)
        Me.GroupNotas.Controls.Add(Me.DateTimePicker4)
        Me.GroupNotas.Controls.Add(Me.LabelControl7)
        Me.GroupNotas.Controls.Add(Me.dtpLunes6)
        Me.GroupNotas.Controls.Add(Me.dtpLunes5)
        Me.GroupNotas.Controls.Add(Me.LabelControl4)
        Me.GroupNotas.Controls.Add(Me.DateTimePicker2)
        Me.GroupNotas.Controls.Add(Me.LabelControl3)
        Me.GroupNotas.Controls.Add(Me.DateTimePicker1)
        Me.GroupNotas.Controls.Add(Me.lblNumero)
        Me.GroupNotas.Controls.Add(Me.LabelControl2)
        Me.GroupNotas.Controls.Add(Me.LabelControl6)
        Me.GroupNotas.Controls.Add(Me.lkReceta)
        Me.GroupNotas.Controls.Add(Me.LabelControl5)
        Me.GroupNotas.Controls.Add(Me.txtNotas)
        Me.GroupNotas.Controls.Add(Me.LabelControl33)
        Me.GroupNotas.Controls.Add(Me.dtpFecha)
        Me.GroupNotas.Location = New System.Drawing.Point(0, 93)
        Me.GroupNotas.LookAndFeel.SkinName = "Office 2007 Blue"
        Me.GroupNotas.LookAndFeel.UseDefaultLookAndFeel = False
        Me.GroupNotas.Name = "GroupNotas"
        Me.GroupNotas.Size = New System.Drawing.Size(877, 199)
        Me.GroupNotas.TabIndex = 0
        Me.GroupNotas.Text = "Datos Generales"
        '
        'lblCodigo
        '
        Me.lblCodigo.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lblCodigo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblCodigo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lblCodigo.Location = New System.Drawing.Point(480, 128)
        Me.lblCodigo.Name = "lblCodigo"
        Me.lblCodigo.Size = New System.Drawing.Size(102, 20)
        Me.lblCodigo.TabIndex = 337
        Me.lblCodigo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblData
        '
        Me.lblData.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lblData.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblData.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lblData.Location = New System.Drawing.Point(372, 152)
        Me.lblData.Name = "lblData"
        Me.lblData.Size = New System.Drawing.Size(264, 20)
        Me.lblData.TabIndex = 336
        Me.lblData.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblClave
        '
        Me.lblClave.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lblClave.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblClave.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lblClave.Location = New System.Drawing.Point(373, 128)
        Me.lblClave.Name = "lblClave"
        Me.lblClave.Size = New System.Drawing.Size(102, 20)
        Me.lblClave.TabIndex = 335
        Me.lblClave.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblCostoTotal
        '
        Me.lblCostoTotal.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lblCostoTotal.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblCostoTotal.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lblCostoTotal.Location = New System.Drawing.Point(742, 106)
        Me.lblCostoTotal.Name = "lblCostoTotal"
        Me.lblCostoTotal.Size = New System.Drawing.Size(125, 20)
        Me.lblCostoTotal.TabIndex = 333
        Me.lblCostoTotal.Text = "0.00"
        Me.lblCostoTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LabelControl17
        '
        Me.LabelControl17.Appearance.ForeColor = System.Drawing.Color.Black
        Me.LabelControl17.Location = New System.Drawing.Point(671, 110)
        Me.LabelControl17.Name = "LabelControl17"
        Me.LabelControl17.Size = New System.Drawing.Size(62, 13)
        Me.LabelControl17.TabIndex = 334
        Me.LabelControl17.Text = "Costo Total :"
        '
        'lblPaletas
        '
        Me.lblPaletas.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lblPaletas.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblPaletas.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lblPaletas.Location = New System.Drawing.Point(742, 129)
        Me.lblPaletas.Name = "lblPaletas"
        Me.lblPaletas.Size = New System.Drawing.Size(125, 20)
        Me.lblPaletas.TabIndex = 331
        Me.lblPaletas.Text = "0.00"
        Me.lblPaletas.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LabelControl12
        '
        Me.LabelControl12.Appearance.ForeColor = System.Drawing.Color.Black
        Me.LabelControl12.Location = New System.Drawing.Point(643, 133)
        Me.LabelControl12.Name = "LabelControl12"
        Me.LabelControl12.Size = New System.Drawing.Size(93, 13)
        Me.LabelControl12.TabIndex = 332
        Me.LabelControl12.Text = "Paletas a Producir :"
        '
        'lblCostoUnitario
        '
        Me.lblCostoUnitario.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lblCostoUnitario.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblCostoUnitario.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lblCostoUnitario.Location = New System.Drawing.Point(742, 151)
        Me.lblCostoUnitario.Name = "lblCostoUnitario"
        Me.lblCostoUnitario.Size = New System.Drawing.Size(125, 20)
        Me.lblCostoUnitario.TabIndex = 329
        Me.lblCostoUnitario.Text = "0.00"
        Me.lblCostoUnitario.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LabelControl13
        '
        Me.LabelControl13.Appearance.ForeColor = System.Drawing.Color.Black
        Me.LabelControl13.Location = New System.Drawing.Point(646, 155)
        Me.LabelControl13.Name = "LabelControl13"
        Me.LabelControl13.Size = New System.Drawing.Size(90, 13)
        Me.LabelControl13.TabIndex = 330
        Me.LabelControl13.Text = "Costo Por Unidad :"
        '
        'cbCantidad
        '
        Me.cbCantidad.Location = New System.Drawing.Point(78, 154)
        Me.cbCantidad.Name = "cbCantidad"
        Me.cbCantidad.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cbCantidad.Properties.DisplayFormat.FormatString = "n2"
        Me.cbCantidad.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.cbCantidad.Properties.EditFormat.FormatString = "n2"
        Me.cbCantidad.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.cbCantidad.Properties.Mask.EditMask = "n2"
        Me.cbCantidad.Size = New System.Drawing.Size(91, 20)
        Me.cbCantidad.TabIndex = 319
        '
        'LabelControl1
        '
        Me.LabelControl1.Appearance.ForeColor = System.Drawing.Color.Black
        Me.LabelControl1.Location = New System.Drawing.Point(24, 158)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(50, 13)
        Me.LabelControl1.TabIndex = 320
        Me.LabelControl1.Text = "Cantidad :"
        '
        'bbAdd
        '
        Me.bbAdd.Location = New System.Drawing.Point(178, 152)
        Me.bbAdd.Name = "bbAdd"
        Me.bbAdd.Size = New System.Drawing.Size(100, 21)
        Me.bbAdd.TabIndex = 6
        Me.bbAdd.Text = "F1 - Procesar"
        '
        'LabelControl8
        '
        Me.LabelControl8.Appearance.ForeColor = System.Drawing.Color.Black
        Me.LabelControl8.Location = New System.Drawing.Point(13, 109)
        Me.LabelControl8.Name = "LabelControl8"
        Me.LabelControl8.Size = New System.Drawing.Size(62, 13)
        Me.LabelControl8.TabIndex = 318
        Me.LabelControl8.Text = "Congelador :"
        '
        'DateTimePicker3
        '
        Me.DateTimePicker3.Checked = False
        Me.DateTimePicker3.CustomFormat = "hh:mm tt"
        Me.DateTimePicker3.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DateTimePicker3.Location = New System.Drawing.Point(163, 103)
        Me.DateTimePicker3.Name = "DateTimePicker3"
        Me.DateTimePicker3.ShowUpDown = True
        Me.DateTimePicker3.Size = New System.Drawing.Size(76, 21)
        Me.DateTimePicker3.TabIndex = 317
        Me.DateTimePicker3.Value = New Date(2007, 7, 10, 7, 0, 0, 0)
        '
        'DateTimePicker4
        '
        Me.DateTimePicker4.Checked = False
        Me.DateTimePicker4.CustomFormat = "hh:mm tt"
        Me.DateTimePicker4.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DateTimePicker4.Location = New System.Drawing.Point(78, 103)
        Me.DateTimePicker4.Name = "DateTimePicker4"
        Me.DateTimePicker4.ShowUpDown = True
        Me.DateTimePicker4.Size = New System.Drawing.Size(76, 21)
        Me.DateTimePicker4.TabIndex = 316
        Me.DateTimePicker4.Value = New Date(2007, 7, 10, 7, 0, 0, 0)
        '
        'LabelControl7
        '
        Me.LabelControl7.Appearance.ForeColor = System.Drawing.Color.Black
        Me.LabelControl7.Location = New System.Drawing.Point(32, 82)
        Me.LabelControl7.Name = "LabelControl7"
        Me.LabelControl7.Size = New System.Drawing.Size(39, 13)
        Me.LabelControl7.TabIndex = 315
        Me.LabelControl7.Text = "Mezcla :"
        '
        'dtpLunes6
        '
        Me.dtpLunes6.Checked = False
        Me.dtpLunes6.CustomFormat = "hh:mm tt"
        Me.dtpLunes6.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpLunes6.Location = New System.Drawing.Point(163, 76)
        Me.dtpLunes6.Name = "dtpLunes6"
        Me.dtpLunes6.ShowUpDown = True
        Me.dtpLunes6.Size = New System.Drawing.Size(76, 21)
        Me.dtpLunes6.TabIndex = 314
        Me.dtpLunes6.Value = New Date(2007, 7, 10, 7, 0, 0, 0)
        '
        'dtpLunes5
        '
        Me.dtpLunes5.Checked = False
        Me.dtpLunes5.CustomFormat = "hh:mm tt"
        Me.dtpLunes5.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpLunes5.Location = New System.Drawing.Point(78, 76)
        Me.dtpLunes5.Name = "dtpLunes5"
        Me.dtpLunes5.ShowUpDown = True
        Me.dtpLunes5.Size = New System.Drawing.Size(76, 21)
        Me.dtpLunes5.TabIndex = 312
        Me.dtpLunes5.Value = New Date(2007, 7, 10, 7, 0, 0, 0)
        '
        'LabelControl4
        '
        Me.LabelControl4.Appearance.ForeColor = System.Drawing.Color.Black
        Me.LabelControl4.Location = New System.Drawing.Point(214, 54)
        Me.LabelControl4.Name = "LabelControl4"
        Me.LabelControl4.Size = New System.Drawing.Size(29, 13)
        Me.LabelControl4.TabIndex = 311
        Me.LabelControl4.Text = "Final :"
        '
        'DateTimePicker2
        '
        Me.DateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateTimePicker2.Location = New System.Drawing.Point(261, 50)
        Me.DateTimePicker2.Name = "DateTimePicker2"
        Me.DateTimePicker2.Size = New System.Drawing.Size(104, 21)
        Me.DateTimePicker2.TabIndex = 310
        '
        'LabelControl3
        '
        Me.LabelControl3.Appearance.ForeColor = System.Drawing.Color.Black
        Me.LabelControl3.Location = New System.Drawing.Point(39, 54)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(32, 13)
        Me.LabelControl3.TabIndex = 309
        Me.LabelControl3.Text = "Inicio :"
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateTimePicker1.Location = New System.Drawing.Point(76, 50)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.Size = New System.Drawing.Size(104, 21)
        Me.DateTimePicker1.TabIndex = 308
        '
        'lblNumero
        '
        Me.lblNumero.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lblNumero.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblNumero.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lblNumero.Location = New System.Drawing.Point(76, 23)
        Me.lblNumero.Name = "lblNumero"
        Me.lblNumero.Size = New System.Drawing.Size(102, 20)
        Me.lblNumero.TabIndex = 3
        Me.lblNumero.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LabelControl2
        '
        Me.LabelControl2.Appearance.ForeColor = System.Drawing.Color.Black
        Me.LabelControl2.Location = New System.Drawing.Point(48, 27)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(23, 13)
        Me.LabelControl2.TabIndex = 306
        Me.LabelControl2.Text = "Nº. :"
        '
        'LabelControl6
        '
        Me.LabelControl6.Appearance.ForeColor = System.Drawing.Color.Black
        Me.LabelControl6.Location = New System.Drawing.Point(32, 132)
        Me.LabelControl6.Name = "LabelControl6"
        Me.LabelControl6.Size = New System.Drawing.Size(41, 13)
        Me.LabelControl6.TabIndex = 303
        Me.LabelControl6.Text = "Receta :"
        '
        'lkReceta
        '
        Me.lkReceta.Location = New System.Drawing.Point(78, 129)
        Me.lkReceta.Name = "lkReceta"
        Me.lkReceta.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.lkReceta.Properties.NullText = ""
        Me.lkReceta.Size = New System.Drawing.Size(286, 20)
        Me.lkReceta.TabIndex = 2
        '
        'LabelControl5
        '
        Me.LabelControl5.Appearance.ForeColor = System.Drawing.Color.Black
        Me.LabelControl5.Location = New System.Drawing.Point(434, 32)
        Me.LabelControl5.Name = "LabelControl5"
        Me.LabelControl5.Size = New System.Drawing.Size(78, 13)
        Me.LabelControl5.TabIndex = 300
        Me.LabelControl5.Text = "Observaciones :"
        '
        'txtNotas
        '
        Me.txtNotas.Location = New System.Drawing.Point(513, 29)
        Me.txtNotas.Name = "txtNotas"
        Me.txtNotas.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNotas.Properties.MaxLength = 300
        Me.txtNotas.Size = New System.Drawing.Size(356, 67)
        Me.txtNotas.TabIndex = 5
        '
        'LabelControl33
        '
        Me.LabelControl33.Appearance.ForeColor = System.Drawing.Color.Black
        Me.LabelControl33.Location = New System.Drawing.Point(207, 29)
        Me.LabelControl33.Name = "LabelControl33"
        Me.LabelControl33.Size = New System.Drawing.Size(36, 13)
        Me.LabelControl33.TabIndex = 247
        Me.LabelControl33.Text = "Fecha :"
        '
        'dtpFecha
        '
        Me.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFecha.Location = New System.Drawing.Point(261, 25)
        Me.dtpFecha.Name = "dtpFecha"
        Me.dtpFecha.Size = New System.Drawing.Size(104, 21)
        Me.dtpFecha.TabIndex = 1
        '
        'DefaultLookAndFeel1
        '
        Me.DefaultLookAndFeel1.LookAndFeel.SkinName = "Money Twins"
        '
        'gcDetalle
        '
        Me.gcDetalle.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gcDetalle.Location = New System.Drawing.Point(2, 21)
        Me.gcDetalle.MainView = Me.gvDetalle
        Me.gcDetalle.Name = "gcDetalle"
        Me.gcDetalle.Size = New System.Drawing.Size(870, 291)
        Me.gcDetalle.TabIndex = 0
        Me.gcDetalle.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.gvDetalle, Me.GridView1})
        '
        'gvDetalle
        '
        Me.gvDetalle.GridControl = Me.gcDetalle
        Me.gvDetalle.Name = "gvDetalle"
        Me.gvDetalle.OptionsView.ShowGroupPanel = False
        '
        'GridView1
        '
        Me.GridView1.GridControl = Me.gcDetalle
        Me.GridView1.Name = "GridView1"
        '
        'GroupControl2
        '
        Me.GroupControl2.AppearanceCaption.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.GroupControl2.AppearanceCaption.ForeColor = System.Drawing.Color.White
        Me.GroupControl2.AppearanceCaption.Options.UseFont = True
        Me.GroupControl2.AppearanceCaption.Options.UseForeColor = True
        Me.GroupControl2.Controls.Add(Me.gcDetalle)
        Me.GroupControl2.Location = New System.Drawing.Point(2, 284)
        Me.GroupControl2.LookAndFeel.SkinName = "Office 2016 Dark"
        Me.GroupControl2.LookAndFeel.UseDefaultLookAndFeel = False
        Me.GroupControl2.Name = "GroupControl2"
        Me.GroupControl2.Size = New System.Drawing.Size(874, 314)
        Me.GroupControl2.TabIndex = 335
        Me.GroupControl2.Text = ":: MRP ::"
        '
        'frmOrden_Data
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(878, 599)
        Me.Controls.Add(Me.GroupControl2)
        Me.Controls.Add(Me.GroupNotas)
        Me.Controls.Add(Me.RibbonControl1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmOrden_Data"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = ":: Orden de Producción ::"
        CType(Me.RibbonControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GroupNotas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupNotas.ResumeLayout(False)
        Me.GroupNotas.PerformLayout()
        CType(Me.cbCantidad.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lkReceta.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtNotas.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gcDetalle, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gvDetalle, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GroupControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl2.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents RibbonControl1 As DevExpress.XtraBars.Ribbon.RibbonControl
    Friend WithEvents bbClose As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents bbSave As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents barText As DevExpress.XtraBars.BarStaticItem
    Friend WithEvents txtStatus As DevExpress.XtraBars.BarStaticItem
    Friend WithEvents RibbonPage1 As DevExpress.XtraBars.Ribbon.RibbonPage
    Friend WithEvents RibbonPageGroup2 As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents GroupNotas As DevExpress.XtraEditors.GroupControl
    Friend WithEvents lblNumero As System.Windows.Forms.Label
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl6 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lkReceta As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents LabelControl5 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtNotas As DevExpress.XtraEditors.MemoEdit
    Friend WithEvents LabelControl33 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents dtpFecha As System.Windows.Forms.DateTimePicker
    Friend WithEvents bbAdd As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents DefaultLookAndFeel1 As DevExpress.LookAndFeel.DefaultLookAndFeel
    Friend WithEvents LabelControl4 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents DateTimePicker2 As DateTimePicker
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents DateTimePicker1 As DateTimePicker
    Friend WithEvents LabelControl7 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents dtpLunes6 As DateTimePicker
    Friend WithEvents dtpLunes5 As DateTimePicker
    Friend WithEvents LabelControl8 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents DateTimePicker3 As DateTimePicker
    Friend WithEvents DateTimePicker4 As DateTimePicker
    Friend WithEvents cbCantidad As DevExpress.XtraEditors.CalcEdit
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents gcDetalle As DevExpress.XtraGrid.GridControl
    Friend WithEvents gvDetalle As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GroupControl2 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents lblCostoTotal As Label
    Friend WithEvents LabelControl17 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lblPaletas As Label
    Friend WithEvents LabelControl12 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lblCostoUnitario As Label
    Friend WithEvents LabelControl13 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lblClave As Label
    Friend WithEvents lblData As Label
    Friend WithEvents lblCodigo As Label
End Class
