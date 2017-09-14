//August Lee 2015/03/06
//Notes: Before Call the Maximize function , u have to assign the myLayout first! 
var myLayout;

function LayoutMax(panel) {
    myLayout.open(panel);
    setTimeout(function () {
        toggleMaximize(panel, "", true);
        },
        300
    );
}

function LayoutMin(panel) {
    toggleMaximize(panel, "", false);
    myLayout.close(panel);
}

//MaxMin:true =>Max ;MaxMin:1 =>false
function toggleMaximize(paneName, cbPane, MaxMin) {
    var pane = cbPane || paneName
    $Pane = myLayout.panes[pane]
        , state = myLayout.state
        , s = state[pane]
        , container = state.container
        , isMaximized = null
        , panePaddingAndBorderHeight = s.outerHeight - s.css.height
        , panePaddingAndBorderWidth = s.outerWidth - s.css.width
        ;

    if (pane === "north" || pane === "south") {
        if ($Pane.height() == s.css.height) {
            $Pane.css({
                height: container.innerHeight - panePaddingAndBorderHeight
            , zIndex: 3
            });
            isMaximized = true;
        }
        else { // RESET pane to what state says it *should be*
            $Pane.css({
                height: s.css.height
            , zIndex: 1
            });
            isMaximized = false;
        }
    }
    else if (pane === "east" || pane === "west") {
        if ($Pane.width() == s.css.width) {
            s.top = $Pane.css("top"); // save value | TODO: add top/bottom/left/right to state.pane.css data
            $Pane.css({
                //	need to also set top & height if want to cover north/south panes
                //	if only want to cover west-center-east panes, then DO NOT set top or height!
                top: container.insetTop
            , height: container.innerHeight - panePaddingAndBorderHeight
            , width: container.innerWidth - panePaddingAndBorderWidth
            , zIndex: 3
            });
            isMaximized = true;
        }
        else { // RESET pane to what state says it *should be*
            $Pane.css({
                top: s.top
            , height: s.css.height
            , width: s.css.width
            , zIndex: 1
            });
            isMaximized = false;
        }
    }
    //alert("MaxMin:" + MaxMin + "; isMaximized:" + isMaximized);
    //August 
    if (MaxMin && !isMaximized) //Max with isMaximized = false 
        return;
    if (!MaxMin && isMaximized) //Min with isMaximized = true 
        return;

    // if no valid pane was passed, then exit now
    if (isMaximized === null) return;

    // set flags so can check a pane's state to see if it is 'maximized'
    s.maximized = isMaximized;
    // set var for use by onresizeall callback to re-maximize pane after window.resize
    container.maximizedPane = isMaximized ? pane : '';

    // OPTIONALLY show/hide all other panes in Layout
    for (var i = 0; i < 5; i++) {
        var name = $.layout.config.allPanes[i]
        , $P = myLayout.panes[name];
        if (!$P || name == pane) continue; // SKIP un/maximized pane
        if (isMaximized && $P.is(":visible")) {
            state[name].hiddenByMaximize = true; // set a state-flag
            $P.css("visibility", "hidden"); // make pane invisible
            if (name !== "center")
                myLayout.resizers[name].hide(); // ditto for its resizer-bar
        }
        else if (!isMaximized && state[name].hiddenByMaximize) {
            state[name].hiddenByMaximize = false; // clear flag
            $P.css("visibility", "visible"); // reset visibility
            if (name !== "center")
                myLayout.resizers[name].show(); // ditto for its resizer-bar
        }
    }

    // if maximized, add events to catch pane.close or resizeAll, which UN-maximize the pane
    if (isMaximized) {
        $Pane.bind("layoutpaneonclose_start.toggleMaximize", toggleMaximize)
            .bind("layoutpaneonresize_start.toggleMaximize", toggleMaximize);
        // TODO: pane.onresize is not reliably firing when layout resized
        //		try adding a callback to layoutonresize_start as well, pane = state.container.maximizedPane
    }
    else {
        // remove events (above) added when pane was maximized
        $Pane.unbind(".toggleMaximize");
        if (!cbPane) // skip if this is being called by runCallback() to avoid disrupting sequence
            myLayout.resizeAll();
    }
};

//GIS Layout and CallBack
function OpenGIS(SigNno) {
    myLayout = $('body').layout();
    myLayout.hide("north");
    myLayout.hide("west");
    var size = screen.width;
    myLayout.sizePane("east", size);
    setTimeout(function () {
            myLayout.show("east", true);
            loadGIS(SigNno);
        },
        200
    );
}

function CloseGIS() {
    //if (typeof (window.frames[0].stop) === 'undefined') {
    //    //Internet Explorer code
    //    setTimeout(function () { window.frames[0].document.execCommand('Stop'); }, 1000);
    //} else {
    //    //Other browsers
    //    setTimeout(function () { window.frames[0].stop(); }, 1000);
    //}
    myLayout = $('body').layout();
    myLayout.sizePane("east", 0);
    myLayout.hide("east");
    myLayout.sizePane("west", .15);
    myLayout.show("west", true);
    myLayout.open("west");
    myLayout.show("north", true);
    myLayout.open("north");
}

function loadGIS(SigNno) {
    var gis = $("div[id='GIS']");
    var url = 'http://163.29.242.88:8080/DLA/web_page/DLA010100.jsp?SignNo=' + SigNno;
    var html = "<iframe id='gisframe' src='" + url + "' style='position: absolute; z-index: 1; height: 100%; width:100%; border: none' scrolling='no' marginheight='0' marginwidth='0' frameborder='0'></iframe>";
    html += "<div id='btnCloseGIS' style='position: absolute; z-index: 2; top: 0px; right: 0px; display: block; cursor: pointer; padding: 4px; background-color: lightgreen; font-size: 15px;' onclick='CloseGIS();'><span>返回財管系統</span></div>";
    gis.html(html);
}

var eventMethod = window.addEventListener ? "addEventListener" : "attachEvent";
var eventer = window[eventMethod];
var messageEvent = eventMethod == "attachEvent" ? "onmessage" : "message";

// Listen to message from child window
eventer(messageEvent, function (e) {
    var origina = e.origin;
    var key = e.message ? "message" : "data";
    var data = e[key];
    //run function//
    ReceiveCallback(e, data);
}, false);

function ReceiveCallback(msg, data) {
    //if (msg.origin == "http://ndemo.tw-futaba.com.tw") 
    {
        CloseGIS();
        window.location.href = "/UnitLand/ULM010?spe=" + msg.data;
    }
}