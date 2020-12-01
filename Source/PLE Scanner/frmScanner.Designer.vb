<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmScanner
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmScanner))
        Me.lblDescription = New System.Windows.Forms.Label()
        Me.txtClassName = New System.Windows.Forms.TextBox()
        Me.lblClassName = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnExecute = New System.Windows.Forms.Button()
        Me.btnViewScanResults = New System.Windows.Forms.Button()
        Me.cboYear = New System.Windows.Forms.ComboBox()
        Me.cboSemester = New System.Windows.Forms.ComboBox()
        Me.lblSemeser = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'lblDescription
        '
        Me.lblDescription.Location = New System.Drawing.Point(10, 15)
        Me.lblDescription.Name = "lblDescription"
        Me.lblDescription.Size = New System.Drawing.Size(288, 33)
        Me.lblDescription.TabIndex = 0
        Me.lblDescription.Text = "This tool will assist with forming the URL's necessary for inserting QA tables in" &
    "to PLE"
        '
        'txtClassName
        '
        Me.txtClassName.Location = New System.Drawing.Point(102, 51)
        Me.txtClassName.Name = "txtClassName"
        Me.txtClassName.Size = New System.Drawing.Size(128, 20)
        Me.txtClassName.TabIndex = 1
        '
        'lblClassName
        '
        Me.lblClassName.AutoSize = True
        Me.lblClassName.Location = New System.Drawing.Point(30, 54)
        Me.lblClassName.Name = "lblClassName"
        Me.lblClassName.Size = New System.Drawing.Size(66, 13)
        Me.lblClassName.TabIndex = 2
        Me.lblClassName.Text = "Class Name:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(36, 88)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(60, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Class Year:"
        '
        'btnExecute
        '
        Me.btnExecute.Location = New System.Drawing.Point(33, 169)
        Me.btnExecute.Name = "btnExecute"
        Me.btnExecute.Size = New System.Drawing.Size(105, 33)
        Me.btnExecute.TabIndex = 5
        Me.btnExecute.Text = "&Execute Job"
        Me.btnExecute.UseVisualStyleBackColor = True
        '
        'btnViewScanResults
        '
        Me.btnViewScanResults.Location = New System.Drawing.Point(144, 169)
        Me.btnViewScanResults.Name = "btnViewScanResults"
        Me.btnViewScanResults.Size = New System.Drawing.Size(110, 33)
        Me.btnViewScanResults.TabIndex = 6
        Me.btnViewScanResults.Text = "&View QA Page"
        Me.btnViewScanResults.UseVisualStyleBackColor = True
        '
        'cboYear
        '
        Me.cboYear.FormattingEnabled = True
        Me.cboYear.Location = New System.Drawing.Point(102, 85)
        Me.cboYear.Name = "cboYear"
        Me.cboYear.Size = New System.Drawing.Size(128, 21)
        Me.cboYear.TabIndex = 7
        '
        'cboSemester
        '
        Me.cboSemester.FormattingEnabled = True
        Me.cboSemester.Location = New System.Drawing.Point(102, 119)
        Me.cboSemester.Name = "cboSemester"
        Me.cboSemester.Size = New System.Drawing.Size(128, 21)
        Me.cboSemester.TabIndex = 8
        '
        'lblSemeser
        '
        Me.lblSemeser.AutoSize = True
        Me.lblSemeser.Location = New System.Drawing.Point(14, 122)
        Me.lblSemeser.Name = "lblSemeser"
        Me.lblSemeser.Size = New System.Drawing.Size(82, 13)
        Me.lblSemeser.TabIndex = 9
        Me.lblSemeser.Text = "Class Semester:"
        '
        'frmScanner
        '
        Me.AcceptButton = Me.btnExecute
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(285, 220)
        Me.Controls.Add(Me.lblSemeser)
        Me.Controls.Add(Me.cboSemester)
        Me.Controls.Add(Me.cboYear)
        Me.Controls.Add(Me.btnViewScanResults)
        Me.Controls.Add(Me.btnExecute)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.lblClassName)
        Me.Controls.Add(Me.txtClassName)
        Me.Controls.Add(Me.lblDescription)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmScanner"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "PLE QA Scanner"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lblDescription As Label
    Friend WithEvents txtClassName As TextBox
    Friend WithEvents lblClassName As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents btnExecute As Button
    Friend WithEvents btnViewScanResults As Button
    Friend WithEvents cboYear As ComboBox
    Friend WithEvents cboSemester As ComboBox
    Friend WithEvents lblSemeser As Label
End Class
