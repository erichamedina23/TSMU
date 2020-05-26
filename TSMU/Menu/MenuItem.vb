Public Class MenuItem
    Public Sub New()
        ActionType = TSMU.ActionType.FORM
        Items = New List(Of MenuItem)()
        Key = 0
        FormType = FormTypes.FORM_NONE
        Dialog = False
        Duplicate = False
        Popup = False
    End Sub

    Public Property Group() As String
        Get
            Return m_Group
        End Get
        Set
            m_Group = Value
        End Set
    End Property
    Private m_Group As String

    Public Property Dialog() As Boolean
        Get
            Return m_Dialog
        End Get
        Set
            m_Dialog = Value
        End Set
    End Property
    Private m_Dialog As Boolean

    Public Property Popup() As Boolean
        Get
            Return m_Popup
        End Get
        Set
            m_Popup = Value
        End Set
    End Property
    Private m_Popup As Boolean

    Public Property Duplicate() As Boolean
        Get
            Return m_Duplicate
        End Get
        Set
            m_Duplicate = Value
        End Set
    End Property
    Private m_Duplicate As Boolean

    Public Property Type() As String
        Get
            Return m_Type
        End Get
        Set
            m_Type = Value
        End Set
    End Property
    Private m_Type As String

    Public Property Page() As String
        Get
            Return m_Page
        End Get
        Set
            m_Page = Value
        End Set
    End Property
    Private m_Page As String

    Public Property GroupIndex() As Integer
        Get
            Return m_GroupIndex
        End Get
        Set
            m_GroupIndex = Value
        End Set
    End Property
    Private m_GroupIndex As Integer

    Public Property PageIndex() As Integer
        Get
            Return m_PageIndex
        End Get
        Set
            m_PageIndex = Value
        End Set
    End Property
    Private m_PageIndex As Integer

    Public Property Text() As String
        Get
            Return m_Text
        End Get
        Set
            m_Text = Value
        End Set
    End Property
    Private m_Text As String

    Public Property Index() As Integer
        Get
            Return m_Index
        End Get
        Set
            m_Index = Value
        End Set
    End Property
    Private m_Index As Integer

    Public Property Image() As Image
        Get
            Return m_Image
        End Get
        Set
            m_Image = Value
        End Set
    End Property
    Private m_Image As Image

    Public Property RibbonType() As Integer
        Get
            Return m_RibbonType
        End Get
        Set
            m_RibbonType = Value
        End Set
    End Property
    Private m_RibbonType As Integer

    Public Property Icon() As Image
        Get
            Return m_Icon
        End Get
        Set
            m_Icon = Value
        End Set
    End Property
    Private m_Icon As Image

    Public Property ActionType() As Integer
        Get
            Return m_ActionType
        End Get
        Set
            m_ActionType = Value
        End Set
    End Property
    Private m_ActionType As Integer

    Public Property Items() As List(Of MenuItem)
        Get
            Return m_Items
        End Get
        Set
            m_Items = Value
        End Set
    End Property
    Private m_Items As List(Of MenuItem)

    Public Property Url() As String
        Get
            Return m_Url
        End Get
        Set
            m_Url = Value
        End Set
    End Property
    Private m_Url As String

    Public Property Key() As Integer
        Get
            Return m_Key
        End Get
        Set
            m_Key = Value
        End Set
    End Property
    Private m_Key As Integer

    Public Property FormType() As Integer
        Get
            Return m_FormType
        End Get
        Set
            m_FormType = Value
        End Set
    End Property
    Private m_FormType As Integer
End Class
