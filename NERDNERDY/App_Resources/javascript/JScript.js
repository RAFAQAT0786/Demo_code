<script language="JScript">
    var iNextPageToCreate = 1;

    function AddFirstPage()
{
        alert(1);
    newHTML  = "<IE: DEVICERECT ID='page1' MEDIA='print' CLASS='pagestyle'>";
    alert(2);
    newHTML += "<IE: LAYOUTRECT ID='layoutrect1' CONTENTSRC='document'" +
              "ONLAYOUTCOMPLETE='OnRectComplete()' NEXTRECT='layoutrect2'" +
              "CLASS='lorstyle'/>";
   newHTML += "</IE: DEVICERECT > ";
alert(3);
pagecontainer.insertAdjacentHTML("afterBegin", newHTML);
}

function OnRectComplete() {
    if (event.contentOverflow == true) {
        document.all("layoutrect" + iPageToCreate).onlayoutcomplete = null;

        newHTML = "<IE:DEVICERECT ID='page" + (iPageToCreate + 1) +
            "' MEDIA='print' CLASS='pagestyle'>";
        newHTML += "<IE:LAYOUTRECT ID='layoutrect" + (iPageToCreate + 1) +
            "' ONLAYOUTCOMPLETE='OnRectComplete()' NEXTRECT='layoutrect" +
            (iPageToCreate + 2) + "'  CLASS='lorstyle'/>";
        newHTML += "</IE:DEVICERECT>";

        pagecontainer.insertAdjacentHTML("beforeEnd", newHTML);
        iPageToCreate++;
    }
}
</script >