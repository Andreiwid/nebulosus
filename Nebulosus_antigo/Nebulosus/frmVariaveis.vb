Imports System.Data
Imports System.Data.OleDb

Public Class frmVariaveis

    Private Sub frmConjuntos_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        preencheCBOVariaveis()
    End Sub

    Private Sub cboVariaveis_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboVariaveis.SelectedIndexChanged
        'se estiver em modo de edição, não dá o refresh no combo
        If cboVariaveis.DropDownStyle = ComboBoxStyle.Simple Then
            Exit Sub
        End If

        Dim conn As New OleDbConnection(ConnectionString)

        Dim cmd As New OleDbCommand("SELECT nome, ini, fin FROM tblvariaveis WHERE codvar = @codvar", conn)
        cmd.Parameters.Add("@codvar", OleDbType.Integer).Value = cboVariaveis.SelectedValue

        Dim da As New OleDbDataAdapter(cmd)
        Dim dt As New DataTable
        da.Fill(dt)

        txtIni.Text = CStr(dt(0)("ini"))
        txtFin.Text = CStr(dt(0)("fin"))

        'configura intervalo no gráfico
        ChartConjuntos.ChartAreas(0).AxisX.Minimum = txtIni.Text
        ChartConjuntos.ChartAreas(0).AxisX.Maximum = txtFin.Text
        ChartConjuntos.ChartAreas(0).AxisX.Title = "x = " & CStr(dt(0)("nome"))

        'verifica se está selecionada alguma variável
        If IsNothing(cboVariaveis.SelectedValue) = False Then
            preencheLVWValores(cboVariaveis.SelectedValue, 0)
        End If
    End Sub

    Private Sub cmdVarEditar_Click(sender As System.Object, e As System.EventArgs) Handles cmdVarEditar.Click, cmdVarIncluir.Click
        cboVariaveis.DropDownStyle = ComboBoxStyle.Simple
        preencheLVWValores(0, False)

        'armazena o codvar a ser alterado
        If CType(sender, Button).Name = "cmdVarEditar" Then
            cmdVarEditar.Tag = cboVariaveis.SelectedValue
        Else
            cboVariaveis.Text = vbNullString
            txtIni.Text = vbNullString
            txtFin.Text = vbNullString
        End If

        txtIni.Enabled = True
        txtFin.Enabled = True

        cmdVarIncluir.Enabled = False
        cmdVarEditar.Enabled = False
        cmdVarSalvar.Enabled = True
        cmdVarExcluir.Enabled = False
        cmdVarCancelar.Enabled = True

        cboVariaveis.Focus()
    End Sub

    Private Sub cmdVarSalvar_Click(sender As System.Object, e As System.EventArgs) Handles cmdVarSalvar.Click
        Dim conn As New OleDbConnection(ConnectionString)
        Dim query As String

        'vê se é inclusão ou alteração
        If IsNothing(cmdVarEditar.Tag) = True Then
            query = "INSERT INTO tblvariaveis " & _
                    "(nome, ini, fin) " & _
                    "VALUES (@nome, @ini, @fin)"
        Else
            query = "UPDATE tblvariaveis " & _
                    "SET nome = @nome, ini = @ini, fin = @fin " & _
                    "WHERE codvar = @codvar"
        End If

        Dim cmd As New OleDbCommand(query, conn)
        cmd.CommandType = CommandType.Text
        cmd.Parameters.Add("@nome", OleDbType.WChar).Value = cboVariaveis.Text
        cmd.Parameters.Add("@ini", OleDbType.Integer).Value = txtIni.Text
        cmd.Parameters.Add("@fin", OleDbType.Integer).Value = txtFin.Text
        cmd.Parameters.Add("@codvar", OleDbType.Integer).Value = cmdVarEditar.Tag

        conn.Open()
        cmd.ExecuteNonQuery()

        Dim novocodvar As Integer
        If IsNothing(cmdVarEditar.Tag) = True Then
            cmd.CommandText = "SELECT @@IDENTITY"
            novocodvar = CInt(cmd.ExecuteScalar())
        End If

        conn.Close()

        cboVariaveis.DropDownStyle = ComboBoxStyle.DropDownList
        txtIni.Enabled = False
        txtFin.Enabled = False

        cmdVarIncluir.Enabled = True
        cmdVarEditar.Enabled = True
        cmdVarSalvar.Enabled = False
        cmdVarExcluir.Enabled = True
        cmdVarCancelar.Enabled = False

        preencheCBOVariaveis()

        If IsNothing(cmdVarEditar.Tag) = True Then
            cboVariaveis.SelectedValue = novocodvar
        Else
            cboVariaveis.SelectedValue = cmdVarEditar.Tag
        End If

        cmdVarEditar.Tag = Nothing
    End Sub

    Private Sub preencheCBOVariaveis()
        Dim da As New OleDbDataAdapter("SELECT codvar, nome FROM tblvariaveis", ConnectionString)
        Dim dt As New DataTable
        da.Fill(dt)

        cboVariaveis.DataSource = dt
    End Sub

    Private Sub pnlConjCor_Click(sender As Object, e As System.EventArgs) Handles pnlConjCor.Click
        If ColorDialog1.ShowDialog = DialogResult.OK Then
            pnlConjCor.BackColor = ColorDialog1.Color
            pnlConjCor.Focus()
        End If
    End Sub

    Private Sub cmdConjIncluir_Click(sender As System.Object, e As System.EventArgs) Handles cmdConjIncluir.Click, cmdConjEditar.Click
        'armazena o codvar a ser alterado
        If CType(sender, Button).Name = "cmdConjEditar" Then
            If lvwConjuntos.SelectedItems.Count = 0 Then
                MessageBox.Show("Selecione algum valor!", "Editar", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End If
            cmdConjEditar.Tag = lvwConjuntos.SelectedItems(0).Tag
        Else
            txtConjValor.Text = vbNullString
            cboConjFuncao.SelectedIndex = -1
            pnlConjCor.BackColor = Color.Black
            cboConjModalAPert.SelectedIndex = -1
            txtConjModalAVlr.Text = vbNullString
            cboConjModalBPert.SelectedIndex = -1
            txtConjModalBVlr.Text = vbNullString
            cboConjModalCPert.SelectedIndex = -1
            txtConjModalCVlr.Text = vbNullString
            cboConjModalDPert.SelectedIndex = -1
            txtConjModalDVlr.Text = vbNullString
        End If

        txtConjValor.Enabled = True
        cboConjFuncao.Enabled = True
        pnlConjCor.Enabled = True
        cboConjModalAPert.Enabled = True
        txtConjModalAVlr.Enabled = True
        cboConjModalBPert.Enabled = True
        txtConjModalBVlr.Enabled = True
        cboConjModalCPert.Enabled = True
        txtConjModalCVlr.Enabled = True
        cboConjModalDPert.Enabled = True
        txtConjModalDVlr.Enabled = True

        cmdConjIncluir.Enabled = False
        cmdConjEditar.Enabled = False
        cmdConjSalvar.Enabled = True
        cmdConjExcluir.Enabled = False
        cmdConjCancelar.Enabled = True

        txtConjValor.Focus()
    End Sub

    Private Sub cboConjTipo_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboConjFuncao.SelectedIndexChanged
        'verifica se os campos estão em modo de edição
        If cmdConjSalvar.Enabled = True Then
            Select Case CStr(cboConjFuncao.SelectedItem)
                Case "Triangular"
                    cboConjModalDPert.Enabled = False
                    txtConjModalDVlr.Enabled = False

                Case "Trapezoidal"
                    cboConjModalDPert.Enabled = True
                    txtConjModalDVlr.Enabled = True
            End Select
        End If
    End Sub

    Private Sub cmdConjSalvar_Click(sender As System.Object, e As System.EventArgs) Handles cmdConjSalvar.Click
        Dim conn As New OleDbConnection(ConnectionString)
        Dim query As String

        Dim cmd As New OleDbCommand

        'vê se é inclusão ou alteração
        If IsNothing(cmdConjEditar.Tag) = True Then
            query = "INSERT INTO tblconjuntos " & _
                    "(codvar, valor, funcao_pert, cor, pa, a, pb, b, pc, c, pd, d) " & _
                    "VALUES (@codvar, @valor, @funcao_pert, @cor, @pa, @a, @pb, @b, @pc, @c, @pd, @d)"

            cmd.Parameters.Add("@codvar", OleDbType.Integer).Value = cboVariaveis.SelectedValue
        Else
            query = "UPDATE tblconjuntos " & _
                    "SET valor = @valor, funcao_pert = @funcao_pert, cor = @cor, pa = @pa, a = @a, pb = @pb, b = @b, pc = @pc, c = @c, pd = @pd, d = @d " & _
                    "WHERE codconj = @codconj"
        End If

        cmd.Connection = conn
        cmd.CommandType = CommandType.Text
        cmd.CommandText = query

        cmd.Parameters.Add("@valor", OleDbType.WChar).Value = txtConjValor.Text
        cmd.Parameters.Add("@funcao_pert", OleDbType.WChar).Value = cboConjFuncao.SelectedItem
        cmd.Parameters.Add("@cor", OleDbType.WChar).Value = CStr(pnlConjCor.BackColor.ToArgb())
        cmd.Parameters.Add("@pa", OleDbType.Integer).Value = CInt(cboConjModalAPert.SelectedItem)
        cmd.Parameters.Add("@a", OleDbType.Double).Value = CDbl(txtConjModalAVlr.Text)
        cmd.Parameters.Add("@pb", OleDbType.Integer).Value = CInt(cboConjModalBPert.SelectedItem)
        cmd.Parameters.Add("@b", OleDbType.Double).Value = CDbl(txtConjModalBVlr.Text)
        cmd.Parameters.Add("@pc", OleDbType.Integer).Value = CInt(cboConjModalCPert.SelectedItem)
        cmd.Parameters.Add("@c", OleDbType.Double).Value = CDbl(txtConjModalCVlr.Text)
        Select Case cboConjFuncao.SelectedItem
            Case "Triangular"
                cmd.Parameters.Add("@pd", OleDbType.Integer).Value = DBNull.Value
                cmd.Parameters.Add("@d", OleDbType.Double).Value = DBNull.Value
            Case "Trapezoidal"
                cmd.Parameters.Add("@pd", OleDbType.Integer).Value = CInt(cboConjModalDPert.SelectedItem)
                cmd.Parameters.Add("@d", OleDbType.Double).Value = CDbl(txtConjModalDVlr.Text)
        End Select
        cmd.Parameters.Add("@codconj", OleDbType.Integer).Value = CInt(cmdConjEditar.Tag)

        conn.Open()
        cmd.ExecuteNonQuery()
        conn.Close()

        txtConjValor.Enabled = False
        cboConjFuncao.Enabled = False
        pnlConjCor.Enabled = False
        cboConjModalAPert.Enabled = False
        txtConjModalAVlr.Enabled = False
        cboConjModalBPert.Enabled = False
        txtConjModalBVlr.Enabled = False
        cboConjModalCPert.Enabled = False
        txtConjModalCVlr.Enabled = False
        cboConjModalDPert.Enabled = False
        txtConjModalDVlr.Enabled = False

        cmdConjIncluir.Enabled = True
        cmdConjEditar.Enabled = True
        cmdConjSalvar.Enabled = False
        cmdConjExcluir.Enabled = True

        cmdConjEditar.Tag = Nothing

        preencheLVWValores(cboVariaveis.SelectedValue, False)
    End Sub


    Private Sub preencheLVWValores(codvar As Integer, calcpert As Boolean)
        Dim conn As New OleDbConnection(ConnectionString)

        Dim cmd As New OleDbCommand("SELECT * FROM tblconjuntos WHERE codvar = @codvar ORDER BY codconj", conn)
        cmd.Parameters.Add("@codvar", OleDbType.Integer).Value = codvar

        Dim da As New OleDbDataAdapter(cmd)
        Dim dt As New DataTable
        da.Fill(dt)

        lvwConjuntos.Items.Clear()
        ChartConjuntos.Series.Clear()

        If dt.DefaultView.Count = 0 Then
            ChartConjuntos.Series.Add("vazio")
            ChartConjuntos.Series("vazio").Points.AddXY(0, 0)
        End If

        'se for > 0 limpa o gráfico para plotar os novos dados
        Dim item As New ListViewItem

        For i As Integer = 0 To (dt.DefaultView.Count - 1)
            item = New ListViewItem(String.Empty)
            item.Tag = CStr(dt(i)("codconj"))
            item.UseItemStyleForSubItems = False
            item.BackColor = Color.FromArgb(CStr(dt(i)("cor")))

            item.SubItems.Add(CStr(dt(i)("valor")))

            If calcpert = True Then
                Select Case CStr(dt(i)("funcao_pert"))
                    Case "Triangular"
                        item.SubItems.Add(functriangular(CDbl(dt(i)("a")), CDbl(dt(i)("b")), CDbl(dt(i)("c")), txtCalcPert.Text))
                    Case "Trapezoidal"
                        item.SubItems.Add(functrapezoidal(CDbl(dt(i)("a")), CDbl(dt(i)("b")), CDbl(dt(i)("c")), CDbl(dt(i)("d")), txtCalcPert.Text))
                End Select
            End If

            lvwConjuntos.Items.Add(item)

            'plota gráfico
            ChartConjuntos.Series.Add(CStr(dt(i)("valor")))
            ChartConjuntos.Series(CStr(dt(i)("valor"))).ChartType = DataVisualization.Charting.SeriesChartType.Line
            ChartConjuntos.Series(CStr(dt(i)("valor"))).Color = Color.FromArgb(CStr(dt(i)("cor")))
            ChartConjuntos.Series(CStr(dt(i)("valor"))).BorderWidth = 2

            'verifica qual é a função de pertinência
            Select Case CStr(dt(i)("funcao_pert"))
                Case "Triangular"
                    'plota os 3 pontos
                    ChartConjuntos.Series(CStr(dt(i)("valor"))).Points.AddXY(CDbl(dt(i)("a")), CDbl(dt(i)("pa")))
                    ChartConjuntos.Series(CStr(dt(i)("valor"))).Points.AddXY(CDbl(dt(i)("b")), CDbl(dt(i)("pb")))
                    ChartConjuntos.Series(CStr(dt(i)("valor"))).Points.AddXY(CDbl(dt(i)("c")), CDbl(dt(i)("pc")))

                Case "Trapezoidal"
                    'plota os 4 pontos
                    ChartConjuntos.Series(CStr(dt(i)("valor"))).Points.AddXY(CDbl(dt(i)("a")), CDbl(dt(i)("pa")))
                    ChartConjuntos.Series(CStr(dt(i)("valor"))).Points.AddXY(CDbl(dt(i)("b")), CDbl(dt(i)("pb")))
                    ChartConjuntos.Series(CStr(dt(i)("valor"))).Points.AddXY(CDbl(dt(i)("c")), CDbl(dt(i)("pc")))
                    ChartConjuntos.Series(CStr(dt(i)("valor"))).Points.AddXY(CDbl(dt(i)("d")), CDbl(dt(i)("pd")))
            End Select
        Next
    End Sub

    Private Sub lvwConjuntos_Click(sender As Object, e As System.EventArgs) Handles lvwConjuntos.Click
        Dim conn As New OleDbConnection(ConnectionString)

        Dim cmd As New OleDbCommand("SELECT * FROM tblconjuntos WHERE codconj = @codconj", conn)
        cmd.Parameters.Add("@codconj", OleDbType.Integer).Value = CInt(lvwConjuntos.SelectedItems(0).Tag)

        Dim da As New OleDbDataAdapter(cmd)
        Dim dt As New DataTable
        da.Fill(dt)

        txtConjValor.Text = CStr(dt(0)("valor"))
        cboConjFuncao.SelectedItem = CStr(dt(0)("funcao_pert"))
        pnlConjCor.BackColor = Color.FromArgb(CStr(dt(0)("cor")))
        cboConjModalAPert.SelectedItem = CStr(dt(0)("pa"))
        txtConjModalAVlr.Text = CStr(dt(0)("a"))
        cboConjModalBPert.SelectedItem = CStr(dt(0)("pb"))
        txtConjModalBVlr.Text = CStr(dt(0)("b"))
        cboConjModalCPert.SelectedItem = CStr(dt(0)("pc"))
        txtConjModalCVlr.Text = CStr(dt(0)("c"))
        If IsDBNull(dt(0)("pd")) = True Then
            cboConjModalDPert.SelectedIndex = -1
        Else
            cboConjModalDPert.SelectedItem = CStr(dt(0)("pd"))
        End If

        If IsDBNull(dt(0)("d")) = True Then
            txtConjModalDVlr.Text = String.Empty
        Else
            txtConjModalDVlr.Text = CStr(dt(0)("d"))
        End If
    End Sub

    Private Sub cmdVarCancelar_Click(sender As System.Object, e As System.EventArgs) Handles cmdVarCancelar.Click
        cboVariaveis.DropDownStyle = ComboBoxStyle.DropDownList
        txtIni.Enabled = False
        txtFin.Enabled = False

        cmdVarIncluir.Enabled = True
        cmdVarEditar.Enabled = True
        cmdVarSalvar.Enabled = False
        cmdVarExcluir.Enabled = True
        cmdVarCancelar.Enabled = False

        preencheCBOVariaveis()

        If IsNothing(cmdVarEditar.Tag) = False Then
            cboVariaveis.SelectedValue = cmdVarEditar.Tag
        End If
    End Sub

    Private Sub lvwConjuntos_DoubleClick(sender As Object, e As System.EventArgs) Handles lvwConjuntos.DoubleClick
        cmdConjEditar.PerformClick()
    End Sub

    Private Sub lvwConjuntos_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles lvwConjuntos.SelectedIndexChanged
        'verifica se os campos estão em modo de edição
        If cmdConjSalvar.Enabled = True Then
            If MessageBox.Show("Deseja salvar o conjunto em edição?", "Salvar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                cmdConjSalvar_Click(sender, e)
            Else
                cmdConjCancelar_Click(sender, e)
            End If
        End If
    End Sub

    Private Sub cmdConjCancelar_Click(sender As System.Object, e As System.EventArgs) Handles cmdConjCancelar.Click
        txtConjValor.Enabled = False
        cboConjFuncao.Enabled = False
        pnlConjCor.Enabled = False
        cboConjModalAPert.Enabled = False
        txtConjModalAVlr.Enabled = False
        cboConjModalBPert.Enabled = False
        txtConjModalBVlr.Enabled = False
        cboConjModalCPert.Enabled = False
        txtConjModalCVlr.Enabled = False
        cboConjModalDPert.Enabled = False
        txtConjModalDVlr.Enabled = False

        cmdConjIncluir.Enabled = True
        cmdConjEditar.Enabled = True
        cmdConjSalvar.Enabled = False
        cmdConjExcluir.Enabled = True
        cmdConjCancelar.Enabled = False

        lvwConjuntos.Focus()
    End Sub

    Private Sub cmdVarExcluir_Click(sender As System.Object, e As System.EventArgs) Handles cmdVarExcluir.Click
        If MessageBox.Show("Tem certeza que deseja excluir esta variável e seu conjunto com todos os valores?", "Excluir", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then
            Exit Sub
        End If

        Dim conn As New OleDbConnection(ConnectionString)
        Dim query As String

        query = "DELETE FROM tblvariaveis " & _
                "WHERE codvar = @codvar"

        Dim cmd As New OleDbCommand(query, conn)
        cmd.CommandType = CommandType.Text
        cmd.Parameters.Add("@codvar", OleDbType.Integer).Value = cboVariaveis.SelectedValue

        conn.Open()
        cmd.ExecuteNonQuery()
        conn.Close()

        preencheCBOVariaveis()
    End Sub

    Private Sub cmdConjExcluir_Click(sender As System.Object, e As System.EventArgs) Handles cmdConjExcluir.Click
        If MessageBox.Show("Tem certeza que deseja excluir este valor?", "Excluir", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then
            Exit Sub
        End If

        Dim conn As New OleDbConnection(ConnectionString)
        Dim query As String

        query = "DELETE FROM tblconjuntos " & _
                "WHERE codconj = @codconj"

        Dim cmd As New OleDbCommand(query, conn)
        cmd.CommandType = CommandType.Text
        cmd.Parameters.Add("@codconj", OleDbType.Integer).Value = CInt(lvwConjuntos.SelectedItems(0).Tag)

        conn.Open()
        cmd.ExecuteNonQuery()
        conn.Close()

        preencheLVWValores(cboVariaveis.SelectedValue, 0)
    End Sub

    Private Sub cmdCalcPert_Click(sender As System.Object, e As System.EventArgs) Handles cmdCalcPert.Click
        preencheLVWValores(cboVariaveis.SelectedValue, 1)
    End Sub
End Class