Imports System.IO

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

    Public Shared Function UpdateAssetTypesIds() As cMultiValueReturn

        Dim SQLstring As String = ""
        Dim SQLUpdate As String = ""
        Dim RowsAffected As Integer
        Dim Retval As New cMultiValueReturn

        ' ID is the original old ID from the local database
        SQLstring = "SELECT NewID, ID FROM AssetTypes"

        Using connection As SqlConnection = DBConnection.GetConnectionIntermediate

            connection.Open()

            Using cmd As New SqlCommand(SQLstring, connection)

                Using reader As SqlDataReader = cmd.ExecuteReader

                    If reader.HasRows Then

                        Do While reader.Read

                            ' update related table data here
                            ' AssetGroupTypes
                            SQLUpdate = "UPDATE AssetGroupTypes SET AssetTypeID = " & reader("NewID").ToString & " WHERE AssetTypeID = " & reader("ID").ToString
                            Using cmdUpdate As New SqlCommand(SQLUpdate, connection)
                                Try
                                    RowsAffected = cmdUpdate.ExecuteNonQuery()
                                    'If RowsAffected > 0 Then
                                    'Retval.PassedHistory.Items.Add("Updated ID Fields AssetTypes/AssetGroupTypes " & reader("ID").ToString & "/" & reader("NewID").ToString)
                                    'End If
                                Catch ex As Exception
                                    Retval.FailedHistory.Items.Add("Update ID Fields AssetTypes/AssetGroupTypes FAILED " & reader("ID").ToString & "/" & reader("NewID").ToString)
                                    Retval.OverallResult = False
                                End Try
                                'End Using 'cmdUpdate

                                ' Assets
                                SQLUpdate = "UPDATE Assets SET AssetTypeID = " & reader("NewID").ToString & " WHERE AssetTypeID = " & reader("ID").ToString
                                'Using cmdUpdate As New SqlCommand(SQLUpdate, connection)
                                cmdUpdate.CommandText = SQLUpdate
                                Try
                                    RowsAffected = cmdUpdate.ExecuteNonQuery()
                                    'If RowsAffected > 0 Then
                                    '    Retval.PassedHistory.Items.Add("Updated ID Fields AssetTypes/Assets " & reader("ID").ToString & "/" & reader("NewID").ToString)
                                    'End If
                                Catch ex As Exception
                                    Retval.FailedHistory.Items.Add("Update ID Fields AssetTypes/Assets FAILED " & reader("ID").ToString & "/" & reader("NewID").ToString)
                                    Retval.OverallResult = False
                                End Try
                            End Using 'cmdUpdate

                        Loop

                    End If

                End Using ' reader

            End Using ' cmd

        End Using ' connection

        Return Retval


    End Function

    Public Shared Function UpdateAssetGroupsIds() As cMultiValueReturn

        Dim SQLstring As String = ""
        Dim SQLUpdate As String = ""
        Dim RowsAffected As Integer
        Dim Retval As New cMultiValueReturn

        ' ID is the original old ID from the local database
        SQLstring = "SELECT NewID, ID FROM AssetGroups"

        Using connection As SqlConnection = DBConnection.GetConnectionIntermediate

            connection.Open()

            Using cmd As New SqlCommand(SQLstring, connection)

                Using reader As SqlDataReader = cmd.ExecuteReader

                    If reader.HasRows Then

                        Do While reader.Read

                            ' update related table data here
                            ' AssetGroupTypes
                            SQLUpdate = "UPDATE AssetGroupTypes SET AssetGroupID = " & reader("NewID").ToString & " WHERE AssetGroupID = " & reader("ID").ToString
                            Using cmdUpdate As New SqlCommand(SQLUpdate, connection)
                                Try
                                    RowsAffected = cmdUpdate.ExecuteNonQuery()
                                    'If RowsAffected > 0 Then
                                    '    Retval.PassedHistory.Items.Add("Updated ID Fields AssetGroups/AssetGroupTypes " & reader("ID").ToString & "/" & reader("NewID").ToString)
                                    'End If
                                Catch ex As Exception
                                    Retval.FailedHistory.Items.Add("Update ID Fields AssetGroups/AssetGroupTypes FAILED " & reader("ID").ToString & "/" & reader("NewID").ToString)
                                    Retval.OverallResult = False
                                End Try
                                'End Using 'cmdUpdate

                                ' AssetTypes
                                SQLUpdate = "UPDATE AssetTypes SET GroupID = " & reader("NewID").ToString & " WHERE GroupID = " & reader("ID").ToString
                                'Using cmdUpdate As New SqlCommand(SQLUpdate, connection)
                                cmdUpdate.CommandText = SQLUpdate
                                Try
                                    RowsAffected = cmdUpdate.ExecuteNonQuery()
                                    'If RowsAffected > 0 Then
                                    '    Retval.PassedHistory.Items.Add("Updated ID Fields AssetGroups/AssetTypes " & reader("ID").ToString & "/" & reader("NewID").ToString)
                                    'End If
                                Catch ex As Exception
                                    Retval.FailedHistory.Items.Add("Update ID Fields AssetGroups/AssetTypes FAILED " & reader("ID").ToString & "/" & reader("NewID").ToString)
                                    Retval.OverallResult = False
                                End Try
                            End Using 'cmdUpdate

                        Loop

                    End If

                End Using ' reader

            End Using ' cmd

        End Using ' connection

        Return Retval

    End Function

    Public Shared Function UpdateActionsIDs() As cMultiValueReturn

        Dim SQLstring As String = ""
        Dim SQLUpdate As String = ""
        Dim RowsAffected As Integer
        Dim Retval As New cMultiValueReturn

        ' ID is the original old ID from the local database
        SQLstring = "SELECT NewID, ID FROM Actions"

        Using connection As SqlConnection = DBConnection.GetConnectionIntermediate

            connection.Open()

            Using cmd As New SqlCommand(SQLstring, connection)

                Using reader As SqlDataReader = cmd.ExecuteReader

                    If reader.HasRows Then

                        Do While reader.Read

                            ' update related table data here
                            ' FrontDeskNoteActions
                            SQLUpdate = "UPDATE FrontDeskNoteActions SET ActionID = " & reader("NewID").ToString & " WHERE ActionID = " & reader("ID").ToString
                            Using cmdUpdate As New SqlCommand(SQLUpdate, connection)
                                Try
                                    RowsAffected = cmdUpdate.ExecuteNonQuery()
                                    'If RowsAffected > 0 Then
                                    '    Retval.PassedHistory.Items.Add("Updated ID Fields Actions/FrontDeskNoteActions " & reader("ID").ToString & "/" & reader("NewID").ToString)
                                    'End If
                                Catch ex As Exception
                                    Retval.FailedHistory.Items.Add("Update ID Fields Actions/FrontDeskNoteActions FAILED " & reader("ID").ToString & "/" & reader("NewID").ToString)
                                    Retval.OverallResult = False
                                End Try
                            End Using 'cmdUpdate

                        Loop

                    End If

                End Using ' reader

            End Using ' cmd

        End Using ' connection

        Return Retval

    End Function

    Public Shared Function UpdateAccommodationIDs() As cMultiValueReturn

        Dim SQLstring As String = ""
        Dim SQLUpdate As String = ""
        Dim RowsAffected As Integer
        Dim Retval As New cMultiValueReturn

        ' ID is the original old ID from the local database
        SQLstring = "SELECT NewID, ID FROM Accommodations"

        Using connection As SqlConnection = DBConnection.GetConnectionIntermediate

            connection.Open()

            Using cmd As New SqlCommand(SQLstring, connection)

                Using reader As SqlDataReader = cmd.ExecuteReader

                    If reader.HasRows Then

                        Do While reader.Read

                            ' update related table data here
                            ' Assets
                            SQLUpdate = "UPDATE Assets SET LocationID = " & reader("NewID").ToString & " WHERE LocationID = " & reader("ID").ToString
                            Using cmdUpdate As New SqlCommand(SQLUpdate, connection)
                                Try
                                    RowsAffected = cmdUpdate.ExecuteNonQuery()
                                    'If RowsAffected > 0 Then
                                    '    Retval.PassedHistory.Items.Add("Updated ID Fields Accommodation/Assets " & reader("ID").ToString & "/" & reader("NewID").ToString)
                                    'End If
                                Catch ex As Exception
                                    Retval.FailedHistory.Items.Add("Update ID Fields Accommodation/Assets FAILED " & reader("ID").ToString & "/" & reader("NewID").ToString)
                                    Retval.OverallResult = False
                                End Try
                                'End Using 'cmdUpdate

                                ' CalendarRooms
                                SQLUpdate = "UPDATE CalendarRooms SET RoomID = " & reader("NewID").ToString & " WHERE RoomID = " & reader("ID").ToString
                                'Using cmdUpdate As New SqlCommand(SQLUpdate, connection)
                                cmdUpdate.CommandText = SQLUpdate
                                Try
                                    RowsAffected = cmdUpdate.ExecuteNonQuery()
                                    'If RowsAffected > 0 Then
                                    '    Retval.PassedHistory.Items.Add("Updated ID Fields Accommodation/CalendarRooms " & reader("ID").ToString & "/" & reader("NewID").ToString)
                                    'End If
                                Catch ex As Exception
                                    Retval.FailedHistory.Items.Add("Update ID Fields Accommodation/CalendarRooms FAILED " & reader("ID").ToString & "/" & reader("NewID").ToString)
                                    Retval.OverallResult = False
                                End Try
                                'End Using 'cmdUpdate

                                ' LicenceRooms
                                SQLUpdate = "UPDATE LicenceRooms SET AccommodationID = " & reader("NewID").ToString & " WHERE AccommodationID = " & reader("ID").ToString
                                'Using cmdUpdate As New SqlCommand(SQLUpdate, connection)
                                cmdUpdate.CommandText = SQLUpdate
                                Try
                                    RowsAffected = cmdUpdate.ExecuteNonQuery()
                                    'If RowsAffected > 0 Then
                                    '    Retval.PassedHistory.Items.Add("Updated ID Fields Accommodation/LicenceRooms " & reader("ID").ToString & "/" & reader("NewID").ToString)
                                    'End If
                                Catch ex As Exception
                                    Retval.FailedHistory.Items.Add("Update ID Fields Accommodation/LicenceRooms FAILED " & reader("ID").ToString & "/" & reader("NewID").ToString)
                                    Retval.OverallResult = False
                                End Try
                                'End Using 'cmdUpdate

                                ' LicenceTaperHeader
                                SQLUpdate = "UPDATE LicenceTaperHeader SET RoomID = " & reader("NewID").ToString & " WHERE RoomID = " & reader("ID").ToString
                                'Using cmdUpdate As New SqlCommand(SQLUpdate, connection)
                                cmdUpdate.CommandText = SQLUpdate
                                Try
                                    RowsAffected = cmdUpdate.ExecuteNonQuery()
                                    'If RowsAffected > 0 Then
                                    '    Retval.PassedHistory.Items.Add("Updated ID Fields Accommodation/LicenceTaperHeader " & reader("ID").ToString & "/" & reader("NewID").ToString)
                                    'End If
                                Catch ex As Exception
                                    Retval.FailedHistory.Items.Add("Update ID Fields Accommodation/LicenceTaperHeader FAILED " & reader("ID").ToString & "/" & reader("NewID").ToString)
                                    Retval.OverallResult = False
                                End Try
                                'End Using 'cmdUpdate

                                ' Meters
                                SQLUpdate = "UPDATE Meters SET LocationID = " & reader("NewID").ToString & " WHERE LocationID = " & reader("ID").ToString
                                'Using cmdUpdate As New SqlCommand(SQLUpdate, connection)
                                cmdUpdate.CommandText = SQLUpdate
                                Try
                                    RowsAffected = cmdUpdate.ExecuteNonQuery()
                                    'If RowsAffected > 0 Then
                                    '    Retval.PassedHistory.Items.Add("Updated ID Fields Accommodation/Meters " & reader("ID").ToString & "/" & reader("NewID").ToString)
                                    'End If
                                Catch ex As Exception
                                    Retval.FailedHistory.Items.Add("Update ID Fields Accommodation/Meters FAILED " & reader("ID").ToString & "/" & reader("NewID").ToString)
                                    Retval.OverallResult = False
                                End Try
                                'End Using 'cmdUpdate

                                ' RoomBookings
                                SQLUpdate = "UPDATE RoomBookings SET RoomID = " & reader("NewID").ToString & " WHERE RoomID = " & reader("ID").ToString
                                'Using cmdUpdate As New SqlCommand(SQLUpdate, connection)
                                cmdUpdate.CommandText = SQLUpdate
                                Try
                                    RowsAffected = cmdUpdate.ExecuteNonQuery()
                                    'If RowsAffected > 0 Then
                                    '    Retval.PassedHistory.Items.Add("Updated ID Fields Accommodation/RoomBookings " & reader("ID").ToString & "/" & reader("NewID").ToString)
                                    'End If
                                Catch ex As Exception
                                    Retval.FailedHistory.Items.Add("Update ID Fields Accommodation/RoomBookings FAILED " & reader("ID").ToString & "/" & reader("NewID").ToString)
                                    Retval.OverallResult = False
                                End Try
                                'End Using 'cmdUpdate

                                ' RoomGroupRooms
                                SQLUpdate = "UPDATE RoomGroupRooms SET RoomID = " & reader("NewID").ToString & " WHERE RoomID = " & reader("ID").ToString
                                'Using cmdUpdate As New SqlCommand(SQLUpdate, connection)
                                cmdUpdate.CommandText = SQLUpdate
                                Try
                                    RowsAffected = cmdUpdate.ExecuteNonQuery()
                                    'If RowsAffected > 0 Then
                                    '    Retval.PassedHistory.Items.Add("Updated ID Fields Accommodation/RoomGroupRooms " & reader("ID").ToString & "/" & reader("NewID").ToString)
                                    'End If
                                Catch ex As Exception
                                    Retval.FailedHistory.Items.Add("Update ID Fields Accommodation/RoomGroupRooms FAILED " & reader("ID").ToString & "/" & reader("NewID").ToString)
                                    Retval.OverallResult = False
                                End Try
                                'End Using 'cmdUpdate

                                ' Viewings
                                SQLUpdate = "UPDATE Viewings SET RoomID = " & reader("NewID").ToString & " WHERE RoomID = " & reader("ID").ToString
                                'Using cmdUpdate As New SqlCommand(SQLUpdate, connection)
                                cmdUpdate.CommandText = SQLUpdate
                                Try
                                    RowsAffected = cmdUpdate.ExecuteNonQuery()
                                    'If RowsAffected > 0 Then
                                    '    Retval.PassedHistory.Items.Add("Updated ID Fields Accommodation/Viewings " & reader("ID").ToString & "/" & reader("NewID").ToString)
                                    'End If
                                Catch ex As Exception
                                    Retval.FailedHistory.Items.Add("Update ID Fields Accommodation/Viewings FAILED " & reader("ID").ToString & "/" & reader("NewID").ToString)
                                    Retval.OverallResult = False
                                End Try
                            End Using 'cmdUpdate

                        Loop

                    End If

                End Using ' reader

            End Using ' cmd

        End Using ' connection

        Return Retval

    End Function

    Public Shared Function UpdateClientIDs() As cMultiValueReturn

        Dim SQLstring As String = ""
        Dim SQLUpdate As String = ""
        Dim RowsAffected As Integer
        Dim Retval As New cMultiValueReturn

        ' ID is the original old ID from the local database
        SQLstring = "SELECT NewID, ID FROM Clients"

        Using connection As SqlConnection = DBConnection.GetConnectionIntermediate

            connection.Open()

            Using cmd As New SqlCommand(SQLstring, connection)

                Using reader As SqlDataReader = cmd.ExecuteReader

                    If reader.HasRows Then

                        Do While reader.Read

                            ' update related table data here
                            ' Addresses
                            SQLUpdate = "UPDATE Addresses SET ClientID = " & reader("NewID").ToString & " WHERE ClientID = " & reader("ID").ToString
                            Using cmdUpdate As New SqlCommand(SQLUpdate, connection)
                                Try
                                    RowsAffected = cmdUpdate.ExecuteNonQuery()
                                    'If RowsAffected > 0 Then
                                    '    Retval.PassedHistory.Items.Add("Updated ID Fields Client/Addresses " & reader("ID").ToString & "/" & reader("NewID").ToString)
                                    'End If
                                Catch ex As Exception
                                    Retval.FailedHistory.Items.Add("Update ID Fields Client/Addresses FAILED " & reader("ID").ToString & "/" & reader("NewID").ToString)
                                    Retval.OverallResult = False
                                End Try
                                'End Using 'cmdUpdate

                                ' Announcements
                                SQLUpdate = "UPDATE Announcements SET ClientID = " & reader("NewID").ToString & " WHERE ClientID = " & reader("ID").ToString
                                'Using cmdUpdate As New SqlCommand(SQLUpdate, connection)
                                cmdUpdate.CommandText = SQLUpdate
                                Try
                                    RowsAffected = cmdUpdate.ExecuteNonQuery()
                                    'If RowsAffected > 0 Then
                                    '    Retval.PassedHistory.Items.Add("Updated ID Fields Client/Announcements " & reader("ID").ToString & "/" & reader("NewID").ToString)
                                    'End If
                                Catch ex As Exception
                                    Retval.FailedHistory.Items.Add("Update ID Fields Client/Announcements FAILED " & reader("ID").ToString & "/" & reader("NewID").ToString)
                                    Retval.OverallResult = False
                                End Try
                                'End Using 'cmdUpdate

                                ' Assets
                                SQLUpdate = "UPDATE Assets SET ClientID = " & reader("NewID").ToString & " WHERE ClientID = " & reader("ID").ToString
                                'Using cmdUpdate As New SqlCommand(SQLUpdate, connection)
                                cmdUpdate.CommandText = SQLUpdate
                                Try
                                    RowsAffected = cmdUpdate.ExecuteNonQuery()
                                    'If RowsAffected > 0 Then
                                    '    Retval.PassedHistory.Items.Add("Updated ID Fields Client/Assets " & reader("ID").ToString & "/" & reader("NewID").ToString)
                                    'End If
                                Catch ex As Exception
                                    Retval.FailedHistory.Items.Add("Update ID Fields Client/Assets FAILED " & reader("ID").ToString & "/" & reader("NewID").ToString)
                                    Retval.OverallResult = False
                                End Try
                                'End Using 'cmdUpdate

                                ' Availability
                                SQLUpdate = "UPDATE Availability SET ClientID = " & reader("NewID").ToString & " WHERE ClientID = " & reader("ID").ToString
                                'Using cmdUpdate As New SqlCommand(SQLUpdate, connection)
                                cmdUpdate.CommandText = SQLUpdate
                                Try
                                    RowsAffected = cmdUpdate.ExecuteNonQuery()
                                    'If RowsAffected > 0 Then
                                    '    Retval.PassedHistory.Items.Add("Updated ID Fields Client/Availability " & reader("ID").ToString & "/" & reader("NewID").ToString)
                                    'End If
                                Catch ex As Exception
                                    Retval.FailedHistory.Items.Add("Update ID Fields Client/Availability FAILED " & reader("ID").ToString & "/" & reader("NewID").ToString)
                                    Retval.OverallResult = False
                                End Try
                                'End Using 'cmdUpdate

                                ' ClientFilters
                                SQLUpdate = "UPDATE ClientFilters SET ClientID = " & reader("NewID").ToString & " WHERE ClientID = " & reader("ID").ToString
                                'Using cmdUpdate As New SqlCommand(SQLUpdate, connection)
                                cmdUpdate.CommandText = SQLUpdate
                                Try
                                    RowsAffected = cmdUpdate.ExecuteNonQuery()
                                    'If RowsAffected > 0 Then
                                    '    Retval.PassedHistory.Items.Add("Updated ID Fields Client/ClientFilters " & reader("ID").ToString & "/" & reader("NewID").ToString)
                                    'End If
                                Catch ex As Exception
                                    Retval.FailedHistory.Items.Add("Update ID Fields Client/ClientFilters FAILED " & reader("ID").ToString & "/" & reader("NewID").ToString)
                                    Retval.OverallResult = False
                                End Try
                                'End Using 'cmdUpdate

                                ' ClientGroupClients
                                SQLUpdate = "UPDATE ClientGroupClients SET ClientID = " & reader("NewID").ToString & " WHERE ClientID = " & reader("ID").ToString
                                'Using cmdUpdate As New SqlCommand(SQLUpdate, connection)
                                cmdUpdate.CommandText = SQLUpdate
                                Try
                                    RowsAffected = cmdUpdate.ExecuteNonQuery()
                                    'If RowsAffected > 0 Then
                                    '    Retval.PassedHistory.Items.Add("Updated ID Fields Client/ClientGroupClients " & reader("ID").ToString & "/" & reader("NewID").ToString)
                                    'End If
                                Catch ex As Exception
                                    Retval.FailedHistory.Items.Add("Update ID Fields Client/ClientGroupClients FAILED " & reader("ID").ToString & "/" & reader("NewID").ToString)
                                    Retval.OverallResult = False
                                End Try
                                'End Using 'cmdUpdate

                                ' ClientPersons
                                SQLUpdate = "UPDATE ClientPersons SET ClientID = " & reader("NewID").ToString & " WHERE ClientID = " & reader("ID").ToString
                                'Using cmdUpdate As New SqlCommand(SQLUpdate, connection)
                                cmdUpdate.CommandText = SQLUpdate
                                Try
                                    RowsAffected = cmdUpdate.ExecuteNonQuery()
                                    'If RowsAffected > 0 Then
                                    '    Retval.PassedHistory.Items.Add("Updated ID Fields Client/ClientPersons " & reader("ID").ToString & "/" & reader("NewID").ToString)
                                    'End If
                                Catch ex As Exception
                                    Retval.FailedHistory.Items.Add("Update ID Fields Client/ClientPersons FAILED " & reader("ID").ToString & "/" & reader("NewID").ToString)
                                    Retval.OverallResult = False
                                End Try
                                'End Using 'cmdUpdate

                                ' DeletedInvoices
                                SQLUpdate = "UPDATE DeletedInvoices SET ClientID = " & reader("NewID").ToString & " WHERE ClientID = " & reader("ID").ToString
                                'Using cmdUpdate As New SqlCommand(SQLUpdate, connection)
                                cmdUpdate.CommandText = SQLUpdate
                                Try
                                    RowsAffected = cmdUpdate.ExecuteNonQuery()
                                    'If RowsAffected > 0 Then
                                    '    Retval.PassedHistory.Items.Add("Updated ID Fields Client/DeletedInvoices " & reader("ID").ToString & "/" & reader("NewID").ToString)
                                    'End If
                                Catch ex As Exception
                                    Retval.FailedHistory.Items.Add("Update ID Fields Client/DeletedInvoices FAILED " & reader("ID").ToString & "/" & reader("NewID").ToString)
                                    Retval.OverallResult = False
                                End Try
                                'End Using 'cmdUpdate

                                ' Deposits
                                SQLUpdate = "UPDATE Deposits SET ClientID = " & reader("NewID").ToString & " WHERE ClientID = " & reader("ID").ToString
                                'Using cmdUpdate As New SqlCommand(SQLUpdate, connection)
                                cmdUpdate.CommandText = SQLUpdate
                                Try
                                    RowsAffected = cmdUpdate.ExecuteNonQuery()
                                    'If RowsAffected > 0 Then
                                    '    Retval.PassedHistory.Items.Add("Updated ID Fields Client/Deposits " & reader("ID").ToString & "/" & reader("NewID").ToString)
                                    'End If
                                Catch ex As Exception
                                    Retval.FailedHistory.Items.Add("Update ID Fields Client/Deposits FAILED " & reader("ID").ToString & "/" & reader("NewID").ToString)
                                    Retval.OverallResult = False
                                End Try
                                'End Using 'cmdUpdate

                                ' EmailAddresses
                                SQLUpdate = "UPDATE EmailAddresses SET ClientID = " & reader("NewID").ToString & " WHERE ClientID = " & reader("ID").ToString
                                'Using cmdUpdate As New SqlCommand(SQLUpdate, connection)
                                cmdUpdate.CommandText = SQLUpdate
                                Try
                                    RowsAffected = cmdUpdate.ExecuteNonQuery()
                                    'If RowsAffected > 0 Then
                                    '    Retval.PassedHistory.Items.Add("Updated ID Fields Client/EmailAddresses " & reader("ID").ToString & "/" & reader("NewID").ToString)
                                    'End If
                                Catch ex As Exception
                                    Retval.FailedHistory.Items.Add("Update ID Fields Client/EmailAddresses FAILED " & reader("ID").ToString & "/" & reader("NewID").ToString)
                                    Retval.OverallResult = False
                                End Try
                                'End Using 'cmdUpdate

                                ' Filters
                                SQLUpdate = "UPDATE Filters SET FilterClientID = " & reader("NewID").ToString & " WHERE FilterClientID = " & reader("ID").ToString
                                'Using cmdUpdate As New SqlCommand(SQLUpdate, connection)
                                cmdUpdate.CommandText = SQLUpdate
                                Try
                                    RowsAffected = cmdUpdate.ExecuteNonQuery()
                                    'If RowsAffected > 0 Then
                                    '    Retval.PassedHistory.Items.Add("Updated ID Fields Client/Filters " & reader("ID").ToString & "/" & reader("NewID").ToString)
                                    'End If
                                Catch ex As Exception
                                    Retval.FailedHistory.Items.Add("Update ID Fields Client/Filters FAILED " & reader("ID").ToString & "/" & reader("NewID").ToString)
                                    Retval.OverallResult = False
                                End Try
                                'End Using 'cmdUpdate

                                ' Instructions
                                SQLUpdate = "UPDATE Instructions SET ClientID = " & reader("NewID").ToString & " WHERE ClientID = " & reader("ID").ToString
                                'Using cmdUpdate As New SqlCommand(SQLUpdate, connection)
                                cmdUpdate.CommandText = SQLUpdate
                                Try
                                    RowsAffected = cmdUpdate.ExecuteNonQuery()
                                    'If RowsAffected > 0 Then
                                    '    Retval.PassedHistory.Items.Add("Updated ID Fields Client/Instructions " & reader("ID").ToString & "/" & reader("NewID").ToString)
                                    'End If
                                Catch ex As Exception
                                    Retval.FailedHistory.Items.Add("Update ID Fields Client/Instructions FAILED " & reader("ID").ToString & "/" & reader("NewID").ToString)
                                    Retval.OverallResult = False
                                End Try
                                'End Using 'cmdUpdate

                                ' Invoices
                                SQLUpdate = "UPDATE Invoices SET ClientID = " & reader("NewID").ToString & " WHERE ClientID = " & reader("ID").ToString
                                'Using cmdUpdate As New SqlCommand(SQLUpdate, connection)
                                cmdUpdate.CommandText = SQLUpdate
                                Try
                                    RowsAffected = cmdUpdate.ExecuteNonQuery()
                                    'If RowsAffected > 0 Then
                                    '    Retval.PassedHistory.Items.Add("Updated ID Fields Client/Invoices " & reader("ID").ToString & "/" & reader("NewID").ToString)
                                    'End If
                                Catch ex As Exception
                                    Retval.FailedHistory.Items.Add("Update ID Fields Client/Invoices FAILED " & reader("ID").ToString & "/" & reader("NewID").ToString)
                                    Retval.OverallResult = False
                                End Try
                                'End Using 'cmdUpdate

                                ' Licences
                                SQLUpdate = "UPDATE Licences SET ClientID = " & reader("NewID").ToString & " WHERE ClientID = " & reader("ID").ToString
                                'Using cmdUpdate As New SqlCommand(SQLUpdate, connection)
                                cmdUpdate.CommandText = SQLUpdate
                                Try
                                    RowsAffected = cmdUpdate.ExecuteNonQuery()
                                    'If RowsAffected > 0 Then
                                    '    Retval.PassedHistory.Items.Add("Updated ID Fields Client/Licences " & reader("ID").ToString & "/" & reader("NewID").ToString)
                                    'End If
                                Catch ex As Exception
                                    Retval.FailedHistory.Items.Add("Update ID Fields Client/Licences FAILED " & reader("ID").ToString & "/" & reader("NewID").ToString)
                                    Retval.OverallResult = False
                                End Try
                                'End Using 'cmdUpdate

                                ' LicenceServiceChargeItemsTemp
                                SQLUpdate = "UPDATE LicenceServiceChargeItemsTemp SET ClientID = " & reader("NewID").ToString & " WHERE ClientID = " & reader("ID").ToString
                                'Using cmdUpdate As New SqlCommand(SQLUpdate, connection)
                                cmdUpdate.CommandText = SQLUpdate
                                Try
                                    RowsAffected = cmdUpdate.ExecuteNonQuery()
                                    'If RowsAffected > 0 Then
                                    '    Retval.PassedHistory.Items.Add("Updated ID Fields Client/LicenceServiceChargeItemsTemp " & reader("ID").ToString & "/" & reader("NewID").ToString)
                                    'End If
                                Catch ex As Exception
                                    Retval.FailedHistory.Items.Add("Update ID Fields Client/LicenceServiceChargeItemsTemp FAILED " & reader("ID").ToString & "/" & reader("NewID").ToString)
                                    Retval.OverallResult = False
                                End Try
                                'End Using 'cmdUpdate

                                ' ServiceChargeItems
                                SQLUpdate = "UPDATE ServiceChargeItems SET ClientID = " & reader("NewID").ToString & " WHERE ClientID = " & reader("ID").ToString
                                'Using cmdUpdate As New SqlCommand(SQLUpdate, connection)
                                cmdUpdate.CommandText = SQLUpdate
                                Try
                                    RowsAffected = cmdUpdate.ExecuteNonQuery()
                                    'If RowsAffected > 0 Then
                                    '    Retval.PassedHistory.Items.Add("Updated ID Fields Client/ServiceChargeItems " & reader("ID").ToString & "/" & reader("NewID").ToString)
                                    'End If
                                Catch ex As Exception
                                    Retval.FailedHistory.Items.Add("Update ID Fields Client/ServiceChargeItems FAILED " & reader("ID").ToString & "/" & reader("NewID").ToString)
                                    Retval.OverallResult = False
                                End Try
                                'End Using 'cmdUpdate

                                ' Tasks
                                SQLUpdate = "UPDATE Tasks SET ClientID = " & reader("NewID").ToString & " WHERE ClientID = " & reader("ID").ToString
                                'Using cmdUpdate As New SqlCommand(SQLUpdate, connection)
                                cmdUpdate.CommandText = SQLUpdate
                                Try
                                    RowsAffected = cmdUpdate.ExecuteNonQuery()
                                    'If RowsAffected > 0 Then
                                    '    Retval.PassedHistory.Items.Add("Updated ID Fields Client/Tasks " & reader("ID").ToString & "/" & reader("NewID").ToString)
                                    'End If
                                Catch ex As Exception
                                    Retval.FailedHistory.Items.Add("Update ID Fields Client/Tasks FAILED " & reader("ID").ToString & "/" & reader("NewID").ToString)
                                    Retval.OverallResult = False
                                End Try
                                'End Using 'cmdUpdate

                                ' TelephoneNumbers
                                SQLUpdate = "UPDATE TelephoneNumbers SET ClientID = " & reader("NewID").ToString & " WHERE ClientID = " & reader("ID").ToString
                                'Using cmdUpdate As New SqlCommand(SQLUpdate, connection)
                                cmdUpdate.CommandText = SQLUpdate
                                Try
                                    RowsAffected = cmdUpdate.ExecuteNonQuery()
                                    'If RowsAffected > 0 Then
                                    '    Retval.PassedHistory.Items.Add("Updated ID Fields Client/TelephoneNumbers " & reader("ID").ToString & "/" & reader("NewID").ToString)
                                    'End If
                                Catch ex As Exception
                                    Retval.FailedHistory.Items.Add("Update ID Fields Client/TelephoneNumbers FAILED " & reader("ID").ToString & "/" & reader("NewID").ToString)
                                    Retval.OverallResult = False
                                End Try
                                'End Using 'cmdUpdate

                                ' WebAddresses
                                SQLUpdate = "UPDATE WebAddresses SET ClientID = " & reader("NewID").ToString & " WHERE ClientID = " & reader("ID").ToString
                                'Using cmdUpdate As New SqlCommand(SQLUpdate, connection)
                                cmdUpdate.CommandText = SQLUpdate
                                Try
                                    RowsAffected = cmdUpdate.ExecuteNonQuery()
                                    'If RowsAffected > 0 Then
                                    '    Retval.PassedHistory.Items.Add("Updated ID Fields Client/WebAddresses " & reader("ID").ToString & "/" & reader("NewID").ToString)
                                    'End If
                                Catch ex As Exception
                                    Retval.FailedHistory.Items.Add("Update ID Fields Client/WebAddresses FAILED " & reader("ID").ToString & "/" & reader("NewID").ToString)
                                    Retval.OverallResult = False
                                End Try
                                'End Using 'cmdUpdate

                                ' RoomBookings - CompanyID field is actually ClientID!!
                                SQLUpdate = "UPDATE RoomBookings SET CompanyID = " & reader("NewID").ToString & " WHERE CompanyID = " & reader("ID").ToString
                                'Using cmdUpdate As New SqlCommand(SQLUpdate, connection)
                                cmdUpdate.CommandText = SQLUpdate
                                Try
                                    RowsAffected = cmdUpdate.ExecuteNonQuery()
                                    'If RowsAffected > 0 Then
                                    '    Retval.PassedHistory.Items.Add("Updated ID Fields Client/RoomBookings " & reader("ID").ToString & "/" & reader("NewID").ToString)
                                    'End If
                                Catch ex As Exception
                                    Retval.FailedHistory.Items.Add("Update ID Fields Client/RoomBookings FAILED " & reader("ID").ToString & "/" & reader("NewID").ToString)
                                    Retval.OverallResult = False
                                End Try
                            End Using 'cmdUpdate

                        Loop

                    End If

                End Using ' reader

            End Using ' cmd

        End Using ' connection

        Return Retval

    End Function

    Public Shared Function UpdateCompanyIDs() As cMultiValueReturn


        Dim SQLstring As String = ""
        Dim SQLUpdate As String = ""
        Dim RowsAffected As Integer
        Dim Retval As New cMultiValueReturn

        ' ID is the original old ID from the local database
        SQLstring = "SELECT NewID, ID FROM Companies"

        Using connection As SqlConnection = DBConnection.GetConnectionIntermediate

            connection.Open()

            Using cmd As New SqlCommand(SQLstring, connection)

                Using reader As SqlDataReader = cmd.ExecuteReader

                    If reader.HasRows Then

                        Do While reader.Read

                            ' update related table data here
                            ' Addresses
                            SQLUpdate = "UPDATE Addresses SET CompanyID = " & reader("NewID").ToString & " WHERE CompanyID = " & reader("ID").ToString
                            Using cmdUpdate As New SqlCommand(SQLUpdate, connection)
                                Try
                                    RowsAffected = cmdUpdate.ExecuteNonQuery()
                                    'If RowsAffected > 0 Then
                                    '    Retval.PassedHistory.Items.Add("Updated ID Fields Companies/Addresses " & reader("ID").ToString & "/" & reader("NewID").ToString)
                                    'End If
                                Catch ex As Exception
                                    Retval.FailedHistory.Items.Add("Update ID Fields Companies/Addresses FAILED " & reader("ID").ToString & "/" & reader("NewID").ToString)
                                    Retval.OverallResult = False
                                End Try
                                'End Using 'cmdUpdate

                                ' Clients
                                SQLUpdate = "UPDATE Clients SET CompanyID = " & reader("NewID").ToString & " WHERE CompanyID = " & reader("ID").ToString
                                'Using cmdUpdate As New SqlCommand(SQLUpdate, connection)
                                cmdUpdate.CommandText = SQLUpdate
                                Try
                                    RowsAffected = cmdUpdate.ExecuteNonQuery()
                                    'If RowsAffected > 0 Then
                                    '    Retval.PassedHistory.Items.Add("Updated ID Fields Companies/Clients " & reader("ID").ToString & "/" & reader("NewID").ToString)
                                    'End If
                                Catch ex As Exception
                                    Retval.FailedHistory.Items.Add("Update ID Fields Companies/Clients FAILED " & reader("ID").ToString & "/" & reader("NewID").ToString)
                                    Retval.OverallResult = False
                                End Try
                                'End Using 'cmdUpdate

                                ' CompanyDocuments
                                SQLUpdate = "UPDATE CompanyDocuments SET CompanyID = " & reader("NewID").ToString & " WHERE CompanyID = " & reader("ID").ToString
                                ' Using cmdUpdate As New SqlCommand(SQLUpdate, connection)
                                cmdUpdate.CommandText = SQLUpdate
                                Try
                                    RowsAffected = cmdUpdate.ExecuteNonQuery()
                                    'If RowsAffected > 0 Then
                                    '    Retval.PassedHistory.Items.Add("Updated ID Fields Companies/CompanyDocuments " & reader("ID").ToString & "/" & reader("NewID").ToString)
                                    'End If
                                Catch ex As Exception
                                    Retval.FailedHistory.Items.Add("Update ID Fields Companies/CompanyDocuments FAILED " & reader("ID").ToString & "/" & reader("NewID").ToString)
                                    Retval.OverallResult = False
                                End Try
                                'End Using 'cmdUpdate

                                ' CompanyPersons
                                SQLUpdate = "UPDATE CompanyPersons SET CompanyID = " & reader("NewID").ToString & " WHERE CompanyID = " & reader("ID").ToString
                                'Using cmdUpdate As New SqlCommand(SQLUpdate, connection)
                                cmdUpdate.CommandText = SQLUpdate
                                Try
                                    RowsAffected = cmdUpdate.ExecuteNonQuery()
                                    'If RowsAffected > 0 Then
                                    '    Retval.PassedHistory.Items.Add("Updated ID Fields Companies/CompanyPersons " & reader("ID").ToString & "/" & reader("NewID").ToString)
                                    'End If
                                Catch ex As Exception
                                    Retval.FailedHistory.Items.Add("Update ID Fields Companies/CompanyPersons FAILED " & reader("ID").ToString & "/" & reader("NewID").ToString)
                                    Retval.OverallResult = False
                                End Try
                                'End Using 'cmdUpdate

                                ' Contacts
                                SQLUpdate = "UPDATE Contacts SET CompanyID = " & reader("NewID").ToString & " WHERE CompanyID = " & reader("ID").ToString
                                'Using cmdUpdate As New SqlCommand(SQLUpdate, connection)
                                cmdUpdate.CommandText = SQLUpdate
                                Try
                                    RowsAffected = cmdUpdate.ExecuteNonQuery()
                                    'If RowsAffected > 0 Then
                                    '    Retval.PassedHistory.Items.Add("Updated ID Fields Companies/Contacts " & reader("ID").ToString & "/" & reader("NewID").ToString)
                                    'End If
                                Catch ex As Exception
                                    Retval.FailedHistory.Items.Add("Update ID Fields Companies/Contacts FAILED " & reader("ID").ToString & "/" & reader("NewID").ToString)
                                    Retval.OverallResult = False
                                End Try
                                'End Using 'cmdUpdate

                                ' CouriersAndTaxis
                                SQLUpdate = "UPDATE CouriersAndTaxis SET CompanyID = " & reader("NewID").ToString & " WHERE CompanyID = " & reader("ID").ToString
                                'Using cmdUpdate As New SqlCommand(SQLUpdate, connection)
                                cmdUpdate.CommandText = SQLUpdate
                                Try
                                    RowsAffected = cmdUpdate.ExecuteNonQuery()
                                    'If RowsAffected > 0 Then
                                    '    Retval.PassedHistory.Items.Add("Updated ID Fields Companies/CouriersAndTaxis " & reader("ID").ToString & "/" & reader("NewID").ToString)
                                    'End If
                                Catch ex As Exception
                                    Retval.FailedHistory.Items.Add("Update ID Fields Companies/CouriersAndTaxis FAILED " & reader("ID").ToString & "/" & reader("NewID").ToString)
                                    Retval.OverallResult = False
                                End Try
                                'End Using 'cmdUpdate

                                ' Deliveries
                                SQLUpdate = "UPDATE Deliveries SET CompanyID = " & reader("NewID").ToString & " WHERE CompanyID = " & reader("ID").ToString
                                'Using cmdUpdate As New SqlCommand(SQLUpdate, connection)
                                cmdUpdate.CommandText = SQLUpdate
                                Try
                                    RowsAffected = cmdUpdate.ExecuteNonQuery()
                                    'If RowsAffected > 0 Then
                                    '    Retval.PassedHistory.Items.Add("Updated ID Fields Companies/Deliveries " & reader("ID").ToString & "/" & reader("NewID").ToString)
                                    'End If
                                Catch ex As Exception
                                    Retval.FailedHistory.Items.Add("Update ID Fields Companies/Deliveries FAILED " & reader("ID").ToString & "/" & reader("NewID").ToString)
                                    Retval.OverallResult = False
                                End Try
                                'End Using 'cmdUpdate

                                ' EmailAddresses
                                SQLUpdate = "UPDATE EmailAddresses SET CompanyID = " & reader("NewID").ToString & " WHERE CompanyID = " & reader("ID").ToString
                                'Using cmdUpdate As New SqlCommand(SQLUpdate, connection)
                                cmdUpdate.CommandText = SQLUpdate
                                Try
                                    RowsAffected = cmdUpdate.ExecuteNonQuery()
                                    'If RowsAffected > 0 Then
                                    '    Retval.PassedHistory.Items.Add("Updated ID Fields Companies/EmailAddresses " & reader("ID").ToString & "/" & reader("NewID").ToString)
                                    'End If
                                Catch ex As Exception
                                    Retval.FailedHistory.Items.Add("Update ID Fields Companies/EmailAddresses FAILED " & reader("ID").ToString & "/" & reader("NewID").ToString)
                                    Retval.OverallResult = False
                                End Try
                                'End Using 'cmdUpdate

                                ' Faxes
                                SQLUpdate = "UPDATE Faxes SET CompanyID = " & reader("NewID").ToString & " WHERE CompanyID = " & reader("ID").ToString
                                'Using cmdUpdate As New SqlCommand(SQLUpdate, connection)
                                cmdUpdate.CommandText = SQLUpdate
                                Try
                                    RowsAffected = cmdUpdate.ExecuteNonQuery()
                                    'If RowsAffected > 0 Then
                                    '    Retval.PassedHistory.Items.Add("Updated ID Fields Companies/Faxes " & reader("ID").ToString & "/" & reader("NewID").ToString)
                                    'End If
                                Catch ex As Exception
                                    Retval.FailedHistory.Items.Add("Update ID Fields Companies/Faxes FAILED " & reader("ID").ToString & "/" & reader("NewID").ToString)
                                    Retval.OverallResult = False
                                End Try
                                'End Using 'cmdUpdate

                                ' FrontDeskNotes
                                SQLUpdate = "UPDATE FrontDeskNotes SET CompanyID = " & reader("NewID").ToString & " WHERE CompanyID = " & reader("ID").ToString
                                'Using cmdUpdate As New SqlCommand(SQLUpdate, connection)
                                cmdUpdate.CommandText = SQLUpdate
                                Try
                                    RowsAffected = cmdUpdate.ExecuteNonQuery()
                                    'If RowsAffected > 0 Then
                                    '    Retval.PassedHistory.Items.Add("Updated ID Fields Companies/FrontDeskNotes " & reader("ID").ToString & "/" & reader("NewID").ToString)
                                    'End If
                                Catch ex As Exception
                                    Retval.FailedHistory.Items.Add("Update ID Fields Companies/FrontDeskNotes FAILED " & reader("ID").ToString & "/" & reader("NewID").ToString)
                                    Retval.OverallResult = False
                                End Try
                                'End Using 'cmdUpdate

                                ' Invoices
                                SQLUpdate = "UPDATE Invoices SET CompanyID = " & reader("NewID").ToString & " WHERE CompanyID = " & reader("ID").ToString
                                'Using cmdUpdate As New SqlCommand(SQLUpdate, connection)
                                cmdUpdate.CommandText = SQLUpdate
                                Try
                                    RowsAffected = cmdUpdate.ExecuteNonQuery()
                                    'If RowsAffected > 0 Then
                                    '    Retval.PassedHistory.Items.Add("Updated ID Fields Companies/Invoices " & reader("ID").ToString & "/" & reader("NewID").ToString)
                                    'End If
                                Catch ex As Exception
                                    Retval.FailedHistory.Items.Add("Update ID Fields Companies/Invoices FAILED " & reader("ID").ToString & "/" & reader("NewID").ToString)
                                    Retval.OverallResult = False
                                End Try
                                'End Using 'cmdUpdate

                                ' LicenceServiceChargeItemsTemp
                                SQLUpdate = "UPDATE LicenceServiceChargeItemsTemp SET CompanyID = " & reader("NewID").ToString & " WHERE CompanyID = " & reader("ID").ToString
                                'Using cmdUpdate As New SqlCommand(SQLUpdate, connection)
                                cmdUpdate.CommandText = SQLUpdate
                                Try
                                    RowsAffected = cmdUpdate.ExecuteNonQuery()
                                    'If RowsAffected > 0 Then
                                    '    Retval.PassedHistory.Items.Add("Updated ID Fields Companies/LicenceServiceChargeItemsTemp " & reader("ID").ToString & "/" & reader("NewID").ToString)
                                    'End If
                                Catch ex As Exception
                                    Retval.FailedHistory.Items.Add("Update ID Fields Companies/LicenceServiceChargeItemsTemp FAILED " & reader("ID").ToString & "/" & reader("NewID").ToString)
                                    Retval.OverallResult = False
                                End Try
                                'End Using 'cmdUpdate

                                ' Mail
                                SQLUpdate = "UPDATE Mail SET CompanyID = " & reader("NewID").ToString & " WHERE CompanyID = " & reader("ID").ToString
                                'Using cmdUpdate As New SqlCommand(SQLUpdate, connection)
                                cmdUpdate.CommandText = SQLUpdate
                                Try
                                    RowsAffected = cmdUpdate.ExecuteNonQuery()
                                    'If RowsAffected > 0 Then
                                    '    Retval.PassedHistory.Items.Add("Updated ID Fields Companies/Mail " & reader("ID").ToString & "/" & reader("NewID").ToString)
                                    'End If
                                Catch ex As Exception
                                    Retval.FailedHistory.Items.Add("Update ID Fields Companies/Mail FAILED " & reader("ID").ToString & "/" & reader("NewID").ToString)
                                    Retval.OverallResult = False
                                End Try
                                'End Using 'cmdUpdate

                                ' Messages
                                SQLUpdate = "UPDATE Messages SET CompanyID = " & reader("NewID").ToString & " WHERE CompanyID = " & reader("ID").ToString
                                'Using cmdUpdate As New SqlCommand(SQLUpdate, connection)
                                cmdUpdate.CommandText = SQLUpdate
                                Try
                                    RowsAffected = cmdUpdate.ExecuteNonQuery()
                                    'If RowsAffected > 0 Then
                                    '    Retval.PassedHistory.Items.Add("Updated ID Fields Companies/Messages " & reader("ID").ToString & "/" & reader("NewID").ToString)
                                    'End If
                                Catch ex As Exception
                                    Retval.FailedHistory.Items.Add("Update ID Fields Companies/Messages FAILED " & reader("ID").ToString & "/" & reader("NewID").ToString)
                                    Retval.OverallResult = False
                                End Try
                                'End Using 'cmdUpdate

                                ' ServiceChargeItems
                                SQLUpdate = "UPDATE ServiceChargeItems SET CompanyID = " & reader("NewID").ToString & " WHERE CompanyID = " & reader("ID").ToString
                                'Using cmdUpdate As New SqlCommand(SQLUpdate, connection)
                                cmdUpdate.CommandText = SQLUpdate
                                Try
                                    RowsAffected = cmdUpdate.ExecuteNonQuery()
                                    'If RowsAffected > 0 Then
                                    '    Retval.PassedHistory.Items.Add("Updated ID Fields Companies/ServiceChargeItems " & reader("ID").ToString & "/" & reader("NewID").ToString)
                                    'End If
                                Catch ex As Exception
                                    Retval.FailedHistory.Items.Add("Update ID Fields Companies/ServiceChargeItems FAILED " & reader("ID").ToString & "/" & reader("NewID").ToString)
                                    Retval.OverallResult = False
                                End Try
                                'End Using 'cmdUpdate

                                ' TelephoneNumbers
                                SQLUpdate = "UPDATE TelephoneNumbers SET CompanyID = " & reader("NewID").ToString & " WHERE CompanyID = " & reader("ID").ToString
                                'Using cmdUpdate As New SqlCommand(SQLUpdate, connection)
                                cmdUpdate.CommandText = SQLUpdate
                                Try
                                    RowsAffected = cmdUpdate.ExecuteNonQuery()
                                    'If RowsAffected > 0 Then
                                    '    Retval.PassedHistory.Items.Add("Updated ID Fields Companies/TelephoneNumbers " & reader("ID").ToString & "/" & reader("NewID").ToString)
                                    'End If
                                Catch ex As Exception
                                    Retval.FailedHistory.Items.Add("Update ID Fields Companies/TelephoneNumbers FAILED " & reader("ID").ToString & "/" & reader("NewID").ToString)
                                    Retval.OverallResult = False
                                End Try
                                'End Using 'cmdUpdate

                                ' Viewings
                                SQLUpdate = "UPDATE Viewings SET CompanyID = " & reader("NewID").ToString & " WHERE CompanyID = " & reader("ID").ToString
                                'Using cmdUpdate As New SqlCommand(SQLUpdate, connection)
                                cmdUpdate.CommandText = SQLUpdate
                                Try
                                    RowsAffected = cmdUpdate.ExecuteNonQuery()
                                    'If RowsAffected > 0 Then
                                    '    Retval.PassedHistory.Items.Add("Updated ID Fields Companies/Viewings " & reader("ID").ToString & "/" & reader("NewID").ToString)
                                    'End If
                                Catch ex As Exception
                                    Retval.FailedHistory.Items.Add("Update ID Fields Companies/Viewings FAILED " & reader("ID").ToString & "/" & reader("NewID").ToString)
                                    Retval.OverallResult = False
                                End Try
                                'End Using 'cmdUpdate

                                ' WebAddresses
                                SQLUpdate = "UPDATE WebAddresses SET CompanyID = " & reader("NewID").ToString & " WHERE CompanyID = " & reader("ID").ToString
                                'Using cmdUpdate As New SqlCommand(SQLUpdate, connection)
                                cmdUpdate.CommandText = SQLUpdate
                                Try
                                    RowsAffected = cmdUpdate.ExecuteNonQuery()
                                    'If RowsAffected > 0 Then
                                    '    Retval.PassedHistory.Items.Add("Updated ID Fields Companies/VWebAddressesiewings " & reader("ID").ToString & "/" & reader("NewID").ToString)
                                    'End If
                                Catch ex As Exception
                                    Retval.FailedHistory.Items.Add("Update ID Fields Companies/WebAddresses FAILED " & reader("ID").ToString & "/" & reader("NewID").ToString)
                                    Retval.OverallResult = False
                                End Try
                            End Using 'cmdUpdate

                        Loop

                    End If

                End Using ' reader

            End Using ' cmd

        End Using ' connection

        Return Retval
    End Function

    Public Shared Function UpdateContactHistoryIDs() As cMultiValueReturn

        Dim SQLstring As String = ""
        Dim SQLUpdate As String = ""
        Dim RowsAffected As Integer
        Dim Retval As New cMultiValueReturn

        ' ID is the original old ID from the local database
        SQLstring = "SELECT NewID, ID FROM ContactHistory"

        Using connection As SqlConnection = DBConnection.GetConnectionIntermediate

            connection.Open()

            Using cmd As New SqlCommand(SQLstring, connection)

                Using reader As SqlDataReader = cmd.ExecuteReader

                    If reader.HasRows Then

                        Do While reader.Read

                            ' update related table data here
                            ' ContactHistoryAttachments
                            SQLUpdate = "UPDATE ContactHistoryAttachments SET ContactHistoryID = " & reader("NewID").ToString & " WHERE ContactHistoryID = " & reader("ID").ToString
                            Using cmdUpdate As New SqlCommand(SQLUpdate, connection)
                                Try
                                    RowsAffected = cmdUpdate.ExecuteNonQuery()
                                    'If RowsAffected > 0 Then
                                    '    Retval.PassedHistory.Items.Add("Updated ID Fields ContactHistory/ContactHistoryAttachments " & reader("ID").ToString & "/" & reader("NewID").ToString)
                                    'End If
                                Catch ex As Exception
                                    Retval.FailedHistory.Items.Add("Update ID Fields ContactHistory/ContactHistoryAttachments FAILED " & reader("ID").ToString & "/" & reader("NewID").ToString)
                                    Retval.OverallResult = False
                                End Try
                                'End Using 'cmdUpdate

                                ' ContacHistoryTasks
                                SQLUpdate = "UPDATE ContactHistoryTasks SET ContactHistoryID = " & reader("NewID").ToString & " WHERE ContactHistoryID = " & reader("ID").ToString
                                'Using cmdUpdate As New SqlCommand(SQLUpdate, connection)
                                cmdUpdate.CommandText = SQLUpdate
                                Try
                                    RowsAffected = cmdUpdate.ExecuteNonQuery()
                                    'If RowsAffected > 0 Then
                                    '    Retval.PassedHistory.Items.Add("Updated ID Fields ContactHistory/ContacHistoryTasks " & reader("ID").ToString & "/" & reader("NewID").ToString)
                                    'End If
                                Catch ex As Exception
                                    Retval.FailedHistory.Items.Add("Update ID Fields ContactHistory/ContacHistoryTasks FAILED " & reader("ID").ToString & "/" & reader("NewID").ToString)
                                    Retval.OverallResult = False
                                End Try
                            End Using 'cmdUpdate

                        Loop

                    End If

                End Using ' reader

            End Using ' cmd

        End Using ' connection

        Return Retval

    End Function

    Public Shared Function UpdateContactsIDs() As cMultiValueReturn

        Dim SQLstring As String = ""
        Dim SQLUpdate As String = ""
        Dim RowsAffected As Integer
        Dim Retval As New cMultiValueReturn

        ' ID is the original old ID from the local database
        SQLstring = "SELECT NewID, ID FROM Contacts"

        Using connection As SqlConnection = DBConnection.GetConnectionIntermediate

            connection.Open()

            Using cmd As New SqlCommand(SQLstring, connection)

                Using reader As SqlDataReader = cmd.ExecuteReader

                    If reader.HasRows Then

                        Do While reader.Read

                            ' update related table data here
                            ' ContactHistory
                            SQLUpdate = "UPDATE ContactHistory SET ContactID = " & reader("NewID").ToString & " WHERE ContactID = " & reader("ID").ToString
                            Using cmdUpdate As New SqlCommand(SQLUpdate, connection)
                                Try
                                    RowsAffected = cmdUpdate.ExecuteNonQuery()
                                    'If RowsAffected > 0 Then
                                    '    Retval.PassedHistory.Items.Add("Updated ID Fields Contact/ContactHistory " & reader("ID").ToString & "/" & reader("NewID").ToString)
                                    'End If
                                Catch ex As Exception
                                    Retval.FailedHistory.Items.Add("Update ID Fields Contact/ContactHistory FAILED " & reader("ID").ToString & "/" & reader("NewID").ToString)
                                    Retval.OverallResult = False
                                End Try
                                'End Using 'cmdUpdate

                                ' ContactSitesOfInterest
                                SQLUpdate = "UPDATE ContactSitesOfInterest SET ContactID = " & reader("NewID").ToString & " WHERE ContactID = " & reader("ID").ToString
                                'Using cmdUpdate As New SqlCommand(SQLUpdate, connection)
                                cmdUpdate.CommandText = SQLUpdate
                                Try
                                    RowsAffected = cmdUpdate.ExecuteNonQuery()
                                    'If RowsAffected > 0 Then
                                    '    Retval.PassedHistory.Items.Add("Updated ID Fields Contacts/ContactSitesOfInterest " & reader("ID").ToString & "/" & reader("NewID").ToString)
                                    'End If
                                Catch ex As Exception
                                    Retval.FailedHistory.Items.Add("Update ID Fields Contacts/ContactSitesOfInterest FAILED " & reader("ID").ToString & "/" & reader("NewID").ToString)
                                    Retval.OverallResult = False
                                End Try
                                'End Using 'cmdUpdate

                                ' Viewings
                                SQLUpdate = "UPDATE Viewings SET ContactID = " & reader("NewID").ToString & " WHERE ContactID = " & reader("ID").ToString
                                'Using cmdUpdate As New SqlCommand(SQLUpdate, connection)
                                cmdUpdate.CommandText = SQLUpdate
                                Try
                                    RowsAffected = cmdUpdate.ExecuteNonQuery()
                                    'If RowsAffected > 0 Then
                                    '    Retval.PassedHistory.Items.Add("Updated ID Fields Contacts/Viewings " & reader("ID").ToString & "/" & reader("NewID").ToString)
                                    'End If
                                Catch ex As Exception
                                    Retval.FailedHistory.Items.Add("Update ID Fields Contacts/Viewings FAILED " & reader("ID").ToString & "/" & reader("NewID").ToString)
                                    Retval.OverallResult = False
                                End Try
                            End Using 'cmdUpdate

                        Loop

                    End If

                End Using ' reader

            End Using ' cmd

        End Using ' connection

        Return Retval

    End Function

    Public Shared Function UpdateDelegatesIDs() As cMultiValueReturn

        Dim SQLstring As String = ""
        Dim SQLUpdate As String = ""
        Dim RowsAffected As Integer
        Dim Retval As New cMultiValueReturn

        ' ID is the original old ID from the local database
        SQLstring = "SELECT NewID, ID FROM Delegates"

        Using connection As SqlConnection = DBConnection.GetConnectionIntermediate

            connection.Open()

            Using cmd As New SqlCommand(SQLstring, connection)

                Using reader As SqlDataReader = cmd.ExecuteReader

                    If reader.HasRows Then

                        Do While reader.Read

                            ' update related table data here
                            ' RoomBookingDelegates
                            SQLUpdate = "UPDATE RoomBookingDelegates SET DelegateID = " & reader("NewID").ToString & " WHERE DelegateID = " & reader("ID").ToString
                            Using cmdUpdate As New SqlCommand(SQLUpdate, connection)
                                Try
                                    RowsAffected = cmdUpdate.ExecuteNonQuery()
                                    'If RowsAffected > 0 Then
                                    '    Retval.PassedHistory.Items.Add("Updated ID Fields Delegates/RoomBookingDelegates " & reader("ID").ToString & "/" & reader("NewID").ToString)
                                    'End If
                                Catch ex As Exception
                                    Retval.FailedHistory.Items.Add("Update ID Fields Delegates/RoomBookingDelegates FAILED " & reader("ID").ToString & "/" & reader("NewID").ToString)
                                    Retval.OverallResult = False
                                End Try
                            End Using 'cmdUpdate

                        Loop

                    End If

                End Using ' reader

            End Using ' cmd

        End Using ' connection

        Return Retval

    End Function

    Public Shared Function UpdateDocumentsIDs() As cMultiValueReturn

        Dim SQLstring As String = ""
        Dim SQLUpdate As String = ""
        Dim RowsAffected As Integer
        Dim Retval As New cMultiValueReturn

        ' ID is the original old ID from the local database
        SQLstring = "SELECT NewID, ID FROM Documents"

        Using connection As SqlConnection = DBConnection.GetConnectionIntermediate

            connection.Open()

            Using cmd As New SqlCommand(SQLstring, connection)

                Using reader As SqlDataReader = cmd.ExecuteReader

                    If reader.HasRows Then

                        Do While reader.Read

                            ' update related table data here
                            ' CompanyDocuments
                            SQLUpdate = "UPDATE CompanyDocuments SET DocumentID = " & reader("NewID").ToString & " WHERE DocumentID = " & reader("ID").ToString
                            Using cmdUpdate As New SqlCommand(SQLUpdate, connection)
                                Try
                                    RowsAffected = cmdUpdate.ExecuteNonQuery()
                                    'If RowsAffected > 0 Then
                                    '    Retval.PassedHistory.Items.Add("Updated ID Fields Documents/CompanyDocuments " & reader("ID").ToString & "/" & reader("NewID").ToString)
                                    'End If
                                Catch ex As Exception
                                    Retval.FailedHistory.Items.Add("Update ID Fields Documents/CompanyDocuments FAILED " & reader("ID").ToString & "/" & reader("NewID").ToString)
                                    Retval.OverallResult = False
                                End Try
                                'End Using 'cmdUpdate

                                ' ContactHistoryAttachments
                                SQLUpdate = "UPDATE ContactHistoryAttachments SET DocumentID = " & reader("NewID").ToString & " WHERE DocumentID = " & reader("ID").ToString
                                'Using cmdUpdate As New SqlCommand(SQLUpdate, connection)
                                cmdUpdate.CommandText = SQLUpdate
                                Try
                                    RowsAffected = cmdUpdate.ExecuteNonQuery()
                                    'If RowsAffected > 0 Then
                                    '    Retval.PassedHistory.Items.Add("Updated ID Fields Documents/ContactHistoryAttachments " & reader("ID").ToString & "/" & reader("NewID").ToString)
                                    'End If
                                Catch ex As Exception
                                    Retval.FailedHistory.Items.Add("Update ID Fields Documents/ContactHistoryAttachments FAILED " & reader("ID").ToString & "/" & reader("NewID").ToString)
                                    Retval.OverallResult = False
                                End Try
                                'End Using 'cmdUpdate

                                ' FrontDeskNoteDocuments
                                SQLUpdate = "UPDATE FrontDeskNoteDocuments SET DocumentID = " & reader("NewID").ToString & " WHERE DocumentID = " & reader("ID").ToString
                                'Using cmdUpdate As New SqlCommand(SQLUpdate, connection)
                                cmdUpdate.CommandText = SQLUpdate
                                Try
                                    RowsAffected = cmdUpdate.ExecuteNonQuery()
                                    'If RowsAffected > 0 Then
                                    '    Retval.PassedHistory.Items.Add("Updated ID Fields Documents/FrontDeskNoteDocuments " & reader("ID").ToString & "/" & reader("NewID").ToString)
                                    'End If
                                Catch ex As Exception
                                    Retval.FailedHistory.Items.Add("Update ID Fields Documents/FrontDeskNoteDocuments FAILED " & reader("ID").ToString & "/" & reader("NewID").ToString)
                                    Retval.OverallResult = False
                                End Try
                                'End Using 'cmdUpdate

                                ' RoomBookingDocuments
                                SQLUpdate = "UPDATE RoomBookingDocuments SET DocumentID = " & reader("NewID").ToString & " WHERE DocumentID = " & reader("ID").ToString
                                'Using cmdUpdate As New SqlCommand(SQLUpdate, connection)
                                cmdUpdate.CommandText = SQLUpdate
                                Try
                                    RowsAffected = cmdUpdate.ExecuteNonQuery()
                                    'If RowsAffected > 0 Then
                                    '    Retval.PassedHistory.Items.Add("Updated ID Fields Documents/RoomBookingDocuments " & reader("ID").ToString & "/" & reader("NewID").ToString)
                                    'End If
                                Catch ex As Exception
                                    Retval.FailedHistory.Items.Add("Update ID Fields Documents/RoomBookingDocuments FAILED " & reader("ID").ToString & "/" & reader("NewID").ToString)
                                    Retval.OverallResult = False
                                End Try
                                'End Using 'cmdUpdate

                                ' TaskDocuments
                                SQLUpdate = "UPDATE TaskDocuments SET DocumentID = " & reader("NewID").ToString & " WHERE DocumentID = " & reader("ID").ToString
                                'Using cmdUpdate As New SqlCommand(SQLUpdate, connection)
                                cmdUpdate.CommandText = SQLUpdate
                                Try
                                    RowsAffected = cmdUpdate.ExecuteNonQuery()
                                    'If RowsAffected > 0 Then
                                    '    Retval.PassedHistory.Items.Add("Updated ID Fields Documents/TaskDocuments " & reader("ID").ToString & "/" & reader("NewID").ToString)
                                    'End If
                                Catch ex As Exception
                                    Retval.FailedHistory.Items.Add("Update ID Fields Documents/TaskDocuments FAILED " & reader("ID").ToString & "/" & reader("NewID").ToString)
                                    Retval.OverallResult = False
                                End Try
                            End Using 'cmdUpdate

                        Loop

                    End If

                End Using ' reader

            End Using ' cmd

        End Using ' connection

        Return Retval


    End Function

    Public Shared Function UpdateFrontDeskNotesIDs() As cMultiValueReturn

        Dim SQLstring As String = ""
        Dim SQLUpdate As String = ""
        Dim RowsAffected As Integer
        Dim Retval As New cMultiValueReturn

        ' ID is the original old ID from the local database
        SQLstring = "SELECT NewID, ID FROM FrontDeskNotes"

        Using connection As SqlConnection = DBConnection.GetConnectionIntermediate

            connection.Open()

            Using cmd As New SqlCommand(SQLstring, connection)

                Using reader As SqlDataReader = cmd.ExecuteReader

                    If reader.HasRows Then

                        Do While reader.Read

                            ' update related table data here
                            ' FrontDeskNoteActions
                            SQLUpdate = "UPDATE FrontDeskNoteActions SET FDNoteID = " & reader("NewID").ToString & " WHERE FDNoteID = " & reader("ID").ToString
                            Using cmdUpdate As New SqlCommand(SQLUpdate, connection)
                                Try
                                    RowsAffected = cmdUpdate.ExecuteNonQuery()
                                    'If RowsAffected > 0 Then
                                    '    Retval.PassedHistory.Items.Add("Updated ID Fields FrontDeskNotes/FrontDeskNoteActions " & reader("ID").ToString & "/" & reader("NewID").ToString)
                                    'End If
                                Catch ex As Exception
                                    Retval.FailedHistory.Items.Add("Update ID Fields FrontDeskNotes/FrontDeskNoteActions FAILED " & reader("ID").ToString & "/" & reader("NewID").ToString)
                                    Retval.OverallResult = False
                                End Try
                                'End Using 'cmdUpdate

                                ' FrontDeskNoteDocuments
                                SQLUpdate = "UPDATE FrontDeskNoteDocuments SET FDNoteID = " & reader("NewID").ToString & " WHERE FDNoteID = " & reader("ID").ToString
                                'Using cmdUpdate As New SqlCommand(SQLUpdate, connection)
                                cmdUpdate.CommandText = SQLUpdate
                                Try
                                    RowsAffected = cmdUpdate.ExecuteNonQuery()
                                    'If RowsAffected > 0 Then
                                    '    Retval.PassedHistory.Items.Add("Updated ID Fields FrontDeskNotes/FrontDeskNoteDocuments " & reader("ID").ToString & "/" & reader("NewID").ToString)
                                    'End If
                                Catch ex As Exception
                                    Retval.FailedHistory.Items.Add("Update ID Fields FrontDeskNotes/FrontDeskNoteDocuments FAILED " & reader("ID").ToString & "/" & reader("NewID").ToString)
                                    Retval.OverallResult = False
                                End Try
                                'End Using 'cmdUpdate

                                ' FrontDeskNoteServiceCharges
                                SQLUpdate = "UPDATE FrontDeskNoteServiceCharges SET FDNoteID = " & reader("NewID").ToString & " WHERE FDNoteID = " & reader("ID").ToString
                                'Using cmdUpdate As New SqlCommand(SQLUpdate, connection)
                                cmdUpdate.CommandText = SQLUpdate
                                Try
                                    RowsAffected = cmdUpdate.ExecuteNonQuery()
                                    'If RowsAffected > 0 Then
                                    '    Retval.PassedHistory.Items.Add("Updated ID Fields FrontDeskNotes/FrontDeskNoteServiceCharges " & reader("ID").ToString & "/" & reader("NewID").ToString)
                                    'End If
                                Catch ex As Exception
                                    Retval.FailedHistory.Items.Add("Update ID Fields FrontDeskNotes/FrontDeskNoteServiceCharges FAILED " & reader("ID").ToString & "/" & reader("NewID").ToString)
                                    Retval.OverallResult = False
                                End Try
                                'End Using 'cmdUpdate

                                ' FrontDeskNoteTasks
                                SQLUpdate = "UPDATE FrontDeskNoteTasks SET FrontDeskNoteID = " & reader("NewID").ToString & " WHERE FrontDeskNoteID = " & reader("ID").ToString
                                'Using cmdUpdate As New SqlCommand(SQLUpdate, connection)
                                cmdUpdate.CommandText = SQLUpdate
                                Try
                                    RowsAffected = cmdUpdate.ExecuteNonQuery()
                                    'If RowsAffected > 0 Then
                                    '    Retval.PassedHistory.Items.Add("Updated ID Fields FrontDeskNotes/FrontDeskNoteTasks " & reader("ID").ToString & "/" & reader("NewID").ToString)
                                    'End If
                                Catch ex As Exception
                                    Retval.FailedHistory.Items.Add("Update ID Fields FrontDeskNotes/FrontDeskNoteTasks FAILED " & reader("ID").ToString & "/" & reader("NewID").ToString)
                                    Retval.OverallResult = False
                                End Try
                            End Using 'cmdUpdate

                        Loop

                    End If

                End Using ' reader

            End Using ' cmd

        End Using ' connection

        Return Retval

    End Function

    Public Shared Function UpdateInvoiceExportBatchesIDs() As cMultiValueReturn

        Dim SQLstring As String = ""
        Dim SQLUpdate As String = ""
        Dim RowsAffected As Integer
        Dim Retval As New cMultiValueReturn

        ' ID is the original old ID from the local database
        SQLstring = "SELECT NewID, ID FROM InvoiceExportBatches"

        Using connection As SqlConnection = DBConnection.GetConnectionIntermediate

            connection.Open()

            Using cmd As New SqlCommand(SQLstring, connection)

                Using reader As SqlDataReader = cmd.ExecuteReader

                    If reader.HasRows Then

                        Do While reader.Read

                            ' update related table data here
                            ' Invoices
                            SQLUpdate = "UPDATE Invoices SET ExportBatchID = " & reader("NewID").ToString & " WHERE ExportBatchID = " & reader("ID").ToString
                            Using cmdUpdate As New SqlCommand(SQLUpdate, connection)
                                Try
                                    RowsAffected = cmdUpdate.ExecuteNonQuery()
                                    'If RowsAffected > 0 Then
                                    '    Retval.PassedHistory.Items.Add("Updated ID Fields InvoiceExportBatches/Invoices " & reader("ID").ToString & "/" & reader("NewID").ToString)
                                    'End If
                                Catch ex As Exception
                                    Retval.FailedHistory.Items.Add("Update ID Fields InvoiceExportBatches/Invoices FAILED " & reader("ID").ToString & "/" & reader("NewID").ToString)
                                    Retval.OverallResult = False
                                End Try
                            End Using 'cmdUpdate

                        Loop

                    End If

                End Using ' reader

            End Using ' cmd

        End Using ' connection

        Return Retval

    End Function

    Public Shared Function UpdateInvoiceLinesIDs() As cMultiValueReturn

        Dim SQLstring As String = ""
        Dim SQLUpdate As String = ""
        Dim RowsAffected As Integer
        Dim Retval As New cMultiValueReturn

        ' ID is the original old ID from the local database
        SQLstring = "SELECT NewID, ID FROM InvoiceLines"

        Using connection As SqlConnection = DBConnection.GetConnectionIntermediate

            connection.Open()

            Using cmd As New SqlCommand(SQLstring, connection)

                Using reader As SqlDataReader = cmd.ExecuteReader

                    If reader.HasRows Then

                        Do While reader.Read

                            ' update related table data here
                            ' Deposits
                            SQLUpdate = "UPDATE Deposits SET InvoiceLineID = " & reader("NewID").ToString & " WHERE InvoiceLineID = " & reader("ID").ToString
                            Using cmdUpdate As New SqlCommand(SQLUpdate, connection)
                                Try
                                    RowsAffected = cmdUpdate.ExecuteNonQuery()
                                    'If RowsAffected > 0 Then
                                    '    'Retval.PassedHistory.Items.Add("Updated ID Fields InvoiceLines/Deposits " & reader("ID").ToString & "/" & reader("NewID").ToString)
                                    'End If
                                Catch ex As Exception
                                    Retval.FailedHistory.Items.Add("Update ID Fields InvoiceLines/Deposits FAILED " & reader("ID").ToString & "/" & reader("NewID").ToString)
                                    Retval.OverallResult = False
                                End Try
                                'End Using 'cmdUpdate

                                ' LicenceServiceChargeItemsTemp
                                SQLUpdate = "UPDATE LicenceServiceChargeItemsTemp SET InvoiceLineID = " & reader("NewID").ToString & " WHERE InvoiceLineID = " & reader("ID").ToString
                                'Using cmdUpdate As New SqlCommand(SQLUpdate, connection)
                                cmdUpdate.CommandText = SQLUpdate
                                Try
                                    RowsAffected = cmdUpdate.ExecuteNonQuery()
                                    'If RowsAffected > 0 Then
                                    '    'Retval.PassedHistory.Items.Add("Updated ID Fields InvoiceLines/LicenceServiceChargeItemsTemp " & reader("ID").ToString & "/" & reader("NewID").ToString)
                                    'End If
                                Catch ex As Exception
                                    Retval.FailedHistory.Items.Add("Update ID Fields InvoiceLines/LicenceServiceChargeItemsTemp FAILED " & reader("ID").ToString & "/" & reader("NewID").ToString)
                                    Retval.OverallResult = False
                                End Try
                                'End Using 'cmdUpdate

                                ' LicenceUnits
                                SQLUpdate = "UPDATE LicenceUnits SET InvoiceLineID = " & reader("NewID").ToString & " WHERE InvoiceLineID = " & reader("ID").ToString
                                'Using cmdUpdate As New SqlCommand(SQLUpdate, connection)
                                cmdUpdate.CommandText = SQLUpdate
                                Try
                                    RowsAffected = cmdUpdate.ExecuteNonQuery()
                                    'If RowsAffected > 0 Then
                                    '    'Retval.PassedHistory.Items.Add("Updated ID Fields InvoiceLines/LicenceUnits " & reader("ID").ToString & "/" & reader("NewID").ToString)
                                    'End If
                                Catch ex As Exception
                                    Retval.FailedHistory.Items.Add("Update ID Fields InvoiceLines/LicenceUnits FAILED " & reader("ID").ToString & "/" & reader("NewID").ToString)
                                    Retval.OverallResult = False
                                End Try
                                'End Using 'cmdUpdate

                                ' Payments
                                SQLUpdate = "UPDATE Payments SET InvoiceLineID = " & reader("NewID").ToString & " WHERE InvoiceLineID = " & reader("ID").ToString
                                'Using cmdUpdate As New SqlCommand(SQLUpdate, connection)
                                cmdUpdate.CommandText = SQLUpdate
                                Try
                                    RowsAffected = cmdUpdate.ExecuteNonQuery()
                                    'If RowsAffected > 0 Then
                                    '    'Retval.PassedHistory.Items.Add("Updated ID Fields InvoiceLines/Payments " & reader("ID").ToString & "/" & reader("NewID").ToString)
                                    'End If
                                Catch ex As Exception
                                    Retval.FailedHistory.Items.Add("Update ID Fields InvoiceLines/Payments FAILED " & reader("ID").ToString & "/" & reader("NewID").ToString)
                                    Retval.OverallResult = False
                                End Try
                                'End Using 'cmdUpdate

                                ' ServiceChargeItems
                                SQLUpdate = "UPDATE ServiceChargeItems SET InvoiceLineID = " & reader("NewID").ToString & " WHERE InvoiceLineID = " & reader("ID").ToString
                                'Using cmdUpdate As New SqlCommand(SQLUpdate, connection)
                                cmdUpdate.CommandText = SQLUpdate
                                Try
                                    RowsAffected = cmdUpdate.ExecuteNonQuery()
                                    'If RowsAffected > 0 Then
                                    '    'Retval.PassedHistory.Items.Add("Updated ID Fields InvoiceLines/ServiceChargeItems " & reader("ID").ToString & "/" & reader("NewID").ToString)
                                    'End If
                                Catch ex As Exception
                                    Retval.FailedHistory.Items.Add("Update ID Fields InvoiceLines/ServiceChargeItems FAILED " & reader("ID").ToString & "/" & reader("NewID").ToString)
                                    Retval.OverallResult = False
                                End Try
                                'End Using 'cmdUpdate

                                ' ServiceChargeUnits
                                SQLUpdate = "UPDATE ServiceChargeUnits SET InvoiceLineID = " & reader("NewID").ToString & " WHERE InvoiceLineID = " & reader("ID").ToString
                                'Using cmdUpdate As New SqlCommand(SQLUpdate, connection)
                                cmdUpdate.CommandText = SQLUpdate
                                Try
                                    RowsAffected = cmdUpdate.ExecuteNonQuery()
                                    'If RowsAffected > 0 Then
                                    '    'Retval.PassedHistory.Items.Add("Updated ID Fields InvoiceLines/ServiceChargeUnits " & reader("ID").ToString & "/" & reader("NewID").ToString)
                                    'End If
                                Catch ex As Exception
                                    Retval.FailedHistory.Items.Add("Update ID Fields InvoiceLines/ServiceChargeUnits FAILED " & reader("ID").ToString & "/" & reader("NewID").ToString)
                                    Retval.OverallResult = False
                                End Try
                            End Using 'cmdUpdate

                        Loop

                    End If

                End Using ' reader

            End Using ' cmd

        End Using ' connection

        Return Retval


    End Function

    Public Shared Function UpdateInvoicesIDs() As cMultiValueReturn

        Dim SQLstring As String = ""
        Dim SQLUpdate As String = ""
        Dim RowsAffected As Integer
        Dim Retval As New cMultiValueReturn

        ' ID is the original old ID from the local database
        SQLstring = "SELECT NewID, ID FROM Invoices"

        Using connection As SqlConnection = DBConnection.GetConnectionIntermediate

            connection.Open()

            Using cmd As New SqlCommand(SQLstring, connection)

                Using reader As SqlDataReader = cmd.ExecuteReader

                    If reader.HasRows Then

                        Do While reader.Read

                            ' update related table data here
                            ' DeletedInvoices
                            SQLUpdate = "UPDATE DeletedInvoices SET InvoiceID = " & reader("NewID").ToString & " WHERE InvoiceID = " & reader("ID").ToString
                            Using cmdUpdate As New SqlCommand(SQLUpdate, connection)
                                Try
                                    RowsAffected = cmdUpdate.ExecuteNonQuery()
                                    'If RowsAffected > 0 Then
                                    '    Retval.PassedHistory.Items.Add("Updated ID Fields Invoices/DeletedInvoices " & reader("ID").ToString & "/" & reader("NewID").ToString)
                                    'End If
                                Catch ex As Exception
                                    Retval.FailedHistory.Items.Add("Update ID Fields Invoices/DeletedInvoices FAILED " & reader("ID").ToString & "/" & reader("NewID").ToString)
                                    Retval.OverallResult = False
                                End Try
                                'End Using 'cmdUpdate

                                ' InvoiceLines
                                SQLUpdate = "UPDATE InvoiceLines SET InvoiceID = " & reader("NewID").ToString & " WHERE InvoiceID = " & reader("ID").ToString
                                'Using cmdUpdate As New SqlCommand(SQLUpdate, connection)
                                cmdUpdate.CommandText = SQLUpdate
                                Try
                                    RowsAffected = cmdUpdate.ExecuteNonQuery()
                                    'If RowsAffected > 0 Then
                                    '    Retval.PassedHistory.Items.Add("Updated ID Fields Invoices/InvoiceLines " & reader("ID").ToString & "/" & reader("NewID").ToString)
                                    'End If
                                Catch ex As Exception
                                    Retval.FailedHistory.Items.Add("Update ID Fields Invoices/InvoiceLines FAILED " & reader("ID").ToString & "/" & reader("NewID").ToString)
                                    Retval.OverallResult = False
                                End Try
                            End Using 'cmdUpdate

                        Loop

                    End If

                End Using ' reader

            End Using ' cmd

        End Using ' connection

        Return Retval

    End Function

    Public Shared Function UpdateLicencesIDs() As cMultiValueReturn

        Dim SQLstring As String = ""
        Dim SQLUpdate As String = ""
        Dim RowsAffected As Integer
        Dim Retval As New cMultiValueReturn

        ' ID is the original old ID from the local database
        SQLstring = "SELECT NewID, ID FROM Licences"

        Using connection As SqlConnection = DBConnection.GetConnectionIntermediate

            connection.Open()

            Using cmd As New SqlCommand(SQLstring, connection)

                Using reader As SqlDataReader = cmd.ExecuteReader

                    If reader.HasRows Then

                        Do While reader.Read

                            ' update related table data here
                            ' Deposits
                            SQLUpdate = "UPDATE Deposits SET LicenceID = " & reader("NewID").ToString & " WHERE LicenceID = " & reader("ID").ToString
                            Using cmdUpdate As New SqlCommand(SQLUpdate, connection)
                                Try
                                    RowsAffected = cmdUpdate.ExecuteNonQuery()
                                    'If RowsAffected > 0 Then
                                    '    Retval.PassedHistory.Items.Add("Updated ID Fields Licences/Deposits " & reader("ID").ToString & "/" & reader("NewID").ToString)
                                    'End If
                                Catch ex As Exception
                                    Retval.FailedHistory.Items.Add("Update ID Fields Licences/Deposits FAILED " & reader("ID").ToString & "/" & reader("NewID").ToString)
                                    Retval.OverallResult = False
                                End Try
                                'End Using 'cmdUpdate

                                ' LicenceRooms
                                SQLUpdate = "UPDATE LicenceRooms SET LicenceID = " & reader("NewID").ToString & " WHERE LicenceID = " & reader("ID").ToString
                                'Using cmdUpdate As New SqlCommand(SQLUpdate, connection)
                                cmdUpdate.CommandText = SQLUpdate
                                Try
                                    RowsAffected = cmdUpdate.ExecuteNonQuery()
                                    'If RowsAffected > 0 Then
                                    '    Retval.PassedHistory.Items.Add("Updated ID Fields Licences/LicenceRooms " & reader("ID").ToString & "/" & reader("NewID").ToString)
                                    'End If
                                Catch ex As Exception
                                    Retval.FailedHistory.Items.Add("Update ID Fields Licences/LicenceRooms FAILED " & reader("ID").ToString & "/" & reader("NewID").ToString)
                                    Retval.OverallResult = False
                                End Try
                                'End Using 'cmdUpdate

                                ' LicenceServiceChargeItems
                                SQLUpdate = "UPDATE LicenceServiceChargeItems SET LicenceID = " & reader("NewID").ToString & " WHERE LicenceID = " & reader("ID").ToString
                                'Using cmdUpdate As New SqlCommand(SQLUpdate, connection)
                                cmdUpdate.CommandText = SQLUpdate
                                Try
                                    RowsAffected = cmdUpdate.ExecuteNonQuery()
                                    'If RowsAffected > 0 Then
                                    '    Retval.PassedHistory.Items.Add("Updated ID Fields Licences/LicenceServiceChargeItems " & reader("ID").ToString & "/" & reader("NewID").ToString)
                                    'End If
                                Catch ex As Exception
                                    Retval.FailedHistory.Items.Add("Update ID Fields Licences/LicenceServiceChargeItems FAILED " & reader("ID").ToString & "/" & reader("NewID").ToString)
                                    Retval.OverallResult = False
                                End Try
                                'End Using 'cmdUpdate

                                ' LicenceTaperHeader
                                SQLUpdate = "UPDATE LicenceTaperHeader SET LicenceID = " & reader("NewID").ToString & " WHERE LicenceID = " & reader("ID").ToString
                                'Using cmdUpdate As New SqlCommand(SQLUpdate, connection)
                                cmdUpdate.CommandText = SQLUpdate
                                Try
                                    RowsAffected = cmdUpdate.ExecuteNonQuery()
                                    'If RowsAffected > 0 Then
                                    '    Retval.PassedHistory.Items.Add("Updated ID Fields Licences/LicenceTaperHeader " & reader("ID").ToString & "/" & reader("NewID").ToString)
                                    'End If
                                Catch ex As Exception
                                    Retval.FailedHistory.Items.Add("Update ID Fields Licences/LicenceTaperHeader FAILED " & reader("ID").ToString & "/" & reader("NewID").ToString)
                                    Retval.OverallResult = False
                                End Try
                                'End Using 'cmdUpdate

                                ' LicenceUnits
                                SQLUpdate = "UPDATE LicenceUnits SET LicenceID = " & reader("NewID").ToString & " WHERE LicenceID = " & reader("ID").ToString
                                'Using cmdUpdate As New SqlCommand(SQLUpdate, connection)
                                cmdUpdate.CommandText = SQLUpdate
                                Try
                                    RowsAffected = cmdUpdate.ExecuteNonQuery()
                                    'If RowsAffected > 0 Then
                                    '    Retval.PassedHistory.Items.Add("Updated ID Fields Licences/LicenceUnits " & reader("ID").ToString & "/" & reader("NewID").ToString)
                                    'End If
                                Catch ex As Exception
                                    Retval.FailedHistory.Items.Add("Update ID Fields Licences/LicenceUnits FAILED " & reader("ID").ToString & "/" & reader("NewID").ToString)
                                    Retval.OverallResult = False
                                End Try
                                'End Using 'cmdUpdate

                                ' ServiceChargeUnits
                                SQLUpdate = "UPDATE ServiceChargeUnits SET LicenceID = " & reader("NewID").ToString & " WHERE LicenceID = " & reader("ID").ToString
                                'Using cmdUpdate As New SqlCommand(SQLUpdate, connection)
                                cmdUpdate.CommandText = SQLUpdate
                                Try
                                    RowsAffected = cmdUpdate.ExecuteNonQuery()
                                    'If RowsAffected > 0 Then
                                    '    Retval.PassedHistory.Items.Add("Updated ID Fields Licences/ServiceChargeUnits " & reader("ID").ToString & "/" & reader("NewID").ToString)
                                    'End If
                                Catch ex As Exception
                                    Retval.FailedHistory.Items.Add("Update ID Fields Licences/ServiceChargeUnits FAILED " & reader("ID").ToString & "/" & reader("NewID").ToString)
                                    Retval.OverallResult = False
                                End Try
                            End Using 'cmdUpdate

                        Loop

                    End If

                End Using ' reader

            End Using ' cmd

        End Using ' connection

        Return Retval



    End Function

    Public Shared Function UpdateLicenceTaperHeaderIDs() As cMultiValueReturn

        Dim SQLstring As String = ""
        Dim SQLUpdate As String = ""
        Dim RowsAffected As Integer
        Dim Retval As New cMultiValueReturn

        ' ID is the original old ID from the local database
        SQLstring = "SELECT NewID, ID FROM LicenceTaperHeader"

        Using connection As SqlConnection = DBConnection.GetConnectionIntermediate

            connection.Open()

            Using cmd As New SqlCommand(SQLstring, connection)

                Using reader As SqlDataReader = cmd.ExecuteReader

                    If reader.HasRows Then

                        Do While reader.Read

                            ' update related table data here
                            ' LicenceTaperDetail
                            SQLUpdate = "UPDATE LicenceTaperDetail SET LicenceTaperHeaderID = " & reader("NewID").ToString & " WHERE LicenceTaperHeaderID = " & reader("ID").ToString
                            Using cmdUpdate As New SqlCommand(SQLUpdate, connection)
                                Try
                                    RowsAffected = cmdUpdate.ExecuteNonQuery()
                                    'If RowsAffected > 0 Then
                                    '    Retval.PassedHistory.Items.Add("Updated ID Fields LicenceTaperHeader/LicenceTaperDetail " & reader("ID").ToString & "/" & reader("NewID").ToString)
                                    'End If
                                Catch ex As Exception
                                    Retval.FailedHistory.Items.Add("Update ID Fields LicenceTaperHeader/LicenceTaperDetail FAILED " & reader("ID").ToString & "/" & reader("NewID").ToString)
                                    Retval.OverallResult = False
                                End Try
                            End Using 'cmdUpdate

                        Loop

                    End If

                End Using ' reader

            End Using ' cmd

        End Using ' connection

        Return Retval

    End Function

    Public Shared Function UpdateMetersIDs() As cMultiValueReturn

        Dim SQLstring As String = ""
        Dim SQLUpdate As String = ""
        Dim RowsAffected As Integer
        Dim Retval As New cMultiValueReturn

        ' ID is the original old ID from the local database
        SQLstring = "SELECT NewID, ID FROM Meters"

        Using connection As SqlConnection = DBConnection.GetConnectionIntermediate

            connection.Open()

            Using cmd As New SqlCommand(SQLstring, connection)

                Using reader As SqlDataReader = cmd.ExecuteReader

                    If reader.HasRows Then

                        Do While reader.Read

                            ' update related table data here
                            ' MeterReadings
                            SQLUpdate = "UPDATE MeterReadings SET MeterID = " & reader("NewID").ToString & " WHERE MeterID = " & reader("ID").ToString
                            Using cmdUpdate As New SqlCommand(SQLUpdate, connection)
                                Try
                                    RowsAffected = cmdUpdate.ExecuteNonQuery()
                                    'If RowsAffected > 0 Then
                                    '    Retval.PassedHistory.Items.Add("Updated ID Fields Meters/MeterReadings " & reader("ID").ToString & "/" & reader("NewID").ToString)
                                    'End If
                                Catch ex As Exception
                                    Retval.FailedHistory.Items.Add("Update ID Fields Meters/MeterReadings FAILED " & reader("ID").ToString & "/" & reader("NewID").ToString)
                                    Retval.OverallResult = False
                                End Try
                            End Using 'cmdUpdate

                        Loop

                    End If

                End Using ' reader

            End Using ' cmd

        End Using ' connection

        Return Retval

    End Function

    Public Shared Function UpdatePaymentExportBatchesIDs() As cMultiValueReturn

        Dim SQLstring As String = ""
        Dim SQLUpdate As String = ""
        Dim RowsAffected As Integer
        Dim Retval As New cMultiValueReturn

        ' ID is the original old ID from the local database
        SQLstring = "SELECT NewID, ID FROM PaymentExportBatches"

        Using connection As SqlConnection = DBConnection.GetConnectionIntermediate

            connection.Open()

            Using cmd As New SqlCommand(SQLstring, connection)

                Using reader As SqlDataReader = cmd.ExecuteReader

                    If reader.HasRows Then

                        Do While reader.Read

                            ' update related table data here
                            ' Payments
                            SQLUpdate = "UPDATE Payments SET ExportBatchID = " & reader("NewID").ToString & " WHERE ExportBatchID = " & reader("ID").ToString
                            Using cmdUpdate As New SqlCommand(SQLUpdate, connection)
                                Try
                                    RowsAffected = cmdUpdate.ExecuteNonQuery()
                                    'If RowsAffected > 0 Then
                                    '    Retval.PassedHistory.Items.Add("Updated ID Fields PaymentExportBatches/Payments " & reader("ID").ToString & "/" & reader("NewID").ToString)
                                    'End If
                                Catch ex As Exception
                                    Retval.FailedHistory.Items.Add("Update ID Fields PaymentExportBatches/Payments FAILED " & reader("ID").ToString & "/" & reader("NewID").ToString)
                                    Retval.OverallResult = False
                                End Try
                            End Using 'cmdUpdate

                        Loop

                    End If

                End Using ' reader

            End Using ' cmd

        End Using ' connection

        Return Retval


    End Function

    Public Shared Function UpdatePersonsIDs() As cMultiValueReturn

        Dim SQLstring As String = ""
        Dim SQLUpdate As String = ""
        Dim RowsAffected As Integer
        Dim Retval As New cMultiValueReturn

        ' ID is the original old ID from the local database
        SQLstring = "SELECT NewID, ID FROM Persons"

        Using connection As SqlConnection = DBConnection.GetConnectionIntermediate

            connection.Open()

            Using cmd As New SqlCommand(SQLstring, connection)

                Using reader As SqlDataReader = cmd.ExecuteReader

                    If reader.HasRows Then

                        Do While reader.Read

                            ' update related table data here
                            ' Addresses
                            SQLUpdate = "UPDATE Addresses SET PersonID = " & reader("NewID").ToString & " WHERE PersonID = " & reader("ID").ToString
                            Using cmdUpdate As New SqlCommand(SQLUpdate, connection)
                                Try
                                    RowsAffected = cmdUpdate.ExecuteNonQuery()
                                    'If RowsAffected > 0 Then
                                    '    Retval.PassedHistory.Items.Add("Updated ID Fields Persons/Addresses " & reader("ID").ToString & "/" & reader("NewID").ToString)
                                    'End If
                                Catch ex As Exception
                                    Retval.FailedHistory.Items.Add("Update ID Fields Persons/Addresses FAILED " & reader("ID").ToString & "/" & reader("NewID").ToString)
                                    Retval.OverallResult = False
                                End Try
                                'End Using 'cmdUpdate

                                ' Announcements
                                SQLUpdate = "UPDATE Announcements SET PersonID = " & reader("NewID").ToString & " WHERE PersonID = " & reader("ID").ToString
                                'Using cmdUpdate As New SqlCommand(SQLUpdate, connection)
                                cmdUpdate.CommandText = SQLUpdate
                                Try
                                    RowsAffected = cmdUpdate.ExecuteNonQuery()
                                    'If RowsAffected > 0 Then
                                    '    Retval.PassedHistory.Items.Add("Updated ID Fields Persons/Announcements " & reader("ID").ToString & "/" & reader("NewID").ToString)
                                    'End If
                                Catch ex As Exception
                                    Retval.FailedHistory.Items.Add("Update ID Fields Persons/Announcements FAILED " & reader("ID").ToString & "/" & reader("NewID").ToString)
                                    Retval.OverallResult = False
                                End Try
                                'End Using 'cmdUpdate

                                ' Availability
                                SQLUpdate = "UPDATE Availability SET PersonID = " & reader("NewID").ToString & " WHERE PersonID = " & reader("ID").ToString
                                'Using cmdUpdate As New SqlCommand(SQLUpdate, connection)
                                cmdUpdate.CommandText = SQLUpdate
                                Try
                                    RowsAffected = cmdUpdate.ExecuteNonQuery()
                                    'If RowsAffected > 0 Then
                                    '    Retval.PassedHistory.Items.Add("Updated ID Fields Persons/Availability " & reader("ID").ToString & "/" & reader("NewID").ToString)
                                    'End If
                                Catch ex As Exception
                                    Retval.FailedHistory.Items.Add("Update ID Fields Persons/Availability FAILED " & reader("ID").ToString & "/" & reader("NewID").ToString)
                                    Retval.OverallResult = False
                                End Try
                                'End Using 'cmdUpdate

                                ' ClientPersons
                                SQLUpdate = "UPDATE ClientPersons SET PersonID = " & reader("NewID").ToString & " WHERE PersonID = " & reader("ID").ToString
                                'Using cmdUpdate As New SqlCommand(SQLUpdate, connection)
                                cmdUpdate.CommandText = SQLUpdate
                                Try
                                    RowsAffected = cmdUpdate.ExecuteNonQuery()
                                    'If RowsAffected > 0 Then
                                    '    Retval.PassedHistory.Items.Add("Updated ID Fields Persons/ClientPersons " & reader("ID").ToString & "/" & reader("NewID").ToString)
                                    'End If
                                Catch ex As Exception
                                    Retval.FailedHistory.Items.Add("Update ID Fields Persons/ClientPersons FAILED " & reader("ID").ToString & "/" & reader("NewID").ToString)
                                    Retval.OverallResult = False
                                End Try
                                'End Using 'cmdUpdate

                                ' CompanyPersons
                                SQLUpdate = "UPDATE CompanyPersons SET PersonID = " & reader("NewID").ToString & " WHERE PersonID = " & reader("ID").ToString
                                'Using cmdUpdate As New SqlCommand(SQLUpdate, connection)
                                cmdUpdate.CommandText = SQLUpdate
                                Try
                                    RowsAffected = cmdUpdate.ExecuteNonQuery()
                                    'If RowsAffected > 0 Then
                                    '    Retval.PassedHistory.Items.Add("Updated ID Fields Persons/CompanyPersons " & reader("ID").ToString & "/" & reader("NewID").ToString)
                                    'End If
                                Catch ex As Exception
                                    Retval.FailedHistory.Items.Add("Update ID Fields Persons/CompanyPersons FAILED " & reader("ID").ToString & "/" & reader("NewID").ToString)
                                    Retval.OverallResult = False
                                End Try
                                'End Using 'cmdUpdate

                                ' ContactHistory
                                SQLUpdate = "UPDATE ContactHistory SET PersonID = " & reader("NewID").ToString & " WHERE PersonID = " & reader("ID").ToString
                                'Using cmdUpdate As New SqlCommand(SQLUpdate, connection)
                                cmdUpdate.CommandText = SQLUpdate
                                Try
                                    RowsAffected = cmdUpdate.ExecuteNonQuery()
                                    'If RowsAffected > 0 Then
                                    '    Retval.PassedHistory.Items.Add("Updated ID Fields Persons/ContactHistory " & reader("ID").ToString & "/" & reader("NewID").ToString)
                                    'End If
                                Catch ex As Exception
                                    Retval.FailedHistory.Items.Add("Update ID Fields Persons/ContactHistory FAILED " & reader("ID").ToString & "/" & reader("NewID").ToString)
                                    Retval.OverallResult = False
                                End Try
                                'End Using 'cmdUpdate

                                ' Contacts
                                SQLUpdate = "UPDATE Contacts SET PersonID = " & reader("NewID").ToString & " WHERE PersonID = " & reader("ID").ToString
                                'Using cmdUpdate As New SqlCommand(SQLUpdate, connection)
                                cmdUpdate.CommandText = SQLUpdate
                                Try
                                    RowsAffected = cmdUpdate.ExecuteNonQuery()
                                    'If RowsAffected > 0 Then
                                    '    Retval.PassedHistory.Items.Add("Updated ID Fields Persons/Contacts " & reader("ID").ToString & "/" & reader("NewID").ToString)
                                    'End If
                                Catch ex As Exception
                                    Retval.FailedHistory.Items.Add("Update ID Fields Persons/Contacts FAILED " & reader("ID").ToString & "/" & reader("NewID").ToString)
                                    Retval.OverallResult = False
                                End Try
                                'End Using 'cmdUpdate

                                ' CouriersAndTaxis
                                SQLUpdate = "UPDATE CouriersAndTaxis SET PersonID = " & reader("NewID").ToString & " WHERE PersonID = " & reader("ID").ToString
                                'Using cmdUpdate As New SqlCommand(SQLUpdate, connection)
                                cmdUpdate.CommandText = SQLUpdate
                                Try
                                    RowsAffected = cmdUpdate.ExecuteNonQuery()
                                    'If RowsAffected > 0 Then
                                    '    Retval.PassedHistory.Items.Add("Updated ID Fields Persons/CouriersAndTaxis " & reader("ID").ToString & "/" & reader("NewID").ToString)
                                    'End If
                                Catch ex As Exception
                                    Retval.FailedHistory.Items.Add("Update ID Fields Persons/CouriersAndTaxis FAILED " & reader("ID").ToString & "/" & reader("NewID").ToString)
                                    Retval.OverallResult = False
                                End Try
                                'End Using 'cmdUpdate

                                ' Deliveries
                                SQLUpdate = "UPDATE Deliveries SET PersonID = " & reader("NewID").ToString & " WHERE PersonID = " & reader("ID").ToString
                                'Using cmdUpdate As New SqlCommand(SQLUpdate, connection)
                                cmdUpdate.CommandText = SQLUpdate
                                Try
                                    RowsAffected = cmdUpdate.ExecuteNonQuery()
                                    'If RowsAffected > 0 Then
                                    '    Retval.PassedHistory.Items.Add("Updated ID Fields Persons/Deliveries " & reader("ID").ToString & "/" & reader("NewID").ToString)
                                    'End If
                                Catch ex As Exception
                                    Retval.FailedHistory.Items.Add("Update ID Fields Persons/Deliveries FAILED " & reader("ID").ToString & "/" & reader("NewID").ToString)
                                    Retval.OverallResult = False
                                End Try
                                'End Using 'cmdUpdate

                                ' EmailAddresses
                                SQLUpdate = "UPDATE EmailAddresses SET PersonID = " & reader("NewID").ToString & " WHERE PersonID = " & reader("ID").ToString
                                'Using cmdUpdate As New SqlCommand(SQLUpdate, connection)
                                cmdUpdate.CommandText = SQLUpdate
                                Try
                                    RowsAffected = cmdUpdate.ExecuteNonQuery()
                                    'If RowsAffected > 0 Then
                                    '    Retval.PassedHistory.Items.Add("Updated ID Fields Persons/EmailAddresses " & reader("ID").ToString & "/" & reader("NewID").ToString)
                                    'End If
                                Catch ex As Exception
                                    Retval.FailedHistory.Items.Add("Update ID Fields Persons/EmailAddresses FAILED " & reader("ID").ToString & "/" & reader("NewID").ToString)
                                    Retval.OverallResult = False
                                End Try
                                'End Using 'cmdUpdate

                                ' Faxes
                                SQLUpdate = "UPDATE Faxes SET PersonID = " & reader("NewID").ToString & " WHERE PersonID = " & reader("ID").ToString
                                'Using cmdUpdate As New SqlCommand(SQLUpdate, connection)
                                cmdUpdate.CommandText = SQLUpdate
                                Try
                                    RowsAffected = cmdUpdate.ExecuteNonQuery()
                                    'If RowsAffected > 0 Then
                                    '    Retval.PassedHistory.Items.Add("Updated ID Fields Persons/Faxes " & reader("ID").ToString & "/" & reader("NewID").ToString)
                                    'End If
                                Catch ex As Exception
                                    Retval.FailedHistory.Items.Add("Update ID Fields Persons/Faxes FAILED " & reader("ID").ToString & "/" & reader("NewID").ToString)
                                    Retval.OverallResult = False
                                End Try
                                'End Using 'cmdUpdate

                                ' Instructions
                                SQLUpdate = "UPDATE Instructions SET PersonID = " & reader("NewID").ToString & " WHERE PersonID = " & reader("ID").ToString
                                'Using cmdUpdate As New SqlCommand(SQLUpdate, connection)
                                cmdUpdate.CommandText = SQLUpdate
                                Try
                                    RowsAffected = cmdUpdate.ExecuteNonQuery()
                                    'If RowsAffected > 0 Then
                                    '    Retval.PassedHistory.Items.Add("Updated ID Fields Persons/Instructions " & reader("ID").ToString & "/" & reader("NewID").ToString)
                                    'End If
                                Catch ex As Exception
                                    Retval.FailedHistory.Items.Add("Update ID Fields Persons/Instructions FAILED " & reader("ID").ToString & "/" & reader("NewID").ToString)
                                    Retval.OverallResult = False
                                End Try
                                'End Using 'cmdUpdate

                                ' Mail
                                SQLUpdate = "UPDATE Mail SET PersonID = " & reader("NewID").ToString & " WHERE PersonID = " & reader("ID").ToString
                                'Using cmdUpdate As New SqlCommand(SQLUpdate, connection)
                                cmdUpdate.CommandText = SQLUpdate
                                Try
                                    RowsAffected = cmdUpdate.ExecuteNonQuery()
                                    'If RowsAffected > 0 Then
                                    '    Retval.PassedHistory.Items.Add("Updated ID Fields Persons/Mail " & reader("ID").ToString & "/" & reader("NewID").ToString)
                                    'End If
                                Catch ex As Exception
                                    Retval.FailedHistory.Items.Add("Update ID Fields Persons/Mail FAILED " & reader("ID").ToString & "/" & reader("NewID").ToString)
                                    Retval.OverallResult = False
                                End Try
                                'End Using 'cmdUpdate

                                ' Messages
                                SQLUpdate = "UPDATE Messages SET PersonID = " & reader("NewID").ToString & " WHERE PersonID = " & reader("ID").ToString
                                'Using cmdUpdate As New SqlCommand(SQLUpdate, connection)
                                cmdUpdate.CommandText = SQLUpdate
                                Try
                                    RowsAffected = cmdUpdate.ExecuteNonQuery()
                                    'If RowsAffected > 0 Then
                                    '    Retval.PassedHistory.Items.Add("Updated ID Fields Persons/Messages " & reader("ID").ToString & "/" & reader("NewID").ToString)
                                    'End If
                                Catch ex As Exception
                                    Retval.FailedHistory.Items.Add("Update ID Fields Persons/Messages FAILED " & reader("ID").ToString & "/" & reader("NewID").ToString)
                                    Retval.OverallResult = False
                                End Try
                                'End Using 'cmdUpdate

                                ' PersonImages
                                SQLUpdate = "UPDATE PersonImages SET PersonID = " & reader("NewID").ToString & " WHERE PersonID = " & reader("ID").ToString
                                'Using cmdUpdate As New SqlCommand(SQLUpdate, connection)
                                cmdUpdate.CommandText = SQLUpdate
                                Try
                                    RowsAffected = cmdUpdate.ExecuteNonQuery()
                                    'If RowsAffected > 0 Then
                                    '    Retval.PassedHistory.Items.Add("Updated ID Fields Persons/PersonImages " & reader("ID").ToString & "/" & reader("NewID").ToString)
                                    'End If
                                Catch ex As Exception
                                    Retval.FailedHistory.Items.Add("Update ID Fields Persons/PersonImages FAILED " & reader("ID").ToString & "/" & reader("NewID").ToString)
                                    Retval.OverallResult = False
                                End Try
                                'End Using 'cmdUpdate

                                ' RoomBookings
                                SQLUpdate = "UPDATE RoomBookings SET PersonID = " & reader("NewID").ToString & " WHERE PersonID = " & reader("ID").ToString
                                'Using cmdUpdate As New SqlCommand(SQLUpdate, connection)
                                cmdUpdate.CommandText = SQLUpdate
                                Try
                                    RowsAffected = cmdUpdate.ExecuteNonQuery()
                                    'If RowsAffected > 0 Then
                                    '    Retval.PassedHistory.Items.Add("Updated ID Fields Persons/RoomBookings " & reader("ID").ToString & "/" & reader("NewID").ToString)
                                    'End If
                                Catch ex As Exception
                                    Retval.FailedHistory.Items.Add("Update ID Fields Persons/RoomBookings FAILED " & reader("ID").ToString & "/" & reader("NewID").ToString)
                                    Retval.OverallResult = False
                                End Try
                                'End Using 'cmdUpdate

                                ' Tasks
                                SQLUpdate = "UPDATE Tasks SET PersonID = " & reader("NewID").ToString & " WHERE PersonID = " & reader("ID").ToString
                                'Using cmdUpdate As New SqlCommand(SQLUpdate, connection)
                                cmdUpdate.CommandText = SQLUpdate
                                Try
                                    RowsAffected = cmdUpdate.ExecuteNonQuery()
                                    'If RowsAffected > 0 Then
                                    '    Retval.PassedHistory.Items.Add("Updated ID Fields Persons/Tasks " & reader("ID").ToString & "/" & reader("NewID").ToString)
                                    'End If
                                Catch ex As Exception
                                    Retval.FailedHistory.Items.Add("Update ID Fields Persons/Tasks FAILED " & reader("ID").ToString & "/" & reader("NewID").ToString)
                                    Retval.OverallResult = False
                                End Try
                                'End Using 'cmdUpdate

                                ' TelephoneNumbers
                                SQLUpdate = "UPDATE TelephoneNumbers SET PersonID = " & reader("NewID").ToString & " WHERE PersonID = " & reader("ID").ToString
                                'Using cmdUpdate As New SqlCommand(SQLUpdate, connection)
                                cmdUpdate.CommandText = SQLUpdate
                                Try
                                    RowsAffected = cmdUpdate.ExecuteNonQuery()
                                    'If RowsAffected > 0 Then
                                    '    Retval.PassedHistory.Items.Add("Updated ID Fields Persons/TelephoneNumbers " & reader("ID").ToString & "/" & reader("NewID").ToString)
                                    'End If
                                Catch ex As Exception
                                    Retval.FailedHistory.Items.Add("Update ID Fields Persons/TelephoneNumbers FAILED " & reader("ID").ToString & "/" & reader("NewID").ToString)
                                    Retval.OverallResult = False
                                End Try
                                'End Using 'cmdUpdate

                                ' Viewings
                                SQLUpdate = "UPDATE Viewings SET PersonID = " & reader("NewID").ToString & " WHERE PersonID = " & reader("ID").ToString
                                'Using cmdUpdate As New SqlCommand(SQLUpdate, connection)
                                cmdUpdate.CommandText = SQLUpdate
                                Try
                                    RowsAffected = cmdUpdate.ExecuteNonQuery()
                                    'If RowsAffected > 0 Then
                                    '    Retval.PassedHistory.Items.Add("Updated ID Fields Persons/Viewings " & reader("ID").ToString & "/" & reader("NewID").ToString)
                                    'End If
                                Catch ex As Exception
                                    Retval.FailedHistory.Items.Add("Update ID Fields Persons/Viewings FAILED " & reader("ID").ToString & "/" & reader("NewID").ToString)
                                    Retval.OverallResult = False
                                End Try
                                'End Using 'cmdUpdate

                                ' WebAddresses
                                SQLUpdate = "UPDATE WebAddresses SET PersonID = " & reader("NewID").ToString & " WHERE PersonID = " & reader("ID").ToString
                                'Using cmdUpdate As New SqlCommand(SQLUpdate, connection)
                                cmdUpdate.CommandText = SQLUpdate
                                Try
                                    RowsAffected = cmdUpdate.ExecuteNonQuery()
                                    'If RowsAffected > 0 Then
                                    '    Retval.PassedHistory.Items.Add("Updated ID Fields Persons/WebAddresses " & reader("ID").ToString & "/" & reader("NewID").ToString)
                                    'End If
                                Catch ex As Exception
                                    Retval.FailedHistory.Items.Add("Update ID Fields Persons/WebAddresses FAILED " & reader("ID").ToString & "/" & reader("NewID").ToString)
                                    Retval.OverallResult = False
                                End Try
                            End Using 'cmdUpdate

                        Loop

                    End If

                End Using ' reader

            End Using ' cmd

        End Using ' connection

        Return Retval

    End Function

    Public Shared Function UpdateRoomBookingsIDs() As cMultiValueReturn

        Dim SQLstring As String = ""
        Dim SQLUpdate As String = ""
        Dim RowsAffected As Integer
        Dim Retval As New cMultiValueReturn

        ' ID is the original old ID from the local database
        SQLstring = "SELECT NewID, ID FROM RoomBookings"

        Using connection As SqlConnection = DBConnection.GetConnectionIntermediate

            connection.Open()

            Using cmd As New SqlCommand(SQLstring, connection)

                Using reader As SqlDataReader = cmd.ExecuteReader

                    If reader.HasRows Then

                        Do While reader.Read

                            ' update related table data here
                            ' RoomBookingDelegates
                            SQLUpdate = "UPDATE RoomBookingDelegates SET RoomBookingID = " & reader("NewID").ToString & " WHERE RoomBookingID = " & reader("ID").ToString
                            Using cmdUpdate As New SqlCommand(SQLUpdate, connection)
                                Try
                                    RowsAffected = cmdUpdate.ExecuteNonQuery()
                                    'If RowsAffected > 0 Then
                                    '    Retval.PassedHistory.Items.Add("Updated ID Fields RoomBookings/RoomBookingDelegates " & reader("ID").ToString & "/" & reader("NewID").ToString)
                                    'End If
                                Catch ex As Exception
                                    Retval.FailedHistory.Items.Add("Update ID Fields RoomBookings/RoomBookingDelegates FAILED " & reader("ID").ToString & "/" & reader("NewID").ToString)
                                    Retval.OverallResult = False
                                End Try
                                'End Using 'cmdUpdate

                                ' RoomBookingDocuments
                                SQLUpdate = "UPDATE RoomBookingDocuments SET RoomBookingID = " & reader("NewID").ToString & " WHERE RoomBookingID = " & reader("ID").ToString
                                'Using cmdUpdate As New SqlCommand(SQLUpdate, connection)
                                cmdUpdate.CommandText = SQLUpdate
                                Try
                                    RowsAffected = cmdUpdate.ExecuteNonQuery()
                                    'If RowsAffected > 0 Then
                                    '    Retval.PassedHistory.Items.Add("Updated ID Fields RoomBookings/RoomBookingDocuments " & reader("ID").ToString & "/" & reader("NewID").ToString)
                                    'End If
                                Catch ex As Exception
                                    Retval.FailedHistory.Items.Add("Update ID Fields RoomBookings/RoomBookingDocuments FAILED " & reader("ID").ToString & "/" & reader("NewID").ToString)
                                    Retval.OverallResult = False
                                End Try
                                'End Using 'cmdUpdate

                                ' RoomBookingItemHistory
                                SQLUpdate = "UPDATE RoomBookingItemHistory SET RoomBookingID = " & reader("NewID").ToString & " WHERE RoomBookingID = " & reader("ID").ToString
                                'Using cmdUpdate As New SqlCommand(SQLUpdate, connection)
                                cmdUpdate.CommandText = SQLUpdate
                                Try
                                    RowsAffected = cmdUpdate.ExecuteNonQuery()
                                    'If RowsAffected > 0 Then
                                    '    Retval.PassedHistory.Items.Add("Updated ID Fields RoomBookings/RoomBookingItemHistory " & reader("ID").ToString & "/" & reader("NewID").ToString)
                                    'End If
                                Catch ex As Exception
                                    Retval.FailedHistory.Items.Add("Update ID Fields RoomBookings/RoomBookingItemHistory FAILED " & reader("ID").ToString & "/" & reader("NewID").ToString)
                                    Retval.OverallResult = False
                                End Try
                                'End Using 'cmdUpdate

                                ' RoomBookingServiceChargeItems
                                SQLUpdate = "UPDATE RoomBookingServiceChargeItems SET RoomBookingID = " & reader("NewID").ToString & " WHERE RoomBookingID = " & reader("ID").ToString
                                'Using cmdUpdate As New SqlCommand(SQLUpdate, connection)
                                cmdUpdate.CommandText = SQLUpdate
                                Try
                                    RowsAffected = cmdUpdate.ExecuteNonQuery()
                                    'If RowsAffected > 0 Then
                                    '    Retval.PassedHistory.Items.Add("Updated ID Fields RoomBookings/RoomBookingServiceChargeItems " & reader("ID").ToString & "/" & reader("NewID").ToString)
                                    'End If
                                Catch ex As Exception
                                    Retval.FailedHistory.Items.Add("Update ID Fields RoomBookings/RoomBookingServiceChargeItems FAILED " & reader("ID").ToString & "/" & reader("NewID").ToString)
                                    Retval.OverallResult = False
                                End Try
                                'End Using 'cmdUpdate

                                ' RoomBookingTasks
                                SQLUpdate = "UPDATE RoomBookingTasks SET RoomBookingID = " & reader("NewID").ToString & " WHERE RoomBookingID = " & reader("ID").ToString
                                'Using cmdUpdate As New SqlCommand(SQLUpdate, connection)
                                cmdUpdate.CommandText = SQLUpdate
                                Try
                                    RowsAffected = cmdUpdate.ExecuteNonQuery()
                                    'If RowsAffected > 0 Then
                                    '    Retval.PassedHistory.Items.Add("Updated ID Fields RoomBookings/RoomBookingTasks " & reader("ID").ToString & "/" & reader("NewID").ToString)
                                    'End If
                                Catch ex As Exception
                                    Retval.FailedHistory.Items.Add("Update ID Fields RoomBookings/RoomBookingTasks FAILED " & reader("ID").ToString & "/" & reader("NewID").ToString)
                                    Retval.OverallResult = False
                                End Try
                            End Using 'cmdUpdate

                        Loop

                    End If

                End Using ' reader

            End Using ' cmd

        End Using ' connection

        Return Retval

    End Function

    Public Shared Function UpdateRoomBookingStatusIDs() As cMultiValueReturn

        Dim SQLstring As String = ""
        Dim SQLUpdate As String = ""
        Dim RowsAffected As Integer
        Dim Retval As New cMultiValueReturn

        ' ID is the original old ID from the local database
        SQLstring = "SELECT NewID, ID FROM RoomBookingStatus"

        Using connection As SqlConnection = DBConnection.GetConnectionIntermediate

            connection.Open()

            Using cmd As New SqlCommand(SQLstring, connection)

                Using reader As SqlDataReader = cmd.ExecuteReader

                    If reader.HasRows Then

                        Do While reader.Read

                            ' update related table data here
                            ' RoomBookings
                            SQLUpdate = "UPDATE RoomBookings SET StatusID = " & reader("NewID").ToString & " WHERE StatusID = " & reader("ID").ToString
                            Using cmdUpdate As New SqlCommand(SQLUpdate, connection)
                                Try
                                    RowsAffected = cmdUpdate.ExecuteNonQuery()
                                    'If RowsAffected > 0 Then
                                    '    Retval.PassedHistory.Items.Add("Updated ID Fields RoomBookingStatus/RoomBookings " & reader("ID").ToString & "/" & reader("NewID").ToString)
                                    'End If
                                Catch ex As Exception
                                    Retval.FailedHistory.Items.Add("Update ID Fields RoomBookingStatus/RoomBookings FAILED " & reader("ID").ToString & "/" & reader("NewID").ToString)
                                    Retval.OverallResult = False
                                End Try
                            End Using 'cmdUpdate

                        Loop

                    End If

                End Using ' reader

            End Using ' cmd

        End Using ' connection

        Return Retval

    End Function

    Public Shared Function UpdateServiceChargeItemsIDs() As cMultiValueReturn

        Dim SQLstring As String = ""
        Dim SQLUpdate As String = ""
        Dim RowsAffected As Integer
        Dim Retval As New cMultiValueReturn

        ' ID is the original old ID from the local database
        SQLstring = "SELECT NewID, ID FROM ServiceChargeItems"

        Using connection As SqlConnection = DBConnection.GetConnectionIntermediate

            connection.Open()

            Using cmd As New SqlCommand(SQLstring, connection)

                Using reader As SqlDataReader = cmd.ExecuteReader

                    If reader.HasRows Then

                        Do While reader.Read

                            ' update related table data here
                            ' Faxes
                            SQLUpdate = "UPDATE Faxes SET SCID = " & reader("NewID").ToString & " WHERE SCID = " & reader("ID").ToString
                            Using cmdUpdate As New SqlCommand(SQLUpdate, connection)
                                Try
                                    RowsAffected = cmdUpdate.ExecuteNonQuery()
                                    'If RowsAffected > 0 Then
                                    '    Retval.PassedHistory.Items.Add("Updated ID Fields ServiceChargeItems/Faxes " & reader("ID").ToString & "/" & reader("NewID").ToString)
                                    'End If
                                Catch ex As Exception
                                    Retval.FailedHistory.Items.Add("Update ID Fields ServiceChargeItems/Faxes FAILED " & reader("ID").ToString & "/" & reader("NewID").ToString)
                                    Retval.OverallResult = False
                                End Try
                                'End Using 'cmdUpdate

                                ' FrontDeskNoteServiceCharges
                                SQLUpdate = "UPDATE FrontDeskNoteServiceCharges SET SCID = " & reader("NewID").ToString & " WHERE SCID = " & reader("ID").ToString
                                'Using cmdUpdate As New SqlCommand(SQLUpdate, connection)
                                cmdUpdate.CommandText = SQLUpdate
                                Try
                                    RowsAffected = cmdUpdate.ExecuteNonQuery()
                                    'If RowsAffected > 0 Then
                                    '    Retval.PassedHistory.Items.Add("Updated ID Fields ServiceChargeItems/FrontDeskNoteServiceCharges " & reader("ID").ToString & "/" & reader("NewID").ToString)
                                    'End If
                                Catch ex As Exception
                                    Retval.FailedHistory.Items.Add("Update ID Fields ServiceChargeItems/FrontDeskNoteServiceCharges FAILED " & reader("ID").ToString & "/" & reader("NewID").ToString)
                                    Retval.OverallResult = False
                                End Try
                                'End Using 'cmdUpdate

                                ' Mail
                                SQLUpdate = "UPDATE Mail SET SCID = " & reader("NewID").ToString & " WHERE SCID = " & reader("ID").ToString
                                'Using cmdUpdate As New SqlCommand(SQLUpdate, connection)
                                cmdUpdate.CommandText = SQLUpdate
                                Try
                                    RowsAffected = cmdUpdate.ExecuteNonQuery()
                                    'If RowsAffected > 0 Then
                                    '    Retval.PassedHistory.Items.Add("Updated ID Fields ServiceChargeItems/Mail " & reader("ID").ToString & "/" & reader("NewID").ToString)
                                    'End If
                                Catch ex As Exception
                                    Retval.FailedHistory.Items.Add("Update ID Fields ServiceChargeItems/Mail FAILED " & reader("ID").ToString & "/" & reader("NewID").ToString)
                                    Retval.OverallResult = False
                                End Try
                                'End Using 'cmdUpdate

                                ' RoomBookingServiceChargeItems
                                SQLUpdate = "UPDATE RoomBookingServiceChargeItems SET ServiceChargeItemID = " & reader("NewID").ToString & " WHERE ServiceChargeItemID = " & reader("ID").ToString
                                'Using cmdUpdate As New SqlCommand(SQLUpdate, connection)
                                cmdUpdate.CommandText = SQLUpdate
                                Try
                                    RowsAffected = cmdUpdate.ExecuteNonQuery()
                                    'If RowsAffected > 0 Then
                                    '    Retval.PassedHistory.Items.Add("Updated ID Fields ServiceChargeItems/RoomBookingServiceChargeItems " & reader("ID").ToString & "/" & reader("NewID").ToString)
                                    'End If
                                Catch ex As Exception
                                    Retval.FailedHistory.Items.Add("Update ID Fields ServiceChargeItems/RoomBookingServiceChargeItems FAILED " & reader("ID").ToString & "/" & reader("NewID").ToString)
                                    Retval.OverallResult = False
                                End Try
                                'End Using 'cmdUpdate

                                ' MeterReadings
                                SQLUpdate = "UPDATE MeterReadings SET SCItemID = " & reader("NewID").ToString & " WHERE SCItemID = " & reader("ID").ToString
                                'Using cmdUpdate As New SqlCommand(SQLUpdate, connection)
                                cmdUpdate.CommandText = SQLUpdate
                                Try
                                    RowsAffected = cmdUpdate.ExecuteNonQuery()
                                    'If RowsAffected > 0 Then
                                    '    Retval.PassedHistory.Items.Add("Updated ID Fields ServiceChargeItems/MeterReadings " & reader("ID").ToString & "/" & reader("NewID").ToString)
                                    'End If
                                Catch ex As Exception
                                    Retval.FailedHistory.Items.Add("Update ID Fields ServiceChargeItems/MeterReadings FAILED " & reader("ID").ToString & "/" & reader("NewID").ToString)
                                    Retval.OverallResult = False
                                End Try
                                'End Using 'cmdUpdate

                                ' RoomBookings
                                SQLUpdate = "UPDATE RoomBookings SET SCItemID = " & reader("NewID").ToString & " WHERE SCItemID = " & reader("ID").ToString
                                'Using cmdUpdate As New SqlCommand(SQLUpdate, connection)
                                cmdUpdate.CommandText = SQLUpdate
                                Try
                                    RowsAffected = cmdUpdate.ExecuteNonQuery()
                                    'If RowsAffected > 0 Then
                                    '    Retval.PassedHistory.Items.Add("Updated ID Fields ServiceChargeItems/RoomBookings " & reader("ID").ToString & "/" & reader("NewID").ToString)
                                    'End If
                                Catch ex As Exception
                                    Retval.FailedHistory.Items.Add("Update ID Fields ServiceChargeItems/RoomBookings FAILED " & reader("ID").ToString & "/" & reader("NewID").ToString)
                                    Retval.OverallResult = False
                                End Try
                            End Using 'cmdUpdate

                        Loop

                    End If

                End Using ' reader

            End Using ' cmd

        End Using ' connection

        Return Retval


    End Function

    Public Shared Function UpdateServiceChargeTypesIDs() As cMultiValueReturn

        Dim SQLstring As String = ""
        Dim SQLUpdate As String = ""
        Dim RowsAffected As Integer
        Dim Retval As New cMultiValueReturn

        ' ID is the original old ID from the local database
        SQLstring = "SELECT NewID, ID FROM ServiceChargeTypes"

        Using connection As SqlConnection = DBConnection.GetConnectionIntermediate

            connection.Open()

            Using cmd As New SqlCommand(SQLstring, connection)

                Using reader As SqlDataReader = cmd.ExecuteReader

                    If reader.HasRows Then

                        Do While reader.Read

                            ' update related table data here
                            ' Accommodations
                            SQLUpdate = "UPDATE Accommodations SET SCTypeID = " & reader("NewID").ToString & " WHERE SCTypeID = " & reader("ID").ToString
                            Using cmdUpdate As New SqlCommand(SQLUpdate, connection)
                                Try
                                    RowsAffected = cmdUpdate.ExecuteNonQuery()
                                    'If RowsAffected > 0 Then
                                    '    Retval.PassedHistory.Items.Add("Updated ID Fields ServiceChargeTypes/Accommodations " & reader("ID").ToString & "/" & reader("NewID").ToString)
                                    'End If
                                Catch ex As Exception
                                    Retval.FailedHistory.Items.Add("Update ID Fields ServiceChargeTypes/Accommodations FAILED " & reader("ID").ToString & "/" & reader("NewID").ToString)
                                    Retval.OverallResult = False
                                End Try
                                'End Using 'cmdUpdate

                                ' LicenceServiceChargeItems
                                SQLUpdate = "UPDATE LicenceServiceChargeItems SET SCTypeID = " & reader("NewID").ToString & " WHERE SCTypeID = " & reader("ID").ToString
                                'Using cmdUpdate As New SqlCommand(SQLUpdate, connection)
                                cmdUpdate.CommandText = SQLUpdate
                                Try
                                    RowsAffected = cmdUpdate.ExecuteNonQuery()
                                    'If RowsAffected > 0 Then
                                    '    Retval.PassedHistory.Items.Add("Updated ID Fields ServiceChargeTypes/LicenceServiceChargeItems " & reader("ID").ToString & "/" & reader("NewID").ToString)
                                    'End If
                                Catch ex As Exception
                                    Retval.FailedHistory.Items.Add("Update ID Fields ServiceChargeTypes/LicenceServiceChargeItems FAILED " & reader("ID").ToString & "/" & reader("NewID").ToString)
                                    Retval.OverallResult = False
                                End Try
                                'End Using 'cmdUpdate

                                ' LicenceServiceChargeItemsTemp
                                SQLUpdate = "UPDATE LicenceServiceChargeItemsTemp SET SCTypeID = " & reader("NewID").ToString & " WHERE SCTypeID = " & reader("ID").ToString
                                'Using cmdUpdate As New SqlCommand(SQLUpdate, connection)
                                cmdUpdate.CommandText = SQLUpdate
                                Try
                                    RowsAffected = cmdUpdate.ExecuteNonQuery()
                                    'If RowsAffected > 0 Then
                                    '    Retval.PassedHistory.Items.Add("Updated ID Fields ServiceChargeTypes/LicenceServiceChargeItemsTemp " & reader("ID").ToString & "/" & reader("NewID").ToString)
                                    'End If
                                Catch ex As Exception
                                    Retval.FailedHistory.Items.Add("Update ID Fields ServiceChargeTypes/LicenceServiceChargeItemsTemp FAILED " & reader("ID").ToString & "/" & reader("NewID").ToString)
                                    Retval.OverallResult = False
                                End Try
                                'End Using 'cmdUpdate

                                ' Meters
                                SQLUpdate = "UPDATE Meters SET SCTypeID = " & reader("NewID").ToString & " WHERE SCTypeID = " & reader("ID").ToString
                                'Using cmdUpdate As New SqlCommand(SQLUpdate, connection)
                                cmdUpdate.CommandText = SQLUpdate
                                Try
                                    RowsAffected = cmdUpdate.ExecuteNonQuery()
                                    'If RowsAffected > 0 Then
                                    '    Retval.PassedHistory.Items.Add("Updated ID Fields ServiceChargeTypes/Meters " & reader("ID").ToString & "/" & reader("NewID").ToString)
                                    'End If
                                Catch ex As Exception
                                    Retval.FailedHistory.Items.Add("Update ID Fields ServiceChargeTypes/Meters FAILED " & reader("ID").ToString & "/" & reader("NewID").ToString)
                                    Retval.OverallResult = False
                                End Try
                                'End Using 'cmdUpdate

                                ' ServiceChargeItems
                                SQLUpdate = "UPDATE ServiceChargeItems SET SCTypeID = " & reader("NewID").ToString & " WHERE SCTypeID = " & reader("ID").ToString
                                'Using cmdUpdate As New SqlCommand(SQLUpdate, connection)
                                cmdUpdate.CommandText = SQLUpdate
                                Try
                                    RowsAffected = cmdUpdate.ExecuteNonQuery()
                                    'If RowsAffected > 0 Then
                                    '    Retval.PassedHistory.Items.Add("Updated ID Fields ServiceChargeTypes/ServiceChargeItems " & reader("ID").ToString & "/" & reader("NewID").ToString)
                                    'End If
                                Catch ex As Exception
                                    Retval.FailedHistory.Items.Add("Update ID Fields ServiceChargeTypes/ServiceChargeItems FAILED " & reader("ID").ToString & "/" & reader("NewID").ToString)
                                    Retval.OverallResult = False
                                End Try
                            End Using 'cmdUpdate

                        Loop

                    End If

                End Using ' reader

            End Using ' cmd

        End Using ' connection

        Return Retval


    End Function

    Public Shared Function UpdateTaskPriorityIDs() As cMultiValueReturn

        Dim SQLstring As String = ""
        Dim SQLUpdate As String = ""
        Dim RowsAffected As Integer
        Dim Retval As New cMultiValueReturn

        ' ID is the original old ID from the local database
        SQLstring = "SELECT NewID, ID FROM TaskPriority"

        Using connection As SqlConnection = DBConnection.GetConnectionIntermediate

            connection.Open()

            Using cmd As New SqlCommand(SQLstring, connection)

                Using reader As SqlDataReader = cmd.ExecuteReader

                    If reader.HasRows Then

                        Do While reader.Read

                            ' update related table data here
                            ' Tasks
                            SQLUpdate = "UPDATE Tasks SET PriorityID = " & reader("NewID").ToString & " WHERE PriorityID = " & reader("ID").ToString
                            Using cmdUpdate As New SqlCommand(SQLUpdate, connection)
                                Try
                                    RowsAffected = cmdUpdate.ExecuteNonQuery()
                                    'If RowsAffected > 0 Then
                                    '    Retval.PassedHistory.Items.Add("Updated ID Fields TaskPriority/Tasks " & reader("ID").ToString & "/" & reader("NewID").ToString)
                                    'End If
                                Catch ex As Exception
                                    Retval.FailedHistory.Items.Add("Update ID Fields TaskPriority/Tasks FAILED " & reader("ID").ToString & "/" & reader("NewID").ToString)
                                    Retval.OverallResult = False
                                End Try
                            End Using 'cmdUpdate

                        Loop

                    End If

                End Using ' reader

            End Using ' cmd

        End Using ' connection

        Return Retval

    End Function

    Public Shared Function UpdateTasksIDs() As cMultiValueReturn

        Dim SQLstring As String = ""
        Dim SQLUpdate As String = ""
        Dim RowsAffected As Integer
        Dim Retval As New cMultiValueReturn

        ' ID is the original old ID from the local database
        SQLstring = "SELECT NewID, ID FROM Tasks"

        Using connection As SqlConnection = DBConnection.GetConnectionIntermediate

            connection.Open()

            Using cmd As New SqlCommand(SQLstring, connection)

                Using reader As SqlDataReader = cmd.ExecuteReader

                    If reader.HasRows Then

                        Do While reader.Read

                            ' update related table data here
                            ' ContactHistoryTasks
                            SQLUpdate = "UPDATE ContactHistoryTasks SET TaskID = " & reader("NewID").ToString & " WHERE TaskID = " & reader("ID").ToString
                            Using cmdUpdate As New SqlCommand(SQLUpdate, connection)
                                Try
                                    RowsAffected = cmdUpdate.ExecuteNonQuery()
                                    'If RowsAffected > 0 Then
                                    '    Retval.PassedHistory.Items.Add("Updated ID Fields Tasks/ContactHistoryTasks " & reader("ID").ToString & "/" & reader("NewID").ToString)
                                    'End If
                                Catch ex As Exception
                                    Retval.FailedHistory.Items.Add("Update ID Fields Tasks/ContactHistoryTasks FAILED " & reader("ID").ToString & "/" & reader("NewID").ToString)
                                    Retval.OverallResult = False
                                End Try
                                'End Using 'cmdUpdate

                                ' FrontDeskNoteTasks
                                SQLUpdate = "UPDATE FrontDeskNoteTasks SET TaskID = " & reader("NewID").ToString & " WHERE TaskID = " & reader("ID").ToString
                                'Using cmdUpdate As New SqlCommand(SQLUpdate, connection)
                                cmdUpdate.CommandText = SQLUpdate
                                Try
                                    RowsAffected = cmdUpdate.ExecuteNonQuery()
                                    'If RowsAffected > 0 Then
                                    '    Retval.PassedHistory.Items.Add("Updated ID Fields Tasks/FrontDeskNoteTasks " & reader("ID").ToString & "/" & reader("NewID").ToString)
                                    'End If
                                Catch ex As Exception
                                    Retval.FailedHistory.Items.Add("Update ID Fields Tasks/FrontDeskNoteTasks FAILED " & reader("ID").ToString & "/" & reader("NewID").ToString)
                                    Retval.OverallResult = False
                                End Try
                                'End Using 'cmdUpdate

                                ' RoomBookingTasks
                                SQLUpdate = "UPDATE RoomBookingTasks SET TaskID = " & reader("NewID").ToString & " WHERE TaskID = " & reader("ID").ToString
                                'Using cmdUpdate As New SqlCommand(SQLUpdate, connection)
                                cmdUpdate.CommandText = SQLUpdate
                                Try
                                    RowsAffected = cmdUpdate.ExecuteNonQuery()
                                    'If RowsAffected > 0 Then
                                    '    Retval.PassedHistory.Items.Add("Updated ID Fields Tasks/RoomBookingTasks " & reader("ID").ToString & "/" & reader("NewID").ToString)
                                    'End If
                                Catch ex As Exception
                                    Retval.FailedHistory.Items.Add("Update ID Fields Tasks/RoomBookingTasks FAILED " & reader("ID").ToString & "/" & reader("NewID").ToString)
                                    Retval.OverallResult = False
                                End Try
                                'End Using 'cmdUpdate

                                ' TaskDocuments
                                SQLUpdate = "UPDATE TaskDocuments SET TaskID = " & reader("NewID").ToString & " WHERE TaskID = " & reader("ID").ToString
                                'Using cmdUpdate As New SqlCommand(SQLUpdate, connection)
                                cmdUpdate.CommandText = SQLUpdate
                                Try
                                    RowsAffected = cmdUpdate.ExecuteNonQuery()
                                    'If RowsAffected > 0 Then
                                    '    Retval.PassedHistory.Items.Add("Updated ID Fields Tasks/TaskDocuments " & reader("ID").ToString & "/" & reader("NewID").ToString)
                                    'End If
                                Catch ex As Exception
                                    Retval.FailedHistory.Items.Add("Update ID Fields Tasks/TaskDocuments FAILED " & reader("ID").ToString & "/" & reader("NewID").ToString)
                                    Retval.OverallResult = False
                                End Try
                                'End Using 'cmdUpdate

                                ' TaskHistory
                                SQLUpdate = "UPDATE TaskHistory SET TaskID = " & reader("NewID").ToString & " WHERE TaskID = " & reader("ID").ToString
                                'Using cmdUpdate As New SqlCommand(SQLUpdate, connection)
                                cmdUpdate.CommandText = SQLUpdate
                                Try
                                    RowsAffected = cmdUpdate.ExecuteNonQuery()
                                    'If RowsAffected > 0 Then
                                    '    Retval.PassedHistory.Items.Add("Updated ID Fields Tasks/TaskHistory " & reader("ID").ToString & "/" & reader("NewID").ToString)
                                    'End If
                                Catch ex As Exception
                                    Retval.FailedHistory.Items.Add("Update ID Fields Tasks/TaskHistory FAILED " & reader("ID").ToString & "/" & reader("NewID").ToString)
                                    Retval.OverallResult = False
                                End Try
                            End Using 'cmdUpdate

                        Loop

                    End If

                End Using ' reader

            End Using ' cmd

        End Using ' connection

        Return Retval


    End Function

    Public Shared Function UpdateTaskStatusIDs() As cMultiValueReturn

        Dim SQLstring As String = ""
        Dim SQLUpdate As String = ""
        Dim RowsAffected As Integer
        Dim Retval As New cMultiValueReturn

        ' ID is the original old ID from the local database
        SQLstring = "SELECT NewID, ID FROM TaskStatus"

        Using connection As SqlConnection = DBConnection.GetConnectionIntermediate

            connection.Open()

            Using cmd As New SqlCommand(SQLstring, connection)

                Using reader As SqlDataReader = cmd.ExecuteReader

                    If reader.HasRows Then

                        Do While reader.Read

                            ' update related table data here
                            ' Tasks
                            SQLUpdate = "UPDATE Tasks SET StatusID = " & reader("NewID").ToString & " WHERE StatusID = " & reader("ID").ToString
                            Using cmdUpdate As New SqlCommand(SQLUpdate, connection)
                                Try
                                    RowsAffected = cmdUpdate.ExecuteNonQuery()
                                    'If RowsAffected > 0 Then
                                    '    Retval.PassedHistory.Items.Add("Updated ID Fields TaskStatus/Tasks " & reader("ID").ToString & "/" & reader("NewID").ToString)
                                    'End If
                                Catch ex As Exception
                                    Retval.FailedHistory.Items.Add("Update ID Fields TaskStatus/Tasks FAILED " & reader("ID").ToString & "/" & reader("NewID").ToString)
                                    Retval.OverallResult = False
                                End Try
                            End Using 'cmdUpdate

                        Loop

                    End If

                End Using ' reader

            End Using ' cmd

        End Using ' connection

        Return Retval


    End Function

    Public Shared Function UpdateUserGroupIDs() As cMultiValueReturn

        Dim SQLstring As String = ""
        Dim SQLUpdate As String = ""
        Dim RowsAffected As Integer
        Dim Retval As New cMultiValueReturn

        ' ID is the original old ID from the local database
        SQLstring = "SELECT NewID, ID FROM UserGroups"

        Using connection As SqlConnection = DBConnection.GetConnectionIntermediate

            connection.Open()

            Using cmd As New SqlCommand(SQLstring, connection)

                Using reader As SqlDataReader = cmd.ExecuteReader

                    If reader.HasRows Then

                        Do While reader.Read

                            ' update related table data here
                            ' UserList
                            SQLUpdate = "UPDATE UserList SET UserGroupID = " & reader("NewID").ToString & " WHERE UserGroupID = " & reader("ID").ToString
                            Using cmdUpdate As New SqlCommand(SQLUpdate, connection)
                                Try
                                    RowsAffected = cmdUpdate.ExecuteNonQuery()
                                    'If RowsAffected > 0 Then
                                    '    Retval.PassedHistory.Items.Add("Updated ID Fields UserGroups/UserList " & reader("ID").ToString & "/" & reader("NewID").ToString)
                                    'End If
                                Catch ex As Exception
                                    Retval.FailedHistory.Items.Add("Update ID Fields UserGroups/UserList FAILED " & reader("ID").ToString & "/" & reader("NewID").ToString)
                                    Retval.OverallResult = False
                                End Try
                            End Using 'cmdUpdate

                        Loop

                    End If

                End Using ' reader

            End Using ' cmd

        End Using ' connection

        Return Retval


    End Function

    Public Shared Function UpdateUserListIDs() As cMultiValueReturn

        Dim SQLstring As String = ""
        Dim SQLUpdate As String = ""
        Dim RowsAffected As Integer
        Dim Retval As New cMultiValueReturn

        ' ID is the original old ID from the local database
        SQLstring = "SELECT NewID, ID FROM UserList"

        Using connection As SqlConnection = DBConnection.GetConnectionIntermediate

            connection.Open()

            Using cmd As New SqlCommand(SQLstring, connection)

                Using reader As SqlDataReader = cmd.ExecuteReader

                    If reader.HasRows Then

                        Do While reader.Read

                            ' update related table data here
                            ' AssetHistory
                            SQLUpdate = "UPDATE AssetHistory SET UserID = " & reader("NewID").ToString & " WHERE UserID = " & reader("ID").ToString
                            Using cmdUpdate As New SqlCommand(SQLUpdate, connection)
                                Try
                                    RowsAffected = cmdUpdate.ExecuteNonQuery()
                                    'If RowsAffected > 0 Then
                                    '    Retval.PassedHistory.Items.Add("Updated ID Fields UserList/AssetHistory " & reader("ID").ToString & "/" & reader("NewID").ToString)
                                    'End If
                                Catch ex As Exception
                                    Retval.FailedHistory.Items.Add("Update ID Fields UserList/AssetHistory FAILED " & reader("ID").ToString & "/" & reader("NewID").ToString)
                                    Retval.OverallResult = False
                                End Try
                                'End Using 'cmdUpdate

                                ' Filters
                                SQLUpdate = "UPDATE Filters SET FilterUserID = " & reader("NewID").ToString & " WHERE FilterUserID = " & reader("ID").ToString
                                'Using cmdUpdate As New SqlCommand(SQLUpdate, connection)
                                cmdUpdate.CommandText = SQLUpdate
                                Try
                                    RowsAffected = cmdUpdate.ExecuteNonQuery()
                                    'If RowsAffected > 0 Then
                                    '    Retval.PassedHistory.Items.Add("Updated ID Fields UserList/Filters " & reader("ID").ToString & "/" & reader("NewID").ToString)
                                    'End If
                                Catch ex As Exception
                                    Retval.FailedHistory.Items.Add("Update ID Fields UserList/Filters FAILED " & reader("ID").ToString & "/" & reader("NewID").ToString)
                                    Retval.OverallResult = False
                                End Try
                                'End Using 'cmdUpdate

                                SQLUpdate = "UPDATE Filters SET UserID = " & reader("NewID").ToString & " WHERE UserID = " & reader("ID").ToString
                                'Using cmdUpdate As New SqlCommand(SQLUpdate, connection)
                                cmdUpdate.CommandText = SQLUpdate
                                Try
                                    RowsAffected = cmdUpdate.ExecuteNonQuery()
                                    'If RowsAffected > 0 Then
                                    '    Retval.PassedHistory.Items.Add("Updated ID Fields UserList/Filters " & reader("ID").ToString & "/" & reader("NewID").ToString)
                                    'End If
                                Catch ex As Exception
                                    Retval.FailedHistory.Items.Add("Update ID Fields UserList/Filters FAILED " & reader("ID").ToString & "/" & reader("NewID").ToString)
                                    Retval.OverallResult = False
                                End Try
                                'End Using 'cmdUpdate

                                SQLUpdate = "UPDATE Filters SET FilterCreatorID = " & reader("NewID").ToString & " WHERE FilterCreatorID = " & reader("ID").ToString
                                'Using cmdUpdate As New SqlCommand(SQLUpdate, connection)
                                cmdUpdate.CommandText = SQLUpdate
                                Try
                                    RowsAffected = cmdUpdate.ExecuteNonQuery()
                                    'If RowsAffected > 0 Then
                                    '    Retval.PassedHistory.Items.Add("Updated ID Fields UserList/Filters " & reader("ID").ToString & "/" & reader("NewID").ToString)
                                    'End If
                                Catch ex As Exception
                                    Retval.FailedHistory.Items.Add("Update ID Fields UserList/Filters FAILED " & reader("ID").ToString & "/" & reader("NewID").ToString)
                                    Retval.OverallResult = False
                                End Try
                                'End Using 'cmdUpdate

                                ' MeterReadings
                                SQLUpdate = "UPDATE MeterReadings SET UserID = " & reader("NewID").ToString & " WHERE UserID = " & reader("ID").ToString
                                'Using cmdUpdate As New SqlCommand(SQLUpdate, connection)
                                cmdUpdate.CommandText = SQLUpdate
                                Try
                                    RowsAffected = cmdUpdate.ExecuteNonQuery()
                                    'If RowsAffected > 0 Then
                                    '    Retval.PassedHistory.Items.Add("Updated ID Fields UserList/MeterReadings " & reader("ID").ToString & "/" & reader("NewID").ToString)
                                    'End If
                                Catch ex As Exception
                                    Retval.FailedHistory.Items.Add("Update ID Fields UserList/MeterReadings FAILED " & reader("ID").ToString & "/" & reader("NewID").ToString)
                                    Retval.OverallResult = False
                                End Try
                                'End Using 'cmdUpdate

                                ' PostageReconciliation
                                SQLUpdate = "UPDATE PostageReconciliation SET UserID = " & reader("NewID").ToString & " WHERE UserID = " & reader("ID").ToString
                                'Using cmdUpdate As New SqlCommand(SQLUpdate, connection)
                                cmdUpdate.CommandText = SQLUpdate
                                Try
                                    RowsAffected = cmdUpdate.ExecuteNonQuery()
                                    'If RowsAffected > 0 Then
                                    '    Retval.PassedHistory.Items.Add("Updated ID Fields UserList/PostageReconciliation " & reader("ID").ToString & "/" & reader("NewID").ToString)
                                    'End If
                                Catch ex As Exception
                                    Retval.FailedHistory.Items.Add("Update ID Fields UserList/PostageReconciliation FAILED " & reader("ID").ToString & "/" & reader("NewID").ToString)
                                    Retval.OverallResult = False
                                End Try
                                'End Using 'cmdUpdate

                                ' RoomBookingItemHistory
                                SQLUpdate = "UPDATE RoomBookingItemHistory SET UserID = " & reader("NewID").ToString & " WHERE UserID = " & reader("ID").ToString
                                'Using cmdUpdate As New SqlCommand(SQLUpdate, connection)
                                cmdUpdate.CommandText = SQLUpdate
                                Try
                                    RowsAffected = cmdUpdate.ExecuteNonQuery()
                                    'If RowsAffected > 0 Then
                                    '    Retval.PassedHistory.Items.Add("Updated ID Fields UserList/RoomBookingItemHistory " & reader("ID").ToString & "/" & reader("NewID").ToString)
                                    'End If
                                Catch ex As Exception
                                    Retval.FailedHistory.Items.Add("Update ID Fields UserList/RoomBookingItemHistory FAILED " & reader("ID").ToString & "/" & reader("NewID").ToString)
                                    Retval.OverallResult = False
                                End Try
                                'End Using 'cmdUpdate

                                ' RoomBookings
                                SQLUpdate = "UPDATE RoomBookings SET CancelledByUserID = " & reader("NewID").ToString & " WHERE CancelledByUserID = " & reader("ID").ToString
                                'Using cmdUpdate As New SqlCommand(SQLUpdate, connection)
                                cmdUpdate.CommandText = SQLUpdate
                                Try
                                    RowsAffected = cmdUpdate.ExecuteNonQuery()
                                    'If RowsAffected > 0 Then
                                    '    Retval.PassedHistory.Items.Add("Updated ID Fields UserList/RoomBookings " & reader("ID").ToString & "/" & reader("NewID").ToString)
                                    'End If
                                Catch ex As Exception
                                    Retval.FailedHistory.Items.Add("Update ID Fields UserList/RoomBookings FAILED " & reader("ID").ToString & "/" & reader("NewID").ToString)
                                    Retval.OverallResult = False
                                End Try
                                'End Using 'cmdUpdate

                                SQLUpdate = "UPDATE RoomBookings SET CreatorID = " & reader("NewID").ToString & " WHERE CreatorID = " & reader("ID").ToString
                                'Using cmdUpdate As New SqlCommand(SQLUpdate, connection)
                                cmdUpdate.CommandText = SQLUpdate
                                Try
                                    RowsAffected = cmdUpdate.ExecuteNonQuery()
                                    'If RowsAffected > 0 Then
                                    '    Retval.PassedHistory.Items.Add("Updated ID Fields UserList/RoomBookings " & reader("ID").ToString & "/" & reader("NewID").ToString)
                                    'End If
                                Catch ex As Exception
                                    Retval.FailedHistory.Items.Add("Update ID Fields UserList/RoomBookings FAILED " & reader("ID").ToString & "/" & reader("NewID").ToString)
                                    Retval.OverallResult = False
                                End Try
                                'End Using 'cmdUpdate

                                ' TaskHistory
                                SQLUpdate = "UPDATE TaskHistory SET UserID = " & reader("NewID").ToString & " WHERE UserID = " & reader("ID").ToString
                                'Using cmdUpdate As New SqlCommand(SQLUpdate, connection)
                                cmdUpdate.CommandText = SQLUpdate
                                Try
                                    RowsAffected = cmdUpdate.ExecuteNonQuery()
                                    'If RowsAffected > 0 Then
                                    '    Retval.PassedHistory.Items.Add("Updated ID Fields UserList/TaskHistory " & reader("ID").ToString & "/" & reader("NewID").ToString)
                                    'End If
                                Catch ex As Exception
                                    Retval.FailedHistory.Items.Add("Update ID Fields UserList/TaskHistory FAILED " & reader("ID").ToString & "/" & reader("NewID").ToString)
                                    Retval.OverallResult = False
                                End Try
                                'End Using 'cmdUpdate

                                ' TaskManagerFolders
                                SQLUpdate = "UPDATE TaskManagerFolders SET UserID = " & reader("NewID").ToString & " WHERE UserID = " & reader("ID").ToString
                                'Using cmdUpdate As New SqlCommand(SQLUpdate, connection)
                                cmdUpdate.CommandText = SQLUpdate
                                Try
                                    RowsAffected = cmdUpdate.ExecuteNonQuery()
                                    'If RowsAffected > 0 Then
                                    '    Retval.PassedHistory.Items.Add("Updated ID Fields UserList/TaskManagerFolders " & reader("ID").ToString & "/" & reader("NewID").ToString)
                                    'End If
                                Catch ex As Exception
                                    Retval.FailedHistory.Items.Add("Update ID Fields UserList/TaskManagerFolders FAILED " & reader("ID").ToString & "/" & reader("NewID").ToString)
                                    Retval.OverallResult = False
                                End Try
                                'End Using 'cmdUpdate

                                ' Tasks
                                SQLUpdate = "UPDATE Tasks SET OverDueNotificationUserID = " & reader("NewID").ToString & " WHERE OverDueNotificationUserID = " & reader("ID").ToString
                                'Using cmdUpdate As New SqlCommand(SQLUpdate, connection)
                                cmdUpdate.CommandText = SQLUpdate
                                Try
                                    RowsAffected = cmdUpdate.ExecuteNonQuery()
                                    'If RowsAffected > 0 Then
                                    '    Retval.PassedHistory.Items.Add("Updated ID Fields UserList/Tasks " & reader("ID").ToString & "/" & reader("NewID").ToString)
                                    'End If
                                Catch ex As Exception
                                    Retval.FailedHistory.Items.Add("Update ID Fields UserList/Tasks FAILED " & reader("ID").ToString & "/" & reader("NewID").ToString)
                                    Retval.OverallResult = False
                                End Try
                                'End Using 'cmdUpdate

                                SQLUpdate = "UPDATE Tasks SET UserID = " & reader("NewID").ToString & " WHERE UserID = " & reader("ID").ToString
                                'Using cmdUpdate As New SqlCommand(SQLUpdate, connection)
                                cmdUpdate.CommandText = SQLUpdate
                                Try
                                    RowsAffected = cmdUpdate.ExecuteNonQuery()
                                    'If RowsAffected > 0 Then
                                    '    Retval.PassedHistory.Items.Add("Updated ID Fields UserList/Tasks " & reader("ID").ToString & "/" & reader("NewID").ToString)
                                    'End If
                                Catch ex As Exception
                                    Retval.FailedHistory.Items.Add("Update ID Fields UserList/Tasks FAILED " & reader("ID").ToString & "/" & reader("NewID").ToString)
                                    Retval.OverallResult = False
                                End Try
                                'End Using 'cmdUpdate

                                SQLUpdate = "UPDATE Tasks SET CreatorID = " & reader("NewID").ToString & " WHERE CreatorID = " & reader("ID").ToString
                                'Using cmdUpdate As New SqlCommand(SQLUpdate, connection)
                                cmdUpdate.CommandText = SQLUpdate
                                Try
                                    RowsAffected = cmdUpdate.ExecuteNonQuery()
                                    'If RowsAffected > 0 Then
                                    '    Retval.PassedHistory.Items.Add("Updated ID Fields UserList/Tasks " & reader("ID").ToString & "/" & reader("NewID").ToString)
                                    'End If
                                Catch ex As Exception
                                    Retval.FailedHistory.Items.Add("Update ID Fields UserList/Tasks FAILED " & reader("ID").ToString & "/" & reader("NewID").ToString)
                                    Retval.OverallResult = False
                                End Try
                                'End Using 'cmdUpdate

                                ' UserOptions
                                SQLUpdate = "UPDATE UserOptions SET UserID = " & reader("NewID").ToString & " WHERE UserID = " & reader("ID").ToString
                                'Using cmdUpdate As New SqlCommand(SQLUpdate, connection)
                                cmdUpdate.CommandText = SQLUpdate
                                Try
                                    RowsAffected = cmdUpdate.ExecuteNonQuery()
                                    'If RowsAffected > 0 Then
                                    '    Retval.PassedHistory.Items.Add("Updated ID Fields UserList/UserOptions " & reader("ID").ToString & "/" & reader("NewID").ToString)
                                    'End If
                                Catch ex As Exception
                                    Retval.FailedHistory.Items.Add("Update ID Fields UserList/UserOptions FAILED " & reader("ID").ToString & "/" & reader("NewID").ToString)
                                    Retval.OverallResult = False
                                End Try
                                'End Using 'cmdUpdate

                                ' UserReports
                                SQLUpdate = "UPDATE UserReports SET UserID = " & reader("NewID").ToString & " WHERE UserID = " & reader("ID").ToString
                                'Using cmdUpdate As New SqlCommand(SQLUpdate, connection)
                                cmdUpdate.CommandText = SQLUpdate
                                Try
                                    RowsAffected = cmdUpdate.ExecuteNonQuery()
                                    'If RowsAffected > 0 Then
                                    '    Retval.PassedHistory.Items.Add("Updated ID Fields UserList/UserReports " & reader("ID").ToString & "/" & reader("NewID").ToString)
                                    'End If
                                Catch ex As Exception
                                    Retval.FailedHistory.Items.Add("Update ID Fields UserList/UserReports FAILED " & reader("ID").ToString & "/" & reader("NewID").ToString)
                                    Retval.OverallResult = False
                                End Try
                                'End Using 'cmdUpdate

                                ' LicenceServiceChargeItemsTemp
                                SQLUpdate = "UPDATE LicenceServiceChargeItemsTemp SET CreatedByID = " & reader("NewID").ToString & " WHERE CreatedByID = " & reader("ID").ToString
                                'Using cmdUpdate As New SqlCommand(SQLUpdate, connection)
                                cmdUpdate.CommandText = SQLUpdate
                                Try
                                    RowsAffected = cmdUpdate.ExecuteNonQuery()
                                    'If RowsAffected > 0 Then
                                    '    Retval.PassedHistory.Items.Add("Updated ID Fields UserList/LicenceServiceChargeItemsTemp " & reader("ID").ToString & "/" & reader("NewID").ToString)
                                    'End If
                                Catch ex As Exception
                                    Retval.FailedHistory.Items.Add("Update ID Fields UserList/LicenceServiceChargeItemsTemp FAILED " & reader("ID").ToString & "/" & reader("NewID").ToString)
                                    Retval.OverallResult = False
                                End Try
                                'End Using 'cmdUpdate

                                ' ServiceChargeItems
                                SQLUpdate = "UPDATE ServiceChargeItems SET CreatedByID = " & reader("NewID").ToString & " WHERE CreatedByID = " & reader("ID").ToString
                                'Using cmdUpdate As New SqlCommand(SQLUpdate, connection)
                                cmdUpdate.CommandText = SQLUpdate
                                Try
                                    RowsAffected = cmdUpdate.ExecuteNonQuery()
                                    'If RowsAffected > 0 Then
                                    '    Retval.PassedHistory.Items.Add("Updated ID Fields UserList/ServiceChargeItems " & reader("ID").ToString & "/" & reader("NewID").ToString)
                                    'End If
                                Catch ex As Exception
                                    Retval.FailedHistory.Items.Add("Update ID Fields UserList/ServiceChargeItems FAILED " & reader("ID").ToString & "/" & reader("NewID").ToString)
                                    Retval.OverallResult = False
                                End Try
                                'End Using 'cmdUpdate

                                ' Actions
                                SQLUpdate = "UPDATE Actions SET CreatorID = " & reader("NewID").ToString & " WHERE CreatorID = " & reader("ID").ToString
                                'Using cmdUpdate As New SqlCommand(SQLUpdate, connection)
                                cmdUpdate.CommandText = SQLUpdate
                                Try
                                    RowsAffected = cmdUpdate.ExecuteNonQuery()
                                    'If RowsAffected > 0 Then
                                    '    Retval.PassedHistory.Items.Add("Updated ID Fields UserList/Actions " & reader("ID").ToString & "/" & reader("NewID").ToString)
                                    'End If
                                Catch ex As Exception
                                    Retval.FailedHistory.Items.Add("Update ID Fields UserList/Actions FAILED " & reader("ID").ToString & "/" & reader("NewID").ToString)
                                    Retval.OverallResult = False
                                End Try
                                'End Using 'cmdUpdate


                                ' Contacts
                                SQLUpdate = "UPDATE Contacts SET CreatorID = " & reader("NewID").ToString & " WHERE CreatorID = " & reader("ID").ToString
                                'Using cmdUpdate As New SqlCommand(SQLUpdate, connection)
                                cmdUpdate.CommandText = SQLUpdate
                                Try
                                    RowsAffected = cmdUpdate.ExecuteNonQuery()
                                    'If RowsAffected > 0 Then
                                    '    Retval.PassedHistory.Items.Add("Updated ID Fields UserList/Contacts " & reader("ID").ToString & "/" & reader("NewID").ToString)
                                    'End If
                                Catch ex As Exception
                                    Retval.FailedHistory.Items.Add("Update ID Fields UserList/Contacts FAILED " & reader("ID").ToString & "/" & reader("NewID").ToString)
                                    Retval.OverallResult = False
                                End Try
                                'End Using 'cmdUpdate

                                ' CouriersAndTaxis
                                SQLUpdate = "UPDATE CouriersAndTaxis SET CreatorID = " & reader("NewID").ToString & " WHERE CreatorID = " & reader("ID").ToString
                                'Using cmdUpdate As New SqlCommand(SQLUpdate, connection)
                                cmdUpdate.CommandText = SQLUpdate
                                Try
                                    RowsAffected = cmdUpdate.ExecuteNonQuery()
                                    'If RowsAffected > 0 Then
                                    '    Retval.PassedHistory.Items.Add("Updated ID Fields UserList/CouriersAndTaxis " & reader("ID").ToString & "/" & reader("NewID").ToString)
                                    'End If
                                Catch ex As Exception
                                    Retval.FailedHistory.Items.Add("Update ID Fields UserList/CouriersAndTaxis FAILED " & reader("ID").ToString & "/" & reader("NewID").ToString)
                                    Retval.OverallResult = False
                                End Try
                                'End Using 'cmdUpdate

                                ' Deliveries
                                SQLUpdate = "UPDATE Deliveries SET CreatorID = " & reader("NewID").ToString & " WHERE CreatorID = " & reader("ID").ToString
                                'Using cmdUpdate As New SqlCommand(SQLUpdate, connection)
                                cmdUpdate.CommandText = SQLUpdate
                                Try
                                    RowsAffected = cmdUpdate.ExecuteNonQuery()
                                    'If RowsAffected > 0 Then
                                    '    Retval.PassedHistory.Items.Add("Updated ID Fields UserList/Deliveries " & reader("ID").ToString & "/" & reader("NewID").ToString)
                                    'End If
                                Catch ex As Exception
                                    Retval.FailedHistory.Items.Add("Update ID Fields UserList/Deliveries FAILED " & reader("ID").ToString & "/" & reader("NewID").ToString)
                                    Retval.OverallResult = False
                                End Try
                                'End Using 'cmdUpdate

                                ' Faxes
                                SQLUpdate = "UPDATE Faxes SET CreatorID = " & reader("NewID").ToString & " WHERE CreatorID = " & reader("ID").ToString
                                'Using cmdUpdate As New SqlCommand(SQLUpdate, connection)
                                cmdUpdate.CommandText = SQLUpdate
                                Try
                                    RowsAffected = cmdUpdate.ExecuteNonQuery()
                                    'If RowsAffected > 0 Then
                                    '    Retval.PassedHistory.Items.Add("Updated ID Fields UserList/Faxes " & reader("ID").ToString & "/" & reader("NewID").ToString)
                                    'End If
                                Catch ex As Exception
                                    Retval.FailedHistory.Items.Add("Update ID Fields UserList/Faxes FAILED " & reader("ID").ToString & "/" & reader("NewID").ToString)
                                    Retval.OverallResult = False
                                End Try
                                'End Using 'cmdUpdate

                                ' FrontDeskNotes
                                SQLUpdate = "UPDATE FrontDeskNotes SET CreatorID = " & reader("NewID").ToString & " WHERE CreatorID = " & reader("ID").ToString
                                'Using cmdUpdate As New SqlCommand(SQLUpdate, connection)
                                cmdUpdate.CommandText = SQLUpdate
                                Try
                                    RowsAffected = cmdUpdate.ExecuteNonQuery()
                                    'If RowsAffected > 0 Then
                                    '    Retval.PassedHistory.Items.Add("Updated ID Fields UserList/FrontDeskNotes " & reader("ID").ToString & "/" & reader("NewID").ToString)
                                    'End If
                                Catch ex As Exception
                                    Retval.FailedHistory.Items.Add("Update ID Fields UserList/FrontDeskNotes FAILED " & reader("ID").ToString & "/" & reader("NewID").ToString)
                                    Retval.OverallResult = False
                                End Try
                                'End Using 'cmdUpdate

                                ' InvoiceExportBatches
                                SQLUpdate = "UPDATE InvoiceExportBatches SET CreatorID = " & reader("NewID").ToString & " WHERE CreatorID = " & reader("ID").ToString
                                'Using cmdUpdate As New SqlCommand(SQLUpdate, connection)
                                cmdUpdate.CommandText = SQLUpdate
                                Try
                                    RowsAffected = cmdUpdate.ExecuteNonQuery()
                                    'If RowsAffected > 0 Then
                                    '    Retval.PassedHistory.Items.Add("Updated ID Fields UserList/InvoiceExportBatches " & reader("ID").ToString & "/" & reader("NewID").ToString)
                                    'End If
                                Catch ex As Exception
                                    Retval.FailedHistory.Items.Add("Update ID Fields UserList/InvoiceExportBatches FAILED " & reader("ID").ToString & "/" & reader("NewID").ToString)
                                    Retval.OverallResult = False
                                End Try
                                'End Using 'cmdUpdate

                                ' Mail
                                SQLUpdate = "UPDATE Mail SET CreatorID = " & reader("NewID").ToString & " WHERE CreatorID = " & reader("ID").ToString
                                'Using cmdUpdate As New SqlCommand(SQLUpdate, connection)
                                cmdUpdate.CommandText = SQLUpdate
                                Try
                                    RowsAffected = cmdUpdate.ExecuteNonQuery()
                                    'If RowsAffected > 0 Then
                                    '    Retval.PassedHistory.Items.Add("Updated ID Fields UserList/Mail " & reader("ID").ToString & "/" & reader("NewID").ToString)
                                    'End If
                                Catch ex As Exception
                                    Retval.FailedHistory.Items.Add("Update ID Fields UserList/Mail FAILED " & reader("ID").ToString & "/" & reader("NewID").ToString)
                                    Retval.OverallResult = False
                                End Try
                                'End Using 'cmdUpdate

                                ' Messages
                                SQLUpdate = "UPDATE Messages SET CreatorID = " & reader("NewID").ToString & " WHERE CreatorID = " & reader("ID").ToString
                                'Using cmdUpdate As New SqlCommand(SQLUpdate, connection)
                                cmdUpdate.CommandText = SQLUpdate
                                Try
                                    RowsAffected = cmdUpdate.ExecuteNonQuery()
                                    'If RowsAffected > 0 Then
                                    '    Retval.PassedHistory.Items.Add("Updated ID Fields UserList/Messages " & reader("ID").ToString & "/" & reader("NewID").ToString)
                                    'End If
                                Catch ex As Exception
                                    Retval.FailedHistory.Items.Add("Update ID Fields UserList/Messages FAILED " & reader("ID").ToString & "/" & reader("NewID").ToString)
                                    Retval.OverallResult = False
                                End Try
                                'End Using 'cmdUpdate

                                ' PaymentExportBatches
                                SQLUpdate = "UPDATE PaymentExportBatches SET CreatorID = " & reader("NewID").ToString & " WHERE CreatorID = " & reader("ID").ToString
                                'Using cmdUpdate As New SqlCommand(SQLUpdate, connection)
                                cmdUpdate.CommandText = SQLUpdate
                                Try
                                    RowsAffected = cmdUpdate.ExecuteNonQuery()
                                    'If RowsAffected > 0 Then
                                    '    Retval.PassedHistory.Items.Add("Updated ID Fields UserList/PaymentExportBatches " & reader("ID").ToString & "/" & reader("NewID").ToString)
                                    'End If
                                Catch ex As Exception
                                    Retval.FailedHistory.Items.Add("Update ID Fields UserList/PaymentExportBatches FAILED " & reader("ID").ToString & "/" & reader("NewID").ToString)
                                    Retval.OverallResult = False
                                End Try
                                'End Using 'cmdUpdate

                                ' RoomBookings
                                SQLUpdate = "UPDATE RoomBookings SET CreatorID = " & reader("NewID").ToString & " WHERE CreatorID = " & reader("ID").ToString
                                'Using cmdUpdate As New SqlCommand(SQLUpdate, connection)
                                cmdUpdate.CommandText = SQLUpdate
                                Try
                                    RowsAffected = cmdUpdate.ExecuteNonQuery()
                                    'If RowsAffected > 0 Then
                                    '    Retval.PassedHistory.Items.Add("Updated ID Fields UserList/RoomBookings " & reader("ID").ToString & "/" & reader("NewID").ToString)
                                    'End If
                                Catch ex As Exception
                                    Retval.FailedHistory.Items.Add("Update ID Fields UserList/RoomBookings FAILED " & reader("ID").ToString & "/" & reader("NewID").ToString)
                                    Retval.OverallResult = False
                                End Try
                                'End Using 'cmdUpdate

                                ' Viewings
                                SQLUpdate = "UPDATE Viewings SET CreatorID = " & reader("NewID").ToString & " WHERE CreatorID = " & reader("ID").ToString
                                'Using cmdUpdate As New SqlCommand(SQLUpdate, connection)
                                cmdUpdate.CommandText = SQLUpdate
                                Try
                                    RowsAffected = cmdUpdate.ExecuteNonQuery()
                                    'If RowsAffected > 0 Then
                                    '    Retval.PassedHistory.Items.Add("Updated ID Fields UserList/Viewings " & reader("ID").ToString & "/" & reader("NewID").ToString)
                                    'End If
                                Catch ex As Exception
                                    Retval.FailedHistory.Items.Add("Update ID Fields UserList/Viewings FAILED " & reader("ID").ToString & "/" & reader("NewID").ToString)
                                    Retval.OverallResult = False
                                End Try
                                'End Using 'cmdUpdate

                                ' Documents
                                SQLUpdate = "UPDATE Documents SET OwnerID = " & reader("NewID").ToString & " WHERE OwnerID = " & reader("ID").ToString
                                'Using cmdUpdate As New SqlCommand(SQLUpdate, connection)
                                cmdUpdate.CommandText = SQLUpdate
                                Try
                                    RowsAffected = cmdUpdate.ExecuteNonQuery()
                                    'If RowsAffected > 0 Then
                                    '    Retval.PassedHistory.Items.Add("Updated ID Fields UserList/Documents " & reader("ID").ToString & "/" & reader("NewID").ToString)
                                    'End If
                                Catch ex As Exception
                                    Retval.FailedHistory.Items.Add("Update ID Fields UserList/Documents FAILED " & reader("ID").ToString & "/" & reader("NewID").ToString)
                                    Retval.OverallResult = False
                                End Try
                                'End Using 'cmdUpdate

                                ' DeletedInvoices
                                SQLUpdate = "UPDATE DeletedInvoices SET DeletedByID = " & reader("NewID").ToString & " WHERE DeletedByID = " & reader("ID").ToString
                                'Using cmdUpdate As New SqlCommand(SQLUpdate, connection)
                                cmdUpdate.CommandText = SQLUpdate
                                Try
                                    RowsAffected = cmdUpdate.ExecuteNonQuery()
                                    'If RowsAffected > 0 Then
                                    '    Retval.PassedHistory.Items.Add("Updated ID Fields UserList/DeletedInvoices " & reader("ID").ToString & "/" & reader("NewID").ToString)
                                    'End If
                                Catch ex As Exception
                                    Retval.FailedHistory.Items.Add("Update ID Fields UserList/DeletedInvoices FAILED " & reader("ID").ToString & "/" & reader("NewID").ToString)
                                    Retval.OverallResult = False
                                End Try
                            End Using 'cmdUpdate

                        Loop

                    End If

                End Using ' reader

            End Using ' cmd

        End Using ' connection

        Return Retval


    End Function

    Public Shared Function UpdateVATRatesIDs() As cMultiValueReturn

        Dim SQLstring As String = ""
        Dim SQLUpdate As String = ""
        Dim RowsAffected As Integer
        Dim Retval As New cMultiValueReturn

        ' ID is the original old ID from the local database
        SQLstring = "SELECT NewID, ID FROM VATRates"

        Using connection As SqlConnection = DBConnection.GetConnectionIntermediate

            connection.Open()

            Using cmd As New SqlCommand(SQLstring, connection)

                Using reader As SqlDataReader = cmd.ExecuteReader

                    If reader.HasRows Then

                        Do While reader.Read

                            ' update related table data here
                            ' InvoiceLInes
                            SQLUpdate = "UPDATE InvoiceLInes SET VATRateID = " & reader("NewID").ToString & " WHERE VATRateID = " & reader("ID").ToString
                            Using cmdUpdate As New SqlCommand(SQLUpdate, connection)
                                Try
                                    RowsAffected = cmdUpdate.ExecuteNonQuery()
                                    'If RowsAffected > 0 Then
                                    '    Retval.PassedHistory.Items.Add("Updated ID Fields VATRates/InvoiceLInes " & reader("ID").ToString & "/" & reader("NewID").ToString)
                                    'End If
                                Catch ex As Exception
                                    Retval.FailedHistory.Items.Add("Update ID Fields VATRates/InvoiceLInes FAILED " & reader("ID").ToString & "/" & reader("NewID").ToString)
                                    Retval.OverallResult = False
                                End Try
                                'End Using 'cmdUpdate

                                ' ProgramOptions
                                SQLUpdate = "UPDATE ProgramOptions SET DepositVATRate = " & reader("NewID").ToString & " WHERE DepositVATRate = " & reader("ID").ToString
                                'Using cmdUpdate As New SqlCommand(SQLUpdate, connection)
                                cmdUpdate.CommandText = SQLUpdate
                                Try
                                    RowsAffected = cmdUpdate.ExecuteNonQuery()
                                    'If RowsAffected > 0 Then
                                    '    Retval.PassedHistory.Items.Add("Updated ID Fields VATRates/ProgramOptions " & reader("ID").ToString & "/" & reader("NewID").ToString)
                                    'End If
                                Catch ex As Exception
                                    Retval.FailedHistory.Items.Add("Update ID Fields VATRates/ProgramOptions FAILED " & reader("ID").ToString & "/" & reader("NewID").ToString)
                                    Retval.OverallResult = False
                                End Try
                                'End Using 'cmdUpdate

                                SQLUpdate = "UPDATE ProgramOptions SET LicenceVATRate = " & reader("NewID").ToString & " WHERE LicenceVATRate = " & reader("ID").ToString
                                'Using cmdUpdate As New SqlCommand(SQLUpdate, connection)
                                cmdUpdate.CommandText = SQLUpdate
                                Try
                                    RowsAffected = cmdUpdate.ExecuteNonQuery()
                                    'If RowsAffected > 0 Then
                                    '    Retval.PassedHistory.Items.Add("Updated ID Fields VATRates/ProgramOptions " & reader("ID").ToString & "/" & reader("NewID").ToString)
                                    'End If
                                Catch ex As Exception
                                    Retval.FailedHistory.Items.Add("Update ID Fields VATRates/ProgramOptions FAILED " & reader("ID").ToString & "/" & reader("NewID").ToString)
                                    Retval.OverallResult = False
                                End Try
                                'End Using 'cmdUpdate

                                ' ServiceChargeTypes
                                SQLUpdate = "UPDATE ServiceChargeTypes SET VATRate = " & reader("NewID").ToString & " WHERE VATRate = " & reader("ID").ToString
                                'Using cmdUpdate As New SqlCommand(SQLUpdate, connection)
                                cmdUpdate.CommandText = SQLUpdate
                                Try
                                    RowsAffected = cmdUpdate.ExecuteNonQuery()
                                    'If RowsAffected > 0 Then
                                    '    Retval.PassedHistory.Items.Add("Updated ID Fields VATRates/ServiceChargeTypes " & reader("ID").ToString & "/" & reader("NewID").ToString)
                                    'End If
                                Catch ex As Exception
                                    Retval.FailedHistory.Items.Add("Update ID Fields VATRates/ServiceChargeTypes FAILED " & reader("ID").ToString & "/" & reader("NewID").ToString)
                                    Retval.OverallResult = False
                                End Try
                            End Using 'cmdUpdate

                        Loop

                    End If

                End Using ' reader

            End Using ' cmd

        End Using ' connection

        Return Retval

    End Function

    Public Shared Function UpdateListDataIDs() As cMultiValueReturn

        Dim SQLstring As String = ""
        Dim SQLUpdate As String = ""
        Dim RowsAffected As Integer
        Dim Retval As New cMultiValueReturn

        ' ID is the original old ID from the local database
        SQLstring = "SELECT NewID, ID FROM ListData"

        Using connection As SqlConnection = DBConnection.GetConnectionIntermediate

            connection.Open()

            Using cmd As New SqlCommand(SQLstring, connection)

                Using reader As SqlDataReader = cmd.ExecuteReader

                    If reader.HasRows Then

                        Do While reader.Read

                            ' update related table data here
                            ' Accommodations StatusID
                            SQLUpdate = "UPDATE Accommodations SET StatusID = " & reader("NewID").ToString & " WHERE StatusID = " & reader("ID").ToString
                            Using cmdUpdate As New SqlCommand(SQLUpdate, connection)
                                Try
                                    RowsAffected = cmdUpdate.ExecuteNonQuery()
                                Catch ex As Exception
                                    Retval.FailedHistory.Items.Add("Update ID Fields ListData/Accommodations/StatusID FAILED " & reader("ID").ToString & "/" & reader("NewID").ToString)
                                    Retval.OverallResult = False
                                End Try

                                ' Accommodations TypeID
                                SQLUpdate = "UPDATE Accommodations SET TypeID = " & reader("NewID").ToString & " WHERE TypeID = " & reader("ID").ToString
                                cmdUpdate.CommandText = SQLUpdate
                                Try
                                    RowsAffected = cmdUpdate.ExecuteNonQuery()
                                Catch ex As Exception
                                    Retval.FailedHistory.Items.Add("Update ID Fields ListData/Accommodations/TypeID FAILED " & reader("ID").ToString & "/" & reader("NewID").ToString)
                                    Retval.OverallResult = False
                                End Try

                                ' Actions StatusID
                                SQLUpdate = "UPDATE Actions SET StatusID = " & reader("NewID").ToString & " WHERE StatusID = " & reader("ID").ToString
                                cmdUpdate.CommandText = SQLUpdate
                                Try
                                    RowsAffected = cmdUpdate.ExecuteNonQuery()
                                Catch ex As Exception
                                    Retval.FailedHistory.Items.Add("Update ID Fields ListData/Actions/StatusID FAILED " & reader("ID").ToString & "/" & reader("NewID").ToString)
                                    Retval.OverallResult = False
                                End Try

                                ' Addresses typeID
                                SQLUpdate = "UPDATE Addresses SET TypeID = " & reader("NewID").ToString & " WHERE TypeID = " & reader("ID").ToString
                                cmdUpdate.CommandText = SQLUpdate
                                Try
                                    RowsAffected = cmdUpdate.ExecuteNonQuery()
                                Catch ex As Exception
                                    Retval.FailedHistory.Items.Add("Update ID Fields ListData/Addresses/TypeID FAILED " & reader("ID").ToString & "/" & reader("NewID").ToString)
                                    Retval.OverallResult = False
                                End Try

                                ' Availability AvailabilityID
                                SQLUpdate = "UPDATE Availability SET AvailabilityID = " & reader("NewID").ToString & " WHERE AvailabilityID = " & reader("ID").ToString
                                cmdUpdate.CommandText = SQLUpdate
                                Try
                                    RowsAffected = cmdUpdate.ExecuteNonQuery()
                                Catch ex As Exception
                                    Retval.FailedHistory.Items.Add("Update ID Fields ListData/Availability/AvailabilityID FAILED " & reader("ID").ToString & "/" & reader("NewID").ToString)
                                    Retval.OverallResult = False
                                End Try

                                ' CalendarRooms CalendarID
                                SQLUpdate = "UPDATE CalendarRooms SET CalendarID = " & reader("NewID").ToString & " WHERE CalendarID = " & reader("ID").ToString
                                cmdUpdate.CommandText = SQLUpdate
                                Try
                                    RowsAffected = cmdUpdate.ExecuteNonQuery()
                                Catch ex As Exception
                                    Retval.FailedHistory.Items.Add("Update ID Fields ListData/CalendarRooms/CalendarID FAILED " & reader("ID").ToString & "/" & reader("NewID").ToString)
                                    Retval.OverallResult = False
                                End Try

                                ' ClientFilters BusinessTypeID
                                SQLUpdate = "UPDATE ClientFilters SET BusinessTypeID = " & reader("NewID").ToString & " WHERE BusinessTypeID = " & reader("ID").ToString
                                cmdUpdate.CommandText = SQLUpdate
                                Try
                                    RowsAffected = cmdUpdate.ExecuteNonQuery()
                                Catch ex As Exception
                                    Retval.FailedHistory.Items.Add("Update ID Fields ListData/ClientFilters/BusinessTypeID FAILED " & reader("ID").ToString & "/" & reader("NewID").ToString)
                                    Retval.OverallResult = False
                                End Try

                                ' ClientFilters ClientTypeID
                                SQLUpdate = "UPDATE ClientFilters SET ClientTypeID = " & reader("NewID").ToString & " WHERE ClientTypeID = " & reader("ID").ToString
                                cmdUpdate.CommandText = SQLUpdate
                                Try
                                    RowsAffected = cmdUpdate.ExecuteNonQuery()
                                Catch ex As Exception
                                    Retval.FailedHistory.Items.Add("Update ID Fields ListData/ClientFilters/ClientTypeID FAILED " & reader("ID").ToString & "/" & reader("NewID").ToString)
                                    Retval.OverallResult = False
                                End Try

                                ' ClientFilters SourceID
                                SQLUpdate = "UPDATE ClientFilters SET SourceID = " & reader("NewID").ToString & " WHERE SourceID = " & reader("ID").ToString
                                cmdUpdate.CommandText = SQLUpdate
                                Try
                                    RowsAffected = cmdUpdate.ExecuteNonQuery()
                                Catch ex As Exception
                                    Retval.FailedHistory.Items.Add("Update ID Fields ListData/ClientFilters/SourceID FAILED " & reader("ID").ToString & "/" & reader("NewID").ToString)
                                    Retval.OverallResult = False
                                End Try

                                ' ClientFilters StatusID
                                SQLUpdate = "UPDATE ClientFilters SET StatusID = " & reader("NewID").ToString & " WHERE StatusID = " & reader("ID").ToString
                                cmdUpdate.CommandText = SQLUpdate
                                Try
                                    RowsAffected = cmdUpdate.ExecuteNonQuery()
                                Catch ex As Exception
                                    Retval.FailedHistory.Items.Add("Update ID Fields ListData/ClientFilters/StatusID FAILED " & reader("ID").ToString & "/" & reader("NewID").ToString)
                                    Retval.OverallResult = False
                                End Try

                                ' ClientFilters TradingTypeID
                                SQLUpdate = "UPDATE ClientFilters SET TradingTypeID = " & reader("NewID").ToString & " WHERE TradingTypeID = " & reader("ID").ToString
                                cmdUpdate.CommandText = SQLUpdate
                                Try
                                    RowsAffected = cmdUpdate.ExecuteNonQuery()
                                Catch ex As Exception
                                    Retval.FailedHistory.Items.Add("Update ID Fields ListData/ClientFilters/TradingTypeID FAILED " & reader("ID").ToString & "/" & reader("NewID").ToString)
                                    Retval.OverallResult = False
                                End Try

                                ' ClientGroupClients GroupID
                                SQLUpdate = "UPDATE ClientGroupClients SET GroupID = " & reader("NewID").ToString & " WHERE GroupID = " & reader("ID").ToString
                                cmdUpdate.CommandText = SQLUpdate
                                Try
                                    RowsAffected = cmdUpdate.ExecuteNonQuery()
                                Catch ex As Exception
                                    Retval.FailedHistory.Items.Add("Update ID Fields ListData/ClientGroupClients/GroupID FAILED " & reader("ID").ToString & "/" & reader("NewID").ToString)
                                    Retval.OverallResult = False
                                End Try

                                ' Clients SourceID
                                SQLUpdate = "UPDATE Clients SET SourceID = " & reader("NewID").ToString & " WHERE SourceID = " & reader("ID").ToString
                                cmdUpdate.CommandText = SQLUpdate
                                Try
                                    RowsAffected = cmdUpdate.ExecuteNonQuery()
                                Catch ex As Exception
                                    Retval.FailedHistory.Items.Add("Update ID Fields ListData/Clients/SourceID FAILED " & reader("ID").ToString & "/" & reader("NewID").ToString)
                                    Retval.OverallResult = False
                                End Try

                                ' Clients StatusID
                                SQLUpdate = "UPDATE Clients SET StatusID = " & reader("NewID").ToString & " WHERE StatusID = " & reader("ID").ToString
                                cmdUpdate.CommandText = SQLUpdate
                                Try
                                    RowsAffected = cmdUpdate.ExecuteNonQuery()
                                Catch ex As Exception
                                    Retval.FailedHistory.Items.Add("Update ID Fields ListData/Clients/StatusID FAILED " & reader("ID").ToString & "/" & reader("NewID").ToString)
                                    Retval.OverallResult = False
                                End Try

                                ' Clients TypeID
                                SQLUpdate = "UPDATE Clients SET TypeID = " & reader("NewID").ToString & " WHERE TypeID = " & reader("ID").ToString
                                cmdUpdate.CommandText = SQLUpdate
                                Try
                                    RowsAffected = cmdUpdate.ExecuteNonQuery()
                                Catch ex As Exception
                                    Retval.FailedHistory.Items.Add("Update ID Fields ListData/Clients/TypeID FAILED " & reader("ID").ToString & "/" & reader("NewID").ToString)
                                    Retval.OverallResult = False
                                End Try

                                ' Companies BusinessTypeID
                                SQLUpdate = "UPDATE Companies SET BusinessTypeID = " & reader("NewID").ToString & " WHERE BusinessTypeID = " & reader("ID").ToString
                                cmdUpdate.CommandText = SQLUpdate
                                Try
                                    RowsAffected = cmdUpdate.ExecuteNonQuery()
                                Catch ex As Exception
                                    Retval.FailedHistory.Items.Add("Update ID Fields ListData/Companies/BusinessTypeID FAILED " & reader("ID").ToString & "/" & reader("NewID").ToString)
                                    Retval.OverallResult = False
                                End Try

                                ' Companies TradingTypeID
                                SQLUpdate = "UPDATE Companies SET TradingTypeID = " & reader("NewID").ToString & " WHERE TradingTypeID = " & reader("ID").ToString
                                cmdUpdate.CommandText = SQLUpdate
                                Try
                                    RowsAffected = cmdUpdate.ExecuteNonQuery()
                                Catch ex As Exception
                                    Retval.FailedHistory.Items.Add("Update ID Fields ListData/Companies/TradingTypeID FAILED " & reader("ID").ToString & "/" & reader("NewID").ToString)
                                    Retval.OverallResult = False
                                End Try

                                ' ContactHistory StatusID
                                SQLUpdate = "UPDATE ContactHistory SET StatusID = " & reader("NewID").ToString & " WHERE StatusID = " & reader("ID").ToString
                                cmdUpdate.CommandText = SQLUpdate
                                Try
                                    RowsAffected = cmdUpdate.ExecuteNonQuery()
                                Catch ex As Exception
                                    Retval.FailedHistory.Items.Add("Update ID Fields ListData/ContactHistory/StatusID FAILED " & reader("ID").ToString & "/" & reader("NewID").ToString)
                                    Retval.OverallResult = False
                                End Try

                                ' ContactHistory TypeID
                                SQLUpdate = "UPDATE ContactHistory SET TypeID = " & reader("NewID").ToString & " WHERE TypeID = " & reader("ID").ToString
                                cmdUpdate.CommandText = SQLUpdate
                                Try
                                    RowsAffected = cmdUpdate.ExecuteNonQuery()
                                Catch ex As Exception
                                    Retval.FailedHistory.Items.Add("Update ID Fields ListData/ContactHistory/TypeID FAILED " & reader("ID").ToString & "/" & reader("NewID").ToString)
                                    Retval.OverallResult = False
                                End Try

                                ' Contacts InactiveReasonID
                                SQLUpdate = "UPDATE Contacts SET InactiveReasonID = " & reader("NewID").ToString & " WHERE InactiveReasonID = " & reader("ID").ToString
                                cmdUpdate.CommandText = SQLUpdate
                                Try
                                    RowsAffected = cmdUpdate.ExecuteNonQuery()
                                Catch ex As Exception
                                    Retval.FailedHistory.Items.Add("Update ID Fields ListData/Contacts/InactiveReasonID FAILED " & reader("ID").ToString & "/" & reader("NewID").ToString)
                                    Retval.OverallResult = False
                                End Try

                                ' Contacts SourceID
                                SQLUpdate = "UPDATE Contacts SET SourceID = " & reader("NewID").ToString & " WHERE SourceID = " & reader("ID").ToString
                                cmdUpdate.CommandText = SQLUpdate
                                Try
                                    RowsAffected = cmdUpdate.ExecuteNonQuery()
                                Catch ex As Exception
                                    Retval.FailedHistory.Items.Add("Update ID Fields ListData/Contacts/SourceID FAILED " & reader("ID").ToString & "/" & reader("NewID").ToString)
                                    Retval.OverallResult = False
                                End Try

                                ' Contacts StatusID
                                SQLUpdate = "UPDATE Contacts SET StatusID = " & reader("NewID").ToString & " WHERE StatusID = " & reader("ID").ToString
                                cmdUpdate.CommandText = SQLUpdate
                                Try
                                    RowsAffected = cmdUpdate.ExecuteNonQuery()
                                Catch ex As Exception
                                    Retval.FailedHistory.Items.Add("Update ID Fields ListData/Contacts/StatusID FAILED " & reader("ID").ToString & "/" & reader("NewID").ToString)
                                    Retval.OverallResult = False
                                End Try

                                ' CouriersAndTaxis ProviderID
                                SQLUpdate = "UPDATE CouriersAndTaxis SET ProviderID = " & reader("NewID").ToString & " WHERE ProviderID = " & reader("ID").ToString
                                cmdUpdate.CommandText = SQLUpdate
                                Try
                                    RowsAffected = cmdUpdate.ExecuteNonQuery()
                                Catch ex As Exception
                                    Retval.FailedHistory.Items.Add("Update ID Fields ListData/CouriersAndTaxis/ProviderID FAILED " & reader("ID").ToString & "/" & reader("NewID").ToString)
                                    Retval.OverallResult = False
                                End Try

                                ' CustomComments GroupID
                                SQLUpdate = "UPDATE CustomComments SET GroupID = " & reader("NewID").ToString & " WHERE GroupID = " & reader("ID").ToString
                                cmdUpdate.CommandText = SQLUpdate
                                Try
                                    RowsAffected = cmdUpdate.ExecuteNonQuery()
                                Catch ex As Exception
                                    Retval.FailedHistory.Items.Add("Update ID Fields ListData/CustomComments/GroupID FAILED " & reader("ID").ToString & "/" & reader("NewID").ToString)
                                    Retval.OverallResult = False
                                End Try

                                ' Deliveries DeliveryTypeID
                                SQLUpdate = "UPDATE Deliveries SET DeliveryTypeID = " & reader("NewID").ToString & " WHERE DeliveryTypeID = " & reader("ID").ToString
                                cmdUpdate.CommandText = SQLUpdate
                                Try
                                    RowsAffected = cmdUpdate.ExecuteNonQuery()
                                Catch ex As Exception
                                    Retval.FailedHistory.Items.Add("Update ID Fields ListData/Deliveries/DeliveryTypeID FAILED " & reader("ID").ToString & "/" & reader("NewID").ToString)
                                    Retval.OverallResult = False
                                End Try

                                ' EmailAddresses TypeID
                                SQLUpdate = "UPDATE EmailAddresses SET TypeID = " & reader("NewID").ToString & " WHERE TypeID = " & reader("ID").ToString
                                cmdUpdate.CommandText = SQLUpdate
                                Try
                                    RowsAffected = cmdUpdate.ExecuteNonQuery()
                                Catch ex As Exception
                                    Retval.FailedHistory.Items.Add("Update ID Fields ListData/EmailAddresses/TypeID FAILED " & reader("ID").ToString & "/" & reader("NewID").ToString)
                                    Retval.OverallResult = False
                                End Try

                                ' FrontDeskNotes StatusID
                                SQLUpdate = "UPDATE FrontDeskNotes SET StatusID = " & reader("NewID").ToString & " WHERE StatusID = " & reader("ID").ToString
                                cmdUpdate.CommandText = SQLUpdate
                                Try
                                    RowsAffected = cmdUpdate.ExecuteNonQuery()
                                Catch ex As Exception
                                    Retval.FailedHistory.Items.Add("Update ID Fields ListData/FrontDeskNotes/StatusID FAILED " & reader("ID").ToString & "/" & reader("NewID").ToString)
                                    Retval.OverallResult = False
                                End Try

                                ' FrontDeskNotes TypeID
                                SQLUpdate = "UPDATE FrontDeskNotes SET TypeID = " & reader("NewID").ToString & " WHERE TypeID = " & reader("ID").ToString
                                cmdUpdate.CommandText = SQLUpdate
                                Try
                                    RowsAffected = cmdUpdate.ExecuteNonQuery()
                                Catch ex As Exception
                                    Retval.FailedHistory.Items.Add("Update ID Fields ListData/FrontDeskNotes/TypeID FAILED " & reader("ID").ToString & "/" & reader("NewID").ToString)
                                    Retval.OverallResult = False
                                End Try

                                ' Meters MeterTypeID
                                SQLUpdate = "UPDATE Meters SET MeterTypeID = " & reader("NewID").ToString & " WHERE MeterTypeID = " & reader("ID").ToString
                                cmdUpdate.CommandText = SQLUpdate
                                Try
                                    RowsAffected = cmdUpdate.ExecuteNonQuery()
                                Catch ex As Exception
                                    Retval.FailedHistory.Items.Add("Update ID Fields ListData/Meters/MeterTypeID FAILED " & reader("ID").ToString & "/" & reader("NewID").ToString)
                                    Retval.OverallResult = False
                                End Try

                                ' RoomBookings LayoutID
                                SQLUpdate = "UPDATE RoomBookings SET LayoutID = " & reader("NewID").ToString & " WHERE LayoutID = " & reader("ID").ToString
                                cmdUpdate.CommandText = SQLUpdate
                                Try
                                    RowsAffected = cmdUpdate.ExecuteNonQuery()
                                Catch ex As Exception
                                    Retval.FailedHistory.Items.Add("Update ID Fields ListData/RoomBookings/LayoutID FAILED " & reader("ID").ToString & "/" & reader("NewID").ToString)
                                    Retval.OverallResult = False
                                End Try

                                ' RoomBookings StatusID
                                SQLUpdate = "UPDATE RoomBookings SET StatusID = " & reader("NewID").ToString & " WHERE StatusID = " & reader("ID").ToString
                                cmdUpdate.CommandText = SQLUpdate
                                Try
                                    RowsAffected = cmdUpdate.ExecuteNonQuery()
                                Catch ex As Exception
                                    Retval.FailedHistory.Items.Add("Update ID Fields ListData/RoomBookings/StatusID FAILED " & reader("ID").ToString & "/" & reader("NewID").ToString)
                                    Retval.OverallResult = False
                                End Try

                                ' RoomGroupRooms GroupID
                                SQLUpdate = "UPDATE RoomGroupRooms SET GroupID = " & reader("NewID").ToString & " WHERE GroupID = " & reader("ID").ToString
                                cmdUpdate.CommandText = SQLUpdate
                                Try
                                    RowsAffected = cmdUpdate.ExecuteNonQuery()
                                Catch ex As Exception
                                    Retval.FailedHistory.Items.Add("Update ID Fields ListData/RoomGroupRooms/GroupID FAILED " & reader("ID").ToString & "/" & reader("NewID").ToString)
                                    Retval.OverallResult = False
                                End Try

                                ' ServiceChargeGroupTypes GroupID
                                SQLUpdate = "UPDATE ServiceChargeGroupTypes SET GroupID = " & reader("NewID").ToString & " WHERE GroupID = " & reader("ID").ToString
                                cmdUpdate.CommandText = SQLUpdate
                                Try
                                    RowsAffected = cmdUpdate.ExecuteNonQuery()
                                Catch ex As Exception
                                    Retval.FailedHistory.Items.Add("Update ID Fields ListData/ServiceChargeGroupTypes/GroupID FAILED " & reader("ID").ToString & "/" & reader("NewID").ToString)
                                    Retval.OverallResult = False
                                End Try

                                ' ServiceChargeGroupTypes TypeID
                                SQLUpdate = "UPDATE ServiceChargeGroupTypes SET TypeID = " & reader("NewID").ToString & " WHERE TypeID = " & reader("ID").ToString
                                cmdUpdate.CommandText = SQLUpdate
                                Try
                                    RowsAffected = cmdUpdate.ExecuteNonQuery()
                                Catch ex As Exception
                                    Retval.FailedHistory.Items.Add("Update ID Fields ListData/ServiceChargeGroupTypes/TypeID FAILED " & reader("ID").ToString & "/" & reader("NewID").ToString)
                                    Retval.OverallResult = False
                                End Try

                                ' TelephoneNumbers TypeID
                                SQLUpdate = "UPDATE TelephoneNumbers SET TypeID = " & reader("NewID").ToString & " WHERE TypeID = " & reader("ID").ToString
                                cmdUpdate.CommandText = SQLUpdate
                                Try
                                    RowsAffected = cmdUpdate.ExecuteNonQuery()
                                Catch ex As Exception
                                    Retval.FailedHistory.Items.Add("Update ID Fields ListData/TelephoneNumbers/TypeID FAILED " & reader("ID").ToString & "/" & reader("NewID").ToString)
                                    Retval.OverallResult = False
                                End Try

                                ' WebAddresses TypeID
                                SQLUpdate = "UPDATE WebAddresses SET TypeID = " & reader("NewID").ToString & " WHERE TypeID = " & reader("ID").ToString
                                cmdUpdate.CommandText = SQLUpdate
                                Try
                                    RowsAffected = cmdUpdate.ExecuteNonQuery()
                                Catch ex As Exception
                                    Retval.FailedHistory.Items.Add("Update ID Fields ListData/WebAddresses/TypeID FAILED " & reader("ID").ToString & "/" & reader("NewID").ToString)
                                    Retval.OverallResult = False
                                End Try


                            End Using 'cmdUpdate

                        Loop

                    End If

                End Using ' reader

            End Using ' cmd

        End Using ' connection

        Return Retval

    End Function

    Public Shared Function GetDatabases() As List(Of cDatabase)

        Dim db As New List(Of cDatabase)
        Dim d As cDatabase
        Dim SQLstring As String

        SQLstring = "SELECT ID, DatabaseName FROM Databases WHERE DatabaseName NOT LIKE '%Prospects%'"

        Using connection As SqlConnection = DBConnection.GetConnectionTrident

            connection.Open()

            Using cmd As New SqlCommand(SQLstring, connection)

                Using reader As SqlDataReader = cmd.ExecuteReader

                    If reader.HasRows Then

                        db = New List(Of cDatabase)

                        Do While reader.Read
                            d = New cDatabase
                            d.ID = reader("ID")
                            d.DatabaseName = reader("DatabaseName")
                            db.Add(d)
                        Loop

                    End If

                End Using ' reader

            End Using ' cmd

        End Using ' connection

        Return db

    End Function

    Public Shared Function GetTableNamesStage2() As List(Of String)

        Dim tn As New List(Of String)
        Dim SQLstring As String

        SQLstring = "SELECT name FROM sysobjects WHERE xtype = 'U' order by name"

        Using connection As SqlConnection = DBConnection.GetConnectionStage2

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

    Public Shared Function DropIntermediateDatabase() As Boolean

        Dim bRetVal As Integer

        Dim SQLString As String = "ALTER DATABASE [CentrePro_Intermediate] SET  SINGLE_USER WITH ROLLBACK IMMEDIATE DROP DATABASE CentrePro_Intermediate"

        Using connection As SqlConnection = DBConnection.GetConnectionServer

            connection.Open()

            Using cmd As New SqlCommand(SQLString, connection)

                bRetVal = cmd.ExecuteNonQuery

            End Using ' cmd

        End Using ' connection

        Return bRetVal


    End Function

    Public Shared Function CreateIntermediateDatabase(filename As String) As Integer

        Dim bRetVal As Integer

        Dim reader As New StreamReader(filename)
        Using connection As SqlConnection = DBConnection.GetConnectionServer

            connection.Open()

            Using cmd As New SqlCommand(reader.ReadToEnd, connection)

                bRetVal = cmd.ExecuteNonQuery

            End Using ' cmd

        End Using ' connection

        Return bRetVal

    End Function

    Public Shared Function CreateIntermediateDatabaseTables(filename As String) As Integer

        Dim bRetVal As Integer

        Dim reader As New StreamReader(filename)
        Using connection As SqlConnection = DBConnection.GetConnectionServer

            connection.Open()

            Using cmd As New SqlCommand(reader.ReadToEnd, connection)

                bRetVal = cmd.ExecuteNonQuery

            End Using ' cmd

        End Using ' connection

        Return bRetVal


    End Function


    Public Shared Function HasColumn(colName As String, tablename As String) As Integer

        Dim bRetVal As Integer

        Dim SQLString As String = "SELECT COUNT(OBJECT_ID) FROM sys.columns WHERE Name = N'" & colName & "' and OBJECT_ID = OBJECT_ID(N'" & tablename & "')"

        Using connection As SqlConnection = DBConnection.GetConnectionStage2

            connection.Open()

            Using cmd As New SqlCommand(SQLString, connection)

                bRetVal = cmd.ExecuteScalar

            End Using ' cmd

        End Using ' connection

        Return bRetVal

    End Function

    Public Shared Function DropColumn(colName As String, tableName As String) As Integer

        Dim bRetVal As Integer

        Dim SQLString As String = "ALTER TABLE " & tableName & " DROP COLUMN " & colName

        Using connection As SqlConnection = DBConnection.GetConnectionStage2

            connection.Open()

            Using cmd As New SqlCommand(SQLString, connection)

                bRetVal = cmd.ExecuteNonQuery

            End Using ' cmd

        End Using ' connection

        Return bRetVal

    End Function

    Public Shared Function RenameColumn(colName As String, tableName As String, newColName As String) As Integer

        Dim bRetVal As Integer

        Dim SQLString As String = "EXEC sp_rename '" & tableName & "." & colName & "', '" & newColName & "', 'COLUMN'"

        Using connection As SqlConnection = DBConnection.GetConnectionStage2

            connection.Open()

            Using cmd As New SqlCommand(SQLString, connection)

                bRetVal = cmd.ExecuteNonQuery

            End Using ' cmd

        End Using ' connection

        Return bRetVal


    End Function

    Public Shared Function HasIdentityColumnMaster(tableName As String) As Integer

        Dim bRetVal As Integer

        Dim SQLString As String = "SELECT Count(Column_ID) FROM sys.identity_columns WHERE OBJECT_NAME(object_id) = '" & tableName & "'"

        Using connection As SqlConnection = DBConnection.GetConnectionCentreProMaster

            connection.Open()

            Using cmd As New SqlCommand(SQLString, connection)

                bRetVal = cmd.ExecuteScalar

            End Using ' cmd

        End Using ' connection

        Return bRetVal

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

    Public Shared Function ImportTableToStage2(sTableName As String)


        ' No need to check for identiy column in stage2 as there are none!
        Dim SQLUpdate As String = "INSERT INTO " & sTableName & " SELECT * FROM CentrePro_intermediate.dbo." & sTableName

        Using connection As SqlConnection = DBConnection.GetConnectionStage2

            connection.Open()

            Try
                Using cmdUpdate As New SqlCommand(SQLUpdate, connection)
                    cmdUpdate.ExecuteNonQuery()
                End Using 'cmdUpdate
                Return True
            Catch ex As Exception
                Return False
            End Try

        End Using 'connection

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
                Using cmdUpdate As New SqlCommand(SQLUpdate, connection)
                    cmdUpdate.ExecuteNonQuery()
                End Using 'cmdUpdate
                Return True
            Catch ex As Exception
                Return False
            End Try

        End Using 'connection
    End Function

    Public Shared Function ImportStage2TableToMaster(sTableName As String)

        Dim SQLUpdate As String = "INSERT INTO " & sTableName & " SELECT * FROM CentrePro_Stage2.dbo." & sTableName

        Using connection As SqlConnection = DBConnection.GetConnectionCentreProMaster

            connection.Open()

            Try
                Using cmdUpdate As New SqlCommand(SQLUpdate, connection)
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
