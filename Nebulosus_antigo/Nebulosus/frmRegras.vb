Imports System.Data
Imports System.Data.OleDb

Public Class frmRegras

    Private Sub frmRegras_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Dim conn As New OleDbConnection(ConnectionString)

        Dim cmd1 As New OleDbCommand
        cmd1.CommandType = CommandType.Text
        cmd1.CommandText = "DELETE FROM tblregras"
        cmd1.Connection = conn

        conn.Open()
        cmd1.ExecuteNonQuery()
        conn.Close()

        For i As Integer = 0 To (dgRegras.Rows.Count - 2)
            Dim cmd2 As New OleDbCommand
            cmd2.CommandType = CommandType.Text
            cmd2.CommandText = "INSERT INTO tblregras VALUES (@regra)"
            cmd2.Connection = conn
            cmd2.Parameters.Add("@regra", OleDbType.WChar).Value = dgRegras.Rows(i).Cells(0).Value

            conn.Open()
            cmd2.ExecuteNonQuery()
            conn.Close()
        Next
    End Sub

    Private Sub frmRegras_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        preencheTVWVariaveis()
        preencheDGRegras()
    End Sub

    Private Sub preencheTVWVariaveis()
        Dim daVariaveis As New OleDbDataAdapter("SELECT * FROM tblvariaveis", ConnectionString)
        Dim daConjuntos As New OleDbDataAdapter("SELECT * FROM tblconjuntos", ConnectionString)
        Dim ds As New DataSet

        Try
            daVariaveis.Fill(ds, "Variaveis")
            daConjuntos.Fill(ds, "Conjuntos")
        Catch ex As Exception
            MsgBox(ex.Message)
            Exit Sub
        End Try

        Dim dvConjuntos = ds.Tables("Conjuntos").DefaultView

        Dim dr As DataRow
        Dim nodo As TreeNode

        'percorre cada linha na tabela Variaveis 
        For Each dr In ds.Tables("Variaveis").Rows
            'preencher todas as variáveis com o nome
            nodo = tvwVariaveis.Nodes.Add(dr("nome"))

            'preencher os conjuntos para cada variável filtrando por codigo da variável
            dvConjuntos.RowFilter = "codvar = " & dr("codvar")

            'preenche os nos do treeview com o nome do conjunto para cada variável
            For i As Integer = 0 To dvConjuntos.Count - 1
                nodo.Nodes.Add(dvConjuntos.Item(i).Row("valor"))
            Next
        Next
    End Sub

    Private Sub preencheDGRegras()
        Dim da As New OleDbDataAdapter("SELECT * FROM tblregras", ConnectionString)
        Dim dt As New DataTable

        Try
            da.Fill(dt)
        Catch ex As Exception
            MsgBox(ex.Message)
            Exit Sub
        End Try

        For i As Integer = 0 To dt.Rows.Count - 1
            dgRegras.Rows.Add(dt.Rows(i)(0))
        Next
    End Sub

    Private Sub cmdVarIncluir_Click(sender As System.Object, e As System.EventArgs)
        dgRegras.Rows.Add()
    End Sub
End Class