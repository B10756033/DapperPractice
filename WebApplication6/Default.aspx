<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebApplication6._Default" EnableEventValidation="false"%>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <asp:HiddenField ID="hfBarcode" runat="server" Value=""/>
    <asp:Panel ID="pnlList" runat="server">
        <asp:Button ID="btnAdd" runat="server" Text="新增" OnClick="btnAdd_Click" class="btn btn-secondary" UseSubmitBehavior="false"/>
        <table class="table table-hover table-bordered">
        <asp:Repeater ID="rptVCard" runat="server" OnItemCommand="rptVCard_ItemCommand">
            <HeaderTemplate>
                <thead>
                    <th scope="col">Barcode</th>
                    <th scope="col">BookName</th>
                    <th scope="col">Author</th>
                    <th scope="col">PublishingHouse</th>
                    <th scope="col">PublicationDate</th>
                    <th scope="col">Price</th>
                </thead>
            </HeaderTemplate>
            <ItemTemplate>
                <tbody class="table-group-divider">
                    <td style="text-align: center; vertical-align: middle;">
                        <asp:Label runat="server" ID="Label0" Text='<%# Eval("Barcode")%>'></asp:Label>
                    </td>
                    <td style="text-align: center; vertical-align: middle;">
                        <asp:Label runat="server" ID="lblProperty" Text='<%# Eval("BookName")%>'></asp:Label>
                    </td>
                    <td style="text-align: center; vertical-align: middle;">
                        <asp:Label runat="server" ID="Label1" Text='<%# Eval("Author")%>'></asp:Label>
                    </td>
                    <td style="text-align: center; vertical-align: middle;">
                        <asp:Label runat="server" ID="Label2" Text='<%# Eval("PublishingHouse")%>'></asp:Label>
                    </td>
                    <td style="text-align: center; vertical-align: middle;">
                        <asp:Label runat="server" ID="Label3" Text='<%# Eval("PublicationDate", "{0:yyyy/MM/dd}")%>'></asp:Label>
                    </td>
                    <td style="text-align: center; vertical-align: middle;">
                        <asp:Label runat="server" ID="Label4" Text='<%# Eval("Price")%>'></asp:Label>
                    </td>
                    <td style="text-align: center;">
                        <asp:Button ID="Button3" runat="server" Text="檢視" CommandName="gvView" CommandArgument='<%# Eval("Barcode")%>' CssClass="btn btn-light" UseSubmitBehavior="false" />
                        <asp:Button ID="Button1" runat="server" Text="刪除" CommandName="gvDel" CommandArgument='<%# Eval("Barcode")%>' CssClass="btn btn-light" UseSubmitBehavior="false" />                    
                    </td>
                </tbody>
            </ItemTemplate>
        </asp:Repeater>
        </table>
    </asp:Panel>
    <asp:Panel ID="pnlView" runat="server" Visible="false">
        <table border="1">
            <asp:Label ID="Label11" runat="server" Text="Barcode"></asp:Label>
            <asp:TextBox ID="txt_Barcode" runat="server" Visible="false" CssClass="form-control" UseSubmitBehavior="false" Enabled="false"></asp:TextBox>
            <asp:Label ID="Label12" runat="server" Text="BookName"></asp:Label>
            <asp:TextBox ID="txt_BookName" runat="server" CssClass="form-control" UseSubmitBehavior="false" Enabled="false"></asp:TextBox>
            <asp:Label ID="Label13" runat="server" Text="Author"></asp:Label>            
            <asp:TextBox ID="txt_Author" runat="server" CssClass="form-control" UseSubmitBehavior="false" Enabled="false"></asp:TextBox>
            <asp:Label ID="Label14" runat="server" Text="PublishingHouse"></asp:Label>            
            <asp:TextBox ID="txt_PublishingHouse" runat="server" CssClass="form-control" UseSubmitBehavior="false" Enabled="false"></asp:TextBox>
            <asp:Label ID="Label15" runat="server" Text="PublicationDate"></asp:Label>            
            <asp:TextBox ID="txt_PublicationDate" runat="server" CssClass="form-control" UseSubmitBehavior="false" Enabled="false"></asp:TextBox>
            <asp:Image class="bi bi-calendar3" ID="Image1" runat="server" ImageUrl="~/Images/calendar3.svg" style="position: absolute; right: 5px; top: 50%; transform: translateY(-50%);" />
            <asp:Label ID="Label16" runat="server" Text="Price"></asp:Label>            
            <asp:TextBox ID="txt_Price" runat="server" CssClass="form-control" UseSubmitBehavior="false" Enabled="false"></asp:TextBox>
            
                <%--<td style="text-align: center;">
                    <asp:Label runat="server" ID="_Barcode" Text=""></asp:Label>
                </td>
                <td style="text-align: center;">
                    <asp:Label runat="server" ID="_BookName" Text=""></asp:Label>
                </td>
                <td style="text-align: center;">
                    <asp:Label runat="server" ID="_Author" Text=""></asp:Label>
                </td>
                <td style="text-align: center;">
                    <asp:Label runat="server" ID="_PublishingHouse" Text=""></asp:Label>
                </td>
                <td style="text-align: center;">
                    <asp:Label runat="server" ID="_PublicationDate" Text=""></asp:Label>
                </td>
                <td style="text-align: center;">
                    <asp:Label runat="server" ID="_Price" Text=""></asp:Label>
                </td>--%>
                
                <asp:Button ID="btnEdit" runat="server" Text="編輯" OnClick="btnEdit_Click" CssClass="btn btn-light" UseSubmitBehavior="false" />
                <asp:Button ID="btnBack" runat="server" Text="返回" OnClick="btnBack_Click" CssClass="btn btn-light" UseSubmitBehavior="false" />
                <%--<asp:LinkButton ID="Button2" runat="server" Text="編輯" OnClick="Button2_Click"/>--%>
                
        </table>
    </asp:Panel>
    <asp:Panel ID="pnlEdit" runat="server" Visible="false">
        <div class="col-auto">
            <asp:Label ID="Label5" runat="server" Text="Barcode"></asp:Label>
            <asp:TextBox ID="txtBarcode" runat="server" Visible="false" CssClass="form-control" UseSubmitBehavior="false"></asp:TextBox>
            <asp:Label ID="Label6" runat="server" Text="BookName"></asp:Label>
            <asp:TextBox ID="txtEdBknam" runat="server" CssClass="form-control" UseSubmitBehavior="false"></asp:TextBox>
            <asp:Label ID="Label7" runat="server" Text="Author"></asp:Label>            
            <asp:TextBox ID="txtEdAuthor" runat="server" CssClass="form-control" UseSubmitBehavior="false"></asp:TextBox>
            <asp:Label ID="Label8" runat="server" Text="PublishingHouse"></asp:Label>            
            <asp:TextBox ID="txtEdPublHouse" runat="server" CssClass="form-control" UseSubmitBehavior="false"></asp:TextBox>
            <asp:Label ID="Label9" runat="server" Text="PublicationDate"></asp:Label>            
            <table>
              <tr>
                <td style="position: relative;">
                  <asp:TextBox ID="txtEdPublDate" runat="server" CssClass="form-control" UseSubmitBehavior="false"></asp:TextBox>
                  <asp:Image class="bi bi-calendar3" ID="calImage" runat="server" ImageUrl="~/Images/calendar3.svg" style="position: absolute; right: 5px; top: 50%; transform: translateY(-50%);" />
                </td>
              </tr>
            </table>
            <ajaxToolkit:CalendarExtender ID="calExtender" runat="server"
                TargetControlID="txtEdPublDate"
                Format="yyyy-MM-dd"
                PopupButtonID="calImage">
            </ajaxToolkit:CalendarExtender>
            <asp:Label ID="Label10" runat="server" Text="Price"></asp:Label>            
            <asp:TextBox ID="txtEdPrice" runat="server" CssClass="form-control" UseSubmitBehavior="false"></asp:TextBox>
            <asp:Button ID="Button4" runat="server" Text="儲存" OnClick="save_Click" CssClass="btn btn-light" UseSubmitBehavior="false" />                    
            <asp:Button ID="Button2" runat="server" Text="返回" OnClick="btnBack_Click" CssClass="btn btn-light" UseSubmitBehavior="false" />                    
        </div>
    </asp:Panel>
</asp:Content>
