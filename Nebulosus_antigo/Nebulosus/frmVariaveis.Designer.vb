<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmVariaveis
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmVariaveis))
        Dim ListViewItem1 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem(New System.Windows.Forms.ListViewItem.ListViewSubItem() {New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, "", System.Drawing.SystemColors.WindowText, System.Drawing.SystemColors.Window, New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))), New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, "", System.Drawing.SystemColors.WindowText, System.Drawing.SystemColors.Window, New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))), New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, "", System.Drawing.SystemColors.WindowText, System.Drawing.SystemColors.Window, New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))), New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, "")}, -1)
        Dim ChartArea1 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Me.cboVariaveis = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmdVarIncluir = New System.Windows.Forms.Button()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.cmdVarEditar = New System.Windows.Forms.Button()
        Me.lvwConjuntos = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.cmdVarCancelar = New System.Windows.Forms.Button()
        Me.txtFin = New System.Windows.Forms.TextBox()
        Me.txtIni = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cmdVarExcluir = New System.Windows.Forms.Button()
        Me.cmdVarSalvar = New System.Windows.Forms.Button()
        Me.ChartConjuntos = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtConjValor = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cboConjFuncao = New System.Windows.Forms.ComboBox()
        Me.cmdConjEditar = New System.Windows.Forms.Button()
        Me.cmdConjSalvar = New System.Windows.Forms.Button()
        Me.cmdConjExcluir = New System.Windows.Forms.Button()
        Me.cmdConjIncluir = New System.Windows.Forms.Button()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.cboConjModalAPert = New System.Windows.Forms.ComboBox()
        Me.txtConjModalAVlr = New System.Windows.Forms.TextBox()
        Me.txtConjModalBVlr = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.cboConjModalBPert = New System.Windows.Forms.ComboBox()
        Me.txtConjModalCVlr = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.cboConjModalCPert = New System.Windows.Forms.ComboBox()
        Me.txtConjModalDVlr = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.cboConjModalDPert = New System.Windows.Forms.ComboBox()
        Me.pnlConjCor = New System.Windows.Forms.Panel()
        Me.ColorDialog1 = New System.Windows.Forms.ColorDialog()
        Me.cmdConjCancelar = New System.Windows.Forms.Button()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.cmdCalcPert = New System.Windows.Forms.Button()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtCalcPert = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        CType(Me.ChartConjuntos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cboVariaveis
        '
        Me.cboVariaveis.DisplayMember = "nome"
        Me.cboVariaveis.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboVariaveis.FormattingEnabled = True
        Me.cboVariaveis.Location = New System.Drawing.Point(22, 38)
        Me.cboVariaveis.Name = "cboVariaveis"
        Me.cboVariaveis.Size = New System.Drawing.Size(184, 21)
        Me.cboVariaveis.TabIndex = 1
        Me.cboVariaveis.ValueMember = "codvar"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(19, 22)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(99, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Variável linguística:"
        '
        'cmdVarIncluir
        '
        Me.cmdVarIncluir.FlatAppearance.BorderColor = System.Drawing.Color.Silver
        Me.cmdVarIncluir.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdVarIncluir.ImageIndex = 0
        Me.cmdVarIncluir.ImageList = Me.ImageList1
        Me.cmdVarIncluir.Location = New System.Drawing.Point(367, 36)
        Me.cmdVarIncluir.Name = "cmdVarIncluir"
        Me.cmdVarIncluir.Size = New System.Drawing.Size(36, 23)
        Me.cmdVarIncluir.TabIndex = 5
        Me.ToolTip1.SetToolTip(Me.cmdVarIncluir, "Incluir")
        Me.cmdVarIncluir.UseVisualStyleBackColor = True
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "add.png")
        Me.ImageList1.Images.SetKeyName(1, "delete.png")
        Me.ImageList1.Images.SetKeyName(2, "page_white_edit.png")
        Me.ImageList1.Images.SetKeyName(3, "disk.png")
        Me.ImageList1.Images.SetKeyName(4, "cancel.png")
        Me.ImageList1.Images.SetKeyName(5, "sum.png")
        '
        'cmdVarEditar
        '
        Me.cmdVarEditar.FlatAppearance.BorderColor = System.Drawing.Color.Silver
        Me.cmdVarEditar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdVarEditar.ImageIndex = 2
        Me.cmdVarEditar.ImageList = Me.ImageList1
        Me.cmdVarEditar.Location = New System.Drawing.Point(447, 36)
        Me.cmdVarEditar.Name = "cmdVarEditar"
        Me.cmdVarEditar.Size = New System.Drawing.Size(36, 23)
        Me.cmdVarEditar.TabIndex = 6
        Me.ToolTip1.SetToolTip(Me.cmdVarEditar, "Editar")
        Me.cmdVarEditar.UseVisualStyleBackColor = True
        '
        'lvwConjuntos
        '
        Me.lvwConjuntos.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader3})
        Me.lvwConjuntos.FullRowSelect = True
        Me.lvwConjuntos.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me.lvwConjuntos.HideSelection = False
        ListViewItem1.UseItemStyleForSubItems = False
        Me.lvwConjuntos.Items.AddRange(New System.Windows.Forms.ListViewItem() {ListViewItem1})
        Me.lvwConjuntos.Location = New System.Drawing.Point(12, 390)
        Me.lvwConjuntos.MultiSelect = False
        Me.lvwConjuntos.Name = "lvwConjuntos"
        Me.lvwConjuntos.Size = New System.Drawing.Size(245, 141)
        Me.lvwConjuntos.TabIndex = 3
        Me.lvwConjuntos.UseCompatibleStateImageBehavior = False
        Me.lvwConjuntos.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = ""
        Me.ColumnHeader1.Width = 16
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "Valor"
        Me.ColumnHeader2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.ColumnHeader2.Width = 123
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "µ(x)"
        Me.ColumnHeader3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.ColumnHeader3.Width = 102
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cmdVarCancelar)
        Me.GroupBox1.Controls.Add(Me.txtFin)
        Me.GroupBox1.Controls.Add(Me.txtIni)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.cboVariaveis)
        Me.GroupBox1.Controls.Add(Me.cmdVarIncluir)
        Me.GroupBox1.Controls.Add(Me.cmdVarExcluir)
        Me.GroupBox1.Controls.Add(Me.cmdVarSalvar)
        Me.GroupBox1.Controls.Add(Me.cmdVarEditar)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(719, 71)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Variáveis"
        '
        'cmdVarCancelar
        '
        Me.cmdVarCancelar.Enabled = False
        Me.cmdVarCancelar.FlatAppearance.BorderColor = System.Drawing.Color.Silver
        Me.cmdVarCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdVarCancelar.ImageIndex = 4
        Me.cmdVarCancelar.ImageList = Me.ImageList1
        Me.cmdVarCancelar.Location = New System.Drawing.Point(527, 36)
        Me.cmdVarCancelar.Name = "cmdVarCancelar"
        Me.cmdVarCancelar.Size = New System.Drawing.Size(36, 23)
        Me.cmdVarCancelar.TabIndex = 9
        Me.ToolTip1.SetToolTip(Me.cmdVarCancelar, "Cancelar")
        Me.cmdVarCancelar.UseVisualStyleBackColor = True
        '
        'txtFin
        '
        Me.txtFin.Enabled = False
        Me.txtFin.Location = New System.Drawing.Point(293, 39)
        Me.txtFin.Name = "txtFin"
        Me.txtFin.Size = New System.Drawing.Size(61, 20)
        Me.txtFin.TabIndex = 4
        '
        'txtIni
        '
        Me.txtIni.Enabled = False
        Me.txtIni.Location = New System.Drawing.Point(226, 39)
        Me.txtIni.Name = "txtIni"
        Me.txtIni.Size = New System.Drawing.Size(61, 20)
        Me.txtIni.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(223, 22)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(51, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Intervalo:"
        '
        'cmdVarExcluir
        '
        Me.cmdVarExcluir.FlatAppearance.BorderColor = System.Drawing.Color.Silver
        Me.cmdVarExcluir.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdVarExcluir.ImageIndex = 1
        Me.cmdVarExcluir.ImageList = Me.ImageList1
        Me.cmdVarExcluir.Location = New System.Drawing.Point(407, 36)
        Me.cmdVarExcluir.Name = "cmdVarExcluir"
        Me.cmdVarExcluir.Size = New System.Drawing.Size(36, 23)
        Me.cmdVarExcluir.TabIndex = 8
        Me.ToolTip1.SetToolTip(Me.cmdVarExcluir, "Excluir")
        Me.cmdVarExcluir.UseVisualStyleBackColor = True
        '
        'cmdVarSalvar
        '
        Me.cmdVarSalvar.Enabled = False
        Me.cmdVarSalvar.FlatAppearance.BorderColor = System.Drawing.Color.Silver
        Me.cmdVarSalvar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdVarSalvar.ImageIndex = 3
        Me.cmdVarSalvar.ImageList = Me.ImageList1
        Me.cmdVarSalvar.Location = New System.Drawing.Point(487, 36)
        Me.cmdVarSalvar.Name = "cmdVarSalvar"
        Me.cmdVarSalvar.Size = New System.Drawing.Size(36, 23)
        Me.cmdVarSalvar.TabIndex = 7
        Me.ToolTip1.SetToolTip(Me.cmdVarSalvar, "Salvar")
        Me.cmdVarSalvar.UseVisualStyleBackColor = True
        '
        'ChartConjuntos
        '
        Me.ChartConjuntos.BorderlineColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ChartConjuntos.BorderlineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid
        Me.ChartConjuntos.BorderlineWidth = 2
        Me.ChartConjuntos.BorderSkin.PageColor = System.Drawing.SystemColors.Control
        Me.ChartConjuntos.BorderSkin.SkinStyle = System.Windows.Forms.DataVisualization.Charting.BorderSkinStyle.Emboss
        ChartArea1.AxisY.Interval = 0.5R
        ChartArea1.AxisY.Maximum = 1.0R
        ChartArea1.AxisY.Minimum = 0.0R
        ChartArea1.AxisY.MinorGrid.Enabled = True
        ChartArea1.AxisY.MinorGrid.LineColor = System.Drawing.Color.LightGray
        ChartArea1.AxisY.Title = "µ = Pertinência"
        ChartArea1.Name = "ChartArea1"
        Me.ChartConjuntos.ChartAreas.Add(ChartArea1)
        Me.ChartConjuntos.Location = New System.Drawing.Point(12, 116)
        Me.ChartConjuntos.Name = "ChartConjuntos"
        Me.ChartConjuntos.Size = New System.Drawing.Size(719, 263)
        Me.ChartConjuntos.TabIndex = 2
        Me.ChartConjuntos.Text = "Chart1"
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(260, 93)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(212, 20)
        Me.Label3.TabIndex = 1
        Me.Label3.Text = "Definição dos conjuntos nebulosos"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(319, 390)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(34, 13)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "Valor:"
        '
        'txtConjValor
        '
        Me.txtConjValor.Enabled = False
        Me.txtConjValor.Location = New System.Drawing.Point(322, 407)
        Me.txtConjValor.Name = "txtConjValor"
        Me.txtConjValor.Size = New System.Drawing.Size(121, 20)
        Me.txtConjValor.TabIndex = 9
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(319, 441)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(116, 13)
        Me.Label5.TabIndex = 10
        Me.Label5.Text = "Função de pertinência:"
        '
        'cboConjFuncao
        '
        Me.cboConjFuncao.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboConjFuncao.Enabled = False
        Me.cboConjFuncao.FormattingEnabled = True
        Me.cboConjFuncao.Items.AddRange(New Object() {"Triangular", "Trapezoidal"})
        Me.cboConjFuncao.Location = New System.Drawing.Point(322, 458)
        Me.cboConjFuncao.Name = "cboConjFuncao"
        Me.cboConjFuncao.Size = New System.Drawing.Size(121, 21)
        Me.cboConjFuncao.TabIndex = 11
        '
        'cmdConjEditar
        '
        Me.cmdConjEditar.FlatAppearance.BorderColor = System.Drawing.Color.Silver
        Me.cmdConjEditar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdConjEditar.ImageIndex = 2
        Me.cmdConjEditar.ImageList = Me.ImageList1
        Me.cmdConjEditar.Location = New System.Drawing.Point(263, 448)
        Me.cmdConjEditar.Name = "cmdConjEditar"
        Me.cmdConjEditar.Size = New System.Drawing.Size(36, 23)
        Me.cmdConjEditar.TabIndex = 5
        Me.cmdConjEditar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.cmdConjEditar, "Editar")
        Me.cmdConjEditar.UseVisualStyleBackColor = True
        '
        'cmdConjSalvar
        '
        Me.cmdConjSalvar.Enabled = False
        Me.cmdConjSalvar.FlatAppearance.BorderColor = System.Drawing.Color.Silver
        Me.cmdConjSalvar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdConjSalvar.ImageIndex = 3
        Me.cmdConjSalvar.ImageList = Me.ImageList1
        Me.cmdConjSalvar.Location = New System.Drawing.Point(263, 477)
        Me.cmdConjSalvar.Name = "cmdConjSalvar"
        Me.cmdConjSalvar.Size = New System.Drawing.Size(36, 23)
        Me.cmdConjSalvar.TabIndex = 6
        Me.cmdConjSalvar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.cmdConjSalvar, "Salvar")
        Me.cmdConjSalvar.UseVisualStyleBackColor = True
        '
        'cmdConjExcluir
        '
        Me.cmdConjExcluir.FlatAppearance.BorderColor = System.Drawing.Color.Silver
        Me.cmdConjExcluir.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdConjExcluir.ImageIndex = 1
        Me.cmdConjExcluir.ImageList = Me.ImageList1
        Me.cmdConjExcluir.Location = New System.Drawing.Point(263, 419)
        Me.cmdConjExcluir.Name = "cmdConjExcluir"
        Me.cmdConjExcluir.Size = New System.Drawing.Size(36, 23)
        Me.cmdConjExcluir.TabIndex = 7
        Me.cmdConjExcluir.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.cmdConjExcluir, "Excluir")
        Me.cmdConjExcluir.UseVisualStyleBackColor = True
        '
        'cmdConjIncluir
        '
        Me.cmdConjIncluir.FlatAppearance.BorderColor = System.Drawing.Color.Silver
        Me.cmdConjIncluir.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdConjIncluir.ImageIndex = 0
        Me.cmdConjIncluir.ImageList = Me.ImageList1
        Me.cmdConjIncluir.Location = New System.Drawing.Point(263, 390)
        Me.cmdConjIncluir.Name = "cmdConjIncluir"
        Me.cmdConjIncluir.Size = New System.Drawing.Size(36, 23)
        Me.cmdConjIncluir.TabIndex = 4
        Me.cmdConjIncluir.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.cmdConjIncluir, "Incluir")
        Me.cmdConjIncluir.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(319, 488)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(26, 13)
        Me.Label6.TabIndex = 12
        Me.Label6.Text = "Cor:"
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.Silver
        Me.Label7.Location = New System.Drawing.Point(464, 389)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(118, 14)
        Me.Label7.TabIndex = 14
        Me.Label7.Text = "Modais:"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(466, 437)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(13, 13)
        Me.Label8.TabIndex = 15
        Me.Label8.Text = "a"
        '
        'cboConjModalAPert
        '
        Me.cboConjModalAPert.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboConjModalAPert.Enabled = False
        Me.cboConjModalAPert.FormattingEnabled = True
        Me.cboConjModalAPert.Items.AddRange(New Object() {"0", "1"})
        Me.cboConjModalAPert.Location = New System.Drawing.Point(485, 434)
        Me.cboConjModalAPert.Name = "cboConjModalAPert"
        Me.cboConjModalAPert.Size = New System.Drawing.Size(40, 21)
        Me.cboConjModalAPert.TabIndex = 16
        '
        'txtConjModalAVlr
        '
        Me.txtConjModalAVlr.Enabled = False
        Me.txtConjModalAVlr.Location = New System.Drawing.Point(531, 434)
        Me.txtConjModalAVlr.Name = "txtConjModalAVlr"
        Me.txtConjModalAVlr.Size = New System.Drawing.Size(51, 20)
        Me.txtConjModalAVlr.TabIndex = 17
        '
        'txtConjModalBVlr
        '
        Me.txtConjModalBVlr.Enabled = False
        Me.txtConjModalBVlr.Location = New System.Drawing.Point(531, 467)
        Me.txtConjModalBVlr.Name = "txtConjModalBVlr"
        Me.txtConjModalBVlr.Size = New System.Drawing.Size(51, 20)
        Me.txtConjModalBVlr.TabIndex = 20
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(466, 470)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(13, 13)
        Me.Label9.TabIndex = 18
        Me.Label9.Text = "b"
        '
        'cboConjModalBPert
        '
        Me.cboConjModalBPert.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboConjModalBPert.Enabled = False
        Me.cboConjModalBPert.FormattingEnabled = True
        Me.cboConjModalBPert.Items.AddRange(New Object() {"0", "1"})
        Me.cboConjModalBPert.Location = New System.Drawing.Point(485, 466)
        Me.cboConjModalBPert.Name = "cboConjModalBPert"
        Me.cboConjModalBPert.Size = New System.Drawing.Size(40, 21)
        Me.cboConjModalBPert.TabIndex = 19
        '
        'txtConjModalCVlr
        '
        Me.txtConjModalCVlr.Enabled = False
        Me.txtConjModalCVlr.Location = New System.Drawing.Point(531, 500)
        Me.txtConjModalCVlr.Name = "txtConjModalCVlr"
        Me.txtConjModalCVlr.Size = New System.Drawing.Size(51, 20)
        Me.txtConjModalCVlr.TabIndex = 23
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(466, 503)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(13, 13)
        Me.Label10.TabIndex = 21
        Me.Label10.Text = "c"
        '
        'cboConjModalCPert
        '
        Me.cboConjModalCPert.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboConjModalCPert.Enabled = False
        Me.cboConjModalCPert.FormattingEnabled = True
        Me.cboConjModalCPert.Items.AddRange(New Object() {"0", "1"})
        Me.cboConjModalCPert.Location = New System.Drawing.Point(485, 498)
        Me.cboConjModalCPert.Name = "cboConjModalCPert"
        Me.cboConjModalCPert.Size = New System.Drawing.Size(40, 21)
        Me.cboConjModalCPert.TabIndex = 22
        '
        'txtConjModalDVlr
        '
        Me.txtConjModalDVlr.Enabled = False
        Me.txtConjModalDVlr.Location = New System.Drawing.Point(531, 533)
        Me.txtConjModalDVlr.Name = "txtConjModalDVlr"
        Me.txtConjModalDVlr.Size = New System.Drawing.Size(51, 20)
        Me.txtConjModalDVlr.TabIndex = 26
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(466, 536)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(13, 13)
        Me.Label11.TabIndex = 24
        Me.Label11.Text = "d"
        '
        'cboConjModalDPert
        '
        Me.cboConjModalDPert.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboConjModalDPert.Enabled = False
        Me.cboConjModalDPert.FormattingEnabled = True
        Me.cboConjModalDPert.Items.AddRange(New Object() {"0", "1"})
        Me.cboConjModalDPert.Location = New System.Drawing.Point(485, 530)
        Me.cboConjModalDPert.Name = "cboConjModalDPert"
        Me.cboConjModalDPert.Size = New System.Drawing.Size(40, 21)
        Me.cboConjModalDPert.TabIndex = 25
        '
        'pnlConjCor
        '
        Me.pnlConjCor.BackColor = System.Drawing.Color.Black
        Me.pnlConjCor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlConjCor.Enabled = False
        Me.pnlConjCor.Location = New System.Drawing.Point(322, 504)
        Me.pnlConjCor.Name = "pnlConjCor"
        Me.pnlConjCor.Size = New System.Drawing.Size(53, 22)
        Me.pnlConjCor.TabIndex = 13
        '
        'cmdConjCancelar
        '
        Me.cmdConjCancelar.Enabled = False
        Me.cmdConjCancelar.FlatAppearance.BorderColor = System.Drawing.Color.Silver
        Me.cmdConjCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdConjCancelar.ImageIndex = 4
        Me.cmdConjCancelar.ImageList = Me.ImageList1
        Me.cmdConjCancelar.Location = New System.Drawing.Point(263, 506)
        Me.cmdConjCancelar.Name = "cmdConjCancelar"
        Me.cmdConjCancelar.Size = New System.Drawing.Size(36, 23)
        Me.cmdConjCancelar.TabIndex = 27
        Me.cmdConjCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.cmdConjCancelar, "Cancelar")
        Me.cmdConjCancelar.UseVisualStyleBackColor = True
        '
        'cmdCalcPert
        '
        Me.cmdCalcPert.FlatAppearance.BorderColor = System.Drawing.Color.Silver
        Me.cmdCalcPert.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdCalcPert.ImageIndex = 5
        Me.cmdCalcPert.ImageList = Me.ImageList1
        Me.cmdCalcPert.Location = New System.Drawing.Point(224, 535)
        Me.cmdCalcPert.Name = "cmdCalcPert"
        Me.cmdCalcPert.Size = New System.Drawing.Size(36, 23)
        Me.cmdCalcPert.TabIndex = 30
        Me.cmdCalcPert.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.cmdCalcPert, "Cancelar")
        Me.cmdCalcPert.UseVisualStyleBackColor = True
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(34, 538)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(117, 13)
        Me.Label12.TabIndex = 28
        Me.Label12.Text = "Calcular pertinência x ="
        '
        'txtCalcPert
        '
        Me.txtCalcPert.Location = New System.Drawing.Point(157, 535)
        Me.txtCalcPert.Name = "txtCalcPert"
        Me.txtCalcPert.Size = New System.Drawing.Size(61, 20)
        Me.txtCalcPert.TabIndex = 29
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(466, 410)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(60, 13)
        Me.Label13.TabIndex = 8
        Me.Label13.Text = "Pertinência"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(544, 410)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(31, 13)
        Me.Label14.TabIndex = 8
        Me.Label14.Text = "Valor"
        '
        'frmVariaveis
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(743, 560)
        Me.Controls.Add(Me.cmdCalcPert)
        Me.Controls.Add(Me.txtCalcPert)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.cmdConjCancelar)
        Me.Controls.Add(Me.pnlConjCor)
        Me.Controls.Add(Me.cboConjModalDPert)
        Me.Controls.Add(Me.cboConjModalCPert)
        Me.Controls.Add(Me.cboConjModalBPert)
        Me.Controls.Add(Me.cboConjModalAPert)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.cboConjFuncao)
        Me.Controls.Add(Me.txtConjModalDVlr)
        Me.Controls.Add(Me.txtConjModalCVlr)
        Me.Controls.Add(Me.txtConjModalBVlr)
        Me.Controls.Add(Me.txtConjModalAVlr)
        Me.Controls.Add(Me.txtConjValor)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.cmdConjIncluir)
        Me.Controls.Add(Me.cmdConjExcluir)
        Me.Controls.Add(Me.ChartConjuntos)
        Me.Controls.Add(Me.cmdConjSalvar)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.cmdConjEditar)
        Me.Controls.Add(Me.lvwConjuntos)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "frmVariaveis"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Editor de variáveis nebulosas"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.ChartConjuntos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cboVariaveis As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmdVarIncluir As System.Windows.Forms.Button
    Friend WithEvents cmdVarEditar As System.Windows.Forms.Button
    Friend WithEvents lvwConjuntos As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtFin As System.Windows.Forms.TextBox
    Friend WithEvents txtIni As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cmdVarExcluir As System.Windows.Forms.Button
    Friend WithEvents cmdVarSalvar As System.Windows.Forms.Button
    Friend WithEvents ChartConjuntos As System.Windows.Forms.DataVisualization.Charting.Chart
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtConjValor As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cboConjFuncao As System.Windows.Forms.ComboBox
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents cmdConjEditar As System.Windows.Forms.Button
    Friend WithEvents cmdConjSalvar As System.Windows.Forms.Button
    Friend WithEvents cmdConjExcluir As System.Windows.Forms.Button
    Friend WithEvents cmdConjIncluir As System.Windows.Forms.Button
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents cboConjModalAPert As System.Windows.Forms.ComboBox
    Friend WithEvents txtConjModalAVlr As System.Windows.Forms.TextBox
    Friend WithEvents txtConjModalBVlr As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents cboConjModalBPert As System.Windows.Forms.ComboBox
    Friend WithEvents txtConjModalCVlr As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents cboConjModalCPert As System.Windows.Forms.ComboBox
    Friend WithEvents txtConjModalDVlr As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents cboConjModalDPert As System.Windows.Forms.ComboBox
    Friend WithEvents pnlConjCor As System.Windows.Forms.Panel
    Friend WithEvents ColorDialog1 As System.Windows.Forms.ColorDialog
    Friend WithEvents ColumnHeader3 As System.Windows.Forms.ColumnHeader
    Friend WithEvents cmdVarCancelar As System.Windows.Forms.Button
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents cmdConjCancelar As System.Windows.Forms.Button
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txtCalcPert As System.Windows.Forms.TextBox
    Friend WithEvents cmdCalcPert As System.Windows.Forms.Button
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label

End Class
