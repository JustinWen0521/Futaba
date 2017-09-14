//August Lee 2014/11/21 CopyRight

//按鈕事件
var TabFireListener = new Object();
//現在tab名稱
var currentpage = "";
// 預設顯示第一個 Tab
var _showTab = 0;
//切換tab的Url
var _clickTab = "";
//切換權限字串
var ls_changeSeq = new Array();
//現在tab的index
var currentpageIndex = 0;
var pages = new Array();
//訊息
var showMsg = "尚有其它步驟尚未完成，請先完成其它步驟內容!";
//$(function ()
var FireEvent = true;
function TabControl()
{
        var $defaultLi = $('ul.tabs li').eq(_showTab).addClass('active');
        $($defaultLi.find('a').attr('href')).siblings().hide();
        
        //init 將頁面順序寫入陣列
        init();
        
        // 當 li 頁籤被點擊時...
        // 若要改成滑鼠移到 li 頁籤就切換時, 把 click 改成 mouseover
        $('ul.tabs li').click(function () {
            // 找出 li 中的超連結 href(#id)
            var $this = $(this);
	        _clickTab = $this.find('a').attr('href');

            // 把目前點擊到的 li 頁籤加上 .active
            // 並把兄弟元素中有 .active 的都移除 class

            var value = TabFireListener.whatButtonFireEvent(_clickTab);
            if (!value) {
                //alert('state disable');
                return false;
            }

            //檢查是否可以切換頁面
            var IsChangeOK = IsChangeAble(currentpage, _clickTab);
            if (!IsChangeOK) {
                alert(showMsg);
                return false;
            }

            currentpage = _clickTab;
            $this.addClass('active').siblings('.active').removeClass('active');
            // 淡入相對應的內容並隱藏兄弟元素
            $(_clickTab).stop(false, true).fadeIn().siblings().hide();

            return false;
        }).find('a').focus(function () {
            this.blur();
        });
}

function initTabs(tabs) {
    tabs.on("tabsbeforeactivate", function (event, ui) {
        //alert(ui.newPanel.attr('id'));
        //alert(ui.newPanel.index());

        //if (event.altKey && event.keyCode === $.ui.keyCode.BACKSPACE) {
        //    var panelId = tabs.find(".ui-tabs-active").remove().attr("aria-controls");
        //    $("#" + panelId).remove();
        //    tabs.tabs("refresh");
        //}

        //setDisable(tabs, ui);
        if (FireEvent) {
            FireEvent = true;
            //檢查是否可以切換頁面
            var IsChangeOK = IsChangeAble(ui);
            if (!IsChangeOK) {
                alert(showMsg);
                return false;
            }
            var value = TabFireListener.whatButtonFireEvent(ui);
            if (!value) {
                //alert('state disable');
                return false;
            }
        }
        FireEvent = true;
        currentpageIndex = getSelectIndex(ui);
    });
    return TabFireListener;
}

//取得目前頁面id
function getCurrentPage(ui) {
    return ui.oldPanel.attr("id");
}

//取得切換頁面id
function getSelectPage(ui) {
    return ui.newPanel.attr("id");
}

//頁面切換順序放入陣列
function changeSeq(Seq) {
    ls_changeSeq = Seq.toString().split(';');
}

//取得目前頁面index  --> 減1會從0起始
function getCurrentIndex(ui) {
    return ui.oldPanel.index()-1;
}

//取得切換頁面之index  --> 減1會從0起始
function getSelectIndex(ui) {
    return ui.newPanel.index()-1;
}


//回傳陣列
function NextEnablePageIndex(ui) {
    return ls_changeSeq[getCurrentIndex(ui)].split(',');
}

function IsChangeAble(ui) {
    if (ls_changeSeq.length==0) //沒設定順序就全部都可以隨意切換
        return true;
    var NowPageIndex = getCurrentIndex(ui);
    var NextPageIndex = getSelectIndex(ui);
    var ls_NextPageEnable = NextEnablePageIndex(ui);
    for (i = 0; i < ls_NextPageEnable.length; i++)
        if (ls_NextPageEnable[i].toString() == NextPageIndex)
            return true;
    return false;
}

TabFireListener.whatButtonFireEvent = function (buttonName) {
   // do nothing,for override.
}

TabFireListener.init = function () {

};

//強制切換頁面
function switchpage(tabs,pageindex) {
    tabs.tabs({ active: pageindex });
}

//function EnableTabsAll(tabs, list) {
//    tabs.tabs("option", "enabled", list);
//}

function EnableTabs(tabs, index) {
    tabs.tabs("enable", index);
}

function DisableTabs(tabs) {
    tabs.tabs("disable");
}

function setDisable(tabs, ui) {
    DisableTabs(tabs);
    EnableTabs(tabs, getSelectIndex(ui));
    //var ar=[];
    var ls_NextPageEnable = ls_changeSeq[getSelectIndex(ui)].split(',');
    for (i = 0; i < ls_NextPageEnable.length; i++) //{
        //ar.push(parseInt(ls_NextPageEnable[i]));
        EnableTabs(tabs, parseInt(ls_NextPageEnable[i]));
    //}
    //EnableTabsAll(tabs,ar);
    //alert(ls_NextPageEnable);
}




