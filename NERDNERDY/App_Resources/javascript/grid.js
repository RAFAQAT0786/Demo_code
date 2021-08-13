var Totalchk;
var Counter;
window.onload = function () {
    Totalchk = parseInt('<%= this.GridView1.Rows.Count %>');   //Get total no. of CheckBoxes in side the GridView.
    Counter = 0;
}

function SelectUnSelectAll(CheckBox) {
    var grid = document.getElementById('<%= this.GridView1.ClientID %>');//Get target base & child control.
    var checkbox = "chkSelect";

    var Inputs = grid.getElementsByTagName("input");//Get all control of type INPUT in the base control.

    for (var n = 0; n < Inputs.length; ++n)
        if (Inputs[n].type == 'checkbox' && Inputs[n].id.indexOf(checkbox, 0) >= 0)
            Inputs[n].checked = CheckBox.checked;

    Counter = CheckBox.checked ? Totalchk : 0;
}

function SelectUnSelect(CheckBox) {
    var grid = document.getElementById('<%= this.GridView1.ClientID %>');//Get target base & child control.
    var Inputs = grid.getElementsByTagName("input");//Get all control of type INPUT in the base control.
    if (CheckBox.checked && Counter < Totalchk)   //Modifiy Counter;
        Counter++;
    else if (Counter > 0)
        Counter--;
    if (Counter < Totalchk)   //Change state of the header CheckBox.
        Inputs[0].checked = false;
    else if (Counter == Totalchk)
        Inputs[0].checked = true;
}
function F() {
    <script type="text/javascript" language="javascript">
    var Totalchk;
    var Counter;
    window.onload = function()
{
        Totalchk = parseInt('<%= this.GridView1.Rows.Count %>');   //Get total no. of CheckBoxes in side the GridView.
    Counter = 0;
 }
 function SelectUnSelectAll(CheckBox)
{
   var grid = document.getElementById('<%= this.GridView1.ClientID %>');//Get target base & child control.
    var checkbox = "chkSelect";

    var Inputs = grid.getElementsByTagName("input");//Get all control of type INPUT in the base control.

   for(var n = 0; n < Inputs.length; ++n)
     if(Inputs[n].type == 'checkbox' && Inputs[n].id.indexOf(checkbox,0) >= 0)
          Inputs[n].checked = CheckBox.checked;

    Counter = CheckBox.checked ? Totalchk : 0;
 }

 function SelectUnSelect(CheckBox)
{
   var grid = document.getElementById('<%= this.GridView1.ClientID %>');//Get target base & child control.
    var Inputs = grid.getElementsByTagName("input");//Get all control of type INPUT in the base control.
   if(CheckBox.checked && Counter < Totalchk)   //Modifiy Counter;
    Counter++;
 else if(Counter > 0)
    Counter--;
   if(Counter < Totalchk)   //Change state of the header CheckBox.
    Inputs[0].checked = false;
 else if(Counter == Totalchk)
    Inputs[0].checked = true;
}
function F()
{var res = confirm('Do You Want to Delete Education Detail?');
    //alert(res);
    if(res)
  {
    var grid=document.getElementById("<%=GridView1.ClientID%>");
    if (!grid)
    {alert("No Record Selected");
    return false;
}
var vData='';
var checkbox = "chkSelect";
var Inputs = grid.getElementsByTagName("input");//Get all control of type INPUT in the base control.
    for(var n = 1; n < Inputs.length; ++n)
        if(Inputs[n].type == 'checkbox' && Inputs[n].id.indexOf(checkbox,0) >= 0 && Inputs[n].checked)
            vData=vData+ Inputs[n].value + ',';  //alert(vData);
    document.getElementById("<%=TXTVALUE.ClientID %>").value=vData;//alert(vData);
    if (vData=="")
    {
        alert("No Record Selected");
    return false;
}
}}}
</script>
    var grid = document.getElementById("<%=GridView1.ClientID%>");
    if (!grid) {
        alert("No Record Selected");
        return false;
    }
    var vData = '';
    var checkbox = "chkSelect";
    var Inputs = grid.getElementsByTagName("input");//Get all control of type INPUT in the base control.
    for (var n = 1; n < Inputs.length; ++n)
        if (Inputs[n].type == 'checkbox' && Inputs[n].id.indexOf(checkbox, 0) >= 0 && Inputs[n].checked)
            vData = vData + Inputs[n].value + ',';  //alert(vData);
    document.getElementById("<%=TXTVALUE.ClientID %>").value = vData;//alert(vData);
    if (vData == "") {
        alert("No Record Selected");
        return false;
    }
}