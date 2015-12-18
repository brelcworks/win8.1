Imports LiteDB
Public Class MONGO

End Class
Public Class BILLM
    Public Property Id() As Integer
        Get
            Return m_Id
        End Get
        Set
            m_Id = Value
        End Set
    End Property
    Private m_Id As Integer
    Public Property BID() As String
        Get
            Return M_BID
        End Get
        Set(ByVal VALUE As String)
            M_BID = VALUE
        End Set
    End Property
    Private M_BID As String
    Public Property BILL_NO() As String
        Get
            Return M_BILL_NO
        End Get
        Set(ByVal VALUE As String)
            M_BILL_NO = VALUE
        End Set
    End Property
    Private M_BILL_NO As String
    Public Property BDATE() As DateTime
        Get
            Return M_BDATE
        End Get
        Set(ByVal VALUE As DateTime)
            M_BDATE = VALUE
        End Set
    End Property
    Private M_BDATE As DateTime
    Public Property DNAME() As String
        Get
            Return M_DNAME
        End Get
        Set(ByVal VALUE As String)
            M_DNAME = VALUE
        End Set
    End Property
    Private M_DNAME As String
    Public Property CUST() As String
        Get
            Return M_CUST
        End Get
        Set(ByVal VALUE As String)
            M_CUST = VALUE
        End Set
    End Property
    Private M_CUST As String
    Public Property PART_NO() As String
        Get
            Return M_PART_NO
        End Get
        Set(ByVal VALUE As String)
            M_PART_NO = VALUE
        End Set
    End Property
    Private M_PART_NO As String
    Public Property PARTI() As String
        Get
            Return M_PARTI
        End Get
        Set(ByVal VALUE As String)
            M_PARTI = VALUE
        End Set
    End Property
    Private M_PARTI As String
    Public Property QTY() As String
        Get
            Return M_QTY
        End Get
        Set(ByVal VALUE As String)
            M_QTY = VALUE
        End Set
    End Property
    Private M_QTY As String
    Public Property MRP() As String
        Get
            Return M_MRP
        End Get
        Set(ByVal VALUE As String)
            M_MRP = VALUE
        End Set
    End Property
    Private M_MRP As String
    Public Property TOTAL() As String
        Get
            Return M_TOTAL
        End Get
        Set(ByVal VALUE As String)
            M_TOTAL = VALUE
        End Set
    End Property
    Private M_TOTAL As String
    Public Property SPRICE() As String
        Get
            Return M_SPRICE
        End Get
        Set(ByVal VALUE As String)
            M_SPRICE = VALUE
        End Set
    End Property
    Private M_SPRICE As String
    Public Property TAX() As String
        Get
            Return M_TAX
        End Get
        Set(ByVal VALUE As String)
            M_TAX = VALUE
        End Set
    End Property
    Private M_TAX As String
    Public Property TVAL() As String
        Get
            Return M_TVAL
        End Get
        Set(ByVal VALUE As String)
            M_TVAL = VALUE
        End Set
    End Property
    Private M_TVAL As String
    Public Property STOT() As String
        Get
            Return M_STOT
        End Get
        Set(ByVal VALUE As String)
            M_STOT = VALUE
        End Set
    End Property
    Private M_STOT As String
    Public Property CMP() As String
        Get
            Return M_CMP
        End Get
        Set(ByVal VALUE As String)
            M_CMP = VALUE
        End Set
    End Property
    Private M_CMP As String
    Public Property UNIT() As String
        Get
            Return M_UNIT
        End Get
        Set(ByVal VALUE As String)
            M_UNIT = VALUE
        End Set
    End Property
    Private M_UNIT As String
    Public Property USER() As String
        Get
            Return M_USER
        End Get
        Set(ByVal VALUE As String)
            M_USER = VALUE
        End Set
    End Property
    Private M_USER As String
    Public Property MODE() As String
        Get
            Return M_MODE
        End Get
        Set(ByVal VALUE As String)
            M_MODE = VALUE
        End Set
    End Property
    Private M_MODE As String
    Public Property SSTA() As String
        Get
            Return M_SSTA
        End Get
        Set(ByVal VALUE As String)
            M_SSTA = VALUE
        End Set
    End Property
    Private M_SSTA As String
    Public Property AEDT() As String
        Get
            Return M_AEDT
        End Get
        Set(ByVal VALUE As String)
            M_AEDT = VALUE
        End Set
    End Property
    Private M_AEDT As String
    Public Property LMODI() As String
        Get
            Return M_LMODI
        End Get
        Set(ByVal VALUE As String)
            M_LMODI = VALUE
        End Set
    End Property
    Private M_LMODI As String
    Public Property BILLID() As String
        Get
            Return M_BILLID
        End Get
        Set(ByVal VALUE As String)
            M_BILLID = VALUE
        End Set
    End Property
    Private M_BILLID As String
    Public Property DPCODE() As String
        Get
            Return M_DPCODE
        End Get
        Set(ByVal VALUE As String)
            M_DPCODE = VALUE
        End Set
    End Property
    Private M_DPCODE As String
End Class

Public Class STOCK
    Public Property _id() As ObjectId
        Get
            Return M_id
        End Get
        Private Set(ByVal VALUE As ObjectId)
            M_id = VALUE
        End Set
    End Property
    Private M_id As ObjectId
    Public Property RID() As String
        Get
            Return M_RID
        End Get
        Set(ByVal VALUE As String)
            M_RID = VALUE
        End Set
    End Property
    Private M_RID As String
    Public Property TYPE() As String
        Get
            Return M_TYPE
        End Get
        Set(ByVal VALUE As String)
            M_TYPE = VALUE
        End Set
    End Property
    Private M_TYPE As String
    Public Property PART_NO() As String
        Get
            Return M_PART_NO
        End Get
        Set(ByVal VALUE As String)
            M_PART_NO = VALUE
        End Set
    End Property
    Private M_PART_NO As String
    Public Property PARTI() As String
        Get
            Return M_PARTI
        End Get
        Set(ByVal VALUE As String)
            M_PARTI = VALUE
        End Set
    End Property
    Private M_PARTI As String
    Public Property MRP() As String
        Get
            Return M_MRP
        End Get
        Set(ByVal VALUE As String)
            M_MRP = VALUE
        End Set
    End Property
    Private M_MRP As String
    Public Property QTY() As String
        Get
            Return M_QTY
        End Get
        Set(ByVal VALUE As String)
            M_QTY = VALUE
        End Set
    End Property
    Private M_QTY As String
    Public Property TOTAL() As String
        Get
            Return M_TOTAL
        End Get
        Set(ByVal VALUE As String)
            M_TOTAL = VALUE
        End Set
    End Property
    Private M_TOTAL As String
    Public Property RACKNO() As String
        Get
            Return M_RACKNO
        End Get
        Set(ByVal VALUE As String)
            M_RACKNO = VALUE
        End Set
    End Property
    Private M_RACKNO As String
    Public Property TAX() As String
        Get
            Return M_TAX
        End Get
        Set(ByVal VALUE As String)
            M_TAX = VALUE
        End Set
    End Property
    Private M_TAX As String
    Public Property TVAL() As String
        Get
            Return M_TVAL
        End Get
        Set(ByVal VALUE As String)
            M_TVAL = VALUE
        End Set
    End Property
    Private M_TVAL As String
    Public Property STOTAL() As String
        Get
            Return M_STOTAL
        End Get
        Set(ByVal VALUE As String)
            M_STOTAL = VALUE
        End Set
    End Property
    Private M_STOTAL As String
    Public Property PPRICE() As String
        Get
            Return M_PPRICE
        End Get
        Set(ByVal VALUE As String)
            M_PPRICE = VALUE
        End Set
    End Property
    Private M_PPRICE As String
    Public Property UNIT() As String
        Get
            Return M_UNIT
        End Get
        Set(ByVal VALUE As String)
            M_UNIT = VALUE
        End Set
    End Property
    Private M_UNIT As String
    Public Property SPRICE() As String
        Get
            Return M_SPRICE
        End Get
        Set(ByVal VALUE As String)
            M_SPRICE = VALUE
        End Set
    End Property
    Private M_SPRICE As String
    Public Property SSTA() As String
        Get
            Return M_SSTA
        End Get
        Set(ByVal VALUE As String)
            M_SSTA = VALUE
        End Set
    End Property
    Private M_SSTA As String
    Public Property EOR() As String
        Get
            Return M_EOR
        End Get
        Set(ByVal VALUE As String)
            M_EOR = VALUE
        End Set
    End Property
    Private M_EOR As String
    Public Property GROP() As String
        Get
            Return M_GROP
        End Get
        Set(ByVal VALUE As String)
            M_GROP = VALUE
        End Set
    End Property
    Private M_GROP As String
    Public Property USER1() As String
        Get
            Return M_USER1
        End Get
        Set(ByVal VALUE As String)
            M_USER1 = VALUE
        End Set
    End Property
    Private M_USER1 As String
    Public Property LMODI() As String
        Get
            Return M_LMODI
        End Get
        Set(ByVal VALUE As String)
            M_LMODI = VALUE
        End Set
    End Property
    Private M_LMODI As String
End Class

Public Class PMRM
    Public Property _id() As ObjectId
        Get
            Return M_id
        End Get
        Private Set(ByVal VALUE As ObjectId)
            M_id = VALUE
        End Set
    End Property
    Private M_id As ObjectId
    Public Property SID() As String
        Get
            Return M_SID
        End Get
        Set(ByVal VALUE As String)
            M_SID = VALUE
        End Set
    End Property
    Private M_SID As String
    Public Property SNAME() As String
        Get
            Return M_SNAME
        End Get
        Set(ByVal VALUE As String)
            M_SNAME = VALUE
        End Set
    End Property
    Private M_SNAME As String
    Public Property ENGINE_NO() As String
        Get
            Return M_ENGINE_NO
        End Get
        Set(ByVal VALUE As String)
            M_ENGINE_NO = VALUE
        End Set
    End Property
    Private M_ENGINE_NO As String
    Public Property DOS() As DateTime
        Get
            Return M_DOS
        End Get
        Set(ByVal VALUE As DateTime)
            M_DOS = VALUE
        End Set
    End Property
    Private M_DOS As DateTime
    Public Property STYPE() As String
        Get
            Return M_STYPE
        End Get
        Set(ByVal VALUE As String)
            M_STYPE = VALUE
        End Set
    End Property
    Private M_STYPE As String
    Public Property HMR() As String
        Get
            Return M_HMR
        End Get
        Set(ByVal VALUE As String)
            M_HMR = VALUE
        End Set
    End Property
    Private M_HMR As String
    Public Property REPORT() As String
        Get
            Return M_REPORT
        End Get
        Set(ByVal VALUE As String)
            M_REPORT = VALUE
        End Set
    End Property
    Private M_REPORT As String
    Public Property TECHNICIAN() As String
        Get
            Return M_TECHNICIAN
        End Get
        Set(ByVal VALUE As String)
            M_TECHNICIAN = VALUE
        End Set
    End Property
    Private M_TECHNICIAN As String
    Public Property METERIAL() As String
        Get
            Return M_METERIAL
        End Get
        Set(ByVal VALUE As String)
            M_METERIAL = VALUE
        End Set
    End Property
    Private M_METERIAL As String
    Public Property CUST() As String
        Get
            Return M_CUST
        End Get
        Set(ByVal VALUE As String)
            M_CUST = VALUE
        End Set
    End Property
    Private M_CUST As String
    Public Property RECID() As String
        Get
            Return M_RECID
        End Get
        Set(ByVal VALUE As String)
            M_RECID = VALUE
        End Set
    End Property
    Private M_RECID As String
    Public Property CDATI() As DateTime
        Get
            Return M_CDATI
        End Get
        Set(ByVal VALUE As DateTime)
            M_CDATI = VALUE
        End Set
    End Property
    Private M_CDATI As DateTime
    Public Property DIST() As String
        Get
            Return M_DIST
        End Get
        Set(ByVal VALUE As String)
            M_DIST = VALUE
        End Set
    End Property
    Private M_DIST As String
    Public Property STATE() As String
        Get
            Return M_STATE
        End Get
        Set(ByVal VALUE As String)
            M_STATE = VALUE
        End Set
    End Property
    Private M_STATE As String
    Public Property CCATE() As String
        Get
            Return M_CCATE
        End Get
        Set(ByVal VALUE As String)
            M_CCATE = VALUE
        End Set
    End Property
    Private M_CCATE As String
    Public Property MODEL() As String
        Get
            Return M_MODEL
        End Get
        Set(ByVal VALUE As String)
            M_MODEL = VALUE
        End Set
    End Property
    Private M_MODEL As String
    Public Property DOI() As DateTime
        Get
            Return M_DOI
        End Get
        Set(ByVal VALUE As DateTime)
            M_DOI = VALUE
        End Set
    End Property
    Private M_DOI As DateTime
    Public Property DGNO() As String
        Get
            Return M_DGNO
        End Get
        Set(ByVal VALUE As String)
            M_DGNO = VALUE
        End Set
    End Property
    Private M_DGNO As String
    Public Property AMAKE() As String
        Get
            Return M_AMAKE
        End Get
        Set(ByVal VALUE As String)
            M_AMAKE = VALUE
        End Set
    End Property
    Private M_AMAKE As String
    Public Property ALSN() As String
        Get
            Return M_ALSN
        End Get
        Set(ByVal VALUE As String)
            M_ALSN = VALUE
        End Set
    End Property
    Private M_ALSN As String
    Public Property BSN() As String
        Get
            Return M_BSN
        End Get
        Set(ByVal VALUE As String)
            M_BSN = VALUE
        End Set
    End Property
    Private M_BSN As String
    Public Property CNAT() As String
        Get
            Return M_CNAT
        End Get
        Set(ByVal VALUE As String)
            M_CNAT = VALUE
        End Set
    End Property
    Private M_CNAT As String
    Public Property SERV() As String
        Get
            Return M_SERV
        End Get
        Set(ByVal VALUE As String)
            M_SERV = VALUE
        End Set
    End Property
    Private M_SERV As String
    Public Property RFAIL() As String
        Get
            Return M_RFAIL
        End Get
        Set(ByVal VALUE As String)
            M_RFAIL = VALUE
        End Set
    End Property
    Private M_RFAIL As String
    Public Property STA() As String
        Get
            Return M_STA
        End Get
        Set(ByVal VALUE As String)
            M_STA = VALUE
        End Set
    End Property
    Private M_STA As String
    Public Property WARR() As String
        Get
            Return M_WARR
        End Get
        Set(ByVal VALUE As String)
            M_WARR = VALUE
        End Set
    End Property
    Private M_WARR As String
    Public Property ACTION() As String
        Get
            Return M_ACTION
        End Get
        Set(ByVal VALUE As String)
            M_ACTION = VALUE
        End Set
    End Property
    Private M_ACTION As String
    Public Property OEA() As String
        Get
            Return M_OEA
        End Get
        Set(ByVal VALUE As String)
            M_OEA = VALUE
        End Set
    End Property
    Private M_OEA As String
    Public Property AMC() As String
        Get
            Return M_AMC
        End Get
        Set(ByVal VALUE As String)
            M_AMC = VALUE
        End Set
    End Property
    Private M_AMC As String
    Public Property TTR() As String
        Get
            Return M_TTR
        End Get
        Set(ByVal VALUE As String)
            M_TTR = VALUE
        End Set
    End Property
    Private M_TTR As String
    Public Property SLA() As String
        Get
            Return M_SLA
        End Get
        Set(ByVal VALUE As String)
            M_SLA = VALUE
        End Set
    End Property
    Private M_SLA As String
    Public Property TSLOT() As String
        Get
            Return M_TSLOT
        End Get
        Set(ByVal VALUE As String)
            M_TSLOT = VALUE
        End Set
    End Property
    Private M_TSLOT As String
    Public Property RESLA() As String
        Get
            Return M_RESLA
        End Get
        Set(ByVal VALUE As String)
            M_RESLA = VALUE
        End Set
    End Property
    Private M_RESLA As String
    Public Property KVA() As String
        Get
            Return M_KVA
        End Get
        Set(ByVal VALUE As String)
            M_KVA = VALUE
        End Set
    End Property
    Private M_KVA As String
    Public Property SSTA() As String
        Get
            Return M_SSTA
        End Get
        Set(ByVal VALUE As String)
            M_SSTA = VALUE
        End Set
    End Property
    Private M_SSTA As String
    Public Property LMODI() As String
        Get
            Return M_LMODI
        End Get
        Set(ByVal VALUE As String)
            M_LMODI = VALUE
        End Set
    End Property
    Private M_LMODI As String
    Public Property RECID1() As String
        Get
            Return M_RECID1
        End Get
        Set(ByVal VALUE As String)
            M_RECID1 = VALUE
        End Set
    End Property
    Private M_RECID1 As String
End Class

Public Class BILL1M
    Public Property _id() As ObjectId
        Get
            Return m__id
        End Get
        Private Set
            m__id = Value
        End Set
    End Property
    Private m__id As ObjectId
    Public Property BID() As String
        Get
            Return m_BID
        End Get
        Set
            m_BID = Value
        End Set
    End Property
    Private m_BID As String
    Public Property BDATE() As DateTime
        Get
            Return m_BDATE
        End Get
        Set
            m_BDATE = Value
        End Set
    End Property
    Private m_BDATE As DateTime
    Public Property BNO() As String
        Get
            Return m_BNO
        End Get
        Set
            m_BNO = Value
        End Set
    End Property
    Private m_BNO As String
    Public Property CUST() As String
        Get
            Return m_CUST
        End Get
        Set
            m_CUST = Value
        End Set
    End Property
    Private m_CUST As String
    Public Property SNAME() As String
        Get
            Return m_SNAME
        End Get
        Set
            m_SNAME = Value
        End Set
    End Property
    Private m_SNAME As String
    Public Property GTOT() As Decimal
        Get
            Return m_GTOT
        End Get
        Set
            m_GTOT = Value
        End Set
    End Property
    Private m_GTOT As Decimal
    Public Property TOTAL() As Decimal
        Get
            Return m_TOTAL
        End Get
        Set
            m_TOTAL = Value
        End Set
    End Property
    Private m_TOTAL As Decimal
    Public Property PAYMENT() As Decimal
        Get
            Return m_PAYMENT
        End Get
        Set
            m_PAYMENT = Value
        End Set
    End Property
    Private m_PAYMENT As Decimal
    Public Property SECTOR() As String
        Get
            Return m_SECTOR
        End Get
        Set
            m_SECTOR = Value
        End Set
    End Property
    Private m_SECTOR As String
    Public Property ADDRESS() As String
        Get
            Return m_ADDRESS
        End Get
        Set
            m_ADDRESS = Value
        End Set
    End Property
    Private m_ADDRESS As String
    Public Property ROUND() As Decimal
        Get
            Return m_ROUND
        End Get
        Set
            m_ROUND = Value
        End Set
    End Property
    Private m_ROUND As Decimal
    Public Property NTOT() As Decimal
        Get
            Return m_NTOT
        End Get
        Set
            m_NTOT = Value
        End Set
    End Property
    Private m_NTOT As Decimal
    Public Property TVAL() As Decimal
        Get
            Return m_TVAL
        End Get
        Set
            m_TVAL = Value
        End Set
    End Property
    Private m_TVAL As Decimal
    Public Property USER1() As String
        Get
            Return m_USER1
        End Get
        Set
            m_USER1 = Value
        End Set
    End Property
    Private m_USER1 As String
    Public Property MODE() As String
        Get
            Return m_MODE
        End Get
        Set
            m_MODE = Value
        End Set
    End Property
    Private m_MODE As String
    Public Property VNO() As String
        Get
            Return m_VNO
        End Get
        Set
            m_VNO = Value
        End Set
    End Property
    Private m_VNO As String
    Public Property CBILL() As Decimal
        Get
            Return m_CBILL
        End Get
        Set
            m_CBILL = Value
        End Set
    End Property
    Private m_CBILL As Decimal
    Public Property BAPAY() As Decimal
        Get
            Return m_BAPAY
        End Get
        Set
            m_BAPAY = Value
        End Set
    End Property
    Private m_BAPAY As Decimal
    Public Property BST() As String
        Get
            Return m_BST
        End Get
        Set
            m_BST = Value
        End Set
    End Property
    Private m_BST As String
    Public Property SSTA() As String
        Get
            Return m_SSTA
        End Get
        Set
            m_SSTA = Value
        End Set
    End Property
    Private m_SSTA As String
    Public Property DPCODE() As String
        Get
            Return m_DPCODE
        End Get
        Set
            m_DPCODE = Value
        End Set
    End Property
    Private m_DPCODE As String
    Public Property BID1() As String
        Get
            Return m_BID1
        End Get
        Set
            m_BID1 = Value
        End Set
    End Property
    Private m_BID1 As String
    Public Property LMODI() As String
        Get
            Return m_LMODI
        End Get
        Set
            m_LMODI = Value
        End Set
    End Property
    Private m_LMODI As String
    Public Property AEDT() As String
        Get
            Return m_AEDT
        End Get
        Set
            m_AEDT = Value
        End Set
    End Property
    Private m_AEDT As String
    Public Property BAMT() As String
        Get
            Return m_BAMT
        End Get
        Set
            m_BAMT = Value
        End Set
    End Property
    Private m_BAMT As String

End Class
Public Class MAINPOPUM
    Public Property _id() As ObjectId
        Get
            Return m__id
        End Get
        Private Set
            m__id = Value
        End Set
    End Property
    Private m__id As ObjectId
    Public Property RID() As String
        Get
            Return m_RID
        End Get
        Set
            m_RID = Value
        End Set
    End Property
    Private m_RID As String
    Public Property RID1() As String
        Get
            Return m_RID1
        End Get
        Set
            m_RID1 = Value
        End Set
    End Property
    Private m_RID1 As String
    Public Property SID() As String
        Get
            Return m_SID
        End Get
        Set
            m_SID = Value
        End Set
    End Property
    Private m_SID As String
    Public Property CNAME() As String
        Get
            Return m_CNAME
        End Get
        Set
            m_CNAME = Value
        End Set
    End Property
    Private m_CNAME As String
    Public Property SNAME() As String
        Get
            Return m_SNAME
        End Get
        Set
            m_SNAME = Value
        End Set
    End Property
    Private m_SNAME As String
    Public Property ENS() As String
        Get
            Return m_ENS
        End Get
        Set
            m_ENS = Value
        End Set
    End Property
    Private m_ENS As String
    Public Property ALSN() As String
        Get
            Return m_ALSN
        End Get
        Set
            m_ALSN = Value
        End Set
    End Property
    Private m_ALSN As String
    Public Property RAT_PH() As String
        Get
            Return m_RAT_PH
        End Get
        Set
            m_RAT_PH = Value
        End Set
    End Property
    Private m_RAT_PH As String
    Public Property PHASE() As String
        Get
            Return m_PHASE
        End Get
        Set
            m_PHASE = Value
        End Set
    End Property
    Private m_PHASE As String
    Public Property MODEL() As String
        Get
            Return m_MODEL
        End Get
        Set
            m_MODEL = Value
        End Set
    End Property
    Private m_MODEL As String
    Public Property BSN() As String
        Get
            Return m_BSN
        End Get
        Set
            m_BSN = Value
        End Set
    End Property
    Private m_BSN As String
    Public Property CPN() As String
        Get
            Return m_CPN
        End Get
        Set
            m_CPN = Value
        End Set
    End Property
    Private m_CPN As String
    Public Property PHNO() As String
        Get
            Return m_PHNO
        End Get
        Set
            m_PHNO = Value
        End Set
    End Property
    Private m_PHNO As String
    Public Property ADDR() As String
        Get
            Return m_ADDR
        End Get
        Set
            m_ADDR = Value
        End Set
    End Property
    Private m_ADDR As String
    Public Property DOC() As DateTime
        Get
            Return m_DOC
        End Get
        Set
            m_DOC = Value
        End Set
    End Property
    Private m_DOC As DateTime
    Public Property SPIN() As String
        Get
            Return m_SPIN
        End Get
        Set
            m_SPIN = Value
        End Set
    End Property
    Private m_SPIN As String
    Public Property AMC() As String
        Get
            Return m_AMC
        End Get
        Set
            m_AMC = Value
        End Set
    End Property
    Private m_AMC As String
    Public Property CHMR() As String
        Get
            Return m_CHMR
        End Get
        Set
            m_CHMR = Value
        End Set
    End Property
    Private m_CHMR As String
    Public Property CHMD() As DateTime
        Get
            Return m_CHMD
        End Get
        Set
            m_CHMD = Value
        End Set
    End Property
    Private m_CHMD As DateTime
    Public Property LHMR() As String
        Get
            Return m_LHMR
        End Get
        Set
            m_LHMR = Value
        End Set
    End Property
    Private m_LHMR As String
    Public Property LSD() As DateTime
        Get
            Return m_LSD
        End Get
        Set
            m_LSD = Value
        End Set
    End Property
    Private m_LSD As DateTime
    Public Property NSD() As DateTime
        Get
            Return m_NSD
        End Get
        Set
            m_NSD = Value
        End Set
    End Property
    Private m_NSD As DateTime
    Public Property AHM() As String
        Get
            Return m_AHM
        End Get
        Set
            m_AHM = Value
        End Set
    End Property
    Private m_AHM As String
    Public Property DGNO() As String
        Get
            Return m_DGNO
        End Get
        Set
            m_DGNO = Value
        End Set
    End Property
    Private m_DGNO As String
    Public Property ACTION() As String
        Get
            Return m_ACTION
        End Get
        Set
            m_ACTION = Value
        End Set
    End Property
    Private m_ACTION As String
    Public Property DIST() As String
        Get
            Return m_DIST
        End Get
        Set
            m_DIST = Value
        End Set
    End Property
    Private m_DIST As String
    Public Property STATE() As String
        Get
            Return m_STATE
        End Get
        Set
            m_STATE = Value
        End Set
    End Property
    Private m_STATE As String
    Public Property AMAKE() As String
        Get
            Return m_AMAKE
        End Get
        Set
            m_AMAKE = Value
        End Set
    End Property
    Private m_AMAKE As String
    Public Property WARR() As String
        Get
            Return m_WARR
        End Get
        Set
            m_WARR = Value
        End Set
    End Property
    Private m_WARR As String
    Public Property OEA() As String
        Get
            Return m_OEA
        End Get
        Set
            m_OEA = Value
        End Set
    End Property
    Private m_OEA As String
    Public Property SSTA() As String
        Get
            Return m_SSTA
        End Get
        Set
            m_SSTA = Value
        End Set
    End Property
    Private m_SSTA As String
    Public Property HMAGE() As String
        Get
            Return m_HMAGE
        End Get
        Set
            m_HMAGE = Value
        End Set
    End Property
    Private m_HMAGE As String
    Public Property DPCODE() As String
        Get
            Return m_DPCODE
        End Get
        Set
            m_DPCODE = Value
        End Set
    End Property
    Private m_DPCODE As String
    Public Property LMODI() As String
        Get
            Return m_LMODI
        End Get
        Set
            m_LMODI = Value
        End Set
    End Property
    Private m_LMODI As String
    Public Property AEDT() As String
        Get
            Return m_AEDT
        End Get
        Set
            m_AEDT = Value
        End Set
    End Property
    Private m_AEDT As String
    Public Property LLOP() As String
        Get
            Return m_LLOP
        End Get
        Set
            m_LLOP = Value
        End Set
    End Property
    Private m_LLOP As String
    Public Property SOLENOID() As String
        Get
            Return m_SOLENOID
        End Get
        Set
            m_SOLENOID = Value
        End Set
    End Property
    Private m_SOLENOID As String
    Public Property CHALT() As String
        Get
            Return m_CHALT
        End Get
        Set
            m_CHALT = Value
        End Set
    End Property
    Private m_CHALT As String
    Public Property STARTER() As String
        Get
            Return m_STARTER
        End Get
        Set
            m_STARTER = Value
        End Set
    End Property
    Private m_STARTER As String
    Public Property CNTYPE() As String
        Get
            Return m_CNTYPE
        End Get
        Set
            m_CNTYPE = Value
        End Set
    End Property
    Private m_CNTYPE As String
    Public Property CNMAKE() As String
        Get
            Return m_CNMAKE
        End Get
        Set
            m_CNMAKE = Value
        End Set
    End Property
    Private m_CNMAKE As String
    Public Property SAUTO() As String
        Get
            Return m_SAUTO
        End Get
        Set
            m_SAUTO = Value
        End Set
    End Property
    Private m_SAUTO As String
    Public Property FRAME() As String
        Get
            Return m_FRAME
        End Get
        Set
            m_FRAME = Value
        End Set
    End Property
    Private m_FRAME As String
    Public Property DSTA() As String
        Get
            Return m_DSTA
        End Get
        Set
            m_DSTA = Value
        End Set
    End Property
    Private m_DSTA As String

End Class

Public Class SHEET1M
    Public Property _id() As ObjectId
        Get
            Return m__id
        End Get
        Private Set
            m__id = Value
        End Set
    End Property
    Private m__id As ObjectId
    Public Property RID() As String
        Get
            Return m_RID
        End Get
        Set
            m_RID = Value
        End Set
    End Property
    Private m_RID As String
    Public Property PART_NO() As String
        Get
            Return m_PART_NO
        End Get
        Set
            m_PART_NO = Value
        End Set
    End Property
    Private m_PART_NO As String
    Public Property PARTI() As String
        Get
            Return m_PARTI
        End Get
        Set
            m_PARTI = Value
        End Set
    End Property
    Private m_PARTI As String
    Public Property MRP() As String
        Get
            Return m_MRP
        End Get
        Set
            m_MRP = Value
        End Set
    End Property
    Private m_MRP As String
    Public Property GROP() As String
        Get
            Return m_GROP
        End Get
        Set
            m_GROP = Value
        End Set
    End Property
    Private m_GROP As String
    Public Property CATE() As String
        Get
            Return m_CATE
        End Get
        Set
            m_CATE = Value
        End Set
    End Property
    Private m_CATE As String
    Public Property DPCODE() As String
        Get
            Return m_DPCODE
        End Get
        Set
            m_DPCODE = Value
        End Set
    End Property
    Private m_DPCODE As String
    Public Property LMODI() As String
        Get
            Return m_LMODI
        End Get
        Set
            m_LMODI = Value
        End Set
    End Property
    Private m_LMODI As String
    Public Property TRATE() As String
        Get
            Return m_TRATE
        End Get
        Set
            m_TRATE = Value
        End Set
    End Property
    Private m_TRATE As String
    Public Property RID1() As String
        Get
            Return m_RID1
        End Get
        Set
            m_RID1 = Value
        End Set
    End Property
    Private m_RID1 As String
    Public Property UNIT() As String
        Get
            Return m_UNIT
        End Get
        Set
            m_UNIT = Value
        End Set
    End Property
    Private m_UNIT As String
End Class
