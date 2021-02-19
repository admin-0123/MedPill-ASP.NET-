<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="WebForm2.aspx.cs" Inherits="EDP_Clinic.WebForm2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">

    <asp:Label ID="lblError" runat="server"></asp:Label>  
    <asp:ListView ID="ListView1" runat="server" GroupItemCount="3" OnPagePropertiesChanging="ListView1_PagePropertiesChanging">  
        <EmptyDataTemplate>  
            <table runat="server">  
                <tr>  
                    <td>No data was returned.</td>  
                </tr>  
            </table>  
        </EmptyDataTemplate>  
        <EmptyItemTemplate>  
            <td runat="server" />  
        </EmptyItemTemplate>  
        <GroupTemplate>  
            <tr runat="server" id="itemPlaceholderContainer">  
                <td runat="server" id="itemPlaceholder"></td>  
            </tr>  
            <span> Apple </span>
        </GroupTemplate>  
      
      
        <ItemTemplate>  
            <td runat="server">TestCol1:  
                <asp:Label Text='<%# Eval("dateTime") %>' runat="server" ID="TestCol1Label" /><br /> TestCol2:  
                <asp:Label Text='<%# Eval("appointmentType") %>' runat="server" ID="TestCol2Label" /><br /> TestCol3:  
                <asp:Label Text='<%# Eval("doctorID") %>' runat="server" ID="TestCol3Label" /><br />  
            </td>  
        </ItemTemplate>  
        <LayoutTemplate>  
            <table runat="server">  
                <tr runat="server">  
                    <td runat="server">  
                        <table runat="server" id="groupPlaceholderContainer" border="0">  
                            <tr runat="server" id="groupPlaceholder"></tr>  
                        </table>  
                    </td>  
                </tr>  
                <tr runat="server">  
                    <td runat="server">  
                        <asp:DataPager runat="server" PageSize="5" ID="DataPager1">  
                            <Fields>  
                                <asp:NumericPagerField></asp:NumericPagerField>  
      
                            </Fields>  
                        </asp:DataPager>  
                    </td>  
                </tr>  
            </table>  
        </LayoutTemplate>  
      
    </asp:ListView>  

        </div>
</asp:Content>
