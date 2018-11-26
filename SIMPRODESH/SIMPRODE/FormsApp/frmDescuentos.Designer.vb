<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDescuentos
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmDescuentos))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.cbDescuentos = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.btnCargarExcel = New System.Windows.Forms.Button()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.btnEliminar = New System.Windows.Forms.Button()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtDescArt = New System.Windows.Forms.TextBox()
        Me.txtCodigoArt = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.dgvArticulo = New System.Windows.Forms.DataGridView()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.dthorafin = New System.Windows.Forms.DateTimePicker()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.dthorain = New System.Windows.Forms.DateTimePicker()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.dtFin = New System.Windows.Forms.DateTimePicker()
        Me.dtInicio = New System.Windows.Forms.DateTimePicker()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.ckSabado = New System.Windows.Forms.CheckBox()
        Me.ckViernes = New System.Windows.Forms.CheckBox()
        Me.ckJueves = New System.Windows.Forms.CheckBox()
        Me.ckMiercoles = New System.Windows.Forms.CheckBox()
        Me.ckMartes = New System.Windows.Forms.CheckBox()
        Me.ckLunes = New System.Windows.Forms.CheckBox()
        Me.ckDomingo = New System.Windows.Forms.CheckBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.dgvRangos = New System.Windows.Forms.DataGridView()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.dgvSucursales = New System.Windows.Forms.DataGridView()
        Me.GroupBox1.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        CType(Me.dgvArticulo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage2.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.dgvRangos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage3.SuspendLayout()
        CType(Me.dgvSucursales, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.White
        Me.GroupBox1.Controls.Add(Me.Button2)
        Me.GroupBox1.Controls.Add(Me.cbDescuentos)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.ForeColor = System.Drawing.Color.MidnightBlue
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(694, 73)
        Me.GroupBox1.TabIndex = 6
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Descuentos"
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.Color.MidnightBlue
        Me.Button2.BackgroundImage = Global.SIMPRODE.My.Resources.Resources.ver
        Me.Button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button2.FlatAppearance.BorderSize = 0
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button2.Location = New System.Drawing.Point(379, 28)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(81, 25)
        Me.Button2.TabIndex = 3
        Me.ToolTip1.SetToolTip(Me.Button2, "Ver Articulos Descuento")
        Me.Button2.UseVisualStyleBackColor = False
        '
        'cbDescuentos
        '
        Me.cbDescuentos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbDescuentos.FormattingEnabled = True
        Me.cbDescuentos.Location = New System.Drawing.Point(118, 29)
        Me.cbDescuentos.Name = "cbDescuentos"
        Me.cbDescuentos.Size = New System.Drawing.Size(255, 26)
        Me.cbDescuentos.TabIndex = 1
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(7, 34)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(84, 18)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Descuentos:"
        '
        'btnCargarExcel
        '
        Me.btnCargarExcel.BackColor = System.Drawing.Color.MidnightBlue
        Me.btnCargarExcel.BackgroundImage = Global.SIMPRODE.My.Resources.Resources.import1
        Me.btnCargarExcel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnCargarExcel.FlatAppearance.BorderSize = 0
        Me.btnCargarExcel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCargarExcel.Location = New System.Drawing.Point(612, 26)
        Me.btnCargarExcel.Name = "btnCargarExcel"
        Me.btnCargarExcel.Size = New System.Drawing.Size(47, 47)
        Me.btnCargarExcel.TabIndex = 33
        Me.ToolTip1.SetToolTip(Me.btnCargarExcel, "Importar Articulos de Excel")
        Me.btnCargarExcel.UseVisualStyleBackColor = False
        '
        'Button4
        '
        Me.Button4.BackColor = System.Drawing.Color.MidnightBlue
        Me.Button4.BackgroundImage = Global.SIMPRODE.My.Resources.Resources.f3_
        Me.Button4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button4.FlatAppearance.BorderSize = 0
        Me.Button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button4.Location = New System.Drawing.Point(128, 26)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(47, 47)
        Me.Button4.TabIndex = 32
        Me.ToolTip1.SetToolTip(Me.Button4, "Agregar Articulo Por Departamento")
        Me.Button4.UseVisualStyleBackColor = False
        '
        'Button3
        '
        Me.Button3.BackColor = System.Drawing.Color.MidnightBlue
        Me.Button3.BackgroundImage = Global.SIMPRODE.My.Resources.Resources.f2_
        Me.Button3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button3.FlatAppearance.BorderSize = 0
        Me.Button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button3.Location = New System.Drawing.Point(75, 26)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(47, 47)
        Me.Button3.TabIndex = 31
        Me.ToolTip1.SetToolTip(Me.Button3, "Agregar Articulos Por Categoria")
        Me.Button3.UseVisualStyleBackColor = False
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.MidnightBlue
        Me.Button1.BackgroundImage = Global.SIMPRODE.My.Resources.Resources.f11
        Me.Button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button1.FlatAppearance.BorderSize = 0
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Location = New System.Drawing.Point(22, 26)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(47, 47)
        Me.Button1.TabIndex = 30
        Me.ToolTip1.SetToolTip(Me.Button1, "Buscar Por Nombre Del Articulo")
        Me.Button1.UseVisualStyleBackColor = False
        '
        'btnEliminar
        '
        Me.btnEliminar.BackColor = System.Drawing.Color.MidnightBlue
        Me.btnEliminar.BackgroundImage = Global.SIMPRODE.My.Resources.Resources.eliminar
        Me.btnEliminar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnEliminar.FlatAppearance.BorderSize = 0
        Me.btnEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnEliminar.Location = New System.Drawing.Point(584, 106)
        Me.btnEliminar.Name = "btnEliminar"
        Me.btnEliminar.Size = New System.Drawing.Size(75, 28)
        Me.btnEliminar.TabIndex = 29
        Me.ToolTip1.SetToolTip(Me.btnEliminar, "Eliminar Articulos")
        Me.btnEliminar.UseVisualStyleBackColor = False
        '
        'btnAdd
        '
        Me.btnAdd.BackColor = System.Drawing.Color.MidnightBlue
        Me.btnAdd.BackgroundImage = Global.SIMPRODE.My.Resources.Resources.agregar
        Me.btnAdd.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnAdd.FlatAppearance.BorderSize = 0
        Me.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAdd.Location = New System.Drawing.Point(503, 106)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(75, 28)
        Me.btnAdd.TabIndex = 28
        Me.ToolTip1.SetToolTip(Me.btnAdd, "Agregar Articulo")
        Me.btnAdd.UseVisualStyleBackColor = False
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Controls.Add(Me.TabPage3)
        Me.TabControl1.Location = New System.Drawing.Point(12, 101)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(694, 407)
        Me.TabControl1.TabIndex = 7
        '
        'TabPage1
        '
        Me.TabPage1.BackColor = System.Drawing.Color.White
        Me.TabPage1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.TabPage1.Controls.Add(Me.Label10)
        Me.TabPage1.Controls.Add(Me.btnCargarExcel)
        Me.TabPage1.Controls.Add(Me.Label9)
        Me.TabPage1.Controls.Add(Me.Label8)
        Me.TabPage1.Controls.Add(Me.Button4)
        Me.TabPage1.Controls.Add(Me.Label7)
        Me.TabPage1.Controls.Add(Me.Button3)
        Me.TabPage1.Controls.Add(Me.Button1)
        Me.TabPage1.Controls.Add(Me.btnEliminar)
        Me.TabPage1.Controls.Add(Me.btnAdd)
        Me.TabPage1.Controls.Add(Me.txtDescArt)
        Me.TabPage1.Controls.Add(Me.txtCodigoArt)
        Me.TabPage1.Controls.Add(Me.Label2)
        Me.TabPage1.Controls.Add(Me.dgvArticulo)
        Me.TabPage1.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabPage1.ForeColor = System.Drawing.Color.MidnightBlue
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(686, 381)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Articulo"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Location = New System.Drawing.Point(222, 51)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(271, 18)
        Me.Label10.TabIndex = 37
        Me.Label10.Text = "F2: Consulta por departamento del articulo"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Location = New System.Drawing.Point(222, 67)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(243, 18)
        Me.Label9.TabIndex = 36
        Me.Label9.Text = "F3: Consulta por categoria del articulo."
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Location = New System.Drawing.Point(222, 35)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(253, 18)
        Me.Label8.TabIndex = 35
        Me.Label8.Text = "F1: Consulta por descripcion del articulo"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Location = New System.Drawing.Point(192, 19)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(182, 18)
        Me.Label7.TabIndex = 34
        Me.Label7.Text = "Descripcion de las opciones:"
        '
        'txtDescArt
        '
        Me.txtDescArt.Location = New System.Drawing.Point(208, 109)
        Me.txtDescArt.Name = "txtDescArt"
        Me.txtDescArt.ReadOnly = True
        Me.txtDescArt.Size = New System.Drawing.Size(289, 26)
        Me.txtDescArt.TabIndex = 27
        '
        'txtCodigoArt
        '
        Me.txtCodigoArt.Location = New System.Drawing.Point(81, 109)
        Me.txtCodigoArt.Name = "txtCodigoArt"
        Me.txtCodigoArt.Size = New System.Drawing.Size(121, 26)
        Me.txtCodigoArt.TabIndex = 26
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Location = New System.Drawing.Point(19, 113)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(60, 18)
        Me.Label2.TabIndex = 25
        Me.Label2.Text = "Articulo:"
        '
        'dgvArticulo
        '
        Me.dgvArticulo.AllowUserToAddRows = False
        Me.dgvArticulo.AllowUserToDeleteRows = False
        Me.dgvArticulo.AllowUserToResizeColumns = False
        Me.dgvArticulo.AllowUserToResizeRows = False
        Me.dgvArticulo.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgvArticulo.BackgroundColor = System.Drawing.Color.SteelBlue
        Me.dgvArticulo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvArticulo.Location = New System.Drawing.Point(22, 140)
        Me.dgvArticulo.Name = "dgvArticulo"
        Me.dgvArticulo.ReadOnly = True
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black
        Me.dgvArticulo.RowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvArticulo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvArticulo.Size = New System.Drawing.Size(645, 228)
        Me.dgvArticulo.TabIndex = 24
        '
        'TabPage2
        '
        Me.TabPage2.BackColor = System.Drawing.Color.White
        Me.TabPage2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.TabPage2.Controls.Add(Me.GroupBox4)
        Me.TabPage2.Controls.Add(Me.GroupBox3)
        Me.TabPage2.Controls.Add(Me.GroupBox2)
        Me.TabPage2.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabPage2.ForeColor = System.Drawing.Color.MidnightBlue
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(686, 381)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Descuento"
        '
        'GroupBox4
        '
        Me.GroupBox4.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox4.Controls.Add(Me.Label11)
        Me.GroupBox4.Controls.Add(Me.dthorafin)
        Me.GroupBox4.Controls.Add(Me.Label6)
        Me.GroupBox4.Controls.Add(Me.dthorain)
        Me.GroupBox4.Controls.Add(Me.Label5)
        Me.GroupBox4.Controls.Add(Me.Label4)
        Me.GroupBox4.Controls.Add(Me.dtFin)
        Me.GroupBox4.Controls.Add(Me.dtInicio)
        Me.GroupBox4.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox4.ForeColor = System.Drawing.Color.MidnightBlue
        Me.GroupBox4.Location = New System.Drawing.Point(31, 190)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(452, 181)
        Me.GroupBox4.TabIndex = 2
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Rango de Fechas"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(14, 134)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(82, 18)
        Me.Label11.TabIndex = 7
        Me.Label11.Text = "Hora de Fin:"
        '
        'dthorafin
        '
        Me.dthorafin.Enabled = False
        Me.dthorafin.Format = System.Windows.Forms.DateTimePickerFormat.Time
        Me.dthorafin.Location = New System.Drawing.Point(117, 129)
        Me.dthorafin.Name = "dthorafin"
        Me.dthorafin.Size = New System.Drawing.Size(124, 26)
        Me.dthorafin.TabIndex = 6
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(14, 102)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(97, 18)
        Me.Label6.TabIndex = 5
        Me.Label6.Text = "Hora de Inicio:"
        '
        'dthorain
        '
        Me.dthorain.Enabled = False
        Me.dthorain.Format = System.Windows.Forms.DateTimePickerFormat.Time
        Me.dthorain.Location = New System.Drawing.Point(117, 97)
        Me.dthorain.Name = "dthorain"
        Me.dthorain.Size = New System.Drawing.Size(124, 26)
        Me.dthorain.TabIndex = 4
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(14, 70)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(89, 18)
        Me.Label5.TabIndex = 3
        Me.Label5.Text = "Fecha de Fin:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(14, 38)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(104, 18)
        Me.Label4.TabIndex = 2
        Me.Label4.Text = "Fecha de Inicio:"
        '
        'dtFin
        '
        Me.dtFin.CustomFormat = "dd/MM/yyyy"
        Me.dtFin.Enabled = False
        Me.dtFin.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtFin.Location = New System.Drawing.Point(117, 65)
        Me.dtFin.Name = "dtFin"
        Me.dtFin.Size = New System.Drawing.Size(124, 26)
        Me.dtFin.TabIndex = 1
        '
        'dtInicio
        '
        Me.dtInicio.CustomFormat = "dd/MM/yyyy"
        Me.dtInicio.Enabled = False
        Me.dtInicio.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtInicio.Location = New System.Drawing.Point(117, 33)
        Me.dtInicio.Name = "dtInicio"
        Me.dtInicio.Size = New System.Drawing.Size(124, 26)
        Me.dtInicio.TabIndex = 0
        '
        'GroupBox3
        '
        Me.GroupBox3.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox3.Controls.Add(Me.ckSabado)
        Me.GroupBox3.Controls.Add(Me.ckViernes)
        Me.GroupBox3.Controls.Add(Me.ckJueves)
        Me.GroupBox3.Controls.Add(Me.ckMiercoles)
        Me.GroupBox3.Controls.Add(Me.ckMartes)
        Me.GroupBox3.Controls.Add(Me.ckLunes)
        Me.GroupBox3.Controls.Add(Me.ckDomingo)
        Me.GroupBox3.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox3.ForeColor = System.Drawing.Color.MidnightBlue
        Me.GroupBox3.Location = New System.Drawing.Point(504, 15)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(150, 356)
        Me.GroupBox3.TabIndex = 1
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Dias De La Semana"
        '
        'ckSabado
        '
        Me.ckSabado.AutoSize = True
        Me.ckSabado.Enabled = False
        Me.ckSabado.ForeColor = System.Drawing.Color.MidnightBlue
        Me.ckSabado.Location = New System.Drawing.Point(21, 284)
        Me.ckSabado.Name = "ckSabado"
        Me.ckSabado.Size = New System.Drawing.Size(72, 22)
        Me.ckSabado.TabIndex = 6
        Me.ckSabado.Text = "Sábado"
        Me.ckSabado.UseVisualStyleBackColor = True
        '
        'ckViernes
        '
        Me.ckViernes.AutoSize = True
        Me.ckViernes.Enabled = False
        Me.ckViernes.ForeColor = System.Drawing.Color.MidnightBlue
        Me.ckViernes.Location = New System.Drawing.Point(21, 245)
        Me.ckViernes.Name = "ckViernes"
        Me.ckViernes.Size = New System.Drawing.Size(75, 22)
        Me.ckViernes.TabIndex = 5
        Me.ckViernes.Text = "Viernes"
        Me.ckViernes.UseVisualStyleBackColor = True
        '
        'ckJueves
        '
        Me.ckJueves.AutoSize = True
        Me.ckJueves.Enabled = False
        Me.ckJueves.ForeColor = System.Drawing.Color.MidnightBlue
        Me.ckJueves.Location = New System.Drawing.Point(21, 204)
        Me.ckJueves.Name = "ckJueves"
        Me.ckJueves.Size = New System.Drawing.Size(69, 22)
        Me.ckJueves.TabIndex = 4
        Me.ckJueves.Text = "Jueves"
        Me.ckJueves.UseVisualStyleBackColor = True
        '
        'ckMiercoles
        '
        Me.ckMiercoles.AutoSize = True
        Me.ckMiercoles.Enabled = False
        Me.ckMiercoles.ForeColor = System.Drawing.Color.MidnightBlue
        Me.ckMiercoles.Location = New System.Drawing.Point(21, 164)
        Me.ckMiercoles.Name = "ckMiercoles"
        Me.ckMiercoles.Size = New System.Drawing.Size(88, 22)
        Me.ckMiercoles.TabIndex = 3
        Me.ckMiercoles.Text = "Miércoles"
        Me.ckMiercoles.UseVisualStyleBackColor = True
        '
        'ckMartes
        '
        Me.ckMartes.AutoSize = True
        Me.ckMartes.Enabled = False
        Me.ckMartes.ForeColor = System.Drawing.Color.MidnightBlue
        Me.ckMartes.Location = New System.Drawing.Point(21, 127)
        Me.ckMartes.Name = "ckMartes"
        Me.ckMartes.Size = New System.Drawing.Size(70, 22)
        Me.ckMartes.TabIndex = 2
        Me.ckMartes.Text = "Martes"
        Me.ckMartes.UseVisualStyleBackColor = True
        '
        'ckLunes
        '
        Me.ckLunes.AutoSize = True
        Me.ckLunes.Enabled = False
        Me.ckLunes.ForeColor = System.Drawing.Color.MidnightBlue
        Me.ckLunes.Location = New System.Drawing.Point(21, 87)
        Me.ckLunes.Name = "ckLunes"
        Me.ckLunes.Size = New System.Drawing.Size(63, 22)
        Me.ckLunes.TabIndex = 1
        Me.ckLunes.Text = "Lunes"
        Me.ckLunes.UseVisualStyleBackColor = True
        '
        'ckDomingo
        '
        Me.ckDomingo.AutoSize = True
        Me.ckDomingo.Enabled = False
        Me.ckDomingo.ForeColor = System.Drawing.Color.MidnightBlue
        Me.ckDomingo.Location = New System.Drawing.Point(21, 51)
        Me.ckDomingo.Name = "ckDomingo"
        Me.ckDomingo.Size = New System.Drawing.Size(83, 22)
        Me.ckDomingo.TabIndex = 0
        Me.ckDomingo.Text = "Domingo"
        Me.ckDomingo.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox2.Controls.Add(Me.dgvRangos)
        Me.GroupBox2.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.ForeColor = System.Drawing.Color.MidnightBlue
        Me.GroupBox2.Location = New System.Drawing.Point(30, 15)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(453, 168)
        Me.GroupBox2.TabIndex = 0
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Rango de Cantidad"
        '
        'dgvRangos
        '
        Me.dgvRangos.AllowUserToAddRows = False
        Me.dgvRangos.AllowUserToDeleteRows = False
        Me.dgvRangos.AllowUserToResizeColumns = False
        Me.dgvRangos.AllowUserToResizeRows = False
        Me.dgvRangos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvRangos.BackgroundColor = System.Drawing.Color.SteelBlue
        Me.dgvRangos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvRangos.Location = New System.Drawing.Point(15, 21)
        Me.dgvRangos.Name = "dgvRangos"
        Me.dgvRangos.ReadOnly = True
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black
        Me.dgvRangos.RowsDefaultCellStyle = DataGridViewCellStyle2
        Me.dgvRangos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvRangos.Size = New System.Drawing.Size(420, 137)
        Me.dgvRangos.TabIndex = 0
        '
        'TabPage3
        '
        Me.TabPage3.BackColor = System.Drawing.Color.White
        Me.TabPage3.Controls.Add(Me.dgvSucursales)
        Me.TabPage3.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabPage3.Location = New System.Drawing.Point(4, 22)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Size = New System.Drawing.Size(686, 381)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "Sucursales"
        '
        'dgvSucursales
        '
        Me.dgvSucursales.AllowUserToAddRows = False
        Me.dgvSucursales.AllowUserToDeleteRows = False
        Me.dgvSucursales.AllowUserToResizeColumns = False
        Me.dgvSucursales.AllowUserToResizeRows = False
        Me.dgvSucursales.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgvSucursales.BackgroundColor = System.Drawing.Color.SteelBlue
        Me.dgvSucursales.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvSucursales.Location = New System.Drawing.Point(9, 15)
        Me.dgvSucursales.Name = "dgvSucursales"
        Me.dgvSucursales.ReadOnly = True
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black
        Me.dgvSucursales.RowsDefaultCellStyle = DataGridViewCellStyle3
        Me.dgvSucursales.Size = New System.Drawing.Size(669, 356)
        Me.dgvSucursales.TabIndex = 1
        '
        'frmDescuentos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.MidnightBlue
        Me.BackgroundImage = Global.SIMPRODE.My.Resources.Resources._3
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(715, 519)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "frmDescuentos"
        Me.Opacity = 0.95R
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Descuentos"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        CType(Me.dgvArticulo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage2.ResumeLayout(False)
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        CType(Me.dgvRangos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage3.ResumeLayout(False)
        CType(Me.dgvSucursales, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents cbDescuentos As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents btnCargarExcel As System.Windows.Forms.Button
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents btnEliminar As System.Windows.Forms.Button
    Friend WithEvents btnAdd As System.Windows.Forms.Button
    Friend WithEvents txtDescArt As System.Windows.Forms.TextBox
    Friend WithEvents txtCodigoArt As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents dgvArticulo As System.Windows.Forms.DataGridView
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents dtFin As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtInicio As System.Windows.Forms.DateTimePicker
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents ckSabado As System.Windows.Forms.CheckBox
    Friend WithEvents ckViernes As System.Windows.Forms.CheckBox
    Friend WithEvents ckJueves As System.Windows.Forms.CheckBox
    Friend WithEvents ckMiercoles As System.Windows.Forms.CheckBox
    Friend WithEvents ckMartes As System.Windows.Forms.CheckBox
    Friend WithEvents ckLunes As System.Windows.Forms.CheckBox
    Friend WithEvents ckDomingo As System.Windows.Forms.CheckBox
    Friend WithEvents dgvRangos As System.Windows.Forms.DataGridView
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents dthorafin As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents dthorain As System.Windows.Forms.DateTimePicker
    Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
    Friend WithEvents dgvSucursales As System.Windows.Forms.DataGridView
End Class
