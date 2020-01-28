
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

        Cursor = Cursors.WaitCursor

        lbOutput.Items.Add(" ********* Updating ID Links *********")

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

        ' Clients
        lbOutput.Items.Add("Updating Clients table IDs...")
        lbOutput.TopIndex = lbOutput.Items.Count - 1
        Dim ClientReturns As cMultiValueReturn = cData.UpdateClientIDs()
        lbOutput.Items.AddRange(ClientReturns.PassedHistory.Items)
        lbOutput.TopIndex = lbOutput.Items.Count - 1
        If ClientReturns.OverallResult = False Then
            lbError.Items.AddRange(ClientReturns.FailedHistory.Items)
            lbError.TopIndex = lbError.Items.Count - 1
        End If

        ' Companies
        lbOutput.Items.Add("Updating Companies table IDs...")
        lbOutput.TopIndex = lbOutput.Items.Count - 1
        Dim CoReturns As cMultiValueReturn = cData.UpdateCompanyIDs()
        lbOutput.Items.AddRange(CoReturns.PassedHistory.Items)
        lbOutput.TopIndex = lbOutput.Items.Count - 1
        If CoReturns.OverallResult = False Then
            lbError.Items.AddRange(CoReturns.FailedHistory.Items)
            lbError.TopIndex = lbError.Items.Count - 1
        End If

        ' ContactHistory
        lbOutput.Items.Add("Updating ContactHistory table IDs...")
        lbOutput.TopIndex = lbOutput.Items.Count - 1
        Dim CHReturns As cMultiValueReturn = cData.UpdateContactHistoryIDs()
        lbOutput.Items.AddRange(CHReturns.PassedHistory.Items)
        lbOutput.TopIndex = lbOutput.Items.Count - 1
        If CHReturns.OverallResult = False Then
            lbError.Items.AddRange(CHReturns.FailedHistory.Items)
            lbError.TopIndex = lbError.Items.Count - 1
        End If

        ' Contacts
        lbOutput.Items.Add("Updating Contacts table IDs...")
        lbOutput.TopIndex = lbOutput.Items.Count - 1
        Dim contactsReturns As cMultiValueReturn = cData.UpdateContactsIDs()
        lbOutput.Items.AddRange(contactsReturns.PassedHistory.Items)
        lbOutput.TopIndex = lbOutput.Items.Count - 1
        If contactsReturns.OverallResult = False Then
            lbError.Items.AddRange(contactsReturns.FailedHistory.Items)
            lbError.TopIndex = lbError.Items.Count - 1
        End If

        ' Delegates
        lbOutput.Items.Add("Updating Delegates table IDs...")
        lbOutput.TopIndex = lbOutput.Items.Count - 1
        Dim DelReturns As cMultiValueReturn = cData.UpdateDelegatesIDs()
        lbOutput.Items.AddRange(DelReturns.PassedHistory.Items)
        lbOutput.TopIndex = lbOutput.Items.Count - 1
        If DelReturns.OverallResult = False Then
            lbError.Items.AddRange(DelReturns.FailedHistory.Items)
            lbError.TopIndex = lbError.Items.Count - 1
        End If

        ' Documents
        lbOutput.Items.Add("Updating Documents table IDs...")
        lbOutput.TopIndex = lbOutput.Items.Count - 1
        Dim DocReturns As cMultiValueReturn = cData.UpdateDocumentsIDs()
        lbOutput.Items.AddRange(DocReturns.PassedHistory.Items)
        lbOutput.TopIndex = lbOutput.Items.Count - 1
        If DocReturns.OverallResult = False Then
            lbError.Items.AddRange(DocReturns.FailedHistory.Items)
            lbError.TopIndex = lbError.Items.Count - 1
        End If

        ' FrontDeskNotes
        lbOutput.Items.Add("Updating FrontDeskNotes table IDs...")
        lbOutput.TopIndex = lbOutput.Items.Count - 1
        Dim FDNReturns As cMultiValueReturn = cData.UpdateFrontDeskNotesIDs()
        lbOutput.Items.AddRange(FDNReturns.PassedHistory.Items)
        lbOutput.TopIndex = lbOutput.Items.Count - 1
        If FDNReturns.OverallResult = False Then
            lbError.Items.AddRange(FDNReturns.FailedHistory.Items)
            lbError.TopIndex = lbError.Items.Count - 1
        End If

        ' InvoiceExportBatches
        lbOutput.Items.Add("Updating FrontDeskNotes table IDs...")
        lbOutput.TopIndex = lbOutput.Items.Count - 1
        Dim IEBReturns As cMultiValueReturn = cData.UpdateInvoiceExportBatchesIDs()
        lbOutput.Items.AddRange(IEBReturns.PassedHistory.Items)
        lbOutput.TopIndex = lbOutput.Items.Count - 1
        If IEBReturns.OverallResult = False Then
            lbError.Items.AddRange(IEBReturns.FailedHistory.Items)
            lbError.TopIndex = lbError.Items.Count - 1
        End If

        ' InvoiceLines
        lbOutput.Items.Add("Updating InvoiceLines table IDs...")
        lbOutput.TopIndex = lbOutput.Items.Count - 1
        Dim ILReturns As cMultiValueReturn = cData.UpdateInvoiceLinesIDs()
        lbOutput.Items.AddRange(ILReturns.PassedHistory.Items)
        lbOutput.TopIndex = lbOutput.Items.Count - 1
        If ILReturns.OverallResult = False Then
            lbError.Items.AddRange(ILReturns.FailedHistory.Items)
            lbError.TopIndex = lbError.Items.Count - 1
        End If

        ' Invoices
        lbOutput.Items.Add("Updating Invoices table IDs...")
        lbOutput.TopIndex = lbOutput.Items.Count - 1
        Dim InvReturns As cMultiValueReturn = cData.UpdateInvoicesIDs()
        lbOutput.Items.AddRange(InvReturns.PassedHistory.Items)
        lbOutput.TopIndex = lbOutput.Items.Count - 1
        If InvReturns.OverallResult = False Then
            lbError.Items.AddRange(InvReturns.FailedHistory.Items)
            lbError.TopIndex = lbError.Items.Count - 1
        End If

        ' Licences
        lbOutput.Items.Add("Updating Licences table IDs...")
        lbOutput.TopIndex = lbOutput.Items.Count - 1
        Dim LReturns As cMultiValueReturn = cData.UpdateLicencesIDs()
        lbOutput.Items.AddRange(LReturns.PassedHistory.Items)
        lbOutput.TopIndex = lbOutput.Items.Count - 1
        If LReturns.OverallResult = False Then
            lbError.Items.AddRange(LReturns.FailedHistory.Items)
            lbError.TopIndex = lbError.Items.Count - 1
        End If

        ' LicenceTaperHeader
        lbOutput.Items.Add("Updating LicenceTaperHeader table IDs...")
        lbOutput.TopIndex = lbOutput.Items.Count - 1
        Dim LTHReturns As cMultiValueReturn = cData.UpdateLicenceTaperHeaderIDs()
        lbOutput.Items.AddRange(LTHReturns.PassedHistory.Items)
        lbOutput.TopIndex = lbOutput.Items.Count - 1
        If LTHReturns.OverallResult = False Then
            lbError.Items.AddRange(LTHReturns.FailedHistory.Items)
            lbError.TopIndex = lbError.Items.Count - 1
        End If

        ' Meters
        lbOutput.Items.Add("Updating Meters table IDs...")
        lbOutput.TopIndex = lbOutput.Items.Count - 1
        Dim MetersReturns As cMultiValueReturn = cData.UpdateMetersIDs()
        lbOutput.Items.AddRange(MetersReturns.PassedHistory.Items)
        lbOutput.TopIndex = lbOutput.Items.Count - 1
        If MetersReturns.OverallResult = False Then
            lbError.Items.AddRange(MetersReturns.FailedHistory.Items)
            lbError.TopIndex = lbError.Items.Count - 1
        End If

        ' PaymentExportBatches
        lbOutput.Items.Add("Updating PaymentExportBatches table IDs...")
        lbOutput.TopIndex = lbOutput.Items.Count - 1
        Dim PEBReturns As cMultiValueReturn = cData.UpdatePaymentExportBatchesIDs()
        lbOutput.Items.AddRange(PEBReturns.PassedHistory.Items)
        lbOutput.TopIndex = lbOutput.Items.Count - 1
        If PEBReturns.OverallResult = False Then
            lbError.Items.AddRange(PEBReturns.FailedHistory.Items)
            lbError.TopIndex = lbError.Items.Count - 1
        End If

        ' Persons
        lbOutput.Items.Add("Updating Persons table IDs...")
        lbOutput.TopIndex = lbOutput.Items.Count - 1
        Dim PersonsReturns As cMultiValueReturn = cData.UpdatePersonsIDs()
        lbOutput.Items.AddRange(PersonsReturns.PassedHistory.Items)
        lbOutput.TopIndex = lbOutput.Items.Count - 1
        If PersonsReturns.OverallResult = False Then
            lbError.Items.AddRange(PersonsReturns.FailedHistory.Items)
            lbError.TopIndex = lbError.Items.Count - 1
        End If

        ' RoomBookings
        lbOutput.Items.Add("Updating RoomBookings table IDs...")
        lbOutput.TopIndex = lbOutput.Items.Count - 1
        Dim RBReturns As cMultiValueReturn = cData.UpdateRoomBookingsIDs()
        lbOutput.Items.AddRange(RBReturns.PassedHistory.Items)
        lbOutput.TopIndex = lbOutput.Items.Count - 1
        If RBReturns.OverallResult = False Then
            lbError.Items.AddRange(RBReturns.FailedHistory.Items)
            lbError.TopIndex = lbError.Items.Count - 1
        End If

        ' RoomBookingStatus
        lbOutput.Items.Add("Updating RoomBookingStatus table IDs...")
        lbOutput.TopIndex = lbOutput.Items.Count - 1
        Dim RBSReturns As cMultiValueReturn = cData.UpdateRoomBookingStatusIDs()
        lbOutput.Items.AddRange(RBSReturns.PassedHistory.Items)
        lbOutput.TopIndex = lbOutput.Items.Count - 1
        If RBSReturns.OverallResult = False Then
            lbError.Items.AddRange(RBSReturns.FailedHistory.Items)
            lbError.TopIndex = lbError.Items.Count - 1
        End If

        ' ServiceChargeItems
        lbOutput.Items.Add("Updating ServiceChargeItems table IDs...")
        lbOutput.TopIndex = lbOutput.Items.Count - 1
        Dim SCIReturns As cMultiValueReturn = cData.UpdateServiceChargeItemsIDs()
        lbOutput.Items.AddRange(SCIReturns.PassedHistory.Items)
        lbOutput.TopIndex = lbOutput.Items.Count - 1
        If SCIReturns.OverallResult = False Then
            lbError.Items.AddRange(SCIReturns.FailedHistory.Items)
            lbError.TopIndex = lbError.Items.Count - 1
        End If

        ' ServiceChargeTypes
        lbOutput.Items.Add("Updating ServiceChargeTypes table IDs...")
        lbOutput.TopIndex = lbOutput.Items.Count - 1
        Dim SCTReturns As cMultiValueReturn = cData.UpdateServiceChargeTypesIDs()
        lbOutput.Items.AddRange(SCTReturns.PassedHistory.Items)
        lbOutput.TopIndex = lbOutput.Items.Count - 1
        If SCTReturns.OverallResult = False Then
            lbError.Items.AddRange(SCTReturns.FailedHistory.Items)
            lbError.TopIndex = lbError.Items.Count - 1
        End If

        ' TaskPriority
        lbOutput.Items.Add("Updating TaskPriority table IDs...")
        lbOutput.TopIndex = lbOutput.Items.Count - 1
        Dim TPReturns As cMultiValueReturn = cData.UpdateTaskPriorityIDs()
        lbOutput.Items.AddRange(TPReturns.PassedHistory.Items)
        lbOutput.TopIndex = lbOutput.Items.Count - 1
        If TPReturns.OverallResult = False Then
            lbError.Items.AddRange(TPReturns.FailedHistory.Items)
            lbError.TopIndex = lbError.Items.Count - 1
        End If

        ' Tasks
        lbOutput.Items.Add("Updating Tasks table IDs...")
        lbOutput.TopIndex = lbOutput.Items.Count - 1
        Dim TaskReturns As cMultiValueReturn = cData.UpdateTasksIDs()
        lbOutput.Items.AddRange(TaskReturns.PassedHistory.Items)
        lbOutput.TopIndex = lbOutput.Items.Count - 1
        If TaskReturns.OverallResult = False Then
            lbError.Items.AddRange(TaskReturns.FailedHistory.Items)
            lbError.TopIndex = lbError.Items.Count - 1
        End If

        ' TaskStatus
        lbOutput.Items.Add("Updating TaskStatus table IDs...")
        lbOutput.TopIndex = lbOutput.Items.Count - 1
        Dim TSReturns As cMultiValueReturn = cData.UpdateTaskStatusIDs()
        lbOutput.Items.AddRange(TSReturns.PassedHistory.Items)
        lbOutput.TopIndex = lbOutput.Items.Count - 1
        If TSReturns.OverallResult = False Then
            lbError.Items.AddRange(TSReturns.FailedHistory.Items)
            lbError.TopIndex = lbError.Items.Count - 1
        End If

        ' UserGroups
        lbOutput.Items.Add("Updating UserGroups table IDs...")
        lbOutput.TopIndex = lbOutput.Items.Count - 1
        Dim UGReturns As cMultiValueReturn = cData.UpdateUserGroupIDs()
        lbOutput.Items.AddRange(UGReturns.PassedHistory.Items)
        lbOutput.TopIndex = lbOutput.Items.Count - 1
        If UGReturns.OverallResult = False Then
            lbError.Items.AddRange(UGReturns.FailedHistory.Items)
            lbError.TopIndex = lbError.Items.Count - 1
        End If

        ' UserList
        lbOutput.Items.Add("Updating UserList table IDs...")
        lbOutput.TopIndex = lbOutput.Items.Count - 1
        Dim ULReturns As cMultiValueReturn = cData.UpdateUserListIDs()
        lbOutput.Items.AddRange(ULReturns.PassedHistory.Items)
        lbOutput.TopIndex = lbOutput.Items.Count - 1
        If ULReturns.OverallResult = False Then
            lbError.Items.AddRange(ULReturns.FailedHistory.Items)
            lbError.TopIndex = lbError.Items.Count - 1
        End If

        ' VATRates
        lbOutput.Items.Add("Updating VATRates table IDs...")
        lbOutput.TopIndex = lbOutput.Items.Count - 1
        Dim VRReturns As cMultiValueReturn = cData.UpdateVATRAtesIDs()
        lbOutput.Items.AddRange(VRReturns.PassedHistory.Items)
        lbOutput.TopIndex = lbOutput.Items.Count - 1
        If VRReturns.OverallResult = False Then
            lbError.Items.AddRange(VRReturns.FailedHistory.Items)
            lbError.TopIndex = lbError.Items.Count - 1
        End If

        ' ListData
        lbOutput.Items.Add("Updating ListData table IDs...")
        lbOutput.TopIndex = lbOutput.Items.Count - 1
        Dim LDReturns As cMultiValueReturn = cData.UpdateListDataIDs()
        lbOutput.Items.AddRange(LDReturns.PassedHistory.Items)
        lbOutput.TopIndex = lbOutput.Items.Count - 1
        If LDReturns.OverallResult = False Then
            lbError.Items.AddRange(LDReturns.FailedHistory.Items)
            lbError.TopIndex = lbError.Items.Count - 1
        End If

        lbOutput.Items.Add(" **** Finished Updating ID Links ****")
        lbOutput.TopIndex = lbOutput.Items.Count - 1

        Cursor = Cursors.Default

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

    Private Sub cmdDropOldID_Click(sender As Object, e As EventArgs) Handles cmdDropOldID.Click

        Dim tableNames As List(Of String) = cData.GetTableNames

        If tableNames.Count > 0 Then

            For Each tn As String In tableNames

                If cData.HasColumn("ID", tn) > 0 Then

                    lbOutput.Items.Add("Dropping ID Column from " & tn)
                    lbOutput.TopIndex = lbOutput.Items.Count - 1
                    cData.DropColumn("ID", tn)
                    If cData.HasColumn("NewID", tn) Then
                        lbOutput.Items.Add("Renamin NewID to ID in " & tn)
                        lbOutput.TopIndex = lbOutput.Items.Count - 1
                        cData.RenameColumn("NewID", tn, "ID")
                    End If
                End If

            Next

        End If

    End Sub

    Private Sub cmdCreateIntermediateDatabase_Click(sender As Object, e As EventArgs) Handles cmdCreateIntermediateDatabase.Click

        Dim ofd As New OpenFileDialog
        Dim result As DialogResult = ofd.ShowDialog()

        If result = Windows.Forms.DialogResult.OK Then
            cData.CreateIntermediateDatabase(ofd.FileName)
        End If


    End Sub
End Class
