<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btn_version = New System.Windows.Forms.Button()
        Me.select_php = New System.Windows.Forms.ComboBox()
        Me.btn_php = New System.Windows.Forms.Button()
        Me.path_php = New System.Windows.Forms.TextBox()
        Me.btn_xampp = New System.Windows.Forms.Button()
        Me.path_xampp = New System.Windows.Forms.TextBox()
        Me.status_bar = New System.Windows.Forms.StatusStrip()
        Me.back_agent = New System.ComponentModel.BackgroundWorker()
        Me.btn_refresh = New System.Windows.Forms.Button()
        Me.btn_change = New System.Windows.Forms.Button()
        Me.btn_apache = New System.Windows.Forms.Button()
        Me.status_log = New System.Windows.Forms.RichTextBox()
        Me.php_version = New System.Windows.Forms.ToolStripStatusLabel()
        Me.apache_status = New System.Windows.Forms.ToolStripSplitButton()
        Me.folder_browser = New System.Windows.Forms.FolderBrowserDialog()
        Me.GroupBox1.SuspendLayout()
        Me.status_bar.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btn_version)
        Me.GroupBox1.Controls.Add(Me.select_php)
        Me.GroupBox1.Controls.Add(Me.btn_php)
        Me.GroupBox1.Controls.Add(Me.path_php)
        Me.GroupBox1.Controls.Add(Me.btn_xampp)
        Me.GroupBox1.Controls.Add(Me.path_xampp)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(533, 107)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Configuration"
        '
        'btn_version
        '
        Me.btn_version.Location = New System.Drawing.Point(6, 77)
        Me.btn_version.Name = "btn_version"
        Me.btn_version.Size = New System.Drawing.Size(117, 23)
        Me.btn_version.TabIndex = 5
        Me.btn_version.Text = "PHP Version"
        Me.btn_version.UseVisualStyleBackColor = True
        '
        'select_php
        '
        Me.select_php.FormattingEnabled = True
        Me.select_php.Location = New System.Drawing.Point(129, 79)
        Me.select_php.Name = "select_php"
        Me.select_php.Size = New System.Drawing.Size(398, 21)
        Me.select_php.TabIndex = 4
        '
        'btn_php
        '
        Me.btn_php.Location = New System.Drawing.Point(6, 49)
        Me.btn_php.Name = "btn_php"
        Me.btn_php.Size = New System.Drawing.Size(117, 23)
        Me.btn_php.TabIndex = 3
        Me.btn_php.Text = "PHP Directory"
        Me.btn_php.UseVisualStyleBackColor = True
        '
        'path_php
        '
        Me.path_php.Location = New System.Drawing.Point(129, 51)
        Me.path_php.Name = "path_php"
        Me.path_php.Size = New System.Drawing.Size(398, 20)
        Me.path_php.TabIndex = 2
        '
        'btn_xampp
        '
        Me.btn_xampp.Location = New System.Drawing.Point(6, 20)
        Me.btn_xampp.Name = "btn_xampp"
        Me.btn_xampp.Size = New System.Drawing.Size(117, 23)
        Me.btn_xampp.TabIndex = 1
        Me.btn_xampp.Text = "XAMMP Directory"
        Me.btn_xampp.UseVisualStyleBackColor = True
        '
        'path_xampp
        '
        Me.path_xampp.Location = New System.Drawing.Point(129, 22)
        Me.path_xampp.Name = "path_xampp"
        Me.path_xampp.Size = New System.Drawing.Size(398, 20)
        Me.path_xampp.TabIndex = 0
        '
        'status_bar
        '
        Me.status_bar.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.apache_status, Me.php_version})
        Me.status_bar.Location = New System.Drawing.Point(0, 249)
        Me.status_bar.Name = "status_bar"
        Me.status_bar.Size = New System.Drawing.Size(557, 22)
        Me.status_bar.TabIndex = 1
        Me.status_bar.Text = "StatusStrip1"
        '
        'back_agent
        '
        Me.back_agent.WorkerReportsProgress = True
        Me.back_agent.WorkerSupportsCancellation = True
        '
        'btn_refresh
        '
        Me.btn_refresh.Location = New System.Drawing.Point(12, 126)
        Me.btn_refresh.Name = "btn_refresh"
        Me.btn_refresh.Size = New System.Drawing.Size(231, 34)
        Me.btn_refresh.TabIndex = 3
        Me.btn_refresh.Text = "Refresh Version List"
        Me.btn_refresh.UseVisualStyleBackColor = True
        '
        'btn_change
        '
        Me.btn_change.Location = New System.Drawing.Point(12, 166)
        Me.btn_change.Name = "btn_change"
        Me.btn_change.Size = New System.Drawing.Size(231, 34)
        Me.btn_change.TabIndex = 4
        Me.btn_change.Text = "Change PHP Version"
        Me.btn_change.UseVisualStyleBackColor = True
        '
        'btn_apache
        '
        Me.btn_apache.Location = New System.Drawing.Point(12, 206)
        Me.btn_apache.Name = "btn_apache"
        Me.btn_apache.Size = New System.Drawing.Size(231, 34)
        Me.btn_apache.TabIndex = 5
        Me.btn_apache.Text = "Start/Stop Apache"
        Me.btn_apache.UseVisualStyleBackColor = True
        '
        'status_log
        '
        Me.status_log.BackColor = System.Drawing.Color.White
        Me.status_log.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.status_log.Font = New System.Drawing.Font("Consolas", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.status_log.Location = New System.Drawing.Point(249, 126)
        Me.status_log.Name = "status_log"
        Me.status_log.ReadOnly = True
        Me.status_log.Size = New System.Drawing.Size(296, 114)
        Me.status_log.TabIndex = 6
        Me.status_log.Text = ""
        '
        'php_version
        '
        Me.php_version.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.php_version.Name = "php_version"
        Me.php_version.Size = New System.Drawing.Size(90, 17)
        Me.php_version.Text = "PHP Version: ??"
        '
        'apache_status
        '
        Me.apache_status.BackColor = System.Drawing.SystemColors.Control
        Me.apache_status.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.apache_status.Image = Global.PHPSwitch.My.Resources.Resources.undefined
        Me.apache_status.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.apache_status.Name = "apache_status"
        Me.apache_status.Size = New System.Drawing.Size(160, 20)
        Me.apache_status.Text = "Apache: Undetermined"
        '
        'folder_browser
        '
        Me.folder_browser.RootFolder = System.Environment.SpecialFolder.MyComputer
        Me.folder_browser.ShowNewFolderButton = False
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(557, 271)
        Me.Controls.Add(Me.status_log)
        Me.Controls.Add(Me.btn_apache)
        Me.Controls.Add(Me.btn_change)
        Me.Controls.Add(Me.btn_refresh)
        Me.Controls.Add(Me.status_bar)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "Form1"
        Me.Text = "PHP Switch"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.status_bar.ResumeLayout(False)
        Me.status_bar.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btn_version As System.Windows.Forms.Button
    Friend WithEvents select_php As System.Windows.Forms.ComboBox
    Friend WithEvents btn_php As System.Windows.Forms.Button
    Friend WithEvents path_php As System.Windows.Forms.TextBox
    Friend WithEvents btn_xampp As System.Windows.Forms.Button
    Friend WithEvents path_xampp As System.Windows.Forms.TextBox
    Friend WithEvents status_bar As System.Windows.Forms.StatusStrip
    Friend WithEvents apache_status As System.Windows.Forms.ToolStripSplitButton
    Friend WithEvents back_agent As System.ComponentModel.BackgroundWorker
    Friend WithEvents btn_refresh As System.Windows.Forms.Button
    Friend WithEvents btn_change As System.Windows.Forms.Button
    Friend WithEvents btn_apache As System.Windows.Forms.Button
    Friend WithEvents status_log As System.Windows.Forms.RichTextBox
    Friend WithEvents php_version As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents folder_browser As System.Windows.Forms.FolderBrowserDialog

End Class
