
Public Class frmScanner
    Dim strDescriptionBase As String = "This tool will assist with forming the URLs necessary for inserting QA tables into PLE"
    ' Let's hold our variables
    Dim strClassYear As String
    Dim strClassName As String
    Dim strBaseURL As String
    Dim strLocalPLE As String
    Private Sub btnExecute_Click(sender As Object, e As EventArgs) Handles btnExecute.Click



        ' Get the name and year the class is from
        strClassYear = cboYear.SelectedItem.ToString
        strClassName = txtClassName.Text

        ' Get the name and year the class is from
        strClassYear = cboYear.SelectedItem.ToString
        Select Case cboSemester.SelectedIndex
            Case 0 'Fall
                strClassYear &= "10"
                Exit Select
            Case 1 'Spring
                strClassYear &= "20"
                Exit Select
            Case 2 'Summer
                strClassYear &= "30"
                Exit Select
            Case Else
                MessageBox.Show("You need to enter a class name and/or class year!", "PLE QA Scanner", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
        End Select

        ' Are the entries blank?
        If (strClassName = "" Or strClassYear = "") Then
            MessageBox.Show("You need to enter a class name and/or class year!", "PLE QA Scanner", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If

        ' Form the URL
        strBaseURL = "http://ple.odu.edu/courses/" & strClassYear & "/" & strClassName & "/editor/options/accessibility_scan?" & strClassName & "_" & strClassYear
        Dim uriBaseURL = New Uri(strBaseURL)

        ' Let's see if the PLE Site exists
        Dim boolDoesPLEExist As Boolean = DoesPLESiteExist(strClassName, strClassYear)
        If (boolDoesPLEExist = False) Then
            MessageBox.Show("The PLE site you requested doesn't exist!", "PLE QA Scanner", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtClassName.Focus()
            txtClassName.SelectAll()
            Exit Sub
        End If

        ' Open the user's default browser to kick off the PLE job
        ' While there is a way to automate this, I don't feel like messing with figuring out
        ' how to seed MIDAS logins to shibboleth
        '
        ' Once the user is logged in, you can quickly execute jobs by pasting in
        ' classes and hitting execute job
        System.Diagnostics.Process.Start(strBaseURL)

    End Sub

    Private Sub btnViewScanResults_Click(sender As Object, e As EventArgs) Handles btnViewScanResults.Click
        ' Let's hold our variables
        Dim strClassYear As String
        Dim strClassName As String
        Dim strBaseURL As String

        ' Get the name and year the class is from
        strClassYear = cboYear.SelectedItem.ToString
        Select Case cboSemester.SelectedIndex
            Case 0 'Fall
                strClassYear &= "10"
                Exit Select
            Case 1 'Spring
                strClassYear &= "20"
                Exit Select
            Case 2 'Summer
                strClassYear &= "30"
                Exit Select
            Case Else
                MessageBox.Show("You need to enter a class name and/or class year!", "PLE QA Scanner", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
        End Select
        strClassName = txtClassName.Text

        ' Are the entries blank?
        If (strClassName = "" Or strClassYear = "") Then
            MessageBox.Show("You need to enter a class name and/or class year!", "PLE QA Scanner", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If

        ' Form the URL
        strBaseURL = "http://ple.odu.edu/courses/" & strClassYear & "/" & strClassName & "/qa"

        ' Let's see if the PLE site exists
        Dim boolDoesPLEExist As Boolean = DoesPLESiteExist(strClassName, strClassYear)
        If (boolDoesPLEExist = False) Then
            MessageBox.Show("The PLE site you requested doesn't exist!", "PLE QA Scanner", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtClassName.Focus()
            txtClassName.SelectAll()
            Exit Sub
        End If

        ' Start the user's default browser
        System.Diagnostics.Process.Start(strBaseURL)

    End Sub

    Private Sub frmScanner_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Let's pick a semester based on the current system date/time to default to
        Dim currentDate As Date = Date.Now

        ' Prefill the year.  Encoded as follows:
        ' YYYY year
        ' ZZ semester period.  10 = fall; 20 = spring; 30 = summer
        cboYear.Items.Add("2025")
        cboYear.Items.Add("2024")
        cboYear.Items.Add("2023")
        cboYear.Items.Add("2022")
        cboYear.Items.Add("2021")
        cboYear.Items.Add("2020")
        cboYear.Items.Add("2019")
        cboYear.Items.Add("2018")
        cboYear.Items.Add("2017")
        cboYear.Items.Add("2016")
        cboYear.Items.Add("2015")
        Dim strYear As String = currentDate.Year.ToString
        cboYear.SelectedItem = strYear

        cboSemester.Items.Add("Fall - YYYY10") ' YYYY10
        cboSemester.Items.Add("Spring - YYYY20") ' YYYY20 (Winter Term classes are classified as Spring)
        cboSemester.Items.Add("Summer - YYYY30") ' YYYY30


        ' Month index is 1 based
        ' Combo box index is 0 based
        If currentDate.Month < 4 Then
            cboSemester.SelectedIndex = 1 'Spring
        End If
        If currentDate.Month > 4 And currentDate.Month < 7 Then
            cboSemester.SelectedIndex = 2 'Summer
        End If
        If currentDate.Month > 7 Then
            cboSemester.SelectedIndex = 0 'Fall
        End If


        lblDescription.Text = strDescriptionBase
    End Sub

    Private Sub frmScanner_GotFocus(sender As Object, e As EventArgs) Handles Me.GotFocus
        txtClassName.SelectAll()
    End Sub
End Class
