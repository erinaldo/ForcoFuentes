<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmReceta_Open
    Inherits DevExpress.XtraEditors.XtraForm

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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmReceta_Open))
        Me.RibbonControl1 = New DevExpress.XtraBars.Ribbon.RibbonControl()
        Me.barText = New DevExpress.XtraBars.BarStaticItem()
        Me.bbAdd = New DevExpress.XtraBars.BarButtonItem()
        Me.bbEdit = New DevExpress.XtraBars.BarButtonItem()
        Me.bbExcel = New DevExpress.XtraBars.BarButtonItem()
        Me.bbClose = New DevExpress.XtraBars.BarButtonItem()
        Me.bbPrint = New DevExpress.XtraBars.BarSubItem()
        Me.bbClave = New DevExpress.XtraBars.BarButtonItem()
        Me.bbProducto = New DevExpress.XtraBars.BarButtonItem()
        Me.bbInventario = New DevExpress.XtraBars.BarButtonItem()
        Me.bbEspecie = New DevExpress.XtraBars.BarButtonItem()
        Me.bbCalidad = New DevExpress.XtraBars.BarButtonItem()
        Me.bbGeneral = New DevExpress.XtraBars.BarButtonItem()
        Me.bbDelete = New DevExpress.XtraBars.BarButtonItem()
        Me.bbDetalle = New DevExpress.XtraBars.BarButtonItem()
        Me.RibbonPage1 = New DevExpress.XtraBars.Ribbon.RibbonPage()
        Me.RibbonPageGroup1 = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.RibbonStatusBar1 = New DevExpress.XtraBars.Ribbon.RibbonStatusBar()
        Me.DefaultLookAndFeel1 = New DevExpress.LookAndFeel.DefaultLookAndFeel(Me.components)
        Me.GroupControl1 = New DevExpress.XtraEditors.GroupControl()
        Me.gcProducto = New DevExpress.XtraGrid.GridControl()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GroupControl2 = New DevExpress.XtraEditors.GroupControl()
        Me.bbProceso = New DevExpress.XtraEditors.SimpleButton()
        Me.txtNombre = New System.Windows.Forms.TextBox()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        CType(Me.RibbonControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl1.SuspendLayout()
        CType(Me.gcProducto, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GroupControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl2.SuspendLayout()
        Me.SuspendLayout()
        '
        'RibbonControl1
        '
        Me.RibbonControl1.ApplicationButtonText = Nothing
        Me.RibbonControl1.ExpandCollapseItem.Id = 0
        Me.RibbonControl1.Items.AddRange(New DevExpress.XtraBars.BarItem() {Me.RibbonControl1.ExpandCollapseItem, Me.barText, Me.bbAdd, Me.bbEdit, Me.bbExcel, Me.bbClose, Me.bbPrint, Me.bbClave, Me.bbProducto, Me.bbInventario, Me.bbEspecie, Me.bbCalidad, Me.bbGeneral, Me.bbDelete, Me.bbDetalle})
        Me.RibbonControl1.Location = New System.Drawing.Point(0, 0)
        Me.RibbonControl1.MaxItemId = 17
        Me.RibbonControl1.Name = "RibbonControl1"
        Me.RibbonControl1.Pages.AddRange(New DevExpress.XtraBars.Ribbon.RibbonPage() {Me.RibbonPage1})
        Me.RibbonControl1.ShowCategoryInCaption = False
        Me.RibbonControl1.ShowPageHeadersMode = DevExpress.XtraBars.Ribbon.ShowPageHeadersMode.Hide
        Me.RibbonControl1.ShowToolbarCustomizeItem = False
        Me.RibbonControl1.Size = New System.Drawing.Size(818, 93)
        Me.RibbonControl1.StatusBar = Me.RibbonStatusBar1
        Me.RibbonControl1.Toolbar.ShowCustomizeItem = False
        Me.RibbonControl1.ToolbarLocation = DevExpress.XtraBars.Ribbon.RibbonQuickAccessToolbarLocation.Hidden
        '
        'barText
        '
        Me.barText.Caption = "Registros : 0"
        Me.barText.Id = 0
        Me.barText.Name = "barText"
        Me.barText.TextAlignment = System.Drawing.StringAlignment.Near
        '
        'bbAdd
        '
        Me.bbAdd.Caption = "Agregar"
        Me.bbAdd.Id = 1
        Me.bbAdd.LargeGlyph = CType(resources.GetObject("bbAdd.LargeGlyph"), System.Drawing.Image)
        Me.bbAdd.Name = "bbAdd"
        '
        'bbEdit
        '
        Me.bbEdit.Caption = "Editar"
        Me.bbEdit.Id = 2
        Me.bbEdit.LargeGlyph = CType(resources.GetObject("bbEdit.LargeGlyph"), System.Drawing.Image)
        Me.bbEdit.Name = "bbEdit"
        '
        'bbExcel
        '
        Me.bbExcel.Caption = "Excel"
        Me.bbExcel.Id = 4
        Me.bbExcel.LargeGlyph = CType(resources.GetObject("bbExcel.LargeGlyph"), System.Drawing.Image)
        Me.bbExcel.Name = "bbExcel"
        '
        'bbClose
        '
        Me.bbClose.Caption = "Cerrar"
        Me.bbClose.Id = 5
        Me.bbClose.LargeGlyph = CType(resources.GetObject("bbClose.LargeGlyph"), System.Drawing.Image)
        Me.bbClose.Name = "bbClose"
        '
        'bbPrint
        '
        Me.bbPrint.Caption = "Reportes"
        Me.bbPrint.Id = 8
        Me.bbPrint.LargeGlyph = CType(resources.GetObject("bbPrint.LargeGlyph"), System.Drawing.Image)
        Me.bbPrint.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.bbClave), New DevExpress.XtraBars.LinkPersistInfo(Me.bbProducto), New DevExpress.XtraBars.LinkPersistInfo(Me.bbInventario), New DevExpress.XtraBars.LinkPersistInfo(Me.bbEspecie), New DevExpress.XtraBars.LinkPersistInfo(Me.bbCalidad)})
        Me.bbPrint.Name = "bbPrint"
        '
        'bbClave
        '
        Me.bbClave.Caption = "Orden: Codigo"
        Me.bbClave.Id = 9
        Me.bbClave.Name = "bbClave"
        '
        'bbProducto
        '
        Me.bbProducto.Caption = "Orden: Nombre de Producto"
        Me.bbProducto.Id = 10
        Me.bbProducto.Name = "bbProducto"
        '
        'bbInventario
        '
        Me.bbInventario.Caption = "Orden: Segmento"
        Me.bbInventario.Id = 11
        Me.bbInventario.Name = "bbInventario"
        '
        'bbEspecie
        '
        Me.bbEspecie.Caption = "Orden: Segmento + Familia"
        Me.bbEspecie.Id = 12
        Me.bbEspecie.Name = "bbEspecie"
        '
        'bbCalidad
        '
        Me.bbCalidad.Caption = "Orden: Segmento+Familia+Clase"
        Me.bbCalidad.Id = 13
        Me.bbCalidad.Name = "bbCalidad"
        '
        'bbGeneral
        '
        Me.bbGeneral.Caption = "Catalogo General"
        Me.bbGeneral.Id = 14
        Me.bbGeneral.LargeGlyph = CType(resources.GetObject("bbGeneral.LargeGlyph"), System.Drawing.Image)
        Me.bbGeneral.Name = "bbGeneral"
        '
        'bbDelete
        '
        Me.bbDelete.Caption = "Eliminar"
        Me.bbDelete.Id = 15
        Me.bbDelete.LargeGlyph = CType(resources.GetObject("bbDelete.LargeGlyph"), System.Drawing.Image)
        Me.bbDelete.Name = "bbDelete"
        '
        'bbDetalle
        '
        Me.bbDetalle.Caption = "Detalle"
        Me.bbDetalle.Id = 16
        Me.bbDetalle.LargeGlyph = CType(resources.GetObject("bbDetalle.LargeGlyph"), System.Drawing.Image)
        Me.bbDetalle.Name = "bbDetalle"
        '
        'RibbonPage1
        '
        Me.RibbonPage1.Groups.AddRange(New DevExpress.XtraBars.Ribbon.RibbonPageGroup() {Me.RibbonPageGroup1})
        Me.RibbonPage1.Name = "RibbonPage1"
        Me.RibbonPage1.Text = "RibbonPage1"
        '
        'RibbonPageGroup1
        '
        Me.RibbonPageGroup1.ItemLinks.Add(Me.bbAdd)
        Me.RibbonPageGroup1.ItemLinks.Add(Me.bbEdit)
        Me.RibbonPageGroup1.ItemLinks.Add(Me.bbDelete)
        Me.RibbonPageGroup1.ItemLinks.Add(Me.bbDetalle)
        Me.RibbonPageGroup1.ItemLinks.Add(Me.bbExcel)
        Me.RibbonPageGroup1.ItemLinks.Add(Me.bbClose)
        Me.RibbonPageGroup1.Name = "RibbonPageGroup1"
        '
        'RibbonStatusBar1
        '
        Me.RibbonStatusBar1.ItemLinks.Add(Me.barText)
        Me.RibbonStatusBar1.Location = New System.Drawing.Point(0, 477)
        Me.RibbonStatusBar1.Name = "RibbonStatusBar1"
        Me.RibbonStatusBar1.Ribbon = Me.RibbonControl1
        Me.RibbonStatusBar1.Size = New System.Drawing.Size(818, 23)
        '
        'DefaultLookAndFeel1
        '
        Me.DefaultLookAndFeel1.LookAndFeel.SkinName = "Money Twins"
        '
        'GroupControl1
        '
        Me.GroupControl1.AppearanceCaption.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.GroupControl1.AppearanceCaption.Options.UseFont = True
        Me.GroupControl1.Controls.Add(Me.gcProducto)
        Me.GroupControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupControl1.Location = New System.Drawing.Point(0, 93)
        Me.GroupControl1.LookAndFeel.SkinName = "Office 2016 Dark"
        Me.GroupControl1.LookAndFeel.UseDefaultLookAndFeel = False
        Me.GroupControl1.Name = "GroupControl1"
        Me.GroupControl1.Size = New System.Drawing.Size(818, 384)
        Me.GroupControl1.TabIndex = 1
        Me.GroupControl1.Text = ":: Listado de Recetas ::"
        '
        'gcProducto
        '
        Me.gcProducto.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gcProducto.Location = New System.Drawing.Point(2, 21)
        Me.gcProducto.LookAndFeel.SkinName = "Office 2016 Dark"
        Me.gcProducto.LookAndFeel.UseDefaultLookAndFeel = False
        Me.gcProducto.MainView = Me.GridView1
        Me.gcProducto.MenuManager = Me.RibbonControl1
        Me.gcProducto.Name = "gcProducto"
        Me.gcProducto.Size = New System.Drawing.Size(814, 361)
        Me.gcProducto.TabIndex = 0
        Me.gcProducto.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        '
        'GridView1
        '
        Me.GridView1.GridControl = Me.gcProducto
        Me.GridView1.Name = "GridView1"
        '
        'GroupControl2
        '
        Me.GroupControl2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupControl2.Controls.Add(Me.bbProceso)
        Me.GroupControl2.Controls.Add(Me.txtNombre)
        Me.GroupControl2.Controls.Add(Me.LabelControl2)
        Me.GroupControl2.Location = New System.Drawing.Point(268, 3)
        Me.GroupControl2.LookAndFeel.SkinName = "Office 2007 Blue"
        Me.GroupControl2.LookAndFeel.UseDefaultLookAndFeel = False
        Me.GroupControl2.Name = "GroupControl2"
        Me.GroupControl2.Size = New System.Drawing.Size(547, 86)
        Me.GroupControl2.TabIndex = 0
        Me.GroupControl2.Text = ":: Filtro ::"
        '
        'bbProceso
        '
        Me.bbProceso.Appearance.Options.UseTextOptions = True
        Me.bbProceso.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.bbProceso.Image = CType(resources.GetObject("bbProceso.Image"), System.Drawing.Image)
        Me.bbProceso.Location = New System.Drawing.Point(414, 51)
        Me.bbProceso.Name = "bbProceso"
        Me.bbProceso.Size = New System.Drawing.Size(95, 23)
        Me.bbProceso.TabIndex = 4
        Me.bbProceso.Text = "Actualizar"
        '
        'txtNombre
        '
        Me.txtNombre.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNombre.Location = New System.Drawing.Point(7, 51)
        Me.txtNombre.MaxLength = 300
        Me.txtNombre.Name = "txtNombre"
        Me.txtNombre.Size = New System.Drawing.Size(383, 21)
        Me.txtNombre.TabIndex = 1
        '
        'LabelControl2
        '
        Me.LabelControl2.Location = New System.Drawing.Point(7, 32)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(100, 13)
        Me.LabelControl2.TabIndex = 3
        Me.LabelControl2.Text = "Clave ó Descripción :"
        '
        'frmReceta_Open
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(818, 500)
        Me.Controls.Add(Me.GroupControl2)
        Me.Controls.Add(Me.GroupControl1)
        Me.Controls.Add(Me.RibbonStatusBar1)
        Me.Controls.Add(Me.RibbonControl1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmReceta_Open"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = ":: Listado de Recetas ::"
        CType(Me.RibbonControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl1.ResumeLayout(False)
        CType(Me.gcProducto, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GroupControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl2.ResumeLayout(False)
        Me.GroupControl2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents RibbonControl1 As DevExpress.XtraBars.Ribbon.RibbonControl
    Friend WithEvents barText As DevExpress.XtraBars.BarStaticItem
    Friend WithEvents bbAdd As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents bbEdit As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents bbExcel As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents bbClose As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents RibbonPage1 As DevExpress.XtraBars.Ribbon.RibbonPage
    Friend WithEvents RibbonPageGroup1 As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents RibbonStatusBar1 As DevExpress.XtraBars.Ribbon.RibbonStatusBar
    Friend WithEvents bbPrint As DevExpress.XtraBars.BarSubItem
    Friend WithEvents DefaultLookAndFeel1 As DevExpress.LookAndFeel.DefaultLookAndFeel
    Friend WithEvents GroupControl1 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents gcProducto As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents bbClave As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents bbProducto As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents bbInventario As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents bbEspecie As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents bbCalidad As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents GroupControl2 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtNombre As System.Windows.Forms.TextBox
    Friend WithEvents bbGeneral As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents bbProceso As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents bbDelete As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents bbDetalle As DevExpress.XtraBars.BarButtonItem
End Class
