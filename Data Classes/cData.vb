Public Class cData

    ' commented code as aide memoir only on how to write the data access procedures - One save and one read and one insert!

    'Public Shared Function GetJobList(Optional bOpenOnly As Boolean = True) As rJobItems

    '    Dim rJobItem As rJobItem
    '    Dim rJobItems As New rJobItems
    '    Dim SQLString As String

    '    SQLString = "SELECT * FROM vwJobItems_OUTPUT "
    '    If bOpenOnly = True Then
    '        SQLString = SQLString & "WHERE [Job Status] <> 'Closed' "
    '    End If
    '    SQLString = SQLString & "ORDER BY [Date Created] DESC, [Job Number] DESC"

    '    Using connection As SqlConnection = DBConnection.GetConnection

    '        connection.Open()

    '        Using cmd As New SqlCommand(SQLString, connection)

    '            Using reader As SqlDataReader = cmd.ExecuteReader

    '                If reader.HasRows Then

    '                    Do While reader.Read

    '                        rJobItem = New rJobItem

    '                        With rJobItem
    '                            .ID = reader("ID")
    '                            .Building = reader("Building").trim
    '                            .JobNumber = NotNull(reader("Job Number"), 0)
    '                            .Client = NotNull(reader("Client").ToString.Trim, "")
    '                            .Unit = NotNull(reader("Unit").ToString.Trim, "")
    '                            .JobType = NotNull(reader("Job Type").ToString.Trim, "")
    '                            .Creator = NotNull(reader("Creator").ToString.Trim, "")
    '                            .Owner = NotNull(reader("Owner").ToString.Trim, "")
    '                            .Allocated = NotNull(reader("Allocated"), "")
    '                            .DateCreated = NotNull(reader("Date Created"), Nothing)
    '                            .DateReported = NotNull(reader("Date Reported"), Nothing)
    '                            .DateResolved = NotNull(reader("Date Resolved"), Nothing)
    '                            .ReportedBy = NotNull(reader("Reported By").ToString.Trim, "")
    '                            .JobStatus = NotNull(reader("Job Status").ToString.Trim, "")
    '                            .JobPriority = NotNull(reader("Job Priority").ToString.Trim, "")
    '                            .Narrative = NotNull(reader("Narrative").ToString.Trim, "")
    '                            .Chargeable = SQLBitToBoolean(reader("Chargeable"))
    '                            .DateDue = NotNull(reader("Date Due"), Nothing)
    '                            .Urgent = SQLBitToBoolean(reader("Urgent"))
    '                            .UnattendedAccess = SQLBitToBoolean(reader("Unattended Access"))
    '                            rJobItems.Add(rJobItem)
    '                        End With
    '                    Loop

    '                End If

    '            End Using ' reader

    '        End Using ' cmd

    '    End Using ' connection

    '    Return rJobItems

    'End Function

    'Public Shared Function SaveJobItemHistory(JIH As JobItemHistory) As Integer

    '    ' Save JobItemHistory record and return the ID

    '    Using connection As SqlConnection = DBConnection.GetConnection

    '        connection.Open()

    '        Using cmd As New SqlCommand("spSaveJobItemHistory", connection)
    '            cmd.CommandType = CommandType.StoredProcedure
    '            ' Add parameter(s) 
    '            cmd.Parameters.AddWithValue("@ID", NotNull(JIH.ID, 0))
    '            cmd.Parameters.AddWithValue("@TypeID", NotNull(JIH.TypeID, 1))      'Default is System Generated
    '            cmd.Parameters.AddWithValue("@DateCreated", NotNull(JIH.DateCreated, Date.MinValue))
    '            cmd.Parameters.AddWithValue("@DateActioned", NotNull(JIH.DateActioned, Date.MinValue))
    '            cmd.Parameters.AddWithValue("@CreatorID", NotNull(JIH.CreatedByID, 0))
    '            cmd.Parameters.AddWithValue("@JobHeaderID", NotNull(JIH.JobHeaderID, 0))
    '            cmd.Parameters.AddWithValue("@JobItemID", NotNull(JIH.JobItemID, 0))
    '            cmd.Parameters.AddWithValue("@Narrative", NotNull(JIH.Narrative, ""))
    '            cmd.Parameters.AddWithValue("@TimeSpent", NotNull(JIH.TimeSpent, 0))
    '            If JIH.TypeID = 1 Then
    '                cmd.Parameters.AddWithValue("@ActionedByID", NotNull(JIH.CreatedByID, 0))
    '            Else
    '                cmd.Parameters.AddWithValue("@ActionedByID", NotNull(JIH.ActionedByID, 0))
    '            End If

    '            ' Job Record State Fields - Alex Brewer 28/10/2019
    '            cmd.Parameters.AddWithValue("@JobTypeState", NotNull(JIH.JobStateRecord.JobTypeState, ""))
    '            cmd.Parameters.AddWithValue("@JobPriorityState", NotNull(JIH.JobStateRecord.JobPriorityState, ""))
    '            cmd.Parameters.AddWithValue("@JobStatusState", NotNull(JIH.JobStateRecord.JobStatusState, ""))
    '            cmd.Parameters.AddWithValue("@AllocatedToState", NotNull(JIH.JobStateRecord.AllocatedToState, ""))
    '            cmd.Parameters.AddWithValue("@UAAllowedState", NotNull(JIH.JobStateRecord.UAAllowedState, ""))
    '            cmd.Parameters.AddWithValue("@ChargeableState", NotNull(JIH.JobStateRecord.ChargeableState, ""))
    '            cmd.Parameters.AddWithValue("@SubConState", NotNull(JIH.JobStateRecord.SubConState, ""))
    '            cmd.Parameters.AddWithValue("@ProjectRefState", NotNull(JIH.JobStateRecord.ProjectRefState, ""))

    '            ' Return Value
    '            cmd.Parameters.Add("@ReturnID", SqlDbType.Int)
    '            cmd.Parameters("@ReturnID").Direction = ParameterDirection.Output
    '            ' Execute the stored procedure
    '            Try
    '                cmd.ExecuteNonQuery()
    '                Return cmd.Parameters("@ReturnID").Value
    '            Catch ex As Exception
    '                Return 0
    '            End Try

    '        End Using ' cmd

    '    End Using ' connection

    'End Function

    'Public Shared Function AddSubcontractor(Description As String)

    '    Dim SQLupdate As String = "Insert Into SubContractors(Description) VALUES ('" & Description & "')"

    '    Using connection As SqlConnection = DBConnection.GetConnection

    '        connection.Open()

    '        Try
    '            Using cmdUpdate As New SqlCommand(SQLupdate, connection)
    '                cmdUpdate.ExecuteNonQuery()
    '            End Using 'cmdUpdate
    '            Return True
    '        Catch ex As Exception
    '            Return False
    '        End Try

    '    End Using 'connection

    'End Function

    Public Shared Function GetTableNames() As List(Of String)

        Dim tn As New List(Of String)
        Dim SQLstring As String

        SQLstring = "SELECT name FROM sysobjects WHERE xtype = 'U' order by name"

        Using connection As SqlConnection = DBConnection.GetConnectionIntermediate

            connection.Open()

            Using cmd As New SqlCommand(SQLstring, connection)

                Using reader As SqlDataReader = cmd.ExecuteReader

                    If reader.HasRows Then

                        tn = New List(Of String)

                        Do While reader.Read
                            tn.Add(reader("name"))
                        Loop

                    End If

                End Using ' reader

            End Using ' cmd

        End Using ' connection

        Return tn

    End Function

    Public Shared Function EmptyIntermediateDatabase(Optional reseed As Boolean = False)

        Dim tableNames As List(Of String) = GetTableNames()

        If tableNames.Count > 0 Then

            For Each tn As String In tableNames
                ResetTable(tn, reseed)
            Next

        End If

    End Function

    Public Shared Function HasIdentityColumn(tableName As String) As Integer

        Dim bRetVal As Integer

        Dim SQLString As String = "SELECT Count(Column_ID) FROM sys.identity_columns WHERE OBJECT_NAME(object_id) = '" & tableName & "'"

        Using connection As SqlConnection = DBConnection.GetConnectionIntermediate

            connection.Open()

            Using cmd As New SqlCommand(SQLString, connection)

                bRetVal = cmd.ExecuteScalar

            End Using ' cmd

        End Using ' connection

        Return bRetVal

    End Function

    Public Shared Function ImportTableToIntermediate(sTableName As String, BuildingID As Integer, sourceDB As String)

        Dim SQLUpdate As String = String.Empty

        Select Case HasIdentityColumn(sTableName)
            Case 1
                SQLUpdate = "SET IDENTITY_INSERT " & sTableName & " OFF "
                SQLUpdate &= "INSERT INTO " & sTableName & " SELECT " & BuildingID.ToString & ", * FROM " & sourceDB & ".dbo." & sTableName
                SQLUpdate &= " SET IDENTITY_INSERT " & sTableName & " ON "
            Case 0
                SQLUpdate = "INSERT INTO " & sTableName & " SELECT " & BuildingID.ToString & ", * FROM " & sourceDB & ".dbo." & sTableName
        End Select

        Using connection As SqlConnection = DBConnection.GetConnectionIntermediate

            connection.Open()

            Try
                Using cmdUpdate As New SqlCommand(SQLupdate, connection)
                    cmdUpdate.ExecuteNonQuery()
                End Using 'cmdUpdate
                Return True
            Catch ex As Exception
                Return False
            End Try

        End Using 'connection
    End Function

    Public Shared Function Truncate(sTableName As String) As String

        ' Using Delete instead of truncate to retain the identity counter if requested
        Dim sql As String = "DELETE FROM " & sTableName
        Return sql

    End Function

    Public Shared Function ResetIdent(sTablename As String, Optional Seed As Integer = 0) As String

        Dim sql As String = "DBCC CHECKIDENT (" & sTablename & ", RESEED," & Seed.ToString & ")"
        Return sql

    End Function

    Public Shared Function ResetTable(sTableName As String, Optional ResetIdentity As Boolean = True) As Boolean

        Using connection As SqlConnection = DBConnection.GetConnectionIntermediate

            connection.Open()

            Using cmd As New SqlCommand(Truncate(sTableName), connection)
                Try
                    cmd.ExecuteNonQuery()
                    If ResetIdentity = True Then
                        cmd.CommandText = ResetIdent(sTableName)
                        cmd.ExecuteNonQuery()
                    End If
                    Return True
                Catch ex As Exception
                    Return False
                End Try
            End Using

        End Using

    End Function

End Class
