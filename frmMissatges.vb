Imports System.Windows.Forms

Public Class frmMissatges

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        frmPrincipal.Enabled = True
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        frmPrincipal.Enabled = True
        Me.Close()
    End Sub

    Private Sub txtMissatges_DoubleClick(sender As Object, e As EventArgs) Handles txtMissatges.DoubleClick
        Dim nroFeinaC As String = ""
        Dim auxC As String

        If Mid(txtMissatges.SelectedText, 1, 1) = "#" Then
            For i = 2 To txtMissatges.SelectedText.Length
                auxC = Mid(txtMissatges.SelectedText, i, 1)
                If auxC < "0" Or auxC > "9" Then Exit For
                nroFeinaC &= auxC
            Next
            If nroFeinaC.Length > 0 Then
                frmPrincipal.MostrarFeina(CLng(nroFeinaC))
            End If
            txtMissatges.SelectionLength = 0
        End If
    End Sub

End Class
