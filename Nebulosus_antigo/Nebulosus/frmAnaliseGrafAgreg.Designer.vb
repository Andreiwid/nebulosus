<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAnaliseGrafAgreg
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
        Dim ChartArea1 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmAnaliseGrafAgreg))
        Me.ChartEnvoltoria = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.dgSeg = New System.Windows.Forms.DataGridView()
        Me.columnSeg = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.columnX = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.columnY = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblCOG = New System.Windows.Forms.Label()
        CType(Me.ChartEnvoltoria, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgSeg, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ChartEnvoltoria
        '
        Me.ChartEnvoltoria.BorderlineColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ChartEnvoltoria.BorderlineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid
        Me.ChartEnvoltoria.BorderlineWidth = 2
        Me.ChartEnvoltoria.BorderSkin.PageColor = System.Drawing.SystemColors.Control
        Me.ChartEnvoltoria.BorderSkin.SkinStyle = System.Windows.Forms.DataVisualization.Charting.BorderSkinStyle.Emboss
        ChartArea1.AxisY.Interval = 0.5R
        ChartArea1.AxisY.Maximum = 1.0R
        ChartArea1.AxisY.Minimum = 0.0R
        ChartArea1.AxisY.MinorGrid.Enabled = True
        ChartArea1.AxisY.MinorGrid.LineColor = System.Drawing.Color.LightGray
        ChartArea1.AxisY.Title = "µ = Pertinência"
        ChartArea1.Name = "ChartArea1"
        Me.ChartEnvoltoria.ChartAreas.Add(ChartArea1)
        Me.ChartEnvoltoria.Location = New System.Drawing.Point(12, 12)
        Me.ChartEnvoltoria.Name = "ChartEnvoltoria"
        Me.ChartEnvoltoria.Size = New System.Drawing.Size(550, 364)
        Me.ChartEnvoltoria.TabIndex = 3
        Me.ChartEnvoltoria.Text = "Chart1"
        '
        'dgSeg
        '
        Me.dgSeg.AllowUserToAddRows = False
        Me.dgSeg.AllowUserToDeleteRows = False
        Me.dgSeg.AllowUserToOrderColumns = True
        Me.dgSeg.AllowUserToResizeColumns = False
        Me.dgSeg.AllowUserToResizeRows = False
        Me.dgSeg.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgSeg.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgSeg.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgSeg.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgSeg.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.columnSeg, Me.columnX, Me.columnY})
        Me.dgSeg.Location = New System.Drawing.Point(591, 12)
        Me.dgSeg.Name = "dgSeg"
        Me.dgSeg.ReadOnly = True
        Me.dgSeg.RowHeadersVisible = False
        Me.dgSeg.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgSeg.Size = New System.Drawing.Size(294, 364)
        Me.dgSeg.TabIndex = 4
        '
        'columnSeg
        '
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.columnSeg.DefaultCellStyle = DataGridViewCellStyle2
        Me.columnSeg.HeaderText = "Segmento"
        Me.columnSeg.Name = "columnSeg"
        Me.columnSeg.ReadOnly = True
        '
        'columnX
        '
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.columnX.DefaultCellStyle = DataGridViewCellStyle3
        Me.columnX.HeaderText = "X"
        Me.columnX.Name = "columnX"
        Me.columnX.ReadOnly = True
        '
        'columnY
        '
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.columnY.DefaultCellStyle = DataGridViewCellStyle4
        Me.columnY.HeaderText = "Y"
        Me.columnY.Name = "columnY"
        Me.columnY.ReadOnly = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 389)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(106, 13)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Centro de gravidade:"
        '
        'lblCOG
        '
        Me.lblCOG.AutoSize = True
        Me.lblCOG.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCOG.Location = New System.Drawing.Point(124, 389)
        Me.lblCOG.Name = "lblCOG"
        Me.lblCOG.Size = New System.Drawing.Size(0, 13)
        Me.lblCOG.TabIndex = 6
        '
        'frmAnaliseGrafAgreg
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(909, 421)
        Me.Controls.Add(Me.lblCOG)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.dgSeg)
        Me.Controls.Add(Me.ChartEnvoltoria)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmAnaliseGrafAgreg"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Gráfico de agregação - análise da envoltória"
        CType(Me.ChartEnvoltoria, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgSeg, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ChartEnvoltoria As System.Windows.Forms.DataVisualization.Charting.Chart
    Friend WithEvents dgSeg As System.Windows.Forms.DataGridView
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblCOG As System.Windows.Forms.Label
    Friend WithEvents columnSeg As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents columnX As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents columnY As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
