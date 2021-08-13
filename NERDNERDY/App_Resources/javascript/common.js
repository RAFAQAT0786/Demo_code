function createxmlhttp() {
    try { xmlHttp = new XMLHttpRequest(); } // Firefox, Opera 8.0+, Safari
    catch (e) {
        try { xmlHttp = new ActiveXObject("Msxml2.XMLHTTP"); } // Internet Explorer
        catch (e) { xmlHttp = new ActiveXObject("Microsoft.XMLHTTP"); }
    }
    return xmlHttp;
}
function setval(dest, src) {
    var destctl = document.getElementById('ctl00_ContentPlaceHolder1_' + dest);
    if (!destctl) return;
    destctl.value = src.value;
}
function clearControls(ctrl) {
    var arrCtl = ctrl.split(',');//alert(arrdest);//alert(retval.count + " " + arrdest.length);
    for (i = 0; i < arrCtl.length; i++) {
        var destctl = document.getElementById('ctl00_ContentPlaceHolder1_' + arrCtl[i]); //alert(destctl);
        if (destctl) destctl.value = "";
    }
}
function cexist(page, params, dests, fields, func) {
    alert(page + " " + params + " " + dests);
    if (params == "") return false;
    //alert(1);
    //clearControls(dests);

    xmlHttp = createxmlhttp();
    if (xmlHttp) {
        alert(1);
        xmlHttp.onreadystatechange = function () { dexist(dests, fields, func); };
        var qstr = "LoadData.aspx?page=" + page + "&";
        arrparams = params.split(',');
        for (i = 0; i < arrparams.length; i++)
            qstr += "param" + i + "=" + arrparams[i] + (i < arrparams.length - 1 ? "&" : ""); //qstr=Exist.aspx?page=EmpCode&param0=2&param1=18";
        alert(qstr);
        xmlHttp.open("POST", qstr, true);
        xmlHttp.setRequestHeader('Content-Type', 'application/x-www-form-urlencoded');
        xmlHttp.send();
    }
    alert('END');
}
function SendRequest(page, params, callbackfunc) {
    xmlHttp = createxmlhttp();
    if (xmlHttp) {
        xmlHttp.onreadystatechange = function () { dexist(dests, fields, func); };
        var qstr = "LoadData.aspx?page=" + page + "&";
        arrparams = params.split(',');
        for (i = 0; i < arrparams.length; i++)
            qstr += "param" + i + "=" + arrparams[i] + (i < arrparams.length - 1 ? "&" : ""); //qstr=Exist.aspx?page=EmpCode&param0=2&param1=18";
        xmlHttp.open("POST", qstr, true);
        xmlHttp.setRequestHeader('Content-Type', 'application/x-www-form-urlencoded');
        xmlHttp.send();
    }
}
function dexist(dests, fields, func) {
    if (xmlHttp.readyState == 4 && xmlHttp.status == 200) // if xmlhttp shows "loaded" AND "OK"
    {
        var retval = xmlHttp.responseText;  //alert('retval' + retval);
        retval = eval(retval); alert(retval);
        if (retval)  //&& retval["retval"]!='undefined'
        {
            if (func != "") {
                str = func + "(retval)"; alert(str);
                eval(str);
            }
            else {
                arrdest = dests.split(','); alert(arrdest); alert(retval.count + " " + arrdest.length);
                arrFields = fields.split(','); alert(arrFields.length);//alert(retval.count + " " + arrdest.length);
                //for (i=0;i<arrdest.length;i++)
                for (var key in retval) {
                    i = findarray(arrFields, key);
                    //alert(key + " " + i);
                    var destctl = document.getElementById('ctl00_ContentPlaceHolder1_' + arrdest[i]); //alert(destctl);
                    if (destctl) destctl.value = retval[key];
                }
            }
        }
    }
}
function findarray(array, search) {
    for (i = 0; i < array.length; i++) {
        if (array[i] == search)
            return i;
    }
    return -1;
}

function showproperties(obj) {
    str = ""; str1 = "<pre>";
    for (var p in obj) {
        str = str + " " + p;
        str1 += "'   " + p + "=' + objAmt." + p + " + ";
    }
    //alert(str + "" + str1);
    document.write(str1);
}
function listdata(page, src, dest)//FILL COMBO
{
    var id;
    if (src.id == undefined)
        id = src;
    else
        id = src.value; //alert("id" + id);
    var destctl = document.getElementById('ctl00_ContentPlaceHolder1_' + dest);
    if (!destctl) return;
    destctl.length = 0;
    if (id == "") {
        return false;
    }
    xmlHttp = createxmlhttp();
    if (xmlHttp) {
        xmlHttp.onreadystatechange = function () { showdata(destctl, page); };

        xmlHttp.open("POST", "LoadData.aspx?page=" + page + "&param0=" + id + "", true);
        xmlHttp.setRequestHeader('Content-Type', 'application/x-www-form-urlencoded');
        xmlHttp.send();
    }
}
function showdata(destctl, page) // Called by listdata to fill combo
{
    if (xmlHttp.readyState == 4) // if xmlhttp shows "loaded"
    {
        if (xmlHttp.status == 200)  // if "OK"
        {
            var retval = xmlHttp.responseText;  //alert(retval);
            vResponseArray = eval(retval);          // alert(vResponseArray);
            var option = document.createElement("option");
            option.value = "";
            option.text = "-- Select " + page + "--";
            destctl.options.add(option);
            for (var key in vResponseArray) {   //alert(key + vResponseArray[key]);
                var option = document.createElement("option");
                option.value = key;
                option.text = vResponseArray[key];
                destctl.options.add(option);
            }
        }
    }
}
function validatedecimal(ctrl) {
    var Value = ctrl.value;
    if (Value == "") {
        ctrl.value = "0.00";
        return;
    }
    var arrParts = Value.split('.'); //alert(arrParts.length);
    if (arrParts.length == 1)
        ctrl.value = parseInt(Value) + ".00";
    else //if(arrParts.length > 1)
    {
        if (arrParts[1].length > 2) {
            varValue = arrParts[0];
            arrParts[1] = arrParts[1].substring(0, 2);
            ctrl.value = varValue + "." + arrParts[1];
        }
    }
}
function validateint(ctrl) {
    var Value = ctrl.value;
    if (Value == "") {
        ctrl.value = "0";
        return;
    }
}

function onlyint() {
    if (window.event) { keyCode = window.event.keyCode; evt = window.event; }
    else if (evt) keyCode = evt.which;
    else return true;

    inputField = evt.srcElement ? evt.srcElement : evt.target || evt.currentTarget;
    var text = inputField.value;
    if (!(window.event.keyCode > 47 && window.event.keyCode <= 57))
        window.event.keyCode = 0;
}
function onlydecimal() {
    if (window.event) { keyCode = window.event.keyCode; evt = window.event; }
    else if (evt) keyCode = evt.which;
    else return true;

    inputField = evt.srcElement ? evt.srcElement : evt.target || evt.currentTarget;
    var text = inputField.value;

    if (!(window.event.keyCode > 47 && window.event.keyCode <= 57 || window.event.keyCode == 46))
        window.event.keyCode = 0;
    var arrParts = text.split('.');
    if (arrParts.length > 1) {
        if (window.event.keyCode == 46) window.event.keyCode = 0;
        if (arrParts[1].length > 2) window.event.keyCode = 0;
    }
}
String.prototype.toProperCase = function () {
    return this.toLowerCase().replace(/^(.)|\s(.)/g,
        function ($1) { return $1.toUpperCase(); });
}