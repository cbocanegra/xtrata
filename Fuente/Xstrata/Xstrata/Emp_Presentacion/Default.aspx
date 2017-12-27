<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Default.aspx.vb" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/javascript" src="ToolTip/jquery.js"></script>
	<script type="text/javascript" src="ToolTip/tooltip.jquery.js"></script>
    
    <script type="text/javascript">
			$(document).ready(function(){
				$('.tooltip').tooltip({
							folderurl : '../../contents/'
							});
				$('.tooltip2').tooltip();	
				$('.tooltip3').tooltip({
							folderurl : '../../contents/'
							});
				$('.tooltip4').tooltip();
				$('.tooltip5').tooltip({width: '250px'});
				$('.tooltip6').tooltip({width: '250px', height: '75px'});
				$('.tooltip7').tooltip({cursor: 'wait'});					
			}
      
      );
		</script>
         
</head>
<body>
    <form id="form1" runat="server">
    <div>    
        <asp:TextBox ID="TextBox1" runat="server" class="tooltip"></asp:TextBox>    
    </div>
    </form>
</body>
</html>
