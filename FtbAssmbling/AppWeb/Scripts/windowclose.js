function init() {
    document.addEventListener("keydown", keyDownTextField, false);
    //$(window).on("beforeunload", function () {
    //    return bunload();//"close window";//inFormOrLink ? "Do you really want to close?" : null;
    //})
    window.onbeforeunload = function (e) {
        $.ajax({
            url: '@Url.Action("RecordUser","Home")',
            type: "POST",
            dataType: "json",
            //data: { name: request.term },
        })
    };
}

function keyDownTextField(e) { //ALT+F4
    var keyCode = e.keyCode;
    if ((window.event.altKey) && (window.event.keyCode == 115)) {
        $.ajax({
            url: '@Url.Action("RecordUser","Home")',
            type: "POST",
            dataType: "json",
            //data: { name: request.term },
        });
    }
    //else { isAltF4 = false; }

    //alert("[window.event.keyCode]" + window.event.keyCode);
    //alert("[window.event.altKey]" + window.event.altKey);
}

//function document.onkeydown()
//{
//    if ((window.event.altKey) && (window.event.keyCode == 115)) 
//    {
//        isAltF4 = true;
//        bunload();
//    }
//    else { isAltF4 = false;   }
//}
//真的關閉時，要觸發logoutUser
//window.onunload = logoutUser;
//function logoutUser() 
//{
//    //多判斷是不是按下[X]關閉，是的話才做登出
//    if (isXClose) 
//    {
//        try {
//            if (window.XMLHttpRequest) 
//            { // Mozilla, Safari,...
//                xmlhttp = new XMLHttpRequest();
//                if (http_request.overrideMimeType) 
//                {
//                    http_request.overrideMimeType('text/xml');
//                }
//            }
//            else if (window.ActiveXObject) 
//            { // IE
//                try {
//                    xmlhttp = new ActiveXObject("Msxml2.XMLHTTP");
//                } 
//                catch (e)

//                {
//                    try {
//                        xmlhttp = new ActiveXObject("Microsoft.XMLHTTP");
//                    } 
//                    catch (e) { }
//                }
//            }  // else IF
//            //var xmlhttp = new ActiveXObject("Microsoft.XMLHTTP");
//            xmlhttp.open("POST", "Logout.aspx", false);
//            xmlhttp.send();
//            return true;
//        } 
//        catch (e) {
//            alert('delete user account error message:' + e.message);
//        }
//    } // end if (isXClose)
//} // end function logoutUser()