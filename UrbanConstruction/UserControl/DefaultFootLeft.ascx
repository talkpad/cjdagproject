<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="DefaultFootLeft.ascx.cs"
    Inherits="UrbanConstruction.UserControl.DefaultFootLeft" %>
<div class="ListL">
    <div class="LZCFG">
        <!--S本馆简介-->
        <h2>
            <span>本馆简介</span></h2>
        <ul>
            <%for (int i = 0; i < count; i++)
              {%>
            <li><a href="about.aspx?kind=<%=list[i].Kind.ToString() %>">
                <%=list[i].M_ItemName.ToString()%></a> </li>
            <%} %>
        </ul>
    </div>
    <!--E政策法规-->
    
    <div class="LPIC">
        <!--S图片链接-->
        <div>
            <a href="Consult.aspx?type=1&token=<%=Session["CRSFToken"] %>" target="_blank">
                <img src="images/picMailboxB.jpg" width="268" height="48" alt="馆长信箱" /></a></div>
        <div>
            <a href="Consult.aspx?type=2&token=<%=Session["CRSFToken"] %>" target="_blank">
                <img src="images/picComehereB.jpg" width="268" height="48" alt="来馆路线" /></a></div>
        <div class="picTell">
            <a href="messageList.aspx" target="_blank">
                <img src="images/picTellB.jpg" width="268" height="83" alt="公共互动" /></a></div>
    </div>
    <!--E图片链接-->
    <div class="LFriendlink">
        <h2>
            <span>友情链接</span></h2>
        <ul>
            <li>
                <select name="link" onchange="javascript:window.open(this.options[this.selectedIndex].value);">
                    <option value="" selected="selected">政府网站</option>
                    <option value="http://www.gov.cn">中华人民共和国中央人民政府门户网站</option>
                    <option value="http://www.gd.gov.cn">广东省人民政府网</option>
                    <option value="http://www.zs.gov.cn">中山市人民政府</option>
                </select>
            </li>
            <li>
                <select name="link" onchange="javascript:window.open(this.options[this.selectedIndex].value);">
                    <option value="" selected="selected">规划局网站</option>
                    <option value="http://bjcjdag.bjghw.gov.cn">北京市规划委员会</option>
                    <option value="http://www.upo.gov.cn/">广州市规划局</option>
                    <option value="http://www.zsghj.gov.cn">中山市城乡规划局</option>
                </select>
            </li>
            <li>
                <select name="link" onchange="javascript:window.open(this.options[this.selectedIndex].value);">
                    <option value="" selected="selected">档案局网站</option>
                    <option value="http://www.chinaarchives.cn/">中国档案网</option>
                    <option value="http://www.da.gd.gov.cn">广东档案信息网</option>
                    <option value="http://www.zsda.gov.cn">中山市档案信息网</option>
                </select>
            </li>
            <li>
                <select name="link" onchange="javascript:window.open(this.options[this.selectedIndex].value);">
                    <option value="" selected="selected">城建档案馆网站</option>
                    <option value="http://www.gzuda.gov.cn">广州市城建档案馆</option>
                    <option value="http://www.cqcjda.com">重庆市城市建设档案馆</option>
                    <option value="http://www.csccic.com">长沙城建档案馆</option>
                     <option value="http://www.suca.com.cn/">上海城建档案馆</option>
                    <option value="http://www.whcjda.gov.cn/16/">武汉城建档案馆</option>
                    <option value="http://www.zhcjda.com/default.htm">珠海城建档案馆</option>
                </select>
            </li>
        </ul>
    </div>
</div>
