//August Lee release in 2014/10/20

var au_InsertSuccessMsg = "新增成功";
var au_InsertErrorMsg = "新增失敗";
var au_UpdateSuccessMsg = "修改成功";
var au_UpdateErrorMsg = "修改失敗";
var au_DeleteSuccessMsg = "刪除成功";
var au_DeleteErrorMsg = "刪除失敗";

var InsertSuccess = "InsertSuccess";
var InsertFail = "InsertFail";
var UpdateSuccess = "UpdateSuccess";
var UpdateFail = "UpdateFail";
var DeleteSuccess = "DeleteSuccess";
var DeleteFail = "DeleteFail";

//設定 jquery datepicker 中文語系
$.datepicker.regional['zh-TW'] = {
    dayNames: ["星期日", "星期一", "星期二", "星期三", "星期四", "星期五", "星期六"],
    dayNamesMin: ["日", "一", "二", "三", "四", "五", "六"],
    monthNames: ["一月", "二月", "三月", "四月", "五月", "六月", "七月", "八月", "九月", "十月", "十一月", "十二月"],
    monthNamesShort: ["一月", "二月", "三月", "四月", "五月", "六月", "七月", "八月", "九月", "十月", "十一月", "十二月"],
    prevText: "上月",
    nextText: "次月",
    weekHeader: "週",
    changeMonth: true,
    changeYear: true,
    showMonthAfterYear: true,
    yearRange: "1991:+55", //民國80年 ~ 今年+15年
    //beforeShow: function (input, inst) {
    //    inst.dpDiv.css({ marginTop: -input.offsetHeight + 'px', marginLeft: input.offsetWidth + 'px' });
    //}
    //beforeShow: function (input, inst) {
    //    // Handle calendar position before showing it.
    //    // It's not supported by Datepicker itself (for now) so we need to use its internal variables.
    //    var calendar = inst.dpDiv;

    //    // Dirty hack, but we can't do anything without it (for now, in jQuery UI 1.8.20)
    //    setTimeout(function () {
    //        calendar.position({
    //            my: 'right top',
    //            at: 'right bottom',
    //            collision: 'none',
    //            of: input
    //        });
    //    }, 1);
    //}
};
//將 jquery datepicker 預設語系設定為中文
$.datepicker.setDefaults($.datepicker.regional["zh-TW"]);

//將 jquery datepicker 日期格式化為民國年
(function ($) {
    $.extend($.datepicker, {
        formatDate: function (format, date, settings) {
            var d = date.getDate();
            var m = date.getMonth() + 1;
            var y = date.getFullYear();
            var fy = function (v) {
                return (v < 100 ? '0' : '') + v;
            };
            var fm = function (v) {
                return (v < 10 ? '0' : '') + v;
            };
            return fy((y - 1911)) + '' + fm(m) + '' + fm(d);
        },
        parseDate: function (format, value, settings) {
            var v = new String(value);
            var Y, M, D;
            if (v.length == 7) {/*1001215*/
                Y = v.substring(0, 3) - 0 + 1911;
                M = v.substring(3, 5) - 0 - 1;
                D = v.substring(5, 7) - 0;
                return (new Date(Y, M, D));
            } else if (v.length == 6) {/*981215*/
                Y = v.substring(0, 2) - 0 + 1911;
                M = v.substring(2, 4) - 0 - 1;
                D = v.substring(4, 6) - 0;
                return (new Date(Y, M, D));
            }
            return (new Date());
        },
        formatYear: function (v) {
            return '民國' + (v - 1911) + '年';
            //return '' + (v - 1911);
        }
    });

    //$.fn.test = function () {
    //    this.on('click', function () {
    //        alert('test $.fn()');
    //    });
    //};
})(jQuery);

// alertify(彈跳視窗dialog) 預設值
alertify.defaults = {
    // dialogs defaults
    modal: true,
    basic: false,
    frameless: false,
    movable: true,
    resizable: true,
    closable: true,
    closableByDimmer: true,
    maximizable: true,
    startMaximized: false,
    pinnable: true,
    pinned: true,
    padding: true,
    overflow: true,
    maintainFocus: true,
    transition: 'pulse',
    autoReset: true,

    // notifier defaults
    notifier: {
        // auto-dismiss wait time (in seconds)  
        delay: 3,
        // default position
        position: 'bottom-right'
    },

    // language resources 
    glossary: {
        // dialogs default title
        title: '',
        // ok button text
        ok: '確定',
        // cancel button text
        cancel: '取消'
    },

    // theme settings
    theme: {
        // class name attached to prompt dialog input textbox.
        input: 'ajs-input',
        // class name attached to ok button
        ok: 'ajs-ok',
        // class name attached to cancel button 
        cancel: 'ajs-cancel'
    }
};

// Override default alert() 
//(function (proxied) {
//    window.alert = function () {
//        // do something here
//        return proxied.apply(this, arguments);
//    };
//})(window.alert);

function Save(response) {
    var msg = "";
    var hasError = false;
    if (response == null) {
        msg = "操作失敗!";
        hasError = true;
    }
    var result = response['Result'];
    var message = response['Message'];
    //alert(result);
    switch (result) {
        case "ERROR":
            msg = message;
            hasError = true;
            break;
        case InsertSuccess:
            response['Result'] = "OK";
            msg = IsEmpty2(message, au_InsertSuccessMsg);
            //if (message == null)
            //    msg = au_InsertSuccessMsg;
            //else
            //    msg = message;
            window.top.notifyMessage(msg, false);
            return;
        case UpdateSuccess:
            response['Result'] = "OK";
            msg = IsEmpty2(message, au_UpdateSuccessMsg);
            //if (message == null)
            //    msg = au_UpdateSuccessMsg;
            //else
            //    msg = message;
            window.top.notifyMessage(msg, false);
            return;
        case DeleteSuccess:
            response['Result'] = "OK";
            msg = IsEmpty2(message, au_DeleteSuccessMsg);
            //if (message == null)
            //    msg = au_DeleteSuccessMsg;
            //else
            //    msg = message;
            window.top.notifyMessage(msg, false);
            return;
        case InsertFail:
            response['Result'] = "ERROR";
            msg = message;//response['Message'];
            hasError = true;
            break;
        case UpdateFail:
            response['Result'] = "ERROR";
            msg = message;//response['Message'];
            hasError = true;
            break;
        default:
            hasError = false;
            if (msg == null || msg == undefined || msg == "")
                msg = message;
            break;
    }
    msg = msg.replace(/\r\n/g, '<br />').replace(/\r/g, '<br />').replace(/\n/g, '<br />').replace(/\&lt;br \/&gt;/g, '<br />');
    if (result == "ERROR" || hasError) {
        //alert(msg);
        //ShowMessage(msg);
        alertify.alert(msg);
    } else {
        window.top.notifyMessage(msg, false);
    }
};

function IsEmpty2(msg, others) {
    if (msg == null || msg == undefined || msg == "")
        return others;
    return msg;
}

var CloseDialog = function () {
    var parent = window.parent.$("div#fm");
    if (parent != null) {
        parent.dialog("close");
    }
}

var DialogCloseListener = new Object();
DialogCloseListener.whatButtonFireEvent = function (obj,pk) {
    // do nothing,for override.
}

DialogCloseListener.CloseEvent = function () {
    // do nothing,for override.
}
DialogCloseListener.CloseEvent = function (obj) {
    // do nothing,for override.
}

DialogCloseListener.init = function () {

};

function CheckEmpty(obj, objname) {
    //var objname = "";
    //if (obj.attr("title") != null)
    //    objname = obj.attr("title").val();
    if (obj.val().toString() == "") //if (obj.val().toString().trim() == "")
        return "[" + objname + "]不可為空!" + "\r\n";
    return "";
}

function OpenDialog(obj, heights, weights, modal) {
    obj.on('click', function (e) {
        e.preventDefault();
        var fullscreen = false;
        var page = $(this).attr("url");
        var pagetitle = $(this).attr("title");

        var $dialog = $('<div id="fm" style="overflow: hidden;"></div>')
        .html('<iframe  style="border: 0px;  "  src="' + page + '" width="100%" height="100%"></iframe>')
        .dialog({
            autoOpen: false,
            show: {
                effect: "fade",
                duration: 100
            },
            hide: {
                effect: "fade",
                duration: 100
            },
            modal: modal,
            height: heights,
            width: weights,
            //open: function (event, ui) { $("#div[id='fm']").css('overflow', 'hidden'); $('.ui-widget-overlay').css('width', '100%'); },
            //close: function (event, ui) { $("#div[id='fm']").css('overflow', 'auto'); },
            title: pagetitle
            , buttons: {
                "儲存": function (e) {
                    //DialogCloseListener.CloseEvent();
                    //DialogCloseListener.whatButtonFireEvent($(this));
                    //$(this).dialog("close")
                    var id = DialogCloseListener.init();
                    var IsOK = DialogCloseListener.CloseEvent();
                    if (IsOK) {
                        DialogCloseListener.whatButtonFireEvent(id);
                        $(this).dialog("close");
                    }
                },
                "離開": function () {
                    //DialogCloseListener.whatButtonFireEvent(page);
                    $(this).dialog("close")
                },
                "全螢幕": function () {
                    if (!fullscreen) {
                        $(this).dialog("option", "position", [0, 0]);
                        $(this).dialog("option", "width", $(window).width());
                        $(this).dialog("option", "height", $(window).height());
                        fullscreen = true;
                    }
                    else {
                        $(this).dialog("option", "width", weights);
                        $(this).dialog("option", "height", heights);
                        $(this).dialog("option", "position", "center");
                        fullscreen = false;
                    }
                }
            }
            //, close: function (event, ui) {
            //    DialogCloseListener.whatButtonFireEvent($(this));
            //}
        });
        $dialog.OpenDialog = function () {

        }
        //$dialog.dialog("option", "buttons", {}); //全部按鈕移除
        $dialog.dialog('open');
        //$dialog.find("#inp").text('123');
    });
}

function ShowDialog(heights, weights, modal, url, title, IsCopy) {
    var fullscreen = false;
    var page = url;
    var pagetitle = title;
    var $dialog = $('<div id="fm" style="overflow: hidden; margin:0px; padding:0px;"></div>')
    .html('<iframe style="border: 0px; margin:0px; padding:0px;" src="' + page + '" width="100%" height="100%"></iframe>')
    .dialog({
        autoOpen: false,
        show: {
            effect: "fade",
            duration: 100
        },
        hide: {
            effect: "fade",
            duration: 100
        },
        modal: modal,
        height: heights,
        width: weights,
        title: pagetitle
        , buttons: {
            "儲存": function (e) {
                var id = DialogCloseListener.init();
                var IsOK = DialogCloseListener.CloseEvent();
                if (IsOK) {
                    DialogCloseListener.whatButtonFireEvent(id);
                    $(this).dialog("close");
                }
            },
            //"繼續新增": function (e) {
            //    var id = DialogCloseListener.init();
            //    var IsOK = DialogCloseListener.CloseEvent();
            //    if (IsOK) {
            //        DialogCloseListener.whatButtonFireEvent(id);
            //        $(this).dialog("close");
            //        ShowDialog(heights, weights, modal, url, title, IsCopy);
            //    }
            //    else {
            //        return false;
            //    }

            //    //var IsOK = DialogCloseListener.CloseEvent();
            //    //if (IsOK) {   //2015/01/06 不重新查詢視窗
            //    //    DialogCloseListener.whatButtonFireEvent($(this));
            //    //}
            //},
            "離開": function () {
                //DialogCloseListener.whatButtonFireEvent($(this));
                $(this).dialog("close");
            },
            "全螢幕": function () {
                if (!fullscreen) {
                    $(this).dialog("option", "position", [0, 0]);
                    $(this).dialog("option", "width", $(window).width());
                    $(this).dialog("option", "height", $(window).height());
                    fullscreen = true;
                }
                else {
                    $(this).dialog("option", "width", weights);
                    $(this).dialog("option", "height", heights);
                    $(this).dialog("option", "position", "center");
                    fullscreen = false;
                }
            }
        }
        //, close: function (event, ui) {
        //    DialogCloseListener.whatButtonFireEvent($(this));
        //}
    });
    $dialog.OpenDialog = function () {

    }
    $(".ui-dialog-buttonpane button:contains('繼續新增')").hide();//.button("disable");
    //if (IsCopy != null & IsCopy == true)
    //    $(".ui-dialog-buttonpane button:contains('繼續新增')").show();
    $dialog.dialog('open');
}

function PCE042ShowDialog(heights, weights, modal, url, title, IsCopy) {
    var fullscreen = false;
    var page = url;
    var pagetitle = title;
    var $dialog = $('<div id="fm" style="overflow: hidden;"></div>')
    .html('<iframe  style="border: 0px;  "  src="' + page + '" width="100%" height="100%"></iframe>')
    .dialog({
        autoOpen: false,
        show: {
            effect: "fade",
            duration: 100
        },
        hide: {
            effect: "fade",
            duration: 100
        },
        modal: modal,
        height: heights,
        width: weights,
        title: pagetitle
        , buttons: {
            "資料異動": function (e) {
                var id = DialogCloseListener.init();
                var IsOK = DialogCloseListener.CloseEvent("Change");
                //if (IsOK) {
                //    DialogCloseListener.whatButtonFireEvent(id);
                //    $(this).dialog("close");
                //}
            },
            "資料異動列印": function (e) {
                var id = DialogCloseListener.init("");
                var IsOK = DialogCloseListener.CloseEvent("Print");
                //if (IsOK) {
                //    ShowDialog(heights, weights, modal, url, title, IsCopy);
                //}
            },
            "離開": function () {
                DialogCloseListener.whatButtonFireEvent($(this));
                $(this).dialog("close");
            }
        }
        //, close: function (event, ui) {
        //    DialogCloseListener.whatButtonFireEvent($(this));
        //}
    });
    $dialog.OpenDialog = function () {

    }
    //$(".ui-dialog-buttonpane button:contains('繼續新增')").hide();//.button("disable");
    //if (IsCopy != null & IsCopy == true)
    //    $(".ui-dialog-buttonpane button:contains('繼續新增')").show();
    $dialog.dialog('open');
}

function PIE030ShowDialog(heights, weights, modal, url, title) {
    var fullscreen = false;
    var page = url;
    var pagetitle = title;
    var $dialog = $('<div id="fm" style="overflow: hidden;"></div>')
    .html('<iframe  style="border: 0px;  "  src="' + page + '" width="100%" height="100%"></iframe>')
    .dialog({
        autoOpen: false,
        show: {
            effect: "fade",
            duration: 100
        },
        hide: {
            effect: "fade",
            duration: 100
        },
        modal: modal,
        height: heights,
        width: weights,
        title: pagetitle
        , buttons: {
            "系統計算": function (e) {
                var id = DialogCloseListener.init();
                var IsOK = DialogCloseListener.CloseEvent("Calculate");
            },
            "列印": function (e) {
                var id = DialogCloseListener.init("");
                var IsOK = DialogCloseListener.CloseEvent("Print");
            },
            "確定": function (e) {
                var id = DialogCloseListener.init("");
                var IsOK = DialogCloseListener.CloseEvent("Confirm");
            },
            "離開": function () {
                DialogCloseListener.whatButtonFireEvent($(this));
                $(this).dialog("close");
            }
        }
    });
    $dialog.OpenDialog = function () {

    }
    //$(".ui-dialog-buttonpane button:contains('繼續新增')").hide();//.button("disable");
    //if (IsCopy != null & IsCopy == true)
    //    $(".ui-dialog-buttonpane button:contains('繼續新增')").show();
    $dialog.dialog('open');
}

function DialogButtonDisabled(ButtonName) {
    //隱藏
    window.parent.$(".ui-dialog-buttonpane button:contains('" + ButtonName + "')").button("disable");
    
    //August Lee revised 2015/7/21 default hide 
    DialogButtonHide(ButtonName);

    //Disabled
    //window.parent.$(".ui-dialog-buttonpane button:contains('儲存')")
    //  .attr("disabled", true);
}

function DialogButtonHide(ButtonName) {
    //隱藏
    window.parent.$(".ui-dialog-buttonpane button:contains('" + ButtonName + "')").hide();//button("disable");

    //Disabled
    //window.parent.$(".ui-dialog-buttonpane button:contains('儲存')")
    //  .attr("disabled", true);
}

//功能列全部取消
function Jtable_Toolbar_ByName(jtable, disable, name) {
    var toolbar = jtable.find('.jtable-toolbar span');
    if (disable) {
        toolbar.filter(function (index) {
            return $("span:contains('" + name + "')", this).length === 1;
        }).hide();
    }
    else {
        toolbar.filter(function (index) {
            return $("span:contains('" + name + "')", this).length === 1;
        }).show();
    }
}

function Jtable_Toolbar(jtable, disable) {
    if (disable) {
        jtable.find('.jtable-toolbar').hide();
    } else {
        jtable.find('.jtable-toolbar').show();
    }
}

function CodeQuery(heights, weights, modal, url, title) {
    var fullscreen = false;
    var page = url;
    var pagetitle = title;
    var $dialog = $('<div id="fm" style="overflow: hidden;"></div>')
    .html('<iframe  style="border: 0px;" src="' + page + '" width="100%" height="100%"></iframe>')
    .dialog({
        autoOpen: false,
        show: {
            effect: "fade",
            duration: 500
        },
        hide: {
            effect: "fade",
            duration: 500
        },
        modal: modal,
        height: heights,
        width: weights,
        title: pagetitle
        , buttons: {
            "離開": function () {
                $(this).dialog("close")
            },
            "全螢幕": function () {
                if (!fullscreen) {
                    $(this).dialog("option", "position", [0, 0]);
                    $(this).dialog("option", "width", $(window).width());
                    $(this).dialog("option", "height", $(window).height());
                    fullscreen = true;
                }
                else {
                    $(this).dialog("option", "width", weights);
                    $(this).dialog("option", "height", heights);
                    $(this).dialog("option", "position", "center");
                    fullscreen = false;
                }
            }
        }
    });
    $dialog.OpenDialog = function () {
    }
    $dialog.dialog('open');
}

//沒輸入欄位，背景警告顏色
var Required_BackGround_Color = "pink"; //"salmon";
var CheckInput = function () {
    var msg = "";
    //if (navgator("MSIE"))
    try { //IE才做判斷
        $("input").each(function (obj) {
            var attr = $(this).attr('required');
            // For some browsers, `attr` is undefined; for others,
            // `attr` is false.  Check for both.
            var title = $(this).attr('title');
            if (typeof attr !== typeof undefined && attr !== false) {
                if ($(this).val() == null) {
                    //var title = $(this).attr('title').replace("：", "").replace("!", "");
                    if (typeof title !== typeof undefined)
                        title = title.replace("：", "").replace("!", "");
                    msg += "[" + title + "] 為必填欄位!" + "<br />";
                    $(this).css("background-color", Required_BackGround_Color);
                }
                else if ($(this).val() == "") {//else if ($(this).val().trim() == "") {
                    //var title = $(this).attr('title').replace("：", "").replace("!", "");
                    if (typeof title !== typeof undefined)
                        title = title.replace("：", "").replace("!", "");
                    msg += "[" + title + "] 為必填欄位!" + "<br />";
                    $(this).css("background-color", Required_BackGround_Color);
                }
                else {
                    $(this).css("background-color", "white");
                }
            }
        });

        $("select").each(function (obj) {
            var attr = $(this).attr('required');
            // For some browsers, `attr` is undefined; for others,
            // `attr` is false.  Check for both.
            if (typeof attr !== typeof undefined && attr !== false) {
                if ($(this).val() == null) {
                    var title = $(this).attr('title').replace("：", "").replace("!", "");
                    msg += "[" + title + "] 為必填欄位!" + "<br />";
                    $(this).css("background-color", Required_BackGround_Color);
                }
                else if ($(this).val() == "") {//else if ($(this).val().trim() == "") {
                    var title = $(this).attr('title').replace("：", "").replace("!", "");
                    msg += "[" + title + "] 為必填欄位!" + "<br />";

                    $(this).css("background-color", Required_BackGround_Color);
                }
                else {
                    $(this).css("background-color", "white");
                }
            }
            else {
                $(this).css("background-color", "white");
            }
        });

        if (msg != "") {
            //alert(msg);
            alertify.alert(msg);
            return false;
        }
    } catch (ex) {
        //alert(ex);
        alertify.alert(ex.toString());
        return false;
    };
    return true;
};

function navgator(patter) {
    if (patter == "MSIE")
        return navigator.userAgent.match("MSIE");
    else if (patter == "Chrome")
        return navigator.userAgent.match("Chrome");
    else if (patter == "Firefox")
        return navigator.userAgent.match("Firefox");
    else
        return navigator.userAgent.match("MSIE");
}

function sleep(milliseconds) {
    var start = new Date().getTime();
    for (var i = 0; i < 1e7; i++) {
        if ((new Date().getTime() - start) > milliseconds) {
            break;
        }
    }
}

/* 左邊補0 */
function padLeft(str, len, chr) {
    str = '' + str;
    return str.length >= len ? str : new Array(len - str.length + 1).join(chr) + str;
}

/* 右邊補0 */
function padRight(str, len, chr) {
    str = '' + str;
    return str.length >= len ? str : str + new Array(len - str.length + 1).join(chr);
}

function Disabled(obj, disable, clear) {
    var attr = obj.attr("disabled");
    if (!disable) { //要啟用
        obj.removeAttr('disabled').css("background-color", "white");
        if (obj.hasClass('hasDatepicker')) {
            obj.datepicker("enable");
        }
    } else {
        if (clear) {
            obj.val("");
        }
        //if (obj.is("select")) {
        //obj.css("background-color", "lightgray");
        obj.css("background-color", "#DDDDDD");
        //obj.css("font-color", "black");
        //}
        obj.attr('disabled', 'disabled');
        if (obj.hasClass('hasDatepicker')) {
            obj.datepicker("disable");
        }
    }
}

function ReadOnly(obj, readonly) {
    var attr = obj.attr("Readonly");
    if (!readonly) //要啟用
    {
        obj.removeAttr('readonly');
        obj.removeAttr('disabled');
        obj.css("background-color", "white");
        if (obj.hasClass('hasDatepicker')) {
            obj.datepicker("enable");
        }
    }
    else {
        obj.attr('Readonly', 'Readonly');
        obj.attr('disabled', 'disabled');
        obj.css("background-color", "lightgray");
        if (obj.hasClass('hasDatepicker')) {
            obj.datepicker("disable");
        }
    }
}

//require: true =>加入 required='required' 反之則移除
function Required(obj, required, clear) {
    var attr = obj.attr("required");
    var id = "span_" + obj.attr("id")
    if (!required) //非必填
    {
        if (clear)
            obj.val("");
        obj.removeAttr('required');
        //$("span[id='" + id + "']").remove();
    }
    else
        obj.attr('required', 'required');//obj.attr('required', 'required').before("<span id=" + id + " style='color:red'>*</span>");
}

function AddLabelToInput(frm) {
    //class='date'
    //$("input[class='date']").datepicker({
    //    dateFormat: "Rmmdd"
    //});
    var pickerOpts = {
        showOn: "button",
        //buttonImage: "/images/calendar.jpg"
        buttonText: "..."
    };
    $("input[class='date']").datepicker(pickerOpts).css("width", "100px");

    //設定間距
    //input
    //{
    //margin:5px;
    //-webkit-box-sizing: border-box; /* Safari/Chrome, other WebKit */
    //-moz-box-sizing: border-box;    /* Firefox, other Gecko */
    //box-sizing: border-box;         /* Opera/IE 8+ */
    //}
    $("input").css("margin", "5px").css("-webkit-box-sizing", "border-box").css("-moz-box-sizing", "border-box").css("box-sizing", "border-box");
    $("select").css("margin", "5px").css("-webkit-box-sizing", "border-box").css("-moz-box-sizing", "border-box").css("box-sizing", "border-box");
    $("textarea").css("margin", "5px").css("-webkit-box-sizing", "border-box").css("-moz-box-sizing", "border-box").css("box-sizing", "border-box");

    //設定table 為Screen寬度
    $("table ").css("display", "table").css("margin-right", "auto").css("margin-left", "auto").css("width", "100%");

    $('input[required = "required"],select[required = "required"]')
    .each(function (obj) {
        var attr = $(this).attr('required');
        var id = $(this).attr('id');
        if (typeof attr !== typeof undefined && attr !== false) {
            $(this).before("<span id=span_" + id + " style='color:red'>*</span>")
        }
    });

    var frmInput = $("input");
    frmInput.each(function (obj) {
        var attr = $(this).attr('title');
        var tpe = $(this).attr('type');
        if (tpe == "hidden")
            return;
        if (typeof attr !== typeof undefined && attr !== false) {
            if (attr.substr(0, 1) == "!") {
            }
            else {
                $(this).before("<span>" + attr + "</span>");
            }
        }
    });

    var frmSelect = $("select");
    frmSelect.each(function (obj) {
        var attr = $(this).attr('title');
        if (typeof attr !== typeof undefined && attr !== false) {
            if (attr.substr(0, 1) == "!") {
            }
            else {
                $(this).before("<span>" + attr + "</span>");
            }
        }
    });

    $("select[disabled=disabled]").css("background-color", "lightgray");

    $('input[Readonly = "Readonly"]').not(":button,:hidden").css("background-color", "transparent")
               .css("border", "0px").css("border-bottom", "1px dotted").before("[").after("]");

}


//-------------------Old Version Extend
function FillSelect(obj, HasNull, myarray, value, name, defaultVal) {
    obj.empty();
    if (HasNull == 0)
        obj.append("<option value=''>請選擇</option>");
    try {
        $.each(myarray, function (i, item) {
            if (defaultVal == item[value]) {
                obj.append('<option value="' + item[value] + '" selected="selected" >' + item[name] + '</option>');
            }
            else {
                obj.append('<option value="' + item[value] + '">' + item[name] + '</option>');
            }

        });
    }
    catch (ex) {
        alert(ex);
    }
}


function FillSelect_JsonString(obj, HasNull, strarray, value, name) {
    if (value == "")
        value = "value";
    if (name == "")
        name = "name";
    var P_Ownership = $.parseJSON(strarray);
    FillSelect(obj, HasNull, P_Ownership, value, name);
}

function Select_YN(obj, HasNull) {
    var vOwnership = '[{"name": "是","value": "Y"},{"name": "否","value": "N"}]';
    FillSelect_JsonString(obj, HasNull, vOwnership, "value", "name");
}


//August Lee note! Controller Function parameter must named as name for convenient   
function AU_autocomplete(obj, Url, P_value, P_Name, ObjValue, ObjLabel) {
    try {
        obj.autocomplete(
        {
            source: function (request, response) {
                $.ajax({
                    url: Url,
                    type: "POST",
                    dataType: "json",
                    data: { name: request.term },
                    success: function (data) {
                        response($.map(data, function (item) {
                            return { value: item[P_value], label: item[P_Name] };
                        }))

                    }
                    , error: function (message) {
                        alert(message);
                    }
                })
            },
            select: function (event, ui) {
                ObjValue.val(ui.item.value);
                ObjLabel.val(ui.item.label);
            }
        }
       );
    }
    catch (e) {
        alert(e);
    }
}

function getCheckBox_Select_Single(cbName) {
    var cb = $('input:radio:checked[name="' + cbName + '"]').val();
    //return cb.toString().replace("undefined","");
    if (cb == "undefined" | cb == null)
        return "";
    return cb;
}

function setRadioButton_ByValue(name, value) {
    $('input:radio[name="' + name + '"]').filter('[value="' + value + '"]').attr('checked', true);
}

function getSelect_value(id) {
    var cb = $('Select[id="' + id + '"]').val();
    return cb;
}


function getCTN(name) {
    var json = "";
    switch (name) {
        case "PropertyKind": //財產性質
            json = '[{"name": "公務用","value": "01"},{"name": "公共用","value": "02"},{"name": "事業用","value": "03"},{"name": "非公用","value": "04"}]';
            break;
        case "Cause": //增加原因
            json = '[{"name": "購置","value": "01"},{"name": "新建","value": "02"},' +
                    '{"name": "撥入","value": "03"},{"name": "捐贈","value": "04"},' +
                    '{"name": "投資","value": "05"},{"name": "孳生","value": "06"},' +
                    '{"name": "設定","value": "08"},{"name": "權利合併","value": "09"},' +
                    '{"name": "更正","value": "90"},{"name": "其他","value": "99"}' +
                    ']';
            break;
        case "Ownership":
            json = '[{ "DisplayText": "市有", "Value": 1 }, { "DisplayText": "國有", "Value": 2 }]'
        case "checkResult":
            json = '[{"name": "盤點正常","value": "1"},{"name": "盤點異常","value": "2"}]';
            break;
    }
    return json;
}

function ParseArrayToJson(array) {
    var msg = "";
    for (i = 0; i < array.length; i++) {
        msg += array[i];
        if (i != array.length - 1)
            msg += ";"
    }
    //msg += "]";
    return msg;
}

function NullAs(value, replace) {
    if (replace == "" | replace == null)
        replace = "";
    if (value == null | value == 'NULL')
        return replace;
    return value;
}

//-------------------------------------------
function Code_Data2(CodeName) {
    return "../UnitLand/Code_Data2?CodeKind=" + CodeName;
}

function Code_Data3(CodeName) {
    return "../UnitLand/Code_Data3?CodeKind=" + CodeName;
}

function FunctionCode_Select() {
    return "../EoFunctionCode/FunctionCode_Select";
}

function YN() {
    return { 'N': '否', 'Y': '是' };
}

var wid = 800; //Default Dialog width
var hei = 500; //Default Dialog height

function CQ_UmManage(ValueFiled, NameFiled, width, height) {
    CodeQuery(IsEmpty(height, hei), IsEmpty(width, wid), true, "../NpOccupy/UL_Manage_CodeQuery?" + "Id=" + ValueFiled, "管理資料輔助視窗");
}

function CQ_UmManageRent(ValueFiled, NameFiled, width, height) {
    CodeQuery(IsEmpty(height, hei), IsEmpty(width, wid), true, "../NpRent/UL_Manage_CodeQuery?" + "Id=" + ValueFiled, "管理資料輔助視窗");
}

function CQ_UlProperty(ValueFiled, NameFiled, width, height) {
    CodeQuery(IsEmpty(height, hei), IsEmpty(width, wid), true, "../NpOccupy/CodeQuery?" + "Value=" + ValueFiled + "&Name=" + NameFiled, "財產編號輔助視窗");
}

//function CQ_UnProperty(ValueFiled, NameFiled, width, height) {
//    CodeQuery(IsEmpty(height, hei), IsEmpty(width, wid), true, "../UnitNonExp/CodeQuery?" + "Value=" + ValueFiled + "&Name=" + NameFiled, "財產輔助視窗");
//}

//function CQ_UmProperty(ValueFiled, NameFiled, width, height) {
//    CodeQuery(IsEmpty(height, hei), IsEmpty(width, wid), true, "../UnitMovable/CodeQuery?" + "Value=" + ValueFiled + "&Name=" + NameFiled, "財產輔助視窗");
//}

//function CQ_SyOrgan(ValueFiled, NameFiled, width, height) {
//    CodeQuery(IsEmpty(height, hei), IsEmpty(width, wid), true, "../SyOrgan/CodeQuery?" + "Value=" + ValueFiled + "&Name=" + NameFiled, "機關輔助視窗");
//}

function CQ_SyOrgan_Multi(ValueFiled, NameFiled, width, height) {
    //CodeQuery(IsEmpty(height, hei), IsEmpty(width, wid), true, "/SyOrgan/CodeQuery?" + "Value=" + ValueFiled + "&Name=" + NameFiled, "機關輔助視窗");
    CodeQuery(IsEmpty(height, hei), IsEmpty(width, wid), true, "../SyOrgan/CodeQuery_Multi?" + "Value=" + ValueFiled + "&Name=" + NameFiled, "機關輔助視窗");
}

function CQ_SyPropertyCode_Multi(ValueFiled, NameFiled, width, height, kind) {
    CodeQuery(IsEmpty(height, hei), IsEmpty(width, wid), true, "../SyPropertyCode/CodeQuery_Multi?" + "Value=" + ValueFiled + "&Name=" + NameFiled + "&Q_PropertyKind=" + kind, "財產編號輔助視窗");
}

function CQ_EoDepartment_Multi(ValueFiled, NameFiled, width, height) {
    CodeQuery(IsEmpty(height, hei), IsEmpty(width, wid), true, "../EoDepartment/CodeQuery_Multi?" + "Value=" + ValueFiled + "&Name=" + NameFiled, "群組輔助視窗");
}

function CQ_SyControlItem(ValueFiled, NameFiled, width, height) {
    CodeQuery(IsEmpty(height, hei), IsEmpty(width, wid), true, "../PbMonitor/CodeQuery?" + "Value=" + ValueFiled + "&Name=" + NameFiled, "機關輔助視窗");
}

//function CQ_SyProperty(ValueFiled, NameFiled, width, height) {
//    CodeQuery(IsEmpty(height, hei), IsEmpty(width, wid), true, "../SyPropertyCode/CodeQuery?" + "Value=" + ValueFiled + "&Name=" + NameFiled, "財產輔助視窗");
//}

//function CQ_SyCode(ValueFiled, NameFiled, width, height, CodeKind) {
//    CodeQuery(IsEmpty(height, hei), IsEmpty(width, wid), true, "../SyCode/CodeQuery?" + "Value=" + ValueFiled + "&Name=" + NameFiled + "&CodeKind=" + CodeKind, "機關輔助視窗");
//}

function CQ_BulletinDate(BulletinKind, width, height) {
    CodeQuery(IsEmpty(height, hei), IsEmpty(width, wid), true, "../UnitLand/BulletinDate?BulletinKind=" + BulletinKind, "公告年月輔助視窗");
}

//function CQ_UmStore(ValueFiled, NameFiled, width, height) {
//    CodeQuery(IsEmpty(height, hei), IsEmpty(width, wid), true, "../UmStore/CodeQuery?" + "Value=" + ValueFiled + "&Name=" + NameFiled, "廠商輔助視窗");
//}

//function CQ_MenuPerm(ValueFiled, NameFiled, width, height, TargetKind) {
//    var val = getCheckBox_Select_Single(TargetKind);
//    switch (val) {
//        case "A":
//            CodeQuery(IsEmpty(height, hei), IsEmpty(width, wid), true, "../EoEmployee/CodeQuery?" + "Value=" + ValueFiled + "&Name=" + NameFiled, "人員-輔助視窗");
//            break;
//            //case "B":
//            //    CodeQuery(IsEmpty(height, hei), IsEmpty(width, wid), true, "../EoDepartment/CodeQuery?" + "Value=" + ValueFiled + "&Name=" + NameFiled, "部門/群組-輔助視窗");
//            //    break;
//        case "C":
//            CodeQuery(IsEmpty(height, hei), IsEmpty(width, wid), true, "../EoDepartment/CodeQuery?" + "Value=" + ValueFiled + "&Name=" + NameFiled, "部門/群組-輔助視窗");
//            break;
//        default:
//            CodeQuery(IsEmpty(height, hei), IsEmpty(width, wid), true, "../EoDepartment/CodeQuery?" + "Value=" + ValueFiled + "&Name=" + NameFiled, "部門/群組-輔助視窗");
//            break;
//    }
//}

function IsEmpty(parm, defaults) {
    if (parm == null)
        return defaults;
    if (parm == "")
        return defaults;
    if (parm == 0)
        return defaults;
    return parm;
}

function OnCheck(input, hidden) {
    var attr = $("#" + input).is(':checked');
    if (typeof attr !== typeof undefined && attr !== false) {
        $("#" + hidden).val("Y");
    }
    else
        $("#" + hidden).val("N");
}

function ClearField(ValueF, NameF) {
    $("#" + ValueF).val("");
    $("#" + NameF).val("");
    //for UME031Edit
    var PropertyCodeId = $("#UMMT_PropertyCodeId");
    if (PropertyCodeId[0]) {
        PropertyCodeId.val("");
    }
}

//Form to JsonObject
function ToJsonObject(frm) {
    var jsonData = {};
    $("input[type!='radio']").each(function (obj) {
        var attr = $(this).attr('name');
        if (typeof attr !== typeof undefined && attr !== false) {
            jsonData[attr] = $(this).val();
        }
        else {
            jsonData[$(this).attr('id')] = $(this).val();
        }
    });
    $('input:radio:checked').each(function (obj) {
        var attr = $(this).attr('name');
        if (typeof attr !== typeof undefined && attr !== false) {
            jsonData[attr] = $(this).val();
        }
        else {
            jsonData[$(this).attr('id')] = $(this).val();
        }
    });
    $('select').each(function (obj) {
        var attr = $(this).attr('name');
        if (typeof attr !== typeof undefined && attr !== false) {
            jsonData[attr] = $(this).val();
        }
        else {
            jsonData[$(this).attr('id')] = $(this).val();
        }
    });
    $("textarea").each(function (obj) {
        var attr = $(this).attr('name');
        if (typeof attr !== typeof undefined && attr !== false) {
            jsonData[attr] = $(this).val();
        }
        else {
            jsonData[$(this).attr('id')] = $(this).val();
        }
    });
    return jsonData;
}

function IsEmpty(val) {
    if (val == typeof undefined)
        return "";
    if (val == null)
        return "";
    return val;
}

//*********************************************
//函數功能：某一日期加上一定期間的日或月或年
//參　　數：strType可以是d(Day),m(Month),y(Year); sNum數值; objDate為日期物件或日期
//傳 回 值：傳回加上特定期間之後的日期
//*********************************************
function getDateAdd(sType, sNum, objDate) {
    var sdate, rdate;
    var myYear, myMonth, myDay;
    var intNumber;
    var sNumber;
    var intYear, intMon, intDay;
    var strType;

    if (isObj(sType.value)) strType = parse(sType.value);
    strType = parse(sType);

    if (isObj(sNum.value)) sNumber = parse(sNum.value);
    else sNumber = sNum;

    if (isObj(objDate.value)) sdate = parse(objDate.value);
    else sdate = parse(objDate);

    if (sNumber == "") sNumber = 0;
    if (isNaN(sNumber)) intNumber = 0;
    else intNumber = parseInt(sNumber, 10);

    if (sdate.length == 7 && strType.length > 0) {
        intYear = parseInt(sdate.substring(0, 3), 10) + 1911;
        intMon = parseInt(sdate.substring(3, 5), 10) - 1;
        intDay = parseInt(sdate.substring(5, 7), 10);
        if (strType == "d") {
            rdate = new Date(intYear, intMon, intDay + intNumber);
        } else if (strType == "m") {
            rdate = new Date(intYear, intMon + intNumber, intDay);
        } else if (strType == "y") {
            rdate = new Date(intYear + intNumber, intMon, intDay);
        }
        //the bullshit js trancate 19xx to xx
        if (rdate.getYear() < 2000) myYear = (rdate.getYear() - 11).toString()
        else myYear = (rdate.getYear() - 1911).toString();
        //myYear = (rdate.getYear()-1911).toString();
        myMonth = (rdate.getMonth() + 1).toString();
        myDay = rdate.getDate().toString();

        if (myYear.length <= 2) { myYear = "0" + myYear; }
        if (myMonth.length <= 1) { myMonth = "0" + myMonth; }
        if (myDay.length <= 1) { myDay = "0" + myDay; }
        myToday = myYear + myMonth + myDay;
        return myToday;

    } else {
        return "";
    }
}

function checkEmpty(obj, name) {
    var msg = "";
    if (obj.val().toString().trim() == "") {
        msg += "[" + name + "]不可為空!"
    }
    return msg;
}

function OpenWindowLoadCaseNo() {
    $("#Q_CaseNoFrom").val("@Model.UNA_CaseNo");
    $("#Q_CaseNoTo").val("@Model.UNA_CaseNo");
}

//Object.prototype.value = function () {
//    return this.value;
//}

String.prototype.trim = function () {
    return this.replace(/^\s+|\s+$/g, "");
}
String.prototype.ltrim = function () {
    return this.replace(/^\s+/, "");
}
String.prototype.rtrim = function () {
    return this.replace(/\s+$/, "");
}

String.prototype.IsNullOrEmpty = function () {
    //return this.replace(/\s+$/, "");
    return this === "undefined" ? "" : this;
}


//August Lee 2015/04/01 add 
jQuery.fn.extend({
    //開啟Item View
    ItemView: function (url, autosize) {
        try {
            autosize = typeof autosize !== 'undefined' ? autosize : true;
            $(this).html(url);
            if (autosize) {
                jQuery(function ($) {
                    var lastHeight = 0, curHeight = 0, $frame = $(this).find("iframe:eq(0)");//$('iframe:eq(0)');
                    setInterval(function () {
                        curHeight = $frame.contents().find('body').height();
                        if (curHeight != lastHeight) {
                            $frame.css('height', (lastHeight = curHeight) + 'px');
                        }
                    }, 500);
                });
            }
        }
        catch (e) {
            //alert(e);
        }
    },
    ReadOnly: function (readonly, clear) {
        var obj = $(this);
        if (obj.is("text") | obj.is("textarea") | obj.is("password")) {
            if (readonly)
                ReadOnly(obj, true)
            else
                ReadOnly(obj, false)
        }
        else {
            if (readonly)
                Disabled(obj, true)
            else
                Disabled(obj, false)
        }
        if (clear) {
            obj.val("");
        }

        if (!readonly) //要啟用
            obj.removeAttr('disabled').css("background-color", "white");
        else {
            obj.css("background-color", "lightgray");
        }
    },
    Required: function (required, clear) {
        var obj = $(this);
        if (required)
            Required(obj, true, clear)
        else
            Required(obj, false, clear)
    },
    Disabled: function (disable) {
        var obj = $(this);
        Disabled(obj, disable, false);
    },
    Hide: function () {
        var obj = $(this);
        obj.css("display", "none");

        var id = $(this).attr('id');
        var span = $("span[id='span_" + id + "']");
        if (span != null)
            span.css("display", "none");
    },
    Show: function () {
        var obj = $(this);
        obj.css("display", "");
        var id = $(this).attr('id');

        var span = $("span[id='span_" + id + "']");
        if (span != null)
            span.css("display", "");
    },
    Replace: function (newtitle) {
        var id = $(this).attr('id');
        var span = $("span[id='span_" + id + "']");//.remove();
        $(this).attr('title', newtitle);
        if(span!=null)
            span.text(newtitle);
        //var title = span.attr('title');
        //if (typeof title !== typeof undefined && title !== false) {
        //    title = newtitle;
        //} 
    },
    Title: function () {
        var title = $(this).attr('title');
        if (typeof attr !== typeof undefined && attr !== false) {
            return title;
        }
        return "";
    },
    ErorBg: function () { //物件背景變色-Error
        $(this).css("background-color", Required_BackGround_Color);
    },
    DisErorBg: function () { //物件背景變白色-Non Error
        $(this).css("background-color", "white");
    },
    DialogModal: function (yn, title, heights, weights) {
        var P_title = "";
        if (title != "" && title != null) {
            P_title = title;
        }
        if (heights != "" && heights != null) {
            $(this).dialog({
                //closeOnEscape: false,
                //open: function (event, ui) { $(".ui-dialog-titlebar-close").hide(); },
                modal: yn,
                title:P_title,
                height: heights,
                width: weights
            });
        }
        else {
            $(this).dialog({
                modal: yn,
                title: P_title
            });
        }
    },
    CloseDialog: function () {
        $(this).dialog("close");
    },
    GetSelectRow: function () {
        var id = $(this).attr('id');
        return getSelectRow(id);
    },
    GetAllSelectRows: function () {
        var $selectedRows = $(this).jtable('selectedRows');
        return $selectedRows;
    },
    HasSelectRow: function () {
        var $selectedRows = $(this).jtable('selectedRows');
        return ($selectedRows.length > 0);
    },
    GetRows: function () {
        try {
            return $(this).find('tr.jtable-data-row');
        }
        catch (e) {
            alert(e);
            return null;
        }
    },
    GetRowCount: function () {
        try
        {
            return $(this).find('tr.jtable-data-row').length;
        }
        catch (e) {
            alert(e);
            return 0;
        }
    },
    RemoveAllRows: function () {
        var id = $(this).attr('id');
        $("#"+id+" tbody>tr").remove();
    },
    JTableButtonSetting: function (Verify,list) {
         if (Verify == "Y") {
            Jtable_Toolbar_ByName($(this), true, "新增");
            Jtable_Toolbar_ByName($(this), true, "複製");
            if (list != null & list!="") {
                var ar = list.split(",");
                for (i = 0;i<ar.length;i++)
                    Jtable_Toolbar_ByName($(this), true, ar[i]);
            }
        }
        else {
            Jtable_Toolbar_ByName($(this), false, "新增");
            Jtable_Toolbar_ByName($(this), false, "複製");
            if (list != null & list != "") {
                var ar = list.split(",");
                for (i = 0; i < ar.length; i++)
                    Jtable_Toolbar_ByName($(this), false, ar[i]);
            }
        }
    },
    SelectText: function () {
        var id = $(this).attr('id');
        return $("#"+id+" option:selected").text();
    },
    UpdateRecord: function (data, clientOnly) {
        var client = true;
        if (clientOnly == false)
            client = false;
        
        for (i = 0; i < data.length; i++) {
            $(this).jtable('updateRecord', {
                record: data[i]
                , clientOnly: client
            });
        }
    },
    AddRecord: function (data) {
        for (i = 0; i < data.length; i++) {
            $(this).jtable('addRecord', {
                record: data[i]
                , clientOnly: true
            });
        }
    },
    DeleteRecord: function (ids, clientOnly) {
        var client = true;
        if (clientOnly == false)
            client = false;
        for (i = 0; i < ids.length; i++) {
            $(this).jtable('deleteRecord', {
                key: ids[i]
                , clientOnly: client
            });
        }
    },
    DeleteSelectRows: function () {
        var tb = $(this);
        var $selectedRows = tb.jtable('selectedRows');
        $selectedRows.each(function () {
            var Pkey = $(this).data("record-key").toString();
            tb.jtable('deleteRecord', {
                key: Pkey,
                clientOnly: true,
                //animationsEnabled: true,
                success: function () {
                },
                error: function () {
                }
            });
        });

        //下列寫法一定要返回server
        //$(this).jtable('deleteRows', { rows: $selectedRows , clientOnly:true });
    },
    ReLoad:function(){
        $(this).jtable('reload');
    },
    DOM: function () {
        var id = $(this).attr('id');
        return document.getElementById(id);
    },
    IsChecked: function () {
        return $(this).is(":checked") ? true : false;
    },
    serializeAll : function () {
        //將畫面上所有input,select,textarea序號化，包含diaabled的項目
        var obj = {};
        $('input', this).each(function () {
            if (this.name == '')
                return;
            var iptType = $(this).attr('type');
            if (iptType == 'button')
                return;
            if (iptType == 'radio')
                return;
            obj[this.name] = $(this).val(); 
        });
        $('input:radio:checked', this).each(function () {
            if (this.name == '')
                return;
            obj[this.name] = $(this).val(); 
        });
        $('input:checkbox', this).each(function () {
            if (this.name == '')
                return;

            var checked = $(this).prop('checked');
            var v1 = $(this).attr('data-checked');
            var v2 = $(this).attr('data-unchecked');
            //alert("v1:" + v1 + ",v2:" + v2);
            if (checked) {
                obj[this.name] = (v1 == undefined || v1 == null) ? "Y" : v1;
            } else {
                obj[this.name] = (v2 == undefined || v2 == null) ? "N" : v2;
            }
        });
        $('select', this).each(function () {
            if (this.name == '')
                return;
            obj[this.name] = $(this).val(); 
        });
        $('textarea', this).each(function () {
            if (this.name == '')
                return;
            obj[this.name] = $(this).val(); 
        });
        return $.param(obj);
    }
});

function GetListGrid(id) {
    if (id != "" && id != null)
        return $("#" + id);
    else
        return $("#ListGridContainer");
}
function showPlaseWait() {
    pleaseWaitDiv.dialog({
        closeOnEscape: false,
        open: function (event, ui) { $(".ui-dialog-titlebar-close").hide(); },
        modal: true
    });
}
function closePlaseWait() {
    pleaseWaitDiv.dialog("close");
}

//process bar
var pleaseWaitDiv = $('<div class="modal hide" id="pleaseWaitDialog" data-backdrop="static" data-keyboard="false"><div class="modal-header"><h1>Processing...</h1></div><div class="modal-body"><div class="progress progress-striped active"><div class="bar" style="width: 100%;"></div></div></div></div>');


function PrepareUI() {
    var pickerOpts = {
        showOn: "button",
        buttonImage: "/images/calendar.png",
        buttonText: "..."
    };
    $("input[class='date']").each(function (obj) {
        var readOnly = $(this).attr('readonly');
        if (!readOnly || readOnly !== "readonly") {
            $(this).datepicker(pickerOpts);
        }
        $(this).css("width", "100px").attr("maxlength", "7");
    });
    $("input[class='nkfcp-orgid']").each(function (obj) {
        $(this).css("width", "120px").attr("maxlength", "10");
    });
    $("input[class='nkfcp-organame']").each(function (obj) {
        $(this).css("width", "250px");
    });
    $("input[class='nkfcp-orgsname']").each(function (obj) {
        $(this).css("width", "150px");
    });
    $("input[class='nkfcp-caseno']").each(function (obj) {
        $(this).css("width", "120px").attr("maxlength", "10");
    });
    $("input[class='nkfcp-propno']").each(function (obj) {
        $(this).css("width", "120px").attr("maxlength", "15");
    });
    $("input[class='nkfcp-proplot']").each(function (obj) {
        $(this).css("width", "100px").attr("maxlength", "7");
    });
    $("input[class='nkfcp-propserial']").each(function (obj) {
        $(this).css("width", "100px").attr("maxlength", "7");
    });
    $("input[class='nkfcp-proofdoc']").each(function (obj) {
        $(this).css("width", "100px");
    });
    $("input[class='nkfcp-proofno']").each(function (obj) {
        $(this).css("width", "120px").attr("maxlength", "10");
    });

    //$("input").css("margin", "3px").css("-webkit-box-sizing", "border-box").css("-moz-box-sizing", "border-box").css("box-sizing", "border-box");
    //$("select").css("margin", "3px").css("-webkit-box-sizing", "border-box").css("-moz-box-sizing", "border-box").css("box-sizing", "border-box");
    //$("textarea").css("margin", "3px").css("-webkit-box-sizing", "border-box").css("-moz-box-sizing", "border-box").css("box-sizing", "border-box");

    //修正CodeQuery樣式 margin & padding
    $("span.code-query-widget").css("padding", "0px 0px 0px 0px");
    $("span.code-query-widget input").css("margin", "1px 1px 1px 1px");

    //設定table 為Screen寬度
    $("table ").css("display", "table").css("margin-right", "auto").css("margin-left", "auto").css("width", "100%");

    //設定字型
    //$("input").css("margin", "3px 3px 3px 3px").css("font-size", "1.1em");
    //$("select").css("margin", "3px 3px 3px 3px").css("font-size", "1.1em").css("width", "auto");
    //$("span").css("margin", "3px 3px 3px 3px").css("font-size", "1.1em").css("width", "auto");

    //$("input, select, textarea")
    //必填欄位
    $('input[required = "required"], select[required = "required"], textarea[required = "required"]')
    .each(function (obj) {
        var attr = $(this).attr('required');
        var id = $(this).attr('id');
        if (typeof attr !== typeof undefined && attr !== false) {
            $(this).before("<span id=span_" + id + " style='color:red'>*</span>")
        }
        //else {
        //    $(this).before("<span id=span_" + id + ">&nbsp;</span>")
        //}
    });

    //標題-input
    var frmInput = $("input,textarea");
    frmInput.each(function (obj) {
        var attr = $(this).attr('title');
        var tpe = $(this).attr('type');
        var id = $(this).attr('id');
        if (tpe == "hidden")
            return;
        if (typeof attr !== typeof undefined && attr !== false) {
            if (attr.substr(0, 1) == "!") {
            }
            else {
                $(this).before("<span id='span_" + id + "' style='vertical-align:top;'>" + attr + "</span>");
            }
        }
    });

    //標題-select
    var frmSelect = $("select");
    frmSelect.each(function (obj) {
        var attr = $(this).attr('title');
        if (typeof attr !== typeof undefined && attr !== false) {
            if (attr.substr(0, 1) == "!") {
            }
            else {
                $(this).before("<span style='vertical-align:top;'>" + attr + "</span>");
            }
        }

        var readOnly = $(this).attr('readonly');
        if (readOnly) {
            if (readOnly == "readonly") {
                Disabled($(this), true, false);
            } else {
                Disabled($(this), false, false);
            }
        }
    });

    $("select[disabled=disabled]").css("background-color", "lightgray");

    $('input[Readonly = "Readonly"]').css("background-color", "transparent")
               .css("border", "0px").css("border-bottom", "1px dotted").before("[").after("]");
}

//註冊事件
function registerEvents() {
    //CodeQuery 回傳值事件
    var cqResults = $('input[data-cqresult="default"],input[id="CQ_Result"]');
    $.each(cqResults, function (i, obj) {
        $(this).on('change', function () {
            var attrCQResult = $(this).attr('data-cqresult');
            //有設定data-cqresult但值非deault，表示使用者自訂處理函式
            if (attrCQResult && attrCQResult != "" && attrCQResult != "default") {
                return;
            }
            //取得回傳的資料(JSON String)
            var jsonString = $(this).val();
            if (!jsonString || jsonString == "")
                return;

            //解析回傳的資料(JSON String --> JSON Object)
            var returnObj = JSON.parse(jsonString, function (key, value) {
                var type;
                if (value && typeof value === 'object') {
                    type = value.type;
                    if (typeof type === 'string' && typeof window[type] === 'function') {
                        return new (window[type])(value);
                    }
                }
                return value;
            });
            //更新相關欄位
            updateCodeQueryResult(returnObj.RequestKey, returnObj.Row);
        });
    });
}

//更新 CodeQuery 欄位
function updateCodeQueryResult(groupName, item) {
    //取出同群組欄位
    $('input[data-cqgroup="' + groupName + '"],select[data-cqgroup="' + groupName + '"],textarea[data-cqgroup="' + groupName + '"]')
    .each(function (obj) {
        //取得參照的資料來源欄位
        var fld = $(this).attr('data-cqfield');
        if (fld) {
            $(this).val(item[fld]).change();
        }
    });
}

//清空群組欄位(ex.CodeQuery fields)
function clearGroupFileds(groupName) {
    //取出同群組欄位
    $('input[data-cqgroup="' + groupName + '"],select[data-cqgroup = "' + groupName + '"],textarea[data-cqgroup="' + groupName + '"]')
    .each(function (obj) {
        //清空欄位
        $(this).val("").change();
    });
}


Storage.prototype.setArray = function (key, obj) {
    return this.setItem(key, JSON.stringify(obj))
}
Storage.prototype.getArray = function (key) {
    return JSON.parse(this.getItem(key))
}

Array.prototype.add = function (obj) {
    this.push(obj);
}

Array.prototype.remove = function (obj) {
    var index = this.indexOf(str);
    if (index > -1) {
        this.splice(index, 1);
    }
}

function AU_Add(obj) {

    var ar = localStorage.getArray("array");
    var count = 0;
    if (ar == null) {
        ar = new Array();
    }
    else {
    }
    ar.push(obj);
    localStorage.setArray("array", ar);
    localStorage.setArray("length", count);
}

function getToday(dateFormate) {
    var now = new Date();
    //var year = now.getFullYear();
    //var month = now.getMonth() + 1;
    //var day = now.getDate();
    var today = now.format(dateFormate);
    //return year + "-" + month + "-" + day;
    return today;
}

//August Lee add 2015/6/17
//function DateAdd_TW(yyyMMdd, addY) {
//    var actualDate = new Date(dateText);
//    var newDate = new Date(actualDate.getFullYear(), actualDate.getMonth(), actualDate.getDate() + 1);
//}

//減去指定年，如20141104減去2年，變成20121104  
function minusYears(date, year) {
    return date.addYears(0 - parseInt(year), true).toString('yyyyMMdd');
}

function DateAdd(timeU, byMany, dateObj) {
    var millisecond = 1;
    var second = millisecond * 1000;
    var minute = second * 60;
    var hour = minute * 60;
    var day = hour * 24;
    var year = day * 365;

    var newDate;
    var dVal = dateObj.valueOf();
    switch (timeU) {
        case "ms": newDate = new Date(dVal + millisecond * byMany); break;
        case "s": newDate = new Date(dVal + second * byMany); break;
        case "mi": newDate = new Date(dVal + minute * byMany); break;
        case "h": newDate = new Date(dVal + hour * byMany); break;
        case "d": newDate = new Date(dVal + day * byMany); break;
        case "y": newDate = new Date(dVal + year * byMany); break;
    }
    return newDate;
}

function getTWDate_date(str) {
    if (str.length != 7)
        return "";
    else {
        var y = str.substr(0, 3);
        var m = str.substr(3, 2);
        var d = str.substr(5, 2);
        return new Date((parseInt(y) + 1911).toString(), m.toString(), d.toString());
        //return new Date(str + 19110000);
    }
}

function getTWDate_str(d) {
    return d.getFullYear()-1911 + '/' + (d.getMonth() + 1) + '/' + (d.getDate() + 1);
}
Date.prototype.dateAdd = function (timeU, byMany) {
    return DateAdd(timeU, byMany, this);
}

function roundX(val, precision) {
    //理論上版本
    var precision = precision || 0; //預設0位數
    var a = val * Math.pow(10, precision); //320007.5
    var b = Math.round(a); //320008
    var c = b / Math.pow(10, precision); //32.0008
    //return c;
    //理論版濃縮
    //return Math.round(val * Math.pow(10, (precision || 0))) / Math.pow(10, (precision || 0));
    //修正誤差版本。但因為浮點計算產生的誤差，會導致結果錯誤
    //例如32.00075*1000會是320007.49999999994，而不是預期的320007.5  
    var precision = precision || 0; //預設0位數
    var a = val * Math.pow(10, precision + 1); //3200074.9999999995
    var b = Math.round(a) / 10; //320007.5
    var c = Math.round(b); //320008
    var d = c / Math.pow(10, precision); //32.0008
    //return d;
    //修正版縮濃
    return Math.round(Math.round(val * Math.pow(10, (precision || 0) + 1)) / 10) / Math.pow(10, (precision || 0));
}

//設定畫面ReadOnly 
function setViewMode(yn) {
    //yn  true/false
    $("#frm :input").prop("disabled", yn);
}

function ShowMessage(message, closeHandler) {
    message = message.replace(/\r\n/g, '<br />').replace(/\r/g, '<br />').replace(/\n/g, '<br />').replace(/\&lt;br \/&gt;/g, '<br />');
    alertify.alert(message);
    if (typeof closeHandler == "function")
        closeHandler();
}

//
function getSelectRow(obj) {
    var Selrow="";
    var $selectedRows = $('#' + obj).jtable('selectedRows');
    if ($selectedRows.length > 0) {
        $selectedRows.each(function () {
            var record = $(this).data('record');
            Selrow = record;
        });
    };
    return Selrow;
}

function getRowCount(obj) {
    return $("#" + obj).find('tr.jtable-data-row').length;
}

//$.ajaxSetup({
//    beforeSend: function () {
//        // show gif here, eg:
//        $("#loading").show();
//    },
//    complete: function () {
//        // hide gif here, eg:
//        $("#loading").hide();
//    }
//});

function ConfirmMessage(message, callback) {
    alertify.confirm(message, function (e) {
        if (e) {
            if (typeof callback == "function") callback();
        } else {
            //alertify.log('你按下了 cancel');
        }
    });
}

function showLoading() {
    $("#loading").show();
}

function hideLoading() {
    $("#loading").hide();
}
//________________________________________舊Function.js___________________________________________

//*********************************************
//函數功能：去除逗號 
//eg. 100,999.99 --> 100999.99
//eg. 一千,兩佰 --> 一仟兩佰
//*********************************************
function deleteCommas(obj) {
    var str = "";
    var flag = false;
    if (isObj(obj.value)) {
        str = obj.value;
        flag = true;
    } else str = obj;

    var rStr = "";
    var ch;
    if (str != null && str != "" && str.length > 0) {
        for (var i = 0; i < str.length; i++) {
            ch = str.charAt(i);
            if (ch != ",") rStr += str.charAt(i);
        }
    }
    if (flag) obj.value = rStr;
    else return rStr;
}

//*********************************************
//程式功能：判斷物件是否正確
//*********************************************
function isObj(obj) {
    return (!((obj == null) || (obj == undefined)));
}

//Edit View 不可維護
function Edit_Disabled(canSave) {
    ReadOnly($("input,select,textarea").not(':button,:hidden,[data-ctrl="N"]'), true, false);
    Disabled($("input[type='button']").not('[data-ctrl="N"]'), true, false);
    Disabled($("button[type='button']").not('[data-ctrl="N"]'), true, false);
    DialogButtonDisabled("繼續新增");
    if (canSave != true){
        canSave = false;
    }
    if (!canSave) {
        DialogButtonDisabled("儲存");
    }
    //$("input[class='date']").datepicker("disable");
    ReadOnly($('.hasDatepicker[data-ctrl="N"]'), false);
}

//August Lee 2015/08/15
//
var PO_Prefix = "";
function _(name,prefix)
{
    prefix == null && (prefix = PO_Prefix);
    var meta = $('input,select,textarea').filter(function() {
        return this.name.toLowerCase() == (prefix+"_"+name).toLowerCase();
    });
    return (meta.length == 0 ? null : $("#" + meta[0].id));//return (meta.length == 0 ? null:meta[0]);
}

function roundp(v, dp, isUp) {
    if (v != null && v != "") {
        v = "" + v;
        if (v.indexOf('.') != -1) {
            if (v.substr(0, v.indexOf(".")) == "") {
                v = "0" + v;
            }
        }
    }
    var v1, v2, sdp = "", dp1;
    var sh = Math.pow(10, dp);
    if (!isNaN(parseInt(v))) {
        v = "" + v;
        sdp = ("" + sh).substr(1);
        if (v.indexOf('.') == -1) {
            if (dp > 0) v = v + '.' + sdp;
        } else {
            v1 = v.substr(0, v.indexOf(".")); //整數部分
            v2 = v.substr(v1.length + 1, v.length); //小數部分 
            if (isUp != "Y") {
                v = v1 + "." + (v2 + sdp).substr(0, dp);
            } else {
                v2 = "0." + v2;
                dp1 = "" + (Math.round(v2 * sh) / sh);
                if ((Math.round(v2 * sh)) == sh) {
                    v1 = parseInt(v1) + 1 + "";
                }
                if (dp1.indexOf('.') == -1) {
                    v = v1 + '.' + sdp;
                } else {
                    var dp1ln = dp1.substring(dp1.indexOf('.') + 1, dp1.length).length;
                    if (dp1ln < dp) {
                        sdp = "";
                        for (var i = dp1ln ; i < dp ; i++) sdp = sdp + "0";
                        dp1 = dp1 + sdp;
                    }
                    v = v1 + '.' + dp1.substr(2);
                }
            }
        }
        return v;
    }
    return "";
}

//format null :1031231  D: 2014/01/01
//parm Y: Year 
function DateTime(format,parm) {
    var today = new Date();
    var dd = today.getDate();
    var mm = today.getMonth() + 1; //January is 0!

    var yyyy = "";
    if (format == "D")
        yyyy =today.getFullYear();
    else
        yyyy=parseInt(today.getFullYear() - 1911).toString();
    if (dd < 10) {
        dd = '0' + dd
    }
    if (mm < 10) {
        mm = '0' + mm
    }
    if (parm == "Y")
        return yyyy;
    if (parm == "M")
        return mm;
    if (parm == "D")
        return dd;
    var today = "";
    if (format == "D")
        today =yyyy + '/' + mm + '/' + dd;
    else
        today = yyyy + mm + dd;
    return today;
}

function notifyMessage(msg, isError) {
    if (isError) {
        alertify.error(msg);
    } else {
        alertify.success(msg);
    }
}
