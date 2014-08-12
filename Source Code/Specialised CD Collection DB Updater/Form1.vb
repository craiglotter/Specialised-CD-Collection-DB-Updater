Imports System.IO

Public Class Form1


    Private Sub Error_Handler(ByVal ex As Exception, Optional ByVal identifier_msg As String = "")
        Try
            If ex.Message.IndexOf("Thread was being aborted") < 0 Then
                Dim Display_Message1 As New Display_Message()
                If FullErrors_Checkbox.Checked = True Then
                    Display_Message1.Message_Textbox.Text = "The Application encountered the following problem: " & vbCrLf & identifier_msg & ":" & ex.ToString
                Else
                    Display_Message1.Message_Textbox.Text = "The Application encountered the following problem: " & vbCrLf & identifier_msg & ":" & ex.Message.ToString
                End If
                Display_Message1.Timer1.Interval = 1000
                Display_Message1.ShowDialog()
                Dim dir As System.IO.DirectoryInfo = New System.IO.DirectoryInfo((Application.StartupPath & "\").Replace("\\", "\") & "Error Logs")
                If dir.Exists = False Then
                    dir.Create()
                End If
                dir = Nothing
                Dim filewriter As System.IO.StreamWriter = New System.IO.StreamWriter((Application.StartupPath & "\").Replace("\\", "\") & "Error Logs\" & Format(Now(), "yyyyMMdd") & "_Error_Log.txt", True)
                filewriter.WriteLine("#" & Format(Now(), "dd/MM/yyyy hh:mm:ss tt") & " - " & identifier_msg & ":" & ex.ToString)
                filewriter.Flush()
                filewriter.Close()
                filewriter = Nothing
            End If
        Catch exc As Exception
            MsgBox("An error occurred in Folder Listing With Size Report's error handling routine. The application will try to recover from this serious error.", MsgBoxStyle.Critical, "Critical Error Encountered")
        End Try
    End Sub


    Private Sub Activity_Handler(ByVal Message As String)
        Try
            Dim dir As System.IO.DirectoryInfo = New System.IO.DirectoryInfo((Application.StartupPath & "\").Replace("\\", "\") & "Activity Logs")
            If dir.Exists = False Then
                dir.Create()
            End If
            dir = Nothing
            Dim filewriter As System.IO.StreamWriter = New System.IO.StreamWriter((Application.StartupPath & "\").Replace("\\", "\") & "Activity Logs\" & Format(Now(), "yyyyMMdd") & "_Activity_Log.txt", True)
            filewriter.WriteLine("#" & Format(Now(), "dd/MM/yyyy hh:mm:ss tt") & " - " & Message)
            filewriter.Flush()
            filewriter.Close()
            filewriter = Nothing
        Catch ex As Exception
            Error_Handler(ex, "Activity_Logger")
        End Try
    End Sub

    Private Sub Status_Handler(ByVal Message As String)
        Try
            Status_Textbox.Text = Message.ToUpper
            Status_Textbox.Select(0, 0)
        Catch ex As Exception
            Error_Handler(ex, "Status_Handler")
        End Try
    End Sub


    Private Sub InputFolder_Textbox_DragEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles InputFolder_Textbox.DragEnter
        Try
            If e.Data.GetDataPresent(DataFormats.FileDrop) Then
                e.Effect = DragDropEffects.All
            End If
        Catch ex As Exception
            Error_Handler(ex)
        End Try
    End Sub

    Private Sub InputFolder_Textbox_DragDrop(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles InputFolder_Textbox.DragDrop
        Try
            If e.Data.GetDataPresent(DataFormats.FileDrop) Then
                Dim MyFiles() As String
                ' Assign the files to an array.
                MyFiles = e.Data.GetData(DataFormats.FileDrop)
                ' Loop through the array and add the files to the list.
                'For i = 0 To MyFiles.Length - 1
                If MyFiles.Length > 0 Then
                    Dim dinfo As FileInfo = New FileInfo(MyFiles(0))
                    If dinfo.Exists = True Then
                        InputFolder_Textbox.Text = (MyFiles(0))
                    End If
                End If
                'Next
            End If
        Catch ex As Exception
            Error_Handler(ex, "InputFolder_Textbox DragDrop")
        End Try
    End Sub


    'Private Sub Browse_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Browse_Button.Click
    '    Status_Handler("Selecting Input Folder")
    '    Try
    '        If Directory_Exists(InputFolder_Textbox.Text) = True Then
    '            FolderBrowserDialog1.SelectedPath = InputFolder_Textbox.Text
    '        End If
    '        Dim result As DialogResult = FolderBrowserDialog1.ShowDialog()
    '        If result = Windows.Forms.DialogResult.OK Then
    '            InputFolder_Textbox.Text = FolderBrowserDialog1.SelectedPath
    '        End If

    '    Catch ex As Exception
    '        Error_Handler(ex, "Browse_Button")
    '    End Try
    '    Status_Handler("Input Folder Selected")
    'End Sub

    'Private Function Directory_Exists(ByVal directory_path As String) As Boolean
    '    Dim result As Boolean = False
    '    Try
    '        If Not directory_path = "" And Not directory_path Is Nothing Then
    '            Dim dinfo As DirectoryInfo = New DirectoryInfo(directory_path)
    '            If dinfo.Exists = False Then
    '                result = False
    '            Else
    '                result = True
    '            End If
    '            dinfo = Nothing
    '        End If
    '    Catch ex As Exception
    '        Error_Handler(ex, "Directory_Exists")
    '    End Try
    '    Return result
    'End Function


    'Private Sub Main_Screen_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    '    Try
    '        InputFolder_Textbox.Text = My.Settings.InputFolder_Textbox
    '        InputFolder_Textbox.Select(0, 0)
    '        If Directory_Exists(InputFolder_Textbox.Text) = False Then
    '            InputFolder_Textbox.Text = ""
    '        End If

    '        Select Case My.Settings.Recursive_Checkbox
    '            Case True
    '                Recursive_Checkbox.Checked = True
    '                Exit Select
    '            Case False
    '                Recursive_Checkbox.Checked = False
    '                Exit Select
    '            Case Else
    '                Recursive_Checkbox.Checked = True
    '                Exit Select
    '        End Select


    '        Select Case My.Settings.FullPath_Checkbox
    '            Case True
    '                FullPath_CheckBox.Checked = True
    '                Exit Select
    '            Case False
    '                FullPath_CheckBox.Checked = False
    '                Exit Select
    '            Case Else
    '                FullPath_CheckBox.Checked = True
    '                Exit Select
    '        End Select

    '        Select Case My.Settings.SizeUnit
    '            Case "1"
    '                SizeUnit1.Checked = True
    '                Exit Select
    '            Case "2"
    '                SizeUnit2.Checked = True
    '                Exit Select
    '            Case "3"
    '                SizeUnit3.Checked = True
    '                Exit Select
    '            Case "4"
    '                SizeUnit4.Checked = True
    '                Exit Select
    '            Case Else
    '                SizeUnit3.Checked = True
    '                Exit Select
    '        End Select
    '    Catch ex As Exception
    '        Error_Handler(ex, "Main_Screen_Load")
    '    End Try
    'End Sub

    'Private Sub Main_Screen_Close(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
    '    Try
    '        If SizeUnit1.Checked = True Then
    '            My.Settings.SizeUnit = "1"
    '        End If
    '        If SizeUnit2.Checked = True Then
    '            My.Settings.SizeUnit = "2"
    '        End If
    '        If SizeUnit3.Checked = True Then
    '            My.Settings.SizeUnit = "3"
    '        End If
    '        If SizeUnit4.Checked = True Then
    '            My.Settings.SizeUnit = "4"
    '        End If
    '        My.Settings.Recursive_Checkbox = Recursive_Checkbox.Checked
    '        My.Settings.FullPath_Checkbox = FullPath_CheckBox.Checked
    '        My.Settings.InputFolder_Textbox = InputFolder_Textbox.Text
    '        My.Settings.Save()
    '    Catch ex As Exception
    '        Error_Handler(ex, "Main_Screen_Close")
    '    End Try

    'End Sub

    'Private Sub SizeUnit1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SizeUnit1.CheckedChanged
    '    Status_Handler("Selecting Size Unit")
    '    My.Settings.SizeUnit = "1"
    '    Status_Handler("Size Unit Selected")
    'End Sub

    'Private Sub SizeUnit2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SizeUnit2.CheckedChanged
    '    Status_Handler("Selecting Size Unit")
    '    My.Settings.SizeUnit = "2"
    '    Status_Handler("Size Unit Selected")
    'End Sub

    'Private Sub SizeUnit3_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SizeUnit3.CheckedChanged
    '    Status_Handler("Selecting Size Unit")
    '    My.Settings.SizeUnit = "3"
    '    Status_Handler("Size Unit Selected")
    'End Sub

    'Private Sub SizeUnit4_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SizeUnit4.CheckedChanged
    '    Status_Handler("Selecting Size Unit")
    '    My.Settings.SizeUnit = "4"
    '    Status_Handler("Size Unit Selected")
    'End Sub

    'Private Sub InputFolder_Textbox_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles InputFolder_Textbox.TextChanged
    '    Status_Handler("Input Folder Selected")
    'End Sub





    'Private Sub startAsyncButton_Click(ByVal sender As System.Object, _
    ' ByVal e As System.EventArgs) _
    ' Handles startAsyncButton.Click

    '    Try
    '        SaveFileDialog1.FileName = "List_" & Format(Now, "yyyyMMdd")
    '        SaveFileDialog1.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.Desktop


    '        statusmessage = "Initializing Application for Operation Launch"
    '        Status_Handler(statusmessage)
    '        Dim resultok As DialogResult = SaveFileDialog1.ShowDialog
    '        If resultok = Windows.Forms.DialogResult.OK Then
    '            Dim fil As FileInfo = New FileInfo(SaveFileDialog1.FileName)
    '            If fil.Exists = True Then
    '                My.Computer.FileSystem.DeleteFile(SaveFileDialog1.FileName, FileIO.UIOption.OnlyErrorDialogs, FileIO.RecycleOption.SendToRecycleBin)
    '            End If
    '            fil = Nothing


    '            ' Reset the text in the result label.

    '            bytes_label.Text = [String].Empty
    '            currentfilename_label.Text = [String].Empty
    '            currentfoldername_label.Text = [String].Empty
    '            filecount_label.Text = [String].Empty
    '            foldercount_label.Text = [String].Empty
    '            datelaunched_label.Text = [String].Empty
    '            savefilename_label.Text = [String].Empty


    '            bytes = 0
    '            currentfilename = ""
    '            currentfoldername = ""
    '            filecount = 0
    '            foldercount = 0
    '            statusmessage = ""
    '            highestPercentageReached = 0
    '            totalfilesprecount = 0
    '            totalfoldersprecount = 0
    '            datelaunched = Now()
    '            savefilename = ""
    '            pretestdone = False
    '            depthstep = 0
    '            bytesResults = Nothing
    '            bytesResults = New ArrayList


    '            Controls_Enabler("run")

    '            ' Get the value from the UpDown control.

    '            datelaunched = Now()
    '            savefilename = SaveFileDialog1.FileName

    '            ' Reset the variable for percentage tracking.
    '            highestPercentageReached = 0

    '            ' Start the asynchronous operation.
    '            Me.LinkLabel1.Visible = True
    '            BackgroundWorker1.RunWorkerAsync(InputFolder_Textbox.Text)
    '        Else
    '            statusmessage = "Operation Launch Cancelled"
    '            Status_Handler(statusmessage)
    '        End If

    '    Catch ex As Exception
    '        Error_Handler(ex, "startAsyncButton_Click")
    '    End Try
    'End Sub 'startAsyncButton_Click


    'Private Sub cancelAsyncButton_Click( _
    'ByVal sender As System.Object, _
    'ByVal e As System.EventArgs) _
    'Handles cancelAsyncButton.Click

    '    ' Cancel the asynchronous operation.
    '    Me.backgroundWorker1.CancelAsync()

    '    ' Disable the Cancel button.
    '    cancelAsyncButton.Enabled = False

    'End Sub 'cancelAsyncButton_Click

    '' This event handler is where the actual work is done.
    'Private Sub backgroundWorker1_DoWork( _
    'ByVal sender As Object, _
    'ByVal e As DoWorkEventArgs) _
    'Handles BackgroundWorker1.DoWork

    '    ' Get the BackgroundWorker object that raised this event.
    '    Dim worker As BackgroundWorker = _
    '        CType(sender, BackgroundWorker)

    '    ' Assign the result of the computation
    '    ' to the Result property of the DoWorkEventArgs
    '    ' object. This is will be available to the 
    '    ' RunWorkerCompleted eventhandler.
    '    e.Result = MainWorkerFunction(e.Argument, worker, e)
    'End Sub 'backgroundWorker1_DoWork

    '' This event handler deals with the results of the
    '' background operation.
    'Private Sub backgroundWorker1_RunWorkerCompleted( _
    'ByVal sender As Object, ByVal e As RunWorkerCompletedEventArgs) _
    'Handles BackgroundWorker1.RunWorkerCompleted

    '    ' First, handle the case where an exception was thrown.
    '    If Not (e.Error Is Nothing) Then
    '        Error_Handler(e.Error, "backgroundWorker1_RunWorkerCompleted")
    '    ElseIf e.Cancelled Then
    '        ' Next, handle the case where the user canceled the 
    '        ' operation.
    '        ' Note that due to a race condition in 
    '        ' the DoWork event handler, the Cancelled
    '        ' flag may not have been set, even though
    '        ' CancelAsync was called.
    '        Me.ProgressBar1.Value = 0
    '        bytes_label.Text = "Cancelled"
    '        currentfilename_label.Text = "Cancelled"
    '        currentfoldername_label.Text = "Cancelled"
    '        filecount_label.Text = "Cancelled"
    '        foldercount_label.Text = "Cancelled"
    '        datelaunched_label.Text = "Cancelled"
    '        savefilename_label.Text = "Cancelled"
    '        statusmessage = "Operation Cancelled"
    '    Else
    '        ' Finally, handle the case where the operation succeeded.

    '        Status_Handler(e.Result)
    '        Me.ProgressBar1.Value = 100
    '        Me.bytes_label.Text = bytes
    '        Me.currentfilename_label.Text = currentfilename
    '        Me.currentfoldername_label.Text = currentfoldername
    '        filecount_label.Text = filecount & " (of " & totalfilesprecount & " files)"
    '        foldercount_label.Text = foldercount - 1 & " (of " & totalfoldersprecount - 1 & " folders)"
    '        Me.datelaunched_label.Text = Format(datelaunched, "yyyy/MM/dd HH:mm:ss") & " - " & Format(Now, "yyyy/MM/dd HH:mm:ss") & " (" & Now.Subtract(Me.datelaunched).TotalSeconds() & " s)"
    '        Me.savefilename_label.Text = SaveFileDialog1.FileName
    '        Me.LinkLabel1.Visible = True
    '        statusmessage = "Operation Completed"
    '    End If

    '    Status_Handler(statusmessage)
    '    Controls_Enabler("stop")

    'End Sub 'backgroundWorker1_RunWorkerCompleted

    'Private Sub Controls_Enabler(ByVal action As String)
    '    Select Case action.ToLower
    '        Case "run"
    '            Me.InputFolder_Textbox.Enabled = False
    '            Me.Browse_Button.Enabled = False
    '            Me.Recursive_Checkbox.Enabled = False
    '            Me.FullPath_CheckBox.Enabled = False
    '            Me.SizeUnit1.Enabled = False
    '            Me.SizeUnit2.Enabled = False
    '            Me.SizeUnit3.Enabled = False
    '            Me.SizeUnit4.Enabled = False
    '            Me.startAsyncButton.Enabled = False
    '            Me.LinkLabel1.Enabled = False
    '            ' Disable the Cancel button.
    '            Me.cancelAsyncButton.Enabled = True
    '            Exit Select
    '        Case "stop"
    '            Me.InputFolder_Textbox.Enabled = True
    '            Me.Browse_Button.Enabled = True
    '            Me.Recursive_Checkbox.Enabled = True
    '            Me.FullPath_CheckBox.Enabled = True
    '            Me.SizeUnit1.Enabled = True
    '            Me.SizeUnit2.Enabled = True
    '            Me.SizeUnit3.Enabled = True
    '            Me.SizeUnit4.Enabled = True
    '            Me.startAsyncButton.Enabled = True
    '            Me.LinkLabel1.Enabled = True
    '            ' Disable the Cancel button.
    '            Me.cancelAsyncButton.Enabled = False
    '            Exit Select
    '        Case Else
    '            Me.InputFolder_Textbox.Enabled = False
    '            Me.Browse_Button.Enabled = False
    '            Me.Recursive_Checkbox.Enabled = False
    '            Me.FullPath_CheckBox.Enabled = False
    '            Me.SizeUnit1.Enabled = False
    '            Me.SizeUnit2.Enabled = False
    '            Me.SizeUnit3.Enabled = False
    '            Me.SizeUnit4.Enabled = False
    '            Me.startAsyncButton.Enabled = False
    '            Me.LinkLabel1.Enabled = False
    '            ' Disable the Cancel button.
    '            Me.cancelAsyncButton.Enabled = True
    '            Exit Select
    '    End Select


    'End Sub

    '' This event handler updates the progress bar.
    'Private Sub backgroundWorker1_ProgressChanged( _
    'ByVal sender As Object, ByVal e As ProgressChangedEventArgs) _
    'Handles BackgroundWorker1.ProgressChanged

    '    Me.ProgressBar1.Value = e.ProgressPercentage
    '    bytes_label.Text = bytes
    '    currentfilename_label.Text = currentfilename
    '    currentfoldername_label.Text = currentfoldername
    '    filecount_label.Text = filecount & " (of " & totalfilesprecount & " files)"
    '    foldercount_label.Text = foldercount - 1 & " (of " & totalfoldersprecount - 1 & " folders)"
    '    datelaunched_label.Text = Format(datelaunched, "yyyy/MM/dd HH:mm:ss") & " - " & Format(Now, "yyyy/MM/dd HH:mm:ss") & " (" & Now.Subtract(Me.datelaunched).TotalSeconds() & " s)"
    '    savefilename_label.Text = SaveFileDialog1.FileName
    '    Status_Handler(statusmessage)
    'End Sub

    '' This is the method that does the actual work. For this
    '' example, it computes a Fibonacci number and
    '' reports progress as it does its work.
    'Function MainWorkerFunction( _
    '    ByVal input As String, _
    '    ByVal worker As BackgroundWorker, _
    '    ByVal e As DoWorkEventArgs) As String



    '    Dim result As String = ""






    '    ' Abort the operation if the user has canceled.
    '    ' Note that a call to CancelAsync may have set 
    '    ' CancellationPending to true just after the
    '    ' last invocation of this method exits, so this 
    '    ' code will not have the opportunity to set the 
    '    ' DoWorkEventArgs.Cancel flag to true. This means
    '    ' that RunWorkerCompletedEventArgs.Cancelled will
    '    ' not be set to true in your RunWorkerCompleted
    '    ' event handler. This is a race condition.
    '    If worker.CancellationPending Then
    '        e.Cancel = True
    '    Else
    '        Try

    '            If Me.pretestdone = False Then
    '                worker.ReportProgress(0)
    '                TotalFilesPreCount_Function(input)
    '                Me.pretestdone = True

    '            End If
    '            statusmessage = "Parsing Folders"
    '            depthstep = depthstep + 1
    '            Dim dinfo As DirectoryInfo = New DirectoryInfo(input)
    '            Dim dinfo2 As DirectoryInfo
    '            Dim finfo As FileInfo
    '            If dinfo.Exists = True Then

    '                Dim dosomework As Boolean = False
    '                'If Me.Recursive_Checkbox.Checked = True Then dosomework = True
    '                'If Me.Recursive_Checkbox.Checked = False And depthstep = 1 Then dosomework = True
    '                'If dosomework = True Then
    '                Dim limiter As Long = -1
    '                If depthstep = 1 Then
    '                    limiter = dinfo.GetDirectories.Length
    '                End If
    '                For Each dinfo2 In dinfo.GetDirectories()

    '                    MainWorkerFunction(dinfo2.FullName, worker, e)
    '                Next
    '                ' End If
    '                dinfo2 = Nothing
    '                Dim cdirbytes As Long = 0
    '                For Each finfo In dinfo.GetFiles()
    '                    'currentfilename = finfo.FullName
    '                    currentfilename = finfo.Name
    '                    bytes = bytes + finfo.Length
    '                    filecount = filecount + 1
    '                    cdirbytes = cdirbytes + finfo.Length
    '                Next
    '                bytesResults.Add(dinfo.FullName & "_XOX_" & cdirbytes)
    '                finfo = Nothing

    '                If Me.FullPath_CheckBox.Checked = True Then
    '                    currentfoldername = dinfo.FullName
    '                Else
    '                    currentfoldername = dinfo.Name
    '                End If
    '                If Not dinfo.FullName = InputFolder_Textbox.Text Then
    '                    'Report_Generator(currentfoldername & " (" & dinfo.GetFiles.Length & " files, " & dinfo.GetDirectories.Length & " directories)", savefilename)

    '                    ' Iterate through a collection
    '                    Dim foldersresult As Long = 0
    '                    For Each name As String In bytesResults
    '                        If name.StartsWith(dinfo.FullName) = True Then
    '                            foldersresult = foldersresult + Long.Parse(name.Remove(0, name.LastIndexOf("_XOX_") + 5))
    '                        End If
    '                    Next
    '                    If Me.Recursive_Checkbox.Checked = True Then dosomework = True
    '                    If Me.Recursive_Checkbox.Checked = False Then
    '                        For Each stri As String In Directory.GetDirectories(InputFolder_Textbox.Text)
    '                            If dinfo.FullName = stri Then
    '                                dosomework = True
    '                            End If
    '                        Next
    '                    End If
    '                    If dosomework = True Then
    '                        If SizeUnit1.Checked = True Then
    '                            Report_Generator(currentfoldername & " (" & foldersresult & " bytes)", savefilename)
    '                        End If
    '                        If SizeUnit2.Checked = True Then
    '                            Report_Generator(currentfoldername & " (" & Math.Round(foldersresult / 1024, 2) & " Kb)", savefilename)
    '                        End If
    '                        If SizeUnit3.Checked = True Then
    '                            Report_Generator(currentfoldername & " (" & Math.Round((foldersresult / 1024) / 1024, 2) & " Mb)", savefilename)
    '                        End If
    '                        If SizeUnit4.Checked = True Then
    '                            Report_Generator(currentfoldername & " (" & Math.Round(((foldersresult / 1024) / 1024) / 1024, 2) & " Gb)", savefilename)
    '                        End If
    '                    End If
    '                End If
    '                foldercount = foldercount + 1
    '            End If
    '            dinfo = Nothing


    '            ' Report progress as a percentage of the total task.

    '            Dim percentComplete As Integer = 0
    '            If totalfilesprecount > 0 Then
    '                percentComplete = CSng(filecount) / CSng(totalfilesprecount) * 100
    '            Else
    '                percentComplete = 100
    '            End If

    '            If percentComplete > highestPercentageReached Then
    '                highestPercentageReached = percentComplete
    '                worker.ReportProgress(percentComplete)
    '            End If
    '        Catch ex As Exception
    '            Error_Handler(ex, "MainWorkerFunction")
    '        End Try
    '    End If

    '    Return result

    'End Function

    'Private Sub TotalFilesPreCount_Function(ByVal input As String)
    '    Try
    '        statusmessage = "Calculating Operational Parameters"
    '        'predepthstep = predepthstep + 1
    '        Dim dinfo As DirectoryInfo = New DirectoryInfo(input)
    '        Dim dinfo2 As DirectoryInfo
    '        Dim finfo As FileInfo
    '        If dinfo.Exists = True Then


    '            'Dim dosomework As Boolean = False
    '            'If Me.Recursive_Checkbox.Checked = True Then dosomework = True
    '            'If Me.Recursive_Checkbox.Checked = False And predepthstep = 1 Then dosomework = True
    '            'If dosomework = True Then
    '            For Each dinfo2 In dinfo.GetDirectories()
    '                TotalFilesPreCount_Function(dinfo2.FullName)
    '            Next
    '            ' End If

    '            dinfo2 = Nothing

    '            For Each finfo In dinfo.GetFiles()
    '                totalfilesprecount = totalfilesprecount + 1
    '            Next
    '            totalfoldersprecount = totalfoldersprecount + 1
    '            finfo = Nothing
    '        End If
    '        dinfo = Nothing
    '    Catch ex As Exception
    '        Error_Handler(ex, "TotalFilesPreCount_Function")
    '    End Try
    'End Sub

    'Private Sub Report_Generator(ByVal Message As String, ByVal Filename As String)
    '    Try
    '        Dim filewriter As System.IO.StreamWriter = New System.IO.StreamWriter(Filename, True)
    '        filewriter.WriteLine(Message)
    '        filewriter.Flush()
    '        filewriter.Close()
    '        filewriter = Nothing
    '    Catch ex As Exception
    '        Error_Handler(ex, "Report_Generator")
    '    End Try
    'End Sub

    'Private Sub FullPath_CheckBox_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FullPath_CheckBox.CheckedChanged
    '    Status_Handler("Write Full Folder Path Switch Toggled")
    'End Sub

    'Private Sub Recursive_Checkbox_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Recursive_Checkbox.CheckedChanged
    '    Status_Handler("Recursive Listing Switch Toggled")
    'End Sub



    'Private Sub LinkLabel1_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
    '    Try
    '        If savefilename.Length > 0 Then
    '            Dim systemDirectory As String
    '            systemDirectory = System.Environment.SystemDirectory
    '            Dim finfo As FileInfo = New FileInfo((systemDirectory & "\notepad.exe").Replace("\\", "\"))
    '            If finfo.Exists = True Then
    '                Dim apptorun As String
    '                apptorun = """" & (systemDirectory & "\notepad.exe").Replace("\\", "\") & """ """ & savefilename & """"
    '                Dim procID As Integer = Shell(apptorun, AppWinStyle.NormalFocus, False)
    '            End If
    '            finfo = Nothing
    '        End If
    '    Catch ex As Exception
    '        Error_Handler(ex, "LinkLabel1_LinkClicked")
    '    End Try
    'End Sub


    Protected Friend Function Get_Connection() As OleDb.OleDbConnection
        'Standard(Security)
        '"Provider=sqloledb;Data Source=Aron1;Initial Catalog=pubs;User Id=sa;Password=asdasd;" 

        'Trusted(Connection)
        '"Provider=sqloledb;Data Source=Aron1;Initial Catalog=pubs;Integrated Security=SSPI;" 
        '(use serverName\instanceName as Data Source to use an specifik SQLServer instance, only SQLServer2000)

        'Prompt for username and password:
        'oConn.Provider = "sqloledb"
        'oConn.Properties("Prompt") = adPromptAlways
        'oConn.Open("Data Source=Aron1;Initial Catalog=pubs;")

        'Connect via an IP address:
        '"Provider=sqloledb;Data Source=190.190.200.100,1433;Network Library=DBMSSOCN;Initial Catalog=pubs;User ID=sa;Password=asdasd;" 
        '(DBMSSOCN=TCP/IP instead of Named Pipes, at the end of the Data Source is the port to use (1433 is the default))

        Dim connection_string As String
        'If dbserver.IndexOf(".") = -1 Then
        'connection_string = "Provider=sqloledb;Data Source=" & dbserver & ";Initial Catalog=" & dbtable & ";User Id=" & dbuser & ";Password=" & dbpassword & ";"
        'Else
        'connection_string = "Provider=sqloledb;Data Source=" & dbserver & ",1433;Network Library=DBMSSOCN;Initial Catalog=" & dbtable & ";User Id=" & dbuser & ";Password=" & dbpassword & ";"
        'End If
        'Dim connection_string As String = "User ID=" & dbuser & ";password=" & dbpassword & ";Data Source=" & dbserver & ";Tag with column collation when possible=False;Initial Catalog=" & dbtable & ";Use Procedure for Prepare=1;Auto Translate=True;Persist Security Info=False;Provider=""SQLOLEDB.1"";Use Encryption for Data=False;Packet Size=4096"

        connection_string = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=""C:\Documents and Settings\Administrator\My Documents\My Databases\CD_Collection.mdb"""

        Dim conn As OleDb.OleDbConnection = New OleDb.OleDbConnection(connection_string)
        Return conn
    End Function



    Public Function WorkerExecuteNonQuery(ByVal SQLstatement As String) As String
        Dim result As String
        Try

            Dim conn As OleDb.OleDbConnection
            Try
                conn = Get_Connection()
                conn.Open()

                Dim sql As OleDb.OleDbCommand
                sql = New OleDb.OleDbCommand
                sql.CommandText = SQLstatement
                sql.Connection = conn
                result = sql.ExecuteNonQuery().ToString & " SQL Statement Succeeded"
                sql.Dispose()

            Catch ex As Exception
                Error_Handler(ex)
                result = "0 SQL Statement Failed"
            Finally
                conn.Close()
                conn.Dispose()
            End Try
        Catch ex As Exception
            Error_Handler(ex)
            result = "0 SQL Statement Failed"


        End Try
        Return result
    End Function




    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim filereader As StreamReader = New StreamReader("C:\Documents and Settings\Administrator\Desktop\List_20060320.txt")
        While filereader.Peek > -1
            Dim lineread As String
            lineread = filereader.ReadLine
            If lineread.Length > 0 Then
                Dim CD_Title, CD_Category, CD_Disk_Number, CD_File_Size As String
                CD_Category = "Application"
                CD_Disk_Number = "1659"
                CD_Title = lineread.Substring(0, (lineread.LastIndexOf("("))).Trim.Replace("'", "`")
                CD_File_Size = lineread.Substring((lineread.LastIndexOf("(") + 1), (lineread.LastIndexOf(")") - lineread.LastIndexOf("(") - 1)).ToUpper.Trim
                Activity_Handler("INSERT INTO File_Collection ( CD_Title, CD_Category, CD_Disk_Number, CD_File_Size ) values ('" & CD_Title & "','" & CD_Category & "','" & CD_Disk_Number & "','" & CD_File_Size & "')")
                Activity_Handler(WorkerExecuteNonQuery("INSERT INTO File_Collection ( CD_Title, CD_Category, CD_Disk_Number, CD_File_Size ) values ('" & CD_Title & "','" & CD_Category & "','" & CD_Disk_Number & "','" & CD_File_Size & "')"))
            End If
        End While
        filereader.Close()

    End Sub
End Class
