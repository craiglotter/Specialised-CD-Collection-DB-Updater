Imports System
Imports System.IO
Imports System.Collections
Imports System.ComponentModel
Imports System.Drawing
Imports System.Threading
Imports System.Windows.Forms


Public Class Main_Screen


    Private lastinputline As String = ""
    Private inputlines As Long = 0
    Private statusmessage As String = ""
    Private highestPercentageReached As Integer = 0
    Private inputlinesprecount As Long = 0
    Private datelaunched As Date = Now()
    Private pretestdone As Boolean = False
    




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
            MsgBox("An error occurred in the application's error handling routine. The application will try to recover from this serious error.", MsgBoxStyle.Critical, "Critical Error Encountered")
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


    Private Sub InputFolder_Textbox_DragEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles InputDatabase_Textbox.DragEnter, InputTextFile_Textbox.DragEnter
        Try
            If e.Data.GetDataPresent(DataFormats.FileDrop) Then
                e.Effect = DragDropEffects.All
            End If
        Catch ex As Exception
            Error_Handler(ex)
        End Try
    End Sub

    Private Sub InputFolder_Textbox_DragDrop(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles InputDatabase_Textbox.DragDrop, InputTextFile_Textbox.DragDrop
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

                        If sender.Equals(InputTextFile_Textbox) = True Then
                            InputTextFile_Textbox.Text = (MyFiles(0))
                        End If
                        If sender.Equals(InputDatabase_Textbox) = True Then
                            InputDatabase_Textbox.Text = (MyFiles(0))
                        End If
                    End If
                    dinfo = Nothing
                End If
                'Next
            End If
        Catch ex As Exception
            Error_Handler(ex, "InputFolder_Textbox DragDrop")
        End Try
    End Sub


    Private Sub Browse1_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Browse1_Button.Click
        Status_Handler("Selecting Input File")
        Try
            OpenFileDialog1.Filter = "Access Files|*.mdb|All Files|*.*"
            OpenFileDialog1.FileName = ""
            If File_Exists(InputDatabase_Textbox.Text) = True Then
                OpenFileDialog1.FileName = InputDatabase_Textbox.Text
            End If
            Dim result As DialogResult = OpenFileDialog1.ShowDialog()
            If result = Windows.Forms.DialogResult.OK Then
                InputDatabase_Textbox.Text = OpenFileDialog1.FileName
            End If

        Catch ex As Exception
            Error_Handler(ex, "Browse1_Button")
        End Try
        Status_Handler("Input File Selected")
    End Sub

    Private Sub Browse2_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Browse2_Button.Click
        Status_Handler("Selecting Input File")
        Try
            OpenFileDialog1.Filter = "Text Files|*.txt|All Files|*.*"
            OpenFileDialog1.FileName = ""
            If File_Exists(InputTextFile_Textbox.Text) = True Then
                OpenFileDialog1.FileName = InputTextFile_Textbox.Text
            End If
            Dim result As DialogResult = OpenFileDialog1.ShowDialog()
            If result = Windows.Forms.DialogResult.OK Then
                InputTextFile_Textbox.Text = OpenFileDialog1.FileName
            End If

        Catch ex As Exception
            Error_Handler(ex, "Browse2_Button")
        End Try
        Status_Handler("Input File Selected")
    End Sub

    Private Function File_Exists(ByVal file_path As String) As Boolean
        Dim result As Boolean = False
        Try
            If Not file_path = "" And Not file_path Is Nothing Then
                Dim dinfo As FileInfo = New FileInfo(file_path)
                If dinfo.Exists = False Then
                    result = False
                Else
                    result = True
                End If
                dinfo = Nothing
            End If
        Catch ex As Exception
            Error_Handler(ex, "File_Exists")
        End Try
        Return result
    End Function

    Private Function Directory_Exists(ByVal directory_path As String) As Boolean
        Dim result As Boolean = False
        Try
            If Not directory_path = "" And Not directory_path Is Nothing Then
                Dim dinfo As DirectoryInfo = New DirectoryInfo(directory_path)
                If dinfo.Exists = False Then
                    result = False
                Else
                    result = True
                End If
                dinfo = Nothing
            End If
        Catch ex As Exception
            Error_Handler(ex, "Directory_Exists")
        End Try
        Return result
    End Function


    Private Sub Main_Screen_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            InputDatabase_Textbox.Text = My.Settings.InputDatabase_Textbox
            InputDatabase_Textbox.Select(0, 0)
            If File_Exists(InputDatabase_Textbox.Text) = False Then
                InputDatabase_Textbox.Text = ""
            End If

            InputTextFile_Textbox.Text = My.Settings.InputTextFile_Textbox
            InputTextFile_Textbox.Select(0, 0)
            If File_Exists(InputTextFile_Textbox.Text) = False Then
                InputTextFile_Textbox.Text = ""
            End If

            InputDiskNumber_Textbox.Text = My.Settings.InputDiskNumber_Textbox
            InputDiskNumber_Textbox.Select(0, 0)

            InputCategory_Textbox.Text = My.Settings.InputCategory_Textbox
            InputCategory_Textbox.Select(0, 0)

            Select Case My.Settings.FullErrors_Checkbox
                Case True
                    FullErrors_Checkbox.Checked = True
                    Exit Select
                Case False
                    FullErrors_Checkbox.Checked = False
                    Exit Select
                Case Else
                    FullErrors_Checkbox.Checked = True
                    Exit Select
            End Select

           
        Catch ex As Exception
            Error_Handler(ex, "Main_Screen_Load")
        End Try
    End Sub

    Private Sub Main_Screen_Close(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        Try

            My.Settings.FullErrors_Checkbox = FullErrors_Checkbox.Checked

            My.Settings.InputDatabase_Textbox = InputDatabase_Textbox.Text
            My.Settings.InputTextFile_Textbox = InputTextFile_Textbox.Text

            My.Settings.InputCategory_Textbox = InputCategory_Textbox.Text
            My.Settings.InputDiskNumber_Textbox = InputDiskNumber_Textbox.Text

            My.Settings.Save()
        Catch ex As Exception
            Error_Handler(ex, "Main_Screen_Close")
        End Try

    End Sub

    Private Sub InputDatabase_Textbox_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles InputDatabase_Textbox.TextChanged
        Status_Handler("Input Database Selected")
    End Sub
    Private Sub InputTextfile_Textbox_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles InputTextFile_Textbox.TextChanged
        Status_Handler("Input Text File Selected")
    End Sub




    Private Sub startAsyncButton_Click(ByVal sender As System.Object, _
     ByVal e As System.EventArgs) _
     Handles startAsyncButton.Click

        Try
            statusmessage = "Initializing Application for Operation Launch"
            Status_Handler(statusmessage)

            ' Reset the text in the result label.

            inputlines_label.Text = [String].Empty
            lastinputline_label.Text = [String].Empty
            datelaunched_label.Text = [String].Empty


            inputlines = 0
            lastinputline = ""
            statusmessage = ""
            highestPercentageReached = 0
            inputlinesprecount = 0
            datelaunched = Now()
            pretestdone = False
            

            Controls_Enabler("run")


            ' Start the asynchronous operation.
            Me.LinkLabel1.Visible = True
            BackgroundWorker1.RunWorkerAsync(InputTextFile_Textbox.Text)

        Catch ex As Exception
            Error_Handler(ex, "startAsyncButton_Click")
        End Try
    End Sub 'startAsyncButton_Click


    Private Sub cancelAsyncButton_Click( _
    ByVal sender As System.Object, _
    ByVal e As System.EventArgs) _
    Handles cancelAsyncButton.Click

        ' Cancel the asynchronous operation.
        Me.backgroundWorker1.CancelAsync()

        ' Disable the Cancel button.
        cancelAsyncButton.Enabled = False

    End Sub 'cancelAsyncButton_Click

    ' This event handler is where the actual work is done.
    Private Sub backgroundWorker1_DoWork( _
    ByVal sender As Object, _
    ByVal e As DoWorkEventArgs) _
    Handles BackgroundWorker1.DoWork

        ' Get the BackgroundWorker object that raised this event.
        Dim worker As BackgroundWorker = _
            CType(sender, BackgroundWorker)

        ' Assign the result of the computation
        ' to the Result property of the DoWorkEventArgs
        ' object. This is will be available to the 
        ' RunWorkerCompleted eventhandler.
        e.Result = MainWorkerFunction(e.Argument, worker, e)
    End Sub 'backgroundWorker1_DoWork

    ' This event handler deals with the results of the
    ' background operation.
    Private Sub backgroundWorker1_RunWorkerCompleted( _
    ByVal sender As Object, ByVal e As RunWorkerCompletedEventArgs) _
    Handles BackgroundWorker1.RunWorkerCompleted

        ' First, handle the case where an exception was thrown.
        If Not (e.Error Is Nothing) Then
            Error_Handler(e.Error, "backgroundWorker1_RunWorkerCompleted")
        ElseIf e.Cancelled Then
            ' Next, handle the case where the user canceled the 
            ' operation.
            ' Note that due to a race condition in 
            ' the DoWork event handler, the Cancelled
            ' flag may not have been set, even though
            ' CancelAsync was called.
            Me.ProgressBar1.Value = 0
            inputlines_label.Text = "Cancelled"
            lastinputline_label.Text = "Cancelled"
            datelaunched_label.Text = "Cancelled"
            statusmessage = "Operation Cancelled"
        Else
            ' Finally, handle the case where the operation succeeded.

            Status_Handler(e.Result)

            Me.ProgressBar1.Value = 100
            Me.inputlines_label.Text = inputlines
            Me.lastinputline_label.Text = lastinputline
            Me.datelaunched_label.Text = Format(datelaunched, "yyyy/MM/dd HH:mm:ss") & " - " & Format(Now, "yyyy/MM/dd HH:mm:ss") & " (" & Now.Subtract(Me.datelaunched).TotalSeconds() & " s)"
            Me.LinkLabel1.Visible = True
            statusmessage = "Operation Completed"
        End If

        Status_Handler(statusmessage)
        Controls_Enabler("stop")

    End Sub 'backgroundWorker1_RunWorkerCompleted

    Private Sub Controls_Enabler(ByVal action As String)
        Select Case action.ToLower
            Case "run"
                Me.InputDatabase_Textbox.Enabled = False
                Me.InputTextFile_Textbox.Enabled = False
                Me.InputCategory_Textbox.Enabled = False
                Me.InputDiskNumber_Textbox.Enabled = False
                Me.Browse1_Button.Enabled = False
                Me.Browse2_Button.Enabled = False

                Me.startAsyncButton.Enabled = False
                Me.LinkLabel1.Enabled = False
                ' Disable the Cancel button.
                Me.cancelAsyncButton.Enabled = True
                Exit Select
            Case "stop"
                Me.InputDatabase_Textbox.Enabled = True
                Me.InputTextFile_Textbox.Enabled = True
                Me.InputCategory_Textbox.Enabled = True
                Me.InputDiskNumber_Textbox.Enabled = True
                Me.Browse1_Button.Enabled = True
                Me.Browse2_Button.Enabled = True

                Me.startAsyncButton.Enabled = True
                Me.LinkLabel1.Enabled = True
                ' Disable the Cancel button.
                Me.cancelAsyncButton.Enabled = False
                Exit Select
            Case Else
                Me.InputDatabase_Textbox.Enabled = False
                Me.InputTextFile_Textbox.Enabled = False
                Me.InputCategory_Textbox.Enabled = False
                Me.InputDiskNumber_Textbox.Enabled = False
                Me.Browse1_Button.Enabled = False
                Me.Browse2_Button.Enabled = False

                Me.startAsyncButton.Enabled = False
                Me.LinkLabel1.Enabled = False
                ' Disable the Cancel button.
                Me.cancelAsyncButton.Enabled = True
                Exit Select
        End Select


    End Sub

    ' This event handler updates the progress bar.
    Private Sub backgroundWorker1_ProgressChanged( _
    ByVal sender As Object, ByVal e As ProgressChangedEventArgs) _
    Handles BackgroundWorker1.ProgressChanged

        Me.ProgressBar1.Value = e.ProgressPercentage
        inputlines_label.Text = inputlines
        lastinputline_label.Text = lastinputline

        datelaunched_label.Text = Format(datelaunched, "yyyy/MM/dd HH:mm:ss") & " - " & Format(Now, "yyyy/MM/dd HH:mm:ss") & " (" & Now.Subtract(Me.datelaunched).TotalSeconds() & " s)"
        Status_Handler(statusmessage)
    End Sub

    ' This is the method that does the actual work. 
    Function MainWorkerFunction( _
        ByVal input As String, _
        ByVal worker As BackgroundWorker, _
        ByVal e As DoWorkEventArgs) As String



        Dim result As String = ""






        ' Abort the operation if the user has canceled.
        ' Note that a call to CancelAsync may have set 
        ' CancellationPending to true just after the
        ' last invocation of this method exits, so this 
        ' code will not have the opportunity to set the 
        ' DoWorkEventArgs.Cancel flag to true. This means
        ' that RunWorkerCompletedEventArgs.Cancelled will
        ' not be set to true in your RunWorkerCompleted
        ' event handler. This is a race condition.
        If worker.CancellationPending Then
            e.Cancel = True
        Else
            Try

                If Me.pretestdone = False Then
                    worker.ReportProgress(0)
                    PreCount_Function()
                    Me.pretestdone = True

                End If
                statusmessage = "Parsing Input File"


                Dim filereader As StreamReader = New StreamReader(InputTextFile_Textbox.Text)
                While filereader.Peek > -1
                    If worker.CancellationPending Then
                        e.Cancel = True
                        Exit While
                        filereader.Close()
                    Else

                        Dim lineread As String
                        lineread = filereader.ReadLine
                        If lineread.Length > 0 Then

                            inputlines = inputlines + 1
                            lastinputline = lineread.Trim
                            ' Report progress as a percentage of the total task.
                            Dim percentComplete As Integer = 0
                            If inputlinesprecount > 0 Then
                                percentComplete = CSng(inputlines) / CSng(inputlinesprecount) * 100
                            Else
                                percentComplete = 100
                            End If

                            If percentComplete > highestPercentageReached Then
                                highestPercentageReached = percentComplete
                                worker.ReportProgress(percentComplete)
                            End If


                            Dim CD_Title, CD_Category, CD_Disk_Number, CD_File_Size As String
                            CD_Category = InputCategory_Textbox.Text.Replace("'", "''")
                            CD_Disk_Number = InputDiskNumber_Textbox.Text.Replace("'", "''")
                            CD_Title = lineread.Substring(0, (lineread.LastIndexOf("("))).Trim.Replace("'", "`").Replace("'", "''")
                            CD_File_Size = lineread.Substring((lineread.LastIndexOf("(") + 1), (lineread.LastIndexOf(")") - lineread.LastIndexOf("(") - 1)).ToUpper.Trim.Replace("'", "''")
                            Activity_Handler("INSERT INTO File_Collection ( CD_Title, CD_Category, CD_Disk_Number, CD_File_Size ) values ('" & CD_Title & "','" & CD_Category & "','" & CD_Disk_Number & "','" & CD_File_Size & "')")
                            Activity_Handler(WorkerExecuteNonQuery("INSERT INTO File_Collection ( CD_Title, CD_Category, CD_Disk_Number, CD_File_Size ) values ('" & CD_Title & "','" & CD_Category & "','" & CD_Disk_Number & "','" & CD_File_Size & "')"))


                        End If
                    End If
                End While
                filereader.Close()


            
            Catch ex As Exception
                Error_Handler(ex, "MainWorkerFunction")
            End Try
        End If

        Return result

    End Function

    Private Sub PreCount_Function()
        Try
            If File_Exists(InputTextFile_Textbox.Text) = True Then
                Dim filereader As StreamReader = New StreamReader(InputTextFile_Textbox.Text)
                While filereader.Peek > -1
                    Dim lineread As String
                    lineread = filereader.ReadLine
                    If lineread.Length > 0 Then
                        inputlinesprecount = inputlinesprecount + 1
                    End If
                End While
                filereader.Close()
            End If
            
        Catch ex As Exception
            Error_Handler(ex, "PreCount_Function")
        End Try
    End Sub






    Private Sub LinkLabel1_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Try
            If File_Exists((Application.StartupPath & "\").Replace("\\", "\") & "Activity Logs\" & Format(Now(), "yyyyMMdd") & "_Activity_Log.txt") = True Then
                Dim systemDirectory As String
                systemDirectory = System.Environment.SystemDirectory
                Dim finfo As FileInfo = New FileInfo((systemDirectory & "\notepad.exe").Replace("\\", "\"))
                If finfo.Exists = True Then
                    Dim apptorun As String
                    apptorun = """" & (systemDirectory & "\notepad.exe").Replace("\\", "\") & """ """ & (Application.StartupPath & "\").Replace("\\", "\") & "Activity Logs\" & Format(Now(), "yyyyMMdd") & "_Activity_Log.txt" & """"
                    Dim procID As Integer = Shell(apptorun, AppWinStyle.NormalFocus, False)
                End If
                finfo = Nothing
            End If
        Catch ex As Exception
            Error_Handler(ex, "LinkLabel1_LinkClicked")
        End Try
    End Sub




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

        connection_string = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=""" & InputDatabase_Textbox.Text & """"

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





End Class
