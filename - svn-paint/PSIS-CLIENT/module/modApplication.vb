Module modInitialize
#Region "Constant"
    Public Const BTN_PROGRESS As String = "F2_1,F2_3"
    Public Const BTN_WBS As String = "F2_2"
    Public Const BTN_SCREEN As String = "F1,F4_1,F4_2,F4_3,F5_1,F5_2,F5_3"
#End Region

#Region "Enumerator"
    Public Enum enuScreenName
        None
        Instruction_Data
        WBS
        Finishing_Line
        WBS_Monitoring
        Paint_Shop
        Paint
        Production_Tracking
        WBS_Pass_Result
        Paint_Pass_Result
        PBR_Pass_Result
        Option_Master
        PLC_Master
        Process_Master
        Model_Option_Setting
        Process_Option_Setting
        Data_Log
        Paint_Progress_Result
        Process_Group_Result
    End Enum
#End Region

#Region "Attribute"
    Private m_enuScreenName As enuScreenName
    Private m_strMenuLists As New List(Of String)
    Private m_ds As DataSet
#End Region

#Region "Constructor"

#End Region

#Region "Property"
    Public Property ScreenName() As enuScreenName
        Get
            Return m_enuScreenName
        End Get
        Set(ByVal value As enuScreenName)
            m_enuScreenName = value
        End Set
    End Property

    Public Property MenuLists() As List(Of String)
        Get
            Return m_strMenuLists
        End Get
        Set(ByVal value As List(Of String))
            m_strMenuLists = value
        End Set
    End Property

    Public ReadOnly Property BtnsProgress() As String()
        Get
            Return BTN_PROGRESS.Split(",")
        End Get
    End Property

    Public ReadOnly Property BtnsWBS() As String()
        Get
            Return BTN_WBS.Split(",")
        End Get
    End Property

    Public ReadOnly Property BtnsScreen() As String()
        Get
            Return BTN_SCREEN.Split(",")
        End Get
    End Property

    Public ReadOnly Property ProcTypes() As dsPAINT.dtPROCESS_MSTDataTable.enuProcessType()
        Get
            Return System.Enum.GetValues(GetType(dsPAINT.dtPROCESS_MSTDataTable.enuProcessType))
        End Get
    End Property

#End Region

#Region "Method"

#End Region

#Region "Event"

#End Region
End Module

Module modFunction
#Region "Constant"

#End Region

#Region "Attribute"

#End Region

#Region "Constructor"

#End Region

#Region "Property"

#End Region

#Region "Method"

    Public Function ParseColumnName(ByVal strColumnName As String) As String
        Return strColumnName.ToUpper.Replace("_", " ")
    End Function

    Public Function ParseColumn(ByVal strColumnName As String) As String
        Return strColumnName.ToUpper.Replace(" ", "_")
    End Function

    Public Function SelectedParam1(ByVal nScreenName As enuScreenName, _
                                   ByVal ltmRow As ListViewItem) As String
        Dim strParam1 As String = String.Empty

        Select Case nScreenName
            Case enuScreenName.PBR_Pass_Result
                strParam1 &= ltmRow.SubItems.Item(0).Text + "," + ltmRow.SubItems.Item(1).Text
            Case enuScreenName.Process_Master, enuScreenName.Process_Option_Setting
                strParam1 &= ltmRow.SubItems.Item(ltmRow.SubItems.Count - 2).Text
            Case enuScreenName.Model_Option_Setting
                strParam1 &= ltmRow.SubItems.Item(0).Text.Substring(0, 3)
            Case enuScreenName.Option_Master
                strParam1 &= ltmRow.SubItems.Item(ltmRow.SubItems.Count - 2).Text
            Case Else
                strParam1 &= ltmRow.SubItems.Item(0).Text
        End Select

        Return strParam1
    End Function

    Public Function SelectedParam2(ByVal nScreenName As enuScreenName, _
                                   ByVal ltmRow As ListViewItem) As String
        Dim strParam2 As String = String.Empty

        Select Case nScreenName
            Case enuScreenName.PBR_Pass_Result
                strParam2 &= ltmRow.SubItems.Item(7).Text + "," + ltmRow.SubItems.Item(8).Text + "," + ltmRow.SubItems.Item(13).Text
            Case enuScreenName.PLC_Master
                strParam2 &= ltmRow.SubItems.Item(ltmRow.SubItems.Count - 1).Text
            Case enuScreenName.Model_Option_Setting
                strParam2 = ltmRow.SubItems.Item(0).Text.Substring(3, 5)
            Case enuScreenName.Process_Option_Setting, enuScreenName.Process_Master
                strParam2 = ltmRow.SubItems.Item(0).Text
            Case Else
                strParam2 = ltmRow.SubItems.Item(1).Text
        End Select

        Return strParam2
    End Function

    Public Sub LoadColumnWidth(ByVal nScreenName As enuScreenName, _
                               ByVal ctrlView As Control, _
                               ByVal ctrlData As ListView)
        Dim strScreenColumnWidth As String = String.Empty

        If My.Settings.Screen_ColumnWidth Is Nothing Then
            My.Settings.Screen_ColumnWidth = New System.Collections.Specialized.StringCollection
            My.Settings.Save()
        End If

        Dim i As Integer
        For i = 0 To My.Settings.Screen_ColumnWidth.Count - 1
            Dim strWidth As String = My.Settings.Screen_ColumnWidth(i)
            If nScreenName.ToString = strWidth.Split(",").First Then
                strScreenColumnWidth = My.Settings.Screen_ColumnWidth(i)

                Exit For
            End If
        Next i

        If strScreenColumnWidth <> String.Empty Then
            Dim strScreenColumnWidths() As String = strScreenColumnWidth.Split(",")
            For i = 1 To strScreenColumnWidths.Count - 1
                If i <= ctrlData.Columns.Count Then
                    Dim col As ColumnHeader = ctrlData.Columns(i - 1)

                    If TypeOf (ctrlView) Is ctrlOptionList Then col.TextAlign = HorizontalAlignment.Center
                    col.Width = strScreenColumnWidths(i)
                End If
            Next i
        Else
            If TypeOf (ctrlView) Is ctrlList Or TypeOf (ctrlView) Is ctrlProcMstList Then
                For Each col As ColumnHeader In ctrlData.Columns
                    col.Width = -2
                Next
            ElseIf TypeOf (ctrlView) Is ctrlOptionList Then
                For Each col As ColumnHeader In ctrlData.Columns
                    col.TextAlign = HorizontalAlignment.Center

                    Select Case col.Index
                        Case 0
                            col.Width = 100
                        Case Else
                            col.Width = 175
                    End Select
                Next
            End If
        End If
    End Sub

    Public Sub StoreColumnWidth(ByVal nScreenName As enuScreenName, _
                                ByVal ctrlView As Control, _
                                ByVal ctrlData As ListView)
        Dim strScreenColumnWidth As String = nScreenName.ToString

        For Each col As ColumnHeader In ctrlData.Columns
            strScreenColumnWidth &= String.Format(",{0}", col.Width)
        Next col

        If My.Settings.Screen_ColumnWidth Is Nothing Then
            My.Settings.Screen_ColumnWidth = New System.Collections.Specialized.StringCollection
            My.Settings.Save()
        End If

        Dim i As Integer
        For i = 0 To My.Settings.Screen_ColumnWidth.Count - 1
            Dim strWidth As String = My.Settings.Screen_ColumnWidth(i)
            If nScreenName.ToString = strWidth.Split(",").First Then
                My.Settings.Screen_ColumnWidth(i) = strScreenColumnWidth
                My.Settings.Save()

                Exit For
            End If
        Next i

        If i > My.Settings.Screen_ColumnWidth.Count - 1 Then
            My.Settings.Screen_ColumnWidth.Add(strScreenColumnWidth)
        End If
    End Sub

    ' ''Reload Button
    Public Sub NavigateCurrent(ByVal nScreenName As enuScreenName, _
                               ByVal ctrlData As ListView, _
                               ByVal objList As clsModelBase)

        Dim strParam1 As String = String.Empty
        Dim strParam2 As String = String.Empty

        If ctrlData.Items.Count > 0 And strParam1 = String.Empty And strParam2 = String.Empty Then
            Dim objFirstRow As ListViewItem

            Select Case ScreenName
                Case enuScreenName.Model_Option_Setting, enuScreenName.Process_Option_Setting
                    objFirstRow = ctrlData.Items(3)
                Case Else
                    objFirstRow = ctrlData.Items(0)
            End Select

            strParam1 = SelectedParam1(nScreenName, objFirstRow)
            strParam2 = SelectedParam2(nScreenName, objFirstRow)
        End If

        NavigateTo(objList, strParam1, strParam2, ctrlData)
    End Sub

    ' ''Up
    Public Sub NavigateUp(ByVal nScreenName As enuScreenName, _
                          ByVal ctrlData As ListView, _
                          ByVal objList As clsModelBase)
        Dim strParam1 As String
        Dim strParam2 As String

        If ctrlData.Focus AndAlso ctrlData.Cursor = Cursors.AppStarting Then
            Dim objFirstRow As ListViewItem

            Select Case ScreenName
                Case enuScreenName.Model_Option_Setting, enuScreenName.Process_Option_Setting
                    objFirstRow = ctrlData.Items(3)
                Case Else
                    objFirstRow = ctrlData.Items(0)
            End Select

            ' ToDo: Filter index_no, skip if already at top
            'If objFirstRow.SubItems.Item(INDEX_NO_COLUMN).Text <> 1 Then
            strParam1 = SelectedParam1(nScreenName, objFirstRow)
            strParam2 = SelectedParam2(nScreenName, objFirstRow)

            objList.LoadData(strParam1, strParam2, clsModelBase.enuFillBy.Up)

            Dim objPrevRow As ListViewItem = objList.Rows(objList.Rows.Length - 1)

            Dim prevParam1 As String = SelectedParam1(nScreenName, objPrevRow)
            Dim prevParam2 As String = SelectedParam2(nScreenName, objPrevRow)

            NavigateTo(objList, prevParam1, prevParam2, ctrlData)
        End If
    End Sub

    ' ''Previous Button
    Public Sub NavigatePrevious(ByVal nScreenName As enuScreenName, _
                                ByVal ctrlData As ListView, _
                                ByVal objList As clsModelBase)
        Dim strParam1 As String
        Dim strParam2 As String

        If ctrlData.Items.Count > 0 Then
            Dim objFirstRow As ListViewItem

            Select Case ScreenName
                Case enuScreenName.Model_Option_Setting, enuScreenName.Process_Option_Setting
                    objFirstRow = ctrlData.Items(3)
                Case Else
                    objFirstRow = ctrlData.Items(0)
            End Select

            ' ToDo: Filter index_no, skip if already at top
            strParam1 = SelectedParam1(nScreenName, objFirstRow)
            strParam2 = SelectedParam2(nScreenName, objFirstRow)

            objList.LoadData(strParam1, strParam2, clsModelBase.enuFillBy.PrevBtn)

            If objList.Rows.Count > 0 Then
                Dim objPrevRow As ListViewItem = objList.Rows(objList.Rows.Length - 1)

                Dim prevParam1 As String = SelectedParam1(nScreenName, objPrevRow)
                Dim prevParam2 As String = SelectedParam2(nScreenName, objPrevRow)

                NavigateTo(objList, prevParam1, prevParam2, ctrlData)
            End If
        End If
    End Sub

    ' ''Next Button
    Public Sub NavigateNext(ByVal nScreenName As enuScreenName, _
                            ByVal ctrlData As ListView, _
                            ByVal objList As clsModelBase)

        Dim strParam1 As String = String.Empty
        Dim strParam2 As String = String.Empty

        If ctrlData.Items.Count > 0 Then
            Dim objLastRow As ListViewItem = ctrlData.Items(ctrlData.Items.Count - 1)

            strParam1 = SelectedParam1(nScreenName, objLastRow)
            strParam2 = SelectedParam2(nScreenName, objLastRow)
        End If

        objList.LoadData(strParam1, strParam2, clsModelBase.enuFillBy.NextBtn)

        If (ctrlData.Items.Count > 0 AndAlso objList.Rows.Length = 2) _
                OrElse (ctrlData.Items.Count = 0 And objList.Rows.Length > 0) Then
            Dim objNextRow As ListViewItem = objList.Rows(IIf(ctrlData.Items.Count > 0, 1, 0))

            Dim nextParam1 As String = SelectedParam1(nScreenName, objNextRow)
            Dim nextParam2 As String = SelectedParam2(nScreenName, objNextRow)

            NavigateTo(objList, nextParam1, nextParam2, ctrlData)
        End If
    End Sub

    ' ''Down
    Public Sub NavigateDown(ByVal nScreenName As enuScreenName, _
                            ByVal ctrlData As ListView, _
                            ByVal objList As clsModelBase)
        Dim strParam1 As String
        Dim strParam2 As String

        Dim blnManyItems As Boolean = True
        blnManyItems = IIf(ScreenName = enuScreenName.Model_Option_Setting Or _
                           ScreenName = enuScreenName.Process_Option_Setting, _
                           ctrlData.Items.Count > 4, _
                           ctrlData.Items.Count > 1)

        If ctrlData.Focus AndAlso ctrlData.Cursor = Cursors.AppStarting AndAlso blnManyItems Then
            Dim objSecondRow As ListViewItem

            Select Case ScreenName
                Case enuScreenName.Model_Option_Setting, enuScreenName.Process_Option_Setting
                    objSecondRow = ctrlData.Items(4)
                Case Else
                    objSecondRow = ctrlData.Items(1)
            End Select

            strParam1 = SelectedParam1(nScreenName, objSecondRow)
            strParam2 = SelectedParam2(nScreenName, objSecondRow)

            NavigateTo(objList, strParam1, strParam2, ctrlData)

            SelectLast(ctrlData)
        End If
    End Sub

    ' ''Right Click, Ctrl+T
    Public Sub NavigateSelected(ByVal nScreenName As enuScreenName, _
                                ByVal ctrlData As ListView, _
                                ByVal objList As clsModelBase)
        Dim strParam1 As String
        Dim strParam2 As String

        If ctrlData.SelectedItems.Count > 0 Then
            Dim objFirstRow As ListViewItem = ctrlData.SelectedItems(0)

            strParam1 = SelectedParam1(nScreenName, objFirstRow)
            strParam2 = SelectedParam2(nScreenName, objFirstRow)

            NavigateTo(objList, strParam1, strParam2, ctrlData)
        End If
    End Sub

    Public Sub NavigateTo(ByVal objList As clsModelBase, _
                          ByVal strParam1 As String, _
                          ByVal strParam2 As String, _
                          ByVal ctrlData As ListView)
        objList.LoadData(strParam1, strParam2, clsModelBase.enuFillBy.NextGroup)

        Select Case ScreenName
            Case enuScreenName.Model_Option_Setting, enuScreenName.Process_Option_Setting

                If objList.Rows.Length = 0 Then
                    NavigatePrevious(ScreenName, ctrlData, objList)
                Else
                    For i As Integer = 3 To (objList.Rows.Length + 3) - 1
                        If ctrlData.Items.Count - 1 < i Then
                            ctrlData.Items.Add(objList.Rows(i - 3))
                        Else
                            ctrlData.Items(i) = objList.Rows(i - 3)
                        End If
                    Next

                    For i As Integer = ctrlData.Items.Count - 1 To 3 + objList.Rows.Length Step -1
                        ctrlData.Items.RemoveAt(i)
                    Next
                End If

            Case Else
                ctrlData.Items.Clear()
                ctrlData.Items.AddRange(objList.Rows)
        End Select

        SelectFirst(ctrlData)
    End Sub

    Private Sub SelectFirst(ByVal ctrlData As ListView)
        Select Case ScreenName
            Case enuScreenName.Model_Option_Setting, enuScreenName.Process_Option_Setting
                SelectN(3, ctrlData)
            Case Else
                SelectN(0, ctrlData)
        End Select
    End Sub

    Private Sub SelectN(ByVal index As UInteger, _
                        ByVal ctrlData As ListView)
        If index < ctrlData.Items.Count Then
            ctrlData.Focus()
            ctrlData.Items(CInt(index)).Selected = True
            ctrlData.Items(CInt(index)).Focused = True
        End If
    End Sub

    Private Sub SelectLast(ByVal ctrlData As ListView)
        If ctrlData.Items.Count > 0 Then SelectN(ctrlData.Items.Count - 1, ctrlData)
    End Sub
#End Region

#Region "Event"

#End Region
End Module
