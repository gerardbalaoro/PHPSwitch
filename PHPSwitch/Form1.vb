Public Class Form1
    Public xammp_path As String
    Public php_path As String

    Private Function validatePaths(Optional ByVal validate = True)
        xammp_path = path_xampp.Text
        php_path = path_php.Text

        If validate = True Or validate = "xampp" Then
            If IO.Directory.Exists(xammp_path) = True Then
                If IO.File.Exists(xammp_path & "\xammp-control.exe") = False Then
                    Return "XAMPP is not installed"
                End If
            Else
                Return xammp_path & "does not exist"
            End If
        End If

        If validate = True Or validate = "php" Then
            If IO.Directory.Exists(php_path) = True Then
                If IO.File.Exists(php_path & "\php.exe") = False Then
                    Return "PHP is not installed"
                End If
            Else
                Return xammp_path & "does not exist"
            End If
        End If

        Return True
    End Function

    Private Sub btn_xampp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_xampp.Click
        If folder_browser.ShowDialog = DialogResult.OK Then
            path_xampp.Text = folder_browser.SelectedPath
        End If

        validatePaths()
    End Sub
End Class
