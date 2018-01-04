<%@ Page Title="" Language="C#" MasterPageFile="~/ui/master/Default.Master" AutoEventWireup="true" CodeBehind="customerInfo.aspx.cs" Inherits="RAFManagerWeb.customerInfo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:HiddenField ID="custIDHid" runat="server" />
    
    <h1>Gestión de Clientes</h1>    
        
    <asp:SqlDataSource ID="custDetailsDS" runat="server" 
        ConnectionString="<%$ ConnectionStrings:rafMainConnectionString %>" 
        SelectCommand="meta_customerGetDetails" SelectCommandType="StoredProcedure">
        <SelectParameters>
            <asp:ControlParameter ControlID="custIDHid" Name="custid" PropertyName="Value" 
                Type="Int32" />
            <asp:Parameter DefaultValue="2" Name="guiLang" Type="Int16" />
        </SelectParameters>
    </asp:SqlDataSource>

    <telerik:RadTabStrip ID="RadTabStrip1" runat="server" 
        MultiPageID="RadMultiPage1" SelectedIndex="1">
        <Tabs>
            <telerik:RadTab runat="server" Text="Cliente">
            </telerik:RadTab>
            <telerik:RadTab runat="server" Text="Activos" Selected="True">
            </telerik:RadTab>
        </Tabs>
    </telerik:RadTabStrip>
    <telerik:RadMultiPage ID="RadMultiPage1" runat="server" SelectedIndex="1" >
        <telerik:RadPageView ID="RadPageView1" runat="server" CssClass="tabPage">
            <asp:DetailsView ID="DetailsView1" runat="server"
        AutoGenerateRows="False" DataSourceID="custDetailsDS" CssClass="TbCompact">
        <FieldHeaderStyle CssClass="TbLabelCompact" />
        <Fields>
            <asp:BoundField DataField="companyname" HeaderText="Razón Social" 
                SortExpression="companyname" />
            <asp:BoundField DataField="firstname" HeaderText="Nombre" 
                SortExpression="firstname" />
            <asp:BoundField DataField="middlename" HeaderText="Segundo Nombre" 
                SortExpression="middlename" />
            <asp:BoundField DataField="surname1" HeaderText="Primer Apellido" 
                SortExpression="surname1" />
            <asp:BoundField DataField="surname2" HeaderText="Segundo Apellido" 
                SortExpression="surname2" />
            <asp:BoundField DataField="IDType" HeaderText="Identificación" 
                SortExpression="IDType" />
            <asp:BoundField DataField="idnumber" HeaderText="Número" 
                SortExpression="idnumber" />
            <asp:BoundField DataField="Country" HeaderText="País" 
                SortExpression="Country" />
            <asp:BoundField DataField="name" HeaderText="Registrante" SortExpression="name" />
            <asp:BoundField DataField="registrationdate" HeaderText="Matrícula" 
                SortExpression="registrationdate"  />
            <asp:BoundField DataField="State" HeaderText="Estado" SortExpression="State" />
            <asp:BoundField DataField="profilename" HeaderText="Perfil" 
                SortExpression="profilename" />
            <asp:BoundField DataField="language" HeaderText="Idioma" 
                SortExpression="language" />
        </Fields>

<HeaderStyle CssClass="formLabelCompact"></HeaderStyle>
    </asp:DetailsView>
        </telerik:RadPageView>
        <telerik:RadPageView ID="RadPageView2" runat="server"  CssClass="tabPage">
                <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="CustomersGrid">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="CustomersGrid" />
                    <telerik:AjaxUpdatedControl ControlID="AssetsGrid" LoadingPanelID="AssetsGridLP" />
                    <telerik:AjaxUpdatedControl ControlID="ChannelsGrid" LoadingPanelID="ChannelsGridLP" />
                    <telerik:AjaxUpdatedControl ControlID="TransactionsGrid" LoadingPanelID="TransactionsGridLP" />
                    <telerik:AjaxUpdatedControl ControlID="RulesGrid" LoadingPanelID="RulesGridLP" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="AssetsGrid">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="AssetsGrid" LoadingPanelID="AssetsGridLP" />
                    <telerik:AjaxUpdatedControl ControlID="ChannelsGrid" LoadingPanelID="ChannelsGridLP" />
                    <telerik:AjaxUpdatedControl ControlID="TransactionsGrid" LoadingPanelID="TransactionsGridLP" />
                    <telerik:AjaxUpdatedControl ControlID="RulesGrid" LoadingPanelID="RulesGridLP" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="ChannelsGrid">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="ChannelsGrid" LoadingPanelID="ChannelsGridLP" />
                    <telerik:AjaxUpdatedControl ControlID="TransactionsGrid" LoadingPanelID="TransactionsGridLP" />
                    <telerik:AjaxUpdatedControl ControlID="RulesGrid" LoadingPanelID="RulesGridLP" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="TransactionsGrid">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="TransactionsGrid" LoadingPanelID="TransactionsGridLP" />
                    <telerik:AjaxUpdatedControl ControlID="RulesGrid" LoadingPanelID="RulesGridLP" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="RulesGrid">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="RulesGrid" LoadingPanelID="RulesGridLP" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManager>
    <h4>Activos</h4>
    <asp:SqlDataSource ID="AssetsDS" runat="server" ConnectionString="<%$ ConnectionStrings:rafMainConnectionString %>"
        
                    SelectCommand="sp_getAssetsByClient" 
                    InsertCommandType="StoredProcedure" InsertCommand="meta_assetInsertNew" 
                    oninserting="AssetsDS_Inserting" SelectCommandType="StoredProcedure" 
                    ondeleted="AssetsDS_Deleted" oninserted="AssetsDS_Inserted">
        <SelectParameters>
            <asp:ControlParameter ControlID="custIDHid" Name="Client" PropertyName="Value"
                Type="Int32" />
        </SelectParameters>
        <InsertParameters>
            <asp:ControlParameter ControlID="custIDHid" DefaultValue="0" Name="customer" PropertyName="Value" />
            <asp:Parameter Name="type" Type="Int16" />
            <asp:Parameter Name="idnumber" Type="String" />
            <asp:Parameter Name="displaymask" Type="String" />
            <asp:Parameter Name="issueent" Type="Int32" DefaultValue="1" />
            <asp:Parameter Direction="InputOutput" Name="assetNum" Type="Int32" />
        </InsertParameters>
    </asp:SqlDataSource>
    <telerik:RadAjaxLoadingPanel ID="AssetsGridLP" runat="server" MinDisplayTime="1"></telerik:RadAjaxLoadingPanel>
    <telerik:RadGrid ID="AssetsGrid" runat="server" DataSourceID="AssetsDS" 
                    AllowAutomaticDeletes="True" AllowAutomaticInserts="True"
        OnPreRender="gridSelectFirstRow" OnDataBound="gridSelectFirstRow" CellSpacing="0" 
                    GridLines="None">
        <HeaderContextMenu CssClass="GridContextMenu GridContextMenu_Default">
        </HeaderContextMenu>
        <MasterTableView AutoGenerateColumns="False" DataKeyNames="id" 
            DataSourceID="AssetsDS" EditMode="PopUp" EditFormSettings-PopUpSettings-Modal="true" CommandItemDisplay="Top">
            <NoRecordsTemplate>
                <p>
                    No hay activos registrados</p>
            </NoRecordsTemplate>
            <CommandItemSettings AddNewRecordText="Agregar Activos" 
                RefreshText="Recargar" />
            <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column">
            </RowIndicatorColumn>
            <ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column">
            </ExpandCollapseColumn>
            <Columns>
                <telerik:GridBoundColumn datafield="id" 
                    datatype="System.Int32" filtercontrolalttext="Filter id column" headertext="id" 
                    readonly="True" sortexpression="id" uniquename="id" Visible="false" ></telerik:GridBoundColumn>                    
                <telerik:GridDropDownColumn DataField="type" DataSourceID="AssetTypesLangDS" UniqueName="asstTypes"
                    ListTextField="description" ListValueField="reference" HeaderText="Tipo Activo" ></telerik:GridDropDownColumn>
                <telerik:GridBoundColumn datafield="displaymask" 
                    filtercontrolalttext="Filter displaymask column" HeaderText="Número Activo"  
                    sortexpression="displaymask" uniquename="displaymask"></telerik:GridBoundColumn><%--
                <telerik:GridBoundColumn datafield="idnumber" 
                    filtercontrolalttext="Filter idnumber column" headertext="idnumber" 
                    sortexpression="idnumber" uniquename="idnumber"></telerik:GridBoundColumn>--%>
            </Columns>
            <EditFormSettings>
                <EditColumn ButtonType="ImageButton" CancelText="Cancelar" InsertText="Agregar">
                </EditColumn>
                <PopUpSettings CloseButtonToolTip="Cancelar" />
            </EditFormSettings>
        </MasterTableView>
        <ClientSettings EnablePostBackOnRowClick="True">
            <Selecting AllowRowSelect="True" />
        </ClientSettings>
        <FilterMenu EnableTheming="True">
            <CollapseAnimation Type="OutQuint" Duration="200"></CollapseAnimation>
        </FilterMenu>
    </telerik:RadGrid>
    <h4>Canales</h4>
    <asp:SqlDataSource ID="ChannelsDS" runat="server" ConnectionString="<%$ ConnectionStrings:rafMainConnectionString %>"
        SelectCommand="p_getActiveChannelsbyAsset"
        InsertCommand="sp_ChannelInsertNew"
        DeleteCommand="sp_DeleteChannel" 
                    SelectCommandType="StoredProcedure" DeleteCommandType="StoredProcedure" 
                    InsertCommandType="StoredProcedure">
        <SelectParameters>
            <asp:ControlParameter ControlID="AssetsGrid" DefaultValue="0" Name="asset" PropertyName="SelectedValue"
                Type="Int32" />
        </SelectParameters>
        <InsertParameters>
            <asp:ControlParameter ControlID="AssetsGrid" DefaultValue="0" Name="asset" PropertyName="SelectedValue" />
            <asp:Parameter Name="channel" />
        </InsertParameters>
        <DeleteParameters>            
            <asp:Parameter Name="id" Type="Int32"/>
        </DeleteParameters>
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="ChannelsLangDS" runat="server" ConnectionString="<%$ ConnectionStrings:rafMainConnectionString %>"
        SelectCommand="meta_getLanguage" SelectCommandType="StoredProcedure">
        <SelectParameters>
            <asp:Parameter DefaultValue="2" Name="Language" Type="Int32" />
            <asp:Parameter DefaultValue="2" Name="Type" Type="Int32" />
        </SelectParameters>
    </asp:SqlDataSource>
    <telerik:RadAjaxLoadingPanel ID="ChannelsGridLP" runat="server" MinDisplayTime="1"></telerik:RadAjaxLoadingPanel>
    <telerik:RadGrid ID="ChannelsGrid" runat="server" AutoGenerateColumns="False" 
                    DataSourceID="ChannelsDS" AllowAutomaticDeletes="True" AllowAutomaticInserts="True"
        OnPreRender="gridSelectFirstRow" OnDataBound="gridSelectFirstRow" CellSpacing="0" 
                    GridLines="None" >
        <MasterTableView EditMode="PopUp" DataSourceID="ChannelsDS" 
            CommandItemDisplay="Top" ShowFooter="False"
            ShowHeader="False" DataKeyNames="id"
            EditFormSettings-PopUpSettings-Modal="true"
            >
            <NoRecordsTemplate>
                <p>No hay canales activos</p>
            </NoRecordsTemplate>
            <CommandItemSettings AddNewRecordText="Agregar Canales" RefreshText="Recargar"/>
            <RowIndicatorColumn>
                <HeaderStyle Width="20px" />
            </RowIndicatorColumn>
            <ExpandCollapseColumn>
                <HeaderStyle Width="20px" />
            </ExpandCollapseColumn>
            <Columns>
                <telerik:GridBoundColumn datafield="id" datatype="System.Int32" 
                    filtercontrolalttext="Filter id column" headertext="id" readonly="True" 
                    sortexpression="id" uniquename="id" Visible="false"></telerik:GridBoundColumn>
                <telerik:GridBoundColumn datafield="channel" datatype="System.Int32" ReadOnly="true" 
                    filtercontrolalttext="Filter channel column" headertext="channel" 
                    sortexpression="channel" uniquename="channel" Visible="false"></telerik:GridBoundColumn>
                <telerik:GridDropDownColumn DataField="channel" DataSourceID="ChannelsLangDS" UniqueName="column"
                    ListTextField="description" ListValueField="reference" HeaderText="Canal" >
                </telerik:GridDropDownColumn>
                <telerik:GridButtonColumn buttontype="ImageButton" commandname="Delete" 
                    confirmdialogtype="RadWindow" confirmtext="Desea eliminar este registro?" 
                    confirmtitle="Eliminar" filtercontrolalttext="Filter DeleteColumn column" 
                    text="Eliminar" uniquename="DeleteColumn">
                    <ItemStyle CssClass="MyImageButton" HorizontalAlign="Center"></ItemStyle>
                </telerik:GridButtonColumn>
                </Columns>
            <EditFormSettings>
                <EditColumn ButtonType="ImageButton" CancelText="Cancelar" InsertText="Agregar">
                </EditColumn>
                <PopUpSettings CloseButtonToolTip="Cancelar" />
            </EditFormSettings>
        </MasterTableView>
        <ClientSettings EnablePostBackOnRowClick="True">
            <Selecting AllowRowSelect="True" />
        </ClientSettings>
        <HeaderContextMenu CssClass="GridContextMenu GridContextMenu_Default">
        </HeaderContextMenu>
        <FilterMenu EnableTheming="True">
            <CollapseAnimation Duration="200" Type="OutQuint" />
        </FilterMenu>
    </telerik:RadGrid>
    <br />
    <h4>
        Transacciones Válidas</h4>
    <asp:SqlDataSource ID="TransactionsDS" runat="server" ConnectionString="<%$ ConnectionStrings:rafMainConnectionString %>"
        SelectCommand="sp_getTransactionsByChannel"
        InsertCommand="sp_TransactionInsertNew"
        DeleteCommand="sp_DeleteTransaction" 
                    oninserting="TransactionsDS_Inserting" 
                    onselecting="TransactionsDS_Selecting" SelectCommandType="StoredProcedure" 
                    DeleteCommandType="StoredProcedure" InsertCommandType="StoredProcedure">
        <SelectParameters>
            <asp:ControlParameter ControlID="ChannelsGrid" DefaultValue="0" 
                Name="ValidChannel" PropertyName="SelectedValue"
                Type="Int32" />
        </SelectParameters>
        <InsertParameters>
            <asp:ControlParameter ControlID="ChannelsGrid" DefaultValue="0" 
                Name="ValidChannel" PropertyName="SelectedValue"
                Type="Int32" />
            <asp:Parameter Name="transactionid" />
        </InsertParameters>
        <DeleteParameters>
            <asp:Parameter Name="id" Type="Int32" />
        </DeleteParameters>
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="TransactionsLangDS" runat="server" ConnectionString="<%$ ConnectionStrings:rafMainConnectionString %>"
        SelectCommand="meta_getLanguage" SelectCommandType="StoredProcedure">
        <SelectParameters>
            <asp:Parameter DefaultValue="2" Name="Language" Type="Int32" />
            <asp:Parameter DefaultValue="14" Name="Type" Type="Int32" />
        </SelectParameters>
    </asp:SqlDataSource>
    <telerik:RadAjaxLoadingPanel ID="TransactionsGridLP" runat="server" MinDisplayTime="1">
    </telerik:RadAjaxLoadingPanel>
    <telerik:RadGrid ID="TransactionsGrid" runat="server" AutoGenerateColumns="False"
        DataSourceID="TransactionsDS" AllowAutomaticDeletes="True"
        AllowAutomaticInserts="True" ShowFooter="True" ShowStatusBar="True" OnPreRender="gridSelectFirstRow"
        OnDataBound="gridSelectFirstRow" CellSpacing="0" GridLines="None">
        <HeaderContextMenu CssClass="GridContextMenu GridContextMenu_WebBlue">
        </HeaderContextMenu>
        <MasterTableView DataSourceID="TransactionsDS" DataKeyNames="id" CommandItemDisplay="Top"
            ShowFooter="False" ShowHeader="False" EditMode="PopUp" 
            EditFormSettings-PopUpSettings-Modal="true">
            <NoRecordsTemplate>
                <p>No hay transacciones</p>
            </NoRecordsTemplate>
            <CommandItemSettings AddNewRecordText="Agregar Transacciones" />
            <RowIndicatorColumn>
                <HeaderStyle Width="20px" />
            </RowIndicatorColumn>
            <ExpandCollapseColumn>
                <HeaderStyle Width="20px" />
            </ExpandCollapseColumn>
            <Columns>                
                <telerik:GridBoundColumn datafield="id" datatype="System.Int32" 
                    filtercontrolalttext="Filter id column" headertext="id" readonly="True" 
                    sortexpression="id" uniquename="id" Visible="False"></telerik:GridBoundColumn>
                <telerik:GridDropDownColumn DataField="transactionid" DataSourceID="TransactionsLangDS"
                    ListTextField="description" ListValueField="reference" UniqueName="column" HeaderText="Transacción">
                </telerik:GridDropDownColumn>
                <telerik:GridButtonColumn ConfirmText="Desea eliminar este registro?" ConfirmDialogType="RadWindow"
                    ConfirmTitle="Eliminar" ButtonType="ImageButton" CommandName="Delete" Text="Eliminar"
                    UniqueName="DeleteColumn">
                    <ItemStyle HorizontalAlign="Center" CssClass="MyImageButton" />
                </telerik:GridButtonColumn>                            
            </Columns>
            <EditFormSettings>
                <EditColumn ButtonType="ImageButton" CancelText="Cancelar" InsertText="Agregar">
                </EditColumn>
                <PopUpSettings CloseButtonToolTip="Cancelar" />
            </EditFormSettings>
        </MasterTableView>
        <ClientSettings EnablePostBackOnRowClick="True">
            <Selecting AllowRowSelect="True" />
        </ClientSettings>
        <FilterMenu EnableTheming="True">
            <CollapseAnimation Duration="200" Type="OutQuint" />
        </FilterMenu>
    </telerik:RadGrid>
    <br />
    <h4>
        Condiciones</h4>
    <asp:SqlDataSource ID="rulesDS" runat="server" ConnectionString="<%$ ConnectionStrings:rafMainConnectionString %>"
        SelectCommand="sp_getRulesAndConditions" InsertCommand="metaInsertRuleandCondition"
        InsertCommandType="StoredProcedure" oninserting="rulesDS_Inserting" 
                    onselecting="rulesDS_Selecting"  
                    SelectCommandType="StoredProcedure" UpdateCommand="sp_UpdateRuleandCondition" 
                    UpdateCommandType="StoredProcedure" 
                    DeleteCommand="sp_DeleteRuleAndCondition" DeleteCommandType="StoredProcedure">
        <SelectParameters>
            <asp:ControlParameter ControlID="TransactionsGrid" Name="ValidTransaction" 
                PropertyName="SelectedValue" DefaultValue="0" Type="Int32" />
        </SelectParameters>
        <DeleteParameters>
            <asp:Parameter Name="id" Type="Int32"  />
        </DeleteParameters>
        <UpdateParameters>
            <asp:Parameter Name="assetrule" Type="Int32" />
            <asp:Parameter Name="id" Type="Int32" />
            <asp:Parameter Name="actiontype" Type="Byte" />
            <asp:Parameter Name="field" Type="Byte" />
            <asp:Parameter Name="operator" Type="Byte" />
            <asp:Parameter Name="value" Type="String" />
            <asp:Parameter Name="fieldcurrency" Type="Int16" />
            <asp:Parameter Name="valuerangestart" Type="String" />
            <asp:Parameter Name="valuerangeend" Type="String" />
        </UpdateParameters>
        <InsertParameters>
            <asp:ControlParameter ControlID="AssetsGrid" Name="asset" 
                PropertyName="SelectedValue" />
            <asp:ControlParameter ControlID="ChannelsGrid" Name="channel" 
                PropertyName="SelectedValue" />
            <asp:Parameter Name="actiontype" />
            <asp:ControlParameter ControlID="TransactionsGrid" Name="transactionid" 
                PropertyName="SelectedValue" />
            <asp:Parameter Name="field" />
            <asp:Parameter Name="operator" />
            <asp:Parameter Name="value" />
            <asp:Parameter Name="fieldcurrency" />
            <asp:Parameter Name="valuerangestart" />
            <asp:Parameter Name="valuerangeend" />
        </InsertParameters>
    </asp:SqlDataSource>
    <telerik:RadAjaxLoadingPanel ID="RulesGridLP" runat="server" MinDisplayTime="1">
    </telerik:RadAjaxLoadingPanel>
    <telerik:RadGrid ID="RulesGrid" runat="server" DataSourceID="rulesDS"
        AutoGenerateColumns="False" AllowAutomaticInserts="True"
        AutoGenerateEditColumn="True"  OnPreRender="gridSelectFirstRow"
        OnDataBound="gridSelectFirstRow" CellSpacing="0" GridLines="None" 
                    AllowAutomaticUpdates="True" AllowAutomaticDeletes="True" >
        <MasterTableView DataSourceID="rulesDS" DataKeyNames="id" 
            CommandItemDisplay="Top" EditMode="PopUp" 
            EditFormSettings-PopUpSettings-Modal="true" >
            <NoRecordsTemplate>
                <p>
                    No hay Condiciones</p>
            </NoRecordsTemplate>
            <CommandItemSettings AddNewRecordText="Agregar Condición" />
            <RowIndicatorColumn>
                <HeaderStyle Width="20px"></HeaderStyle>
            </RowIndicatorColumn>
            <ExpandCollapseColumn>
                <HeaderStyle Width="20px"></HeaderStyle>
            </ExpandCollapseColumn>
            <Columns>
                <telerik:GridBoundColumn datafield="assetrule" datatype="System.Int64" readonly="true"
                    filtercontrolalttext="Filter assetrule column" headertext="assetrule" 
                    sortexpression="assetrule" uniquename="assetrule" Visible="false"></telerik:GridBoundColumn>
                <telerik:GridBoundColumn datafield="id" datatype="System.Int64" 
                    filtercontrolalttext="Filter id column" headertext="id" readonly="True" 
                    sortexpression="id" uniquename="id" Visible="false"></telerik:GridBoundColumn>
                <telerik:GridDropDownColumn DataField="actiontype" DataSourceID="ruleActionsLangDS"
                    ListTextField="description" ListValueField="reference" UniqueName="actiontype"
                    HeaderText="Acción">
                </telerik:GridDropDownColumn>
                <telerik:GridDropDownColumn DataField="field" DataSourceID="ruleFieldsLangDS" ListTextField="description"
                    ListValueField="reference" UniqueName="field" HeaderText="Cuando">
                </telerik:GridDropDownColumn>
                <telerik:GridDropDownColumn DataField="operator" DataSourceID="ruleOperatorLangDS"
                    ListTextField="description" ListValueField="reference" UniqueName="operator" HeaderText="Sea">
                </telerik:GridDropDownColumn>
                <telerik:GridBoundColumn DataField="value" EmptyDataText="&amp;nbsp;" SortExpression="value"
                    UniqueName="value" HeaderText="Valor">
                </telerik:GridBoundColumn>
                <telerik:GridDropDownColumn DataField="fieldcurrency" DataSourceID="ruleCurrenciesLangDS"
                    ListTextField="description" ListValueField="reference" UniqueName="fieldcurrency" HeaderText="Moneda">
                </telerik:GridDropDownColumn>
                <telerik:GridBoundColumn DataField="valuerangestart" EmptyDataText="&amp;nbsp;" SortExpression="valuerangestart"
                    UniqueName="valuerangestart" HeaderText="Inicio">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="valuerangeend" EmptyDataText="&amp;nbsp;" SortExpression="valuerangeend"
                    UniqueName="valuerangeend" HeaderText="Fin">
                </telerik:GridBoundColumn>
                <telerik:GridButtonColumn ConfirmText="Desea eliminar este registro?" ConfirmDialogType="RadWindow"
                    ConfirmTitle="Eliminar" ButtonType="ImageButton" CommandName="Delete" Text="Eliminar"
                    UniqueName="DeleteColumn" >
                    <ItemStyle HorizontalAlign="Center" CssClass="MyImageButton" />
                </telerik:GridButtonColumn>
                
                
            </Columns>
            <EditFormSettings>
                <EditColumn ButtonType="ImageButton" CancelText="Cancelar" InsertText="Agregar">
                </EditColumn>
                <PopUpSettings CloseButtonToolTip="Cancelar" />
            </EditFormSettings>
        </MasterTableView>
        <ClientSettings EnablePostBackOnRowClick="True">
            <Selecting AllowRowSelect="false" />
        </ClientSettings>
        <HeaderContextMenu CssClass="GridContextMenu GridContextMenu_Default">
        </HeaderContextMenu>
        <FilterMenu EnableTheming="True">
            <CollapseAnimation Type="OutQuint" Duration="200"></CollapseAnimation>
        </FilterMenu>
    </telerik:RadGrid>
    <asp:SqlDataSource ID="assetTypesLangDS" runat="server" ConnectionString="<%$ ConnectionStrings:rafMainConnectionString %>"
        SelectCommand="meta_getLanguage" SelectCommandType="StoredProcedure">
        <SelectParameters>
            <asp:Parameter DefaultValue="2" Name="Language" Type="Int32" />
            <asp:Parameter DefaultValue="1" Name="Type" Type="Int32" />
        </SelectParameters>
    </asp:SqlDataSource>

    <asp:SqlDataSource ID="ruleActionsLangDS" runat="server" ConnectionString="<%$ ConnectionStrings:rafMainConnectionString %>"
        SelectCommand="meta_getLanguage" SelectCommandType="StoredProcedure">
        <SelectParameters>
            <asp:Parameter DefaultValue="2" Name="Language" Type="Int32" />
            <asp:Parameter DefaultValue="8" Name="Type" Type="Int32" />
        </SelectParameters>
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="ruleFieldsLangDS" runat="server" ConnectionString="<%$ ConnectionStrings:rafMainConnectionString %>"
        SelectCommand="meta_getLanguage" SelectCommandType="StoredProcedure">
        <SelectParameters>
            <asp:Parameter DefaultValue="2" Name="Language" Type="Int32" />
            <asp:Parameter DefaultValue="12" Name="Type" Type="Int32" />
        </SelectParameters>
                </asp:SqlDataSource>
    <asp:SqlDataSource ID="ruleOperatorLangDS" runat="server" ConnectionString="<%$ ConnectionStrings:rafMainConnectionString %>"
        SelectCommand="meta_getLanguage" SelectCommandType="StoredProcedure">
        <SelectParameters>
            <asp:Parameter DefaultValue="2" Name="Language" Type="Int32" />
            <asp:Parameter DefaultValue="11" Name="Type" Type="Int32" />
        </SelectParameters>
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="ruleCurrenciesLangDS" runat="server" ConnectionString="<%$ ConnectionStrings:rafMainConnectionString %>"
        SelectCommand="meta_getLanguage" SelectCommandType="StoredProcedure">
        <SelectParameters>
            <asp:Parameter DefaultValue="2" Name="Language" Type="Int32" />
            <asp:Parameter DefaultValue="5" Name="Type" Type="Int32" />
        </SelectParameters>
                </asp:SqlDataSource>
    <asp:SqlDataSource ID="transTypeLangDS" runat="server" ConnectionString="<%$ ConnectionStrings:rafMainConnectionString %>"
        SelectCommand="meta_getLanguage" SelectCommandType="StoredProcedure">
        <SelectParameters>
            <asp:Parameter DefaultValue="2" Name="Language" Type="Int32" />
            <asp:Parameter DefaultValue="14" Name="Type" Type="Int32" />
        </SelectParameters>
    </asp:SqlDataSource>

        </telerik:RadPageView>
    </telerik:RadMultiPage>

    </asp:Content>
