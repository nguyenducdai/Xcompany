app.directive('ckeditor', function () {
    return {
        require: '?ngModel',
        link: function (scope, elm, attr, ngModel) {
            var ck = CKEDITOR.replace(elm[0]);
            if (!ngModel) return;
            ck.on('instanceReady', function () {
                ck.setData(ngModel.$viewValue);
            });
            function updateModel() {
                scope.$apply(function () {
                    ngModel.$setViewValue(ck.getData());
                });
            }
            ck.on('change', updateModel);
            ck.on('key', updateModel);
            ck.on('dataReady', updateModel);

            ngModel.$render = function (value) {
                ck.setData(ngModel.$viewValue);
            };
        }
    };
});

function renderDatatable() {
    $('#dataTable').DataTable({
        "processing": true,
        "serverSide": true,
        "scrollX": true,
        //"language": {
        //    "lengthMenu": 'Display <select>' +
        //    '<option value="20" >20</option>' +
        //    '<option value="50">50</option>' +
        //    '<option value="100">100</option>' +
        //    '<option value="200">200</option>' +
        //    '<option value="500">500</option>' +
        //    '</select> records'
        //},
        //"iDisplayLenght":100,
    });
}

function MessageEvent(msg, idisplay, typeError) {
    var html = "";
    if (typeError == 's') {
        html += '<div class="alert alert-success alert-dismissible" >';
        html += '<a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a>';
        html += '<strong>[success!]</strong> ' + msg;
        html += '</div>';
    } else if (typeError == 'w') {
        html += '< div class="alert alert-warning alert-dismissible" >';
        html += '<a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a>';
        html += '<strong>[warning]</strong> ' + msg;
        html += '</div>';
    } else {
        html += '< div class="alert alert-danger alert-dismissible" >';
        html += '<a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a>';
        html += '<strong>[error]</strong> ' + msg;
        html += '</div>';
    }
    $(idisplay).css({ "display": "block" });
    $(idisplay).html(html);
}

$(".modal-wide").on("show.bs.modal", function () {
    var height = $(window).height() - 200;
    $(this).find(".modal-body").css("max-height", height);
});

function Alias(str) {
    var alStr;
    if (str != null) {
        alStr = str.toLowerCase();
        //Đổi ký tự có dấu thành không dấu
        alStr = alStr.replace(/á|à|ả|ạ|ã|ă|ắ|ằ|ẳ|ẵ|ặ|â|ấ|ầ|ẩ|ẫ|ậ/gi, 'a');
        alStr = alStr.replace(/é|è|ẻ|ẽ|ẹ|ê|ế|ề|ể|ễ|ệ/gi, 'e');
        alStr = alStr.replace(/i|í|ì|ỉ|ĩ|ị/gi, 'i');
        alStr = alStr.replace(/ó|ò|ỏ|õ|ọ|ô|ố|ồ|ổ|ỗ|ộ|ơ|ớ|ờ|ở|ỡ|ợ/gi, 'o');
        alStr = alStr.replace(/ú|ù|ủ|ũ|ụ|ư|ứ|ừ|ử|ữ|ự/gi, 'u');
        alStr = alStr.replace(/ý|ỳ|ỷ|ỹ|ỵ/gi, 'y');
        alStr = alStr.replace(/đ/gi, 'd');
        //Xóa các ký tự đặt biệt
        alStr = alStr.replace(/\`|\~|\!|\@|\#|\||\$|\%|\^|\&|\*|\(|\)|\+|\=|\,|\.|\/|\?|\>|\<|\'|\"|\:|\;|_/gi, '');
        //Đổi khoảng trắng thành ký tự gạch ngang
        alStr = alStr.replace(/ /gi, " - ");
        //Đổi nhiều ký tự gạch ngang liên tiếp thành 1 ký tự gạch ngang
        //Phòng trường hợp người nhập vào quá nhiều ký tự trắng
        alStr = alStr.replace(/\-\-\-\-\-/gi, '-');
        alStr = alStr.replace(/\-\-\-\-/gi, '-');
        alStr = alStr.replace(/\-\-\-/gi, '-');
        alStr = alStr.replace(/\-\-/gi, '-');
        //Xóa các ký tự gạch ngang ở đầu và cuối
        alStr = '@' + alStr + '@';
        alStr = alStr.replace(/\@\-|\-\@|\@/gi, '');
    }
   
    //In alStr ra textbox có id “alStr”
    return alStr;
}


function moveFile(pathFIle,folder) {
    var object = new ActiveXObject("Scripting.FileSystemObject");
    var file = object.GetFile(pathFIle);
    var folder = "../../Upload/";
    file.Move(folder);
}