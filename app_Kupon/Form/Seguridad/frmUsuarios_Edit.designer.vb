<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmUsuarios_Edit
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmUsuarios_Edit))
        Me.XTCEmpresas = New DevExpress.XtraTab.XtraTabControl()
        Me.Empresas = New DevExpress.XtraTab.XtraTabPage()
        Me.rgEstatus = New DevExpress.XtraEditors.RadioGroup()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.bbReset = New System.Windows.Forms.Button()
        Me.txtKey2 = New System.Windows.Forms.TextBox()
        Me.txtKey1 = New System.Windows.Forms.TextBox()
        Me.txtUser = New System.Windows.Forms.TextBox()
        Me.rgSexo = New DevExpress.XtraEditors.RadioGroup()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtCedula = New System.Windows.Forms.TextBox()
        Me.txtApellido2 = New System.Windows.Forms.TextBox()
        Me.txtApellido1 = New System.Windows.Forms.TextBox()
        Me.txtNombre2 = New System.Windows.Forms.TextBox()
        Me.txtNombre1 = New System.Windows.Forms.TextBox()
        Me.XtraTabPage3 = New DevExpress.XtraTab.XtraTabPage()
        Me.gcEmpresas = New DevExpress.XtraGrid.GridControl()
        Me.GvEmpresas = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.XtraTabPage2 = New DevExpress.XtraTab.XtraTabPage()
        Me.gcRoles = New DevExpress.XtraGrid.GridControl()
        Me.gvRoles = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.BarManager1 = New DevExpress.XtraBars.BarManager(Me.components)
        Me.Bar2 = New DevExpress.XtraBars.Bar()
        Me.bbSave = New DevExpress.XtraBars.BarButtonItem()
        Me.bbRoles = New DevExpress.XtraBars.BarButtonItem()
        Me.bbClose = New DevExpress.XtraBars.BarButtonItem()
        Me.Bar3 = New DevExpress.XtraBars.Bar()
        Me.barText = New DevExpress.XtraBars.BarStaticItem()
        Me.barDockControlTop = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlBottom = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlLeft = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlRight = New DevExpress.XtraBars.BarDockControl()
        Me.DefaultLookAndFeel1 = New DevExpress.LookAndFeel.DefaultLookAndFeel(Me.components)
        CType(Me.XTCEmpresas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XTCEmpresas.SuspendLayout()
        Me.Empresas.SuspendLayout()
        CType(Me.rgEstatus.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.rgSexo.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XtraTabPage3.SuspendLayout()
        CType(Me.gcEmpresas, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GvEmpresas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XtraTabPage2.SuspendLayout()
        CType(Me.gcRoles, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gvRoles, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BarManager1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'XTCEmpresas
        '
        Me.XTCEmpresas.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.XTCEmpresas.Location = New System.Drawing.Point(0, 42)
        Me.XTCEmpresas.Name = "XTCEmpresas"
        Me.XTCEmpresas.SelectedTabPage = Me.Empresas
        Me.XTCEmpresas.Size = New System.Drawing.Size(507, 363)
        Me.XTCEmpresas.TabIndex = 0
        Me.XTCEmpresas.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.Empresas, Me.XtraTabPage3, Me.XtraTabPage2})
        '
        'Empresas
        '
        Me.Empresas.Controls.Add(Me.rgEstatus)
        Me.Empresas.Controls.Add(Me.Label4)
        Me.Empresas.Controls.Add(Me.Label3)
        Me.Empresas.Controls.Add(Me.Label2)
        Me.Empresas.Controls.Add(Me.bbReset)
        Me.Empresas.Controls.Add(Me.txtKey2)
        Me.Empresas.Controls.Add(Me.txtKey1)
        Me.Empresas.Controls.Add(Me.txtUser)
        Me.Empresas.Controls.Add(Me.rgSexo)
        Me.Empresas.Controls.Add(Me.Label9)
        Me.Empresas.Controls.Add(Me.Label8)
        Me.Empresas.Controls.Add(Me.Label7)
        Me.Empresas.Controls.Add(Me.Label6)
        Me.Empresas.Controls.Add(Me.Label5)
        Me.Empresas.Controls.Add(Me.txtCedula)
        Me.Empresas.Controls.Add(Me.txtApellido2)
        Me.Empresas.Controls.Add(Me.txtApellido1)
        Me.Empresas.Controls.Add(Me.txtNombre2)
        Me.Empresas.Controls.Add(Me.txtNombre1)
        Me.Empresas.Name = "Empresas"
        Me.Empresas.Size = New System.Drawing.Size(505, 341)
        Me.Empresas.Text = "Generales"
        '
        'rgEstatus
        '
        Me.rgEstatus.Location = New System.Drawing.Point(276, 57)
        Me.rgEstatus.Name = "rgEstatus"
        Me.rgEstatus.Properties.Items.AddRange(New DevExpress.XtraEditors.Controls.RadioGroupItem() {New DevExpress.XtraEditors.Controls.RadioGroupItem(Nothing, "Activo"), New DevExpress.XtraEditors.Controls.RadioGroupItem(Nothing, "Inactivo")})
        Me.rgEstatus.Size = New System.Drawing.Size(159, 24)
        Me.rgEstatus.TabIndex = 363
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(6, 214)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(108, 13)
        Me.Label4.TabIndex = 362
        Me.Label4.Text = "Confirmar Contraseña"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Label4.Visible = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(50, 188)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(64, 13)
        Me.Label3.TabIndex = 361
        Me.Label3.Text = "Contraseña:"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Label3.Visible = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(37, 162)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(77, 13)
        Me.Label2.TabIndex = 360
        Me.Label2.Text = "Usuario/Login:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'bbReset
        '
        Me.bbReset.Location = New System.Drawing.Point(160, 251)
        Me.bbReset.Name = "bbReset"
        Me.bbReset.Size = New System.Drawing.Size(160, 46)
        Me.bbReset.TabIndex = 358
        Me.bbReset.Text = "Restablecer Contraseña"
        Me.bbReset.UseVisualStyleBackColor = True
        '
        'txtKey2
        '
        Me.txtKey2.Location = New System.Drawing.Point(120, 211)
        Me.txtKey2.MaxLength = 50
        Me.txtKey2.Name = "txtKey2"
        Me.txtKey2.Size = New System.Drawing.Size(150, 20)
        Me.txtKey2.TabIndex = 7
        Me.txtKey2.Visible = False
        '
        'txtKey1
        '
        Me.txtKey1.Location = New System.Drawing.Point(120, 185)
        Me.txtKey1.MaxLength = 50
        Me.txtKey1.Name = "txtKey1"
        Me.txtKey1.Size = New System.Drawing.Size(150, 20)
        Me.txtKey1.TabIndex = 6
        Me.txtKey1.Visible = False
        '
        'txtUser
        '
        Me.txtUser.Location = New System.Drawing.Point(120, 159)
        Me.txtUser.MaxLength = 50
        Me.txtUser.Name = "txtUser"
        Me.txtUser.Size = New System.Drawing.Size(150, 20)
        Me.txtUser.TabIndex = 5
        '
        'rgSexo
        '
        Me.rgSexo.Location = New System.Drawing.Point(276, 27)
        Me.rgSexo.Name = "rgSexo"
        Me.rgSexo.Properties.Items.AddRange(New DevExpress.XtraEditors.Controls.RadioGroupItem() {New DevExpress.XtraEditors.Controls.RadioGroupItem(Nothing, "Masculino"), New DevExpress.XtraEditors.Controls.RadioGroupItem(Nothing, "Femenino")})
        Me.rgSexo.Size = New System.Drawing.Size(159, 24)
        Me.rgSexo.TabIndex = 8
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(21, 111)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(93, 13)
        Me.Label9.TabIndex = 352
        Me.Label9.Text = "Segundo Apellido:"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(35, 85)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(79, 13)
        Me.Label8.TabIndex = 351
        Me.Label8.Text = "Primer Apellido:"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(71, 137)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(43, 13)
        Me.Label7.TabIndex = 350
        Me.Label7.Text = "Cédula:"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(21, 59)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(93, 13)
        Me.Label6.TabIndex = 349
        Me.Label6.Text = "Segundo Nombre:"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(35, 33)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(79, 13)
        Me.Label5.TabIndex = 348
        Me.Label5.Text = "Primer Nombre:"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtCedula
        '
        Me.txtCedula.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCedula.Location = New System.Drawing.Point(120, 134)
        Me.txtCedula.MaxLength = 50
        Me.txtCedula.Name = "txtCedula"
        Me.txtCedula.Size = New System.Drawing.Size(150, 20)
        Me.txtCedula.TabIndex = 4
        '
        'txtApellido2
        '
        Me.txtApellido2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtApellido2.Location = New System.Drawing.Point(120, 108)
        Me.txtApellido2.Name = "txtApellido2"
        Me.txtApellido2.Size = New System.Drawing.Size(150, 20)
        Me.txtApellido2.TabIndex = 3
        '
        'txtApellido1
        '
        Me.txtApellido1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtApellido1.Location = New System.Drawing.Point(120, 82)
        Me.txtApellido1.Name = "txtApellido1"
        Me.txtApellido1.Size = New System.Drawing.Size(150, 20)
        Me.txtApellido1.TabIndex = 2
        '
        'txtNombre2
        '
        Me.txtNombre2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNombre2.Location = New System.Drawing.Point(120, 56)
        Me.txtNombre2.Name = "txtNombre2"
        Me.txtNombre2.Size = New System.Drawing.Size(150, 20)
        Me.txtNombre2.TabIndex = 1
        '
        'txtNombre1
        '
        Me.txtNombre1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNombre1.Location = New System.Drawing.Point(120, 30)
        Me.txtNombre1.Name = "txtNombre1"
        Me.txtNombre1.Size = New System.Drawing.Size(150, 20)
        Me.txtNombre1.TabIndex = 0
        '
        'XtraTabPage3
        '
        Me.XtraTabPage3.Controls.Add(Me.gcEmpresas)
        Me.XtraTabPage3.Name = "XtraTabPage3"
        Me.XtraTabPage3.Size = New System.Drawing.Size(505, 341)
        Me.XtraTabPage3.Text = "Empresas"
        '
        'gcEmpresas
        '
        Me.gcEmpresas.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gcEmpresas.Location = New System.Drawing.Point(0, 0)
        Me.gcEmpresas.MainView = Me.GvEmpresas
        Me.gcEmpresas.Name = "gcEmpresas"
        Me.gcEmpresas.Size = New System.Drawing.Size(505, 341)
        Me.gcEmpresas.TabIndex = 5
        Me.gcEmpresas.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GvEmpresas})
        '
        'GvEmpresas
        '
        Me.GvEmpresas.GridControl = Me.gcEmpresas
        Me.GvEmpresas.Name = "GvEmpresas"
        Me.GvEmpresas.OptionsCustomization.AllowColumnMoving = False
        Me.GvEmpresas.OptionsCustomization.AllowGroup = False
        Me.GvEmpresas.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom
        Me.GvEmpresas.OptionsView.ShowGroupPanel = False
        '
        'XtraTabPage2
        '
        Me.XtraTabPage2.Controls.Add(Me.gcRoles)
        Me.XtraTabPage2.Name = "XtraTabPage2"
        Me.XtraTabPage2.Size = New System.Drawing.Size(505, 341)
        Me.XtraTabPage2.Text = "Roles"
        '
        'gcRoles
        '
        Me.gcRoles.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gcRoles.Location = New System.Drawing.Point(0, 0)
        Me.gcRoles.MainView = Me.gvRoles
        Me.gcRoles.Name = "gcRoles"
        Me.gcRoles.Size = New System.Drawing.Size(505, 341)
        Me.gcRoles.TabIndex = 4
        Me.gcRoles.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.gvRoles})
        '
        'gvRoles
        '
        Me.gvRoles.GridControl = Me.gcRoles
        Me.gvRoles.Name = "gvRoles"
        Me.gvRoles.OptionsCustomization.AllowColumnMoving = False
        Me.gvRoles.OptionsCustomization.AllowGroup = False
        Me.gvRoles.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom
        Me.gvRoles.OptionsView.ShowGroupPanel = False
        '
        'BarManager1
        '
        Me.BarManager1.Bars.AddRange(New DevExpress.XtraBars.Bar() {Me.Bar2, Me.Bar3})
        Me.BarManager1.DockControls.Add(Me.barDockControlTop)
        Me.BarManager1.DockControls.Add(Me.barDockControlBottom)
        Me.BarManager1.DockControls.Add(Me.barDockControlLeft)
        Me.BarManager1.DockControls.Add(Me.barDockControlRight)
        Me.BarManager1.Form = Me
        Me.BarManager1.Items.AddRange(New DevExpress.XtraBars.BarItem() {Me.bbSave, Me.bbClose, Me.barText, Me.bbRoles})
        Me.BarManager1.MainMenu = Me.Bar2
        Me.BarManager1.MaxItemId = 4
        Me.BarManager1.StatusBar = Me.Bar3
        '
        'Bar2
        '
        Me.Bar2.BarName = "Main menu"
        Me.Bar2.DockCol = 0
        Me.Bar2.DockRow = 0
        Me.Bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Top
        Me.Bar2.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, Me.bbSave, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph), New DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, Me.bbRoles, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph), New DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, Me.bbClose, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)})
        Me.Bar2.OptionsBar.AllowQuickCustomization = False
        Me.Bar2.OptionsBar.MultiLine = True
        Me.Bar2.OptionsBar.UseWholeRow = True
        Me.Bar2.Text = "Main menu"
        '
        'bbSave
        '
        Me.bbSave.Caption = "Guardar"
        Me.bbSave.Glyph = CType(resources.GetObject("bbSave.Glyph"), System.Drawing.Image)
        Me.bbSave.Id = 0
        Me.bbSave.Name = "bbSave"
        '
        'bbRoles
        '
        Me.bbRoles.Caption = "Roles"
        Me.bbRoles.Glyph = CType(resources.GetObject("bbRoles.Glyph"), System.Drawing.Image)
        Me.bbRoles.Id = 3
        Me.bbRoles.Name = "bbRoles"
        '
        'bbClose
        '
        Me.bbClose.Caption = "Cerrar"
        Me.bbClose.Glyph = CType(resources.GetObject("bbClose.Glyph"), System.Drawing.Image)
        Me.bbClose.Id = 1
        Me.bbClose.Name = "bbClose"
        '
        'Bar3
        '
        Me.Bar3.BarName = "Status bar"
        Me.Bar3.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Bottom
        Me.Bar3.DockCol = 0
        Me.Bar3.DockRow = 0
        Me.Bar3.DockStyle = DevExpress.XtraBars.BarDockStyle.Bottom
        Me.Bar3.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.barText)})
        Me.Bar3.OptionsBar.AllowQuickCustomization = False
        Me.Bar3.OptionsBar.DrawDragBorder = False
        Me.Bar3.OptionsBar.UseWholeRow = True
        Me.Bar3.Text = "Status bar"
        '
        'barText
        '
        Me.barText.Id = 2
        Me.barText.Name = "barText"
        Me.barText.TextAlignment = System.Drawing.StringAlignment.Near
        '
        'barDockControlTop
        '
        Me.barDockControlTop.CausesValidation = False
        Me.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top
        Me.barDockControlTop.Location = New System.Drawing.Point(0, 0)
        Me.barDockControlTop.Size = New System.Drawing.Size(507, 42)
        '
        'barDockControlBottom
        '
        Me.barDockControlBottom.CausesValidation = False
        Me.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.barDockControlBottom.Location = New System.Drawing.Point(0, 402)
        Me.barDockControlBottom.Size = New System.Drawing.Size(507, 28)
        '
        'barDockControlLeft
        '
        Me.barDockControlLeft.CausesValidation = False
        Me.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left
        Me.barDockControlLeft.Location = New System.Drawing.Point(0, 42)
        Me.barDockControlLeft.Size = New System.Drawing.Size(0, 360)
        '
        'barDockControlRight
        '
        Me.barDockControlRight.CausesValidation = False
        Me.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right
        Me.barDockControlRight.Location = New System.Drawing.Point(507, 42)
        Me.barDockControlRight.Size = New System.Drawing.Size(0, 360)
        '
        'DefaultLookAndFeel1
        '
        Me.DefaultLookAndFeel1.LookAndFeel.SkinName = "Money Twins"
        '
        'frmUsuarios_Edit
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(507, 430)
        Me.Controls.Add(Me.XTCEmpresas)
        Me.Controls.Add(Me.barDockControlLeft)
        Me.Controls.Add(Me.barDockControlRight)
        Me.Controls.Add(Me.barDockControlBottom)
        Me.Controls.Add(Me.barDockControlTop)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmUsuarios_Edit"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = ":: Seguridad ::"
        CType(Me.XTCEmpresas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XTCEmpresas.ResumeLayout(False)
        Me.Empresas.ResumeLayout(False)
        Me.Empresas.PerformLayout()
        CType(Me.rgEstatus.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.rgSexo.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XtraTabPage3.ResumeLayout(False)
        CType(Me.gcEmpresas, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GvEmpresas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XtraTabPage2.ResumeLayout(False)
        CType(Me.gcRoles, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gvRoles, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BarManager1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents XTCEmpresas As DevExpress.XtraTab.XtraTabControl
    Friend WithEvents Empresas As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents XtraTabPage2 As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents BarManager1 As DevExpress.XtraBars.BarManager
    Friend WithEvents Bar2 As DevExpress.XtraBars.Bar
    Friend WithEvents Bar3 As DevExpress.XtraBars.Bar
    Friend WithEvents barDockControlTop As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlBottom As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlLeft As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlRight As DevExpress.XtraBars.BarDockControl
    Friend WithEvents bbSave As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents bbClose As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents txtCedula As System.Windows.Forms.TextBox
    Friend WithEvents txtApellido2 As System.Windows.Forms.TextBox
    Friend WithEvents txtApellido1 As System.Windows.Forms.TextBox
    Friend WithEvents txtNombre2 As System.Windows.Forms.TextBox
    Friend WithEvents txtNombre1 As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents rgSexo As DevExpress.XtraEditors.RadioGroup
    Friend WithEvents bbReset As System.Windows.Forms.Button
    Friend WithEvents txtKey2 As System.Windows.Forms.TextBox
    Friend WithEvents txtKey1 As System.Windows.Forms.TextBox
    Friend WithEvents txtUser As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents gcRoles As DevExpress.XtraGrid.GridControl
    Friend WithEvents gvRoles As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents barText As DevExpress.XtraBars.BarStaticItem
    Friend WithEvents DefaultLookAndFeel1 As DevExpress.LookAndFeel.DefaultLookAndFeel
    Friend WithEvents rgEstatus As DevExpress.XtraEditors.RadioGroup
    Friend WithEvents bbRoles As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents XtraTabPage3 As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents gcEmpresas As DevExpress.XtraGrid.GridControl
    Friend WithEvents GvEmpresas As DevExpress.XtraGrid.Views.Grid.GridView
End Class
