<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmInvAjuste_Data2
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmInvAjuste_Data2))
        Me.RibbonControl1 = New DevExpress.XtraBars.Ribbon.RibbonControl()
        Me.bbClose = New DevExpress.XtraBars.BarButtonItem()
        Me.bbSave = New DevExpress.XtraBars.BarButtonItem()
        Me.barText = New DevExpress.XtraBars.BarStaticItem()
        Me.txtStatus = New DevExpress.XtraBars.BarStaticItem()
        Me.RibbonPage1 = New DevExpress.XtraBars.Ribbon.RibbonPage()
        Me.RibbonPageGroup2 = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.RibbonStatusBar1 = New DevExpress.XtraBars.Ribbon.RibbonStatusBar()
        Me.GroupNotas = New DevExpress.XtraEditors.GroupControl()
        Me.bbKardex = New DevExpress.XtraEditors.SimpleButton()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.txtReferencia = New DevExpress.XtraEditors.TextEdit()
        Me.lblNumero = New System.Windows.Forms.Label()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl6 = New DevExpress.XtraEditors.LabelControl()
        Me.lkConcepto = New DevExpress.XtraEditors.LookUpEdit()
        Me.LabelControl5 = New DevExpress.XtraEditors.LabelControl()
        Me.txtNotas = New DevExpress.XtraEditors.MemoEdit()
        Me.LabelControl33 = New DevExpress.XtraEditors.LabelControl()
        Me.dtpFecha = New System.Windows.Forms.DateTimePicker()
        Me.bbEdit = New DevExpress.XtraEditors.SimpleButton()
        Me.bbAdd = New DevExpress.XtraEditors.SimpleButton()
        Me.GroupControl2 = New DevExpress.XtraEditors.GroupControl()
        Me.gcDetalle = New DevExpress.XtraGrid.GridControl()
        Me.gvDetalle = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.DefaultLookAndFeel1 = New DevExpress.LookAndFeel.DefaultLookAndFeel(Me.components)
        CType(Me.RibbonControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GroupNotas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupNotas.SuspendLayout()
        CType(Me.txtReferencia.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lkConcepto.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtNotas.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GroupControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl2.SuspendLayout()
        CType(Me.gcDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gvDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'RibbonControl1
        '
        Me.RibbonControl1.ApplicationButtonText = Nothing
        Me.RibbonControl1.ExpandCollapseItem.Id = 0
        Me.RibbonControl1.Items.AddRange(New DevExpress.XtraBars.BarItem() {Me.RibbonControl1.ExpandCollapseItem, Me.bbClose, Me.bbSave, Me.barText, Me.txtStatus})
        Me.RibbonControl1.Location = New System.Drawing.Point(0, 0)
        Me.RibbonControl1.Margin = New System.Windows.Forms.Padding(4)
        Me.RibbonControl1.MaxItemId = 27
        Me.RibbonControl1.Name = "RibbonControl1"
        Me.RibbonControl1.Pages.AddRange(New DevExpress.XtraBars.Ribbon.RibbonPage() {Me.RibbonPage1})
        Me.RibbonControl1.ShowPageHeadersMode = DevExpress.XtraBars.Ribbon.ShowPageHeadersMode.Hide
        Me.RibbonControl1.Size = New System.Drawing.Size(1197, 117)
        Me.RibbonControl1.StatusBar = Me.RibbonStatusBar1
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
        'RibbonStatusBar1
        '
        Me.RibbonStatusBar1.Location = New System.Drawing.Point(0, 640)
        Me.RibbonStatusBar1.Margin = New System.Windows.Forms.Padding(4)
        Me.RibbonStatusBar1.Name = "RibbonStatusBar1"
        Me.RibbonStatusBar1.Ribbon = Me.RibbonControl1
        Me.RibbonStatusBar1.Size = New System.Drawing.Size(1197, 30)
        '
        'GroupNotas
        '
        Me.GroupNotas.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupNotas.AppearanceCaption.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupNotas.AppearanceCaption.Options.UseFont = True
        Me.GroupNotas.Controls.Add(Me.bbKardex)
        Me.GroupNotas.Controls.Add(Me.LabelControl1)
        Me.GroupNotas.Controls.Add(Me.txtReferencia)
        Me.GroupNotas.Controls.Add(Me.lblNumero)
        Me.GroupNotas.Controls.Add(Me.LabelControl2)
        Me.GroupNotas.Controls.Add(Me.LabelControl6)
        Me.GroupNotas.Controls.Add(Me.lkConcepto)
        Me.GroupNotas.Controls.Add(Me.LabelControl5)
        Me.GroupNotas.Controls.Add(Me.txtNotas)
        Me.GroupNotas.Controls.Add(Me.LabelControl33)
        Me.GroupNotas.Controls.Add(Me.dtpFecha)
        Me.GroupNotas.Location = New System.Drawing.Point(0, 114)
        Me.GroupNotas.LookAndFeel.SkinName = "Office 2007 Blue"
        Me.GroupNotas.LookAndFeel.UseDefaultLookAndFeel = False
        Me.GroupNotas.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupNotas.Name = "GroupNotas"
        Me.GroupNotas.Size = New System.Drawing.Size(1196, 145)
        Me.GroupNotas.TabIndex = 0
        Me.GroupNotas.Text = "Datos Generales"
        '
        'bbKardex
        '
        Me.bbKardex.Location = New System.Drawing.Point(1052, 116)
        Me.bbKardex.Margin = New System.Windows.Forms.Padding(4)
        Me.bbKardex.Name = "bbKardex"
        Me.bbKardex.Size = New System.Drawing.Size(133, 26)
        Me.bbKardex.TabIndex = 8
        Me.bbKardex.Text = "F3 - Kardex"
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(259, 95)
        Me.LabelControl1.Margin = New System.Windows.Forms.Padding(4)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(70, 16)
        Me.LabelControl1.TabIndex = 307
        Me.LabelControl1.Text = "Referencia :"
        '
        'txtReferencia
        '
        Me.txtReferencia.Location = New System.Drawing.Point(357, 90)
        Me.txtReferencia.Margin = New System.Windows.Forms.Padding(4)
        Me.txtReferencia.Name = "txtReferencia"
        Me.txtReferencia.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtReferencia.Properties.MaxLength = 150
        Me.txtReferencia.Size = New System.Drawing.Size(171, 23)
        Me.txtReferencia.TabIndex = 4
        '
        'lblNumero
        '
        Me.lblNumero.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lblNumero.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblNumero.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lblNumero.Location = New System.Drawing.Point(105, 89)
        Me.lblNumero.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblNumero.Name = "lblNumero"
        Me.lblNumero.Size = New System.Drawing.Size(136, 25)
        Me.lblNumero.TabIndex = 3
        Me.lblNumero.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LabelControl2
        '
        Me.LabelControl2.Appearance.ForeColor = System.Drawing.Color.Black
        Me.LabelControl2.Location = New System.Drawing.Point(52, 94)
        Me.LabelControl2.Margin = New System.Windows.Forms.Padding(4)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(27, 16)
        Me.LabelControl2.TabIndex = 306
        Me.LabelControl2.Text = "Nº. :"
        '
        'LabelControl6
        '
        Me.LabelControl6.Appearance.ForeColor = System.Drawing.Color.Black
        Me.LabelControl6.Location = New System.Drawing.Point(12, 63)
        Me.LabelControl6.Margin = New System.Windows.Forms.Padding(4)
        Me.LabelControl6.Name = "LabelControl6"
        Me.LabelControl6.Size = New System.Drawing.Size(62, 16)
        Me.LabelControl6.TabIndex = 303
        Me.LabelControl6.Text = "Concepto :"
        '
        'lkConcepto
        '
        Me.lkConcepto.Enabled = False
        Me.lkConcepto.Location = New System.Drawing.Point(104, 59)
        Me.lkConcepto.Margin = New System.Windows.Forms.Padding(4)
        Me.lkConcepto.Name = "lkConcepto"
        Me.lkConcepto.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.lkConcepto.Properties.NullText = ""
        Me.lkConcepto.Size = New System.Drawing.Size(431, 23)
        Me.lkConcepto.TabIndex = 2
        '
        'LabelControl5
        '
        Me.LabelControl5.Appearance.ForeColor = System.Drawing.Color.Black
        Me.LabelControl5.Location = New System.Drawing.Point(496, 34)
        Me.LabelControl5.Margin = New System.Windows.Forms.Padding(4)
        Me.LabelControl5.Name = "LabelControl5"
        Me.LabelControl5.Size = New System.Drawing.Size(92, 16)
        Me.LabelControl5.TabIndex = 300
        Me.LabelControl5.Text = "Observaciones :"
        '
        'txtNotas
        '
        Me.txtNotas.Location = New System.Drawing.Point(613, 33)
        Me.txtNotas.Margin = New System.Windows.Forms.Padding(4)
        Me.txtNotas.Name = "txtNotas"
        Me.txtNotas.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNotas.Properties.MaxLength = 300
        Me.txtNotas.Size = New System.Drawing.Size(568, 75)
        Me.txtNotas.TabIndex = 5
        '
        'LabelControl33
        '
        Me.LabelControl33.Appearance.ForeColor = System.Drawing.Color.Black
        Me.LabelControl33.Location = New System.Drawing.Point(35, 34)
        Me.LabelControl33.Margin = New System.Windows.Forms.Padding(4)
        Me.LabelControl33.Name = "LabelControl33"
        Me.LabelControl33.Size = New System.Drawing.Size(43, 16)
        Me.LabelControl33.TabIndex = 247
        Me.LabelControl33.Text = "Fecha :"
        '
        'dtpFecha
        '
        Me.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFecha.Location = New System.Drawing.Point(103, 30)
        Me.dtpFecha.Margin = New System.Windows.Forms.Padding(4)
        Me.dtpFecha.Name = "dtpFecha"
        Me.dtpFecha.Size = New System.Drawing.Size(137, 23)
        Me.dtpFecha.TabIndex = 1
        '
        'bbEdit
        '
        Me.bbEdit.Location = New System.Drawing.Point(915, 230)
        Me.bbEdit.Margin = New System.Windows.Forms.Padding(4)
        Me.bbEdit.Name = "bbEdit"
        Me.bbEdit.Size = New System.Drawing.Size(133, 26)
        Me.bbEdit.TabIndex = 7
        Me.bbEdit.Text = "F2 - Editar Linea"
        '
        'bbAdd
        '
        Me.bbAdd.Location = New System.Drawing.Point(776, 230)
        Me.bbAdd.Margin = New System.Windows.Forms.Padding(4)
        Me.bbAdd.Name = "bbAdd"
        Me.bbAdd.Size = New System.Drawing.Size(133, 26)
        Me.bbAdd.TabIndex = 6
        Me.bbAdd.Text = "F1 - Agregar Linea"
        '
        'GroupControl2
        '
        Me.GroupControl2.AppearanceCaption.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.GroupControl2.AppearanceCaption.ForeColor = System.Drawing.Color.White
        Me.GroupControl2.AppearanceCaption.Options.UseFont = True
        Me.GroupControl2.AppearanceCaption.Options.UseForeColor = True
        Me.GroupControl2.Controls.Add(Me.gcDetalle)
        Me.GroupControl2.Location = New System.Drawing.Point(3, 260)
        Me.GroupControl2.LookAndFeel.SkinName = "Office 2016 Dark"
        Me.GroupControl2.LookAndFeel.UseDefaultLookAndFeel = False
        Me.GroupControl2.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupControl2.Name = "GroupControl2"
        Me.GroupControl2.Size = New System.Drawing.Size(1193, 382)
        Me.GroupControl2.TabIndex = 335
        Me.GroupControl2.Text = ":: DETALLE DE ARTICULOS ::"
        '
        'gcDetalle
        '
        Me.gcDetalle.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gcDetalle.EmbeddedNavigator.Margin = New System.Windows.Forms.Padding(4)
        Me.gcDetalle.Location = New System.Drawing.Point(2, 26)
        Me.gcDetalle.MainView = Me.gvDetalle
        Me.gcDetalle.Margin = New System.Windows.Forms.Padding(4)
        Me.gcDetalle.Name = "gcDetalle"
        Me.gcDetalle.Size = New System.Drawing.Size(1189, 354)
        Me.gcDetalle.TabIndex = 0
        Me.gcDetalle.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.gvDetalle})
        '
        'gvDetalle
        '
        Me.gvDetalle.GridControl = Me.gcDetalle
        Me.gvDetalle.Name = "gvDetalle"
        Me.gvDetalle.OptionsView.ShowGroupPanel = False
        '
        'DefaultLookAndFeel1
        '
        Me.DefaultLookAndFeel1.LookAndFeel.SkinName = "Money Twins"
        '
        'frmInvAjuste_Data2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1197, 670)
        Me.Controls.Add(Me.bbEdit)
        Me.Controls.Add(Me.bbAdd)
        Me.Controls.Add(Me.GroupControl2)
        Me.Controls.Add(Me.GroupNotas)
        Me.Controls.Add(Me.RibbonStatusBar1)
        Me.Controls.Add(Me.RibbonControl1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmInvAjuste_Data2"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = ":: Movimientos de Inventario ::"
        CType(Me.RibbonControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GroupNotas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupNotas.ResumeLayout(False)
        Me.GroupNotas.PerformLayout()
        CType(Me.txtReferencia.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lkConcepto.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtNotas.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GroupControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl2.ResumeLayout(False)
        CType(Me.gcDetalle, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gvDetalle, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents RibbonStatusBar1 As DevExpress.XtraBars.Ribbon.RibbonStatusBar
    Friend WithEvents GroupNotas As DevExpress.XtraEditors.GroupControl
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtReferencia As DevExpress.XtraEditors.TextEdit
    Friend WithEvents lblNumero As System.Windows.Forms.Label
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl6 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lkConcepto As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents LabelControl5 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtNotas As DevExpress.XtraEditors.MemoEdit
    Friend WithEvents LabelControl33 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents dtpFecha As System.Windows.Forms.DateTimePicker
    Friend WithEvents bbEdit As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents bbAdd As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GroupControl2 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents gcDetalle As DevExpress.XtraGrid.GridControl
    Friend WithEvents gvDetalle As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents bbKardex As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents DefaultLookAndFeel1 As DevExpress.LookAndFeel.DefaultLookAndFeel
End Class
