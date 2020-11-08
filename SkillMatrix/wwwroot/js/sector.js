$(document).ready(function () {
    $('body').off('click', '#btn-add').on('click', '#btn-add', Search);

    function Search() {
        var _tranferSector = $('#txt-sector').val();
        debugger
        $.ajax({
            type: 'post',
            url: '/Sector/FindSector',
            dataType: 'json',
            data: { sectorName: _tranferSector },
            success: function (response) {
                if (_tranferSector == "") {
                    bootbox.alert('Vui lòng nhập sector')
                }
                else {

                    var data = response.result;

                    if (data == null) {
                        bootbox.alert(`khong tim thay ${_tranferSector}?`)
                        AddSector();
                    }
                    else {
                        bootbox.alert(`${_tranferSector}? đã tồn tại`)
                        $('#sap').text(data.sector);
                    }
                }
                
            }
        })
      
    }

    function AddSector() {
        var model = new Object();

        model.Sector = $('#txt-sector').val();

        debugger
        $.ajax({
            type: 'post',
            url: '/Sector/Add',
            dataType: 'json',
            data: JSON.stringify(model),
            contentType: "application/json; charset=utf-8",

            success: function (response) {

                if (response.statusCode == 200) {

                    bootbox.alert("OK")

                } else {

                    bootbox.alert("Error")

                }
            }
        })
    }

   
})