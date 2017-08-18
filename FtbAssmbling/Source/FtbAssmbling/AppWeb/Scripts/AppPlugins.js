(function ($) {
    //左補字元
    $.fn.autoPadLeft = function (len, c) {
        if (!c || c == '' || !len || len == NaN)
            return;

        $(this).blur(function () {
            var v = $(this).val();
            if (!v || v == '')
                return;
            $(this).val(padLeft(v, len, c));
        });
        return this;
    };
    
    //右補字元
    $.fn.autoPadRight = function (len, c) {
        if (!c || c == '' || !len || len == NaN)
            return;

        $(this).blur(function () {
            var v = $(this).val();
            if (!v || v == '')
                return;
            $(this).val(padRight(v, len, c));
        });
        return this;
    };
    
    //基金
    $.fn.fund = function (org) {
        var fund = $(this);
        $(org).on('change', function () {
            fund.empty();
            var orgId = $(org).val();
            if (!orgId || orgId == "") {
                return;
            }
            fund.append('<option value="">請選擇</option>');
            $.ajax({
                url: '/Home/AJAX_Data',
                type: "GET",
                data: {
                    CodeKind: "FUD",
                    OrgId: orgId
                },
                success: function (states) {
                    $.each(states, function (i, state) {
                        fund.append('<option value="' + state.SYC_Code + '">' + state.SYC_CodeName + '</option>');
                    });
                },
                error: function (xhr, statusText, errorThrown) {
                    window.top.ShowMessage(errorThrown);
                }
            });
        });
        return this;
    };

    //財產編號
    $.fn.propertyNo = function (org, kind) {
        //群組名稱
        var groupName = $(this).attr('data-cqgroup');
        //未設定群組，無需查詢
        if (!groupName || groupName == '') {
            return;
        }
        //取出同群組欄位
        var members = $('input[data-cqgroup="' + groupName + '"],select[data-cqgroup="' + groupName + '"],textarea[data-cqgroup="' + groupName + '"]');

        //預設：所有財產
        if (!kind)
            kind = "";

        $(this).bind('input propertychange', function () {
            var id = $(this).attr('id');
            //先清空欄位
            members.each(function (obj) {
                if ($(this).attr('id') != id) {
                    $(this).val('').change();
                }
            });

            var v = $(this).val();
            if (!v || v == "") {
                return;
            }

            $.ajax({
                url: '/SyPropertyCode/getPropertyByCode',
                type: 'POST',
                dataType: 'json',
                data: {
                    orgId: $(org).val(),
                    kind: kind,
                    code: $(this).val()
                },
                success: function (data) {
                    $.map(data, function (item) {
                        members.each(function (obj) {
                            if ($(this).attr('id') != id) {
                                //取得參照的資料來源欄位
                                var fld = $(this).attr('data-cqfield');
                                if (fld) {
                                    $(this).val(item[fld]).change();
                                }
                            }
                        });
                    })
                },
                error: function (jqXHR, textStatus, errorThrown) {
                    window.top.ShowMessage(errorThrown);
                }
            })
        });
        return this;
    };

    //保管單位/使用單位
    $.fn.keepUnit = function (org) {
        var unit = $(this);
        $(org).change(function () {
            unit.empty();
            var orgId = $(org).val();
            if (!orgId || orgId == "") {
                return;
            }
            unit.append('<option value="">請選擇</option>');
            $.ajax({
                type: 'POST',
                url: '/UnitMovable/GetKeepUnit',
                dataType: 'json',
                data: {
                    id: orgId
                },
                success: function (states) {
                    $.each(states, function (i, state) {
                        unit.append('<option value="' + state.Value + '">' + state.Text + '</option>');
                    });
                    unit.trigger('change');
                },
                error: function (ex) {
                    window.top.ShowMessage('Failed to retrieve states.' + ex);
                }
            });
        });
        return this;
    };

    //保管人/使用人(輸入用->需指定單位)
    $.fn.keeper = function (unit) {
        var keeper = $(this);
        $(unit).change(function () {
            keeper.empty();
            var unitId = $(unit).val();
            if (!unitId || unitId == "") {
                return;
            }
            keeper.append('<option value="">請選擇</option>');
            $.ajax({
                type: 'POST',
                url: '/UnitMovable/GetKeeper',
                dataType: 'json',
                data: {
                    id: unitId
                },
                success: function (states) {
                    $.each(states, function (i, state) {
                        keeper.append('<option value="' + state.Value + '">' + state.Text + '</option>');
                    });
                },
                error: function (ex) {
                    window.top.ShowMessage('Failed to retrieve states.' + ex);
                }
            });
            return false;
        });
        return this;
    };

    //保管人/使用人(查詢用->可不指定單位)
    $.fn.keeper2 = function (org, unit) {
        var keeper = $(this);
        $(unit).change(function () {
            keeper.empty();
            var orgId = $(org).val();
            if (!orgId || orgId == "") {
                return;
            }
            var unitId = $(unit).val();
            if (!unitId) {
                unitId = "";
            }
            keeper.append('<option value="">請選擇</option>');
            $.ajax({
                type: 'POST',
                url: '/UnitMovable/GetKeeperForQuery',
                dataType: 'json',
                data: {
                    orgId: orgId,
                    unitId: unitId
                },
                success: function (states) {
                    $.each(states, function (i, state) {
                        keeper.append('<option value="' + state.Value + '">' + state.Text + '</option>');
                    });
                },
                error: function (ex) {
                    window.top.ShowMessage('Failed to retrieve states.' + ex);
                }
            });
            return false;
        });
        return this;
    };

    //保管單位/使用單位(多重)
    $.fn.linkUnits = function (arrUnits) {
        $(this).change(function () {
            $.each(arrUnits, function (i, unit) {
                $(unit).empty();
                $(unit).append('<option value="">請選擇</option>');
            });
            $.ajax({
                type: 'POST',
                url: '/UnitMovable/GetKeepUnit',
                dataType: 'json',
                data: {
                    id: $(this).val()
                },
                success: function (states) {
                    $.each(arrUnits, function (i, unit) {
                        $.each(states, function (i, state) {
                            $(unit).append('<option value="' + state.Value + '">' + state.Text + '</option>');
                        });
                        $(unit).trigger('change');
                    });
                },
                error: function (ex) {
                    window.top.ShowMessage('Failed to retrieve states.' + ex);
                }
            });
        });
        return this;
    };

    //檔案上傳
    $.fn.fileUpload = function (options) {
        //options 預設值
        options = $.extend({
            action: '/FileManager/Upload',
            sys: '',            //系統別
            objectId: '',       //物件id
            groupCode: '',      //群組代號
            multiple: true,     //預設允許選取多張圖片
            maxLongSide: 1024,  //長邊最大值
            accept: "image/*",  //允許的檔案類型
            maxSize: 10,        //允許檔案大小(MB)
            maxCount: 0,        //允許檔案數
            progress: null,
            fileList: null,
            onSubmit: function () { },
            onComplete: function () { }
        }, options);

        var multiple = (options.multiple) ? 'multiple' : '';
        this.css({ padding: 0, textAlign: 'left' });
        var btnWidth = 80; 
        var btnHeight = 32; 

        var btn = $('<div class="upload-button"></div>');

        var input = $(
			'<input type="file" name="fileData[]" accept="' + options.accept + '" ' + multiple + '/>'
		).css({
		    position: 'absolute', width: btnWidth, height: btnHeight,
		    opacity: 0, fontSize: 0, cursor: 'pointer'
		});

        var innertext = $(
			'<div>' + this.html() + '</div>'
		).css({
		    padding: '3px', textAlign: 'center', verticalAlign: 'middle'
		});

        var progress = $('<span>上傳中...</span>');
        if (!options.groupCode)
            options.groupCode = "";
        var fileList = $('<div id="list_' + options.objectId + '_' + options.groupCode + '"></div>');

        btn.append(input).append(innertext);
        this.empty().append(btn).append(progress).append(fileList);

        progress.hide();
        options.progress = progress;
        options.fileList = fileList;

        input.on('click', function () {
            this.value = null;
        }).on('change', function () {
            var files = this.files;
            //console.log(files);
            var i, file;
            for (i = 0; i < files.length; i++) {
                file = files[i];
                if (file.type.match(/image.*/)) {
                    uploadImage(file, options);
                } else {
                    uploadDirect(file, options);
                }
            }
        });

        loadFileList(options.sys, options.objectId, options.groupCode, options.fileList, false);
        return this;
    };

    //上傳完成
    function uploadCompleted(responseJSON, options) {
        if (responseJSON.Result != "OK") {
            window.top.ShowMessage(responseJSON.Message);
            return;
        }

        var divFile = $('<div id="file_' + responseJSON.File.FileId + '"></div>');
        var delBtn = $(
            '<input type="button" onclick="deleteFile(\'' + options.sys + '\',\'' + responseJSON.File.FileId + '\')" value="刪除" >'
        );
        var link = $(
            '<span id="filename_' + responseJSON.File.FileId + '" onclick="downloadFile(\'' + options.sys + '\',\'' + responseJSON.File.FileId + '\')">' + responseJSON.File.FileName + '</span>'
        ).css({
            cursor: 'pointer', margin: '0px 10px'
        });
        divFile.append(delBtn).append(link);
        options.fileList.append(divFile);
    }

    //直接上傳(不縮圖)
    function uploadDirect(file, options) {
        try {
            var maxSize = options.maxSize;
            if (maxSize > 0 && file.size > maxSize * 1024 * 1024) {
                window.top.ShowMessage("單一檔案大小需小於 " + maxSize + " MB");
                return;
            }

            //隨機產生一個id，用來辨別不同的上傳檔案
            var id = Math.random().toString(36).substring(3, 7);
            options.progress.show();
            options.onSubmit(id);

            var formData = new FormData
            formData.append("sys", options.sys);
            formData.append("objectId", options.objectId);
            formData.append("groupCode", options.groupCode);
            formData.append("file", file);

            $.ajax({
                url: "/FileManager/Upload",
                type: "POST",
                //dataType: "multipart/form-data",
                contentType: false,
                processData: false,
                data: formData,
                success: function (responseJSON) {
                    options.progress.hide();
                    uploadCompleted(responseJSON, options)
                    options.onComplete(responseJSON, id);
                },
                error: function (message) {
                    options.progress.hide();
                    window.top.ShowMessage(message);
                }
            });
        }
        catch (ex) {
            window.top.ShowMessage(ex);
        }
    }

    //上傳圖檔(前端縮圖後再上傳)
    function uploadImage(file, options) {
        var type = file.type;
        var src = window.URL.createObjectURL(file);
        //隨機產生一個id，用來辨別不同的上傳檔案
        var id = Math.random().toString(36).substring(3, 7);

        options.progress.show();
        options.onSubmit(id);

        var img = document.createElement("img");
        img.src = src;
        img.onload = function () {
            var width = this.width,
				height = this.height,
				maxLongSide = options.maxLongSide;

            //寬或高大於設定的上限時，等比例縮小到符合上限
            if (width > height) {
                if (maxLongSide > 0 && width > maxLongSide) {
                    height *= maxLongSide / width;
                    width = maxLongSide;
                }
            } else {
                if (maxLongSide > 0 && height > maxLongSide) {
                    width *= maxLongSide / height;
                    height = maxLongSide;
                }
            }
            //使用縮小後的寬高建立一個canvas
            var canvas = document.createElement("canvas");
            canvas.width = width;
            canvas.height = height;
            var ctx = canvas.getContext("2d");
            ctx.drawImage(img, 0, 0, width, height);
            //將canvas轉為圖片的base64編碼
            var dataurl = canvas.toDataURL(type);
            //去掉 dataurl 開頭的 data:image/png;base64,
            var regex = new RegExp('^data:' + type + ';base64,');
            var base64 = dataurl.replace(regex, '');

            //將圖片的base64編碼上傳至網站，將回傳的JSON傳至onComplete
            $.post(
                '/FileManager/UploadImage', //options.action,
                {
                    sys: options.sys,
                    objectId: options.objectId,
                    groupCode: options.groupCode,
                    fileName: file.name,
                    base64: base64
                },
                function (responseText) {
                    options.progress.hide();
                    if (!responseText.match(/^[\{\[]/)) {
                        window.top.ShowMessage(responseText);
                        return;
                    }
                    var responseJSON = JSON.parse(responseText);
                    uploadCompleted(responseJSON, options)
                    options.onComplete(responseJSON, id);
                },
                'text'
            );
        };
    }
})(jQuery);

//下載檔案
function downloadFile(sys, fileId) {
    window.top.open('/FileManager/Download/?sys=' + sys + '&fileId=' + fileId);
}

//刪除檔案
function deleteFile(sys, fileId) {
    $.ajax({
        url: "/FileManager/Delete",
        type: "POST",
        dataType: "json",
        //contentType: false,
        //processData: false,
        data: {
            sys: sys,
            fileId: fileId
        },
        success: function (responseJSON) {
            if (responseJSON.Result != "OK") {
                window.top.ShowMessage(responseJSON.Message);
                return;
            }

            var link = $("div#file_" + fileId);
            link.remove();
        },
        error: function (message) {
            window.top.ShowMessage('刪除檔案發生錯誤');
        }
    });
}

//載入檔案清單
function loadFileList(sys, objId, groupCode, fileList, viewOnly) {
    $.ajax({
        url: "/FileManager/GetFileList",
        type: "POST",
        dataType: "json",
        data: {
            sys: sys,
            objectId: objId,
            groupCode: groupCode
        },
        success: function (responseJSON) {
            fileList.empty();
            if (responseJSON.Result != "OK") {
                window.top.ShowMessage(responseJSON.Message);
                return;
            }
            $.each(responseJSON.Files, function (i, file) {
                var divFile = $('<div id="file_' + file.FileId + '"></div>');
                if (!viewOnly) {
                    var delBtn = $(
                        '<input type="button" onclick="deleteFile(\'' + sys + '\',\'' + file.FileId + '\')" value="刪除" >'
                    );
                    divFile.append(delBtn);
                }
                var link = $(
                    '<span id="filename_' + file.FileId + '" onclick="downloadFile(\'' + sys + '\',\'' + file.FileId + '\')">' + file.FileName + '</span>'
                ).css({
                    cursor: 'pointer', margin: '0px 10px'
                });
                divFile.append(link);
                fileList.append(divFile);
            });
        },
        error: function (message) {
            window.top.ShowMessage('載入檔案清單發生錯誤');
        }
    });
}

