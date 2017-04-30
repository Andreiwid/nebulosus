Imports System.Data
Imports System.Data.OleDb

Public Class frmDefuzzy

    Dim antvar(,) As String
    Dim antvlr(,) As String
    Dim oper() As String 'armazena qual o operado: E ou OU
    Dim consvar() As String
    Dim consvlr() As String

    Dim lblInput() As Label
    Dim txtInput() As TextBox
    Dim lblInputInter() As Label

    Dim lblAntVar1() As Label
    Dim lblAntVar2() As Label
    Dim lblConsVar() As Label

    Dim ChartAnt1() As System.Windows.Forms.DataVisualization.Charting.Chart
    Dim ChartAnt2() As System.Windows.Forms.DataVisualization.Charting.Chart
    Dim ChartCons() As System.Windows.Forms.DataVisualization.Charting.Chart
    Dim ChartAgreg() As System.Windows.Forms.DataVisualization.Charting.Chart

    Dim VarsInput As New SortedList
    Dim VarsOutput As New SortedList

    Dim intNumRegras As Integer

    Dim dtVarsEConjs As New DataTable

    Private Sub frmDefuzzy_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Dim daRegras As New OleDbDataAdapter("SELECT * FROM tblregras", ConnectionString)
        Dim daVarsEConjs As New OleDbDataAdapter( _
                                                "SELECT     tblvariaveis.nome, ini, fin, tblconjuntos.valor, funcao_pert, cor, pa, a, pb, b, pc, c, pd, d, CDbl(0) AS alfacut " & _
                                                "FROM         (tblconjuntos INNER JOIN tblvariaveis ON tblconjuntos.codvar = tblvariaveis.codvar)" _
                                                , ConnectionString)

        Dim dtRegras As New DataTable

        Try
            daRegras.Fill(dtRegras)
            daVarsEConjs.Fill(dtVarsEConjs)
        Catch ex As Exception
            MsgBox(ex.Message)
            Exit Sub
        End Try

        'define as chaves primárias
        dtVarsEConjs.PrimaryKey = {dtVarsEConjs.Columns("nome"), dtVarsEConjs.Columns("valor")}

        'armazena o no. de regras para ser recuperado mais facilmente
        intNumRegras = dtRegras.Rows.Count

        'redimensiona as variáveis para acomodar o número de regras
        ReDim antvar(intNumRegras, 1) 'considera até 2 antecedentes
        ReDim antvlr(intNumRegras, 1) 'considera até 2 antecedentes
        ReDim oper(intNumRegras)
        ReDim consvar(intNumRegras)
        ReDim consvlr(intNumRegras)

        ReDim ChartAnt1(intNumRegras)
        ReDim ChartAnt2(intNumRegras)
        ReDim ChartCons(intNumRegras)

        Dim lblRegra(intNumRegras) As Label
        Dim lblOper1(intNumRegras) As Label
        Dim lblOper2(intNumRegras) As Label
        ReDim lblAntVar1(intNumRegras)
        ReDim lblAntVar2(intNumRegras)
        ReDim lblConsVar(intNumRegras)

        For i As Integer = 0 To intNumRegras - 1
            Dim strLinha As String = dtRegras.Rows(i)(0)

            'verifia o no. de antecedentes. se tiver E ou OU é porque tem 2
            If strLinha.Contains(" E ") = True Or strLinha.Contains(" OU ") = True Then
                'armazena qual o operador
                oper(i) = IIf(strLinha.Contains(" E ") = True, "E", "OU")

                'retorna as posições dos extremos SE ... ENTÃO
                Dim intPos_SE As Integer = strLinha.IndexOf("SE ")
                Dim intPos_ENTAO As Integer = strLinha.IndexOf(" ENTÃO ")

                'retorna a substring entre SE ... ENTÃO
                Dim strEntre_SEeENTAO As String = strLinha.Substring(intPos_SE + 2, intPos_ENTAO - 1)

                'separa o 1o. e 2o. antecedentes
                Dim str1ant As String = strEntre_SEeENTAO.Split(New [String]() {" E ", " OU "}, StringSplitOptions.None)(0)
                Dim str2ant As String = strEntre_SEeENTAO.Split(New [String]() {" E ", " OU "}, StringSplitOptions.None)(1)

                'armazena a variável e valor do 1o. antecedente
                antvar(i, 0) = str1ant.Split(New [Char]() {"É"c})(0).Trim()
                antvlr(i, 0) = str1ant.Split(New [Char]() {"É"c})(1).Trim()

                'armazena a variável e valor do 2o. antecedente
                antvar(i, 1) = str2ant.Split(New [Char]() {"É"c})(0).Trim()
                antvlr(i, 1) = str2ant.Split(New [Char]() {"É"c})(1).Trim()

                'retorna a substring depois ENTÃO (até o final)
                Dim strDepois_ENTAO As String = strLinha.Substring(intPos_ENTAO + 7)
                consvar(i) = strDepois_ENTAO.Split(New [Char]() {"É"c})(0).Trim()
                consvlr(i) = strDepois_ENTAO.Split(New [Char]() {"É"c})(1).Trim()
            Else
                'retorna as posições dos extremos SE ... ENTÃO
                Dim intPos_SE As Integer = strLinha.IndexOf("SE ")
                Dim intPos_ENTAO As Integer = strLinha.IndexOf(" ENTÃO ")

                'retorna a substring entre SE ... ENTÃO
                Dim strEntre_SEeENTAO As String = strLinha.Substring(intPos_SE + 2, intPos_ENTAO - 1)

                'armazena a variável e valor do 1o. antecedente
                antvar(i, 0) = strEntre_SEeENTAO.Split(New [Char]() {"É"c})(0).Trim()
                antvlr(i, 0) = strEntre_SEeENTAO.Split(New [Char]() {"É"c})(1).Trim()

                'retorna a substring depois ENTÃO (até o final)
                Dim strDepois_ENTAO As String = strLinha.Substring(intPos_ENTAO + 7)
                consvar(i) = strDepois_ENTAO.Split(New [Char]() {"É"c})(0).Trim()
                consvlr(i) = strDepois_ENTAO.Split(New [Char]() {"É"c})(1).Trim()
            End If

            'cria um dataview para aplicar filtro
            Dim dvVarsEConjs As New DataView(dtVarsEConjs)

            lblRegra(i) = New Label
            lblRegra(i).Text = strLinha
            lblRegra(i).Size = New System.Drawing.Size(780, 17)
            lblRegra(i).Location = New System.Drawing.Point(15, 8 + (i * 185))
            lblRegra(i).TextAlign = ContentAlignment.MiddleCenter
            lblRegra(i).BackColor = Color.Silver
            Panel1.Controls.Add(lblRegra(i))

            If oper(i) <> String.Empty Then
                lblOper1(i) = New Label
                lblOper1(i).Text = oper(i) & vbNewLine & IIf(oper(i) = "E", "(min)", "(max)")
                lblOper1(i).Location = New System.Drawing.Point(245, 71 + (i * 185))
                lblOper1(i).AutoSize = True
                lblOper1(i).TextAlign = ContentAlignment.MiddleCenter
                Panel1.Controls.Add(lblOper1(i))
            End If

            lblOper2(i) = New Label
            lblOper2(i).Text = "ENTÃO"
            lblOper2(i).Location = New System.Drawing.Point(519, 87 + (i * 185))
            lblOper2(i).AutoSize = True
            Panel1.Controls.Add(lblOper2(i))

            'preenche gráfico antecedente 1
            'configura gráfico
            dvVarsEConjs.RowFilter = "nome = '" & antvar(i, 0) & "' AND valor = '" & antvlr(i, 0) & "'"

            ChartAnt1(i) = New System.Windows.Forms.DataVisualization.Charting.Chart
            ChartAnt1(i).BorderlineColor = Color.FromArgb(-8355585)
            ChartAnt1(i).BorderlineDashStyle = DataVisualization.Charting.ChartDashStyle.Solid
            ChartAnt1(i).BorderlineWidth = 2
            ChartAnt1(i).BorderSkin.SkinStyle = System.Windows.Forms.DataVisualization.Charting.BorderSkinStyle.Emboss
            ChartAnt1(i).BorderSkin.PageColor = SystemColors.Control
            ChartAnt1(i).Size = New System.Drawing.Size(223, 144)
            ChartAnt1(i).Location = New System.Drawing.Point(18, 26 + (i * 185))
            ChartAnt1(i).ChartAreas.Add("")
            ChartAnt1(i).ChartAreas(0).AxisY.LabelAutoFitMaxFontSize = 6
            ChartAnt1(i).ChartAreas(0).AxisY.Minimum = 0
            ChartAnt1(i).ChartAreas(0).AxisY.Maximum = 1
            ChartAnt1(i).ChartAreas(0).AxisY.Interval = 0.5
            ChartAnt1(i).ChartAreas(0).AxisX.LabelAutoFitMaxFontSize = 6
            ChartAnt1(i).ChartAreas(0).AxisX.Minimum = dvVarsEConjs(0)("ini")
            ChartAnt1(i).ChartAreas(0).AxisX.Maximum = dvVarsEConjs(0)("fin")
            Panel1.Controls.Add(ChartAnt1(i))
            'plota dados
            ChartAnt1(i).Series.Add(CStr(dvVarsEConjs(0)("valor")))
            ChartAnt1(i).Series(CStr(dvVarsEConjs(0)("valor"))).ChartType = DataVisualization.Charting.SeriesChartType.Line
            ChartAnt1(i).Series(CStr(dvVarsEConjs(0)("valor"))).Color = Color.FromArgb(CStr(dvVarsEConjs(0)("cor")))
            ChartAnt1(i).Series(CStr(dvVarsEConjs(0)("valor"))).BorderWidth = 2
            'verifica qual é a função de pertinência
            Select Case CStr(dvVarsEConjs(0)("funcao_pert"))
                Case "Triangular"
                    'plota os 3 pontos
                    ChartAnt1(i).Series(CStr(dvVarsEConjs(0)("valor"))).Points.AddXY(CDbl(dvVarsEConjs(0)("a")), CDbl(dvVarsEConjs(0)("pa")))
                    ChartAnt1(i).Series(CStr(dvVarsEConjs(0)("valor"))).Points.AddXY(CDbl(dvVarsEConjs(0)("b")), CDbl(dvVarsEConjs(0)("pb")))
                    ChartAnt1(i).Series(CStr(dvVarsEConjs(0)("valor"))).Points.AddXY(CDbl(dvVarsEConjs(0)("c")), CDbl(dvVarsEConjs(0)("pc")))
                Case "Trapezoidal"
                    'plota os 4 pontos
                    ChartAnt1(i).Series(CStr(dvVarsEConjs(0)("valor"))).Points.AddXY(CDbl(dvVarsEConjs(0)("a")), CDbl(dvVarsEConjs(0)("pa")))
                    ChartAnt1(i).Series(CStr(dvVarsEConjs(0)("valor"))).Points.AddXY(CDbl(dvVarsEConjs(0)("b")), CDbl(dvVarsEConjs(0)("pb")))
                    ChartAnt1(i).Series(CStr(dvVarsEConjs(0)("valor"))).Points.AddXY(CDbl(dvVarsEConjs(0)("c")), CDbl(dvVarsEConjs(0)("pc")))
                    ChartAnt1(i).Series(CStr(dvVarsEConjs(0)("valor"))).Points.AddXY(CDbl(dvVarsEConjs(0)("d")), CDbl(dvVarsEConjs(0)("pd")))
            End Select

            lblAntVar1(i) = New Label
            lblAntVar1(i).Text = dvVarsEConjs(0)("nome") & " = " & dvVarsEConjs(0)("valor")
            lblAntVar1(i).Location = New System.Drawing.Point(18, 170 + (i * 185))
            lblAntVar1(i).Size = New System.Drawing.Size(223, 13)
            lblAntVar1(i).TextAlign = ContentAlignment.MiddleCenter
            lblAntVar1(i).Font = New Font(Me.Font, FontStyle.Bold)
            Panel1.Controls.Add(lblAntVar1(i))

            'preenche gráfico antecedente 2, se ouver
            If oper(i) <> String.Empty Then
                dvVarsEConjs.RowFilter = "nome = '" & antvar(i, 1) & "' AND valor = '" & antvlr(i, 1) & "'"

                'preenche gráfico antecedente 1
                'configura gráfico
                ChartAnt2(i) = New System.Windows.Forms.DataVisualization.Charting.Chart
                ChartAnt2(i).BorderlineColor = Color.FromArgb(-8355585)
                ChartAnt2(i).BorderlineDashStyle = DataVisualization.Charting.ChartDashStyle.Solid
                ChartAnt2(i).BorderlineWidth = 2
                ChartAnt2(i).BorderSkin.SkinStyle = System.Windows.Forms.DataVisualization.Charting.BorderSkinStyle.Emboss
                ChartAnt2(i).BorderSkin.PageColor = SystemColors.Control
                ChartAnt2(i).Size = New System.Drawing.Size(223, 144)
                ChartAnt2(i).Location = New System.Drawing.Point(290, 26 + (i * 185))
                ChartAnt2(i).ChartAreas.Add("")
                ChartAnt2(i).ChartAreas(0).AxisY.LabelAutoFitMaxFontSize = 6
                ChartAnt2(i).ChartAreas(0).AxisY.Minimum = 0
                ChartAnt2(i).ChartAreas(0).AxisY.Maximum = 1
                ChartAnt2(i).ChartAreas(0).AxisY.Interval = 0.5
                ChartAnt2(i).ChartAreas(0).AxisX.LabelAutoFitMaxFontSize = 6
                ChartAnt2(i).ChartAreas(0).AxisX.Minimum = dvVarsEConjs(0)("ini")
                ChartAnt2(i).ChartAreas(0).AxisX.Maximum = dvVarsEConjs(0)("fin")
                Panel1.Controls.Add(ChartAnt2(i))
                'plota dados
                ChartAnt2(i).Series.Add(CStr(dvVarsEConjs(0)("valor")))
                ChartAnt2(i).Series(CStr(dvVarsEConjs(0)("valor"))).ChartType = DataVisualization.Charting.SeriesChartType.Line
                ChartAnt2(i).Series(CStr(dvVarsEConjs(0)("valor"))).Color = Color.FromArgb(CStr(dvVarsEConjs(0)("cor")))
                ChartAnt2(i).Series(CStr(dvVarsEConjs(0)("valor"))).BorderWidth = 2
                'verifica qual é a função de pertinência
                Select Case CStr(dvVarsEConjs(0)("funcao_pert"))
                    Case "Triangular"
                        'plota os 3 pontos
                        ChartAnt2(i).Series(CStr(dvVarsEConjs(0)("valor"))).Points.AddXY(CDbl(dvVarsEConjs(0)("a")), CDbl(dvVarsEConjs(0)("pa")))
                        ChartAnt2(i).Series(CStr(dvVarsEConjs(0)("valor"))).Points.AddXY(CDbl(dvVarsEConjs(0)("b")), CDbl(dvVarsEConjs(0)("pb")))
                        ChartAnt2(i).Series(CStr(dvVarsEConjs(0)("valor"))).Points.AddXY(CDbl(dvVarsEConjs(0)("c")), CDbl(dvVarsEConjs(0)("pc")))
                    Case "Trapezoidal"
                        'plota os 4 pontos
                        ChartAnt2(i).Series(CStr(dvVarsEConjs(0)("valor"))).Points.AddXY(CDbl(dvVarsEConjs(0)("a")), CDbl(dvVarsEConjs(0)("pa")))
                        ChartAnt2(i).Series(CStr(dvVarsEConjs(0)("valor"))).Points.AddXY(CDbl(dvVarsEConjs(0)("b")), CDbl(dvVarsEConjs(0)("pb")))
                        ChartAnt2(i).Series(CStr(dvVarsEConjs(0)("valor"))).Points.AddXY(CDbl(dvVarsEConjs(0)("c")), CDbl(dvVarsEConjs(0)("pc")))
                        ChartAnt2(i).Series(CStr(dvVarsEConjs(0)("valor"))).Points.AddXY(CDbl(dvVarsEConjs(0)("d")), CDbl(dvVarsEConjs(0)("pd")))
                End Select

                lblAntVar2(i) = New Label
                lblAntVar2(i).Text = dvVarsEConjs(0)("nome") & " = " & dvVarsEConjs(0)("valor")
                lblAntVar2(i).Location = New System.Drawing.Point(290, 170 + (i * 185))
                lblAntVar2(i).Size = New System.Drawing.Size(223, 13)
                lblAntVar2(i).TextAlign = ContentAlignment.MiddleCenter
                lblAntVar2(i).Font = New Font(Me.Font, FontStyle.Bold)
                Panel1.Controls.Add(lblAntVar2(i))

            End If

            'preenche gráfico consequente
            dvVarsEConjs.RowFilter = "nome = '" & consvar(i) & "' AND valor = '" & consvlr(i) & "'"

            'configura gráfico
            ChartCons(i) = New System.Windows.Forms.DataVisualization.Charting.Chart
            ChartCons(i).BorderlineColor = Color.FromArgb(-8355585)
            ChartCons(i).BorderlineDashStyle = DataVisualization.Charting.ChartDashStyle.Solid
            ChartCons(i).BorderlineWidth = 2
            ChartCons(i).BorderSkin.SkinStyle = System.Windows.Forms.DataVisualization.Charting.BorderSkinStyle.Emboss
            ChartCons(i).BorderSkin.PageColor = SystemColors.Control
            ChartCons(i).Size = New System.Drawing.Size(223, 144)
            ChartCons(i).Location = New System.Drawing.Point(574, 26 + (i * 185))
            ChartCons(i).ChartAreas.Add("")
            ChartCons(i).ChartAreas(0).AxisY.LabelAutoFitMaxFontSize = 6
            ChartCons(i).ChartAreas(0).AxisY.Minimum = 0
            ChartCons(i).ChartAreas(0).AxisY.Maximum = 1
            ChartCons(i).ChartAreas(0).AxisY.Interval = 0.5
            ChartCons(i).ChartAreas(0).AxisX.LabelAutoFitMaxFontSize = 6
            ChartCons(i).ChartAreas(0).AxisX.Minimum = dvVarsEConjs(0)("ini")
            ChartCons(i).ChartAreas(0).AxisX.Maximum = dvVarsEConjs(0)("fin")
            Panel1.Controls.Add(ChartCons(i))
            'plota dados
            ChartCons(i).Series.Add(CStr(dvVarsEConjs(0)("valor")))
            ChartCons(i).Series(CStr(dvVarsEConjs(0)("valor"))).ChartType = DataVisualization.Charting.SeriesChartType.Line
            ChartCons(i).Series(CStr(dvVarsEConjs(0)("valor"))).Color = Color.FromArgb(CStr(dvVarsEConjs(0)("cor")))
            ChartCons(i).Series(CStr(dvVarsEConjs(0)("valor"))).BorderWidth = 2
            'verifica qual é a função de pertinência
            Select Case CStr(dvVarsEConjs(0)("funcao_pert"))
                Case "Triangular"
                    'plota os 3 pontos
                    ChartCons(i).Series(CStr(dvVarsEConjs(0)("valor"))).Points.AddXY(CDbl(dvVarsEConjs(0)("a")), CDbl(dvVarsEConjs(0)("pa")))
                    ChartCons(i).Series(CStr(dvVarsEConjs(0)("valor"))).Points.AddXY(CDbl(dvVarsEConjs(0)("b")), CDbl(dvVarsEConjs(0)("pb")))
                    ChartCons(i).Series(CStr(dvVarsEConjs(0)("valor"))).Points.AddXY(CDbl(dvVarsEConjs(0)("c")), CDbl(dvVarsEConjs(0)("pc")))
                Case "Trapezoidal"
                    'plota os 4 pontos
                    ChartCons(i).Series(CStr(dvVarsEConjs(0)("valor"))).Points.AddXY(CDbl(dvVarsEConjs(0)("a")), CDbl(dvVarsEConjs(0)("pa")))
                    ChartCons(i).Series(CStr(dvVarsEConjs(0)("valor"))).Points.AddXY(CDbl(dvVarsEConjs(0)("b")), CDbl(dvVarsEConjs(0)("pb")))
                    ChartCons(i).Series(CStr(dvVarsEConjs(0)("valor"))).Points.AddXY(CDbl(dvVarsEConjs(0)("c")), CDbl(dvVarsEConjs(0)("pc")))
                    ChartCons(i).Series(CStr(dvVarsEConjs(0)("valor"))).Points.AddXY(CDbl(dvVarsEConjs(0)("d")), CDbl(dvVarsEConjs(0)("pd")))
            End Select

            lblConsVar(i) = New Label
            lblConsVar(i).Text = dvVarsEConjs(0)("nome") & " = " & dvVarsEConjs(0)("valor")
            lblConsVar(i).Location = New System.Drawing.Point(574, 170 + (i * 185))
            lblConsVar(i).Size = New System.Drawing.Size(223, 13)
            lblConsVar(i).TextAlign = ContentAlignment.MiddleCenter
            lblConsVar(i).Font = New Font(Me.Font, FontStyle.Bold)
            Panel1.Controls.Add(lblConsVar(i))
        Next

        insereVarsInput()

    End Sub

    Private Sub insereVarsInput()
        For i As Integer = 0 To intNumRegras - 1
            'verifica se já existe a variável na coleção
            If IsNothing(VarsInput(antvar(i, 0))) = True Then
                VarsInput.Add(antvar(i, 0), antvlr(i, 0))
            End If

            If oper(i) <> String.Empty Then
                If IsNothing(VarsInput(antvar(i, 1))) = True Then
                    VarsInput.Add(antvar(i, 1), antvlr(i, 1))
                End If
            End If
        Next

        ReDim lblInput(VarsInput.Count - 1)
        ReDim txtInput(VarsInput.Count - 1)
        ReDim lblInputInter(VarsInput.Count - 1)

        Dim dvVarsEConjs As New DataView(dtVarsEConjs)

        For i As Integer = 0 To VarsInput.Count - 1
            dvVarsEConjs.RowFilter = "nome = '" & VarsInput.GetKey(i) & "' AND valor = '" & VarsInput.GetByIndex(i) & "'"

            lblInput(i) = New Label
            lblInput(i).Text = VarsInput.GetKey(i)
            lblInput(i).AutoSize = True
            lblInput(i).Anchor = AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right Or AnchorStyles.Top
            lblInput(i).TextAlign = ContentAlignment.MiddleRight
            tpnlVarsInputs.Controls.Add(lblInput(i), 0, i + 1)

            txtinput(i) = New TextBox
            txtInput(i).Size = New System.Drawing.Size(50, 20)
            tpnlVarsInputs.Controls.Add(txtInput(i), 1, i + 1)

            lblInputInter(i) = New Label
            lblInputInter(i).Text = dvVarsEConjs(0)("ini") & "..." & dvVarsEConjs(0)("fin")
            lblInputInter(i).AutoSize = True
            lblInputInter(i).Anchor = AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right Or AnchorStyles.Top
            lblInputInter(i).TextAlign = ContentAlignment.MiddleCenter
            tpnlVarsInputs.Controls.Add(lblInputInter(i), 2, i + 1)

        Next
    End Sub

    Private Sub cmdDefuzzy_Click(sender As System.Object, e As System.EventArgs) Handles cmdDefuzzy.Click
        'verifica valores de entrada
        For i As Integer = 0 To txtInput.Count - 1
            If IsNumeric(txtInput(i).Text) = True Then
                Dim min As Double = lblInputInter(i).Text.Split(New [String]() {"..."}, StringSplitOptions.None)(0)
                Dim max As Double = lblInputInter(i).Text.Split(New [String]() {"..."}, StringSplitOptions.None)(1)
                If txtInput(i).Text < min Or txtInput(i).Text > max Then
                    MessageBox.Show("O valor de entrada '" & lblInput(i).Text & "' está fora do intervalo permitido!", "Valores de entrada", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Exit Sub
                End If
            Else
                MessageBox.Show("O valor de entrada '" & lblInput(i).Text & "' não é um número válido!", "Valores de entrada", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End If
        Next

        'carrega num dataview a tabela de variáveis e conjuntos
        Dim dvVarsEConjs As New DataView(dtVarsEConjs)

        For i As Integer = 0 To intNumRegras - 1
            'preenche gráfico antecedente 1
            dvVarsEConjs.RowFilter = "nome = '" & antvar(i, 0) & "' AND valor = '" & antvlr(i, 0) & "'"

            'verifica qual o valor de input para a variavel
            Dim CalcPert1 As String = txtInput(VarsInput.IndexOfKey(antvar(i, 0))).Text
            Dim Pert1 As Double

            Select Case CStr(dvVarsEConjs(0)("funcao_pert"))
                Case "Triangular"
                    Pert1 = functriangular(dvVarsEConjs(0)("a"), dvVarsEConjs(0)("b"), dvVarsEConjs(0)("c"), CalcPert1)
                Case "Trapezoidal"
                    Pert1 = functrapezoidal(dvVarsEConjs(0)("a"), dvVarsEConjs(0)("b"), dvVarsEConjs(0)("c"), dvVarsEConjs(0)("d"), CalcPert1)
            End Select

            lblAntVar1(i).Text = dvVarsEConjs(0)("nome") & " = " & dvVarsEConjs(0)("valor") & " (µ=" & Pert1.ToString("N2") & ")"

            'desenha o cursor da pertinência no gráfico
            ChartAnt1(i).ChartAreas(0).CursorY.Position = IIf(CDbl(Pert1) = 0D, 0.001, CDbl(Pert1)) 'trata o porque do cursor nao desenhar na posição 0
            ChartAnt1(i).ChartAreas(0).CursorY.LineWidth = 3
            ChartAnt1(i).ChartAreas(0).CursorY.LineDashStyle = DataVisualization.Charting.ChartDashStyle.Dot
            ChartAnt1(i).ChartAreas(0).CursorY.LineColor = Color.Yellow

            Dim CalcPert2 As String
            Dim Pert2 As Double
            If oper(i) <> String.Empty Then
                CalcPert2 = txtInput(VarsInput.IndexOfKey(antvar(i, 1))).Text

                'preenche gráfico antecedente 2
                dvVarsEConjs.RowFilter = "nome = '" & antvar(i, 1) & "' AND valor = '" & antvlr(i, 1) & "'"

                'verifica qual o valor de input para a variavel
                Select Case CStr(dvVarsEConjs(0)("funcao_pert"))
                    Case "Triangular"
                        Pert2 = functriangular(dvVarsEConjs(0)("a"), dvVarsEConjs(0)("b"), dvVarsEConjs(0)("c"), CalcPert2)
                    Case "Trapezoidal"
                        Pert2 = functrapezoidal(dvVarsEConjs(0)("a"), dvVarsEConjs(0)("b"), dvVarsEConjs(0)("c"), dvVarsEConjs(0)("d"), CalcPert2)
                End Select

                lblAntVar2(i).Text = dvVarsEConjs(0)("nome") & " = " & dvVarsEConjs(0)("valor") & " (µ=" & Pert2.ToString("N2") & ")"

                'desenha o cursor da pertinência no gráfico
                ChartAnt2(i).ChartAreas(0).CursorY.Position = IIf(CDbl(Pert2) = 0D, 0.001, CDbl(Pert2)) 'trata o porque do cursor nao desenhar na posição 0
                ChartAnt2(i).ChartAreas(0).CursorY.LineWidth = 3
                ChartAnt2(i).ChartAreas(0).CursorY.LineDashStyle = DataVisualization.Charting.ChartDashStyle.Dot
                ChartAnt2(i).ChartAreas(0).CursorY.LineColor = Color.Yellow
            End If

            'define o alfacut de acordo com a operação dos antecedentes
            Dim dtrow As DataRow = dtVarsEConjs.Rows.Find({consvar(i), consvlr(i)})
            Select Case oper(i)
                Case "E"
                    dtrow("alfacut") = Math.Min(Pert1, Pert2)
                Case "OU"
                    dtrow("alfacut") = Math.Max(Pert1, Pert2)
                Case String.Empty
                    dtrow("alfacut") = Pert1
            End Select
            dtrow.AcceptChanges()

            'se já tiver a série alfacut, apaga
            If IsNothing(ChartCons(i).Series.FindByName("alfacut")) = False Then
                ChartCons(i).Series.Remove(ChartCons(i).Series.FindByName("alfacut"))
            End If

            If dtrow("alfacut") > 0 Then
                'configura gráfico consequente inserindo a série alfacut escalada
                ChartCons(i).Series.Add("alfacut")
                ChartCons(i).Series("alfacut").ChartType = DataVisualization.Charting.SeriesChartType.Area
                ChartCons(i).Series("alfacut").Color = Color.Yellow
                'plota gráfico consequente
                Select Case CStr(dtrow("funcao_pert"))
                    Case "Triangular"
                        'plota os 3 pontos agora com a pertinência do alfacut
                        Dim retAlfacut As New SortedList
                        retAlfacut = CalcularAlfacut("Triangular", dtrow("a"), Math.Min(dtrow("pa"), dtrow("alfacut")), dtrow("b"), Math.Min(dtrow("pb"), dtrow("alfacut")), dtrow("c"), Math.Min(dtrow("pc"), dtrow("alfacut")), -1, -1, dtrow("ini"), dtrow("fin"))

                        ChartCons(i).Series("alfacut").Points.DataBindXY(retAlfacut, "key", retAlfacut, "value")

                    Case "Trapezoidal"
                        Dim retAlfacut As New SortedList
                        retAlfacut = CalcularAlfacut("Trapezoidal", dtrow("a"), Math.Min(dtrow("pa"), dtrow("alfacut")), dtrow("b"), Math.Min(dtrow("pb"), dtrow("alfacut")), dtrow("c"), Math.Min(dtrow("pc"), dtrow("alfacut")), dtrow("d"), Math.Min(dtrow("pd"), dtrow("alfacut")), dtrow("ini"), dtrow("fin"))

                        ChartCons(i).Series("alfacut").Points.DataBindXY(retAlfacut, "key", retAlfacut, "value")

                End Select
            End If

            lblConsVar(i).Text = dtrow("nome") & " = " & dtrow("valor") & " (µ=" & CDbl(dtrow("alfacut")).ToString("N2") & ")"
        Next


        '==========================CÁLCULO DE AGREGAÇÃO

        'carrega as variáveis de saída em um array sem se preocupar com os valores do conjunto.
        For i As Integer = 0 To intNumRegras - 1
            'verifica se já existe a variável na coleção
            If IsNothing(VarsOutput(consvar(i))) = True Then
                VarsOutput.Add(consvar(i), String.Empty)
            End If
        Next

        ReDim ChartAgreg(VarsOutput.Count - 1)

        Panel2.Controls.Clear()

        'faz laço em cada variável para preencher com um gráfico cada
        For i As Integer = 0 To VarsOutput.Count - 1
            'retorna a variável e todos os seus conjuntos na view
            dvVarsEConjs.RowFilter = "nome = '" & VarsOutput.GetKey(i) & "'"

            'cria gráfico de agregação
            'configura gráfico
            ChartAgreg(i) = New System.Windows.Forms.DataVisualization.Charting.Chart
            ChartAgreg(i).Cursor = Cursors.Hand
            ChartAgreg(i).BorderlineColor = Color.FromArgb(-8355585)
            ChartAgreg(i).BorderlineDashStyle = DataVisualization.Charting.ChartDashStyle.Solid
            ChartAgreg(i).BorderlineWidth = 2
            ChartAgreg(i).BorderSkin.SkinStyle = System.Windows.Forms.DataVisualization.Charting.BorderSkinStyle.Emboss
            ChartAgreg(i).BorderSkin.PageColor = SystemColors.Control
            ChartAgreg(i).Size = New System.Drawing.Size(223, 144)
            ChartAgreg(i).Location = New System.Drawing.Point(13 + (i * 247), 13)
            ChartAgreg(i).ChartAreas.Add("")
            ChartAgreg(i).ChartAreas(0).AxisY.LabelAutoFitMaxFontSize = 6
            ChartAgreg(i).ChartAreas(0).AxisY.Minimum = 0
            ChartAgreg(i).ChartAreas(0).AxisY.Maximum = 1
            ChartAgreg(i).ChartAreas(0).AxisY.Interval = 0.5
            ChartAgreg(i).ChartAreas(0).AxisX.LabelAutoFitMaxFontSize = 6
            ChartAgreg(i).ChartAreas(0).AxisX.Minimum = dvVarsEConjs(0)("ini")
            ChartAgreg(i).ChartAreas(0).AxisX.Maximum = dvVarsEConjs(0)("fin")
            ChartAgreg(i).Tag = i 'armazena o índice do chart para ser verificado no click
            'adiona o handle para tratar o click no array de charts
            AddHandler ChartAgreg(i).Click, AddressOf ChartAgreg_Click
            Panel2.Controls.Add(ChartAgreg(i))

            'laço em todos as linha das regras pegando os valores dos consequentes
            For j As Integer = 0 To intNumRegras - 1
                'se a linha da regra coincidir com a variável do output
                If consvar(j) = VarsOutput.GetKey(i) And ChartCons(j).Series.Count = 2 Then 'condição series=2 para entrar só quando há alfacut
                    'plota gráfico sendo que cada valor do conjunto é uma série no gráfico
                    ChartAgreg(i).Series.Add(VarsOutput.GetKey(i) + CStr(j))
                    ChartAgreg(i).Series(VarsOutput.GetKey(i) + CStr(j)).ChartType = DataVisualization.Charting.SeriesChartType.Area
                    ChartAgreg(i).Series(VarsOutput.GetKey(i) + CStr(j)).Color = Color.Yellow
                    ChartAgreg(i).Series(VarsOutput.GetKey(i) + CStr(j)).BorderWidth = 2

                    'pega a série alfacut do gráfico consequente e adiciona na série do gráfico de agregação
                    For k As Integer = 0 To ChartCons(j).Series("alfacut").Points.Count - 1
                        ChartAgreg(i).Series(VarsOutput.GetKey(i) + CStr(j)).Points.AddXY(ChartCons(j).Series("alfacut").Points(k).XValue, ChartCons(j).Series("alfacut").Points(k).YValues(0))
                    Next
                End If
            Next j

            'calcula o centróide
            Dim dblCOG_dividendo As Double = 0
            Dim dblCOG_divisor As Double = 0
            Dim dblCOG As Double = 0

            Dim X As Double
            Dim Y As Double

            'verifica se o gráfico de agregação não possui dados
            'isso acontece quando as entradas não encontram regras
            'descobrimos o problema em 19/11.
            'Soluções:
            '  1 - retira o conjunto
            '  2 - faz uma regra para contemplar as entradas
            If ChartAgreg(i).Series.Count = 0 Then
                dblCOG = 0
            Else
                'descobre o max para captar a envoltória
                For j As Integer = 0 To ChartAgreg(i).Series(0).Points.Count - 1
                    X = ChartAgreg(i).Series(0).Points(j).XValue
                    Y = 0
                    For CadaSerieGrafAgreg As Integer = 0 To ChartAgreg(i).Series.Count - 1
                        Y = Math.Max(ChartAgreg(i).Series(CadaSerieGrafAgreg).Points(j).YValues(0), Y)
                    Next CadaSerieGrafAgreg

                    dblCOG_dividendo += X * Y
                    dblCOG_divisor += Y
                Next j

                dblCOG = dblCOG_dividendo / dblCOG_divisor
            End If

            'desenha o cursos para indicar o centróide
            ChartAgreg(i).ChartAreas(0).Name = VarsOutput.GetKey(i) 'armazena a variável na tag
            ChartAgreg(i).ChartAreas(0).CursorX.Position = dblCOG
            ChartAgreg(i).ChartAreas(0).CursorX.LineWidth = 3
            ChartAgreg(i).ChartAreas(0).CursorX.LineDashStyle = DataVisualization.Charting.ChartDashStyle.Dot
            ChartAgreg(i).ChartAreas(0).CursorX.LineColor = Color.Red

            'imprime resultado do cálculo do centróide
            Dim lblAgred(VarsOutput.Count - 1) As Label

            lblAgred(i) = New Label
            lblAgred(i).Text = VarsOutput.GetKey(i) & ": " & dblCOG.ToString("N2")
            lblAgred(i).Location = New System.Drawing.Point(13 + (i * 247), 157)
            lblAgred(i).AutoSize = True
            lblAgred(i).ImageAlign = ContentAlignment.MiddleCenter
            lblAgred(i).Font = New Font(Me.Font, FontStyle.Bold)
            If dblCOG = 0 Then
                lblAgred(i).ForeColor = Color.Red
            Else
                lblAgred(i).ForeColor = Color.Black
            End If
            Panel2.Controls.Add(lblAgred(i))
        Next i
    End Sub

    Private Sub ChartAgreg_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim ndxGrafAgreg As Integer
        ndxGrafAgreg = CType(sender, System.Windows.Forms.DataVisualization.Charting.Chart).Tag

        Dim frmAnaliseGrafAgreg As New frmAnaliseGrafAgreg
        frmAnaliseGrafAgreg.AnaliseGrafAgreg(ChartAgreg(ndxGrafAgreg))
    End Sub

    Private Function CalcularAlfacut(funcao_pert As String, a As Double, pa As Double, b As Double, pb As Double, c As Double, pc As Double, d As Double, pd As Double, ini As Double, fin As Double) As SortedList
        Dim ret As New SortedList

        'somente verifica quantidade de segmentações
        Dim intContNumSegmentos As Integer = 0
        For i As Double = ini To fin Step (fin - ini) / 100
            intContNumSegmentos += 1
        Next i
        'corrige o por que ele sempre avança mais 1 posição 
        intContNumSegmentos -= 1

        Dim X(intContNumSegmentos) As Double
        Dim Y(intContNumSegmentos) As Double

        Dim posX As Integer = 0

        For i As Double = ini To fin Step (fin - ini) / 100
            X(posX) = i

            'verifica se é triângulo ou trapézio
            Select Case funcao_pert
                Case "Triangular"
                    Dim MaxPert As Double = Math.Max(Math.Max(pa, pb), pc)
                    Y(posX) = Math.Min(functriangular(a, b, c, i), MaxPert)

                Case "Trapezoidal"
                    Dim MaxPert As Double = Math.Max(Math.Max(Math.Max(pa, pb), pc), pd)
                    Y(posX) = Math.Min(functrapezoidal(a, b, c, d, i), MaxPert)
            End Select

            ret.Add(X(posX), Y(posX))

            posX += 1
        Next i

        CalcularAlfacut = ret
    End Function

End Class