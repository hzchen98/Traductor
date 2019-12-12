Imports System.ComponentModel

Public Class Form3
    Private Sub Form3_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LeerDatosFicheroTraduccion()
        MsgBox(Application.StartupPath)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim IndiceSuperior As Integer = ListaTraduccion.Count()

        ListaTraduccion(ListaTraduccion.Count() - 1) = New Traduccion(TextBox1.Text,
                                                                           TextBox2.Text,
TextBox3.Text,
TextBox4.Text,
TextBox5.Text,
TextBox6.Text,
TextBox7.Text,
TextBox8.Text)
        ReDim Preserve ListaTraduccion(ListaTraduccion.Count())
    End Sub

    Private Sub Form3_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        GrabarFicheroTraduccion()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim Palabra As String = TextBox9.Text
        Dim Tra As Traduccion = Traducir(Palabra)
        TextBox10.Text = Tra.PalabraIngles
    End Sub
End Class