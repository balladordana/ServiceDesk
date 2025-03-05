<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Site1.Master" AutoEventWireup="true" CodeBehind="Brigads2.aspx.cs" Inherits="ServiceDesk.Views.WebForm7" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2 class="text-center">Бригады</h2>
    <div class="row">
         <div class="col-md-4">
             <form>
                 <div class="mb-3">
                 <label for="Name" class="form-label" style="color:black">Наименование бригады</label>
                 <input type="text" class="form-control" id="Name" runat="server" required="required">
                 </div>
                 <div class="mb-3">
                 <label for="Fio" class="form-label" style="color:black">ФИО бригадира</label>
                 <input type="text" class="form-control" id="Fio" runat="server" required="required">
                 </div>
                <div class="mb-3">
                 <label for="Kol" class="form-label" style="color:black">Количество работников</label>
                 <input type="text" class="form-control" id="Kol" runat="server" required="required">
                 </div>
                 <div class="mb-3">
                 <label for="Tel" class="form-label" style="color:black">Телефон бригадира</label>
                 <input type="text" class="form-control" id="Tel" runat="server" required="required">
                 </div>
                 <div><asp:Label runat="server" ID="label" ForeColor="Black"></asp:Label></div>
                 
                 <div class="row mt-auto">
                     <div class="col d-grid"><asp:Button ID="edit" runat="server" Text="Изменить" class="btn-group" OnClick="edit_Click"></asp:Button></div>
                     <div class="col d-grid"><asp:Button ID="add" runat="server" Text="Добавить" class="btn-group" OnClick="add_Click"></asp:Button></div>
                     <div class="col d-grid"><asp:Button ID="delete" runat="server" Text="Удалить" class="btn-group" OnClick="delete_Click"></asp:Button></div>
                </div>
             </form>
         </div>
        <div class="col-md-8">
            <asp:GridView ID="List" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" AutoGenerateSelectButton="true" OnSelectedIndexChanged="List_SelectedIndexChanged">
                <AlternatingRowStyle BackColor="White" />
                <EditRowStyle BackColor="#7C6F57" />
                <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="teal" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="#E3EAEB" />
                <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
                <SortedAscendingCellStyle BackColor="#F8FAFA" />
                <SortedAscendingHeaderStyle BackColor="#246B61" />
                <SortedDescendingCellStyle BackColor="#D4DFE1" />
                <SortedDescendingHeaderStyle BackColor="#15524A" />
            </asp:GridView>
        </div>
    </div>
</asp:Content>
