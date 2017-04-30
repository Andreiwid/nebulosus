Imports System.Windows.Forms.DataVisualization.Charting

Public Class frmAnaliseGrafAgreg
    Dim GrafAgreg As New Chart

    Friend Sub AnaliseGrafAgreg(GrafAgreg As Chart)
        Me.GrafAgreg = GrafAgreg
        Me.ShowDialog()
    End Sub

    Private Sub CarregarGrafico()
        ChartEnvoltoria.ChartAreas(0).AxisX.Minimum = GrafAgreg.ChartAreas(0).AxisX.Minimum
        ChartEnvoltoria.ChartAreas(0).AxisX.Maximum = GrafAgreg.ChartAreas(0).AxisX.Maximum
        ChartEnvoltoria.ChartAreas(0).AxisX.Title = GrafAgreg.ChartAreas(0).Name

        For i As Integer = 0 To GrafAgreg.Series.Count - 1
            ChartEnvoltoria.Series.Add(GrafAgreg.Series(i).Name)
            ChartEnvoltoria.Series(i).ChartType = GrafAgreg.Series(i).ChartType
            ChartEnvoltoria.Series(i).Color = GrafAgreg.Series(i).Color
            ChartEnvoltoria.Series(i).BorderWidth = GrafAgreg.Series(i).BorderWidth
            For j As Integer = 0 To GrafAgreg.Series(i).Points.Count - 1
                ChartEnvoltoria.Series(i).Points.AddXY(GrafAgreg.Series(i).Points(j).XValue, GrafAgreg.Series(i).Points(j).YValues(0))
            Next j
        Next i

        'desenha o cursos para indicar o centróide
        ChartEnvoltoria.ChartAreas(0).CursorX.Position = GrafAgreg.ChartAreas(0).CursorX.Position
        ChartEnvoltoria.ChartAreas(0).CursorX.LineWidth = GrafAgreg.ChartAreas(0).CursorX.LineWidth
        ChartEnvoltoria.ChartAreas(0).CursorX.LineDashStyle = GrafAgreg.ChartAreas(0).CursorX.LineDashStyle
        ChartEnvoltoria.ChartAreas(0).CursorX.LineColor = GrafAgreg.ChartAreas(0).CursorX.LineColor

        lblCOG.Text = GrafAgreg.ChartAreas(0).CursorX.Position.ToString("N8")
    End Sub

    Private Sub frmAnaliseGrafAgreg_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        CarregarGrafico()
        CalcularCentroide()
    End Sub

    Private Sub CalcularCentroide()
        dgSeg.Rows.Clear()

        ''armazena os limites de X de acordo com o gráfico
        'Dim dblIni As Double = GrafAgreg.ChartAreas(0).AxisX.Minimum
        'Dim dblFin As Double = GrafAgreg.ChartAreas(0).AxisX.Maximum

        ''somente verifica quantidade de segmentações
        'Dim intContNumSegmentos As Integer = 0
        'For j As Double = dblIni To dblFin Step (dblFin - dblIni) / numSeg.Value
        '    intContNumSegmentos += 1
        'Next j
        ''corrige o por que ele sempre avança mais 1 posição 
        'intContNumSegmentos -= 1

        ''declara array dos valores de Y para cada X, considerando o número de séries do gráfico
        'Dim arrY(ChartEnvoltoria.Series.Count - 1, intContNumSegmentos) As Double

        'Dim X(intContNumSegmentos) As Double
        ''percorre cada série em busca
        'For CadaSerieGrafAgreg As Integer = 0 To ChartEnvoltoria.Series.Count - 1
        '    'esta variável só marca a posição do X
        '    Dim posX As Integer = 0
        '    For j As Double = dblIni To dblFin Step (dblFin - dblIni) / numSeg.Value
        '        X(posX) = j

        '        Dim a As Double = 0
        '        Dim pa As Double = 0
        '        Dim b As Double = 0
        '        Dim pb As Double = 0
        '        Dim c As Double = 0
        '        Dim pc As Double = 0
        '        Dim d As Double = 0
        '        Dim pd As Double = 0

        '        'verifica se é triângulo ou trapézio
        '        If ChartEnvoltoria.Series(CadaSerieGrafAgreg).Points.Count = 3 Then
        '            a = ChartEnvoltoria.Series(CadaSerieGrafAgreg).Points(0).XValue
        '            pa = ChartEnvoltoria.Series(CadaSerieGrafAgreg).Points(0).YValues(0)
        '            b = ChartEnvoltoria.Series(CadaSerieGrafAgreg).Points(1).XValue
        '            pb = ChartEnvoltoria.Series(CadaSerieGrafAgreg).Points(1).YValues(0)
        '            c = ChartEnvoltoria.Series(CadaSerieGrafAgreg).Points(2).XValue
        '            pc = ChartEnvoltoria.Series(CadaSerieGrafAgreg).Points(2).YValues(0)

        '            Dim MinPert As Double = Math.Max(Math.Max(pa, pb), pc)

        '            arrY(CadaSerieGrafAgreg, posX) = Math.Min(functriangular(a, b, c, j), MinPert)

        '        ElseIf ChartEnvoltoria.Series(CadaSerieGrafAgreg).Points.Count = 4 Then
        '            a = ChartEnvoltoria.Series(CadaSerieGrafAgreg).Points(0).XValue
        '            pa = ChartEnvoltoria.Series(CadaSerieGrafAgreg).Points(0).YValues(0)
        '            b = ChartEnvoltoria.Series(CadaSerieGrafAgreg).Points(1).XValue
        '            pb = ChartEnvoltoria.Series(CadaSerieGrafAgreg).Points(1).YValues(0)
        '            c = ChartEnvoltoria.Series(CadaSerieGrafAgreg).Points(2).XValue
        '            pc = ChartEnvoltoria.Series(CadaSerieGrafAgreg).Points(2).YValues(0)
        '            d = ChartEnvoltoria.Series(CadaSerieGrafAgreg).Points(3).XValue
        '            pd = ChartEnvoltoria.Series(CadaSerieGrafAgreg).Points(3).YValues(0)

        '            Dim MinPert As Double = Math.Max(Math.Max(Math.Max(pa, pb), pc), pd)

        '            arrY(CadaSerieGrafAgreg, posX) = Math.Min(functrapezoidal(a, b, c, d, j), MinPert)
        '        End If

        '        posX += 1
        '    Next j
        'Next CadaSerieGrafAgreg

        Dim dblCOG_dividendo As Double = 0
        Dim dblCOG_divisor As Double = 0
        Dim dblCOG As Double = 0

        'Dim Y(intContNumSegmentos) As Double

        'verifica se já existe a série envoltória
        If IsNothing(ChartEnvoltoria.Series.FindByName("envoltoria")) = False Then
            ChartEnvoltoria.Series.Remove(ChartEnvoltoria.Series.FindByName("envoltoria"))
        End If
        ChartEnvoltoria.Series.Add("envoltoria")
        ChartEnvoltoria.Series("envoltoria").ChartType = SeriesChartType.Point
        ChartEnvoltoria.Series("envoltoria").Color = Color.Green
        ChartEnvoltoria.Series("envoltoria").MarkerStyle = MarkerStyle.Circle
        ChartEnvoltoria.Series("envoltoria").MarkerSize = 5

        'descobre o max para captar a envoltória
        Dim X As Double
        Dim Y As Double

        'descobre o max para captar a envoltória
        For j As Integer = 0 To ChartEnvoltoria.Series(0).Points.Count - 1
            X = ChartEnvoltoria.Series(0).Points(j).XValue
            Y = 0
            For CadaSerieGrafAgreg As Integer = 0 To ChartEnvoltoria.Series.Count - 2 'por conta da série envoltória recém-adiconada
                Y = Math.Max(ChartEnvoltoria.Series(CadaSerieGrafAgreg).Points(j).YValues(0), Y)
            Next CadaSerieGrafAgreg

            dblCOG_dividendo += X * Y
            dblCOG_divisor += Y

            dgSeg.Rows.Add(j + 1, X.ToString("N8"), Y.ToString("N8"))
            ChartEnvoltoria.Series("envoltoria").Points.AddXY(X, Y)
        Next j

        dblCOG = dblCOG_dividendo / dblCOG_divisor

        'desenha o cursos para indicar o centróide
        ChartEnvoltoria.ChartAreas(0).CursorX.Position = dblCOG

        'imprime resultado do cálculo do centróide
        lblCOG.Text = dblCOG.ToString("N8")
    End Sub

    Private Sub cmdAplicar_Click(sender As System.Object, e As System.EventArgs)
        CalcularCentroide()
    End Sub
End Class