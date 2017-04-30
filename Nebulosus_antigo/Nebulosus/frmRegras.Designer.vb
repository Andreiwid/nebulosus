<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRegras
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmRegras))
        Me.dgRegras = New System.Windows.Forms.DataGridView()
        Me.columnRegra = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.tvwVariaveis = New System.Windows.Forms.TreeView()
        CType(Me.dgRegras, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'dgRegras
        '
        Me.dgRegras.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgRegras.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgRegras.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.columnRegra})
        Me.dgRegras.Location = New System.Drawing.Point(21, 100)
        Me.dgRegras.MultiSelect = False
        Me.dgRegras.Name = "dgRegras"
        Me.dgRegras.Size = New System.Drawing.Size(519, 236)
        Me.dgRegras.TabIndex = 2
        '
        'columnRegra
        '
        Me.columnRegra.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.columnRegra.HeaderText = "Regras"
        Me.columnRegra.Name = "columnRegra"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(9, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(53, 13)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Variáveis:"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.dgRegras)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Location = New System.Drawing.Point(179, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(560, 342)
        Me.GroupBox1.TabIndex = 4
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Definição das regras"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(90, 72)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(412, 13)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "SE [var_ant_1] É [valor] OU [var_ant_2] É [valor] ENTÃO [var_consequente] É [valo" & _
    "r]"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(90, 49)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(403, 13)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "SE [var_ant_1] É [valor] E [var_ant_2] É [valor] ENTÃO [var_consequente] É [valor" & _
    "]"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(90, 26)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(294, 13)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "SE [var_ant_1] É [valor] ENTÃO [var_consequente] É [valor]"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(17, 26)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(48, 13)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Formato:"
        '
        'tvwVariaveis
        '
        Me.tvwVariaveis.Location = New System.Drawing.Point(13, 29)
        Me.tvwVariaveis.Name = "tvwVariaveis"
        Me.tvwVariaveis.Size = New System.Drawing.Size(148, 324)
        Me.tvwVariaveis.TabIndex = 5
        '
        'frmRegras
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(751, 366)
        Me.Controls.Add(Me.tvwVariaveis)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "frmRegras"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Editor de regras"
        CType(Me.dgRegras, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dgRegras As System.Windows.Forms.DataGridView
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents tvwVariaveis As System.Windows.Forms.TreeView
    Friend WithEvents columnRegra As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
End Class
