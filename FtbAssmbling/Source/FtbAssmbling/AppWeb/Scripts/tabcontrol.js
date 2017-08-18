//August Lee 2014/11/21 Copy right

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
            var $this = $(this),
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

function init() {
    pages = new Array();
    var $defaultLi = $('ul.tabs li');
    try
    {
        for (i = 0; i < $defaultLi.length; i++) {
            var str = $($defaultLi[i].innerHTML.toString()).attr('href');
            pages.push(str);
        }
    }
    catch (e) {
        var x = e.toString();
    }
}

function getCurrentPage() {
    return currentpage.toString();
}

//頁面切換順序放入陣列
function changeSeq(Seq) {
    ls_changeSeq = Seq.toString().split(';');
    var x = 1;
}

//取得目前頁面index
function getPageIndex(pagename) {
    var index=0; 
    for (i = 0; i < pages.length; i++)
        if (pages[i] == pagename)
            index = i;
    return index;
}

//回傳陣列
function NextEnablePageIndex(NowPageIndex) {
    return ls_changeSeq[NowPageIndex].split(',');
}

function IsChangeAble(NowPageName, NextPageName) {
    if (pages.length == 0 | ls_changeSeq.length==0) //沒設定順序就全部都可以隨意切換
        return true;
    
    var NowPageIndex = getPageIndex(NowPageName);
    var NextPageIndex=getPageIndex(NextPageName);
    var ls_NextPageEnable = NextEnablePageIndex(NowPageIndex);
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
function switchpage(page) {
    var link = $('ul.tabs li');
    for (i = 0; i < link.length; i++) {
        var href = link[i].textContent;
        if (page==href)
            link[i].click();
    }
}




