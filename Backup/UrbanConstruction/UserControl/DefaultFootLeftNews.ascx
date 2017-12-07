<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="DefaultFootLeftNews.ascx.cs" Inherits="UrbanConstruction.UserControl.DefaultFootLeftNews" %>
<div class="Left">
    <div class="LNav">
        <h2>
            工作动态</h2>
         <ul class="LeListCon">
             <%for (int i = 0; i < count; i++)
              {%>
               <li>
                <a href="WorkDynamic.aspx?MID=<%=list[i].M_ID.ToString() %>&MItemID=<%=list[i].M_ItemID.ToString() %>" target="_blank"><%=list[i].M_ItemName.ToString()%></a>
               </li>                            
            <%} %>
        </ul>
    </div>
</div>
