Public Class clsGlobalEnum

    Public Enum conPMTTYPE As Long

        conPMTTYPE_CHECK = 1
        conPMTTYPE_CC = 2
        conPMTTYPE_CASH = 3
        'Public Const conPMTTYPE_COMP As Long = 4
        conPMTTYPE_StaffChg = 5
        'Public Const conPMTTYPE_OTHER As Long = 6
        conPMTTYPE_SPENDMNY = 7
        'Public Const conPMTTYPE_CAMPERSALE As Long = 8
        conPMTTYPE_DEPTTRNSFR = 9

    End Enum

    Public Enum conSALETYPE As Long

        conSALE = 1

    End Enum

    Public Enum conZOUTSTATUS As Long

        conNotZDOut = 1
        conPrevZDOut = 2
        conDateRange = 3

    End Enum

    Public Enum conDATECRITER As Long

        conAllDates = 1
        conSpecificDate = 2
        conDateRange = 3

    End Enum

    Public Enum conTRANSTYPE As Long

        conStoreCharge = 6

    End Enum

    Public Enum conSQLNAME As Long

        conDeptXFerDates = 1

    End Enum

    Public Enum conDBTYPE As Long

        conMSAccess = 1
        conSQLServer = 2

    End Enum

    Public Enum conLIVECHARGE As Long

        None = 0
        XCharge = 1
        CashLinq = 2

    End Enum

End Class
