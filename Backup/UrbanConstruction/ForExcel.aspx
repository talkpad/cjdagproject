<%@ Page Language="C#" MasterPageFile="~/WebSite.Master" AutoEventWireup="true" CodeBehind="ForExcel.aspx.cs" Inherits="UrbanConstruction.ForExcel" Title="建筑工程档案预验收" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<script src="js/jquery-1.9.1.js" type="text/javascript"></script>
<script type="text/javascript">
    $(document).ready(function() {
    $("#mySelect").change(function() {
    window.location.href = "ForExcel.aspx?searchtype=<%=searchtype %>&value=<%=value %>&pageIndex=" + $("#mySelect").val() + "&token=<%=CreateToken() %>";
        });
    });
</script>
    <style type="text/css">
.gvinfo
{
   line-height:40px;
}
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 <input type="hidden" id="ssid" name="ssid" runat="server"/>
    <div>
      <select id="paramSel" runat="server">
        <option value="0" selected="selected">请选择</option>		
        <option value="1">预验收证书编号</option>
        <option value="2" >项目名称</option> 
        <option value="3">建设单位</option>  
      </select>        
      <input id="valueText" type="text"  size="50" runat="server"/>   
      <input type="submit" id="btn_search"  runat="server" onserverclick="search_click" value="检索"/>
    </div>
    <asp:GridView ID="GridView1" runat="server" CssClass="gvinfo" 
        PageSize="20" HeaderStyle-Width="800px" 
        AutoGenerateColumns="False" Width="990px">
        <Columns>
            <asp:BoundField DataField="序号" HeaderText="序号"  >
                <ItemStyle HorizontalAlign="Center" Width="40px" />
            </asp:BoundField>
            <asp:BoundField DataField="预验收时间" HeaderText="预验收时间" >
                <ItemStyle HorizontalAlign="Center" Width="85px" />
            </asp:BoundField>
            <asp:BoundField DataField="预验收证书编号" HeaderText="预验收证书编号" >
                <ItemStyle HorizontalAlign="Center" Width="145px" />
            </asp:BoundField>
            <asp:BoundField DataField="项目名称" HeaderText="项目名称" >
                <ItemStyle Width="200px" />
            </asp:BoundField>
            <asp:BoundField DataField="建设单位" HeaderText="建设单位" >
                <ItemStyle Width="200px" />
            </asp:BoundField>
        </Columns>    

<HeaderStyle Width="800px"></HeaderStyle>
    </asp:GridView>
        <p class="Page">第<span><%=pageIndex %></span>页&nbsp;&nbsp;/&nbsp;&nbsp;共<%=pageCount %>页&nbsp;&nbsp;
                <%if (pageIndex == 1)
                  {%>
                  <a href="javascript:void(0);" class="SX">第一页</a>&nbsp;&nbsp;
                  <a href="javascript:void(0);" class="SX">上一页</a>&nbsp;&nbsp;
                <%} %>
                <%else
                    { %>
                     <a href="ForExcel.aspx?searchtype=<%=searchtype %>&value=<%=value %>&pageIndex=1&token=<%=CreateToken() %>">第一页</a>&nbsp;&nbsp;
                     <a href="ForExcel.aspx?searchtype=<%=searchtype %>&value=<%=value %>&pageIndex=<%=pageIndex-1 %>&token=<%=CreateToken() %>">上一页</a>&nbsp;&nbsp;
                <%} %>
                 <%if (pageIndex == pageCount)
                  {%>
                    <a href="javascript:void(0);" class="SX">下一页</a>&nbsp;&nbsp;
                    <a href="javascript:void(0);"class="SX">尾页</a>&nbsp;&nbsp;
                <%} %>
                <%else
                    { %>
                      <a href="ForExcel.aspx?searchtype=<%=searchtype %>&value=<%=value %>&pageIndex=<%=pageIndex+1 %>&token=<%=CreateToken() %>">下一页</a>&nbsp;&nbsp;
                      <a href="ForExcel.aspx?searchtype=<%=searchtype %>&value=<%=value %>&pageIndex=<%=pageCount %>&token=<%=CreateToken() %>">尾页</a>&nbsp;&nbsp;
                <%} %>
              
                第<select id="mySelect">
                <%for (int i = 0; i < pageCount; i++)
                  {%>
                  <%if ((i + 1) == pageIndex)
                    {%>
                     <option selected="selected"><%=i + 1%></option>
                  <%} %>
                  <%else
                      { %>
                      <option><%=i + 1%></option>
                  <%} %>
                 
                <%} %>
                </select>页</p>
</asp:Content>
