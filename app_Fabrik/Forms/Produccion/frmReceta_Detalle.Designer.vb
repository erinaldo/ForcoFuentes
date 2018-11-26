<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmReceta_Detalle
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmReceta_Detalle))
        Me.RibbonControl1 = New DevExpress.XtraBars.Ribbon.RibbonControl()
        Me.bClose = New DevExpress.XtraBars.BarButtonItem()
        Me.bbSave = New DevExpress.XtraBars.BarButtonItem()
        Me.barText = New DevExpress.XtraBars.BarStaticItem()
        Me.txtStatus = New DevExpress.XtraBars.BarStaticItem()
        Me.RibbonPage1 = New DevExpress.XtraBars.Ribbon.RibbonPage()
        Me.RibbonPageGroup2 = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.RibbonStatusBar1 = New DevExpress.XtraBars.Ribbon.RibbonStatusBar()
        Me.GroupControl2 = New DevExpress.XtraEditors.GroupControl()
        Me.gcDetalle = New DevExpress.XtraGrid.GridControl()
        Me.gvDetalle = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GroupNotas = New DevExpress.XtraEditors.GroupControl()
        Me.LabelControl6 = New DevExpress.XtraEditors.LabelControl()
        Me.lkProducto = New DevExpress.XtraEditors.LookUpEdit()
        Me.bbEdit = New DevExpress.XtraEditors.SimpleButton()
        Me.bbAdd = New DevExpress.XtraEditors.SimpleButton()
        Me.lblNumero = New System.Windows.Forms.Label()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.bSave = New DevExpress.XtraBars.BarButtonItem()
        Me.DefaultLookAndFeel1 = New DevExpress.LookAndFeel.DefaultLookAndFeel(Me.components)
        CType(Me.RibbonControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GroupControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl2.SuspendLayout()
        CType(Me.gcDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gvDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GroupNotas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupNotas.SuspendLayout()
        CType(Me.lkProducto.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.RibbonControl1.StatusBar = Me.RibbonStatusBar1
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
        'RibbonStatusBar1
        '
        Me.RibbonStatusBar1.ItemLinks.Add(Me.txtStatus)
        Me.RibbonStatusBar1.Location = New System.Drawing.Point(0, 579)
        Me.RibbonStatusBar1.Name = "RibbonStatusBar1"
        Me.RibbonStatusBar1.Ribbon = Me.RibbonControl1
        Me.RibbonStatusBar1.Size = New System.Drawing.Size(907, 23)
        '
        'GroupControl2
        '
        Me.GroupControl2.AppearanceCaption.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.GroupControl2.AppearanceCaption.ForeColor = System.Drawing.Color.White
        Me.GroupControl2.AppearanceCaption.Options.UseFont = True
        Me.GroupControl2.AppearanceCaption.Options.UseForeColor = True
        Me.GroupControl2.Controls.Add(Me.gcDetalle)
        Me.GroupControl2.Location = New System.Drawing.Point(0, 184)
        Me.GroupControl2.LookAndFeel.SkinName = "Office 2016 Dark"
        Me.GroupControl2.LookAndFeel.UseDefaultLookAndFeel = False
        Me.GroupControl2.Name = "GroupControl2"
        Me.GroupControl2.Size = New System.Drawing.Size(907, 395)
        Me.GroupControl2.TabIndex = 15
        Me.GroupControl2.Text = ":: Materia Prima ::"
        '
        'gcDetalle
        '
        Me.gcDetalle.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gcDetalle.Location = New System.Drawing.Point(2, 21)
        Me.gcDetalle.MainView = Me.gvDetalle
        Me.gcDetalle.Name = "gcDetalle"
        Me.gcDetalle.Size = New System.Drawing.Size(903, 372)
        Me.gcDetalle.TabIndex = 0
        Me.gcDetalle.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.gvDetalle})
        '
        'gvDetalle
        '
        Me.gvDetalle.GridControl = Me.gcDetalle
        Me.gvDetalle.Name = "gvDetalle"
        Me.gvDetalle.OptionsView.ShowGroupPanel = False
        '
        'GroupNotas
        '
        Me.GroupNotas.AppearanceCaption.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupNotas.AppearanceCaption.Options.UseFont = True
        Me.GroupNotas.Controls.Add(Me.LabelControl6)
        Me.GroupNotas.Controls.Add(Me.lkProducto)
        Me.GroupNotas.Controls.Add(Me.bbEdit)
        Me.GroupNotas.Controls.Add(Me.bbAdd)
        Me.GroupNotas.Controls.Add(Me.lblNumero)
        Me.GroupNotas.Controls.Add(Me.LabelControl2)
        Me.GroupNotas.Location = New System.Drawing.Point(-1, 92)
        Me.GroupNotas.LookAndFeel.SkinName = "Office 2007 Blue"
        Me.GroupNotas.LookAndFeel.UseDefaultLookAndFeel = False
        Me.GroupNotas.Name = "GroupNotas"
        Me.GroupNotas.Size = New System.Drawing.Size(908, 88)
        Me.GroupNotas.TabIndex = 0
        Me.GroupNotas.Text = ":: Datos Generales ::"
        '
        'LabelControl6
        '
        Me.LabelControl6.Appearance.ForeColor = System.Drawing.Color.Black
        Me.LabelControl6.Location = New System.Drawing.Point(22, 57)
        Me.LabelControl6.Name = "LabelControl6"
        Me.LabelControl6.Size = New System.Drawing.Size(50, 13)
        Me.LabelControl6.TabIndex = 364
        Me.LabelControl6.Text = "Producto :"
        '
        'lkProducto
        '
        Me.lkProducto.Location = New System.Drawing.Point(86, 54)
        Me.lkProducto.Name = "lkProducto"
        Me.lkProducto.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.lkProducto.Properties.NullText = ""
        Me.lkProducto.Size = New System.Drawing.Size(352, 20)
        Me.lkProducto.TabIndex = 4
        '
        'bbEdit
        '
        Me.bbEdit.Location = New System.Drawing.Point(576, 52)
        Me.bbEdit.Name = "bbEdit"
        Me.bbEdit.Size = New System.Drawing.Size(100, 21)
        Me.bbEdit.TabIndex = 362
        Me.bbEdit.Text = "F2 - Editar Linea"
        '
        'bbAdd
        '
        Me.bbAdd.Location = New System.Drawing.Point(458, 53)
        Me.bbAdd.Name = "bbAdd"
        Me.bbAdd.Size = New System.Drawing.Size(100, 21)
        Me.bbAdd.TabIndex = 361
        Me.bbAdd.Text = "F1 - Agregar Linea"
        '
        'lblNumero
        '
        Me.lblNumero.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lblNumero.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblNumero.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lblNumero.Location = New System.Drawing.Point(86, 28)
        Me.lblNumero.Name = "lblNumero"
        Me.lblNumero.Size = New System.Drawing.Size(111, 20)
        Me.lblNumero.TabIndex = 3
        Me.lblNumero.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LabelControl2
        '
        Me.LabelControl2.Appearance.ForeColor = System.Drawing.Color.Black
        Me.LabelControl2.Location = New System.Drawing.Point(34, 32)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(40, 13)
        Me.LabelControl2.TabIndex = 306
        Me.LabelControl2.Text = "Código :"
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
        'frmReceta_Detalle
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(907, 602)
        Me.Controls.Add(Me.GroupNotas)
        Me.Controls.Add(Me.RibbonStatusBar1)
        Me.Controls.Add(Me.GroupControl2)
        Me.Controls.Add(Me.RibbonControl1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmReceta_Detalle"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = ":: Registro de Recetas ::"
        CType(Me.RibbonControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GroupControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl2.ResumeLayout(False)
        CType(Me.gcDetalle, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gvDetalle, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GroupNotas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupNotas.ResumeLayout(False)
        Me.GroupNotas.PerformLayout()
        CType(Me.lkProducto.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents RibbonControl1 As DevExpress.XtraBars.Ribbon.RibbonControl
    Friend WithEvents bClose As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents bbSave As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents barText As DevExpress.XtraBars.BarStaticItem
    Friend WithEvents RibbonPage1 As DevExpress.XtraBars.Ribbon.RibbonPage
    Friend WithEvents RibbonPageGroup2 As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents RibbonStatusBar1 As DevExpress.XtraBars.Ribbon.RibbonStatusBar
    Friend WithEvents GroupControl2 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents gcDetalle As DevExpress.XtraGrid.GridControl
    Friend WithEvents gvDetalle As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GroupNotas As DevExpress.XtraEditors.GroupControl
    Friend WithEvents lblNumero As System.Windows.Forms.Label
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtStatus As DevExpress.XtraBars.BarStaticItem
    Friend WithEvents bSave As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents DefaultLookAndFeel1 As DevExpress.LookAndFeel.DefaultLookAndFeel
    Friend WithEvents bbEdit As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents bbAdd As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LabelControl6 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lkProducto As DevExpress.XtraEditors.LookUpEdit
End Class
