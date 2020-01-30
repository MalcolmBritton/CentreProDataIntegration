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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.lbBuildings = New System.Windows.Forms.ListBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.cmdDropRecreateStage2 = New System.Windows.Forms.Button()
        Me.cmdCopyToStage2Database = New System.Windows.Forms.Button()
        Me.cmdDropOldID = New System.Windows.Forms.Button()
        Me.cmdEmptyStage1 = New System.Windows.Forms.Button()
        Me.cmdMerge = New System.Windows.Forms.Button()
        Me.cmdUpdateLinks = New System.Windows.Forms.Button()
        Me.cmdFillStage1 = New System.Windows.Forms.Button()
        Me.lbOutput = New System.Windows.Forms.ListBox()
        Me.lbError = New System.Windows.Forms.ListBox()
        Me.cmdClose = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.cmdDropDatabase = New System.Windows.Forms.Button()
        Me.cmdCreateIntermediateDatabase = New System.Windows.Forms.Button()
        Me.cmdReset = New System.Windows.Forms.Button()
        Me.cmdClearOutput = New System.Windows.Forms.Button()
        Me.cmdClearErrors = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtCurrentDatabase = New System.Windows.Forms.TextBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'lbBuildings
        '
        Me.lbBuildings.FormattingEnabled = True
        Me.lbBuildings.Location = New System.Drawing.Point(16, 72)
        Me.lbBuildings.Name = "lbBuildings"
        Me.lbBuildings.Size = New System.Drawing.Size(247, 238)
        Me.lbBuildings.TabIndex = 0
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cmdDropRecreateStage2)
        Me.GroupBox1.Controls.Add(Me.cmdCopyToStage2Database)
        Me.GroupBox1.Controls.Add(Me.cmdDropOldID)
        Me.GroupBox1.Controls.Add(Me.cmdEmptyStage1)
        Me.GroupBox1.Controls.Add(Me.cmdMerge)
        Me.GroupBox1.Controls.Add(Me.cmdUpdateLinks)
        Me.GroupBox1.Controls.Add(Me.cmdFillStage1)
        Me.GroupBox1.Location = New System.Drawing.Point(270, 66)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(285, 250)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Process"
        '
        'cmdDropRecreateStage2
        '
        Me.cmdDropRecreateStage2.Location = New System.Drawing.Point(27, 174)
        Me.cmdDropRecreateStage2.Name = "cmdDropRecreateStage2"
        Me.cmdDropRecreateStage2.Size = New System.Drawing.Size(231, 23)
        Me.cmdDropRecreateStage2.TabIndex = 5
        Me.cmdDropRecreateStage2.Text = "Drop and ReCreate Stage 2 Database"
        Me.cmdDropRecreateStage2.UseVisualStyleBackColor = True
        '
        'cmdCopyToStage2Database
        '
        Me.cmdCopyToStage2Database.Location = New System.Drawing.Point(27, 86)
        Me.cmdCopyToStage2Database.Name = "cmdCopyToStage2Database"
        Me.cmdCopyToStage2Database.Size = New System.Drawing.Size(231, 23)
        Me.cmdCopyToStage2Database.TabIndex = 4
        Me.cmdCopyToStage2Database.Text = "Copy to Stage 2 Database"
        Me.cmdCopyToStage2Database.UseVisualStyleBackColor = True
        '
        'cmdDropOldID
        '
        Me.cmdDropOldID.Location = New System.Drawing.Point(27, 115)
        Me.cmdDropOldID.Name = "cmdDropOldID"
        Me.cmdDropOldID.Size = New System.Drawing.Size(231, 23)
        Me.cmdDropOldID.TabIndex = 3
        Me.cmdDropOldID.Text = "Drop Original IDs (Stage 2)"
        Me.cmdDropOldID.UseVisualStyleBackColor = True
        '
        'cmdEmptyStage1
        '
        Me.cmdEmptyStage1.Location = New System.Drawing.Point(27, 201)
        Me.cmdEmptyStage1.Name = "cmdEmptyStage1"
        Me.cmdEmptyStage1.Size = New System.Drawing.Size(231, 23)
        Me.cmdEmptyStage1.TabIndex = 1
        Me.cmdEmptyStage1.Text = "Empty Stage 1 Database"
        Me.cmdEmptyStage1.UseVisualStyleBackColor = True
        '
        'cmdMerge
        '
        Me.cmdMerge.Location = New System.Drawing.Point(27, 145)
        Me.cmdMerge.Name = "cmdMerge"
        Me.cmdMerge.Size = New System.Drawing.Size(231, 23)
        Me.cmdMerge.TabIndex = 2
        Me.cmdMerge.Text = "Merge to Main Database (Stage 2)"
        Me.cmdMerge.UseVisualStyleBackColor = True
        '
        'cmdUpdateLinks
        '
        Me.cmdUpdateLinks.Location = New System.Drawing.Point(27, 57)
        Me.cmdUpdateLinks.Name = "cmdUpdateLinks"
        Me.cmdUpdateLinks.Size = New System.Drawing.Size(231, 23)
        Me.cmdUpdateLinks.TabIndex = 1
        Me.cmdUpdateLinks.Text = "Update Links Stage 1"
        Me.cmdUpdateLinks.UseVisualStyleBackColor = True
        '
        'cmdFillStage1
        '
        Me.cmdFillStage1.Location = New System.Drawing.Point(27, 27)
        Me.cmdFillStage1.Name = "cmdFillStage1"
        Me.cmdFillStage1.Size = New System.Drawing.Size(231, 23)
        Me.cmdFillStage1.TabIndex = 0
        Me.cmdFillStage1.Text = "Fill Stage 1 Database"
        Me.cmdFillStage1.UseVisualStyleBackColor = True
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
        Me.GroupBox2.Controls.Add(Me.cmdDropDatabase)
        Me.GroupBox2.Controls.Add(Me.cmdCreateIntermediateDatabase)
        Me.GroupBox2.Controls.Add(Me.cmdReset)
        Me.GroupBox2.Location = New System.Drawing.Point(270, 317)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(285, 188)
        Me.GroupBox2.TabIndex = 5
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Database"
        '
        'cmdDropDatabase
        '
        Me.cmdDropDatabase.Location = New System.Drawing.Point(27, 54)
        Me.cmdDropDatabase.Name = "cmdDropDatabase"
        Me.cmdDropDatabase.Size = New System.Drawing.Size(231, 23)
        Me.cmdDropDatabase.TabIndex = 4
        Me.cmdDropDatabase.Text = "Drop Stage1 Database"
        Me.cmdDropDatabase.UseVisualStyleBackColor = True
        '
        'cmdCreateIntermediateDatabase
        '
        Me.cmdCreateIntermediateDatabase.Location = New System.Drawing.Point(27, 83)
        Me.cmdCreateIntermediateDatabase.Name = "cmdCreateIntermediateDatabase"
        Me.cmdCreateIntermediateDatabase.Size = New System.Drawing.Size(231, 23)
        Me.cmdCreateIntermediateDatabase.TabIndex = 3
        Me.cmdCreateIntermediateDatabase.Text = "Create Stage 1 Database"
        Me.cmdCreateIntermediateDatabase.UseVisualStyleBackColor = True
        '
        'cmdReset
        '
        Me.cmdReset.Location = New System.Drawing.Point(27, 112)
        Me.cmdReset.Name = "cmdReset"
        Me.cmdReset.Size = New System.Drawing.Size(231, 23)
        Me.cmdReset.TabIndex = 2
        Me.cmdReset.Text = "Reset Stage 1 Database"
        Me.cmdReset.UseVisualStyleBackColor = True
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
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.TextBox1)
        Me.GroupBox3.Location = New System.Drawing.Point(16, 317)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(247, 188)
        Me.GroupBox3.TabIndex = 10
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Process"
        '
        'TextBox1
        '
        Me.TextBox1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.TextBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBox1.Location = New System.Drawing.Point(3, 18)
        Me.TextBox1.Multiline = True
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.ReadOnly = True
        Me.TextBox1.Size = New System.Drawing.Size(241, 167)
        Me.TextBox1.TabIndex = 0
        Me.TextBox1.Text = resources.GetString("TextBox1.Text")
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1142, 518)
        Me.Controls.Add(Me.GroupBox3)
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
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lbBuildings As ListBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents lbOutput As ListBox
    Friend WithEvents lbError As ListBox
    Friend WithEvents cmdClose As Button
    Friend WithEvents cmdFillStage1 As Button
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents cmdReset As Button
    Friend WithEvents cmdEmptyStage1 As Button
    Friend WithEvents cmdMerge As Button
    Friend WithEvents cmdUpdateLinks As Button
    Friend WithEvents cmdDropOldID As Button
    Friend WithEvents cmdClearOutput As Button
    Friend WithEvents cmdClearErrors As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents txtCurrentDatabase As TextBox
    Friend WithEvents cmdCreateIntermediateDatabase As Button
    Friend WithEvents cmdDropDatabase As Button
    Friend WithEvents cmdCopyToStage2Database As Button
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents cmdDropRecreateStage2 As Button
End Class
