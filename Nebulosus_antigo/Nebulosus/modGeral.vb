Module modGeral
    Public ConnectionString As String = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=|DataDirectory|\nebulosusdb.mdb"

    Public Function functriangular(a As Double, b As Double, c As Double, x As Double) As Double
        Dim ret As Double

        If (x >= a) And (x <= b) Then
            ret = (x - a) / (b - a)
        ElseIf (x >= b) And (x <= c) Then
            ret = (c - x) / (c - b)
        Else
            ret = 0
        End If

        functriangular = ret
    End Function

    Public Function functrapezoidal(a As Double, b As Double, c As Double, d As Double, x As Double) As Double
        Dim ret As Double

        If a = b Then
            'FUNÇÃO L A=B
            If (x >= b) And (x <= c) Then
                ret = 1
            ElseIf (x > c) And (x <= d) Then
                ret = (d - x) / (d - c)
            ElseIf x > d Then
                ret = 0
            End If
        ElseIf c = d Then
            'FUNÇÃO GAMA C=D
            If x <= a Then
                ret = 0
            ElseIf (x > a) And (x <= b) Then
                ret = (x - a) / (b - a)
            ElseIf (x > b) And (x <= c) Then
                ret = 1
            End If
        Else
            'TRAPEZIO A<>B<>C<>d
            If x <= a Then
                ret = 0
            ElseIf (x >= a) And (x <= b) Then
                ret = (x - a) / (b - a)
            ElseIf (x >= b) And (x <= c) Then
                ret = 1
            ElseIf (x >= c) And (x <= d) Then
                ret = (d - x) / (d - c)
            ElseIf x >= d Then
                ret = 0
            End If
        End If

        functrapezoidal = ret
    End Function

    'Public Class Modais
    '    Private _funcao_pert As String
    '    Private _a As Double
    '    Private _pa As Double
    '    Private _b As Double
    '    Private _pb As Double
    '    Private _c As Double
    '    Private _pc As Double
    '    Private _d As Double
    '    Private _pd As Double
    '    Private _ini As Double
    '    Private _fin As Double

    '    Public Sub New(ByVal funcao_pert As String, a As Double, pa As Double, b As Double, pb As Double, c As Double, pc As Double, d As Double, pd As Double, ini As Double, fin As Double)
    '        Me._funcao_pert = funcao_pert
    '        Me._a = a
    '        Me._pa = pa
    '        Me._a = a
    '        Me._pa = pa

    '    End Sub



    '    Public Property Nome() As String

    '        Get

    '            Return _nome

    '        End Get

    '        Set(ByVal Valor As String)

    '            _nome = Valor

    '        End Set

    '    End Property


    '    Public Property Email() As String

    '        Get

    '            Return _email

    '        End Get

    '        Set(ByVal Valor As String)

    '            _email = Valor

    '        End Set

    '    End Property


    'End Class
End Module
