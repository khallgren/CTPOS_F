Public Class frmTestData
    'ControlName = 0
    'LabelName = 1
    'FieldName = 2
    'ControlType = 3
    'ComboSQL = 4
    'Currency = 5
    'Editable = 6

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim ctlArray(3, 6) As String

        ctlArray(0, CtlArrayItems.ControlName) = "txtFirstName"
        ctlArray(0, CtlArrayItems.LabelName) = "lblFirstName"
        ctlArray(0, CtlArrayItems.FieldName) = "strStaffFName"
        ctlArray(0, CtlArrayItems.ControlType) = "Text"
        ctlArray(0, CtlArrayItems.ComboSQL) = ""
        ctlArray(0, CtlArrayItems.Currency) = "False"
        ctlArray(0, CtlArrayItems.Editable) = "True"

        ctlArray(1, CtlArrayItems.ControlName) = "txtLastName"
        ctlArray(1, CtlArrayItems.LabelName) = "lblLastName"
        ctlArray(1, CtlArrayItems.FieldName) = "strStaffLName"
        ctlArray(1, CtlArrayItems.ControlType) = "Text"
        ctlArray(1, CtlArrayItems.ComboSQL) = ""
        ctlArray(1, CtlArrayItems.Currency) = "False"
        ctlArray(1, CtlArrayItems.Editable) = "True"

        ctlArray(2, CtlArrayItems.ControlName) = "txtStaffID"
        ctlArray(2, CtlArrayItems.LabelName) = "lblStaffID"
        ctlArray(2, CtlArrayItems.FieldName) = "lngStaffID"
        ctlArray(2, CtlArrayItems.ControlType) = "Text"
        ctlArray(2, CtlArrayItems.ComboSQL) = ""
        ctlArray(2, CtlArrayItems.Currency) = "False"
        ctlArray(2, CtlArrayItems.Editable) = "False"

        ctlArray(3, CtlArrayItems.ControlName) = "chkChecked"
        ctlArray(3, CtlArrayItems.LabelName) = ""
        ctlArray(3, CtlArrayItems.FieldName) = "blnChecked"
        ctlArray(3, CtlArrayItems.ControlType) = "Checkbox"
        ctlArray(3, CtlArrayItems.ComboSQL) = ""
        ctlArray(3, CtlArrayItems.Currency) = "False"
        ctlArray(3, CtlArrayItems.Editable) = "True"

        subPopulateForm(Me, ctlArray, "Select * from tblResidentStaff where lngstaffid = 257", strPOSConn)

    End Sub



End Class