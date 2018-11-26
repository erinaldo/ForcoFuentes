<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmRepExistencia
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmRepExistencia))
        Me.BarManager1 = New DevExpress.XtraBars.BarManager(Me.components)
        Me.barDockControlTop = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlBottom = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlLeft = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlRight = New DevExpress.XtraBars.BarDockControl()
        Me.bbAdd = New DevExpress.XtraEditors.SimpleButton()
        Me.RibbonControl1 = New DevExpress.XtraBars.Ribbon.RibbonControl()
        Me.bClose = New DevExpress.XtraBars.BarButtonItem()
        Me.bbPrint = New DevExpress.XtraBars.BarButtonItem()
        Me.bbExcel = New DevExpress.XtraBars.BarButtonItem()
        Me.RibbonPage2 = New DevExpress.XtraBars.Ribbon.RibbonPage()
        Me.RibbonPageGroup2 = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.LabelControl4 = New DevExpress.XtraEditors.LabelControl()
        Me.dtpDesde1 = New System.Windows.Forms.DateTimePicker()
        Me.dtpHasta1 = New System.Windows.Forms.DateTimePicker()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.gcDetalle = New DevExpress.XtraGrid.GridControl()
        Me.gvDetalle = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridView2 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GroupControl2 = New DevExpress.XtraEditors.GroupControl()
        Me.DefaultLookAndFeel1 = New DevExpress.LookAndFeel.DefaultLookAndFeel(Me.components)
        Me.cbDollar = New DevExpress.XtraEditors.CalcEdit()
        Me.LabelControl21 = New DevExpress.XtraEditors.LabelControl()
        Me.bbDelete = New DevExpress.XtraEditors.SimpleButton()
        Me.bbImport = New DevExpress.XtraEditors.SimpleButton()
        Me.bbRefresh = New DevExpress.XtraEditors.SimpleButton()
        Me.GroupControl1 = New DevExpress.XtraEditors.GroupControl()
        Me.gcDetalle2 = New DevExpress.XtraGrid.GridControl()
        Me.gvDetalle2 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridView4 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridView5 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.bbClear = New DevExpress.XtraEditors.SimpleButton()
        Me.GroupControl3 = New DevExpress.XtraEditors.GroupControl()
        Me.bbDelete2 = New DevExpress.XtraEditors.SimpleButton()
        Me.bbAdd2 = New DevExpress.XtraEditors.SimpleButton()
        Me.gcLista2 = New DevExpress.XtraGrid.GridControl()
        Me.gvLista2 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.colOpt1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemCheckEdit2 = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.colData1 = New DevExpress.XtraGrid.Columns.GridColumn()
        CType(Me.BarManager1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RibbonControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gcDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gvDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GroupControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl2.SuspendLayout()
        CType(Me.cbDollar.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl1.SuspendLayout()
        CType(Me.gcDetalle2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gvDetalle2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GroupControl3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl3.SuspendLayout()
        CType(Me.gcLista2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gvLista2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemCheckEdit2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BarManager1
        '
        Me.BarManager1.DockControls.Add(Me.barDockControlTop)
        Me.BarManager1.DockControls.Add(Me.barDockControlBottom)
        Me.BarManager1.DockControls.Add(Me.barDockControlLeft)
        Me.BarManager1.DockControls.Add(Me.barDockControlRight)
        Me.BarManager1.Form = Me
        Me.BarManager1.MaxItemId = 0
        '
        'barDockControlTop
        '
        Me.barDockControlTop.CausesValidation = False
        Me.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top
        Me.barDockControlTop.Location = New System.Drawing.Point(0, 0)
        Me.barDockControlTop.Size = New System.Drawing.Size(945, 0)
        '
        'barDockControlBottom
        '
        Me.barDockControlBottom.CausesValidation = False
        Me.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.barDockControlBottom.Location = New System.Drawing.Point(0, 644)
        Me.barDockControlBottom.Size = New System.Drawing.Size(945, 0)
        '
        'barDockControlLeft
        '
        Me.barDockControlLeft.CausesValidation = False
        Me.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left
        Me.barDockControlLeft.Location = New System.Drawing.Point(0, 0)
        Me.barDockControlLeft.Size = New System.Drawing.Size(0, 644)
        '
        'barDockControlRight
        '
        Me.barDockControlRight.CausesValidation = False
        Me.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right
        Me.barDockControlRight.Location = New System.Drawing.Point(945, 0)
        Me.barDockControlRight.Size = New System.Drawing.Size(0, 644)
        '
        'bbAdd
        '
        Me.bbAdd.Location = New System.Drawing.Point(6, 153)
        Me.bbAdd.Name = "bbAdd"
        Me.bbAdd.Size = New System.Drawing.Size(93, 21)
        Me.bbAdd.TabIndex = 4
        Me.bbAdd.Text = "F1 - Agregar Fila"
        '
        'RibbonControl1
        '
        Me.RibbonControl1.ApplicationButtonText = Nothing
        Me.RibbonControl1.ExpandCollapseItem.Id = 0
        Me.RibbonControl1.Items.AddRange(New DevExpress.XtraBars.BarItem() {Me.RibbonControl1.ExpandCollapseItem, Me.bClose, Me.bbPrint, Me.bbExcel})
        Me.RibbonControl1.Location = New System.Drawing.Point(0, 0)
        Me.RibbonControl1.MaxItemId = 27
        Me.RibbonControl1.Name = "RibbonControl1"
        Me.RibbonControl1.Pages.AddRange(New DevExpress.XtraBars.Ribbon.RibbonPage() {Me.RibbonPage2})
        Me.RibbonControl1.ShowApplicationButton = DevExpress.Utils.DefaultBoolean.[False]
        Me.RibbonControl1.ShowCategoryInCaption = False
        Me.RibbonControl1.ShowExpandCollapseButton = DevExpress.Utils.DefaultBoolean.[True]
        Me.RibbonControl1.ShowPageHeadersMode = DevExpress.XtraBars.Ribbon.ShowPageHeadersMode.Hide
        Me.RibbonControl1.ShowToolbarCustomizeItem = False
        Me.RibbonControl1.Size = New System.Drawing.Size(945, 93)
        Me.RibbonControl1.Toolbar.ShowCustomizeItem = False
        Me.RibbonControl1.ToolbarLocation = DevExpress.XtraBars.Ribbon.RibbonQuickAccessToolbarLocation.Hidden
        '
        'bClose
        '
        Me.bClose.Caption = "Cerrar"
        Me.bClose.Id = 21
        Me.bClose.LargeGlyph = CType(resources.GetObject("bClose.LargeGlyph"), System.Drawing.Image)
        Me.bClose.Name = "bClose"
        '
        'bbPrint
        '
        Me.bbPrint.Caption = "Ver"
        Me.bbPrint.Id = 25
        Me.bbPrint.LargeGlyph = CType(resources.GetObject("bbPrint.LargeGlyph"), System.Drawing.Image)
        Me.bbPrint.Name = "bbPrint"
        '
        'bbExcel
        '
        Me.bbExcel.Caption = "Excel"
        Me.bbExcel.Id = 26
        Me.bbExcel.LargeGlyph = CType(resources.GetObject("bbExcel.LargeGlyph"), System.Drawing.Image)
        Me.bbExcel.Name = "bbExcel"
        '
        'RibbonPage2
        '
        Me.RibbonPage2.Groups.AddRange(New DevExpress.XtraBars.Ribbon.RibbonPageGroup() {Me.RibbonPageGroup2})
        Me.RibbonPage2.Name = "RibbonPage2"
        Me.RibbonPage2.Text = "Catálogo de Cuentas"
        '
        'RibbonPageGroup2
        '
        Me.RibbonPageGroup2.ItemLinks.Add(Me.bbExcel)
        Me.RibbonPageGroup2.ItemLinks.Add(Me.bClose)
        Me.RibbonPageGroup2.Name = "RibbonPageGroup2"
        Me.RibbonPageGroup2.ShowCaptionButton = False
        '
        'LabelControl4
        '
        Me.LabelControl4.Location = New System.Drawing.Point(8, 102)
        Me.LabelControl4.Name = "LabelControl4"
        Me.LabelControl4.Size = New System.Drawing.Size(37, 13)
        Me.LabelControl4.TabIndex = 382
        Me.LabelControl4.Text = "Desde :"
        '
        'dtpDesde1
        '
        Me.dtpDesde1.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpDesde1.Location = New System.Drawing.Point(52, 98)
        Me.dtpDesde1.Name = "dtpDesde1"
        Me.dtpDesde1.Size = New System.Drawing.Size(103, 20)
        Me.dtpDesde1.TabIndex = 0
        '
        'dtpHasta1
        '
        Me.dtpHasta1.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpHasta1.Location = New System.Drawing.Point(52, 124)
        Me.dtpHasta1.Name = "dtpHasta1"
        Me.dtpHasta1.Size = New System.Drawing.Size(103, 20)
        Me.dtpHasta1.TabIndex = 1
        '
        'LabelControl2
        '
        Me.LabelControl2.Location = New System.Drawing.Point(10, 128)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(35, 13)
        Me.LabelControl2.TabIndex = 383
        Me.LabelControl2.Text = "Hasta :"
        '
        'GridView1
        '
        Me.GridView1.GridControl = Me.gcDetalle
        Me.GridView1.Name = "GridView1"
        '
        'gcDetalle
        '
        Me.gcDetalle.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gcDetalle.Location = New System.Drawing.Point(2, 21)
        Me.gcDetalle.MainView = Me.gvDetalle
        Me.gcDetalle.Name = "gcDetalle"
        Me.gcDetalle.Size = New System.Drawing.Size(295, 190)
        Me.gcDetalle.TabIndex = 0
        Me.gcDetalle.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.gvDetalle, Me.GridView2, Me.GridView1})
        '
        'gvDetalle
        '
        Me.gvDetalle.GridControl = Me.gcDetalle
        Me.gvDetalle.Name = "gvDetalle"
        Me.gvDetalle.OptionsView.ShowGroupPanel = False
        '
        'GridView2
        '
        Me.GridView2.GridControl = Me.gcDetalle
        Me.GridView2.Name = "GridView2"
        '
        'GroupControl2
        '
        Me.GroupControl2.AppearanceCaption.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.GroupControl2.AppearanceCaption.ForeColor = System.Drawing.Color.White
        Me.GroupControl2.AppearanceCaption.Options.UseFont = True
        Me.GroupControl2.AppearanceCaption.Options.UseForeColor = True
        Me.GroupControl2.Controls.Add(Me.gcDetalle)
        Me.GroupControl2.Location = New System.Drawing.Point(1, 180)
        Me.GroupControl2.LookAndFeel.SkinName = "Office 2016 Dark"
        Me.GroupControl2.LookAndFeel.UseDefaultLookAndFeel = False
        Me.GroupControl2.Name = "GroupControl2"
        Me.GroupControl2.Size = New System.Drawing.Size(299, 213)
        Me.GroupControl2.TabIndex = 17
        Me.GroupControl2.Text = ":: ARTICULOS ::"
        '
        'DefaultLookAndFeel1
        '
        Me.DefaultLookAndFeel1.LookAndFeel.SkinName = "Money Twins"
        '
        'cbDollar
        '
        Me.cbDollar.EditValue = New Decimal(New Integer() {700, 0, 0, 0})
        Me.cbDollar.Location = New System.Drawing.Point(209, 96)
        Me.cbDollar.Name = "cbDollar"
        Me.cbDollar.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cbDollar.Properties.DisplayFormat.FormatString = "n2"
        Me.cbDollar.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.cbDollar.Properties.EditFormat.FormatString = "n2"
        Me.cbDollar.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.cbDollar.Size = New System.Drawing.Size(91, 20)
        Me.cbDollar.TabIndex = 400
        '
        'LabelControl21
        '
        Me.LabelControl21.Appearance.ForeColor = System.Drawing.Color.Black
        Me.LabelControl21.Location = New System.Drawing.Point(169, 99)
        Me.LabelControl21.Name = "LabelControl21"
        Me.LabelControl21.Size = New System.Drawing.Size(34, 13)
        Me.LabelControl21.TabIndex = 401
        Me.LabelControl21.Text = "Dollar :"
        '
        'bbDelete
        '
        Me.bbDelete.Location = New System.Drawing.Point(101, 153)
        Me.bbDelete.Name = "bbDelete"
        Me.bbDelete.Size = New System.Drawing.Size(93, 21)
        Me.bbDelete.TabIndex = 407
        Me.bbDelete.Text = "F2 - Borrar Fila"
        Me.bbDelete.ToolTip = "Seleccione la fila a eliminar"
        '
        'bbImport
        '
        Me.bbImport.Location = New System.Drawing.Point(197, 153)
        Me.bbImport.Name = "bbImport"
        Me.bbImport.Size = New System.Drawing.Size(103, 21)
        Me.bbImport.TabIndex = 413
        Me.bbImport.Text = "F3 - Importar Filtro"
        Me.bbImport.ToolTip = "Archivo Excel"
        Me.bbImport.ToolTipTitle = "Importar archivo de excel para aplicar filtro"
        '
        'bbRefresh
        '
        Me.bbRefresh.Appearance.Options.UseTextOptions = True
        Me.bbRefresh.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.bbRefresh.Image = CType(resources.GetObject("bbRefresh.Image"), System.Drawing.Image)
        Me.bbRefresh.Location = New System.Drawing.Point(304, 181)
        Me.bbRefresh.Name = "bbRefresh"
        Me.bbRefresh.Size = New System.Drawing.Size(88, 23)
        Me.bbRefresh.TabIndex = 447
        Me.bbRefresh.Text = "Consultar"
        '
        'GroupControl1
        '
        Me.GroupControl1.AppearanceCaption.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.GroupControl1.AppearanceCaption.ForeColor = System.Drawing.Color.White
        Me.GroupControl1.AppearanceCaption.Options.UseFont = True
        Me.GroupControl1.AppearanceCaption.Options.UseForeColor = True
        Me.GroupControl1.Controls.Add(Me.gcDetalle2)
        Me.GroupControl1.Location = New System.Drawing.Point(301, 207)
        Me.GroupControl1.LookAndFeel.SkinName = "Office 2016 Dark"
        Me.GroupControl1.LookAndFeel.UseDefaultLookAndFeel = False
        Me.GroupControl1.Name = "GroupControl1"
        Me.GroupControl1.Size = New System.Drawing.Size(643, 436)
        Me.GroupControl1.TabIndex = 446
        Me.GroupControl1.Text = ":: DETALLE DE ARTICULOS ::"
        '
        'gcDetalle2
        '
        Me.gcDetalle2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gcDetalle2.Location = New System.Drawing.Point(2, 21)
        Me.gcDetalle2.MainView = Me.gvDetalle2
        Me.gcDetalle2.Name = "gcDetalle2"
        Me.gcDetalle2.Size = New System.Drawing.Size(639, 413)
        Me.gcDetalle2.TabIndex = 0
        Me.gcDetalle2.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.gvDetalle2, Me.GridView4, Me.GridView5})
        '
        'gvDetalle2
        '
        Me.gvDetalle2.GridControl = Me.gcDetalle2
        Me.gvDetalle2.Name = "gvDetalle2"
        Me.gvDetalle2.OptionsView.ShowGroupPanel = False
        '
        'GridView4
        '
        Me.GridView4.GridControl = Me.gcDetalle2
        Me.GridView4.Name = "GridView4"
        '
        'GridView5
        '
        Me.GridView5.GridControl = Me.gcDetalle2
        Me.GridView5.Name = "GridView5"
        '
        'bbClear
        '
        Me.bbClear.Appearance.Options.UseTextOptions = True
        Me.bbClear.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.bbClear.Image = CType(resources.GetObject("bbClear.Image"), System.Drawing.Image)
        Me.bbClear.Location = New System.Drawing.Point(397, 181)
        Me.bbClear.Name = "bbClear"
        Me.bbClear.Size = New System.Drawing.Size(88, 23)
        Me.bbClear.TabIndex = 453
        Me.bbClear.Text = "Limpiar"
        '
        'GroupControl3
        '
        Me.GroupControl3.AppearanceCaption.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupControl3.AppearanceCaption.Options.UseFont = True
        Me.GroupControl3.AppearanceCaption.Options.UseTextOptions = True
        Me.GroupControl3.AppearanceCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GroupControl3.Controls.Add(Me.bbDelete2)
        Me.GroupControl3.Controls.Add(Me.bbAdd2)
        Me.GroupControl3.Controls.Add(Me.gcLista2)
        Me.GroupControl3.Location = New System.Drawing.Point(1, 394)
        Me.GroupControl3.LookAndFeel.SkinName = "Office 2016 Dark"
        Me.GroupControl3.LookAndFeel.UseDefaultLookAndFeel = False
        Me.GroupControl3.Name = "GroupControl3"
        Me.GroupControl3.Size = New System.Drawing.Size(299, 249)
        Me.GroupControl3.TabIndex = 467
        Me.GroupControl3.Text = ":: TIENDAS ::"
        '
        'bbDelete2
        '
        Me.bbDelete2.Image = CType(resources.GetObject("bbDelete2.Image"), System.Drawing.Image)
        Me.bbDelete2.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter
        Me.bbDelete2.Location = New System.Drawing.Point(30, 1)
        Me.bbDelete2.Name = "bbDelete2"
        Me.bbDelete2.Size = New System.Drawing.Size(23, 19)
        Me.bbDelete2.TabIndex = 628
        Me.bbDelete2.Text = "6"
        Me.bbDelete2.ToolTip = "Desmarcar Todos !!!"
        Me.bbDelete2.ToolTipTitle = "Personas"
        '
        'bbAdd2
        '
        Me.bbAdd2.Image = CType(resources.GetObject("bbAdd2.Image"), System.Drawing.Image)
        Me.bbAdd2.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter
        Me.bbAdd2.Location = New System.Drawing.Point(4, 1)
        Me.bbAdd2.Name = "bbAdd2"
        Me.bbAdd2.Size = New System.Drawing.Size(23, 19)
        Me.bbAdd2.TabIndex = 627
        Me.bbAdd2.Text = "6"
        Me.bbAdd2.ToolTip = "Marcar Todos !!!"
        Me.bbAdd2.ToolTipTitle = "Personas"
        '
        'gcLista2
        '
        Me.gcLista2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gcLista2.Location = New System.Drawing.Point(2, 21)
        Me.gcLista2.MainView = Me.gvLista2
        Me.gcLista2.MenuManager = Me.RibbonControl1
        Me.gcLista2.Name = "gcLista2"
        Me.gcLista2.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemCheckEdit2})
        Me.gcLista2.Size = New System.Drawing.Size(295, 226)
        Me.gcLista2.TabIndex = 0
        Me.gcLista2.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.gvLista2})
        '
        'gvLista2
        '
        Me.gvLista2.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colOpt1, Me.colData1})
        Me.gvLista2.GridControl = Me.gcLista2
        Me.gvLista2.Name = "gvLista2"
        Me.gvLista2.OptionsView.ShowGroupPanel = False
        '
        'colOpt1
        '
        Me.colOpt1.Caption = "Opcion"
        Me.colOpt1.ColumnEdit = Me.RepositoryItemCheckEdit2
        Me.colOpt1.FieldName = "optSelection"
        Me.colOpt1.Name = "colOpt1"
        Me.colOpt1.Visible = True
        Me.colOpt1.VisibleIndex = 0
        Me.colOpt1.Width = 45
        '
        'RepositoryItemCheckEdit2
        '
        Me.RepositoryItemCheckEdit2.AutoHeight = False
        Me.RepositoryItemCheckEdit2.Name = "RepositoryItemCheckEdit2"
        '
        'colData1
        '
        Me.colData1.Caption = "Sucusal"
        Me.colData1.FieldName = "Suc_Nombre"
        Me.colData1.Name = "colData1"
        Me.colData1.Visible = True
        Me.colData1.VisibleIndex = 1
        Me.colData1.Width = 250
        '
        'frmRepExistencia
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(945, 644)
        Me.Controls.Add(Me.GroupControl3)
        Me.Controls.Add(Me.bbClear)
        Me.Controls.Add(Me.bbRefresh)
        Me.Controls.Add(Me.GroupControl1)
        Me.Controls.Add(Me.bbImport)
        Me.Controls.Add(Me.bbDelete)
        Me.Controls.Add(Me.cbDollar)
        Me.Controls.Add(Me.LabelControl21)
        Me.Controls.Add(Me.LabelControl2)
        Me.Controls.Add(Me.LabelControl4)
        Me.Controls.Add(Me.dtpDesde1)
        Me.Controls.Add(Me.dtpHasta1)
        Me.Controls.Add(Me.RibbonControl1)
        Me.Controls.Add(Me.bbAdd)
        Me.Controls.Add(Me.GroupControl2)
        Me.Controls.Add(Me.barDockControlLeft)
        Me.Controls.Add(Me.barDockControlRight)
        Me.Controls.Add(Me.barDockControlBottom)
        Me.Controls.Add(Me.barDockControlTop)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmRepExistencia"
        Me.Text = ":: Existencias de Artículo ::"
        CType(Me.BarManager1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RibbonControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gcDetalle, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gvDetalle, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GroupControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl2.ResumeLayout(False)
        CType(Me.cbDollar.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl1.ResumeLayout(False)
        CType(Me.gcDetalle2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gvDetalle2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GroupControl3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl3.ResumeLayout(False)
        CType(Me.gcLista2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gvLista2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemCheckEdit2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents BarManager1 As DevExpress.XtraBars.BarManager
    Friend WithEvents barDockControlTop As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlBottom As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlLeft As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlRight As DevExpress.XtraBars.BarDockControl
    Friend WithEvents bbAdd As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents RibbonControl1 As DevExpress.XtraBars.Ribbon.RibbonControl
    Friend WithEvents bClose As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents bbPrint As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents RibbonPage2 As DevExpress.XtraBars.Ribbon.RibbonPage
    Friend WithEvents RibbonPageGroup2 As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents LabelControl4 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents dtpDesde1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpHasta1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents GroupControl2 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents gcDetalle As DevExpress.XtraGrid.GridControl
    Friend WithEvents gvDetalle As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridView2 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents DefaultLookAndFeel1 As DevExpress.LookAndFeel.DefaultLookAndFeel
    Friend WithEvents cbDollar As DevExpress.XtraEditors.CalcEdit
    Friend WithEvents LabelControl21 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents bbExcel As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents bbDelete As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents bbImport As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents bbRefresh As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GroupControl1 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents gcDetalle2 As DevExpress.XtraGrid.GridControl
    Friend WithEvents gvDetalle2 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridView4 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridView5 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents bbClear As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GroupControl3 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents bbDelete2 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents bbAdd2 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents gcLista2 As DevExpress.XtraGrid.GridControl
    Friend WithEvents gvLista2 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents colOpt1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemCheckEdit2 As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents colData1 As DevExpress.XtraGrid.Columns.GridColumn
End Class
