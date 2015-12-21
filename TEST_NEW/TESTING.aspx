<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="TESTING.aspx.vb" Inherits="TEST_NEW.TESTING" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <asp:Button ID="Add_clm" runat ="server" Text ="Add Column" />
         <asp:Button ID="Mongo" runat ="server" Text ="Mongo_Add" />
        <asp:Button ID="mongoupd" runat ="server" Text ="Mongo_Upd" />
        <asp:Button ID="BILLADD" runat ="server" Text ="BILL UPD" />
        <asp:Button ID="BULK_COPY" runat ="server" Text ="BULK COPY" />
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="RECID1" CssClass="table table-hover table-striped" Width="940px" HorizontalAlign="Center" RowStyle-Wrap="false" AllowSorting="True" HeaderStyle-BackColor="YellowGreen" HeaderStyle-HorizontalAlign="Center" HeaderStyle-Wrap="false" Font-Size="Smaller">
                <Columns>
                    <asp:BoundField DataField="RECID1" HeaderText="RECID1" Visible="False" HtmlEncode="true" />
                    <asp:BoundField DataField="CUST" HeaderText="CUSTOMER" HtmlEncode="true" SortExpression="CUST" />
                    <asp:BoundField DataField="SID" HeaderText="SITE ID" HtmlEncode="true" SortExpression="SID" />
                    <asp:BoundField DataField="SNAME" HeaderText="SITE NAME" HtmlEncode="true" SortExpression="SNAME" />
                    <asp:BoundField DataField="ENGINE_No" HeaderText="ENGINE_NO" HtmlEncode="true" SortExpression="ENGINE_No" />
                    <asp:BoundField DataField="KVA" HeaderText="KVA" HtmlEncode="true" />
                    <asp:BoundField DataField="DOS" HeaderText="DATE OF SERVICE" Visible="False" HtmlEncode="true" />
                    <asp:BoundField DataField="STYPE" HeaderText="SERVICE TYPE" HtmlEncode="true" SortExpression="STYPE" />
                    <asp:BoundField DataField="HMR" HeaderText="HMR" />
                    <asp:BoundField DataField="Report" HeaderText="Report No" Visible="False" HtmlEncode="true" />
                    <asp:BoundField DataField="Technician" HeaderText="Technician" HtmlEncode="true" SortExpression="Technician" Visible="false" />
                    <asp:BoundField DataField="METERIAL" HeaderText="METERIAL USED" Visible="False" HtmlEncode="true" />
                    <asp:BoundField DataField="recid" HeaderText="RECORD ID" Visible="False" HtmlEncode="true" />
                    <asp:BoundField DataField="CDATI" HeaderText="CLOSURE DATE" HtmlEncode="true" DataFormatString="{0:dd-MMM-yyyy hh:mm:ss tt}" />
                    <asp:BoundField DataField="DIST" HeaderText="DISTRICT" Visible="False" HtmlEncode="true" />
                    <asp:BoundField DataField="STATE" HeaderText="STATE" Visible="False" HtmlEncode="true" />
                    <asp:BoundField DataField="CCATE" HeaderText="COMPLAINT CATEGORY" Visible="False" HtmlEncode="true" />
                    <asp:BoundField DataField="MODEL" HeaderText="MODEL" Visible="False" HtmlEncode="true" />
                    <asp:BoundField DataField="DOI" HeaderText="DATE OF COMM." Visible="False" HtmlEncode="true" />
                    <asp:BoundField DataField="DGNO" HeaderText="DG SET NO" Visible="False" HtmlEncode="true" />
                    <asp:BoundField DataField="AMAKE" HeaderText="ALT. MAKE" Visible="False" HtmlEncode="true" />
                    <asp:BoundField DataField="ALSN" HeaderText="ALT. SN" Visible="False" HtmlEncode="true" />
                    <asp:BoundField DataField="BSN" HeaderText="BATTERY SN" Visible="False" HtmlEncode="true" />
                    <asp:BoundField DataField="CNAT" HeaderText="COMPLAINT NATURE" HtmlEncode="true" SortExpression="CNAT" />
                    <asp:BoundField DataField="SERV" HeaderText="SEVERITY" Visible="False" HtmlEncode="true" />
                    <asp:BoundField DataField="RFAIL" HeaderText="REASON OF FAILURE" Visible="False" HtmlEncode="true" />
                    <asp:BoundField DataField="STA" HeaderText="STATUS" HtmlEncode="true" />
                    <asp:BoundField DataField="WARR" HeaderText="WARRANTY STATUS" Visible="False" HtmlEncode="true" />
                    <asp:BoundField DataField="ACTION" HeaderText="ACTION TAKEN" Visible="False" HtmlEncode="true" />
                    <asp:BoundField DataField="OEA" HeaderText="OEA" Visible="False" HtmlEncode="true" />
                    <asp:BoundField DataField="AMC" HeaderText="AMC" Visible="False" HtmlEncode="true" />
                    <asp:BoundField DataField="TTR" HeaderText="TTR" Visible="False" HtmlEncode="true" />
                    <asp:BoundField DataField="SLA" HeaderText="SLA STATUS" Visible="False" HtmlEncode="true" />
                    <asp:BoundField DataField="TSLOT" HeaderText="TIME SLOT" Visible="False" HtmlEncode="true" />
                    <asp:BoundField DataField="RESLA" HeaderText="REASON OF SLA" Visible="False" HtmlEncode="true" />
                    <asp:BoundField DataField="SSTA" HeaderText="SSTA" Visible="False" HtmlEncode="true" />
                    <asp:BoundField DataField="DPCODE" HeaderText="DPCODE" Visible="False" HtmlEncode="true" />
                    <asp:BoundField DataField="lmodi" HeaderText="lmodi" Visible="False" HtmlEncode="true" />
                </Columns>
            </asp:GridView>
    </div>
    </form>
</body>
</html>
