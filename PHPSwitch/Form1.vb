Imports System.ServiceProcess
Imports System.IO
Imports System.Security.Principal

Public Class Form1
    Private xampp_path As String
    Private php_path As String
    Private apache_service As String
    Private versions As New List(Of String)

    Private Function validatePaths(Optional ByVal validate As String = "all", Optional ByVal noLog As Boolean = False)
        xampp_path = path_xampp.Text
        php_path = path_php.Text
        apache_service = path_apache.Text

        If validate = "all" Or validate = "xampp" Then
            If IO.Directory.Exists(xampp_path) = True Then
                If IO.File.Exists(xampp_path & "\xampp-control.exe") = False Then
                    If noLog = False Then
                        log("XAMPP is not installed at the selected directory", "warn")
                    End If
                    Return "XAMPP is not installed in this directory: " & xampp_path
                Else
                    If noLog = False Then
                        log("XAMPP directory found", "success")
                    End If
                End If
            Else
                Return xampp_path & " does not exist"
            End If
        End If

        'If validate = "all" Or validate = "php" Then
        '    If IO.Directory.Exists(php_path) = True Then
        '        If IO.File.Exists(php_path & "\php.exe") = False Then
        '            If noLog = False Then
        '                log("PHP is not installed at the selected directory", "warn")
        '            End If
        '            Return "PHP is not installed in this directory: " & php_path
        '        Else
        '            If noLog = False Then
        '                log("PHP directory found", "success")
        '            End If
        '        End If
        '    Else
        '        Return php_path & " does not exist"
        '    End If
        'End If
        Return True
    End Function

    Private Function log(ByVal msg As String, Optional ByVal type As String = "info")
        Select Case type
            Case "info"
                status_log.Select(status_log.TextLength, 0)
                status_log.SelectionColor = Color.Black
                status_log.AppendText("[" & TimeOfDay & "] " & msg & vbNewLine)
            Case "warn"
                status_log.Select(status_log.TextLength, 0)
                status_log.SelectionColor = Color.Goldenrod
                status_log.AppendText("[" & TimeOfDay & "] " & msg & vbNewLine)
            Case "success"
                status_log.Select(status_log.TextLength, 0)
                status_log.SelectionColor = Color.DarkGreen
                status_log.AppendText("[" & TimeOfDay & "] " & msg & vbNewLine)
            Case "critical"
                status_log.Select(status_log.TextLength, 0)
                status_log.SelectionColor = Color.DarkRed
                status_log.AppendText("[" & TimeOfDay & "] " & msg & vbNewLine)
        End Select
        status_log.ScrollToCaret()
        Return Nothing
    End Function

    Private Function find_phps(Optional ByVal enablelog As Boolean = True)
        Dim val_test = validatePaths("all", Not enablelog)
        If TypeOf val_test Is Boolean AndAlso val_test = True Then
            select_php.Items.Clear()
            findphp_agent.RunWorkerAsync()
            action_status.Text = "Finding PHP versions..."
            action_status.Text = ""
        End If
        Return Nothing
    End Function

    Private Function switch_apache(Optional ByVal action As String = "restart")
        switch_agent.RunWorkerAsync(action)
        Return Nothing
    End Function

    Private Function toggle_apache(Optional ByVal action As String = "restart")
        Dim cmdproc As New Process
        Dim cmdproc_info As ProcessStartInfo = New ProcessStartInfo()
        cmdproc_info.FileName = xampp_path & "\apache\bin\httpd.exe"
        cmdproc_info.UseShellExecute = False
        cmdproc_info.CreateNoWindow = True
        cmdproc_info.RedirectStandardOutput = True
        Select Case action
            Case "restart"
                log("Stopping Apache...", "warn")
                cmdproc_info.Arguments = "-k shutdown"
                cmdproc.StartInfo = cmdproc_info
                cmdproc.Start()
                If New ServiceController(apache_service).Status = ServiceControllerStatus.Stopped Then
                    log("Starting Apache...", "warn")
                    cmdproc_info.Arguments = "-k start"
                    cmdproc.StartInfo = cmdproc_info
                    cmdproc.Start()
                    If New ServiceController(apache_service).Status = ServiceControllerStatus.Running Then
                        log("Apache started", "success")
                    Else
                        log("Failed to start Apache", "critical")
                    End If
                Else
                    log("Failed to stop Apache", "critical")
                End If
            Case "start"
                If New ServiceController(apache_service).Status = ServiceControllerStatus.Running Then
                    log("Apache is running", "success")
                Else
                    log("Starting Apache...", "warn")
                    cmdproc_info.Arguments = "-k start"
                    cmdproc.StartInfo = cmdproc_info
                    cmdproc.Start()
                    If New ServiceController(apache_service).Status = ServiceControllerStatus.Running Then
                        log("Apache started", "success")
                    Else
                        log("Failed to start Apache", "critical")
                    End If
                End If
            Case "stop"
                If New ServiceController(apache_service).Status = ServiceControllerStatus.Stopped Then
                    log("Apache is not running", "critical")
                Else
                    log("Stopping Apache...", "warn")
                    cmdproc_info.Arguments = "-k shutdown"
                    cmdproc.StartInfo = cmdproc_info
                    cmdproc.Start()
                    If New ServiceController(apache_service).Status = ServiceControllerStatus.Stopped Then
                        log("Apache stopped", "warn")
                    Else
                        log("Failed to stop Apache", "critical")
                    End If
                End If
        End Select
        Return Nothing
    End Function

    Private Function CheckService(ByVal Name As String) As Boolean
        Dim colServices As Object
        Dim objService As Object
        colServices = GetObject("winmgmts:").ExecQuery _
            ("Select Name from Win32_Service where Name = '" & Name & "'")
        For Each objService In colServices
            If Len(objService.Name) Then
                Return True
            End If
        Next
        Return False
    End Function

    Private Sub btn_xampp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_xampp.Click
        If folder_browser.ShowDialog = DialogResult.OK Then
            path_xampp.Text = folder_browser.SelectedPath
            Dim validate = validatePaths("xampp")
            If TypeOf validate Is String Then
                MsgBox(validate, MsgBoxStyle.Critical)
            Else
                If path_php.Text = Nothing Then
                    path_php.Text = xampp_path & "\php"
                    validatePaths("php")
                End If
            End If
        End If
    End Sub

    Private Sub btn_php_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_php.Click
        If folder_browser.ShowDialog = DialogResult.OK Then
            path_php.Text = folder_browser.SelectedPath
            Dim validate = validatePaths("php")
            If TypeOf validate Is String Then
                MsgBox(validate, MsgBoxStyle.Critical)
            End If
        End If
    End Sub

    Private Sub time_agent_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles time_agent.Tick
        Dim val_test = validatePaths("all", True)
        Dim apache_test = CheckService(apache_service)
        If TypeOf val_test Is Boolean AndAlso val_test = True Then
            Dim php_exe As FileVersionInfo = FileVersionInfo.GetVersionInfo(php_path + "\php.exe")
            php_version.Text = "PHP Version: " & php_exe.ProductVersion
        End If

        If CheckService(apache_service) <> False Then
            If New ServiceController(apache_service).Status = ServiceControllerStatus.Running Then
                apache_status.Image = My.Resources.running
                apache_status.Text = "Apache : Running"
            Else
                apache_status.Image = My.Resources.stopped
                apache_status.Text = "Apache : Stopped"
            End If
        Else
            apache_status.Image = My.Resources.undefined
            apache_status.Text = "Apache : Not Found"
        End If

        If (TypeOf val_test Is Boolean AndAlso val_test = True) And apache_test = True Then
            btn_apache.Enabled = True
            btn_refresh.Enabled = True
            btn_change.Enabled = True
        Else
            btn_apache.Enabled = False
            btn_refresh.Enabled = False
            btn_change.Enabled = False
        End If
    End Sub

    Private Sub btn_refresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_refresh.Click
        find_phps()
    End Sub

    Private Sub btn_apache_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_apache.Click
        switch_apache()
    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If My.User.IsInRole(ApplicationServices.BuiltInRole.Administrator) = False Then
            log("You have no Admin rights. The application may not work properly", "warn")
        End If
        path_php.Text = My.Settings.php_path
        path_xampp.Text = My.Settings.xammp_path
        path_apache.Text = My.Settings.apache_service
        validatePaths()
        time_agent.Start()
    End Sub

    Private Sub Form1_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        My.Settings.apache_service = path_apache.Text
        My.Settings.xammp_path = path_xampp.Text
        My.Settings.php_path = path_php.Text
        My.Settings.Save()
    End Sub

    Private Sub apache_start_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles apache_start.Click
        switch_apache("start")
    End Sub

    Private Sub apache_stop_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles apache_stop.Click
        switch_apache("stop")
    End Sub

    Private Sub values_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles path_xampp.TextChanged, path_php.TextChanged, path_apache.TextChanged
        If findphp_agent.IsBusy = False Then
            find_phps()
        End If
    End Sub

    Private Sub find_phps(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles findphp_agent.DoWork
        versions.Clear()
        Dim current_php = FileVersionInfo.GetVersionInfo(php_path + "\php.exe").ProductVersion
        versions.Add(current_php)
        For Each subdir In Directory.GetDirectories(Path.GetFullPath(xampp_path), "php_*")
            If IO.File.Exists(subdir & "\php.exe") = True Then
                versions.Add(FileVersionInfo.GetVersionInfo(subdir + "\php.exe").ProductVersion)
            End If
        Next
    End Sub

    Private Sub findphp_agent_RunWorkerCompleted(ByVal sender As System.Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles findphp_agent.RunWorkerCompleted
        For Each ver In versions
            select_php.Items.Add(ver)
            log("Found version: " & ver)
        Next
        select_php.SelectedItem = FileVersionInfo.GetVersionInfo(php_path + "\php.exe").ProductVersion
    End Sub

    Private Sub btn_change_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_change.Click
        log("Changing PHP version..")
        Dim selectedversion = select_php.SelectedItem
        Dim currentversion = FileVersionInfo.GetVersionInfo(php_path + "\php.exe").ProductVersion
        Try
            If Directory.Exists(xampp_path & "\php_" & currentversion) = False Then
                My.Computer.FileSystem.RenameDirectory(php_path, "php_" & currentversion)
            Else
                Throw New Exception(String.Format("Cannot rename {0} to {1} because the directory already exists", php_path, xampp_path & "\php_" & currentversion))
            End If

            If Directory.Exists(php_path) = False Then
                My.Computer.FileSystem.RenameDirectory(xampp_path & "\php_" & selectedversion, Path.GetFileName(php_path))
            Else
                Throw New Exception(String.Format("Cannot rename {0} to {1} because the directory already exists", xampp_path & "\php_" & selectedversion, php_path))
            End If
            log("PHP version changed to " & selectedversion, "success")
            switch_apache()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            log("Failed to change PHP Version", "critical")
        End Try
    End Sub

    Private Sub switch_agent_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles switch_agent.DoWork
        Dim apache As New ServiceController(apache_service)
        Dim action = e.Argument
        Select Case action
            Case "restart"
                If apache.Status = ServiceControllerStatus.Stopped Then
                    log("Apache is not running", "critical")
                    log("Starting Apache...", "warn")
                    apache.Start()
                    apache.WaitForStatus(ServiceControllerStatus.Running)
                    log("Apache started", "success")
                Else
                    log("Stopping Apache...", "warn")
                    apache.Stop()
                    apache.WaitForStatus(ServiceControllerStatus.Stopped)
                    log("Apache stopped", "warn")
                    log("Starting Apache...", "warn")
                    apache.Start()
                    apache.WaitForStatus(ServiceControllerStatus.Running)
                    log("Apache started", "success")
                End If
            Case "start"
                If apache.Status = ServiceControllerStatus.Running Then
                    log("Apache is running", "success")
                Else
                    log("Starting Apache...", "warn")
                    apache.Start()
                    apache.WaitForStatus(ServiceControllerStatus.Running)
                    log("Apache started", "success")
                End If
            Case "stop"
                If apache.Status = ServiceControllerStatus.Stopped Then
                    log("Apache is not running", "critical")
                Else
                    log("Stopping Apache...", "warn")
                    apache.Stop()
                    apache.WaitForStatus(ServiceControllerStatus.Stopped)
                    log("Apache stopped", "warn")
                End If
        End Select
    End Sub
End Class
