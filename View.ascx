<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="View.ascx.cs" Inherits="Christoc.Modules.LESS141029.View" %>


<link rel="stylesheet" href="<%= ModulePath %>Resources/js/colorPicker/spectrum.css" />
<link rel="stylesheet" href="<%= ModulePath %>Resources/css/css<%=ModuleId%>.css?<%= DateTime.Now.ToLongTimeString() %>" />


<asp:Literal ID="litInlineStyle" runat="server" Mode="Transform"></asp:Literal>


<asp:Label ID="lblColor1" runat="server" Text="Color 1"></asp:Label>
<asp:TextBox ID="txtColor1" runat="server" CssClass="colorPicker"></asp:TextBox>
<asp:HiddenField ID="hidColor1" runat="server" />
<%--<asp:TextBox ID="txtColor1Result" runat="server"></asp:TextBox>--%>
<asp:Button ID="btnSubmutColor" runat="server" Text="Button" OnClick="btnSubmutColor_Click" />
<br />
Generated LESS:<asp:Label ID="lblGeneratedLESS" runat="server" Text="Generated LESS"></asp:Label>
<br />
Generated CCS:<asp:Label ID="lblGeneratedCSS" runat="server" Text="Generated CSS"></asp:Label>



<br /><br />

<div class="css<%=ModuleId%>color1" style="height:100px;width:100%;"></div>


<script src="<%= ModulePath %>/Resources/js/colorPicker/spectrum.js"></script>
<script>

    var css<%=ModuleId%>init = $(".css<%=ModuleId%>color1").css('backgroundColor');

    $("#triggerSet").spectrum("set", $("#enterAColor").val());


    $("#<%=txtColor1.ClientID %>").spectrum({

        color: css<%=ModuleId%>init,
        clickoutFiresChange: true,
        move: function (color) {
            var color1 =  color.toHexString(); // #ff0000
            $(".css<%=ModuleId%>color1").css("background", color1);
            $(<%= hidColor1.ClientID %>).val(color1);
         
            

          
        }

    });
</script>