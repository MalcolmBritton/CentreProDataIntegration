Public Class Form1
    Private Sub cmdClose_Click(sender As Object, e As EventArgs) Handles cmdClose.Click
        Me.Close()
    End Sub

    Private Sub cmdCreateIntermediate_Click(sender As Object, e As EventArgs) Handles cmdCreateIntermediate.Click

        Dim tableNames As List(Of String) = cData.GetTableNames

        If tableNames.Count > 0 Then

            For Each tn As String In tableNames

                ' NOT BusinessCentre Table
                If tn.ToUpper <> "BUSINESSCENTRE" Then
                    lbOutput.Items.Add("Adding Table to Intermediate - " & tn)
                    If cData.ImportTableToIntermediate(tn, 1, "CentrePro_UM_1282") = True Then
                        lbOutput.Items.Add("Table " & tn & " added to Intermediate")
                        lbOutput.TopIndex = lbOutput.Items.Count - 1
                    Else
                        lbError.Items.Add("Table " & tn & " NOT added to Intermediate")
                        lbError.TopIndex = lbError.Items.Count - 1
                    End If
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
End Class
