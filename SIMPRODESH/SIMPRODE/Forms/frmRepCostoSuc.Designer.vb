﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRepCostoSuc
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmRepCostoSuc))
        Me.BarManager1 = New DevExpress.XtraBars.BarManager(Me.components)
        Me.barDockControlTop = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlBottom = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlLeft = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlRight = New DevExpress.XtraBars.BarDockControl()
        Me.RibbonControl1 = New DevExpress.XtraBars.Ribbon.RibbonControl()
        Me.bClose = New DevExpress.XtraBars.BarButtonItem()
        Me.bbPrint = New DevExpress.XtraBars.BarButtonItem()
        Me.bbExcel = New DevExpress.XtraBars.BarButtonItem()
        Me.RibbonPage2 = New DevExpress.XtraBars.Ribbon.RibbonPage()
        Me.RibbonPageGroup2 = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.gcDetalle = New DevExpress.XtraGrid.GridControl()
        Me.gvDetalle = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridView2 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GroupControl2 = New DevExpress.XtraEditors.GroupControl()
        Me.DefaultLookAndFeel1 = New DevExpress.LookAndFeel.DefaultLookAndFeel(Me.components)
        Me.LabelControl4 = New DevExpress.XtraEditors.LabelControl()
        Me.dtpDesde1 = New System.Windows.Forms.DateTimePicker()
        Me.bbRefresh = New DevExpress.XtraEditors.SimpleButton()
        Me.lkTienda = New DevExpress.XtraEditors.LookUpEdit()
        Me.LabelControl5 = New DevExpress.XtraEditors.LabelControl()
        CType(Me.BarManager1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RibbonControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gcDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gvDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GroupControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl2.SuspendLayout()
        CType(Me.lkTienda.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.barDockControlTop.Size = New System.Drawing.Size(985, 0)
        '
        'barDockControlBottom
        '
        Me.barDockControlBottom.CausesValidation = False
        Me.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.barDockControlBottom.Location = New System.Drawing.Point(0, 660)
        Me.barDockControlBottom.Size = New System.Drawing.Size(985, 0)
        '
        'barDockControlLeft
        '
        Me.barDockControlLeft.CausesValidation = False
        Me.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left
        Me.barDockControlLeft.Location = New System.Drawing.Point(0, 0)
        Me.barDockControlLeft.Size = New System.Drawing.Size(0, 660)
        '
        'barDockControlRight
        '
        Me.barDockControlRight.CausesValidation = False
        Me.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right
        Me.barDockControlRight.Location = New System.Drawing.Point(985, 0)
        Me.barDockControlRight.Size = New System.Drawing.Size(0, 660)
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
        Me.RibbonControl1.Size = New System.Drawing.Size(985, 93)
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
        Me.gcDetalle.Size = New System.Drawing.Size(980, 506)
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
        Me.GroupControl2.Location = New System.Drawing.Point(1, 131)
        Me.GroupControl2.LookAndFeel.SkinName = "Office 2016 Dark"
        Me.GroupControl2.LookAndFeel.UseDefaultLookAndFeel = False
        Me.GroupControl2.Name = "GroupControl2"
        Me.GroupControl2.Size = New System.Drawing.Size(984, 529)
        Me.GroupControl2.TabIndex = 17
        Me.GroupControl2.Text = ":: LISTADO ::"
        '
        'DefaultLookAndFeel1
        '
        Me.DefaultLookAndFeel1.LookAndFeel.SkinName = "Money Twins"
        '
        'LabelControl4
        '
        Me.LabelControl4.Location = New System.Drawing.Point(360, 102)
        Me.LabelControl4.Name = "LabelControl4"
        Me.LabelControl4.Size = New System.Drawing.Size(34, 13)
        Me.LabelControl4.TabIndex = 436
        Me.LabelControl4.Text = "Corte :"
        '
        'dtpDesde1
        '
        Me.dtpDesde1.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpDesde1.Location = New System.Drawing.Point(408, 98)
        Me.dtpDesde1.Name = "dtpDesde1"
        Me.dtpDesde1.Size = New System.Drawing.Size(117, 20)
        Me.dtpDesde1.TabIndex = 434
        '
        'bbRefresh
        '
        Me.bbRefresh.Appearance.Options.UseTextOptions = True
        Me.bbRefresh.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.bbRefresh.Image = CType(resources.GetObject("bbRefresh.Image"), System.Drawing.Image)
        Me.bbRefresh.Location = New System.Drawing.Point(540, 96)
        Me.bbRefresh.Name = "bbRefresh"
        Me.bbRefresh.Size = New System.Drawing.Size(88, 23)
        Me.bbRefresh.TabIndex = 442
        Me.bbRefresh.Text = "Consultar"
        '
        'lkTienda
        '
        Me.lkTienda.Location = New System.Drawing.Point(62, 99)
        Me.lkTienda.Name = "lkTienda"
        Me.lkTienda.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.lkTienda.Properties.NullText = ""
        Me.lkTienda.Size = New System.Drawing.Size(276, 20)
        Me.lkTienda.TabIndex = 448
        '
        'LabelControl5
        '
        Me.LabelControl5.Appearance.ForeColor = System.Drawing.Color.Black
        Me.LabelControl5.Location = New System.Drawing.Point(9, 102)
        Me.LabelControl5.Name = "LabelControl5"
        Me.LabelControl5.Size = New System.Drawing.Size(39, 13)
        Me.LabelControl5.TabIndex = 449
        Me.LabelControl5.Text = "Tienda :"
        '
        'frmRepCostoSuc
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(985, 660)
        Me.Controls.Add(Me.lkTienda)
        Me.Controls.Add(Me.LabelControl5)
        Me.Controls.Add(Me.bbRefresh)
        Me.Controls.Add(Me.LabelControl4)
        Me.Controls.Add(Me.dtpDesde1)
        Me.Controls.Add(Me.RibbonControl1)
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
        Me.Name = "frmRepCostoSuc"
        Me.Text = ":: Valorización de Inventario por Tienda ::"
        CType(Me.BarManager1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RibbonControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gcDetalle, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gvDetalle, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GroupControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl2.ResumeLayout(False)
        CType(Me.lkTienda.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents BarManager1 As DevExpress.XtraBars.BarManager
    Friend WithEvents barDockControlTop As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlBottom As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlLeft As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlRight As DevExpress.XtraBars.BarDockControl
    Friend WithEvents RibbonControl1 As DevExpress.XtraBars.Ribbon.RibbonControl
    Friend WithEvents bClose As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents bbPrint As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents RibbonPage2 As DevExpress.XtraBars.Ribbon.RibbonPage
    Friend WithEvents RibbonPageGroup2 As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents GroupControl2 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents gcDetalle As DevExpress.XtraGrid.GridControl
    Friend WithEvents gvDetalle As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridView2 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents DefaultLookAndFeel1 As DevExpress.LookAndFeel.DefaultLookAndFeel
    Friend WithEvents bbExcel As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents LabelControl4 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents dtpDesde1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents bbRefresh As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents lkTienda As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents LabelControl5 As DevExpress.XtraEditors.LabelControl
End Class
