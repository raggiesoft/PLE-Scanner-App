Module PLE
    ' Let's see if the PLE site exists
    Public Function DoesPLESiteExist(strClassName As String, strClassYear As String) As Boolean
        ' Form the URL
        Dim strBaseURL As String, strLocalPLE As String
        strBaseURL = "http://ple.odu.edu/courses/" & strClassYear & "/" & strClassName & "/qa"


        Dim uriBaseURL = New Uri(strBaseURL)
        ' Local file, to check for site not existing error
        strLocalPLE = My.Computer.FileSystem.GetTempFileName.ToString()

        ' Let's download the file that was created and check for errors
        ' We need a very long timeout interval since PLE can be slow to respond
        My.Computer.Network.DownloadFile(uriBaseURL, strLocalPLE, "", "", False, 30000, True)
        Dim reader As New System.IO.StreamReader(strLocalPLE)
        Dim strLine As String
        strLine = reader.ReadLine()
        If (strLine.StartsWith("An error occurred:", StringComparison.OrdinalIgnoreCase)) Then
            Return False
        Else
            Return True
        End If
    End Function
End Module
