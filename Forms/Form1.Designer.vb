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
        Me.lbBuildings = New System.Windows.Forms.ListBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.cmdDropOldID = New System.Windows.Forms.Button()
        Me.cmdMerge = New System.Windows.Forms.Button()
        Me.cmdUpdateLinks = New System.Windows.Forms.Button()
        Me.cmdCreateIntermediate = New System.Windows.Forms.Button()
        Me.lbOutput = New System.Windows.Forms.ListBox()
        Me.lbError = New System.Windows.Forms.ListBox()
        Me.cmdClose = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.cmdReset = New System.Windows.Forms.Button()
        Me.cmdEmpty = New System.Windows.Forms.Button()
        Me.cmdClearOutput = New System.Windows.Forms.Button()
        Me.cmdClearErrors = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtCurrentDatabase = New System.Windows.Forms.TextBox()
        Me.cmdCreateIntermediateDatabase = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'lbBuildings
        '
        Me.lbBuildings.FormattingEnabled = True
        Me.lbBuildings.Location = New System.Drawing.Point(16, 72)
        Me.lbBuildings.Name = "lbBuildings"
        Me.lbBuildings.Size = New System.Drawing.Size(247, 433)
        Me.lbBuildings.TabIndex = 0
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cmdDropOldID)
        Me.GroupBox1.Controls.Add(Me.cmdMerge)
        Me.GroupBox1.Controls.Add(Me.cmdUpdateLinks)
        Me.GroupBox1.Controls.Add(Me.cmdCreateIntermediate)
        Me.GroupBox1.Location = New System.Drawing.Point(270, 66)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(285, 225)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Process"
        '
        'cmdDropOldID
        '
        Me.cmdDropOldID.Location = New System.Drawing.Point(27, 82)
        Me.cmdDropOldID.Name = "cmdDropOldID"
        Me.cmdDropOldID.Size = New System.Drawing.Size(231, 23)
        Me.cmdDropOldID.TabIndex = 3
        Me.cmdDropOldID.Text = "Drop Original IDs"
        Me.cmdDropOldID.UseVisualStyleBackColor = True
        '
        'cmdMerge
        '
        Me.cmdMerge.Location = New System.Drawing.Point(27, 112)
        Me.cmdMerge.Name = "cmdMerge"
        Me.cmdMerge.Size = New System.Drawing.Size(231, 23)
        Me.cmdMerge.TabIndex = 2
        Me.cmdMerge.Text = "Merge to Main Database"
        Me.cmdMerge.UseVisualStyleBackColor = True
        '
        'cmdUpdateLinks
        '
        Me.cmdUpdateLinks.Location = New System.Drawing.Point(27, 52)
        Me.cmdUpdateLinks.Name = "cmdUpdateLinks"
        Me.cmdUpdateLinks.Size = New System.Drawing.Size(231, 23)
        Me.cmdUpdateLinks.TabIndex = 1
        Me.cmdUpdateLinks.Text = "Update Links"
        Me.cmdUpdateLinks.UseVisualStyleBackColor = True
        '
        'cmdCreateIntermediate
        '
        Me.cmdCreateIntermediate.Location = New System.Drawing.Point(27, 22)
        Me.cmdCreateIntermediate.Name = "cmdCreateIntermediate"
        Me.cmdCreateIntermediate.Size = New System.Drawing.Size(231, 23)
        Me.cmdCreateIntermediate.TabIndex = 0
        Me.cmdCreateIntermediate.Text = "Fill Intermediate Database"
        Me.cmdCreateIntermediate.UseVisualStyleBackColor = True
        '
        'lbOutput
        '
        Me.lbOutput.FormattingEnabled = True
        Me.lbOutput.Location = New System.Drawing.Point(562, 66)
        Me.lbOutput.Name = "lbOutput"
        Me.lbOutput.Size = New System.Drawing.Size(478, 212)
        Me.lbOutput.TabIndex = 2
        '
        'lbError
        '
        Me.lbError.FormattingEnabled = True
        Me.lbError.Location = New System.Drawing.Point(561, 293)
        Me.lbError.Name = "lbError"
        Me.lbError.Size = New System.Drawing.Size(479, 212)
        Me.lbError.TabIndex = 3
        '
        'cmdClose
        '
        Me.cmdClose.Location = New System.Drawing.Point(1055, 483)
        Me.cmdClose.Name = "cmdClose"
        Me.cmdClose.Size = New System.Drawing.Size(75, 23)
        Me.cmdClose.TabIndex = 4
        Me.cmdClose.Text = "Close"
        Me.cmdClose.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.cmdCreateIntermediateDatabase)
        Me.GroupBox2.Controls.Add(Me.cmdReset)
        Me.GroupBox2.Controls.Add(Me.cmdEmpty)
        Me.GroupBox2.Location = New System.Drawing.Point(270, 303)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(285, 202)
        Me.GroupBox2.TabIndex = 5
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Database"
        '
        'cmdReset
        '
        Me.cmdReset.Location = New System.Drawing.Point(27, 103)
        Me.cmdReset.Name = "cmdReset"
        Me.cmdReset.Size = New System.Drawing.Size(231, 23)
        Me.cmdReset.TabIndex = 2
        Me.cmdReset.Text = "Reset Intermediate Database"
        Me.cmdReset.UseVisualStyleBackColor = True
        '
        'cmdEmpty
        '
        Me.cmdEmpty.Location = New System.Drawing.Point(27, 74)
        Me.cmdEmpty.Name = "cmdEmpty"
        Me.cmdEmpty.Size = New System.Drawing.Size(231, 23)
        Me.cmdEmpty.TabIndex = 1
        Me.cmdEmpty.Text = "Empty Intermediate Database"
        Me.cmdEmpty.UseVisualStyleBackColor = True
        '
        'cmdClearOutput
        '
        Me.cmdClearOutput.Location = New System.Drawing.Point(1059, 66)
        Me.cmdClearOutput.Name = "cmdClearOutput"
        Me.cmdClearOutput.Size = New System.Drawing.Size(75, 23)
        Me.cmdClearOutput.TabIndex = 6
        Me.cmdClearOutput.Text = "Clear"
        Me.cmdClearOutput.UseVisualStyleBackColor = True
        '
        'cmdClearErrors
        '
        Me.cmdClearErrors.Location = New System.Drawing.Point(1059, 293)
        Me.cmdClearErrors.Name = "cmdClearErrors"
        Me.cmdClearErrors.Size = New System.Drawing.Size(75, 23)
        Me.cmdClearErrors.TabIndex = 7
        Me.cmdClearErrors.Text = "Clear"
        Me.cmdClearErrors.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(22, 29)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(101, 13)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "Selected Database"
        '
        'txtCurrentDatabase
        '
        Me.txtCurrentDatabase.Enabled = False
        Me.txtCurrentDatabase.Location = New System.Drawing.Point(129, 26)
        Me.txtCurrentDatabase.Name = "txtCurrentDatabase"
        Me.txtCurrentDatabase.Size = New System.Drawing.Size(399, 22)
        Me.txtCurrentDatabase.TabIndex = 9
        '
        'cmdCreateIntermediateDatabase
        '
        Me.cmdCreateIntermediateDatabase.Location = New System.Drawing.Point(27, 45)
        Me.cmdCreateIntermediateDatabase.Name = "cmdCreateIntermediateDatabase"
        Me.cmdCreateIntermediateDatabase.Size = New System.Drawing.Size(231, 23)
        Me.cmdCreateIntermediateDatabase.TabIndex = 3
        Me.cmdCreateIntermediateDatabase.Text = "Create Intermediate Database"
        Me.cmdCreateIntermediateDatabase.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1142, 518)
        Me.Controls.Add(Me.txtCurrentDatabase)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cmdClearErrors)
        Me.Controls.Add(Me.cmdClearOutput)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.cmdClose)
        Me.Controls.Add(Me.lbError)
        Me.Controls.Add(Me.lbOutput)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.lbBuildings)
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "CentrePro Data Integration Tool"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lbBuildings As ListBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents lbOutput As ListBox
    Friend WithEvents lbError As ListBox
    Friend WithEvents cmdClose As Button
    Friend WithEvents cmdCreateIntermediate As Button
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents cmdReset As Button
    Friend WithEvents cmdEmpty As Button
    Friend WithEvents cmdMerge As Button
    Friend WithEvents cmdUpdateLinks As Button
    Friend WithEvents cmdDropOldID As Button
    Friend WithEvents cmdClearOutput As Button
    Friend WithEvents cmdClearErrors As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents txtCurrentDatabase As TextBox
    Friend WithEvents cmdCreateIntermediateDatabase As Button
End Class
