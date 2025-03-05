<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Site1.Master" AutoEventWireup="true" CodeBehind="MainManager.aspx.cs" Inherits="ServiceDesk.Views.WebForm3" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .modalPopup
        {
            background-color: white;
            width: 80vh;
            border:3px solid teal;
            height: auto;
        }
        .modalPopup .header
        {
            background-color: teal;
            height:50px;
            color: black;
            line-height:30px;
            text-align:center;
            font-weight: bold;
        }
        .modalPopup .middle
        {
            color: black;
            line-height:30px;
            text-align:left;
            padding:5px;
        }
        .modalPopup .footer
        {
            padding:10px;
        }
        .modalPopup2
        {
            background-color: white;
            width: 100vh;
            border:3px solid teal;
            height: auto;
        }
        .modalPopup2 .header
        {
            background-color: teal;
            height:50px;
            color: black;
            line-height:30px;
            text-align:center;
            font-weight: bold;
        }
        .modalPopup2 .middle
        {
            color: black;
            line-height:30px;
            text-align:left;
            padding:5px;
        }
        .modalPopup2 .footer
        {
            padding:10px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2 class="text-center">Проведение работ по остеклению</h2>
    <div class="row" style="height:40vh">
        <div class="col-md-7">
            <div style="max-height: 40vh; overflow-y: auto;">
                <asp:GridView ID="List" runat="server" AutoGenerateSelectButton="True" OnSelectedIndexChanged="selectApplication" CellPadding="4" ForeColor="#333333" GridLines="None">
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
            <div class="row" style="height:5px"></div>
            <div class="row mt-auto">
                <div class="col d-grid"> <asp:Button Text="Добавить заявку" ID="add" runat="server" CssClass="btn-group" OnClick="add_Click" /></div>
                <div class="col d-grid"> 
                        <div class="row">
                            <div class="col-md-6">
                                <asp:Button Text="Фильтровать" runat="server" CssClass="btn-group" ID="Button3" OnClick="Filter" />
                            </div>
                            <div class="col-md-6">
                                <asp:DropDownList ID="DropDownList5" runat="server" CssClass="btn-group" DataTextField="Наименование"  
                                    AutoPostBack="true" OnSelectedIndexChanged="DropDownList5_SelectedIndexChanged" Width="115%"></asp:DropDownList>
                            </div>
                        </div>
                </div>
                <div class="col d-grid"> <asp:Button Text="Сортировать" runat="server" CssClass="btn-group" OnClick="Sort"/></div>
                <div class="col d-grid"> <asp:Button Text="Рекламация" runat="server" CssClass="btn-group" OnClick="Reklama"/></div>
            </div>
        </div>
        <div class="col d-flex justify-content-center">
                <asp:Calendar ID="Calendar1" runat="server" OnSelectionChanged="Calendar_SelectionChanged" BackColor="White" BorderColor="Black" 
                    DayNameFormat="Shortest" Font-Names="Times New Roman" Font-Size="10pt" ForeColor="Black" Height="100%" NextPrevFormat="FullMonth" 
                    TitleFormat="Month" Width="100%" OnDayRender="Calendar1_DayRender">
                    <DayHeaderStyle BackColor="#CCCCCC" Font-Bold="True" Font-Size="7pt" ForeColor="#333333" Height="10pt" />
                    <DayStyle Width="14%" />
                    <NextPrevStyle Font-Size="8pt" ForeColor="White" />
                    <OtherMonthDayStyle ForeColor="#999999" />
                    <SelectedDayStyle BackColor="#CC3333" ForeColor="White" />
                    <SelectorStyle BackColor="#CCCCCC" Font-Bold="True" Font-Names="Verdana" Font-Size="8pt" ForeColor="#333333" Width="1%" />
                    <TitleStyle BackColor="teal" Font-Bold="True" Font-Size="13pt" ForeColor="White" Height="14pt" />
                    <TodayDayStyle BackColor="#CCCC99" />
                </asp:Calendar>            
        </div>
    </div>
    <div class="row" style="height:60px"></div>
    <div class="row" style="height:20vh">
        <asp:GridView ID="GridView2" runat="server" CellPadding="4" ForeColor="Black" GridLines="Horizontal" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" OnDataBound="GridView2_DataBound">
        <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
        <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
        <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
        <SortedAscendingCellStyle BackColor="#F7F7F7" />
        <SortedAscendingHeaderStyle BackColor="#4B4B4B" />
        <SortedDescendingCellStyle BackColor="#E5E5E5" />
        <SortedDescendingHeaderStyle BackColor="#242121" />
        </asp:GridView>
    </div>
    <div class="row">
        <h3>Уведомления о просроченных заявках</h3>
        <asp:GridView ID="GridView7" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None">
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
    <ajaxToolkit:ModalPopupExtender ID="ModalPopupExtender1" PopupControlID="Panel1" runat="server" 
        CancelControlID="Button2" TargetControlID="Label2" PopupDragHandleControlID="header"></ajaxToolkit:ModalPopupExtender>
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:Panel ID="Panel1" CssClass="modalPopup" runat="server">
        <div id ="header" class="header">
            <h2 class="text-center">Добавление заявки</h2>
        </div>
        <div id ="details" class="middle">
            <div class="row" style="height:10px"></div>
            <div class="row">
                    <div><asp:Label ID="Label6" runat="server" Text="Номер"></asp:Label></div>
                    <div><asp:TextBox ID="TextBox2" runat="server" Width="100%"></asp:TextBox></div>
                     <div><asp:Label ID="Label7" runat="server" Text="Фамилия"></asp:Label></div>
                     <div><asp:TextBox ID="TextBox3" runat="server"  Width="100%"></asp:TextBox></div>
                     <div><asp:Label ID="Label8" runat="server" Text="Имя"></asp:Label></div>
                     <div><asp:TextBox ID="TextBox4" runat="server" Width="100%"></asp:TextBox></div>
                     <div><asp:Label ID="Label9" runat="server" Text="Отчество"></asp:Label></div>
                     <div><asp:TextBox ID="TextBox5" runat="server" Width="100%"></asp:TextBox></div>
                     <div><asp:Label ID="Label10" runat="server" Text="Адрес"></asp:Label></div>
                     <div><asp:TextBox ID="TextBox6" runat="server" Width="100%"></asp:TextBox></div>
                    <div><asp:Label ID="Label1" runat="server" Text="Тип заявки" ></asp:Label></div>
                    <div><asp:DropDownList ID="DropDownList2" runat="server" CssClass="btn-group" DataTextField="Наименование заявки" AutoPostBack="true" OnSelectedIndexChanged="DropDownList2_SelectedIndexChanged"></asp:DropDownList></div>
                     <div><asp:Label ID="Label11" runat="server" Text="Тип конструкции"></asp:Label></div>
                    <div><asp:DropDownList ID="DropDownList1" runat="server" CssClass="btn-group" DataTextField="Наименование конструкции" AutoPostBack="true" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged"></asp:DropDownList></div>
                </div>
            </div>
        <div id ="footer" class="footer"></div>
        <asp:Button ID="Button1" runat="server" Text="Добавить" OnClick="Button1_Click" CssClass="btn-group"/>
        <asp:Button ID="Button2" runat="server" Text="Закрыть" CssClass="btn-group"/>
        <div class="row" style="height:10px"></div>
    </asp:Panel>
   <ajaxToolkit:ModalPopupExtender ID="ModalPopupExtender2" PopupControlID="Panel2" runat="server" 
    CancelControlID="Button2" TargetControlID="Label13" PopupDragHandleControlID="header2"></ajaxToolkit:ModalPopupExtender>
    <asp:Panel ID="Panel2" CssClass="modalPopup2" runat="server">
        <div id ="header2" class="header">
            <h2 class="text-center">Информация по заявке</h2>
        </div>
        <div id ="details2" class="middle">
            <asp:GridView ID="GridView1" runat="server" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Horizontal">
                <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
                <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
                <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
                <SortedAscendingCellStyle BackColor="#F7F7F7" />
                <SortedAscendingHeaderStyle BackColor="#4B4B4B" />
                <SortedDescendingCellStyle BackColor="#E5E5E5" />
                <SortedDescendingHeaderStyle BackColor="#242121" />
            </asp:GridView>            
            <asp:Label ID="Label14" runat="server" Text="Изменение ответственного"></asp:Label>
            <asp:DropDownList ID="DropDownList3" runat="server" CssClass="btn-group" DataTextField="ФИО"  
                                    AutoPostBack="true" OnSelectedIndexChanged="DropDownList3_SelectedIndexChanged"></asp:DropDownList>
        </div>
        <div id ="footer2"></div>
        <asp:Button ID="Button4" runat="server" Text="Изменить" OnClick="Button4_Click" CssClass="btn-group"/>
        <asp:Button ID="Button5" runat="server" Text="Закрыть" CssClass="btn-group"/>
    </asp:Panel>
    <asp:Label ID="Label2" runat="server"></asp:Label>
    <asp:Label ID="Label13" runat="server"></asp:Label>
     <ajaxToolkit:ModalPopupExtender ID="ModalPopupExtender3" PopupControlID="Panel3" runat="server" 
      CancelControlID="Button2" TargetControlID="Label13" PopupDragHandleControlID="header3"></ajaxToolkit:ModalPopupExtender>
      <asp:Panel ID="Panel3" CssClass="modalPopup2" runat="server">
          <div id ="header3" class="header">
              <h2 class="text-center">Информация по заявке</h2>
          </div>
          <div id ="details3" class="middle">
              <asp:GridView ID="GridView3" runat="server" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Horizontal">
                  <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
                  <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" />
                  <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
                  <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
                  <SortedAscendingCellStyle BackColor="#F7F7F7" />
                  <SortedAscendingHeaderStyle BackColor="#4B4B4B" />
                  <SortedDescendingCellStyle BackColor="#E5E5E5" />
                  <SortedDescendingHeaderStyle BackColor="#242121" />
              </asp:GridView>
              <asp:Label ID="Label5" runat="server" Text="Комментарий замерщика"></asp:Label>
              <asp:TextBox ID="TextBox1" runat="server" Width="80%"></asp:TextBox>
          </div>
          <div id ="footer3"></div>
          <asp:Button ID="Button6" runat="server" Text="Добавить" OnClick="Button6_Click" CssClass="btn-group"/>
          <asp:Button ID="Button7" runat="server" Text="Закрыть" CssClass="btn-group"/>
      </asp:Panel>
      <asp:Label ID="Label3" runat="server"></asp:Label>
      <asp:Label ID="Label4" runat="server"></asp:Label>
    <ajaxToolkit:ModalPopupExtender ID="ModalPopupExtender4" PopupControlID="Panel4" runat="server" 
         CancelControlID="Button2" TargetControlID="Label13" PopupDragHandleControlID="header4"></ajaxToolkit:ModalPopupExtender>
         <asp:Panel ID="Panel4" CssClass="modalPopup2" runat="server">
             <div id ="header4" class="header">
                 <h2 class="text-center">Информация по заявке</h2>
             </div>
             <div id ="details4" class="middle">
                 <asp:GridView ID="GridView4" runat="server" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Horizontal">
                     <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
                     <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" />
                     <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
                     <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
                     <SortedAscendingCellStyle BackColor="#F7F7F7" />
                     <SortedAscendingHeaderStyle BackColor="#4B4B4B" />
                     <SortedDescendingCellStyle BackColor="#E5E5E5" />
                     <SortedDescendingHeaderStyle BackColor="#242121" />
                 </asp:GridView>
                 <asp:GridView ID="GridView5" runat="server" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Horizontal">
                    <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
                    <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
                    <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
                    <SortedAscendingCellStyle BackColor="#F7F7F7" />
                    <SortedAscendingHeaderStyle BackColor="#4B4B4B" />
                    <SortedDescendingCellStyle BackColor="#E5E5E5" />
                    <SortedDescendingHeaderStyle BackColor="#242121" />
                </asp:GridView>
                 <asp:Label ID="Label18" runat="server" Text="Выберите тип работы"></asp:Label>
                 <asp:DropDownList ID="DropDownList4" runat="server" CssClass="btn-group" DataTextField="Наименование работы"  
                        AutoPostBack="true" OnSelectedIndexChanged="DropDownList4_SelectedIndexChanged"></asp:DropDownList>
                 <div><asp:Label ID="Label19" runat="server" Text="Объем работы"></asp:Label>
                <asp:TextBox ID="TextBox9" runat="server" Width="50%"></asp:TextBox></div>
                 <div><asp:Button ID="Button10" runat="server" Text="Добавить" OnClick="Button10_Click" /></div>
                 <div><asp:Label ID="Label12" runat="server" Text="Дата в формате дд.мм.гггг"></asp:Label>
                 <asp:TextBox ID="TextBox7" runat="server" Width="50%"></asp:TextBox></div>
                 <div><asp:Label ID="Label17" runat="server" Text="Время в формате чч:мм"></asp:Label>
                <asp:TextBox ID="TextBox8" runat="server" Width="50%"></asp:TextBox></div>
                 <div><asp:Label ID="Label20" runat="server" Text="Бригада"></asp:Label>
                     <asp:DropDownList ID="DropDownList6" runat="server" CssClass="btn-group" DataTextField="Наименование бригады"  
                        AutoPostBack="true" OnSelectedIndexChanged="DropDownList6_SelectedIndexChanged"></asp:DropDownList></div>
             </div>
             <div id ="footer4">
                 <asp:Label ID="Label21" runat="server" Text="Label" ForeColor="DarkRed" Visible="False"></asp:Label>
                 <asp:Button ID="Button8" runat="server" Text="Сохранить" OnClick="Button8_Click" CssClass="btn-group"/>
                 <asp:Button ID="Button9" runat="server" Text="Закрыть" CssClass="btn-group"/>
                 </div>
         </asp:Panel>
    <ajaxToolkit:ModalPopupExtender ID="ModalPopupExtender5" PopupControlID="Panel5" runat="server" 
     CancelControlID="Button2" TargetControlID="Label13" PopupDragHandleControlID="header5"></ajaxToolkit:ModalPopupExtender>
     <asp:Panel ID="Panel5" CssClass="modalPopup2" runat="server">
         <div id ="header5" class="header">
             <h2 class="text-center">Информация по заявке</h2>
         </div>
         <div id ="details5" class="middle">
             <asp:GridView ID="GridView6" runat="server" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Horizontal">
                 <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
                 <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" />
                 <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
                 <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
                 <SortedAscendingCellStyle BackColor="#F7F7F7" />
                 <SortedAscendingHeaderStyle BackColor="#4B4B4B" />
                 <SortedDescendingCellStyle BackColor="#E5E5E5" />
                 <SortedDescendingHeaderStyle BackColor="#242121" />
             </asp:GridView>
         </div>
         <div id ="footer5"></div>
         <asp:Button ID="Button12" runat="server" Text="Изменить статус на 'Выполнено'" OnClick="Button12_Click" CssClass="btn-group"/>
         <asp:Button ID="Button13" runat="server" Text="Закрыть" CssClass="btn-group"/>
     </asp:Panel>
    <ajaxToolkit:ModalPopupExtender ID="ModalPopupExtender6" PopupControlID="Panel6" runat="server" 
     CancelControlID="Button2" TargetControlID="Label13" PopupDragHandleControlID="header6"></ajaxToolkit:ModalPopupExtender>
     <asp:Panel ID="Panel6" CssClass="modalPopup2" runat="server">
         <div id ="header6" class="header">
             <h2 class="text-center">Информация по заявке</h2>
         </div>
         <div id ="details6" class="middle">
             <asp:GridView ID="GridView8" runat="server" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Horizontal">
                 <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
                 <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" />
                 <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
                 <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
                 <SortedAscendingCellStyle BackColor="#F7F7F7" />
                 <SortedAscendingHeaderStyle BackColor="#4B4B4B" />
                 <SortedDescendingCellStyle BackColor="#E5E5E5" />
                 <SortedDescendingHeaderStyle BackColor="#242121" />
             </asp:GridView>            
         </div>
         <div id ="footer6"></div>
         <asp:Button ID="Button14" runat="server" Text="Закрыть" CssClass="btn-group"/>
     </asp:Panel>
    <asp:HiddenField ID="StateHiddenField" runat="server" Value="0" />
    <asp:HiddenField ID="HiddenField1" runat="server" Value="0" />
    <asp:HiddenField ID="HiddenField2" runat="server" />
    <asp:HiddenField ID="HiddenField3" runat="server" />
    <asp:Timer ID="Timer1" runat="server" OnTick="Timer1_Tick"></asp:Timer>
</asp:Content>
