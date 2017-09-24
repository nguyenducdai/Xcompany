app.directive('ckeditor', function () {
    return {
        require: '?ngModel',
        link: function (scope, elm, attr, ngModel) {
            console.log(elm);
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
   $('#dataTable').DataTable();
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