<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRepCertExisteFamNo
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmRepCertExisteFamNo))
        Me.RibbonControl1 = New DevExpress.XtraBars.Ribbon.RibbonControl()
        Me.bClose = New DevExpress.XtraBars.BarButtonItem()
        Me.bbPrint = New DevExpress.XtraBars.BarButtonItem()
        Me.RibbonPage2 = New DevExpress.XtraBars.Ribbon.RibbonPage()
        Me.RibbonPageGroup2 = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.GroupControl1 = New DevExpress.XtraEditors.GroupControl()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.txtCrono = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl7 = New DevExpress.XtraEditors.LabelControl()
        Me.txtRemite2 = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl9 = New DevExpress.XtraEditors.LabelControl()
        Me.txtRemite1 = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl6 = New DevExpress.XtraEditors.LabelControl()
        Me.txtDestino2 = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl5 = New DevExpress.XtraEditors.LabelControl()
        Me.txtDestino1 = New DevExpress.XtraEditors.TextEdit()
        Me.lkFamiliaAux = New DevExpress.XtraEditors.LookUpEdit()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl4 = New DevExpress.XtraEditors.LabelControl()
        Me.dtpDesde = New System.Windows.Forms.DateTimePicker()
        CType(Me.RibbonControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl1.SuspendLayout()
        CType(Me.txtCrono.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtRemite2.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtRemite1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDestino2.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDestino1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lkFamiliaAux.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'RibbonControl1
        '
        Me.RibbonControl1.ApplicationButtonText = Nothing
        '
        '
        '
        Me.RibbonControl1.ExpandCollapseItem.Id = 0
        Me.RibbonControl1.ExpandCollapseItem.Name = ""
        Me.RibbonControl1.Items.AddRange(New DevExpress.XtraBars.BarItem() {Me.RibbonControl1.ExpandCollapseItem, Me.bClose, Me.bbPrint})
        Me.RibbonControl1.Location = New System.Drawing.Point(0, 0)
        Me.RibbonControl1.MaxItemId = 26
        Me.RibbonControl1.Name = "RibbonControl1"
        Me.RibbonControl1.Pages.AddRange(New DevExpress.XtraBars.Ribbon.RibbonPage() {Me.RibbonPage2})
        Me.RibbonControl1.SelectedPage = Me.RibbonPage2
        Me.RibbonControl1.ShowApplicationButton = DevExpress.Utils.DefaultBoolean.[False]
        Me.RibbonControl1.ShowCategoryInCaption = False
        Me.RibbonControl1.ShowExpandCollapseButton = DevExpress.Utils.DefaultBoolean.[True]
        Me.RibbonControl1.ShowPageHeadersMode = DevExpress.XtraBars.Ribbon.ShowPageHeadersMode.Hide
        Me.RibbonControl1.ShowToolbarCustomizeItem = False
        Me.RibbonControl1.Size = New System.Drawing.Size(520, 94)
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
        'RibbonPage2
        '
        Me.RibbonPage2.Groups.AddRange(New DevExpress.XtraBars.Ribbon.RibbonPageGroup() {Me.RibbonPageGroup2})
        Me.RibbonPage2.Name = "RibbonPage2"
        Me.RibbonPage2.Text = "Catálogo de Cuentas"
        '
        'RibbonPageGroup2
        '
        Me.RibbonPageGroup2.ItemLinks.Add(Me.bbPrint)
        Me.RibbonPageGroup2.ItemLinks.Add(Me.bClose)
        Me.RibbonPageGroup2.Name = "RibbonPageGroup2"
        Me.RibbonPageGroup2.ShowCaptionButton = False
        '
        'GroupControl1
        '
        Me.GroupControl1.AppearanceCaption.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.GroupControl1.AppearanceCaption.Options.UseFont = True
        Me.GroupControl1.Controls.Add(Me.LabelControl1)
        Me.GroupControl1.Controls.Add(Me.txtCrono)
        Me.GroupControl1.Controls.Add(Me.LabelControl7)
        Me.GroupControl1.Controls.Add(Me.txtRemite2)
        Me.GroupControl1.Controls.Add(Me.LabelControl9)
        Me.GroupControl1.Controls.Add(Me.txtRemite1)
        Me.GroupControl1.Controls.Add(Me.LabelControl6)
        Me.GroupControl1.Controls.Add(Me.txtDestino2)
        Me.GroupControl1.Controls.Add(Me.LabelControl5)
        Me.GroupControl1.Controls.Add(Me.txtDestino1)
        Me.GroupControl1.Controls.Add(Me.lkFamiliaAux)
        Me.GroupControl1.Controls.Add(Me.LabelControl2)
        Me.GroupControl1.Controls.Add(Me.LabelControl4)
        Me.GroupControl1.Controls.Add(Me.dtpDesde)
        Me.GroupControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupControl1.Location = New System.Drawing.Point(0, 94)
        Me.GroupControl1.LookAndFeel.SkinName = "Office 2007 Blue"
        Me.GroupControl1.LookAndFeel.UseDefaultLookAndFeel = False
        Me.GroupControl1.Name = "GroupControl1"
        Me.GroupControl1.Size = New System.Drawing.Size(520, 237)
        Me.GroupControl1.TabIndex = 365
        Me.GroupControl1.Text = ":: Datos Generales ::"
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(22, 195)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(63, 13)
        Me.LabelControl1.TabIndex = 399
        Me.LabelControl1.Text = "Cronologico :"
        '
        'txtCrono
        '
        Me.txtCrono.Location = New System.Drawing.Point(97, 192)
        Me.txtCrono.Name = "txtCrono"
        Me.txtCrono.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCrono.Properties.MaxLength = 150
        Me.txtCrono.Size = New System.Drawing.Size(411, 20)
        Me.txtCrono.TabIndex = 398
        '
        'LabelControl7
        '
        Me.LabelControl7.Location = New System.Drawing.Point(49, 170)
        Me.LabelControl7.Name = "LabelControl7"
        Me.LabelControl7.Size = New System.Drawing.Size(36, 13)
        Me.LabelControl7.TabIndex = 397
        Me.LabelControl7.Text = "Cargo :"
        '
        'txtRemite2
        '
        Me.txtRemite2.Location = New System.Drawing.Point(97, 166)
        Me.txtRemite2.Name = "txtRemite2"
        Me.txtRemite2.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtRemite2.Properties.MaxLength = 150
        Me.txtRemite2.Size = New System.Drawing.Size(411, 20)
        Me.txtRemite2.TabIndex = 396
        '
        'LabelControl9
        '
        Me.LabelControl9.Location = New System.Drawing.Point(45, 147)
        Me.LabelControl9.Name = "LabelControl9"
        Me.LabelControl9.Size = New System.Drawing.Size(40, 13)
        Me.LabelControl9.TabIndex = 395
        Me.LabelControl9.Text = "Remite :"
        '
        'txtRemite1
        '
        Me.txtRemite1.Location = New System.Drawing.Point(97, 143)
        Me.txtRemite1.Name = "txtRemite1"
        Me.txtRemite1.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtRemite1.Properties.MaxLength = 150
        Me.txtRemite1.Size = New System.Drawing.Size(411, 20)
        Me.txtRemite1.TabIndex = 394
        '
        'LabelControl6
        '
        Me.LabelControl6.Location = New System.Drawing.Point(49, 116)
        Me.LabelControl6.Name = "LabelControl6"
        Me.LabelControl6.Size = New System.Drawing.Size(36, 13)
        Me.LabelControl6.TabIndex = 393
        Me.LabelControl6.Text = "Cargo :"
        '
        'txtDestino2
        '
        Me.txtDestino2.Location = New System.Drawing.Point(97, 112)
        Me.txtDestino2.Name = "txtDestino2"
        Me.txtDestino2.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtDestino2.Properties.MaxLength = 150
        Me.txtDestino2.Size = New System.Drawing.Size(411, 20)
        Me.txtDestino2.TabIndex = 392
        '
        'LabelControl5
        '
        Me.LabelControl5.Location = New System.Drawing.Point(42, 93)
        Me.LabelControl5.Name = "LabelControl5"
        Me.LabelControl5.Size = New System.Drawing.Size(43, 13)
        Me.LabelControl5.TabIndex = 391
        Me.LabelControl5.Text = "Destino :"
        '
        'txtDestino1
        '
        Me.txtDestino1.Location = New System.Drawing.Point(97, 89)
        Me.txtDestino1.Name = "txtDestino1"
        Me.txtDestino1.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtDestino1.Properties.MaxLength = 150
        Me.txtDestino1.Size = New System.Drawing.Size(411, 20)
        Me.txtDestino1.TabIndex = 390
        '
        'lkFamiliaAux
        '
        Me.lkFamiliaAux.Location = New System.Drawing.Point(97, 36)
        Me.lkFamiliaAux.Name = "lkFamiliaAux"
        Me.lkFamiliaAux.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.lkFamiliaAux.Properties.NullText = ""
        Me.lkFamiliaAux.Size = New System.Drawing.Size(411, 20)
        Me.lkFamiliaAux.TabIndex = 378
        '
        'LabelControl2
        '
        Me.LabelControl2.Appearance.ForeColor = System.Drawing.Color.Black
        Me.LabelControl2.Location = New System.Drawing.Point(8, 40)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(77, 13)
        Me.LabelControl2.TabIndex = 379
        Me.LabelControl2.Text = "Familia Auxiliar :"
        '
        'LabelControl4
        '
        Me.LabelControl4.Location = New System.Drawing.Point(19, 66)
        Me.LabelControl4.Name = "LabelControl4"
        Me.LabelControl4.Size = New System.Drawing.Size(66, 13)
        Me.LabelControl4.TabIndex = 368
        Me.LabelControl4.Text = "Fecha Corte :"
        '
        'dtpDesde
        '
        Me.dtpDesde.Enabled = False
        Me.dtpDesde.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpDesde.Location = New System.Drawing.Point(97, 62)
        Me.dtpDesde.Name = "dtpDesde"
        Me.dtpDesde.Size = New System.Drawing.Size(117, 20)
        Me.dtpDesde.TabIndex = 363
        '
        'frmRepCertExisteFamNo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(520, 331)
        Me.Controls.Add(Me.GroupControl1)
        Me.Controls.Add(Me.RibbonControl1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmRepCertExisteFamNo"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = ":: Certificado de No Existencia por Familia ::"
        CType(Me.RibbonControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl1.ResumeLayout(False)
        Me.GroupControl1.PerformLayout()
        CType(Me.txtCrono.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtRemite2.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtRemite1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDestino2.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDestino1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lkFamiliaAux.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents RibbonControl1 As DevExpress.XtraBars.Ribbon.RibbonControl
    Friend WithEvents bClose As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents bbPrint As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents RibbonPage2 As DevExpress.XtraBars.Ribbon.RibbonPage
    Friend WithEvents RibbonPageGroup2 As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents GroupControl1 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents LabelControl7 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtRemite2 As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl9 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtRemite1 As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl6 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtDestino2 As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl5 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtDestino1 As DevExpress.XtraEditors.TextEdit
    Friend WithEvents lkFamiliaAux As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl4 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents dtpDesde As System.Windows.Forms.DateTimePicker
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtCrono As DevExpress.XtraEditors.TextEdit
End Class
