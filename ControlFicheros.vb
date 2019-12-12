Imports Microsoft.VisualBasic.FileIO
Module ControlFicheros

    Public ListaTraduccion(0) As Traduccion

    Public Class Traduccion
        Public PalabraEspaniol As String
        Public PalabraIngles As String
        Public FraseEspaniol1 As String
        Public FraseEspaniol2 As String
        Public FraseEspaniol3 As String
        Public FraseIngles1 As String
        Public FraseIngles2 As String
        Public FraseIngles3 As String

        Sub New(PalabraEspaniol As String,
                FraseEspaniol1 As String,
                FraseEspaniol2 As String,
                FraseEspaniol3 As String,
            PalabraIngles As String,
                FraseIngles1 As String,
                FraseIngles2 As String,
                FraseIngles3 As String)

            Me.PalabraEspaniol = PalabraEspaniol
            Me.PalabraIngles = PalabraIngles
            Me.FraseEspaniol1 = FraseEspaniol1
            Me.FraseEspaniol2 = FraseEspaniol2
            Me.FraseEspaniol3 = FraseEspaniol3
            Me.FraseIngles1 = FraseIngles1
            Me.FraseIngles2 = FraseIngles2
            Me.FraseIngles3 = FraseIngles3
        End Sub

        Public Overrides Function Equals(obj As Object) As Boolean
            Dim O As Traduccion = CType(obj, Traduccion)
            Return O.PalabraIngles = PalabraIngles Or O.PalabraEspaniol = PalabraEspaniol
        End Function

        Sub New(Palabra As String)
            PalabraEspaniol = Palabra
        End Sub
    End Class

    Public Datos As String = Application.StartupPath & "\traductor.txt"

    Public Sub GrabarFicheroTraduccion()
        Dim Contador As Integer
        Dim Linea As String
        For Contador = 1 To ListaTraduccion.Count - 2
            Linea = String.Concat(ListaTraduccion(Contador).PalabraEspaniol, "#", ListaTraduccion(Contador).FraseEspaniol1,
                                  "#", ListaTraduccion(Contador).FraseEspaniol2, "#", ListaTraduccion(Contador).FraseEspaniol3, "#",
                                    ListaTraduccion(Contador).PalabraIngles, "#", ListaTraduccion(Contador).FraseIngles1, "#",
                                    ListaTraduccion(Contador).FraseIngles2, "#",
                                    ListaTraduccion(Contador).FraseIngles3, vbCrLf)
            My.Computer.FileSystem.WriteAllText(Datos, Linea, True)
        Next
    End Sub
    Public Sub LeerDatosFicheroTraduccion()
        If My.Computer.FileSystem.FileExists(Datos) Then
            Dim Fichero_leer As String = Datos
            Dim Campos As String()
            Dim indi As Integer = 1
            Dim Delimitador As String = "#"
            Using Analizador_sintactico As New TextFieldParser(Fichero_leer)
                Analizador_sintactico.SetDelimiters(Delimitador)
                While Not Analizador_sintactico.EndOfData
                    ReDim Preserve ListaTraduccion(indi)
                    Campos = Analizador_sintactico.ReadFields
                    ListaTraduccion(indi - 1) = New Traduccion(Campos(0), Campos(1), Campos(2), Campos(3),
                                                                Campos(4), Campos(5), Campos(6), Campos(7))

                    indi += 1
                End While
            End Using
            My.Computer.FileSystem.DeleteFile(Datos)
        Else
        End If
    End Sub

    Public Function Traducir(Palabra As String) As Traduccion
        For Each Tra As Traduccion In ListaTraduccion
            If Tra.Equals(New Traduccion(Palabra)) Then
                Return Tra
            End If
        Next
    End Function

End Module
