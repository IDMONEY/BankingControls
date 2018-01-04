<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/ui/master/Default.Master" CodeBehind="assetRules.aspx.cs" Inherits="gridTest._AssetRules" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">


.RadGrid_Default
{
	border:1px solid #232323;
}

.RadGrid_Default
{
	font:11px/1.4 arial,sans-serif;
}

.RadGrid_Default
{
	background:#d4d0c8;
	color:#333;
}

.MasterTable_Default
{
	background:#fff;
	border-collapse:separate !important;
}

.MasterTable_Default
{
	font:11px/1.4 arial,sans-serif;
}

.GridHeader_Default
{
	color:#fff;
	text-decoration:none;
}

.GridHeader_Default
{
	border-bottom:1px solid #010101;
	background:url('mvwres://Telerik.Web.UI, Version=2008.2.1001.35, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Grid.headers.gif') repeat-x #434343;
	padding:10px 6px 10px 11px;
	text-align:left;
	font-size:1.3em;
	font-weight:normal;
}

    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="RadGrid1">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="RadGrid1" />
                    <telerik:AjaxUpdatedControl ControlID="RadGrid2" />
                    <telerik:AjaxUpdatedControl ControlID="RadGrid3" />
                    <telerik:AjaxUpdatedControl ControlID="RadGrid4" />
                    <telerik:AjaxUpdatedControl ControlID="RadGrid5" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="RadGrid2">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="RadGrid2" />
                    <telerik:AjaxUpdatedControl ControlID="RadGrid3" />
                    <telerik:AjaxUpdatedControl ControlID="RadGrid4" />
                    <telerik:AjaxUpdatedControl ControlID="RadGrid5" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="RadGrid3">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="RadGrid3" />
                    <telerik:AjaxUpdatedControl ControlID="RadGrid4" />
                    <telerik:AjaxUpdatedControl ControlID="RadGrid5" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="RadGrid4">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="RadGrid4" />
                    <telerik:AjaxUpdatedControl ControlID="RadGrid5" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="RadGrid5">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="RadGrid5" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManager>
    <asp:SqlDataSource ID="CustomersDS" runat="server" ConnectionString="<%$ ConnectionStrings:rafMainConnectionString %>"
        SelectCommand="SELECT customers.id, customerinfo.firstname, customerinfo.middlename, customerinfo.surname1, customerinfo.surname2, customercredentials.idnumber FROM customercredentials INNER JOIN customers ON customercredentials.customer = customers.id AND customercredentials.customer = customers.id INNER JOIN customerinfo ON customers.id = customerinfo.id">
    </asp:SqlDataSource>
    <telerik:RadFormDecorator ID="RadFormDecorator1" runat="server" Skin="Web20" />
    <div>
        <telerik:RadGrid  Visible="false" ID="RadGrid1" runat="server" AllowPaging="True" DataSourceID="CustomersDS"
            GridLines="None" Skin="Web20" OnDataBound="RadGrid1_DataBound">
            <MasterTableView AutoGenerateColumns="False" DataKeyNames="id" DataSourceID="CustomersDS">
                <RowIndicatorColumn>
                    <HeaderStyle Width="20px"></HeaderStyle>
                </RowIndicatorColumn>
                <ExpandCollapseColumn>
                    <HeaderStyle Width="20px"></HeaderStyle>
                </ExpandCollapseColumn>
                <Columns>
                    <telerik:GridBoundColumn DataField="id" DataType="System.Int32" EmptyDataText="&amp;nbsp;"
                        HeaderText="id" ReadOnly="True" SortExpression="id" UniqueName="id">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="firstname" EmptyDataText="&amp;nbsp;" HeaderText="firstname"
                        SortExpression="firstname" UniqueName="firstname">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="middlename" EmptyDataText="&amp;nbsp;" HeaderText="middlename"
                        SortExpression="middlename" UniqueName="middlename">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="surname1" EmptyDataText="&amp;nbsp;" HeaderText="surname1"
                        SortExpression="surname1" UniqueName="surname1">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="surname2" EmptyDataText="&amp;nbsp;" HeaderText="surname2"
                        SortExpression="surname2" UniqueName="surname2">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="idnumber" EmptyDataText="&amp;nbsp;" HeaderText="idnumber"
                        SortExpression="idnumber" UniqueName="idnumber">
                    </telerik:GridBoundColumn>
                </Columns>
            </MasterTableView>
            <ClientSettings EnablePostBackOnRowClick="True">
                <Selecting AllowRowSelect="True" />
            </ClientSettings>
            <FilterMenu EnableTheming="True">
                <CollapseAnimation Type="OutQuint" Duration="200"></CollapseAnimation>
            </FilterMenu>
        </telerik:RadGrid>
    </div>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:rafMainConnectionString %>"
        SelectCommand="SELECT assets.id, assets.displaymask AS [Número Activo], assettypes_lang.description AS [Tipo Activo] FROM assets INNER JOIN assettypes ON assets.type = assettypes.id INNER JOIN assettypes_lang ON assettypes.id = assettypes_lang.type WHERE (assets.customer = 3)"
        OnDataBinding="SqlDataSource1_DataBinding">
      <%--  <SelectParameters>
            <asp:ControlParameter ControlID="RadGrid1" DefaultValue="0" Name="Cust" PropertyName="SelectedValue"
                Type="String" />
        </SelectParameters>--%>
    </asp:SqlDataSource>
    <telerik:RadGrid ID="RadGrid2" runat="server" DataSourceID="SqlDataSource1" Skin="WebBlue"
        OnDataBound="RadGrid2_DataBound">
        <MasterTableView AutoGenerateColumns="False" DataKeyNames="id" DataSourceID="SqlDataSource1">
            <RowIndicatorColumn>
                <HeaderStyle Width="20px"></HeaderStyle>
            </RowIndicatorColumn>
            <ExpandCollapseColumn>
                <HeaderStyle Width="20px"></HeaderStyle>
            </ExpandCollapseColumn>
            <Columns>
                <telerik:GridBoundColumn DataField="id" DataType="System.Int32" EmptyDataText="&amp;nbsp;"
                    HeaderText="id" ReadOnly="True" SortExpression="id" UniqueName="id">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="Número Activo" EmptyDataText="&amp;nbsp;" HeaderText="Número Activo"
                    SortExpression="Número Activo" UniqueName="Número Activo">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="Tipo Activo" EmptyDataText="&amp;nbsp;" HeaderText="Tipo Activo"
                    SortExpression="Tipo Activo" UniqueName="Tipo Activo">
                </telerik:GridBoundColumn>
            </Columns>
        </MasterTableView>
        <ClientSettings EnablePostBackOnRowClick="True">
            <Selecting AllowRowSelect="True" />
        </ClientSettings>
        <FilterMenu EnableTheming="True">
            <CollapseAnimation Type="OutQuint" Duration="200"></CollapseAnimation>
        </FilterMenu>
    </telerik:RadGrid>
    <h4>
        Canales</h4>
    <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:rafMainConnectionString %>"
        SelectCommand="SELECT assetvalidchannels.channel, assetvalidchannels.id AS idKey FROM assetvalidchannels INNER JOIN channels ON assetvalidchannels.channel = channels.id INNER JOIN channels_lang ON channels.id = channels_lang.channel WHERE (assetvalidchannels.asset = @asset)"
        
        InsertCommand="INSERT INTO assetvalidchannels(asset, channel) VALUES (@asset, @channel)"
        DeleteCommand="DELETE FROM assetvalidchannels where id = @idKey "
        >
        <SelectParameters>
            <asp:ControlParameter ControlID="RadGrid2" DefaultValue="0" Name="asset" PropertyName="SelectedValue"
                Type="Int32" />
        </SelectParameters>
        <InsertParameters>
            <asp:ControlParameter ControlID="RadGrid2" DefaultValue="0" Name="asset" PropertyName="SelectedValue" />
            <asp:Parameter Name="channel" />
        </InsertParameters>
       <DeleteParameters>
            <asp:Parameter Name="idKey" />
        </DeleteParameters>        
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:rafMainConnectionString %>"
        SelectCommand="SELECT c.id, cl.description FROM channels AS c INNER JOIN channels_lang AS cl ON c.id = cl.channel">
    </asp:SqlDataSource>
    <telerik:RadGrid ID="RadGrid3" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource2"
        GridLines="None" Skin="WebBlue" AllowAutomaticDeletes="True" AllowAutomaticInserts="True"
        OnDataBound="RadGrid3_DataBound">
        <MasterTableView DataSourceID="SqlDataSource2" CommandItemDisplay="Top"
            ShowFooter="False" ShowHeader="False" DataKeyNames="idKey">
            <NoRecordsTemplate>
                <p>No hay canales activos</p>
            </NoRecordsTemplate>
            <CommandItemSettings AddNewRecordText="Agregar Canales" />
            <RowIndicatorColumn>
                <HeaderStyle Width="20px" />
            </RowIndicatorColumn>
            <ExpandCollapseColumn>
                <HeaderStyle Width="20px" />
            </ExpandCollapseColumn>
            <Columns>
                <telerik:GridBoundColumn DataField="channel" DataType="System.Int16" 
                    EmptyDataText="&amp;nbsp;" HeaderText="channel" SortExpression="channel" 
                    UniqueName="channel" ReadOnly="true" Visible="false">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="idKey" DataType="System.Int32" 
                    EmptyDataText="&amp;nbsp;" HeaderText="idKey" ReadOnly="True"  Visible="false"
                    SortExpression="idKey" UniqueName="idKey">
                </telerik:GridBoundColumn>
                <telerik:GridDropDownColumn DataField="channel" DataSourceID="SqlDataSource3" 
                    UniqueName="column" ListTextField="description" ListValueField="id">
                </telerik:GridDropDownColumn>
                                    <telerik:GridButtonColumn ConfirmText="Desea eliminar este registro?" ConfirmDialogType="RadWindow"
                        ConfirmTitle="Eliminar" ButtonType="ImageButton" CommandName="Delete" Text="Eliminar"
                        UniqueName="DeleteColumn">
                        <ItemStyle HorizontalAlign="Center" CssClass="MyImageButton" />
                    </telerik:GridButtonColumn>
            </Columns>
            <EditFormSettings>
                <EditColumn  ButtonType="ImageButton" CancelText="Cancelar" InsertText="Agregar">
                </EditColumn>
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
        Transacciones Válidas</h4>
    <asp:SqlDataSource ID="SqlDataSource4" runat="server" ConnectionString="<%$ ConnectionStrings:rafMainConnectionString %>"
        
        SelectCommand="SELECT at.transactionid, at.id AS idkey FROM assetvalidtransactions AS at INNER JOIN transactiontypes AS t ON at.transactionid = t.id INNER JOIN transactiontypes_lang AS tl ON t.id = tl.transactionid WHERE (at.asset = @asset) AND (at.channel = @channel)"
        InsertCommand="INSERT INTO assetvalidtransactions(asset, channel, transactionid) VALUES (@asset, @channel, @transactionid)"
        DeleteCommand="DELETE FROM assetvalidtransactions where id = @idKey "
        >
        <SelectParameters>
            <asp:ControlParameter ControlID="RadGrid2" DefaultValue="0" Name="asset" PropertyName="SelectedValue"
                Type="Int32" />
            <asp:ControlParameter ControlID="RadGrid3" DefaultValue="0" Name="channel" PropertyName="SelectedValue"
                Type="Int32" />
        </SelectParameters>
        <InsertParameters>
            <asp:ControlParameter ControlID="RadGrid2" Name="asset" PropertyName="SelectedValue" />
            <asp:ControlParameter ControlID="RadGrid3" Name="channel" PropertyName="SelectedValue" />
            <asp:Parameter Name="transactionid" />
        </InsertParameters>
               <DeleteParameters>
            <asp:Parameter Name="idKey" />
        </DeleteParameters>  
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="SqlDataSource5" runat="server" ConnectionString="<%$ ConnectionStrings:rafMainConnectionString %>"
        SelectCommand="SELECT transactiontypes.id transID, transactiontypes_lang.description transName FROM transactiontypes INNER JOIN transactiontypes_lang ON transactiontypes.id = transactiontypes_lang.transactionid">
    </asp:SqlDataSource>
    <telerik:RadGrid ID="RadGrid4" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource4"
        GridLines="None" Skin="WebBlue" AllowAutomaticDeletes="True" AllowAutomaticInserts="True"
        ShowFooter="True" ShowStatusBar="True">
        <MasterTableView DataSourceID="SqlDataSource4" DataKeyNames="idkey" CommandItemDisplay="Top"
            ShowFooter="False" ShowHeader="False">
            <NoRecordsTemplate>
                <p>
                    No hay transacciones</p>
            </NoRecordsTemplate>
            <CommandItemSettings AddNewRecordText="Agregar Transacciones" />
            <RowIndicatorColumn>
                <HeaderStyle Width="20px" />
            </RowIndicatorColumn>
            <ExpandCollapseColumn>
                <HeaderStyle Width="20px" />
            </ExpandCollapseColumn>
            <Columns>
                <telerik:GridBoundColumn DataField="transactionid" DataType="System.Int16" 
                    EmptyDataText="&amp;nbsp;" HeaderText="transactionid" 
                    SortExpression="transactionid" UniqueName="transactionid" Visible="False" ReadOnly="true">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="idkey" DataType="System.Int32" 
                    EmptyDataText="&amp;nbsp;" HeaderText="idkey" ReadOnly="True" 
                    SortExpression="idkey" UniqueName="idkey" Visible="False">
                </telerik:GridBoundColumn>
                <telerik:GridDropDownColumn DataField="transactionid" 
                    DataSourceID="SqlDataSource5" ListTextField="transName" 
                    ListValueField="transID" UniqueName="column">
                </telerik:GridDropDownColumn>           <telerik:GridButtonColumn ConfirmText="Desea eliminar este registro?" ConfirmDialogType="RadWindow"
                        ConfirmTitle="Eliminar" ButtonType="ImageButton" CommandName="Delete" Text="Eliminar"
                        UniqueName="DeleteColumn">
                        <ItemStyle HorizontalAlign="Center" CssClass="MyImageButton" />
                    </telerik:GridButtonColumn>
            </Columns>
                       <EditFormSettings>
                <EditColumn  ButtonType="ImageButton" CancelText="Cancelar" InsertText="Agregar">
                </EditColumn>
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
    <asp:SqlDataSource ID="rulesDS" runat="server" 
        ConnectionString="<%$ ConnectionStrings:rafMainConnectionString %>" 
        SelectCommand="SELECT     r.id AS ruleIDkey, rc.id as condIDkey, rc.field, rc.operator, rc.fieldcurrency, rc.value, rc.valuerangestart, rc.valuerangeend, r.actiontype
FROM         ruleconditions AS rc INNER JOIN
                      rules AS r ON rc.assetrule = r.id
WHERE     (r.asset = @asset) AND (r.channel = @channel)"
        

          InsertCommand="metaInsertRuleandCondition"
        InsertCommandType="StoredProcedure">
        <SelectParameters>
            <asp:ControlParameter ControlID="RadGrid2" Name="asset" 
                PropertyName="SelectedValue" Type="Int32" />
            <asp:ControlParameter ControlID="RadGrid3" Name="channel" 
                PropertyName="SelectedValue" Type="Int16" />
        </SelectParameters>
        <InsertParameters>
        <asp:ControlParameter ControlID="RadGrid2" Name="asset" PropertyName="SelectedValue" />
<asp:ControlParameter ControlID="RadGrid3" Name="channel" PropertyName="SelectedValue" />
<asp:ControlParameter ControlID="RadGrid4" Name="transactionid"  PropertyName="SelectedValue" />
<asp:Parameter Name="actiontype" />
<asp:Parameter Name="field" />
<asp:Parameter Name="operator" />
<asp:Parameter Name="value" />
<asp:Parameter Name="fieldcurrency" />
<asp:Parameter Name="valuerangestart" />
<asp:Parameter Name="valuerangeend" />
        </InsertParameters>
    </asp:SqlDataSource>
    <telerik:RadGrid ID="RadGrid5" runat="server" DataSourceID="rulesDS" 
        GridLines="None" AutoGenerateColumns="False" AllowAutomaticDeletes="True" AllowAutomaticInserts="True" 
        AutoGenerateEditColumn="True" Skin="WebBlue">
        <MasterTableView DataSourceID="rulesDS" 
            DataKeyNames="ruleIDkey,condIDkey" CommandItemDisplay="Top">
                        <NoRecordsTemplate>
                <p>No hay Condiciones</p>
            </NoRecordsTemplate>
            <CommandItemSettings AddNewRecordText="Agregar Condición" />
            <RowIndicatorColumn>
                <HeaderStyle Width="20px"></HeaderStyle>
            </RowIndicatorColumn>
            <ExpandCollapseColumn>
                <HeaderStyle Width="20px"></HeaderStyle>
            </ExpandCollapseColumn>
            <Columns>
            
                <telerik:GridBoundColumn DataField="ruleIDkey" DataType="System.Int64" EmptyDataText="&amp;nbsp;"
                    HeaderText="ruleIDkey" SortExpression="ruleIDkey" UniqueName="ruleIDkey" 
                    ReadOnly="True" Visible=false>
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="condIDkey" DataType="System.Int64" 
                    EmptyDataText="&amp;nbsp;" HeaderText="condIDkey" ReadOnly="True" 
                    SortExpression="condIDkey" UniqueName="condIDkey" Visible=false>
                </telerik:GridBoundColumn>
                <telerik:GridDropDownColumn DataField="actiontype" 
                    DataSourceID="ruleactionsDS" ListTextField="description" 
                    ListValueField="idaction" UniqueName="actiontype" HeaderText="Acción">
                </telerik:GridDropDownColumn>   
                             
                <telerik:GridDropDownColumn DataField="field" 
                    DataSourceID="rulefieldsDS" ListTextField="description" 
                    ListValueField="id" UniqueName="field" HeaderText="Cuando">
                </telerik:GridDropDownColumn>  
                <telerik:GridDropDownColumn DataField="operator" 
                    DataSourceID="ruleOperatorDS" ListTextField="description" 
                    ListValueField="id" UniqueName="operator"  HeaderText="Sea">
                </telerik:GridDropDownColumn>  

                <telerik:GridBoundColumn DataField="value" EmptyDataText="&amp;nbsp;" 
                     SortExpression="value" UniqueName="value"  HeaderText="Valor">
                </telerik:GridBoundColumn>
           <telerik:GridDropDownColumn DataField="fieldcurrency" 
                    DataSourceID="ruleCurrenciesDS" ListTextField="description" 
                    ListValueField="id" UniqueName="fieldcurrency"  HeaderText="Moneda">
                </telerik:GridDropDownColumn>                 
                <telerik:GridBoundColumn DataField="valuerangestart" EmptyDataText="&amp;nbsp;" 
                    SortExpression="valuerangestart" 
                    UniqueName="valuerangestart"  HeaderText="Inicio">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="valuerangeend" EmptyDataText="&amp;nbsp;" 
                     SortExpression="valuerangeend" 
                    UniqueName="valuerangeend"  HeaderText="Fin">
                </telerik:GridBoundColumn>
 
           <telerik:GridButtonColumn ConfirmText="Desea eliminar este registro?" ConfirmDialogType="RadWindow"
                        ConfirmTitle="Eliminar" ButtonType="ImageButton" CommandName="Delete" Text="Eliminar"
                        UniqueName="DeleteColumn">
                        <ItemStyle HorizontalAlign="Center" CssClass="MyImageButton" />
                    </telerik:GridButtonColumn>
            </Columns><EditFormSettings>
                <EditColumn  ButtonType="ImageButton" CancelText="Cancelar" InsertText="Agregar">
                </EditColumn>
            </EditFormSettings>
        </MasterTableView>
                <ClientSettings EnablePostBackOnRowClick="True">
            <Selecting AllowRowSelect="false" />
        </ClientSettings>
        <FilterMenu EnableTheming="True">
            <CollapseAnimation Type="OutQuint" Duration="200"></CollapseAnimation>
        </FilterMenu>
    </telerik:RadGrid>
    
    
    
    
    <asp:SqlDataSource ID="ruleactionsDS" runat="server" 
        ConnectionString="<%$ ConnectionStrings:rafMainConnectionString %>" 
        SelectCommand="SELECT     ruleactions.idaction,ruleactions_lang.description
FROM         ruleactions INNER JOIN
                      ruleactions_lang ON ruleactions.idaction = ruleactions_lang.action"></asp:SqlDataSource>
    
    <asp:SqlDataSource ID="rulefieldsDS" runat="server" ConnectionString="<%$ ConnectionStrings:rafMainConnectionString %>" 
        SelectCommand="SELECT     rulefields.id, rulefields_lang.description
FROM         rulefields INNER JOIN
                      rulefields_lang ON rulefields.id = rulefields_lang.field"></asp:SqlDataSource>
    <asp:SqlDataSource ID="ruleOperatorDS" runat="server" ConnectionString="<%$ ConnectionStrings:rafMainConnectionString %>" 
        SelectCommand="SELECT     rulefieldoperators.id, rulefieldoperators_lang.description
FROM         rulefieldoperators INNER JOIN
                      rulefieldoperators_lang ON rulefieldoperators.id = rulefieldoperators_lang.operator"></asp:SqlDataSource>
                          <asp:SqlDataSource ID="ruleCurrenciesDS" runat="server" ConnectionString="<%$ ConnectionStrings:rafMainConnectionString %>" 
        SelectCommand="SELECT     currencies.id, 
currencies_lang.Description + ' ('+ currencies.codealpha+')' as description
FROM         currencies INNER JOIN
                      currencies_lang ON currencies.id = currencies_lang.currency"></asp:SqlDataSource>
             <asp:SqlDataSource ID="SqlDataSource6" runat="server" ConnectionString="<%$ ConnectionStrings:rafMainConnectionString %>" 
        SelectCommand="SELECT transactiontypes.id , transactiontypes_lang.description FROM transactiontypes INNER JOIN transactiontypes_lang ON transactiontypes.id = transactiontypes_lang.transactionid"></asp:SqlDataSource>
  
</asp:Content>