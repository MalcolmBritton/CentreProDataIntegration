
Public Class Form1

    Dim thisDB As New cDatabase

    Private Sub cmdClose_Click(sender As Object, e As EventArgs) Handles cmdClose.Click
        Me.Close()
    End Sub

    Private Sub cmdCreateIntermediate_Click(sender As Object, e As EventArgs) Handles cmdCreateIntermediate.Click

        Dim tableNames As List(Of String) = cData.GetTableNames

        If tableNames.Count > 0 Then

            For Each tn As String In tableNames

                lbOutput.Items.Add("Adding Table to Intermediate - " & tn)
                If cData.ImportTableToIntermediate(tn, thisDB.ID, thisDB.DatabaseName) = True Then
                    lbOutput.Items.Add("Table " & tn & " added to Intermediate")
                    lbOutput.TopIndex = lbOutput.Items.Count - 1
                Else
                    lbError.Items.Add("Table " & tn & " NOT added to Intermediate")
                    lbError.TopIndex = lbError.Items.Count - 1
                End If
            Next
        End If

    End Sub

    Private Sub cmdEmpty_Click(sender As Object, e As EventArgs) Handles cmdEmpty.Click

        cData.EmptyIntermediateDatabase(False)
        lbOutput.Items.Add("Imtermediate database Emptied")
        lbOutput.TopIndex = lbOutput.Items.Count - 1

    End Sub

    Private Sub cmdReset_Click(sender As Object, e As EventArgs) Handles cmdReset.Click

        cData.EmptyIntermediateDatabase(True)
        lbOutput.Items.Add("Imtermediate database Emptied and Identity Columns reset")
        lbOutput.TopIndex = lbOutput.Items.Count - 1

    End Sub

    Private Sub cmdUpdateLinks_Click(sender As Object, e As EventArgs) Handles cmdUpdateLinks.Click

        ' This where all the foreign keys get updates

        'Accommodations
        lbOutput.Items.Add("Updating Accommodations table IDs...")
        lbOutput.TopIndex = lbOutput.Items.Count - 1
        Dim RoomsReturn As cMultiValueReturn = cData.UpdateAccommodationIDs()
        lbOutput.Items.AddRange(RoomsReturn.PassedHistory.Items)
        lbOutput.TopIndex = lbOutput.Items.Count - 1
        If RoomsReturn.OverallResult = False Then
            lbError.Items.AddRange(RoomsReturn.FailedHistory.Items)
            lbError.TopIndex = lbError.Items.Count - 1
        End If

        'Actions
        lbOutput.Items.Add("Updating Actions table IDs...")
        lbOutput.TopIndex = lbOutput.Items.Count - 1
        Dim ActionsReturn As cMultiValueReturn = cData.UpdateActionsIDs()
        lbOutput.Items.AddRange(ActionsReturn.PassedHistory.Items)
        lbOutput.TopIndex = lbOutput.Items.Count - 1
        If ActionsReturn.OverallResult = False Then
            lbError.Items.AddRange(ActionsReturn.FailedHistory.Items)
            lbError.TopIndex = lbError.Items.Count - 1
        End If

        ' AssetGroups
        lbOutput.Items.Add("Updating AssetGroups table IDs...")
        lbOutput.TopIndex = lbOutput.Items.Count - 1
        Dim AGReturns As cMultiValueReturn = cData.UpdateAssetGroupsIds()
        lbOutput.Items.AddRange(AGReturns.PassedHistory.Items)
        lbOutput.TopIndex = lbOutput.Items.Count - 1
        If AGReturns.OverallResult = False Then
            lbError.Items.AddRange(AGReturns.FailedHistory.Items)
            lbError.TopIndex = lbError.Items.Count - 1
        End If

        ' AssetTypes
        lbOutput.Items.Add("Updating AssetTypes table IDs...")
        lbOutput.TopIndex = lbOutput.Items.Count - 1
        Dim ATReturns As cMultiValueReturn = cData.UpdateAssetTypesIds()
        lbOutput.Items.AddRange(ATReturns.PassedHistory.Items)
        lbOutput.TopIndex = lbOutput.Items.Count - 1
        If ATReturns.OverallResult = False Then
            lbError.Items.AddRange(ATReturns.FailedHistory.Items)
            lbError.TopIndex = lbError.Items.Count - 1
        End If



    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles Me.Load

        ' Load databases into list box - use trident court to get the list from
        LoadDatabases()

    End Sub

    Private Sub LoadDatabases()

        lbBuildings.Items.Clear()

        Dim Dbs As List(Of cDatabase) = cData.GetDatabases
        lbBuildings.DisplayMember = "DatabaseName"
        lbBuildings.ValueMember = "ID"
        lbBuildings.DataSource = Dbs


    End Sub

    Private Sub lbBuildings_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lbBuildings.SelectedIndexChanged

        ' get the id and name for selected database
        thisDB.ID = lbBuildings.SelectedValue
        thisDB.DatabaseName = lbBuildings.Text

    End Sub

    Private Sub cmdClearOutput_Click(sender As Object, e As EventArgs) Handles cmdClearOutput.Click
        lbOutput.Items.Clear()
    End Sub

    Private Sub cmdClearErrors_Click(sender As Object, e As EventArgs) Handles cmdClearErrors.Click
        lbError.Items.Clear()
    End Sub
End Class
