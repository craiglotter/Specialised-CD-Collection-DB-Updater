<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Main_Screen
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Main_Screen))
        Me.startAsyncButton = New System.Windows.Forms.Button
        Me.Status_Textbox = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.FullErrors_Checkbox = New System.Windows.Forms.CheckBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Browse2_Button = New System.Windows.Forms.Button
        Me.Label4 = New System.Windows.Forms.Label
        Me.InputTextFile_Textbox = New System.Windows.Forms.TextBox
        Me.InputSize_Textbox = New System.Windows.Forms.TextBox
        Me.InputDiskNumber_Textbox = New System.Windows.Forms.TextBox
        Me.InputCategory_Textbox = New System.Windows.Forms.TextBox
        Me.InputTitle_Textbox = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.InputDatabase_Textbox = New System.Windows.Forms.TextBox
        Me.Browse1_Button = New System.Windows.Forms.Button
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog
        Me.LinkLabel1 = New System.Windows.Forms.LinkLabel
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar
        Me.cancelAsyncButton = New System.Windows.Forms.Button
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.lastinputline_label = New System.Windows.Forms.Label
        Me.Label13 = New System.Windows.Forms.Label
        Me.datelaunched_label = New System.Windows.Forms.Label
        Me.Label16 = New System.Windows.Forms.Label
        Me.inputlines_label = New System.Windows.Forms.Label
        Me.BackgroundWorker1 = New System.ComponentModel.BackgroundWorker
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'startAsyncButton
        '
        Me.startAsyncButton.Location = New System.Drawing.Point(41, 229)
        Me.startAsyncButton.Name = "startAsyncButton"
        Me.startAsyncButton.Size = New System.Drawing.Size(112, 23)
        Me.startAsyncButton.TabIndex = 15
        Me.startAsyncButton.Text = "Update"
        Me.startAsyncButton.UseVisualStyleBackColor = True
        '
        'Status_Textbox
        '
        Me.Status_Textbox.BackColor = System.Drawing.Color.Lavender
        Me.Status_Textbox.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.Status_Textbox.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Status_Textbox.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Status_Textbox.Location = New System.Drawing.Point(9, 8)
        Me.Status_Textbox.Name = "Status_Textbox"
        Me.Status_Textbox.ReadOnly = True
        Me.Status_Textbox.Size = New System.Drawing.Size(599, 10)
        Me.Status_Textbox.TabIndex = 18
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(614, 8)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(64, 13)
        Me.Label1.TabIndex = 17
        Me.Label1.Text = "20060623.2"
        '
        'FullErrors_Checkbox
        '
        Me.FullErrors_Checkbox.AutoSize = True
        Me.FullErrors_Checkbox.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FullErrors_Checkbox.Location = New System.Drawing.Point(684, 8)
        Me.FullErrors_Checkbox.Name = "FullErrors_Checkbox"
        Me.FullErrors_Checkbox.Size = New System.Drawing.Size(15, 14)
        Me.FullErrors_Checkbox.TabIndex = 16
        Me.FullErrors_Checkbox.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Location = New System.Drawing.Point(12, 9)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(662, 39)
        Me.Label3.TabIndex = 24
        Me.Label3.Text = resources.GetString("Label3.Text")
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Browse2_Button)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.InputTextFile_Textbox)
        Me.GroupBox1.Controls.Add(Me.InputSize_Textbox)
        Me.GroupBox1.Controls.Add(Me.InputDiskNumber_Textbox)
        Me.GroupBox1.Controls.Add(Me.InputCategory_Textbox)
        Me.GroupBox1.Controls.Add(Me.InputTitle_Textbox)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.InputDatabase_Textbox)
        Me.GroupBox1.Controls.Add(Me.Browse1_Button)
        Me.GroupBox1.ForeColor = System.Drawing.Color.Maroon
        Me.GroupBox1.Location = New System.Drawing.Point(15, 47)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(678, 140)
        Me.GroupBox1.TabIndex = 25
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Inputs"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.Black
        Me.Label9.Location = New System.Drawing.Point(459, 112)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(70, 13)
        Me.Label9.TabIndex = 38
        Me.Label9.Text = "CD_File_Size"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.Location = New System.Drawing.Point(353, 112)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(90, 13)
        Me.Label8.TabIndex = 37
        Me.Label8.Text = "CD_Disk_Number"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(252, 112)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(70, 13)
        Me.Label7.TabIndex = 36
        Me.Label7.Text = "CD_Category"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(141, 112)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(46, 13)
        Me.Label6.TabIndex = 35
        Me.Label6.Text = "CD_Title"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(16, 92)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(96, 13)
        Me.Label5.TabIndex = 34
        Me.Label5.Text = "Insert Field Values:"
        '
        'Browse2_Button
        '
        Me.Browse2_Button.Location = New System.Drawing.Point(574, 49)
        Me.Browse2_Button.Name = "Browse2_Button"
        Me.Browse2_Button.Size = New System.Drawing.Size(75, 23)
        Me.Browse2_Button.TabIndex = 33
        Me.Browse2_Button.Text = "Browse"
        Me.Browse2_Button.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(16, 55)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(75, 13)
        Me.Label4.TabIndex = 32
        Me.Label4.Text = "Input Text File:"
        '
        'InputTextFile_Textbox
        '
        Me.InputTextFile_Textbox.AllowDrop = True
        Me.InputTextFile_Textbox.BackColor = System.Drawing.SystemColors.Window
        Me.InputTextFile_Textbox.Location = New System.Drawing.Point(144, 52)
        Me.InputTextFile_Textbox.Name = "InputTextFile_Textbox"
        Me.InputTextFile_Textbox.ReadOnly = True
        Me.InputTextFile_Textbox.Size = New System.Drawing.Size(418, 20)
        Me.InputTextFile_Textbox.TabIndex = 31
        '
        'InputSize_Textbox
        '
        Me.InputSize_Textbox.Enabled = False
        Me.InputSize_Textbox.Location = New System.Drawing.Point(462, 89)
        Me.InputSize_Textbox.Name = "InputSize_Textbox"
        Me.InputSize_Textbox.ReadOnly = True
        Me.InputSize_Textbox.Size = New System.Drawing.Size(100, 20)
        Me.InputSize_Textbox.TabIndex = 30
        Me.InputSize_Textbox.Text = "#InputText#"
        '
        'InputDiskNumber_Textbox
        '
        Me.InputDiskNumber_Textbox.Location = New System.Drawing.Point(356, 89)
        Me.InputDiskNumber_Textbox.Name = "InputDiskNumber_Textbox"
        Me.InputDiskNumber_Textbox.Size = New System.Drawing.Size(100, 20)
        Me.InputDiskNumber_Textbox.TabIndex = 29
        '
        'InputCategory_Textbox
        '
        Me.InputCategory_Textbox.Location = New System.Drawing.Point(250, 89)
        Me.InputCategory_Textbox.Name = "InputCategory_Textbox"
        Me.InputCategory_Textbox.Size = New System.Drawing.Size(100, 20)
        Me.InputCategory_Textbox.TabIndex = 28
        '
        'InputTitle_Textbox
        '
        Me.InputTitle_Textbox.Enabled = False
        Me.InputTitle_Textbox.Location = New System.Drawing.Point(144, 89)
        Me.InputTitle_Textbox.Name = "InputTitle_Textbox"
        Me.InputTitle_Textbox.ReadOnly = True
        Me.InputTitle_Textbox.Size = New System.Drawing.Size(100, 20)
        Me.InputTitle_Textbox.TabIndex = 27
        Me.InputTitle_Textbox.Text = "#InputText#"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(16, 22)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(122, 13)
        Me.Label2.TabIndex = 26
        Me.Label2.Text = "CD Collection Database:"
        '
        'InputDatabase_Textbox
        '
        Me.InputDatabase_Textbox.AllowDrop = True
        Me.InputDatabase_Textbox.BackColor = System.Drawing.SystemColors.Window
        Me.InputDatabase_Textbox.Location = New System.Drawing.Point(144, 19)
        Me.InputDatabase_Textbox.Name = "InputDatabase_Textbox"
        Me.InputDatabase_Textbox.ReadOnly = True
        Me.InputDatabase_Textbox.Size = New System.Drawing.Size(418, 20)
        Me.InputDatabase_Textbox.TabIndex = 24
        '
        'Browse1_Button
        '
        Me.Browse1_Button.Location = New System.Drawing.Point(574, 16)
        Me.Browse1_Button.Name = "Browse1_Button"
        Me.Browse1_Button.Size = New System.Drawing.Size(75, 23)
        Me.Browse1_Button.TabIndex = 25
        Me.Browse1_Button.Text = "Browse"
        Me.Browse1_Button.UseVisualStyleBackColor = True
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'LinkLabel1
        '
        Me.LinkLabel1.AutoSize = True
        Me.LinkLabel1.BackColor = System.Drawing.Color.Transparent
        Me.LinkLabel1.Location = New System.Drawing.Point(200, 297)
        Me.LinkLabel1.Name = "LinkLabel1"
        Me.LinkLabel1.Size = New System.Drawing.Size(97, 13)
        Me.LinkLabel1.TabIndex = 40
        Me.LinkLabel1.TabStop = True
        Me.LinkLabel1.Text = "[Open Activity Log]"
        Me.LinkLabel1.Visible = False
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Location = New System.Drawing.Point(41, 326)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(256, 23)
        Me.ProgressBar1.TabIndex = 39
        '
        'cancelAsyncButton
        '
        Me.cancelAsyncButton.Enabled = False
        Me.cancelAsyncButton.Location = New System.Drawing.Point(178, 229)
        Me.cancelAsyncButton.Name = "cancelAsyncButton"
        Me.cancelAsyncButton.Size = New System.Drawing.Size(119, 23)
        Me.cancelAsyncButton.TabIndex = 38
        Me.cancelAsyncButton.Text = "Cancel"
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox2.Controls.Add(Me.Label10)
        Me.GroupBox2.Controls.Add(Me.lastinputline_label)
        Me.GroupBox2.Controls.Add(Me.Label13)
        Me.GroupBox2.Controls.Add(Me.datelaunched_label)
        Me.GroupBox2.Controls.Add(Me.Label16)
        Me.GroupBox2.Controls.Add(Me.inputlines_label)
        Me.GroupBox2.ForeColor = System.Drawing.Color.Maroon
        Me.GroupBox2.Location = New System.Drawing.Point(332, 193)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(361, 156)
        Me.GroupBox2.TabIndex = 41
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Operation Status"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label10.Location = New System.Drawing.Point(15, 63)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(133, 13)
        Me.Label10.TabIndex = 27
        Me.Label10.Text = "Last Input Line Registered:"
        '
        'lastinputline_label
        '
        Me.lastinputline_label.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lastinputline_label.Location = New System.Drawing.Point(15, 76)
        Me.lastinputline_label.Name = "lastinputline_label"
        Me.lastinputline_label.Size = New System.Drawing.Size(322, 23)
        Me.lastinputline_label.TabIndex = 20
        Me.lastinputline_label.Text = "(no result)"
        Me.lastinputline_label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label13.Location = New System.Drawing.Point(14, 104)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(88, 13)
        Me.Label13.TabIndex = 31
        Me.Label13.Text = "Operational Time:"
        '
        'datelaunched_label
        '
        Me.datelaunched_label.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.datelaunched_label.Location = New System.Drawing.Point(15, 117)
        Me.datelaunched_label.Name = "datelaunched_label"
        Me.datelaunched_label.Size = New System.Drawing.Size(322, 23)
        Me.datelaunched_label.TabIndex = 23
        Me.datelaunched_label.Text = "(no result)"
        Me.datelaunched_label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label16.Location = New System.Drawing.Point(15, 23)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(149, 13)
        Me.Label16.TabIndex = 28
        Me.Label16.Text = "Number of Input Lines Parsed:"
        '
        'inputlines_label
        '
        Me.inputlines_label.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.inputlines_label.Location = New System.Drawing.Point(15, 36)
        Me.inputlines_label.Name = "inputlines_label"
        Me.inputlines_label.Size = New System.Drawing.Size(322, 23)
        Me.inputlines_label.TabIndex = 25
        Me.inputlines_label.Text = "(no result)"
        Me.inputlines_label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'BackgroundWorker1
        '
        Me.BackgroundWorker1.WorkerReportsProgress = True
        Me.BackgroundWorker1.WorkerSupportsCancellation = True
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Lavender
        Me.Panel1.Controls.Add(Me.Status_Textbox)
        Me.Panel1.Controls.Add(Me.FullErrors_Checkbox)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Location = New System.Drawing.Point(-4, 355)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(710, 31)
        Me.Panel1.TabIndex = 42
        '
        'Main_Screen
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.ClientSize = New System.Drawing.Size(705, 384)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.LinkLabel1)
        Me.Controls.Add(Me.ProgressBar1)
        Me.Controls.Add(Me.cancelAsyncButton)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.startAsyncButton)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximumSize = New System.Drawing.Size(713, 418)
        Me.Name = "Main_Screen"
        Me.Text = "Specialised CD Collection DB Updater"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents startAsyncButton As System.Windows.Forms.Button
    Friend WithEvents Status_Textbox As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents FullErrors_Checkbox As System.Windows.Forms.CheckBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Browse2_Button As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents InputTextFile_Textbox As System.Windows.Forms.TextBox
    Friend WithEvents InputSize_Textbox As System.Windows.Forms.TextBox
    Friend WithEvents InputDiskNumber_Textbox As System.Windows.Forms.TextBox
    Friend WithEvents InputCategory_Textbox As System.Windows.Forms.TextBox
    Friend WithEvents InputTitle_Textbox As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents InputDatabase_Textbox As System.Windows.Forms.TextBox
    Friend WithEvents Browse1_Button As System.Windows.Forms.Button
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents LinkLabel1 As System.Windows.Forms.LinkLabel
    Friend WithEvents ProgressBar1 As System.Windows.Forms.ProgressBar
    Private WithEvents cancelAsyncButton As System.Windows.Forms.Button
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Private WithEvents lastinputline_label As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Private WithEvents datelaunched_label As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Private WithEvents inputlines_label As System.Windows.Forms.Label
    Friend WithEvents BackgroundWorker1 As System.ComponentModel.BackgroundWorker
    Friend WithEvents Panel1 As System.Windows.Forms.Panel

End Class
