//中文化 ValidationEngine 
//August Lee Create 2014/10/20
(function ($) {
    $.fn.validationEngineLanguage = function() {
    };   
    $.validationEngineLanguage = {   
        newLang: function() {   
            $.validationEngineLanguage.allRules =   {"required":{               // Add your regex rules here, you can take telephone as an example   
                "regex":"none",   
                "alertText":"* 選項為必填欄位.",   
                "alertTextCheckboxMultiple":"* 請選擇一個單選項目.",   
                "alertTextCheckboxe":"* 請選擇一個複選項目."},   
                "length":{   
                    "regex":"none",   
                    "alertText":"* 長度必須在 ",   
                    "alertText2":" 至 ",   
                    "alertText3": " 之間."},   
                "maxCheckbox":{   
                    "regex":"none",   
                    "alertText":"* 最多選擇 ",
                    "alertText2":" 項."},       
                "minCheckbox":{   
                    "regex":"none",   
                    "alertText":"* 最少選擇 ",   
                    "alertText2":" 項."},       
                "confirm":{   
                    "regex":"none",   
                    "alertText":"* 兩次輸入不一致,請重新輸入."},           
                "telephone":{   
                    "regex":"/^(0[0-9]{2,3}\-)?([2-9][0-9]{6,7})+(\-[0-9]{1,4})?$/",   
                    "alertText":"* 請輸入有效的電話號碼,如:010-29292929."},   
                "mobilephone":{   
                    "regex":"/(^0?[1][358][0-9]{9}$)/",   
                    "alertText":"* 請輸入有效的手機號碼."},      
                "email":{   
                    "regex":"/^[a-zA-Z0-9_\.\-]+\@([a-zA-Z0-9\-]+\.)+[a-zA-Z0-9]{2,4}$/",   
                    "alertText":"* 請輸入有效的Email."},      
                "date":{   
                    "regex":"/^(([0-9]{3}[1-9]|[0-9]{2}[1-9][0-9]{1}|[0-9]{1}[1-9][0-9]{2}|[1-9][0-9]{3})-(((0[13578]|1[02])-(0[1-9]|[12][0-9]|3[01]))|((0[469]|11)-(0[1-9]|[12][0-9]|30))|(02-(0[1-9]|[1][0-9]|2[0-8]))))|((([0-9]{2})(0[48]|[2468][048]|[13579][26])|((0[48]|[2468][048]|[3579][26])00))-02-29)$/",   
                    "alertText":"* 請輸入有效的日期,如:2008-08-08."},   
                "ip":{   
                    "regex":"/^(?:(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.){3}(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)$/",   
                    "alertText":"* 請輸入有效的IP."},   
                "chinese":{   
                    "regex":"/^[\u4e00-\u9fa5]+$/",   
                    "alertText":"*請輸入中文."},   
                "url":{   
                    "regex":"/^[a-zA-z]:\\/\\/[^s]$/",
                    "alertText":"* *請輸入有效的網址."},   
                "zipcode":{   
                    "regex":"/^[1-9]\d{5}$/",   
                    "alertText":"* *請輸入有效的郵遞區號."},   
                "onlyNumber":{   
                    "regex":"/^[0-9]+$/",   
                    "alertText":"* *請輸入數字."},   
                "onlyLetter":{   
                    "regex":"/^[a-zA-Z]+$/",   
                    "alertText":"* *請輸入英文字母."},   
                "noSpecialCaracters":{   
                    "regex":"/^[0-9a-zA-Z]+$/",   
                    "alertText":"* 请输入英文字母和数字."},      
                "ajaxUser":{   
                    "file":"validate.action",//ajax驗證用戶名稱，會post如下參數：validateError    ajaxUser；validateId user；validateValue  cccc   
                    "alertTextOk":"* 帳號可以使用.",     
                    "alertTextLoad":"* 檢查中中, 請稍候...",   
                    "alertText":"* 帳號不能使用."},      
                "ajaxName":{   
                    "file":"validateUser.php",   
                    "alertText":"* This name is already taken",   
                    "alertTextOk":"* This name is available",      
                    "alertTextLoad":"* Loading, please wait"}                      
            }      
        }   
    }   
})(jQuery);   
  
$(document).ready(function() {     
    $.validationEngineLanguage.newLang()   
});  