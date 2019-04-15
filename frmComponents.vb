Imports System.Windows.Forms

Public Class frmComponents

    Public Shared pRecurs As String 'parametre d'entrada al form
    Public Shared pGrup As Boolean = False 'parametre de sortida del form

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        Dim auxComps As New Collection

        'validem que al menys hi hagi 2 components o bé 0
        For i = 0 To dgvComponents.Rows.Count - 1
            If CBool(dgvComponents.Item("cSel", i).Value) Then
                auxComps.Add(CStr(dgvComponents.Item("cComponent", i).Value))
            End If
        Next

        If auxComps.Count = 1 Then
            MsgBox("Un grup de recursos ha de tenir més d'un component.", MsgBoxStyle.OkOnly, "ERROR")
            Exit Sub
        End If

        If ActualitzarComponentsRecursCompost(pRecurs, auxComps) Then
            If auxComps.Count > 1 Then
                pGrup = True
            Else
                pGrup = False
            End If
            Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Me.Close()
        End If

    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub frmComponents_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim auxRow As String() = {"", ""}
        Dim auxString As String
        Dim recursosSimples As New Collection
        Dim componentsRecurs As New Collection

        Me.Text = "Components de '" & pRecurs & "'"

        'obtenim llista de recursos simples
        If Not ObtenirRecursosSimples(recursosSimples) Then
            MsgBox("Error al carregar recursos simples.", MsgBoxStyle.OkOnly, "ERROR")
            Me.Close()
            Exit Sub
        End If

        'obtenim llista de components del recurs
        If Not ObtenirComponentsRecurs(pRecurs, componentsRecurs) Then
            MsgBox("Error al carregar components del recurs.", MsgBoxStyle.OkOnly, "ERROR")
            Me.Close()
            Exit Sub
        End If

        'carreguem grid de components
        dgvComponents.Rows.Clear()
        For Each r In recursosSimples
            auxString = CType(r, String)
            'no carreguem el mateix recurs 
            If auxString <> pRecurs Then
                'carreguem camps grid detall
                auxRow(0) = CStr(componentsRecurs.Contains(auxString))
                auxRow(1) = auxString
                dgvComponents.Rows.Add(auxRow)
            End If
        Next

    End Sub

End Class
