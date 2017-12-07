<%@ Page Language="C#" MasterPageFile="~/WebSite.Master" AutoEventWireup="true" CodeBehind="NewsDetail.aspx.cs"
    Inherits="UrbanConstruction.NewsDetail" Title="详细新闻" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
   <script src="js/jquery-1.9.1.js" type="text/javascript"></script>
<script type="text/javascript">
    function custom_close() {
        window.opener = null;

        window.open('', '_self');

        window.close();  
    }
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="middle">
        <!--S中间内容区域-->
        <p class="dw">
            您现在的位置： <a href="index.aspx">首页</a>&nbsp;&nbsp;<%if (news != null)
                                                             { %><span>&gt;&gt;</span>&nbsp;&nbsp;<a href=" <%=menu.Url.ToString() %>">
                <%if (menu != null)
                  { %>
                  <%=menu.M_NAME.ToString()%>
                  <%} %></a>&nbsp;&nbsp;<span>&gt;&gt;</span>&nbsp;&nbsp;    
                  
                  <%if (news.Kind == 2)
                {%>              
                   <%=news.Title.Substring(0, news.Title.Length - 1)%>
                   <%} %>
                   <%else
                      { %>
                        <%=news.Title.ToString()%>
                   <%} %><%} %></p>
        <div class="Content">
            <!--S详细内容页-->
            <%if (news != null)
              { %>
              <%if (news.Kind == 2)
                {%>
              
            <h3>
               <%=news.Title.Substring(0, news.Title.Length - 1)%></h3>
               <%} %>
               <%else
                  { %>
                   <h3>
                    <%=news.Title.ToString()%></h3>
               <%} %>
            <hr />
            <p class="Date">
               来源：<%=news.Source.ToString() %>&nbsp;&nbsp;&nbsp;&nbsp; 发布日期：<%=news.ReleaseTime.ToString("yyyy-MM-dd")%>&nbsp;&nbsp;&nbsp;&nbsp;<%if (menu.M_ID == 9)
                                                                                           {%>作者：<%} %><%else{ %>发布人：<%} %><%=news.Author.ToString()%>
            </p>
            <div class="ContnetNR">
            <%=news.Content.ToString()%>
            </div>
            <div class="ConFoot">
                <p class="ConFootL">
                    <%if (pre.Count > 0)
                      {%>
                    <a href="NewsDetail.aspx?FID=<%=pre[0].ID.ToString() %>">上一篇：<%=pre[0].Title.ToString()%></a><br>
                    <%} %>
                    <%else
                { %>
                         <a href="#">上一篇：没有了......</a><br>
                    <%} %>
                      <%if (next.Count > 0)
                        {%>
                    <a href="NewsDetail.aspx?FID=<%=next[0].ID.ToString() %>" class="ConFootLaR">下一篇：<%=next[0].Title.ToString()%></a></p>
                     <%} %>
                    <%else
                { %>
                         <a href="#">下一篇：没有了......</a><br>
                    <%} %>
                    <%} %>
                <div class="ConFootR">
                <%-- <input type="button" onclick="javascript:window.history.back(-1);"  value="返回"/>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;--%>
                    <input type="button" onclick="custom_close()"  value="关闭"/>
                </div>
            </div>
            
        </div>
        <!--E详细内容页-->
    </div>
    <!--E中间内容区域-->
</asp:Content>
